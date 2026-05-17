using Organized.Application.Achievements;
using Organized.Application.Common.Model;
using Organized.Domain.Entities.Meetings;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Meetings
{
    public class CreateMeetingRequest
    {
        public int CreatedByUserId { get; set; }
        public int MeetingRoomTableId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime MeetingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<int> AttendeeUserIds { get; set; } = new();
    }

    public class CreateMeetingRequestHandler : RequestHandler<CreateMeetingRequest, MeetingActionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AchievementTracker _achievementTracker;

        public CreateMeetingRequestHandler(IUnitOfWork unitOfWork, AchievementTracker achievementTracker)
        {
            _unitOfWork = unitOfWork;
            _achievementTracker = achievementTracker;
        }

        protected async override Task<Result<MeetingActionResponse>> HandleRequest(CreateMeetingRequest request, Result<MeetingActionResponse> result)
        {
            var creator = await _unitOfWork.UserRepository.GetById(request.CreatedByUserId);
            if (creator == null)
            {
                result.SetResult(new MeetingActionResponse(false, null, "User not found."));
                return result;
            }

            if (creator.Role != UserRole.Admin)
            {
                result.SetResult(new MeetingActionResponse(false, null, "Only admins can create meetings."));
                return result;
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                result.SetResult(new MeetingActionResponse(false, null, "Title is required."));
                return result;
            }

            if (request.StartTime >= request.EndTime)
            {
                result.SetResult(new MeetingActionResponse(false, null, "End time must be after start time."));
                return result;
            }

            if (request.MeetingDate.Date < DateTime.UtcNow.Date)
            {
                result.SetResult(new MeetingActionResponse(false, null, "Meeting date cannot be in the past."));
                return result;
            }

            var room = await _unitOfWork.CompanyTableRepository.GetById(request.MeetingRoomTableId);
            if (room == null || !room.IsMeetingRoom)
            {
                result.SetResult(new MeetingActionResponse(false, null, "Selected room is not a meeting room."));
                return result;
            }

            var distinctAttendees = request.AttendeeUserIds.Distinct().Where(id => id != request.CreatedByUserId).ToList();
            if (distinctAttendees.Count == 0)
            {
                result.SetResult(new MeetingActionResponse(false, null, "Select at least one attendee."));
                return result;
            }

            if (distinctAttendees.Count > room.Capacity)
            {
                result.SetResult(new MeetingActionResponse(false, null, $"Too many attendees. Room capacity is {room.Capacity}."));
                return result;
            }

            var attendees = (await _unitOfWork.UserRepository.GetByIds(distinctAttendees)).ToList();
            if (attendees.Count != distinctAttendees.Count)
            {
                result.SetResult(new MeetingActionResponse(false, null, "One or more attendees were not found."));
                return result;
            }

            var meetingDay = DateTime.SpecifyKind(request.MeetingDate.Date, DateTimeKind.Utc);

            var roomConflict = await _unitOfWork.MeetingRepository.FindRoomConflict(
                request.MeetingRoomTableId, meetingDay, request.StartTime, request.EndTime);
            if (roomConflict != null)
            {
                result.SetResult(new MeetingActionResponse(false, null,
                    $"Room is already booked {roomConflict.StartTime:hh\\:mm}–{roomConflict.EndTime:hh\\:mm} by \"{roomConflict.Title}\"."));
                return result;
            }

            var participantIds = distinctAttendees.Concat(new[] { request.CreatedByUserId }).Distinct().ToList();
            var busyIds = await _unitOfWork.MeetingRepository.FindBusyUserIds(
                participantIds, meetingDay, request.StartTime, request.EndTime);
            if (busyIds.Count > 0)
            {
                var busyNames = new List<string>();
                if (busyIds.Contains(creator.Id) && !string.IsNullOrWhiteSpace(creator.Name))
                {
                    busyNames.Add(creator.Name);
                }
                busyNames.AddRange(attendees
                    .Where(a => busyIds.Contains(a.Id) && !string.IsNullOrWhiteSpace(a.Name))
                    .Select(a => a.Name!));

                var who = busyNames.Count > 0 ? string.Join(", ", busyNames) : "Some participants";
                result.SetResult(new MeetingActionResponse(false, null,
                    $"{who} already have a meeting at this time."));
                return result;
            }

            var meeting = new Meeting
            {
                CreatedByUserId = request.CreatedByUserId,
                MeetingRoomTableId = request.MeetingRoomTableId,
                Title = request.Title.Trim(),
                Description = string.IsNullOrWhiteSpace(request.Description) ? null : request.Description.Trim(),
                MeetingDate = meetingDay,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Status = MeetingStatus.Scheduled
            };

            await _unitOfWork.CreateTransaction();
            try
            {
                await _unitOfWork.MeetingRepository.InsertAsync(meeting);
                await _unitOfWork.SaveAsync();

                foreach (var attendeeId in distinctAttendees)
                {
                    var invite = new MeetingInvite
                    {
                        MeetingId = meeting.Id,
                        UserId = attendeeId,
                        Status = MeetingInviteStatus.Pending
                    };
                    await _unitOfWork.MeetingInviteRepository.InsertAsync(invite);
                }
                await _unitOfWork.SaveAsync();
                await _unitOfWork.Commit();
            }
            catch
            {
                await _unitOfWork.Rollback();
                throw;
            }

            await _achievementTracker.TrackMeetingCreated(request.CreatedByUserId);

            result.SetResult(new MeetingActionResponse(true, meeting.Id));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

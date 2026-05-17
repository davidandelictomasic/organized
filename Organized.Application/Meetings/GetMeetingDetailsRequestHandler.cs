using Organized.Application.Common.Model;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Meetings
{
    public class GetMeetingDetailsRequest
    {
        public int MeetingId { get; set; }
    }

    public class MeetingAttendeeResponse
    {
        public int UserId { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
        public MeetingInviteStatus Status { get; init; }
        public DateTime? RespondedAt { get; init; }
    }

    public class MeetingDetailsResponse
    {
        public int MeetingId { get; init; }
        public int CreatedByUserId { get; init; }
        public string? CreatorName { get; init; }
        public int MeetingRoomTableId { get; init; }
        public string Title { get; init; } = string.Empty;
        public string? Description { get; init; }
        public DateTime MeetingDate { get; init; }
        public TimeSpan StartTime { get; init; }
        public TimeSpan EndTime { get; init; }
        public MeetingStatus Status { get; init; }
        public DateTime CreatedAt { get; init; }
        public List<MeetingAttendeeResponse> Attendees { get; init; } = new();
    }

    public class GetMeetingDetailsRequestHandler : RequestHandler<GetMeetingDetailsRequest, MeetingDetailsResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMeetingDetailsRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<MeetingDetailsResponse>> HandleRequest(GetMeetingDetailsRequest request, Result<MeetingDetailsResponse> result)
        {
            var meeting = await _unitOfWork.MeetingRepository.GetById(request.MeetingId);
            if (meeting == null)
            {
                result.SetResult(null);
                return result;
            }

            var creator = await _unitOfWork.UserRepository.GetById(meeting.CreatedByUserId);
            var invites = (await _unitOfWork.MeetingInviteRepository.GetByMeeting(meeting.Id)).ToList();

            var attendees = new List<MeetingAttendeeResponse>();
            if (invites.Count > 0)
            {
                var users = (await _unitOfWork.UserRepository.GetByIds(invites.Select(i => i.UserId).Distinct())).ToDictionary(u => u.Id);
                foreach (var invite in invites)
                {
                    if (!users.TryGetValue(invite.UserId, out var user)) continue;
                    attendees.Add(new MeetingAttendeeResponse
                    {
                        UserId = invite.UserId,
                        Name = user.Name,
                        Email = user.Email,
                        Status = invite.Status,
                        RespondedAt = invite.RespondedAt
                    });
                }
            }

            result.SetResult(new MeetingDetailsResponse
            {
                MeetingId = meeting.Id,
                CreatedByUserId = meeting.CreatedByUserId,
                CreatorName = creator?.Name,
                MeetingRoomTableId = meeting.MeetingRoomTableId,
                Title = meeting.Title,
                Description = meeting.Description,
                MeetingDate = meeting.MeetingDate,
                StartTime = meeting.StartTime,
                EndTime = meeting.EndTime,
                Status = meeting.Status,
                CreatedAt = meeting.CreatedAt,
                Attendees = attendees
            });
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

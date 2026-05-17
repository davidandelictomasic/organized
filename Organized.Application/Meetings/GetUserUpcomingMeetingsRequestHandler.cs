using Organized.Application.Common.Model;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Meetings
{
    public class GetUserUpcomingMeetingsRequest
    {
        public int UserId { get; set; }
    }

    public class UpcomingMeetingResponse
    {
        public int MeetingId { get; init; }
        public string Title { get; init; } = string.Empty;
        public string? Description { get; init; }
        public DateTime MeetingDate { get; init; }
        public TimeSpan StartTime { get; init; }
        public TimeSpan EndTime { get; init; }
        public int CreatedByUserId { get; init; }
        public string? CreatorName { get; init; }
    }

    public class GetUserUpcomingMeetingsRequestHandler : RequestHandler<GetUserUpcomingMeetingsRequest, List<UpcomingMeetingResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserUpcomingMeetingsRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<List<UpcomingMeetingResponse>>> HandleRequest(GetUserUpcomingMeetingsRequest request, Result<List<UpcomingMeetingResponse>> result)
        {
            var invites = (await _unitOfWork.MeetingInviteRepository.GetAcceptedFutureInvitesForUser(request.UserId, DateTime.UtcNow)).ToList();

            if (invites.Count == 0)
            {
                result.SetResult(new List<UpcomingMeetingResponse>());
                return result;
            }

            var meetingIds = invites.Select(i => i.MeetingId).Distinct();
            var meetings = (await _unitOfWork.MeetingRepository.GetByIds(meetingIds)).ToList();

            var creatorIds = meetings.Select(m => m.CreatedByUserId).Distinct();
            var creators = (await _unitOfWork.UserRepository.GetByIds(creatorIds)).ToDictionary(u => u.Id);

            var response = meetings
                .Select(m =>
                {
                    creators.TryGetValue(m.CreatedByUserId, out var creator);
                    return new UpcomingMeetingResponse
                    {
                        MeetingId = m.Id,
                        Title = m.Title,
                        Description = m.Description,
                        MeetingDate = m.MeetingDate,
                        StartTime = m.StartTime,
                        EndTime = m.EndTime,
                        CreatedByUserId = m.CreatedByUserId,
                        CreatorName = creator?.Name
                    };
                })
                .OrderBy(r => r.MeetingDate)
                .ThenBy(r => r.StartTime)
                .ToList();

            result.SetResult(response);
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

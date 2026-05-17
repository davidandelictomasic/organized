using Organized.Application.Common.Model;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Meetings
{
    public class GetUserMeetingInvitesRequest
    {
        public int UserId { get; set; }
    }

    public class PendingMeetingInviteResponse
    {
        public int InviteId { get; init; }
        public int MeetingId { get; init; }
        public string Title { get; init; } = string.Empty;
        public string? Description { get; init; }
        public DateTime MeetingDate { get; init; }
        public TimeSpan StartTime { get; init; }
        public TimeSpan EndTime { get; init; }
        public int CreatedByUserId { get; init; }
        public string? CreatorName { get; init; }
        public DateTime CreatedAt { get; init; }
    }

    public class GetUserMeetingInvitesRequestHandler : RequestHandler<GetUserMeetingInvitesRequest, List<PendingMeetingInviteResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserMeetingInvitesRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<List<PendingMeetingInviteResponse>>> HandleRequest(GetUserMeetingInvitesRequest request, Result<List<PendingMeetingInviteResponse>> result)
        {
            var invites = (await _unitOfWork.MeetingInviteRepository.GetActiveInvitesForUser(request.UserId, DateTime.UtcNow)).ToList();

            if (invites.Count == 0)
            {
                result.SetResult(new List<PendingMeetingInviteResponse>());
                return result;
            }

            var meetingIds = invites.Select(i => i.MeetingId).Distinct();
            var meetings = (await _unitOfWork.MeetingRepository.GetByIds(meetingIds)).ToDictionary(m => m.Id);

            var creatorIds = meetings.Values.Select(m => m.CreatedByUserId).Distinct();
            var creators = (await _unitOfWork.UserRepository.GetByIds(creatorIds)).ToDictionary(u => u.Id);

            var response = invites
                .Where(i => meetings.ContainsKey(i.MeetingId))
                .Select(i =>
                {
                    var meeting = meetings[i.MeetingId];
                    creators.TryGetValue(meeting.CreatedByUserId, out var creator);
                    return new PendingMeetingInviteResponse
                    {
                        InviteId = i.Id,
                        MeetingId = meeting.Id,
                        Title = meeting.Title,
                        Description = meeting.Description,
                        MeetingDate = meeting.MeetingDate,
                        StartTime = meeting.StartTime,
                        EndTime = meeting.EndTime,
                        CreatedByUserId = meeting.CreatedByUserId,
                        CreatorName = creator?.Name,
                        CreatedAt = i.CreatedAt
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

using Organized.Application.Common.Model;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Meetings
{
    public class GetMeetingsCreatedByAdminRequest
    {
        public int AdminUserId { get; set; }
    }

    public class AdminMeetingSummaryResponse
    {
        public int MeetingId { get; init; }
        public string Title { get; init; } = string.Empty;
        public string? Description { get; init; }
        public DateTime MeetingDate { get; init; }
        public TimeSpan StartTime { get; init; }
        public TimeSpan EndTime { get; init; }
        public int MeetingRoomTableId { get; init; }
        public MeetingStatus Status { get; init; }
        public int InviteCount { get; init; }
        public int AcceptedCount { get; init; }
        public int DeclinedCount { get; init; }
        public int PendingCount { get; init; }
    }

    public class GetMeetingsCreatedByAdminRequestHandler : RequestHandler<GetMeetingsCreatedByAdminRequest, List<AdminMeetingSummaryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMeetingsCreatedByAdminRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<List<AdminMeetingSummaryResponse>>> HandleRequest(GetMeetingsCreatedByAdminRequest request, Result<List<AdminMeetingSummaryResponse>> result)
        {
            var meetings = (await _unitOfWork.MeetingRepository.GetByCreator(request.AdminUserId)).ToList();

            if (meetings.Count == 0)
            {
                result.SetResult(new List<AdminMeetingSummaryResponse>());
                return result;
            }

            var response = new List<AdminMeetingSummaryResponse>(meetings.Count);
            foreach (var meeting in meetings)
            {
                var invites = (await _unitOfWork.MeetingInviteRepository.GetByMeeting(meeting.Id)).ToList();
                response.Add(new AdminMeetingSummaryResponse
                {
                    MeetingId = meeting.Id,
                    Title = meeting.Title,
                    Description = meeting.Description,
                    MeetingDate = meeting.MeetingDate,
                    StartTime = meeting.StartTime,
                    EndTime = meeting.EndTime,
                    MeetingRoomTableId = meeting.MeetingRoomTableId,
                    Status = meeting.Status,
                    InviteCount = invites.Count,
                    AcceptedCount = invites.Count(i => i.Status == MeetingInviteStatus.Accepted),
                    DeclinedCount = invites.Count(i => i.Status == MeetingInviteStatus.Declined),
                    PendingCount = invites.Count(i => i.Status == MeetingInviteStatus.Pending)
                });
            }

            result.SetResult(response);
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

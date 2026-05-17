using Organized.Application.Achievements;
using Organized.Application.Common.Model;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Meetings
{
    public class AcceptMeetingInviteRequest
    {
        public int UserId { get; set; }
        public int InviteId { get; set; }
    }

    public class AcceptMeetingInviteRequestHandler : RequestHandler<AcceptMeetingInviteRequest, MeetingActionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AchievementTracker _achievementTracker;

        public AcceptMeetingInviteRequestHandler(IUnitOfWork unitOfWork, AchievementTracker achievementTracker)
        {
            _unitOfWork = unitOfWork;
            _achievementTracker = achievementTracker;
        }

        protected async override Task<Result<MeetingActionResponse>> HandleRequest(AcceptMeetingInviteRequest request, Result<MeetingActionResponse> result)
        {
            var invite = await _unitOfWork.MeetingInviteRepository.GetById(request.InviteId);
            if (invite == null)
            {
                result.SetResult(new MeetingActionResponse(false, null, "Invite not found."));
                return result;
            }

            if (invite.UserId != request.UserId)
            {
                result.SetResult(new MeetingActionResponse(false, null, "You can't accept this invite."));
                return result;
            }

            if (invite.Status != MeetingInviteStatus.Pending)
            {
                result.SetResult(new MeetingActionResponse(false, null, "This invite is no longer pending."));
                return result;
            }

            var meeting = await _unitOfWork.MeetingRepository.GetById(invite.MeetingId);
            if (meeting == null || meeting.Status != MeetingStatus.Scheduled)
            {
                result.SetResult(new MeetingActionResponse(false, null, "Meeting is no longer active."));
                return result;
            }

            invite.Status = MeetingInviteStatus.Accepted;
            invite.RespondedAt = DateTime.UtcNow;
            _unitOfWork.MeetingInviteRepository.Update(invite);
            await _unitOfWork.SaveAsync();

            await _achievementTracker.TrackMeetingInviteAcceptReceived(meeting.CreatedByUserId);

            result.SetResult(new MeetingActionResponse(true, meeting.Id));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

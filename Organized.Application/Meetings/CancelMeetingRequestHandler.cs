using Organized.Application.Achievements;
using Organized.Application.Common.Model;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Meetings
{
    public class CancelMeetingRequest
    {
        public int UserId { get; set; }
        public int MeetingId { get; set; }
    }

    public class CancelMeetingRequestHandler : RequestHandler<CancelMeetingRequest, MeetingActionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AchievementTracker _achievementTracker;

        public CancelMeetingRequestHandler(IUnitOfWork unitOfWork, AchievementTracker achievementTracker)
        {
            _unitOfWork = unitOfWork;
            _achievementTracker = achievementTracker;
        }

        protected async override Task<Result<MeetingActionResponse>> HandleRequest(CancelMeetingRequest request, Result<MeetingActionResponse> result)
        {
            var meeting = await _unitOfWork.MeetingRepository.GetById(request.MeetingId);
            if (meeting == null)
            {
                result.SetResult(new MeetingActionResponse(false, null, "Meeting not found."));
                return result;
            }

            if (meeting.CreatedByUserId != request.UserId)
            {
                result.SetResult(new MeetingActionResponse(false, null, "Only the meeting creator can cancel it."));
                return result;
            }

            if (meeting.Status == MeetingStatus.Cancelled)
            {
                result.SetResult(new MeetingActionResponse(false, null, "Meeting is already cancelled."));
                return result;
            }

            meeting.Status = MeetingStatus.Cancelled;
            _unitOfWork.MeetingRepository.Update(meeting);

            var invites = await _unitOfWork.MeetingInviteRepository.GetByMeeting(meeting.Id);
            foreach (var invite in invites)
            {
                if (invite.Status == MeetingInviteStatus.Pending || invite.Status == MeetingInviteStatus.Accepted)
                {
                    invite.Status = MeetingInviteStatus.Cancelled;
                    _unitOfWork.MeetingInviteRepository.Update(invite);
                }
            }

            await _unitOfWork.SaveAsync();

            await _achievementTracker.TrackMeetingCancelled(meeting.CreatedByUserId);

            result.SetResult(new MeetingActionResponse(true, meeting.Id));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

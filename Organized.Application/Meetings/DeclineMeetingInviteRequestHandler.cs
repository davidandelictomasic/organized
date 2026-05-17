using Organized.Application.Common.Model;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Meetings
{
    public class DeclineMeetingInviteRequest
    {
        public int UserId { get; set; }
        public int InviteId { get; set; }
    }

    public class DeclineMeetingInviteRequestHandler : RequestHandler<DeclineMeetingInviteRequest, MeetingActionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeclineMeetingInviteRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<MeetingActionResponse>> HandleRequest(DeclineMeetingInviteRequest request, Result<MeetingActionResponse> result)
        {
            var invite = await _unitOfWork.MeetingInviteRepository.GetById(request.InviteId);
            if (invite == null)
            {
                result.SetResult(new MeetingActionResponse(false, null, "Invite not found."));
                return result;
            }

            if (invite.UserId != request.UserId)
            {
                result.SetResult(new MeetingActionResponse(false, null, "You can't decline this invite."));
                return result;
            }

            if (invite.Status != MeetingInviteStatus.Pending)
            {
                result.SetResult(new MeetingActionResponse(false, null, "This invite is no longer pending."));
                return result;
            }

            invite.Status = MeetingInviteStatus.Declined;
            invite.RespondedAt = DateTime.UtcNow;
            _unitOfWork.MeetingInviteRepository.Update(invite);
            await _unitOfWork.SaveAsync();

            result.SetResult(new MeetingActionResponse(true, invite.MeetingId));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

using Organized.Application.Common.Model;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Friends
{
    public class DeclineFriendRequestRequest
    {
        public int UserId { get; set; }
        public int RequestId { get; set; }
    }

    public class DeclineFriendRequestRequestHandler : RequestHandler<DeclineFriendRequestRequest, FriendActionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeclineFriendRequestRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<FriendActionResponse>> HandleRequest(DeclineFriendRequestRequest request, Result<FriendActionResponse> result)
        {
            var friendRequest = await _unitOfWork.FriendRequestRepository.GetById(request.RequestId);

            if (friendRequest == null)
            {
                result.SetResult(new FriendActionResponse(false, "Friend request not found."));
                return result;
            }

            if (friendRequest.ReceiverId != request.UserId)
            {
                result.SetResult(new FriendActionResponse(false, "You can't decline this request."));
                return result;
            }

            if (friendRequest.Status != FriendRequestStatus.Pending)
            {
                result.SetResult(new FriendActionResponse(false, "This request is no longer pending."));
                return result;
            }

            friendRequest.Status = FriendRequestStatus.Declined;
            _unitOfWork.FriendRequestRepository.Update(friendRequest);
            await _unitOfWork.SaveAsync();

            result.SetResult(new FriendActionResponse(true));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

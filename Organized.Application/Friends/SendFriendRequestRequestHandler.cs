using Organized.Application.Common.Model;
using Organized.Domain.Entities.Friends;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Friends
{
    public class SendFriendRequestRequest
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }

    public class SendFriendRequestRequestHandler : RequestHandler<SendFriendRequestRequest, FriendActionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SendFriendRequestRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<FriendActionResponse>> HandleRequest(SendFriendRequestRequest request, Result<FriendActionResponse> result)
        {
            if (request.SenderId == request.ReceiverId)
            {
                result.SetResult(new FriendActionResponse(false, "You can't send a friend request to yourself."));
                return result;
            }

            var receiver = await _unitOfWork.UserRepository.GetById(request.ReceiverId);
            if (receiver == null)
            {
                result.SetResult(new FriendActionResponse(false, "User not found."));
                return result;
            }

            if (await _unitOfWork.FriendshipRepository.AreFriends(request.SenderId, request.ReceiverId))
            {
                result.SetResult(new FriendActionResponse(false, "You are already friends."));
                return result;
            }

            var existingOutgoing = await _unitOfWork.FriendRequestRepository.GetPendingRequest(request.SenderId, request.ReceiverId);
            if (existingOutgoing != null)
            {
                result.SetResult(new FriendActionResponse(false, "You already have a pending request to this user."));
                return result;
            }

            var existingIncoming = await _unitOfWork.FriendRequestRepository.GetPendingRequest(request.ReceiverId, request.SenderId);
            if (existingIncoming != null)
            {
                result.SetResult(new FriendActionResponse(false, "This user has already sent you a friend request."));
                return result;
            }

            var friendRequest = new FriendRequest
            {
                SenderId = request.SenderId,
                ReceiverId = request.ReceiverId
            };
            await _unitOfWork.FriendRequestRepository.InsertAsync(friendRequest);
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

using Organized.Application.Achievements;
using Organized.Application.Common.Model;
using Organized.Domain.Entities.Friends;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Friends
{
    public class AcceptFriendRequestRequest
    {
        public int UserId { get; set; }
        public int RequestId { get; set; }
    }

    public class AcceptFriendRequestRequestHandler : RequestHandler<AcceptFriendRequestRequest, FriendActionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AchievementTracker _achievementTracker;

        public AcceptFriendRequestRequestHandler(IUnitOfWork unitOfWork, AchievementTracker achievementTracker)
        {
            _unitOfWork = unitOfWork;
            _achievementTracker = achievementTracker;
        }

        protected async override Task<Result<FriendActionResponse>> HandleRequest(AcceptFriendRequestRequest request, Result<FriendActionResponse> result)
        {
            var friendRequest = await _unitOfWork.FriendRequestRepository.GetById(request.RequestId);

            if (friendRequest == null)
            {
                result.SetResult(new FriendActionResponse(false, "Friend request not found."));
                return result;
            }

            if (friendRequest.ReceiverId != request.UserId)
            {
                result.SetResult(new FriendActionResponse(false, "You can't accept this request."));
                return result;
            }

            if (friendRequest.Status != FriendRequestStatus.Pending)
            {
                result.SetResult(new FriendActionResponse(false, "This request is no longer pending."));
                return result;
            }

            friendRequest.Status = FriendRequestStatus.Accepted;
            _unitOfWork.FriendRequestRepository.Update(friendRequest);

            var friendship = new Friendship
            {
                UserId = friendRequest.SenderId,
                FriendId = friendRequest.ReceiverId
            };
            await _unitOfWork.FriendshipRepository.InsertAsync(friendship);
            await _unitOfWork.SaveAsync();

            await _achievementTracker.TrackFriendAdded(friendRequest.SenderId);
            await _achievementTracker.TrackFriendAdded(friendRequest.ReceiverId);

            result.SetResult(new FriendActionResponse(true));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

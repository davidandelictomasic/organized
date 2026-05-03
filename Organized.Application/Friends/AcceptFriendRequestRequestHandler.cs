using Organized.Application.Common.Model;
using Organized.Domain.Entities.Achievements;
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
        private static readonly int[] FriendAchievementIds = new[] { 108, 109 };

        private readonly IUnitOfWork _unitOfWork;

        public AcceptFriendRequestRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            await UpdateFriendAchievements(friendRequest.SenderId);
            await UpdateFriendAchievements(friendRequest.ReceiverId);
            await _unitOfWork.SaveAsync();

            result.SetResult(new FriendActionResponse(true));
            return result;
        }

        private async Task UpdateFriendAchievements(int userId)
        {
            var friendCount = (await _unitOfWork.FriendshipRepository.GetByUserId(userId)).Count();

            foreach (var achievementId in FriendAchievementIds)
            {
                var userAchievement = await _unitOfWork.UserAchievementRepository.GetByUserAndAchievement(userId, achievementId);
                var isNew = false;

                if (userAchievement == null)
                {
                    var achievement = await _unitOfWork.AchievementRepository.GetById(achievementId);
                    if (achievement == null) continue;

                    userAchievement = new UserAchievement
                    {
                        UserId = userId,
                        AchievementId = achievementId,
                        Progress = 0,
                        IsCompleted = false
                    };
                    await _unitOfWork.UserAchievementRepository.InsertAsync(userAchievement);
                    isNew = true;
                }

                if (userAchievement.IsCompleted) continue;

                var maxProgress = (await _unitOfWork.AchievementRepository.GetById(achievementId))?.MaxProgress ?? 0;
                userAchievement.Progress = Math.Min(friendCount, maxProgress);

                if (maxProgress > 0 && userAchievement.Progress >= maxProgress)
                {
                    userAchievement.IsCompleted = true;
                    userAchievement.CompletedAt = DateTime.UtcNow;
                }

                if (!isNew)
                {
                    _unitOfWork.UserAchievementRepository.Update(userAchievement);
                }
            }
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

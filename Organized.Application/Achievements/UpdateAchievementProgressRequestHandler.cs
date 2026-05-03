using Organized.Application.Common.Model;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Achievements
{
    public class UpdateAchievementProgressRequest
    {
        public int UserId { get; set; }
        public int AchievementId { get; set; }
        public int Progress { get; set; }
    }

    public class UpdateAchievementProgressResponse
    {
        public int AchievementId { get; init; }
        public int Progress { get; init; }
        public bool IsCompleted { get; init; }
        public DateTime? CompletedAt { get; init; }

        public UpdateAchievementProgressResponse(int achievementId, int progress, bool isCompleted, DateTime? completedAt)
        {
            AchievementId = achievementId;
            Progress = progress;
            IsCompleted = isCompleted;
            CompletedAt = completedAt;
        }

        public UpdateAchievementProgressResponse() { }
    }

    public class UpdateAchievementProgressRequestHandler : RequestHandler<UpdateAchievementProgressRequest, UpdateAchievementProgressResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAchievementProgressRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<UpdateAchievementProgressResponse>> HandleRequest(UpdateAchievementProgressRequest request, Result<UpdateAchievementProgressResponse> result)
        {
            var userAchievement = await _unitOfWork.UserAchievementRepository.GetByUserAndAchievement(request.UserId, request.AchievementId);

            if (userAchievement == null)
            {
                result.SetResult(new UpdateAchievementProgressResponse());
                return result;
            }

            var achievement = await _unitOfWork.AchievementRepository.GetById(userAchievement.AchievementId);

            userAchievement.Progress = request.Progress;

            if (achievement != null && userAchievement.Progress >= achievement.MaxProgress)
            {
                userAchievement.Progress = achievement.MaxProgress;
                userAchievement.IsCompleted = true;
                userAchievement.CompletedAt = DateTime.UtcNow;
            }

            _unitOfWork.UserAchievementRepository.Update(userAchievement);
            await _unitOfWork.SaveAsync();

            result.SetResult(new UpdateAchievementProgressResponse(
                userAchievement.AchievementId,
                userAchievement.Progress,
                userAchievement.IsCompleted,
                userAchievement.CompletedAt
            ));

            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

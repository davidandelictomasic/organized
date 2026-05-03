using Organized.Application.Common.Model;
using Organized.Domain.Entities.Achievements;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Achievements
{
    public class GetUserAchievementsRequest
    {
        public int UserId { get; set; }
    }

    public class UserAchievementResponse
    {
        public int AchievementId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
        public int Progress { get; init; }
        public int MaxProgress { get; init; }
        public bool IsCompleted { get; init; }
        public bool IsHidden { get; init; }
        public DateTime? CompletedAt { get; init; }
    }

    public class GetUserAchievementsRequestHandler : RequestHandler<GetUserAchievementsRequest, List<UserAchievementResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserAchievementsRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<List<UserAchievementResponse>>> HandleRequest(GetUserAchievementsRequest request, Result<List<UserAchievementResponse>> result)
        {
            var userAchievements = await _unitOfWork.UserAchievementRepository.GetByUserId(request.UserId);
            var achievements = await _unitOfWork.AchievementRepository.GetAll();

            // Initialize missing achievements for existing users
            var existingAchievementIds = userAchievements.Select(ua => ua.AchievementId).ToHashSet();
            var missingAchievements = achievements.Where(a => !existingAchievementIds.Contains(a.Id)).ToList();

            if (missingAchievements.Any())
            {
                foreach (var achievement in missingAchievements)
                {
                    var userAchievement = new UserAchievement
                    {
                        UserId = request.UserId,
                        AchievementId = achievement.Id,
                        Progress = 0,
                        IsCompleted = false
                    };
                    await _unitOfWork.UserAchievementRepository.InsertAsync(userAchievement);
                }
                await _unitOfWork.SaveAsync();

                // Re-fetch after inserting
                userAchievements = await _unitOfWork.UserAchievementRepository.GetByUserId(request.UserId);
            }

            var achievementDict = achievements.ToDictionary(a => a.Id);

            var response = userAchievements
                .Where(ua => achievementDict.ContainsKey(ua.AchievementId))
                .Select(ua =>
                {
                    var achievement = achievementDict[ua.AchievementId];
                    return new UserAchievementResponse
                    {
                        AchievementId = ua.AchievementId,
                        Name = achievement.Name,
                        Description = achievement.Description,
                        Progress = ua.Progress,
                        MaxProgress = achievement.MaxProgress,
                        IsCompleted = ua.IsCompleted,
                        IsHidden = achievement.IsHidden,
                        CompletedAt = ua.CompletedAt
                    };
                })
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

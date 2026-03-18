using Organized.Domain.Entities.Achievements;
using Organized.Domain.Persistence.Common;

namespace Organized.Domain.Persistence.Achievements
{
    public interface IUserAchievementRepository : IRepository<UserAchievement, int>
    {
        Task<UserAchievement?> GetById(int id);
        Task<IEnumerable<UserAchievement>> GetByUserId(int userId);
        Task<UserAchievement?> GetByUserAndAchievement(int userId, int achievementId);
        Task<IEnumerable<UserAchievement>> GetCompletedByUserId(int userId);
    }
}

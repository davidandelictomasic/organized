using Microsoft.EntityFrameworkCore;
using Organized.Domain.Entities.Achievements;
using Organized.Domain.Persistence.Achievements;
using Organized.Infrastructure.Database;
using Organized.Infrastructure.Persistence.Common;

namespace Organized.Infrastructure.Persistence.Achievements
{
    public class UserAchievementRepository : Repository<UserAchievement, int>, IUserAchievementRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserAchievementRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserAchievement?> GetById(int id)
        {
            return await _dbContext.UserAchievements.FirstOrDefaultAsync(ua => ua.Id == id);
        }

        public async Task<IEnumerable<UserAchievement>> GetByUserId(int userId)
        {
            return await _dbContext.UserAchievements
                .Where(ua => ua.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserAchievement?> GetByUserAndAchievement(int userId, int achievementId)
        {
            return await _dbContext.UserAchievements
                .FirstOrDefaultAsync(ua => ua.UserId == userId && ua.AchievementId == achievementId);
        }

        public async Task<IEnumerable<UserAchievement>> GetCompletedByUserId(int userId)
        {
            return await _dbContext.UserAchievements
                .Where(ua => ua.UserId == userId && ua.IsCompleted)
                .ToListAsync();
        }
    }
}

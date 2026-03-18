using Microsoft.EntityFrameworkCore;
using Organized.Domain.Entities.Achievements;
using Organized.Domain.Persistence.Achievements;
using Organized.Infrastructure.Database;
using Organized.Infrastructure.Persistence.Common;

namespace Organized.Infrastructure.Persistence.Achievements
{
    public class AchievementRepository : Repository<Achievement, int>, IAchievementRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AchievementRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Achievement?> GetById(int id)
        {
            return await _dbContext.Achievements.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Achievement>> GetAll()
        {
            return await _dbContext.Achievements.ToListAsync();
        }
    }
}

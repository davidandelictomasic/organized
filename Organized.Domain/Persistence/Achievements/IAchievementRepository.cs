using Organized.Domain.Entities.Achievements;
using Organized.Domain.Persistence.Common;

namespace Organized.Domain.Persistence.Achievements
{
    public interface IAchievementRepository : IRepository<Achievement, int>
    {
        Task<Achievement?> GetById(int id);
        Task<IEnumerable<Achievement>> GetAll();
    }
}

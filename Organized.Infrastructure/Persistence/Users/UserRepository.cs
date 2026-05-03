using Microsoft.EntityFrameworkCore;
using Organized.Domain.Entities.Users;
using Organized.Domain.Persistence.Users;
using Organized.Infrastructure.Database;
using Organized.Infrastructure.Persistence.Common;

namespace Organized.Infrastructure.Persistence.Users
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetByIds(IEnumerable<int> ids)
        {
            var idList = ids.ToList();
            return await _dbContext.Users
                .Where(u => idList.Contains(u.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> SearchByNameOrEmail(string term, int excludeUserId)
        {
            var pattern = $"%{term}%";
            return await _dbContext.Users
                .Where(u => u.Id != excludeUserId &&
                            (EF.Functions.ILike(u.Name!, pattern) ||
                             EF.Functions.ILike(u.Email!, pattern)))
                .OrderBy(u => u.Name)
                .Take(20)
                .ToListAsync();
        }
    }
}

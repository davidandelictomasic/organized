using Microsoft.EntityFrameworkCore;
using Organized.Domain.Entities.Friends;
using Organized.Domain.Persistence.Friends;
using Organized.Infrastructure.Database;
using Organized.Infrastructure.Persistence.Common;

namespace Organized.Infrastructure.Persistence.Friends
{
    public class FriendshipRepository : Repository<Friendship, int>, IFriendshipRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FriendshipRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Friendship?> GetById(int id)
        {
            return await _dbContext.Friendships.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Friendship>> GetByUserId(int userId)
        {
            return await _dbContext.Friendships
                .Where(f => f.UserId == userId || f.FriendId == userId)
                .ToListAsync();
        }

        public async Task<Friendship?> GetFriendship(int userId, int friendId)
        {
            return await _dbContext.Friendships
                .FirstOrDefaultAsync(f => 
                    (f.UserId == userId && f.FriendId == friendId) ||
                    (f.UserId == friendId && f.FriendId == userId));
        }

        public async Task<bool> AreFriends(int userId, int friendId)
        {
            return await _dbContext.Friendships
                .AnyAsync(f => 
                    (f.UserId == userId && f.FriendId == friendId) ||
                    (f.UserId == friendId && f.FriendId == userId));
        }
    }
}

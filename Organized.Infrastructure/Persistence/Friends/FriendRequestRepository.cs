using Microsoft.EntityFrameworkCore;
using Organized.Domain.Entities.Friends;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Friends;
using Organized.Infrastructure.Database;
using Organized.Infrastructure.Persistence.Common;

namespace Organized.Infrastructure.Persistence.Friends
{
    public class FriendRequestRepository : Repository<FriendRequest, int>, IFriendRequestRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FriendRequestRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FriendRequest?> GetById(int id)
        {
            return await _dbContext.FriendRequests.FirstOrDefaultAsync(fr => fr.Id == id);
        }

        public async Task<IEnumerable<FriendRequest>> GetPendingRequestsForUser(int userId)
        {
            return await _dbContext.FriendRequests
                .Where(fr => fr.ReceiverId == userId && fr.Status == FriendRequestStatus.Pending)
                .OrderByDescending(fr => fr.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<FriendRequest>> GetSentRequestsByUser(int userId)
        {
            return await _dbContext.FriendRequests
                .Where(fr => fr.SenderId == userId)
                .OrderByDescending(fr => fr.CreatedAt)
                .ToListAsync();
        }

        public async Task<FriendRequest?> GetPendingRequest(int senderId, int receiverId)
        {
            return await _dbContext.FriendRequests
                .FirstOrDefaultAsync(fr => 
                    fr.SenderId == senderId && 
                    fr.ReceiverId == receiverId && 
                    fr.Status == FriendRequestStatus.Pending);
        }
    }
}

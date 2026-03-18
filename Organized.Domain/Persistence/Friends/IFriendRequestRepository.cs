using Organized.Domain.Entities.Friends;
using Organized.Domain.Persistence.Common;

namespace Organized.Domain.Persistence.Friends
{
    public interface IFriendRequestRepository : IRepository<FriendRequest, int>
    {
        Task<FriendRequest?> GetById(int id);
        Task<IEnumerable<FriendRequest>> GetPendingRequestsForUser(int userId);
        Task<IEnumerable<FriendRequest>> GetSentRequestsByUser(int userId);
        Task<FriendRequest?> GetPendingRequest(int senderId, int receiverId);
    }
}

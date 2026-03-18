using Organized.Domain.Entities.Friends;
using Organized.Domain.Persistence.Common;

namespace Organized.Domain.Persistence.Friends
{
    public interface IFriendshipRepository : IRepository<Friendship, int>
    {
        Task<Friendship?> GetById(int id);
        Task<IEnumerable<Friendship>> GetByUserId(int userId);
        Task<Friendship?> GetFriendship(int userId, int friendId);
        Task<bool> AreFriends(int userId, int friendId);
    }
}

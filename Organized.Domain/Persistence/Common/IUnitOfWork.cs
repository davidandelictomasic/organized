using Organized.Domain.Persistence.Achievements;
using Organized.Domain.Persistence.Friends;
using Organized.Domain.Persistence.Reservations;
using Organized.Domain.Persistence.Tables;
using Organized.Domain.Persistence.Users;

namespace Organized.Domain.Persistence.Common
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        Task CreateTransaction();
        Task Commit();
        Task Rollback();

        IUserRepository UserRepository { get; }

        ICompanyTableRepository CompanyTableRepository { get; }

        IReservationRepository ReservationRepository { get; }

        IAchievementRepository AchievementRepository { get; }
        IUserAchievementRepository UserAchievementRepository { get; }

        IFriendshipRepository FriendshipRepository { get; }
        IFriendRequestRepository FriendRequestRepository { get; }
    }
}

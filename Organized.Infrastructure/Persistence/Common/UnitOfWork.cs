

using Microsoft.EntityFrameworkCore.Storage;
using Organized.Domain.Persistence.Achievements;
using Organized.Domain.Persistence.Common;
using Organized.Domain.Persistence.Friends;
using Organized.Domain.Persistence.Meetings;
using Organized.Domain.Persistence.Reservations;
using Organized.Domain.Persistence.Tables;
using Organized.Domain.Persistence.Users;
using Organized.Infrastructure.Database;

namespace Organized.Infrastructure.Persistence.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction? _transaction;

        public IUserRepository UserRepository { get; }

        public ICompanyTableRepository CompanyTableRepository { get; }

        public IReservationRepository ReservationRepository { get; }

        public IAchievementRepository AchievementRepository { get; }
        public IUserAchievementRepository UserAchievementRepository { get; }

        public IFriendshipRepository FriendshipRepository { get; }
        public IFriendRequestRepository FriendRequestRepository { get; }

        public IMeetingRepository MeetingRepository { get; }
        public IMeetingInviteRepository MeetingInviteRepository { get; }

        public UnitOfWork(
            ApplicationDbContext dbContext,
            IUserRepository userRepository,
            ICompanyTableRepository companyTableRepository,
            IReservationRepository reservationRepository,
            IAchievementRepository achievementRepository,
            IUserAchievementRepository userAchievementRepository,
            IFriendshipRepository friendshipRepository,
            IFriendRequestRepository friendRequestRepository,
            IMeetingRepository meetingRepository,
            IMeetingInviteRepository meetingInviteRepository)
        {
            _dbContext = dbContext;
            UserRepository = userRepository;
            CompanyTableRepository = companyTableRepository;
            ReservationRepository = reservationRepository;
            AchievementRepository = achievementRepository;
            UserAchievementRepository = userAchievementRepository;
            FriendshipRepository = friendshipRepository;
            FriendRequestRepository = friendRequestRepository;
            MeetingRepository = meetingRepository;
            MeetingInviteRepository = meetingInviteRepository;
        }

        public async Task CreateTransaction()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task Rollback()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

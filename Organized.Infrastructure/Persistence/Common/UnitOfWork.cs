
using Microsoft.EntityFrameworkCore.Storage;
using Organized.Domain.Persistence.Common;
using Organized.Domain.Persistence.Users;
using Organized.Infrastructure.Database;

namespace Organized.Infrastructure.Persistence.Common
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction? _transaction;

        public IUserRepository UserRepository { get; }

        public UnitOfWork(ApplicationDbContext dbContext, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            UserRepository = userRepository;
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

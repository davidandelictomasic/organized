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
    }
}

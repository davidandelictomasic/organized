using System;
using System.Collections.Generic;
using System.Text;
using Organized.Domain.Entities.Users;
using Organized.Domain.Persistence.Common;

namespace Organized.Domain.Persistence.Users
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User?> GetById(int id);
        
    }
}

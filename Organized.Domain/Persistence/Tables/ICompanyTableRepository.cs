using Organized.Domain.Entities.Tables;
using Organized.Domain.Persistence.Common;

namespace Organized.Domain.Persistence.Tables
{
    public interface ICompanyTableRepository : IRepository<CompanyTable, int>
    {
        Task<CompanyTable?> GetById(int id);
        Task<IEnumerable<CompanyTable>> GetByCity(string city);
        Task<IEnumerable<CompanyTable>> GetAll();
    }
}

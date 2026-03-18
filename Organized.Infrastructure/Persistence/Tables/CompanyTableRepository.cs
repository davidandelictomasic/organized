using Microsoft.EntityFrameworkCore;
using Organized.Domain.Entities.Tables;
using Organized.Domain.Persistence.Tables;
using Organized.Infrastructure.Database;
using Organized.Infrastructure.Persistence.Common;

namespace Organized.Infrastructure.Persistence.Tables
{
    public class CompanyTableRepository : Repository<CompanyTable, int>, ICompanyTableRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyTableRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CompanyTable?> GetById(int id)
        {
            return await _dbContext.CompanyTables.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<CompanyTable>> GetByCity(string city)
        {
            return await _dbContext.CompanyTables
                .Where(t => t.City == city)
                .ToListAsync();
        }

        public async Task<IEnumerable<CompanyTable>> GetAll()
        {
            return await _dbContext.CompanyTables.ToListAsync();
        }
    }
}

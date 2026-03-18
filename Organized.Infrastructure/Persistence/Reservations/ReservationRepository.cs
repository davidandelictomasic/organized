using Microsoft.EntityFrameworkCore;
using Organized.Domain.Entities.Reservations;
using Organized.Domain.Persistence.Reservations;
using Organized.Infrastructure.Database;
using Organized.Infrastructure.Persistence.Common;

namespace Organized.Infrastructure.Persistence.Reservations
{
    public class ReservationRepository : Repository<Reservation, int>, IReservationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ReservationRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Reservation?> GetById(int id)
        {
            return await _dbContext.Reservations.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Reservation>> GetByUserId(int userId)
        {
            return await _dbContext.Reservations
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.ReservationDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetByTableId(int tableId)
        {
            return await _dbContext.Reservations
                .Where(r => r.TableId == tableId)
                .OrderByDescending(r => r.ReservationDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetByDate(DateTime date)
        {
            return await _dbContext.Reservations
                .Where(r => r.ReservationDate.Date == date.Date)
                .ToListAsync();
        }

        public async Task<int> GetUserReservationCount(int userId)
        {
            return await _dbContext.Reservations.CountAsync(r => r.UserId == userId);
        }
    }
}

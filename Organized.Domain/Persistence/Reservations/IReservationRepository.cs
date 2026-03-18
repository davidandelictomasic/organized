using Organized.Domain.Entities.Reservations;
using Organized.Domain.Persistence.Common;

namespace Organized.Domain.Persistence.Reservations
{
    public interface IReservationRepository : IRepository<Reservation, int>
    {
        Task<Reservation?> GetById(int id);
        Task<IEnumerable<Reservation>> GetByUserId(int userId);
        Task<IEnumerable<Reservation>> GetByTableId(int tableId);
        Task<IEnumerable<Reservation>> GetByDate(DateTime date);
        Task<int> GetUserReservationCount(int userId);
    }
}

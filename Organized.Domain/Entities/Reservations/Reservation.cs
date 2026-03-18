using Organized.Domain.Enums;

namespace Organized.Domain.Entities.Reservations
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TableId { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    }
}

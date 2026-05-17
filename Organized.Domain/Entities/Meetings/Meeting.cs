using Organized.Domain.Enums;

namespace Organized.Domain.Entities.Meetings
{
    public class Meeting
    {
        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public int MeetingRoomTableId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime MeetingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public MeetingStatus Status { get; set; } = MeetingStatus.Scheduled;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

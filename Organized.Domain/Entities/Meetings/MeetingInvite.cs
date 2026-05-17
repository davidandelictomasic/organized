using Organized.Domain.Enums;

namespace Organized.Domain.Entities.Meetings
{
    public class MeetingInvite
    {
        public int Id { get; set; }
        public int MeetingId { get; set; }
        public int UserId { get; set; }
        public MeetingInviteStatus Status { get; set; } = MeetingInviteStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? RespondedAt { get; set; }
    }
}

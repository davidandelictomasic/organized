namespace Organized.Domain.Entities.Friends
{
    public class Friendship
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

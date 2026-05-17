using Organized.Domain.Enums;

namespace Organized.Domain.Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? LastOnline { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
    }
}

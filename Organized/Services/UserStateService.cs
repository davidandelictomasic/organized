namespace Organized.Services
{
    public class UserStateService
    {
        public int? UserId { get; private set; }
        public string? UserEmail { get; private set; }
        public string? UserName { get; private set; }
        public bool IsLoggedIn => UserId.HasValue;

        public void SetUser(int userId, string? email, string? name)
        {
            UserId = userId;
            UserEmail = email;
            UserName = name;
        }

        public void ClearUser()
        {
            UserId = null;
            UserEmail = null;
            UserName = null;
        }
    }
}

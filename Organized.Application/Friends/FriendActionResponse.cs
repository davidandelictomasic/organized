namespace Organized.Application.Friends
{
    public class FriendActionResponse
    {
        public bool Success { get; init; }
        public string? ErrorMessage { get; init; }

        public FriendActionResponse(bool success, string? errorMessage = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }

        public FriendActionResponse() { }
    }
}

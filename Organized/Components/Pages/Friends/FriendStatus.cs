namespace Organized.Components.Pages.Friends
{
    public static class FriendStatus
    {
        private static readonly TimeSpan OnlineWindow = TimeSpan.FromMinutes(5);

        public static bool IsOnline(DateTime? lastOnline)
        {
            if (!lastOnline.HasValue) return false;
            return DateTime.UtcNow - lastOnline.Value <= OnlineWindow;
        }

        public static string GetLastSeenText(DateTime? lastOnline)
        {
            if (!lastOnline.HasValue) return "Offline";

            var diff = DateTime.UtcNow - lastOnline.Value;

            if (diff <= OnlineWindow) return "Online";
            if (diff < TimeSpan.FromHours(1)) return $"Last seen {(int)diff.TotalMinutes}m ago";
            if (diff < TimeSpan.FromHours(24)) return $"Last seen {(int)diff.TotalHours}h ago";
            if (diff < TimeSpan.FromHours(48)) return "Last seen yesterday";
            return $"Last seen {(int)diff.TotalDays}d ago";
        }

        public static string GetInitials(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "?";

            var parts = name.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
            {
                return $"{char.ToUpper(parts[0][0])}{char.ToUpper(parts[^1][0])}";
            }
            return parts[0].Length >= 2
                ? $"{char.ToUpper(parts[0][0])}{char.ToUpper(parts[0][1])}"
                : parts[0][0].ToString().ToUpper();
        }
    }
}

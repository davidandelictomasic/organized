using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Organized.Domain.Enums;

namespace Organized.Services
{
    public class UserStateService
    {
        private const string StorageKey = "organized-user-id";

        private readonly ProtectedLocalStorage _storage;

        public int? UserId { get; private set; }
        public string? UserEmail { get; private set; }
        public string? UserName { get; private set; }
        public UserRole? UserRole { get; private set; }
        public bool IsLoggedIn => UserId.HasValue;
        public bool IsAdmin => UserRole == Domain.Enums.UserRole.Admin;
        public bool IsInitialized { get; private set; }

        public UserStateService(ProtectedLocalStorage storage)
        {
            _storage = storage;
        }

        public async Task LoginAsync(int userId, string? email, string? name, UserRole role)
        {
            SetInMemory(userId, email, name, role);
            try
            {
                await _storage.SetAsync(StorageKey, userId);
            }
            catch
            {
            }
        }

        public async Task LogoutAsync()
        {
            ClearInMemory();
            try
            {
                await _storage.DeleteAsync(StorageKey);
            }
            catch
            {
            }
        }

        public void HydrateFromDb(int userId, string? email, string? name, UserRole role)
        {
            SetInMemory(userId, email, name, role);
        }

        public async Task<int?> GetStoredUserIdAsync()
        {
            try
            {
                var result = await _storage.GetAsync<int>(StorageKey);
                return result.Success ? result.Value : null;
            }
            catch
            {
                return null;
            }
        }

        public void MarkInitialized()
        {
            IsInitialized = true;
        }

        public void UpdateName(string? name)
        {
            UserName = name;
        }

        private void SetInMemory(int userId, string? email, string? name, UserRole role)
        {
            UserId = userId;
            UserEmail = email;
            UserName = name;
            UserRole = role;
        }

        private void ClearInMemory()
        {
            UserId = null;
            UserEmail = null;
            UserName = null;
            UserRole = null;
        }
    }
}

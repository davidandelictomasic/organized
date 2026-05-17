using Organized.Application.Common.Model;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Users.User
{
    public class GetAllUsersForAdminRequest
    {
    }

    public class AdminUserListItemResponse
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
        public UserRole Role { get; init; }
        public DateTime? LastOnline { get; init; }
    }

    public class GetAllUsersForAdminRequestHandler : RequestHandler<GetAllUsersForAdminRequest, List<AdminUserListItemResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUsersForAdminRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<List<AdminUserListItemResponse>>> HandleRequest(GetAllUsersForAdminRequest request, Result<List<AdminUserListItemResponse>> result)
        {
            var users = await _unitOfWork.UserRepository.GetAll();

            var response = users
                .Select(u => new AdminUserListItemResponse
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Role = u.Role,
                    LastOnline = u.LastOnline
                })
                .OrderBy(u => u.Name)
                .ToList();

            result.SetResult(response);
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

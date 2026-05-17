using Organized.Application.Common.Model;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Users.User
{
    public class UpdateUserDisplayNameRequest
    {
        public int UserId { get; set; }
        public string NewName { get; set; } = string.Empty;
    }

    public class UpdateUserDisplayNameResponse
    {
        public bool Success { get; init; }
        public string? Error { get; init; }
        public string? Name { get; init; }

        public UpdateUserDisplayNameResponse(bool success, string? error = null, string? name = null)
        {
            Success = success;
            Error = error;
            Name = name;
        }

        public UpdateUserDisplayNameResponse() { }
    }

    public class UpdateUserDisplayNameRequestHandler : RequestHandler<UpdateUserDisplayNameRequest, UpdateUserDisplayNameResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserDisplayNameRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<UpdateUserDisplayNameResponse>> HandleRequest(UpdateUserDisplayNameRequest request, Result<UpdateUserDisplayNameResponse> result)
        {
            var trimmed = request.NewName?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(trimmed))
            {
                result.SetResult(new UpdateUserDisplayNameResponse(false, "Display name cannot be empty."));
                return result;
            }

            if (trimmed.Length > 100)
            {
                result.SetResult(new UpdateUserDisplayNameResponse(false, "Display name must be 100 characters or fewer."));
                return result;
            }

            var user = await _unitOfWork.UserRepository.GetById(request.UserId);

            if (user == null)
            {
                result.SetResult(new UpdateUserDisplayNameResponse(false, "User not found."));
                return result;
            }

            user.Name = trimmed;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveAsync();

            result.SetResult(new UpdateUserDisplayNameResponse(true, null, trimmed));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

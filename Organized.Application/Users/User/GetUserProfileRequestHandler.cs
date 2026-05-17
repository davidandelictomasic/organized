using Organized.Application.Common.Model;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Users.User
{
    public class GetUserProfileRequest
    {
        public int UserId { get; set; }
    }

    public class GetUserProfileResponse
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
        public UserRole Role { get; init; }
        public bool Found { get; init; }

        public GetUserProfileResponse(int id, string? name, string? email, UserRole role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
            Found = true;
        }

        public GetUserProfileResponse()
        {
            Found = false;
        }
    }

    public class GetUserProfileRequestHandler : RequestHandler<GetUserProfileRequest, GetUserProfileResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserProfileRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<GetUserProfileResponse>> HandleRequest(GetUserProfileRequest request, Result<GetUserProfileResponse> result)
        {
            var user = await _unitOfWork.UserRepository.GetById(request.UserId);

            if (user == null)
            {
                result.SetResult(new GetUserProfileResponse());
                return result;
            }

            result.SetResult(new GetUserProfileResponse(user.Id, user.Name, user.Email, user.Role));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

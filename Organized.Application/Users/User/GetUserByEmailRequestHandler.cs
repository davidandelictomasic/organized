using Organized.Application.Common.Model;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Users.User
{
    public class GetUserByEmailResponse
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
        public bool Found { get; init; }
        public bool PasswordMatch { get; init; }

        public GetUserByEmailResponse(int id, string? name, string? email, bool passwordMatch)
        {
            Id = id;
            Name = name;
            Email = email;
            Found = true;
            PasswordMatch = passwordMatch;
        }

        public GetUserByEmailResponse()
        {
            Found = false;
            PasswordMatch = false;
        }
    }

    public class GetUserByEmailRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class GetUserByEmailRequestHandler : RequestHandler<GetUserByEmailRequest, GetUserByEmailResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByEmailRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<GetUserByEmailResponse>> HandleRequest(GetUserByEmailRequest request, Result<GetUserByEmailResponse> result)
        {
            var user = await _unitOfWork.UserRepository.GetByEmail(request.Email);

            if (user == null)
            {
                result.SetResult(new GetUserByEmailResponse());
                return result;
            }

            var passwordMatch = user.Password == request.Password;
            result.SetResult(new GetUserByEmailResponse(user.Id, user.Name, user.Email, passwordMatch));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

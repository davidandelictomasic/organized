using Organized.Application.Common.Model;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Users.User
{
    public class UpdateUserLastOnlineRequest
    {
        public int UserId { get; set; }
    }

    public class UpdateUserLastOnlineResponse
    {
        public bool Success { get; init; }

        public UpdateUserLastOnlineResponse(bool success)
        {
            Success = success;
        }

        public UpdateUserLastOnlineResponse() { }
    }

    public class UpdateUserLastOnlineRequestHandler : RequestHandler<UpdateUserLastOnlineRequest, UpdateUserLastOnlineResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserLastOnlineRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<UpdateUserLastOnlineResponse>> HandleRequest(UpdateUserLastOnlineRequest request, Result<UpdateUserLastOnlineResponse> result)
        {
            var user = await _unitOfWork.UserRepository.GetById(request.UserId);

            if (user == null)
            {
                result.SetResult(new UpdateUserLastOnlineResponse(false));
                return result;
            }

            user.LastOnline = DateTime.UtcNow;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveAsync();

            result.SetResult(new UpdateUserLastOnlineResponse(true));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

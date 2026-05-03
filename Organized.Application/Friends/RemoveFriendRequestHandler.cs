using Organized.Application.Common.Model;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Friends
{
    public class RemoveFriendRequest
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }
    }

    public class RemoveFriendRequestHandler : RequestHandler<RemoveFriendRequest, FriendActionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveFriendRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<FriendActionResponse>> HandleRequest(RemoveFriendRequest request, Result<FriendActionResponse> result)
        {
            var friendship = await _unitOfWork.FriendshipRepository.GetFriendship(request.UserId, request.FriendId);

            if (friendship == null)
            {
                result.SetResult(new FriendActionResponse(false, "Friendship not found."));
                return result;
            }

            _unitOfWork.FriendshipRepository.Delete(friendship);
            await _unitOfWork.SaveAsync();

            result.SetResult(new FriendActionResponse(true));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

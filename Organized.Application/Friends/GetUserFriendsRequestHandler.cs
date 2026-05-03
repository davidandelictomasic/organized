using Organized.Application.Common.Model;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Friends
{
    public class GetUserFriendsRequest
    {
        public int UserId { get; set; }
    }

    public class FriendResponse
    {
        public int UserId { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
        public DateTime? LastOnline { get; init; }
    }

    public class GetUserFriendsRequestHandler : RequestHandler<GetUserFriendsRequest, List<FriendResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserFriendsRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<List<FriendResponse>>> HandleRequest(GetUserFriendsRequest request, Result<List<FriendResponse>> result)
        {
            var friendships = (await _unitOfWork.FriendshipRepository.GetByUserId(request.UserId)).ToList();

            if (!friendships.Any())
            {
                result.SetResult(new List<FriendResponse>());
                return result;
            }

            var friendIds = friendships
                .Select(f => f.UserId == request.UserId ? f.FriendId : f.UserId)
                .Distinct()
                .ToList();

            var friends = await _unitOfWork.UserRepository.GetByIds(friendIds);

            var response = friends
                .Select(u => new FriendResponse
                {
                    UserId = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    LastOnline = u.LastOnline
                })
                .OrderBy(f => f.Name)
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

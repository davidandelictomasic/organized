using Organized.Application.Common.Model;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Friends
{
    public class SearchUsersRequest
    {
        public int SearcherId { get; set; }
        public string SearchTerm { get; set; } = string.Empty;
    }

    public class UserSearchResponse
    {
        public int UserId { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
    }

    public class SearchUsersRequestHandler : RequestHandler<SearchUsersRequest, List<UserSearchResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchUsersRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<List<UserSearchResponse>>> HandleRequest(SearchUsersRequest request, Result<List<UserSearchResponse>> result)
        {
            if (string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                result.SetResult(new List<UserSearchResponse>());
                return result;
            }

            var matches = await _unitOfWork.UserRepository.SearchByNameOrEmail(request.SearchTerm.Trim(), request.SearcherId);

            var friendships = await _unitOfWork.FriendshipRepository.GetByUserId(request.SearcherId);
            var friendIds = friendships
                .Select(f => f.UserId == request.SearcherId ? f.FriendId : f.UserId)
                .ToHashSet();

            var sentRequests = await _unitOfWork.FriendRequestRepository.GetSentRequestsByUser(request.SearcherId);
            var pendingSentReceiverIds = sentRequests
                .Where(r => r.Status == Domain.Enums.FriendRequestStatus.Pending)
                .Select(r => r.ReceiverId)
                .ToHashSet();

            var pendingIncoming = await _unitOfWork.FriendRequestRepository.GetPendingRequestsForUser(request.SearcherId);
            var pendingIncomingSenderIds = pendingIncoming.Select(r => r.SenderId).ToHashSet();

            var response = matches
                .Where(u => !friendIds.Contains(u.Id) &&
                            !pendingSentReceiverIds.Contains(u.Id) &&
                            !pendingIncomingSenderIds.Contains(u.Id))
                .Select(u => new UserSearchResponse
                {
                    UserId = u.Id,
                    Name = u.Name,
                    Email = u.Email
                })
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

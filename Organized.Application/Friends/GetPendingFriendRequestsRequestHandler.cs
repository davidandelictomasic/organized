using Organized.Application.Common.Model;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Friends
{
    public class GetPendingFriendRequestsRequest
    {
        public int UserId { get; set; }
    }

    public class PendingFriendRequestResponse
    {
        public int RequestId { get; init; }
        public int SenderId { get; init; }
        public string? SenderName { get; init; }
        public string? SenderEmail { get; init; }
        public DateTime CreatedAt { get; init; }
    }

    public class GetPendingFriendRequestsRequestHandler : RequestHandler<GetPendingFriendRequestsRequest, List<PendingFriendRequestResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPendingFriendRequestsRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<List<PendingFriendRequestResponse>>> HandleRequest(GetPendingFriendRequestsRequest request, Result<List<PendingFriendRequestResponse>> result)
        {
            var pending = (await _unitOfWork.FriendRequestRepository.GetPendingRequestsForUser(request.UserId)).ToList();

            if (!pending.Any())
            {
                result.SetResult(new List<PendingFriendRequestResponse>());
                return result;
            }

            var senderIds = pending.Select(p => p.SenderId).Distinct();
            var senders = (await _unitOfWork.UserRepository.GetByIds(senderIds)).ToDictionary(u => u.Id);

            var response = pending
                .Where(p => senders.ContainsKey(p.SenderId))
                .Select(p => new PendingFriendRequestResponse
                {
                    RequestId = p.Id,
                    SenderId = p.SenderId,
                    SenderName = senders[p.SenderId].Name,
                    SenderEmail = senders[p.SenderId].Email,
                    CreatedAt = p.CreatedAt
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

using Organized.Application.Common.Model;
using Organized.Application.Friends;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Users.User
{
    public class SearchUsersForMeetingRequest
    {
        public int SearcherId { get; set; }
        public string SearchTerm { get; set; } = string.Empty;
    }

    public class SearchUsersForMeetingRequestHandler : RequestHandler<SearchUsersForMeetingRequest, List<UserSearchResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchUsersForMeetingRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<List<UserSearchResponse>>> HandleRequest(SearchUsersForMeetingRequest request, Result<List<UserSearchResponse>> result)
        {
            if (string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                result.SetResult(new List<UserSearchResponse>());
                return result;
            }

            var matches = await _unitOfWork.UserRepository.SearchByNameOrEmail(request.SearchTerm.Trim(), request.SearcherId);

            var response = matches
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

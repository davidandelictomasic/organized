using Organized.Application.Common.Model;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Meetings
{
    public class GetMeetingRoomsRequest
    {
    }

    public class MeetingRoomResponse
    {
        public int Id { get; init; }
        public string CompanyName { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
        public int Capacity { get; init; }
    }

    public class GetMeetingRoomsRequestHandler : RequestHandler<GetMeetingRoomsRequest, List<MeetingRoomResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMeetingRoomsRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<List<MeetingRoomResponse>>> HandleRequest(GetMeetingRoomsRequest request, Result<List<MeetingRoomResponse>> result)
        {
            var tables = await _unitOfWork.CompanyTableRepository.GetAll();

            var response = tables
                .Where(t => t.IsMeetingRoom)
                .Select(t => new MeetingRoomResponse
                {
                    Id = t.Id,
                    CompanyName = t.CompanyName,
                    City = t.City,
                    Capacity = t.Capacity
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

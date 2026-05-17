using Organized.Application.Common.Model;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Reservations
{
    public class GetReservationsByDateRequest
    {
        public DateTime Date { get; set; }
    }

    public class ReservationOccupantResponse
    {
        public int TableId { get; init; }
        public int UserId { get; init; }
        public string? UserName { get; init; }
    }

    public class GetReservationsByDateRequestHandler : RequestHandler<GetReservationsByDateRequest, List<ReservationOccupantResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetReservationsByDateRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<List<ReservationOccupantResponse>>> HandleRequest(GetReservationsByDateRequest request, Result<List<ReservationOccupantResponse>> result)
        {
            var date = DateTime.SpecifyKind(request.Date.Date, DateTimeKind.Utc);
            var reservations = (await _unitOfWork.ReservationRepository.GetByDate(date))
                .Where(r => r.Status != ReservationStatus.Cancelled)
                .ToList();

            if (reservations.Count == 0)
            {
                result.SetResult(new List<ReservationOccupantResponse>());
                return result;
            }

            var userIds = reservations.Select(r => r.UserId).Distinct().ToList();
            var users = (await _unitOfWork.UserRepository.GetByIds(userIds)).ToDictionary(u => u.Id);

            var response = reservations
                .Select(r => new ReservationOccupantResponse
                {
                    TableId = r.TableId,
                    UserId = r.UserId,
                    UserName = users.TryGetValue(r.UserId, out var u) ? u.Name : null
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

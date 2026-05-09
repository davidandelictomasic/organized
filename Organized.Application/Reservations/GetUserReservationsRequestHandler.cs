using Organized.Application.Common.Model;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Reservations
{
    public class ReservationResponse
    {
        public int Id { get; init; }
        public int UserId { get; init; }
        public int TableId { get; init; }
        public string? TableName { get; init; }
        public string? City { get; init; }
        public DateTime ReservationDate { get; init; }
        public ReservationStatus Status { get; init; }
    }

    public class GetUserReservationsRequest
    {
        public int UserId { get; set; }
    }

    public class GetUserReservationsRequestHandler : RequestHandler<GetUserReservationsRequest, List<ReservationResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserReservationsRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override async Task<Result<List<ReservationResponse>>> HandleRequest(GetUserReservationsRequest request, Result<List<ReservationResponse>> result)
        {
            var reservations = await _unitOfWork.ReservationRepository.GetByUserId(request.UserId);
            var tables = await _unitOfWork.CompanyTableRepository.GetAll();
            var tableDict = tables.ToDictionary(t => t.Id);
            var today = DateTime.UtcNow.Date;

            var response = reservations.Select(r => new ReservationResponse
            {
                Id = r.Id,
                UserId = r.UserId,
                TableId = r.TableId,
                TableName = tableDict.ContainsKey(r.TableId) ? tableDict[r.TableId].CompanyName : "Unknown",
                City = tableDict.ContainsKey(r.TableId) ? tableDict[r.TableId].City : "Unknown",
                ReservationDate = r.ReservationDate,
                Status = (r.Status != ReservationStatus.Cancelled && r.ReservationDate.Date < today)
                    ? ReservationStatus.Completed
                    : r.Status
            }).ToList();

            result.SetResult(response);
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

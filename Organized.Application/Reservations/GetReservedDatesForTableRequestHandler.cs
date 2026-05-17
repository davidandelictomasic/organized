using Organized.Application.Common.Model;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Reservations
{
    public class GetReservedDatesForTableRequest
    {
        public int TableId { get; set; }
    }

    public class GetReservedDatesForTableRequestHandler : RequestHandler<GetReservedDatesForTableRequest, List<DateTime>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetReservedDatesForTableRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async override Task<Result<List<DateTime>>> HandleRequest(GetReservedDatesForTableRequest request, Result<List<DateTime>> result)
        {
            var reservations = await _unitOfWork.ReservationRepository.GetByTableId(request.TableId);
            var today = DateTime.UtcNow.Date;

            var dates = reservations
                .Where(r => r.Status != ReservationStatus.Cancelled
                            && r.ReservationDate.Date >= today)
                .Select(r => r.ReservationDate.Date)
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            result.SetResult(dates);
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

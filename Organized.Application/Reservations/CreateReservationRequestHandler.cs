using Organized.Application.Achievements;
using Organized.Application.Common.Model;
using Organized.Domain.Entities.Reservations;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Reservations
{
    public class CreateReservationResponse
    {
        public int? Id { get; init; }
        public bool Success { get; init; }
        public string? Message { get; init; }

        public CreateReservationResponse(int? id, bool success, string? message = null)
        {
            Id = id;
            Success = success;
            Message = message;
        }

        public CreateReservationResponse()
        {
            Success = false;
        }
    }

    public class CreateReservationRequest
    {
        public int UserId { get; set; }
        public int TableId { get; set; }
        public DateTime ReservationDate { get; set; }
    }

    public class CreateReservationRequestHandler : RequestHandler<CreateReservationRequest, CreateReservationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AchievementTracker _achievementTracker;

        public CreateReservationRequestHandler(IUnitOfWork unitOfWork, AchievementTracker achievementTracker)
        {
            _unitOfWork = unitOfWork;
            _achievementTracker = achievementTracker;
        }

        protected override async Task<Result<CreateReservationResponse>> HandleRequest(CreateReservationRequest request, Result<CreateReservationResponse> result)
        {
            var table = await _unitOfWork.CompanyTableRepository.GetById(request.TableId);
            if (table == null)
            {
                result.SetResult(new CreateReservationResponse(null, false, "Table not found."));
                return result;
            }

            if (table.IsMeetingRoom)
            {
                result.SetResult(new CreateReservationResponse(null, false, "This is a meeting room. Only admins can book it for meetings."));
                return result;
            }

            var requestedDate = request.ReservationDate.Date;
            var userReservations = await _unitOfWork.ReservationRepository.GetByUserId(request.UserId);
            var alreadyBooked = userReservations.Any(r =>
                r.Status != ReservationStatus.Cancelled &&
                r.ReservationDate.Date == requestedDate);

            if (alreadyBooked)
            {
                result.SetResult(new CreateReservationResponse(null, false, "You already have a reservation for this day. Cancel it first to book a different table."));
                return result;
            }

            var reservation = new Reservation
            {
                UserId = request.UserId,
                TableId = request.TableId,
                ReservationDate = request.ReservationDate,
                Status = ReservationStatus.Pending
            };

            await _unitOfWork.ReservationRepository.InsertAsync(reservation);
            await _unitOfWork.SaveAsync();

            await _achievementTracker.TrackReservationCreated(request.UserId);

            result.SetResult(new CreateReservationResponse(reservation.Id, true, "Reservation created successfully"));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

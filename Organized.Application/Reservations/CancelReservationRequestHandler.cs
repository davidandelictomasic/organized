using Organized.Application.Achievements;
using Organized.Application.Common.Model;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Reservations
{
    public class CancelReservationRequest
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
    }

    public class CancelReservationResponse
    {
        public bool Success { get; init; }
        public string? Message { get; init; }

        public CancelReservationResponse(bool success, string? message = null)
        {
            Success = success;
            Message = message;
        }

        public CancelReservationResponse()
        {
            Success = false;
        }
    }

    public class CancelReservationRequestHandler : RequestHandler<CancelReservationRequest, CancelReservationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AchievementTracker _achievementTracker;

        public CancelReservationRequestHandler(IUnitOfWork unitOfWork, AchievementTracker achievementTracker)
        {
            _unitOfWork = unitOfWork;
            _achievementTracker = achievementTracker;
        }

        protected override async Task<Result<CancelReservationResponse>> HandleRequest(CancelReservationRequest request, Result<CancelReservationResponse> result)
        {
            var reservation = await _unitOfWork.ReservationRepository.GetById(request.ReservationId);

            if (reservation == null)
            {
                result.SetResult(new CancelReservationResponse(false, "Reservation not found."));
                return result;
            }

            if (reservation.UserId != request.UserId)
            {
                result.SetResult(new CancelReservationResponse(false, "You can only cancel your own reservations."));
                return result;
            }

            if (reservation.Status != ReservationStatus.Pending)
            {
                result.SetResult(new CancelReservationResponse(false, "Only pending reservations can be cancelled."));
                return result;
            }

            reservation.Status = ReservationStatus.Cancelled;
            _unitOfWork.ReservationRepository.Update(reservation);
            await _unitOfWork.SaveAsync();

            await _achievementTracker.TrackReservationCancelled(request.UserId);

            result.SetResult(new CancelReservationResponse(true, "Reservation cancelled successfully."));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

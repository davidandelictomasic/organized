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
        private readonly UpdateAchievementProgressRequestHandler _updateAchievementHandler;

        public CreateReservationRequestHandler(IUnitOfWork unitOfWork, UpdateAchievementProgressRequestHandler updateAchievementHandler)
        {
            _unitOfWork = unitOfWork;
            _updateAchievementHandler = updateAchievementHandler;
        }

        protected override async Task<Result<CreateReservationResponse>> HandleRequest(CreateReservationRequest request, Result<CreateReservationResponse> result)
        {
            var reservation = new Reservation
            {
                UserId = request.UserId,
                TableId = request.TableId,
                ReservationDate = request.ReservationDate,
                Status = ReservationStatus.Pending
            };

            await _unitOfWork.ReservationRepository.InsertAsync(reservation);
            await _unitOfWork.SaveAsync();

            
            await UpdateReservationAchievements(request.UserId);

            result.SetResult(new CreateReservationResponse(reservation.Id, true, "Reservation created successfully"));
            return result;
        }

        private async Task UpdateReservationAchievements(int userId)
        {
            var reservations = await _unitOfWork.ReservationRepository.GetByUserId(userId);
            var totalReservations = reservations.Count();

            var achievements = await _unitOfWork.AchievementRepository.GetAll();
            var reservationAchievements = achievements
                .Where(a => a.Name is "First Reservation" or "Regular" or "Frequent Visitor" or "Power User" or "Legend")
                .ToList();

            foreach (var achievement in reservationAchievements)
            {
                await _updateAchievementHandler.ProcessActiveRequestAsnync(new UpdateAchievementProgressRequest
                {
                    UserId = userId,
                    AchievementId = achievement.Id,
                    Progress = Math.Min(totalReservations, achievement.MaxProgress)
                });
            }
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

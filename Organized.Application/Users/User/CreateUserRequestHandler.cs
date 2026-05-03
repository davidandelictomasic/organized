using Organized.Application.Common.Model;
using Organized.Domain.Entities.Achievements;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Users.User
{
    public class SuccessPostResponse
    {
        public int? Id { get; init; }
        public SuccessPostResponse(int? id)
        {
            Id = id;
        }
        public SuccessPostResponse()
        {
        }
    }
    public class CreateUserRequest
    {
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string Password { get; set; }

    }
    public class CreateUserRequestHandler : RequestHandler<CreateUserRequest, SuccessPostResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserRequestHandler(IUnitOfWork userUnitOfWork)
        {
            _unitOfWork = userUnitOfWork;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(CreateUserRequest request, Result<SuccessPostResponse> result)
        {
            var user = new Domain.Entities.Users.User
            {
                Name = request.Name,                
                Email = request.Email,
                Password = request.Password


            };
             await _unitOfWork.UserRepository.InsertAsync(user);
            await _unitOfWork.SaveAsync();

            // Initialize all achievements for the new user with progress = 0
            var achievements = await _unitOfWork.AchievementRepository.GetAll();
            foreach (var achievement in achievements)
            {
                var userAchievement = new UserAchievement
                {
                    UserId = user.Id,
                    AchievementId = achievement.Id,
                    Progress = 0,
                    IsCompleted = false
                };
                await _unitOfWork.UserAchievementRepository.InsertAsync(userAchievement);
            }
            await _unitOfWork.SaveAsync();

            result.SetResult(new SuccessPostResponse(user.Id));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

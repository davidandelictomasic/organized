using Organized.Domain.Entities.Achievements;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Achievements
{
    public class AchievementTracker
    {
        private static readonly int[] ReservationCreatedIds = { 1, 3, 4, 5 };
        private static readonly int[] ReservationCancelledIds = { 16, 17, 18 };
        private static readonly int[] FriendIds = { 9, 10, 11 };
        private static readonly int[] MeetingCreatedIds = { 19, 20, 21, 22 };
        private static readonly int[] MeetingCancelledIds = { 23, 24 };
        private static readonly int[] MeetingInviteAcceptIds = { 25, 26 };
        private const int ShortMeetingId = 27;
        private const int ShortMeetingThresholdMinutes = 15;

        private readonly IUnitOfWork _unitOfWork;

        public AchievementTracker(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task TrackReservationCreated(int userId)
        {
            var count = (await _unitOfWork.ReservationRepository.GetByUserId(userId)).Count();
            await ApplyProgress(userId, ReservationCreatedIds, count);
        }

        public async Task TrackReservationCancelled(int userId)
        {
            var reservations = await _unitOfWork.ReservationRepository.GetByUserId(userId);
            var count = reservations.Count(r => r.Status == ReservationStatus.Cancelled);
            await ApplyProgress(userId, ReservationCancelledIds, count);
        }

        public async Task TrackFriendAdded(int userId)
        {
            var count = (await _unitOfWork.FriendshipRepository.GetByUserId(userId)).Count();
            await ApplyProgress(userId, FriendIds, count);
        }

        public async Task TrackMeetingCreated(int adminUserId)
        {
            var meetings = (await _unitOfWork.MeetingRepository.GetByCreator(adminUserId)).ToList();
            await ApplyProgress(adminUserId, MeetingCreatedIds, meetings.Count);

            var shortCount = meetings.Count(m => (m.EndTime - m.StartTime).TotalMinutes < ShortMeetingThresholdMinutes);
            await ApplyProgress(adminUserId, new[] { ShortMeetingId }, shortCount);
        }

        public async Task TrackMeetingCancelled(int adminUserId)
        {
            var meetings = await _unitOfWork.MeetingRepository.GetByCreator(adminUserId);
            var count = meetings.Count(m => m.Status == MeetingStatus.Cancelled);
            await ApplyProgress(adminUserId, MeetingCancelledIds, count);
        }

        public async Task TrackMeetingInviteAcceptReceived(int adminUserId)
        {
            var meetings = await _unitOfWork.MeetingRepository.GetByCreator(adminUserId);
            int total = 0;
            foreach (var meeting in meetings)
            {
                var invites = await _unitOfWork.MeetingInviteRepository.GetByMeeting(meeting.Id);
                total += invites.Count(i => i.Status == MeetingInviteStatus.Accepted);
            }
            await ApplyProgress(adminUserId, MeetingInviteAcceptIds, total);
        }

        private async Task ApplyProgress(int userId, int[] achievementIds, int count)
        {
            foreach (var achievementId in achievementIds)
            {
                var achievement = await _unitOfWork.AchievementRepository.GetById(achievementId);
                if (achievement == null) continue;

                var newProgress = Math.Min(count, achievement.MaxProgress);
                var nowCompleted = newProgress >= achievement.MaxProgress;

                var userAchievement = await _unitOfWork.UserAchievementRepository.GetByUserAndAchievement(userId, achievementId);

                if (userAchievement == null)
                {
                    userAchievement = new UserAchievement
                    {
                        UserId = userId,
                        AchievementId = achievementId,
                        Progress = newProgress,
                        IsCompleted = nowCompleted,
                        CompletedAt = nowCompleted ? DateTime.UtcNow : null
                    };
                    await _unitOfWork.UserAchievementRepository.InsertAsync(userAchievement);
                }
                else
                {
                    if (newProgress > userAchievement.Progress)
                    {
                        userAchievement.Progress = newProgress;
                    }
                    if (nowCompleted && !userAchievement.IsCompleted)
                    {
                        userAchievement.IsCompleted = true;
                        userAchievement.CompletedAt = DateTime.UtcNow;
                    }
                    _unitOfWork.UserAchievementRepository.Update(userAchievement);
                }
            }

            await _unitOfWork.SaveAsync();
        }
    }
}

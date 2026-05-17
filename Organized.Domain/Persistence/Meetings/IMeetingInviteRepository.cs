using Organized.Domain.Entities.Meetings;
using Organized.Domain.Persistence.Common;

namespace Organized.Domain.Persistence.Meetings
{
    public interface IMeetingInviteRepository : IRepository<MeetingInvite, int>
    {
        Task<MeetingInvite?> GetById(int id);
        Task<IEnumerable<MeetingInvite>> GetByMeeting(int meetingId);
        Task<IEnumerable<MeetingInvite>> GetActiveInvitesForUser(int userId, DateTime now);
        Task<IEnumerable<MeetingInvite>> GetAcceptedFutureInvitesForUser(int userId, DateTime now);
        Task<MeetingInvite?> GetByMeetingAndUser(int meetingId, int userId);
    }
}

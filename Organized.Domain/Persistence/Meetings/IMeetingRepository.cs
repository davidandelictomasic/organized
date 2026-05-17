using Organized.Domain.Entities.Meetings;
using Organized.Domain.Persistence.Common;

namespace Organized.Domain.Persistence.Meetings
{
    public interface IMeetingRepository : IRepository<Meeting, int>
    {
        Task<Meeting?> GetById(int id);
        Task<IEnumerable<Meeting>> GetByCreator(int adminUserId);
        Task<IEnumerable<Meeting>> GetByIds(IEnumerable<int> ids);
        Task<Meeting?> FindRoomConflict(int meetingRoomTableId, DateTime date, TimeSpan startTime, TimeSpan endTime);
        Task<List<int>> FindBusyUserIds(IEnumerable<int> userIds, DateTime date, TimeSpan startTime, TimeSpan endTime);
    }
}

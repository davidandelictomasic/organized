using Microsoft.EntityFrameworkCore;
using Organized.Domain.Entities.Meetings;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Meetings;
using Organized.Infrastructure.Database;
using Organized.Infrastructure.Persistence.Common;

namespace Organized.Infrastructure.Persistence.Meetings
{
    public class MeetingRepository : Repository<Meeting, int>, IMeetingRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MeetingRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Meeting?> GetById(int id)
        {
            return await _dbContext.Meetings.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Meeting>> GetByCreator(int adminUserId)
        {
            return await _dbContext.Meetings
                .Where(m => m.CreatedByUserId == adminUserId)
                .OrderByDescending(m => m.MeetingDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Meeting>> GetByIds(IEnumerable<int> ids)
        {
            return await _dbContext.Meetings
                .Where(m => ids.Contains(m.Id))
                .ToListAsync();
        }

        public async Task<Meeting?> FindRoomConflict(int meetingRoomTableId, DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            var day = date.Date;
            return await _dbContext.Meetings
                .Where(m => m.MeetingRoomTableId == meetingRoomTableId
                    && m.Status == MeetingStatus.Scheduled
                    && m.MeetingDate == day
                    && m.StartTime < endTime
                    && startTime < m.EndTime)
                .OrderBy(m => m.StartTime)
                .FirstOrDefaultAsync();
        }

        public async Task<List<int>> FindBusyUserIds(IEnumerable<int> userIds, DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            var ids = userIds.Distinct().ToList();
            var day = date.Date;

            var creatorIds = await _dbContext.Meetings
                .Where(m => ids.Contains(m.CreatedByUserId)
                    && m.Status == MeetingStatus.Scheduled
                    && m.MeetingDate == day
                    && m.StartTime < endTime
                    && startTime < m.EndTime)
                .Select(m => m.CreatedByUserId)
                .ToListAsync();

            var attendeeIds = await (from inv in _dbContext.MeetingInvites
                                     join m in _dbContext.Meetings on inv.MeetingId equals m.Id
                                     where ids.Contains(inv.UserId)
                                         && inv.Status == MeetingInviteStatus.Accepted
                                         && m.Status == MeetingStatus.Scheduled
                                         && m.MeetingDate == day
                                         && m.StartTime < endTime
                                         && startTime < m.EndTime
                                     select inv.UserId).ToListAsync();

            return creatorIds.Concat(attendeeIds).Distinct().ToList();
        }
    }
}

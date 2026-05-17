using Microsoft.EntityFrameworkCore;
using Organized.Domain.Entities.Meetings;
using Organized.Domain.Enums;
using Organized.Domain.Persistence.Meetings;
using Organized.Infrastructure.Database;
using Organized.Infrastructure.Persistence.Common;

namespace Organized.Infrastructure.Persistence.Meetings
{
    public class MeetingInviteRepository : Repository<MeetingInvite, int>, IMeetingInviteRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MeetingInviteRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MeetingInvite?> GetById(int id)
        {
            return await _dbContext.MeetingInvites.FirstOrDefaultAsync(mi => mi.Id == id);
        }

        public async Task<IEnumerable<MeetingInvite>> GetByMeeting(int meetingId)
        {
            return await _dbContext.MeetingInvites
                .Where(mi => mi.MeetingId == meetingId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MeetingInvite>> GetActiveInvitesForUser(int userId, DateTime now)
        {
            var today = now.Date;
            return await _dbContext.MeetingInvites
                .Join(_dbContext.Meetings,
                      mi => mi.MeetingId,
                      m => m.Id,
                      (mi, m) => new { Invite = mi, Meeting = m })
                .Where(x => x.Invite.UserId == userId
                            && x.Invite.Status == MeetingInviteStatus.Pending
                            && x.Meeting.Status == MeetingStatus.Scheduled
                            && x.Meeting.MeetingDate >= today)
                .Select(x => x.Invite)
                .ToListAsync();
        }

        public async Task<IEnumerable<MeetingInvite>> GetAcceptedFutureInvitesForUser(int userId, DateTime now)
        {
            var today = now.Date;
            return await _dbContext.MeetingInvites
                .Join(_dbContext.Meetings,
                      mi => mi.MeetingId,
                      m => m.Id,
                      (mi, m) => new { Invite = mi, Meeting = m })
                .Where(x => x.Invite.UserId == userId
                            && x.Invite.Status == MeetingInviteStatus.Accepted
                            && x.Meeting.Status == MeetingStatus.Scheduled
                            && x.Meeting.MeetingDate >= today)
                .Select(x => x.Invite)
                .ToListAsync();
        }

        public async Task<MeetingInvite?> GetByMeetingAndUser(int meetingId, int userId)
        {
            return await _dbContext.MeetingInvites
                .FirstOrDefaultAsync(mi => mi.MeetingId == meetingId && mi.UserId == userId);
        }
    }
}


using Microsoft.EntityFrameworkCore;
using Organized.Domain.Entities.Achievements;
using Organized.Domain.Entities.Friends;
using Organized.Domain.Entities.Meetings;
using Organized.Domain.Entities.Reservations;
using Organized.Domain.Entities.Tables;
using Organized.Domain.Entities.Users;
using Organized.Infrastructure.Database.Seed;

namespace Organized.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<CompanyTable> CompanyTables { get; set; } = null!;

        public DbSet<Reservation> Reservations { get; set; } = null!;

        public DbSet<Achievement> Achievements { get; set; } = null!;
        public DbSet<UserAchievement> UserAchievements { get; set; } = null!;

        public DbSet<Friendship> Friendships { get; set; } = null!;
        public DbSet<FriendRequest> FriendRequests { get; set; } = null!;

        public DbSet<Meeting> Meetings { get; set; } = null!;
        public DbSet<MeetingInvite> MeetingInvites { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.HasDefaultSchema("public");
            
            DatabaseSeeder.SeedData(modelBuilder);
        }
    }
}

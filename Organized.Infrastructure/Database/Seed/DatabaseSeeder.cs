using Microsoft.EntityFrameworkCore;
using Organized.Domain.Entities.Achievements;
using Organized.Domain.Entities.Friends;
using Organized.Domain.Entities.Tables;
using Organized.Domain.Entities.Users;
using Organized.Domain.Enums;

namespace Organized.Infrastructure.Database.Seed
{
    public static class DatabaseSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var seedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin User", Email = "admin@organized.com", Password = "admin123", LastOnline = seedDate, Role = UserRole.Admin },
                new User { Id = 46, Name = "John Director", Email = "john.director@organized.com", Password = "director123", LastOnline = seedDate, Role = UserRole.Admin },
                new User { Id = 2, Name = "John Doe", Email = "john.doe@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 3, Name = "Jane Smith", Email = "jane.smith@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 4, Name = "Bob Johnson", Email = "bob.johnson@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 5, Name = "Alice Brown", Email = "alice.brown@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 6, Name = "Charlie Davis", Email = "charlie.davis@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 7, Name = "Diana Evans", Email = "diana.evans@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 8, Name = "Ethan Foster", Email = "ethan.foster@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 9, Name = "Fiona Garcia", Email = "fiona.garcia@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 10, Name = "George Harris", Email = "george.harris@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 11, Name = "Hannah Iverson", Email = "hannah.iverson@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 12, Name = "Ian Jackson", Email = "ian.jackson@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 13, Name = "Julia Kim", Email = "julia.kim@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 14, Name = "Kevin Lee", Email = "kevin.lee@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 15, Name = "Laura Martinez", Email = "laura.martinez@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 16, Name = "Mason Nelson", Email = "mason.nelson@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 17, Name = "Nora Oborne", Email = "nora.oborne@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 18, Name = "Oliver Patel", Email = "oliver.patel@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 19, Name = "Penelope Quinn", Email = "penelope.quinn@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 20, Name = "Quentin Roberts", Email = "quentin.roberts@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 21, Name = "Rachel Stewart", Email = "rachel.stewart@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 22, Name = "Samuel Thompson", Email = "samuel.thompson@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 23, Name = "Tara Underwood", Email = "tara.underwood@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 24, Name = "Uma Vasquez", Email = "uma.vasquez@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 25, Name = "Victor Wong", Email = "victor.wong@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 26, Name = "Wendy Xu", Email = "wendy.xu@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 27, Name = "Xavier Young", Email = "xavier.young@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 28, Name = "Yara Zhang", Email = "yara.zhang@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 29, Name = "Zachary Adams", Email = "zachary.adams@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 30, Name = "Amelia Brooks", Email = "amelia.brooks@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 31, Name = "Benjamin Carter", Email = "benjamin.carter@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 32, Name = "Chloe Diaz", Email = "chloe.diaz@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 33, Name = "Daniel Edwards", Email = "daniel.edwards@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 34, Name = "Emma Fischer", Email = "emma.fischer@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 35, Name = "Felix Green", Email = "felix.green@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 36, Name = "Grace Hill", Email = "grace.hill@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 37, Name = "Henry Ingram", Email = "henry.ingram@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 38, Name = "Isabella Jones", Email = "isabella.jones@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 39, Name = "Jacob Klein", Email = "jacob.klein@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 40, Name = "Katherine Lopez", Email = "katherine.lopez@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 41, Name = "Liam Mitchell", Email = "liam.mitchell@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 42, Name = "Mia Nguyen", Email = "mia.nguyen@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 43, Name = "Noah Owens", Email = "noah.owens@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 44, Name = "Olivia Park", Email = "olivia.park@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User },
                new User { Id = 45, Name = "Patrick Reyes", Email = "patrick.reyes@example.com", Password = "password123", LastOnline = seedDate, Role = UserRole.User }
            );

            modelBuilder.Entity<CompanyTable>().HasData(
                new CompanyTable { Id = 1, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 2, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 3, CompanyName = "TechCorp", City = "Los Angeles", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 4, CompanyName = "DataSoft", City = "Chicago", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 5, CompanyName = "DataSoft", City = "Chicago", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 6, CompanyName = "CloudBase", City = "Seattle", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 7, CompanyName = "CloudBase", City = "Seattle", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 8, CompanyName = "InnovateLab", City = "Austin", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 9, CompanyName = "InnovateLab", City = "Austin", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 10, CompanyName = "StartupHub", City = "San Francisco", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 11, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = true, Capacity = 10 },
                new CompanyTable { Id = 12, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 13, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 14, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 15, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 16, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 17, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 18, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 19, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 20, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 21, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 22, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 23, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 24, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 25, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 26, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 27, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 28, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 29, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 30, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 31, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 32, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 33, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 34, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 35, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 36, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 37, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 38, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 39, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 40, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 },
                new CompanyTable { Id = 41, CompanyName = "TechCorp", City = "New York", IsMeetingRoom = false, Capacity = 1 }
            );

            modelBuilder.Entity<Achievement>().HasData(
                new Achievement { Id = 1, Name = "First Reservation", Description = "Make your first table reservation", MaxProgress = 1, IsHidden = false, TargetRole = AchievementTargetRole.User },
                new Achievement { Id = 3, Name = "Frequent Visitor", Description = "Make 10 reservations", MaxProgress = 10, IsHidden = false, TargetRole = AchievementTargetRole.User },
                new Achievement { Id = 4, Name = "Power User", Description = "Make 25 reservations", MaxProgress = 25, IsHidden = false, TargetRole = AchievementTargetRole.User },
                new Achievement { Id = 5, Name = "Legend", Description = "Make 50 reservations", MaxProgress = 50, IsHidden = false, TargetRole = AchievementTargetRole.User },
                new Achievement { Id = 9, Name = "Social Butterfly", Description = "Add 10 friends", MaxProgress = 10, IsHidden = false, TargetRole = AchievementTargetRole.Both },
                new Achievement { Id = 10, Name = "Networking Pro", Description = "Add 25 friends", MaxProgress = 25, IsHidden = false, TargetRole = AchievementTargetRole.Both },
                new Achievement { Id = 11, Name = "LinkedIn IRL", Description = "Add 50 friends", MaxProgress = 50, IsHidden = false, TargetRole = AchievementTargetRole.Both },
                new Achievement { Id = 16, Name = "Plans Change", Description = "Cancel 10 reservations", MaxProgress = 10, IsHidden = false, TargetRole = AchievementTargetRole.User },
                new Achievement { Id = 17, Name = "Serial Canceller", Description = "Cancel 25 reservations", MaxProgress = 25, IsHidden = false, TargetRole = AchievementTargetRole.User },
                new Achievement { Id = 18, Name = "Master of Maybe", Description = "Cancel 50 reservations", MaxProgress = 50, IsHidden = false, TargetRole = AchievementTargetRole.User },
                new Achievement { Id = 19, Name = "First Order of Business", Description = "Create your first meeting", MaxProgress = 1, IsHidden = false, TargetRole = AchievementTargetRole.Admin },
                new Achievement { Id = 20, Name = "Meeting Maker", Description = "Create 10 meetings", MaxProgress = 10, IsHidden = false, TargetRole = AchievementTargetRole.Admin },
                new Achievement { Id = 21, Name = "Calendar Tetris", Description = "Create 25 meetings", MaxProgress = 25, IsHidden = false, TargetRole = AchievementTargetRole.Admin },
                new Achievement { Id = 22, Name = "Boss of Bosses", Description = "Create 50 meetings", MaxProgress = 50, IsHidden = false, TargetRole = AchievementTargetRole.Admin },
                new Achievement { Id = 23, Name = "Reschedule Royalty", Description = "Cancel 5 meetings", MaxProgress = 5, IsHidden = false, TargetRole = AchievementTargetRole.Admin },
                new Achievement { Id = 24, Name = "Master of Postponement", Description = "Cancel 15 meetings", MaxProgress = 15, IsHidden = false, TargetRole = AchievementTargetRole.Admin },
                new Achievement { Id = 25, Name = "Popular Demand", Description = "Get 10 meeting invite accepts", MaxProgress = 10, IsHidden = false, TargetRole = AchievementTargetRole.Admin },
                new Achievement { Id = 26, Name = "Charisma Maxed", Description = "Get 50 meeting invite accepts", MaxProgress = 50, IsHidden = false, TargetRole = AchievementTargetRole.Admin },
                new Achievement { Id = 27, Name = "Could've Been an Email", Description = "Schedule 25 meetings shorter than 15 minutes", MaxProgress = 25, IsHidden = false, TargetRole = AchievementTargetRole.Admin }
            );

            modelBuilder.Entity<Friendship>().HasData(
                new Friendship { Id = 1, UserId = 1, FriendId = 2, CreatedAt = seedDate },
                new Friendship { Id = 2, UserId = 1, FriendId = 3, CreatedAt = seedDate },
                new Friendship { Id = 3, UserId = 1, FriendId = 4, CreatedAt = seedDate },
                new Friendship { Id = 4, UserId = 2, FriendId = 3, CreatedAt = seedDate },
                new Friendship { Id = 5, UserId = 1, FriendId = 6, CreatedAt = seedDate },
                new Friendship { Id = 6, UserId = 1, FriendId = 7, CreatedAt = seedDate },
                new Friendship { Id = 7, UserId = 1, FriendId = 8, CreatedAt = seedDate }
            );

            modelBuilder.Entity<FriendRequest>().HasData(
                new FriendRequest { Id = 1, SenderId = 5, ReceiverId = 1, Status = FriendRequestStatus.Pending, CreatedAt = seedDate },
                new FriendRequest { Id = 2, SenderId = 9, ReceiverId = 1, Status = FriendRequestStatus.Pending, CreatedAt = seedDate },
                new FriendRequest { Id = 3, SenderId = 10, ReceiverId = 1, Status = FriendRequestStatus.Pending, CreatedAt = seedDate },
                new FriendRequest { Id = 4, SenderId = 11, ReceiverId = 1, Status = FriendRequestStatus.Pending, CreatedAt = seedDate },
                new FriendRequest { Id = 5, SenderId = 12, ReceiverId = 1, Status = FriendRequestStatus.Pending, CreatedAt = seedDate }
            );
        }
    }
}

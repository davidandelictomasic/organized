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
                new User { Id = 100, Name = "Admin User", Email = "admin@organized.com", Password = "admin123", LastOnline = seedDate },
                new User { Id = 101, Name = "John Doe", Email = "john.doe@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 102, Name = "Jane Smith", Email = "jane.smith@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 103, Name = "Bob Johnson", Email = "bob.johnson@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 104, Name = "Alice Brown", Email = "alice.brown@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 105, Name = "Charlie Davis", Email = "charlie.davis@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 106, Name = "Diana Evans", Email = "diana.evans@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 107, Name = "Ethan Foster", Email = "ethan.foster@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 108, Name = "Fiona Garcia", Email = "fiona.garcia@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 109, Name = "George Harris", Email = "george.harris@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 110, Name = "Hannah Iverson", Email = "hannah.iverson@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 111, Name = "Ian Jackson", Email = "ian.jackson@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 112, Name = "Julia Kim", Email = "julia.kim@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 113, Name = "Kevin Lee", Email = "kevin.lee@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 114, Name = "Laura Martinez", Email = "laura.martinez@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 115, Name = "Mason Nelson", Email = "mason.nelson@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 116, Name = "Nora Oborne", Email = "nora.oborne@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 117, Name = "Oliver Patel", Email = "oliver.patel@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 118, Name = "Penelope Quinn", Email = "penelope.quinn@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 119, Name = "Quentin Roberts", Email = "quentin.roberts@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 120, Name = "Rachel Stewart", Email = "rachel.stewart@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 121, Name = "Samuel Thompson", Email = "samuel.thompson@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 122, Name = "Tara Underwood", Email = "tara.underwood@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 123, Name = "Uma Vasquez", Email = "uma.vasquez@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 124, Name = "Victor Wong", Email = "victor.wong@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 125, Name = "Wendy Xu", Email = "wendy.xu@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 126, Name = "Xavier Young", Email = "xavier.young@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 127, Name = "Yara Zhang", Email = "yara.zhang@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 128, Name = "Zachary Adams", Email = "zachary.adams@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 129, Name = "Amelia Brooks", Email = "amelia.brooks@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 130, Name = "Benjamin Carter", Email = "benjamin.carter@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 131, Name = "Chloe Diaz", Email = "chloe.diaz@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 132, Name = "Daniel Edwards", Email = "daniel.edwards@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 133, Name = "Emma Fischer", Email = "emma.fischer@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 134, Name = "Felix Green", Email = "felix.green@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 135, Name = "Grace Hill", Email = "grace.hill@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 136, Name = "Henry Ingram", Email = "henry.ingram@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 137, Name = "Isabella Jones", Email = "isabella.jones@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 138, Name = "Jacob Klein", Email = "jacob.klein@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 139, Name = "Katherine Lopez", Email = "katherine.lopez@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 140, Name = "Liam Mitchell", Email = "liam.mitchell@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 141, Name = "Mia Nguyen", Email = "mia.nguyen@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 142, Name = "Noah Owens", Email = "noah.owens@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 143, Name = "Olivia Park", Email = "olivia.park@example.com", Password = "password123", LastOnline = seedDate },
                new User { Id = 144, Name = "Patrick Reyes", Email = "patrick.reyes@example.com", Password = "password123", LastOnline = seedDate }
            );

            modelBuilder.Entity<CompanyTable>().HasData(
                new CompanyTable { Id = 100, CompanyName = "TechCorp", City = "New York" },
                new CompanyTable { Id = 101, CompanyName = "TechCorp", City = "New York" },
                new CompanyTable { Id = 102, CompanyName = "TechCorp", City = "Los Angeles" },
                new CompanyTable { Id = 103, CompanyName = "DataSoft", City = "Chicago" },
                new CompanyTable { Id = 104, CompanyName = "DataSoft", City = "Chicago" },
                new CompanyTable { Id = 105, CompanyName = "CloudBase", City = "Seattle" },
                new CompanyTable { Id = 106, CompanyName = "CloudBase", City = "Seattle" },
                new CompanyTable { Id = 107, CompanyName = "InnovateLab", City = "Austin" },
                new CompanyTable { Id = 108, CompanyName = "InnovateLab", City = "Austin" },
                new CompanyTable { Id = 109, CompanyName = "StartupHub", City = "San Francisco" }
            );

            modelBuilder.Entity<Achievement>().HasData(
                new Achievement { Id = 100, Name = "First Reservation", Description = "Make your first table reservation", MaxProgress = 1, IsHidden = false },
                new Achievement { Id = 101, Name = "Regular", Description = "Make 5 reservations", MaxProgress = 5, IsHidden = false },
                new Achievement { Id = 102, Name = "Frequent Visitor", Description = "Make 10 reservations", MaxProgress = 10, IsHidden = false },
                new Achievement { Id = 103, Name = "Power User", Description = "Make 25 reservations", MaxProgress = 25, IsHidden = false },
                new Achievement { Id = 104, Name = "Legend", Description = "Make 50 reservations", MaxProgress = 50, IsHidden = false },
                new Achievement { Id = 105, Name = "Early Bird", Description = "Make a reservation before 9 AM", MaxProgress = 1, IsHidden = true },
                new Achievement { Id = 106, Name = "Night Owl", Description = "Make a reservation after 6 PM", MaxProgress = 1, IsHidden = true },
                new Achievement { Id = 107, Name = "Explorer", Description = "Reserve tables at 5 different companies", MaxProgress = 5, IsHidden = false },
                new Achievement { Id = 108, Name = "Social Butterfly", Description = "Add 10 friends", MaxProgress = 10, IsHidden = false },
                new Achievement { Id = 109, Name = "Networking Pro", Description = "Add 25 friends", MaxProgress = 25, IsHidden = false }
            );

            modelBuilder.Entity<Friendship>().HasData(
                new Friendship { Id = 100, UserId = 100, FriendId = 101, CreatedAt = seedDate },
                new Friendship { Id = 101, UserId = 100, FriendId = 102, CreatedAt = seedDate },
                new Friendship { Id = 102, UserId = 100, FriendId = 103, CreatedAt = seedDate },
                new Friendship { Id = 103, UserId = 101, FriendId = 102, CreatedAt = seedDate },
                new Friendship { Id = 104, UserId = 100, FriendId = 105, CreatedAt = seedDate },
                new Friendship { Id = 105, UserId = 100, FriendId = 106, CreatedAt = seedDate },
                new Friendship { Id = 106, UserId = 100, FriendId = 107, CreatedAt = seedDate }
            );

            modelBuilder.Entity<FriendRequest>().HasData(
                new FriendRequest { Id = 100, SenderId = 104, ReceiverId = 100, Status = FriendRequestStatus.Pending, CreatedAt = seedDate },
                new FriendRequest { Id = 101, SenderId = 108, ReceiverId = 100, Status = FriendRequestStatus.Pending, CreatedAt = seedDate },
                new FriendRequest { Id = 102, SenderId = 109, ReceiverId = 100, Status = FriendRequestStatus.Pending, CreatedAt = seedDate },
                new FriendRequest { Id = 103, SenderId = 110, ReceiverId = 100, Status = FriendRequestStatus.Pending, CreatedAt = seedDate },
                new FriendRequest { Id = 104, SenderId = 111, ReceiverId = 100, Status = FriendRequestStatus.Pending, CreatedAt = seedDate }
            );
        }
    }
}

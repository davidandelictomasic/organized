using Microsoft.EntityFrameworkCore;
using Organized.Domain.Entities.Achievements;
using Organized.Domain.Entities.Tables;
using Organized.Domain.Entities.Users;

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
                new User { Id = 104, Name = "Alice Brown", Email = "alice.brown@example.com", Password = "password123", LastOnline = seedDate }
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
                new Achievement { Id = 100, Name = "First Reservation", Description = "Make your first table reservation", MaxProgress = 1 },
                new Achievement { Id = 101, Name = "Regular", Description = "Make 5 reservations", MaxProgress = 5 },
                new Achievement { Id = 102, Name = "Frequent Visitor", Description = "Make 10 reservations", MaxProgress = 10 },
                new Achievement { Id = 103, Name = "Power User", Description = "Make 25 reservations", MaxProgress = 25 },
                new Achievement { Id = 104, Name = "Legend", Description = "Make 50 reservations", MaxProgress = 50 },
                new Achievement { Id = 105, Name = "Early Bird", Description = "Make a reservation before 9 AM", MaxProgress = 1 },
                new Achievement { Id = 106, Name = "Night Owl", Description = "Make a reservation after 6 PM", MaxProgress = 1 },
                new Achievement { Id = 107, Name = "Explorer", Description = "Reserve tables at 5 different companies", MaxProgress = 5 },
                new Achievement { Id = 108, Name = "Social Butterfly", Description = "Add 10 friends", MaxProgress = 10 },
                new Achievement { Id = 109, Name = "Networking Pro", Description = "Add 25 friends", MaxProgress = 25 }
            );
        }
    }
}

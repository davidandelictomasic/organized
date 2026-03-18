

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Organized.Domain.Persistence.Achievements;
using Organized.Domain.Persistence.Common;
using Organized.Domain.Persistence.Friends;
using Organized.Domain.Persistence.Reservations;
using Organized.Domain.Persistence.Tables;
using Organized.Domain.Persistence.Users;
using Organized.Infrastructure.Persistence.Achievements;
using Organized.Infrastructure.Persistence.Common;
using Organized.Infrastructure.Persistence.Friends;
using Organized.Infrastructure.Persistence.Reservations;
using Organized.Infrastructure.Persistence.Tables;
using Organized.Infrastructure.Persistence.Users;

namespace Organized.Infrastructure.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            AddDatabase(services, configuration);
            AddRepositories(services);

            return services;
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Database");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddHttpClient();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            // Users
            services.AddScoped<IUserRepository, UserRepository>();

            // Tables
            services.AddScoped<ICompanyTableRepository, CompanyTableRepository>();

            // Reservations
            services.AddScoped<IReservationRepository, ReservationRepository>();

            // Achievements
            services.AddScoped<IAchievementRepository, AchievementRepository>();
            services.AddScoped<IUserAchievementRepository, UserAchievementRepository>();

            // Friends
            services.AddScoped<IFriendshipRepository, FriendshipRepository>();
            services.AddScoped<IFriendRequestRepository, FriendRequestRepository>();

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

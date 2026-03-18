using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organized.Domain.Entities.Achievements;

namespace Organized.Infrastructure.Database.Configurations.Achievements
{
    public class UserAchievementConfiguration : IEntityTypeConfiguration<UserAchievement>
    {
        public void Configure(EntityTypeBuilder<UserAchievement> builder)
        {
            builder.ToTable("user_achievements");

            builder.HasKey(ua => ua.Id);

            builder.Property(ua => ua.Id)
                   .HasColumnName("id");

            builder.Property(ua => ua.UserId)
                   .HasColumnName("user_id")
                   .IsRequired();

            builder.Property(ua => ua.AchievementId)
                   .HasColumnName("achievement_id")
                   .IsRequired();

            builder.Property(ua => ua.Progress)
                   .HasColumnName("progress")
                   .IsRequired();

            builder.Property(ua => ua.IsCompleted)
                   .HasColumnName("is_completed")
                   .IsRequired();

            builder.Property(ua => ua.CompletedAt)
                   .HasColumnName("completed_at");

            builder.HasIndex(ua => ua.UserId);
            builder.HasIndex(ua => new { ua.UserId, ua.AchievementId }).IsUnique();
        }
    }
}

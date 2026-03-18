using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organized.Domain.Entities.Achievements;

namespace Organized.Infrastructure.Database.Configurations.Achievements
{
    public class AchievementConfiguration : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> builder)
        {
            builder.ToTable("achievements");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("id");

            builder.Property(a => a.Name)
                   .HasColumnName("name")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Description)
                   .HasColumnName("description")
                   .HasMaxLength(500);

            builder.Property(a => a.MaxProgress)
                   .HasColumnName("max_progress")
                   .IsRequired();
        }
    }
}

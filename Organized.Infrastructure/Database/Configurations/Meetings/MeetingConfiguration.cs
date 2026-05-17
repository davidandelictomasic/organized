using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organized.Domain.Entities.Meetings;

namespace Organized.Infrastructure.Database.Configurations.Meetings
{
    public class MeetingConfiguration : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            builder.ToTable("meetings");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                   .HasColumnName("id");

            builder.Property(m => m.CreatedByUserId)
                   .HasColumnName("created_by_user_id")
                   .IsRequired();

            builder.Property(m => m.MeetingRoomTableId)
                   .HasColumnName("meeting_room_table_id")
                   .IsRequired();

            builder.Property(m => m.Title)
                   .HasColumnName("title")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.Description)
                   .HasColumnName("description")
                   .HasMaxLength(1000);

            builder.Property(m => m.MeetingDate)
                   .HasColumnName("meeting_date")
                   .IsRequired();

            builder.Property(m => m.StartTime)
                   .HasColumnName("start_time")
                   .IsRequired();

            builder.Property(m => m.EndTime)
                   .HasColumnName("end_time")
                   .IsRequired();

            builder.Property(m => m.Status)
                   .HasColumnName("status")
                   .IsRequired();

            builder.Property(m => m.CreatedAt)
                   .HasColumnName("created_at")
                   .IsRequired();

            builder.HasIndex(m => m.CreatedByUserId);
            builder.HasIndex(m => m.MeetingDate);
        }
    }
}

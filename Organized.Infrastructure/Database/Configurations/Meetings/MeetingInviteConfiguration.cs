using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organized.Domain.Entities.Meetings;

namespace Organized.Infrastructure.Database.Configurations.Meetings
{
    public class MeetingInviteConfiguration : IEntityTypeConfiguration<MeetingInvite>
    {
        public void Configure(EntityTypeBuilder<MeetingInvite> builder)
        {
            builder.ToTable("meeting_invites");

            builder.HasKey(mi => mi.Id);

            builder.Property(mi => mi.Id)
                   .HasColumnName("id");

            builder.Property(mi => mi.MeetingId)
                   .HasColumnName("meeting_id")
                   .IsRequired();

            builder.Property(mi => mi.UserId)
                   .HasColumnName("user_id")
                   .IsRequired();

            builder.Property(mi => mi.Status)
                   .HasColumnName("status")
                   .IsRequired();

            builder.Property(mi => mi.CreatedAt)
                   .HasColumnName("created_at")
                   .IsRequired();

            builder.Property(mi => mi.RespondedAt)
                   .HasColumnName("responded_at");

            builder.HasIndex(mi => mi.MeetingId);
            builder.HasIndex(mi => mi.UserId);
            builder.HasIndex(mi => new { mi.MeetingId, mi.UserId }).IsUnique();
        }
    }
}

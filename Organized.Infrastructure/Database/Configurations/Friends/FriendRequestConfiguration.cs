using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organized.Domain.Entities.Friends;

namespace Organized.Infrastructure.Database.Configurations.Friends
{
    public class FriendRequestConfiguration : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.ToTable("friend_requests");

            builder.HasKey(fr => fr.Id);

            builder.Property(fr => fr.Id)
                   .HasColumnName("id");

            builder.Property(fr => fr.SenderId)
                   .HasColumnName("sender_id")
                   .IsRequired();

            builder.Property(fr => fr.ReceiverId)
                   .HasColumnName("receiver_id")
                   .IsRequired();

            builder.Property(fr => fr.Status)
                   .HasColumnName("status")
                   .IsRequired();

            builder.Property(fr => fr.CreatedAt)
                   .HasColumnName("created_at")
                   .IsRequired();

            builder.HasIndex(fr => fr.SenderId);
            builder.HasIndex(fr => fr.ReceiverId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organized.Domain.Entities.Friends;

namespace Organized.Infrastructure.Database.Configurations.Friends
{
    public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.ToTable("friendships");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                   .HasColumnName("id");

            builder.Property(f => f.UserId)
                   .HasColumnName("user_id")
                   .IsRequired();

            builder.Property(f => f.FriendId)
                   .HasColumnName("friend_id")
                   .IsRequired();

            builder.Property(f => f.CreatedAt)
                   .HasColumnName("created_at")
                   .IsRequired();

            builder.HasIndex(f => f.UserId);
            builder.HasIndex(f => f.FriendId);
            builder.HasIndex(f => new { f.UserId, f.FriendId }).IsUnique();
        }
    }
}

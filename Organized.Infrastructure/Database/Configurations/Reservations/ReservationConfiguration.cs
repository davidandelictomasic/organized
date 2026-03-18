using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organized.Domain.Entities.Reservations;

namespace Organized.Infrastructure.Database.Configurations.Reservations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("reservations");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                   .HasColumnName("id");

            builder.Property(r => r.UserId)
                   .HasColumnName("user_id")
                   .IsRequired();

            builder.Property(r => r.TableId)
                   .HasColumnName("table_id")
                   .IsRequired();

            builder.Property(r => r.ReservationDate)
                   .HasColumnName("reservation_date")
                   .IsRequired();

            builder.Property(r => r.Status)
                   .HasColumnName("status")
                   .IsRequired();

            builder.HasIndex(r => r.UserId);
            builder.HasIndex(r => r.TableId);
            builder.HasIndex(r => r.ReservationDate);
        }
    }
}

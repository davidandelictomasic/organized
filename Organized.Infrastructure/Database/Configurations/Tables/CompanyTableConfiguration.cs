using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organized.Domain.Entities.Tables;

namespace Organized.Infrastructure.Database.Configurations.Tables
{
    public class CompanyTableConfiguration : IEntityTypeConfiguration<CompanyTable>
    {
        public void Configure(EntityTypeBuilder<CompanyTable> builder)
        {
            builder.ToTable("company_tables");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .HasColumnName("id");

            builder.Property(t => t.CompanyName)
                   .HasColumnName("company_name")
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(t => t.City)
                   .HasColumnName("city")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.IsMeetingRoom)
                   .HasColumnName("is_meeting_room")
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(t => t.Capacity)
                   .HasColumnName("capacity")
                   .IsRequired()
                   .HasDefaultValue(1);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlympiadWpfApp.DataAccess.Entities;

namespace OlympiadWpfApp.DataAccess.Configurations;

public class OlympiadConfiguration : IEntityTypeConfiguration<OlympiadEntity>
{
    public void Configure(EntityTypeBuilder<OlympiadEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("Olympiad_pkey");

        builder.ToTable("Olympiad");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .HasColumnName("name");
        builder.Property(e => e.City)
            .HasMaxLength(100)
            .HasColumnName("city");
        builder.Property(e => e.HostCountry)
            .HasMaxLength(100)
            .HasColumnName("host_country");
        builder.Property(e => e.IsDeleted)
            .HasDefaultValue(false)
            .HasColumnName("is_deleted");
        builder.Property(e => e.IsWinter)
            .HasDefaultValue(false)
            .HasColumnName("is_winter");
        builder.Property(e => e.Year).HasColumnName("year");
    }
}
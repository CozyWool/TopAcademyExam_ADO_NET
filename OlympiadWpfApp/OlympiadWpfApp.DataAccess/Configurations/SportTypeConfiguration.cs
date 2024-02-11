using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlympiadWpfApp.DataAccess.Entities;

namespace OlympiadWpfApp.DataAccess.Configurations;

public class SportTypeConfiguration : IEntityTypeConfiguration<SportTypeEntity>
{
    public void Configure(EntityTypeBuilder<SportTypeEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("Sport_Type_pkey");

        builder.ToTable("Sport_Type");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .HasColumnName("name");
    }
}
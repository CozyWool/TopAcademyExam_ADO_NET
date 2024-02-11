using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlympiadWpfApp.DataAccess.Entities;

namespace OlympiadWpfApp.DataAccess.Configurations;

public class SportTypeOlympiadConfiguration : IEntityTypeConfiguration<SportTypeOlympiadEntity>
{
    public void Configure(EntityTypeBuilder<SportTypeOlympiadEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("Sport_Type_Olympiad_pkey");

        builder.ToTable("Sport_Type_Olympiad");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.OlympiadId).HasColumnName("olympiad_id");
        builder.Property(e => e.SportTypeId).HasColumnName("sport_type_id");

        builder.HasOne(d => d.OlympiadEntity).WithMany(p => p.SportTypeOlympiads)
            .HasForeignKey(d => d.OlympiadId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("olymp_FK");

        builder.HasOne(d => d.SportTypeEntity).WithMany(p => p.SportTypeOlympiads)
            .HasForeignKey(d => d.SportTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("sport_type_FK");
    }
}
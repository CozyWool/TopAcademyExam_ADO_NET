using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlympiadWpfApp.DataAccess.Entities;

namespace OlympiadWpfApp.DataAccess.Configurations;

public class ParticipantConfiguration : IEntityTypeConfiguration<ParticipantEntity>
{
    public void Configure(EntityTypeBuilder<ParticipantEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("Participant_pkey");

        builder.ToTable("Participant");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Birthdate).HasColumnName("birthdate");
        builder.Property(e => e.IsDeleted)
            .HasDefaultValue(false)
            .HasColumnName("is_deleted");
        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");
        builder.Property(e => e.Patronymic)
            .HasMaxLength(50)
            .HasColumnName("patronymic");
        builder.Property(e => e.Surname)
            .HasMaxLength(100)
            .HasColumnName("surname");
        builder.Property(e => e.Photo).HasColumnName("photo");
        builder.Property(e => e.Country).HasColumnName("country").HasMaxLength(100);
    }
}
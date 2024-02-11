using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlympiadWpfApp.DataAccess.Entities;

namespace OlympiadWpfApp.DataAccess.Configurations;

public class SportTypeParticipantConfiguration : IEntityTypeConfiguration<SportTypeParticipantEntity>
{
    public void Configure(EntityTypeBuilder<SportTypeParticipantEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("Sport_Type_Participant_pkey");

        builder.ToTable("Sport_Type_Participant");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.BronzeMedals)
            .HasDefaultValue(0)
            .HasColumnName("bronze_medals");
        builder.Property(e => e.GoldMedals)
            .HasDefaultValue(0)
            .HasColumnName("gold_medals");
        builder.Property(e => e.ParticipantId).HasColumnName("participant_id");
        builder.Property(e => e.SilverMedals)
            .HasDefaultValue(0)
            .HasColumnName("silver_medals");
        builder.Property(e => e.SportTypeId).HasColumnName("sport_type_id");

        builder.HasOne(d => d.ParticipantEntity).WithMany(p => p.SportTypeParticipants)
            .HasForeignKey(d => d.ParticipantId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("participant_id");

        builder.HasOne(d => d.SportTypeEntity).WithMany(p => p.SportTypeParticipants)
            .HasForeignKey(d => d.SportTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("sport_type_fk");
    }
}
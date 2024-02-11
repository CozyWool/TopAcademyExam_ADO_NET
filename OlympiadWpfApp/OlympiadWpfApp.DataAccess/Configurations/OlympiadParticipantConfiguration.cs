using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlympiadWpfApp.DataAccess.Entities;

namespace OlympiadWpfApp.DataAccess.Configurations;

public class OlympiadParticipantConfiguration : IEntityTypeConfiguration<OlympiadParticipantEntity>
{
    public void Configure(EntityTypeBuilder<OlympiadParticipantEntity> builder)
    {
        builder.HasKey(e => e.ParticipantId).HasName("Olympiad_Participant_pkey");

        builder.ToTable("Olympiad_Participant");

        builder.Property(e => e.ParticipantId)
            .ValueGeneratedNever()
            .HasColumnName("participant_id");
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("id");
        builder.Property(e => e.OlympiadId).HasColumnName("olympiad_id");

        builder.HasOne(d => d.OlympiadEntity).WithMany(p => p.OlympiadParticipants)
            .HasForeignKey(d => d.OlympiadId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("olympiad_fk");

        builder.HasOne(d => d.ParticipantEntity).WithOne(p => p.OlympiadParticipant)
            .HasForeignKey<OlympiadParticipantEntity>(d => d.ParticipantId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("participant_fk");
    }
}
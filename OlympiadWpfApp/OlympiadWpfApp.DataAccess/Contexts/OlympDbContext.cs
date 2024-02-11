using Microsoft.EntityFrameworkCore;
using OlympiadWpfApp.DataAccess.Entities;

namespace OlympiadWpfApp.DataAccess.Contexts;

public partial class OlympDbContext : DbContext
{
    public OlympDbContext()
    {
    }

    public OlympDbContext(DbContextOptions<OlympDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OlympiadEntity> Olympiads { get; set; }

    public virtual DbSet<OlympiadParticipantEntity> OlympiadParticipants { get; set; }

    public virtual DbSet<ParticipantEntity> Participants { get; set; }

    public virtual DbSet<SportTypeEntity> SportTypes { get; set; }

    public virtual DbSet<SportTypeOlympiadEntity> SportTypeOlympiads { get; set; }

    public virtual DbSet<SportTypeParticipantEntity> SportTypeParticipants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=qwerty;Database=Olymp;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OlympiadEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Olympiad_pkey");

            entity.ToTable("Olympiad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.HostCountry)
                .HasMaxLength(100)
                .HasColumnName("host_country");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.IsWinter)
                .HasDefaultValue(false)
                .HasColumnName("is_winter");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<OlympiadParticipantEntity>(entity =>
        {
            entity.HasKey(e => e.ParticipantId).HasName("Olympiad_Participant_pkey");

            entity.ToTable("Olympiad_Participant");

            entity.Property(e => e.ParticipantId)
                .ValueGeneratedNever()
                .HasColumnName("participant_id");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.OlympiadId).HasColumnName("olympiad_id");

            entity.HasOne(d => d.OlympiadEntity).WithMany(p => p.OlympiadParticipants)
                .HasForeignKey(d => d.OlympiadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("olympiad_fk");

            entity.HasOne(d => d.ParticipantEntity).WithOne(p => p.OlympiadParticipant)
                .HasForeignKey<OlympiadParticipantEntity>(d => d.ParticipantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("participant_fk");
        });

        modelBuilder.Entity<ParticipantEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Participant_pkey");

            entity.ToTable("Participant");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<SportTypeEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sport_Type_pkey");

            entity.ToTable("Sport_Type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SportTypeOlympiadEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sport_Type_Olympiad_pkey");

            entity.ToTable("Sport_Type_Olympiad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OlympiadId).HasColumnName("olympiad_id");
            entity.Property(e => e.SportTypeId).HasColumnName("sport_type_id");

            entity.HasOne(d => d.OlympiadEntity).WithMany(p => p.SportTypeOlympiads)
                .HasForeignKey(d => d.OlympiadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("olymp_FK");

            entity.HasOne(d => d.SportTypeEntity).WithMany(p => p.SportTypeOlympiads)
                .HasForeignKey(d => d.SportTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sport_type_FK");
        });

        modelBuilder.Entity<SportTypeParticipantEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sport_Type_Participant_pkey");

            entity.ToTable("Sport_Type_Participant");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BronzeMedals)
                .HasDefaultValue(0)
                .HasColumnName("bronze_medals");
            entity.Property(e => e.GoldMedals)
                .HasDefaultValue(0)
                .HasColumnName("gold_medals");
            entity.Property(e => e.ParticipantId).HasColumnName("participant_id");
            entity.Property(e => e.SilverMedals)
                .HasDefaultValue(0)
                .HasColumnName("silver_medals");
            entity.Property(e => e.SportTypeId).HasColumnName("sport_type_id");

            entity.HasOne(d => d.ParticipantEntity).WithMany(p => p.SportTypeParticipants)
                .HasForeignKey(d => d.ParticipantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("participant_id");

            entity.HasOne(d => d.SportTypeEntity).WithMany(p => p.SportTypeParticipants)
                .HasForeignKey(d => d.SportTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sport_type_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

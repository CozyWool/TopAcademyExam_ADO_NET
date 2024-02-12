using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OlympiadWpfApp.DataAccess.Configurations;
using OlympiadWpfApp.DataAccess.Entities;

namespace OlympiadWpfApp.DataAccess.Contexts;

public partial class OlympDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public OlympDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
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
        => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("OlympConnectionString"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OlympiadConfiguration).Assembly);
    }
}
namespace OlympiadWpfApp.DataAccess.Entities;

public partial class OlympiadEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public DateOnly Year { get; set; }

    public string HostCountry { get; set; } = null!;

    public string City { get; set; } = null!;

    public bool IsWinter { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<OlympiadParticipantEntity> OlympiadParticipants { get; set; } = new List<OlympiadParticipantEntity>();

    public virtual ICollection<SportTypeOlympiadEntity> SportTypeOlympiads { get; set; } = new List<SportTypeOlympiadEntity>();
}

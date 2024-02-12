namespace OlympiadWpfApp.DataAccess.Entities;

public partial class OlympiadParticipantEntity
{
    public int Id { get; set; }

    public int OlympiadId { get; set; }

    public int ParticipantId { get; set; }

    public virtual OlympiadEntity OlympiadEntity { get; set; } = null!;

    public virtual ParticipantEntity ParticipantEntity { get; set; } = null!;
}

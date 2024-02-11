namespace OlympiadWpfApp.DataAccess.Entities;

public partial class SportTypeParticipantEntity
{
    public int Id { get; set; }

    public int SportTypeId { get; set; }

    public int ParticipantId { get; set; }

    public int GoldMedals { get; set; }

    public int SilverMedals { get; set; }

    public int BronzeMedals { get; set; }

    public virtual ParticipantEntity ParticipantEntity { get; set; } = null!;

    public virtual SportTypeEntity SportTypeEntity { get; set; } = null!;
}

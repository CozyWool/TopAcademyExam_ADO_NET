namespace OlympiadWpfApp.DataAccess.Entities;

public partial class SportTypeEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SportTypeOlympiadEntity> SportTypeOlympiads { get; set; } = new List<SportTypeOlympiadEntity>();

    public virtual ICollection<SportTypeParticipantEntity> SportTypeParticipants { get; set; } = new List<SportTypeParticipantEntity>();
}

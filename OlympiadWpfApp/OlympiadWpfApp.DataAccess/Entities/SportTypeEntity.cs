namespace OlympiadWpfApp.DataAccess.Entities;

public partial class SportTypeEntity : ICloneable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SportTypeOlympiadEntity> SportTypeOlympiads { get; set; } = new List<SportTypeOlympiadEntity>();

    public virtual ICollection<SportTypeParticipantEntity> SportTypeParticipants { get; set; } = new List<SportTypeParticipantEntity>();
    public object Clone()
    {
        return new SportTypeEntity
        {
            Id = Id,
            Name = Name,
            SportTypeOlympiads = SportTypeOlympiads,
            SportTypeParticipants = SportTypeParticipants
        };
    }
}

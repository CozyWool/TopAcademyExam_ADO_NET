namespace OlympiadWpfApp.DataAccess.Entities;

public partial class ParticipantEntity : ICloneable
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public bool IsDeleted { get; set; }
    public byte[] Photo { get; set; } = null!;
    public string Country { get; set; } = null!;

    public virtual OlympiadParticipantEntity? OlympiadParticipant { get; set; }

    public virtual ICollection<SportTypeParticipantEntity> SportTypeParticipants { get; set; } = new List<SportTypeParticipantEntity>();
    public object Clone()
    {
        return new ParticipantEntity
        {
            Id = Id,
            Surname = Surname,
            Name = Name,
            Patronymic = Patronymic,
            Birthdate = Birthdate,
            IsDeleted = IsDeleted,
            Photo = Photo,
            Country = Country,
            OlympiadParticipant = OlympiadParticipant,
            SportTypeParticipants = SportTypeParticipants
        };
    }
}

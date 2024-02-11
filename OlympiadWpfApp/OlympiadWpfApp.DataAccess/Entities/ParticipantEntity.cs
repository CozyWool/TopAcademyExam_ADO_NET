namespace OlympiadWpfApp.DataAccess.Entities;

public partial class ParticipantEntity
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public bool IsDeleted { get; set; }
    public byte[] Photo { get; set; } = null!;

    public virtual OlympiadParticipantEntity? OlympiadParticipant { get; set; }

    public virtual ICollection<SportTypeParticipantEntity> SportTypeParticipants { get; set; } = new List<SportTypeParticipantEntity>();
}

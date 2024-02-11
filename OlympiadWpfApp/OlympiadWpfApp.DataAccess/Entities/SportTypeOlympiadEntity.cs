namespace OlympiadWpfApp.DataAccess.Entities;

public partial class SportTypeOlympiadEntity
{
    public int Id { get; set; }

    public int SportTypeId { get; set; }

    public int OlympiadId { get; set; }

    public virtual OlympiadEntity OlympiadEntity { get; set; } = null!;

    public virtual SportTypeEntity SportTypeEntity { get; set; } = null!;
}

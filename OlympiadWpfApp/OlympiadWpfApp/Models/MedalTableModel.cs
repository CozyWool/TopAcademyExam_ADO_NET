namespace OlympiadWpfApp.Models;

public class MedalTableModel
{
    public string Country { get; init; } = null!;
    public int GoldMedals { get; init; }
    public int SilverMedals { get; init; }
    public int BronzeMedals { get; init; }
    public int TotalMedals => GoldMedals + SilverMedals + BronzeMedals;
}
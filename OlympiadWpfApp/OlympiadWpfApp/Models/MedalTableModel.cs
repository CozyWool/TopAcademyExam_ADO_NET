namespace OlympiadWpfApp.Models;

public class MedalTableModel
{
    public string Country { get; set; }
    public int GoldMedals { get; set; }
    public int SilverMedals { get; set; }
    public int BronzeMedals { get; set; }
    public int TotalMedals => GoldMedals + SilverMedals + BronzeMedals;
}
using System.Globalization;
using System.Windows.Data;

namespace OlympiadWpfApp.Converters;

public class SeasonConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool b)
        {
            switch (CultureInfo.CurrentUICulture.Name)
            {
                case "ru-RU":
                    return b ? "Зимняя" : "Летняя";
                case "en-GB": // локализацию не сделал, а тут кейс сделал, мда (T_T)
                    return b ? "Winter" : "Summer";
            }
        }

        throw new ArgumentException("Wrong data type");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string s)
        {
            switch (CultureInfo.CurrentUICulture.Name)
            {
                case "ru-RU":
                    return s == "Зимняя";
                case "en-GB": // локализацию не сделал, а тут кейс сделал, мда (T_T)
                    return s == "Winter";
            }
        }

        throw new ArgumentException("Wrong data type");
    }
}
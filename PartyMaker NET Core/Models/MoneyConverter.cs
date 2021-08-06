using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PartyMaker_NET_Core.Models
{
    [ValueConversion(typeof(double), typeof(string))]
    public class MoneyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            // Возвращаем строку в формате 123.456.789,01 ₽
            //return ((double)value).ToString("#,###.##", culture) + " ₽";
            if (value == null)
                return " ₽";
            string val = value.ToString();
            return string.Format(val, "#,###.##", culture) + " ₽";
            //return ((double)value).ToString("#,###.##", culture) + " ₽";
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            double result;
            if (Double.TryParse(value.ToString(), System.Globalization.NumberStyles.Any,
                         culture, out result))
            {
                return result;
            }
            else if (Double.TryParse(value.ToString().Replace(" ₽", ""), System.Globalization.NumberStyles.Any,
                         culture, out result))
            {
                return result;
            }
            return value;
        }
    }
}

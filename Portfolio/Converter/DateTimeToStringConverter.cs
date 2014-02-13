using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Portfolio.Converter
{
    class DateTimeToStringConverter : IValueConverter
    {
        // date to string
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var dt = (DateTime)value;
            var info = CultureInfo.CurrentCulture;
            return String.Format(info, "{0:d}", dt);
        }

        // string to date
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var info = CultureInfo.CurrentCulture;
            DateTime dt;
            return DateTime.TryParse((string)value, info, DateTimeStyles.None, out dt) ? dt : DateTime.Now;
        }
    }
}

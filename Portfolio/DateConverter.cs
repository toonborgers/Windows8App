using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace Portfolio
{
    internal class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var dates = (IEnumerable<DateTime>) value;
            CultureInfo info = CultureInfo.CurrentCulture;
            return dates.Select(date => String.Format(info, "{0:d}", date)).ToList();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            CultureInfo info = CultureInfo.CurrentCulture;
            DateTime dt;
            return DateTime.TryParse((string) value, info, DateTimeStyles.None, out dt) ? dt : DateTime.Now;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Portfolio.Converter
{
    class DateTimeToTextRepresentationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            var date = (DateTime) value;
            var info = CultureInfo.CurrentCulture;
            return String.Format(info, "{0:MMMM yyyy}", date);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace PL.Converters
{
    public class StringJoinConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Join("Recommended for you to see: ", value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
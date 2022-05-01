using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DataProtocol;

namespace PL.Converters
{
    public class FloorTagsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<ImaggaTagForImage> categories = value as List<ImaggaTagForImage>;
            if (categories != null && categories.Count > 0)
            {
                var percentage = (double)categories[0].Confidence;
                return Math.Floor(percentage / 20)+1;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

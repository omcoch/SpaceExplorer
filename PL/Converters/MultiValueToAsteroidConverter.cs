using System;
using System.Globalization;
using System.Windows.Data;

namespace PL.Converters
{
    public class MultiValueToAsteroidConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new DataProtocol.Asteroid
            {
                DiameterInKm = double.TryParse(values[1].ToString(), out double d) ? d : 0.0,
                IsDangerous = (bool)values[1],
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

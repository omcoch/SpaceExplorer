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
                Name = values[0] as string,
                DiameterInKm = values[1].ToString() != "" ? double.Parse(values[1].ToString()) : 0.0,
                IsDangerous = (bool)values[2],
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

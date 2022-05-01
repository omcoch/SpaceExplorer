using System.Globalization;
using System.Windows.Controls;

namespace PL.Validations
{
    public class IsDoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return !double.TryParse(value.ToString(), out double d)
                ? new ValidationResult(false, "Field must be double.")
                : ValidationResult.ValidResult;
        }
    }
}
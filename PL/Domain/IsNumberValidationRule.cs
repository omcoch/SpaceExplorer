using System.Globalization;
using System.Windows.Controls;

namespace PL.Domain
{
    public class IsNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double result;
            return !double.TryParse((value ?? "").ToString(), out result)
                ? new ValidationResult(false, "Field must be double.")
                : ValidationResult.ValidResult;
        }
    }
}
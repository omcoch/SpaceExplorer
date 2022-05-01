using System;
using System.Globalization;
using System.Windows.Controls;

namespace PL.Validations
{
    public class DatesValidationRule : ValidationRule
    {
        public DateTime StartDateValue { get; set; }
        public DateTime EndDateValue { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            TimeSpan time = EndDateValue - StartDateValue;

            return EndDateValue > StartDateValue && time.TotalDays > 7
                ? new ValidationResult(false, "Distance of 7 days maximum")
                : ValidationResult.ValidResult;
        }
    }
}
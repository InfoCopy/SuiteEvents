using System;
using System.Globalization;
using System.Windows.Data;

namespace SuiteEvents.Common.Resources.Converters
{
    public class PercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value) *
                   System.Convert.ToDouble(parameter.ToString().Replace(".", ","));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

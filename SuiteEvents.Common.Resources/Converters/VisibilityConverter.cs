using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SuiteEvents.Common.Resources.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result;

            if (value == null)
            {
                result = false;
            }
            else if (value is int)
            {
                result = int.Parse(value.ToString()) > 0;
            }
            else if (value is string)
            {
                result = !string.IsNullOrEmpty(value.ToString()) && !value.ToString().Equals("0");
            }
            else
            {
                result = true;
            }

            return result ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibile = (Visibility)value == Visibility.Visible;

            if (targetType == typeof(string))
            {
                return visibile.ToString();
            }

            if (targetType == typeof(int))
            {
                return visibile ? 1 : 0;
            }
            
            return visibile;
        }
    }
}

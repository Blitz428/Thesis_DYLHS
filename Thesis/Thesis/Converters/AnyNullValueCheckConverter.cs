using System;
using System.Globalization;
using Xamarin.Forms;

namespace Thesis.Converters
{
    public class AnyNullValueCheckConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
            {
                return false;
            }

            foreach (var value in values)
            {
                if (value is string str && string.IsNullOrEmpty(str))
                {
                    return false;
                }
            }
            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

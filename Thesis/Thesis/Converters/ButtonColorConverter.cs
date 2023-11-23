using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Thesis.Converters
{
    public class ButtonColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
            {
                return Color.LightGray;
            }

            foreach (var value in values)
            {
                if (value is string str && string.IsNullOrEmpty(str))
                {
                    return Color.LightGray;
                }
            }
            return Color.FromHex("#2196F3");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

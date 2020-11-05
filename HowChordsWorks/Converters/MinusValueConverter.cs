using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace HowChordsWorks.Converters
{
    public class MinusValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            dynamic dValue = value;

            return -dValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            dynamic dValue = value;

            return -dValue;
        }

        public object ProvideValue()
        {
            return this;
        }
    }
}

using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace HowChordsWorks.Converters
{
    public class ChainingConverter : IValueConverter
    {
        public IValueConverter Converter1 { get; set; }
        public IValueConverter Converter2 { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Converter2.Convert(Converter1.Convert(value, targetType, parameter, culture), targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Converter1.ConvertBack(Converter2.ConvertBack(value, targetType, parameter, culture), targetType, parameter, culture);
        }

        public object ProvideValue()
        {
            return this;
        }
    }
}

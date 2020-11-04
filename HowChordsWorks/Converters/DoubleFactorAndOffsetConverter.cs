using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using System;
using System.Globalization;

namespace HowChordsWorks.Converters
{
    public class DoubleFactorAndOffsetConverter : MarkupExtension, IValueConverter
    {
        public double Offset { get; set; }

        public double Factor { get; set; } = 1;

        public double Divider { get; set; } = 1;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value * Factor / Divider + Offset;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value - Offset) / Offset * Divider;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}

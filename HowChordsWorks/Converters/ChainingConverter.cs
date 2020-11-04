using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using System;
using System.Globalization;

namespace HowChordsWorks.Converters
{
    public class ChainingConverter : MarkupExtension, IValueConverter
    {
        public IValueConverter Converter1 { get; set; }
        public IValueConverter Converter2 { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Converter2.Convert(Converter1.Convert(value, targetType, parameter, culture), targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}

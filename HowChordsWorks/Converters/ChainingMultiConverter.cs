using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace HowChordsWorks.Converters
{
    public class ChainingMultiConverter : IMultiValueConverter
    {
        public IMultiValueConverter Converter1 { get; set; }
        public IValueConverter Converter2 { get; set; }

        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            return Converter2.Convert(Converter1.Convert(values, targetType, parameter, culture), targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        public object ProvideValue()
        {
            return this;
        }
    }
}

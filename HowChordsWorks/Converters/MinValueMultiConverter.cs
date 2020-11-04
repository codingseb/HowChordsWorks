using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HowChordsWorks.Converters
{
    public class MinValueMultiConverter : MarkupExtension, IMultiValueConverter
    {   
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Select(o => (double)o).Min();
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

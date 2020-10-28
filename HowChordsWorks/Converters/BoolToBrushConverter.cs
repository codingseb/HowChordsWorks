using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace HowChordsWorks.Converters
{
    /// <summary>
    /// -- Describe here to what is this class used for. (What is it's purpose) --
    /// </summary>
    public class BoolToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool bValue && bValue ? Brushes.White : Brushes.AliceBlue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

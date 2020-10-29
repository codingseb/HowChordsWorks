using Avalonia.Data.Converters;
using Avalonia.Media;
using HowChordsWorks.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace HowChordsWorks.Converters
{
    /// <summary>
    /// -- Describe here to what is this class used for. (What is it's purpose) --
    /// </summary>
    public class FifthChordsFillColorConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                HSL hSL = new HSL((int)values[0] * 30, 1f, (bool)values[1] ? 0.8f : 0.5f);
                RGB rGB = hSL.ToRGB();

                return new SolidColorBrush(new Color(255, rGB.R, rGB.G, rGB.B));
            }
            catch
            {
                return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}

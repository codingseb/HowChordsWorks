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
    public class FifthChordsFillColorMultiConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int hue = ((int)values[0] * 30) + (int)values[2];
                if(hue < 0)
                {
                    hue += (Math.Abs(hue) / 360 + 1) * 360;
                }
                HSL hSL = new HSL(hue % 360, 1f, (bool)values[1] ? 0.8f : 0.5f);
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

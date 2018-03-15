using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UIKit;

namespace NMCT.Resto.IOS.Converters
{
    public class ScoreToColorConverter : MvxValueConverter<double, UIColor>
    {
        protected override UIColor Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetColor(value);
        }
        private UIColor GetColor(double value)
        {
            if (double.IsNaN(value)) return UIColor.White;
            if (value < 2.5)
            {
                return UIColor.Red;
            }
            else
            {
                return UIColor.Green;
            }
        }
    }
}

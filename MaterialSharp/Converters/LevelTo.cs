using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MaterialSharp.Converters
{
    public class LevelToMargin : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return new Thickness((int) value * 20.0, 0, 0, 0);
            return new Thickness(0, 0, 0, 0);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { throw new NotSupportedException(); }
    }
}

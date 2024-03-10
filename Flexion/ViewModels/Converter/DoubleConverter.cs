using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Flexion.ViewModels.Converter;

public class DoubleConverter:IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not double doubleValue) return "0 mm";
        if (doubleValue == 0) { return "0 mm"; }
        return doubleValue > 0.001 ? $"{doubleValue:F3} mm" : $"{(doubleValue * 1000):F3} μm";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
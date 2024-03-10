using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Flexion.ViewModels.Converter;

public class DoubleConverter:IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is not double doubleValue ? "0 mm" : $"{doubleValue:F3} mm";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace BendingCalculator.ViewModels.Converter;

public class DoubleConverterMegaPascal:IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is not double doubleValue ? "0 MPa" : $"{doubleValue:F3} MPa";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
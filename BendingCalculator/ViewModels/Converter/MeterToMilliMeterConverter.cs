using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace BendingCalculator.ViewModels.Converter;

public class MeterToMilliMeterConverter:IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        
        return (double)value * 1000;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return System.Convert.ToDouble(value) / 1000;
    }
}
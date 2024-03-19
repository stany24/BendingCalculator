using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace BendingCalculator.ViewModels.Converter;

public class DoubleMeterToMilliMeter: IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double val)
        {
            return val * 1000;
        }

        return 0;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double val)
        {
            return val / 1000;
        }

        return 0;
    }
}
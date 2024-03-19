using Avalonia.Data.Converters;

namespace BendingCalculator.ViewModels.Converter;

public static class Converters
{
    public static FuncValueConverter<double?, string> DoubleMilliMeterWithUnits { get; } = 
        new(num => num is not null ? $"{num:F3} mm":"0 mm");
    
    public static FuncValueConverter<double?, string> DoubleMegaPascal { get; } = 
        new(num => num is not null ? $"{num/10000} GPa":"0 GPa");
    
    public static FuncValueConverter<double?, double> DoubleMeterToMilliMeter { get; } = 
        new(num =>
        {
            if (num is not null)
            {
                return (double)(num * 1000);
            }
            return 0;
        });
}
using Avalonia.Data.Converters;

namespace BendingCalculator.ViewModels.Converter;

public static class Converters
{
    public static FuncValueConverter<double?, string> DoubleMilliMeterWithUnits { get; } =
        new(num => num is not null ? $"{num:F3} mm" : "0 mm");

    public static FuncValueConverter<double?, string> DoubleMegaPascal { get; } =
        new(num => num is not null ? $"{num / 1000000:F3} MPa" : "0 MPa");
}
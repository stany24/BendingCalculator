using Avalonia.Data.Converters;
using Avalonia.Media;
using BendingCalculator.Assets.Localization.Static;
using BendingCalculator.Logic.Math;

namespace BendingCalculator.ViewModels.Converter;

public static class Converters
{
    public static FuncValueConverter<double?, string> DoubleMilliMeterWithUnits { get; } =
        new(num => num is not null ? $"{num:F3} mm" : "0 mm");

    public static FuncValueConverter<double?, string> DoubleMegaPascal { get; } =
        new(num => num is not null ? $"{num / 1000000:F3} MPa" : "0 MPa");

    public static FuncValueConverter<Color, IBrush> ColorToBrushConverter { get; } =
        new(GetColor);

    private static SolidColorBrush GetColor(Color color)
    {
        return new SolidColorBrush(color);
    }
    
    public static FuncValueConverter<Layer?, string> LayerToString { get; } = 
        new(layer => $"{layer.HeightOnSides * 1000}");

}
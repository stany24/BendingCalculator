using System.Collections.Generic;
using FlexionV2.Logic;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace FlexionV2.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ISeries[] Series { get; set; } =
    {
        new LineSeries<ObservablePoint>
        {
            Values = new List<ObservablePoint>
            {
                new(0, 4),
                new(1, 3),
                new(3, 8),
                new(18, 6),
                new(20, 12)
            }
        }
    };

    public List<Piece> Pieces { get; set; } = new();
    public List<Layer> Layers { get; set; } = new();
    public List<Material> Materials { get; set; } = new();
}
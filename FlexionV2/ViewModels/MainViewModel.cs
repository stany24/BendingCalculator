using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    private ObservableCollection<Piece> _pieces = new();
    public ObservableCollection<Piece> Pieces { 
        get => _pieces;
        set
        {
            _pieces = value;
            OnPropertyChanged();
        }
    }
    
    private ObservableCollection<Layer> _layers = new();
    public ObservableCollection<Layer> Layers { 
        get => _layers;
        set
        {
            _layers = value;
            OnPropertyChanged();
        }
    }
    
    private ObservableCollection<Material> _materials = new();
    public ObservableCollection<Material> Materials { 
        get => _materials;
        set
        {
            _materials = value;
            OnPropertyChanged();
        }
    }
}
using System.Collections.Generic;
using System.Data.SQLite;
using CommunityToolkit.Mvvm.ComponentModel;
using FlexionV2.Database.Actions;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace FlexionV2.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly SQLiteConnection _connection;

    public MainViewModel(SQLiteConnection connection)
    {
        _connection = connection;
        DataBaseEvents.LayersChanged += (_, _) => ReloadLayers();
        DataBaseEvents.MaterialsChanged += (_, _) => ReloadMaterials();
        DataBaseEvents.PiecesChanged += (_, _) => ReloadPieces();
        DataBaseEvents.LayerOfPieceChanged += (_, _) => LoadLayersOfPiece(_selectedPieceId);
        ReloadMaterials();
        ReloadLayers();
        ReloadPieces();
    }
    
    public ISeries[] SeriesGraphFlexion { get; set; } =
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
}
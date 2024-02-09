using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using FlexionV2.Database.Actions;
using FlexionV2.Views.Editors.Force;
using FlexionV2.Views.Editors.Layer;
using FlexionV2.Views.Editors.Material;
using FlexionV2.Views.Editors.Piece;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace FlexionV2.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly SQLiteConnection _connection;
    public decimal Force { get; set; } = 100;

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

    public void CloseAllWindow()
    {
        _materialEditor?.Close();
        _layerEditor?.Close();
        _pieceEditor?.Close();
        _forceEditor?.Close();
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
    
    public void CalculateFlexion()
    {
        Task.Run(() =>
        {
            if(SelectedPieces is { Count: 0 }){return;}
            if(SelectedPieces[0].Layers.Count == 0){return;}
            double gap = SelectedPieces[0].Length / 10000;
            IEnumerable<double> values = SelectedPieces[0].CalculateFlexion((int)Force,gap); //returns only NaN caused by CalculateI() in Piece class
            List<ObservablePoint> points = values.Select((t, i) => new ObservablePoint(i, t)).ToList();
            SeriesGraphFlexion[0].Values = points;
        });
    }
    
    private MaterialEditor? _materialEditor;
    public void OpenMaterialEditor()
    {
        if(_materialEditor != null){return;}
        _materialEditor = new MaterialEditor(this);
        _materialEditor.Closed += (_, _) => _materialEditor = null;
        _materialEditor.Show();
    }
    
    private LayerEditor? _layerEditor;
    public void OpenLayerEditor()
    {
        if(_layerEditor != null){return;}
        _layerEditor = new LayerEditor(this);
        _layerEditor.Closed += (_, _) => _layerEditor = null;
        _layerEditor.Show();
    }
    
    private PieceEditor? _pieceEditor;
    public void OpenPieceEditor()
    {
        if(_pieceEditor != null){return;}
        _pieceEditor = new PieceEditor(this);
        _pieceEditor.Closed += (_, _) => _pieceEditor = null;
        _pieceEditor.Show();
    }
    
    private ForceEditor? _forceEditor;
    public void OpenForceEditor()
    {
        if(_forceEditor != null){return;}
        _forceEditor = new ForceEditor();
        _forceEditor.Closing += (_, _) => Force = _forceEditor?.CalculateForce() ?? 100;
        _forceEditor.Closed += (_, _) => _forceEditor = null;
        _forceEditor.Show();
    }
}
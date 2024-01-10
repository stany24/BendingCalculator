using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using FlexionV2.Database.Actions;
using FlexionV2.Logic;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace FlexionV2.ViewModels;

public class MainViewModel : ViewModelBase
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

    public ObservableCollection<Layer> LayersOfSelectedPiece { get; set; } = new();

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

    private void ReloadMaterials()
    {
        Materials = new ObservableCollection<Material>(DataBaseLoader.LoadMaterials(_connection));
    }

    public void NewMaterial(Material material)
    {
        Materials.Add(DataBaseCreator.NewMaterial(_connection,material));
    }

    public void UpdateMaterials(List<Material> materials)
    {
        DataBaseUpdater.UpdateMaterials(_connection,materials);
    }

    public void RemoveMaterial(long id)
    {
        DataBaseRemover.RemoveMaterial(_connection,id);
    }

    private void ReloadLayers()
    {
        Layers = new ObservableCollection<Layer>(DataBaseLoader.LoadLayers(_connection));
    }
    
    public void NewLayer(Layer layer)
    {
        Layers.Add(DataBaseCreator.NewLayer(_connection,layer));
    }

    public void UpdateLayers(List<Layer> layers)
    {
        DataBaseUpdater.UpdateLayers(_connection,layers);
    }

    public void RemoveLayer(long id)
    {
        DataBaseRemover.RemoveLayer(_connection,id);
    }

    private void ReloadPieces()
    {
        Pieces = new ObservableCollection<Piece>(DataBaseLoader.LoadPieces(_connection));
    }
    
    public void NewPiece(Piece piece)
    {
        Pieces.Add(DataBaseCreator.NewPiece(_connection,piece));
    }

    public void UpdatePieces(List<Piece> piece)
    {
        DataBaseUpdater.UpdatePieces(_connection,piece);
    }

    public void RemovePiece(long id)
    {
        DataBaseRemover.RemovePiece(_connection,id);
    }

    private long _selectedPieceId;
    public void LoadLayersOfPiece(long? id)
    {
        LayersOfSelectedPiece.Clear();
        if(id is not { } id2){return;}
        _selectedPieceId = id2;
        foreach (Layer layer in DataBaseLoader.LoadLayersOfPiece(_connection,id2))
        {
            LayersOfSelectedPiece.Add(layer);
        }
    }

    public void UpdateLayersInPiece(long id,List<Layer> layers)
    {
        DataBaseUpdater.UpdateLayersInPiece(_connection,id,layers);
    }
}
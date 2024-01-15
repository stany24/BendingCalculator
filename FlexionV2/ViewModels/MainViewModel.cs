using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using CommunityToolkit.Mvvm.ComponentModel;
using FlexionV2.Database.Actions;
using FlexionV2.Logic;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace FlexionV2.ViewModels;

public class MainViewModel : ObservableObject
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

    private ObservableCollection<Piece> _pieces = new();
    public ObservableCollection<Piece> Pieces { 
        get => _pieces;
        set => SetProperty(ref _pieces, value);
    }
    
    private ObservableCollection<Layer> _layers = new();
    public ObservableCollection<Layer> Layers { 
        get => _layers;
        set => SetProperty(ref _layers, value);
    }
    
    private ObservableCollection<Material> _materials = new();
    public ObservableCollection<Material> Materials { 
        get => _materials;
        set => SetProperty(ref _materials, value);
    }

    private ObservableCollection<Layer> _layersOfSelectedPiece= new();

    public ObservableCollection<Layer> LayersOfSelectedPiece
    {
        get => _layersOfSelectedPiece;
        set => SetProperty(ref _layersOfSelectedPiece, value);
    }

    private void ReloadMaterials()
    {
        List<Material> materials = DataBaseLoader.LoadMaterials(_connection);
        while (materials.Count != Materials.Count)
        {
            if (materials.Count < Materials.Count)
            {
                Materials.RemoveAt(0);
            }
            else
            {
                Materials.Add(new Material());
            }
        }

        for (int i = 0; i < materials.Count; i++)
        {
            Materials[i].MaterialId = materials[i].MaterialId;
            Materials[i].Name = materials[i].Name;
            Materials[i].E = materials[i].E;
        }
    }

    public void NewMaterial(Material material)
    {
        DataBaseCreator.NewMaterial(_connection,material);
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
        List<Layer> layers = DataBaseLoader.LoadLayers(_connection);
        while (layers.Count != Layers.Count)
        {
            if (layers.Count < Layers.Count)
            {
                Layers.RemoveAt(0);
            }
            else
            {
                Layers.Add(new Layer());
            }
        }

        for (int i = 0; i < layers.Count; i++)
        {
            Layers[i].LayerId = layers[i].LayerId;
            Layers[i].Material = layers[i].Material;
            Layers[i].HeightAtCenter = layers[i].HeightAtCenter;
            Layers[i].HeightOnSides = layers[i].HeightOnSides;
            Layers[i].WidthAtCenter = layers[i].WidthAtCenter;
            Layers[i].WidthOnSides = layers[i].WidthOnSides;
        }
    }
    
    public void NewLayer(Layer layer)
    {
        DataBaseCreator.NewLayer(_connection,layer);
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
        List<Piece> pieces = DataBaseLoader.LoadPieces(_connection);
        while (pieces.Count != Pieces.Count)
        {
            if (pieces.Count < Pieces.Count)
            {
                Pieces.RemoveAt(0);
            }
            else
            {
                Pieces.Add(new Piece());
            }
        }

        for (int i = 0; i < pieces.Count; i++)
        {
            Pieces[i].Layers = pieces[i].Layers;
            Pieces[i].PieceId = pieces[i].PieceId;
            Pieces[i].Name = pieces[i].Name;
            Pieces[i].Length = pieces[i].Length;
        }
    }
    
    public void NewPiece(Piece piece)
    {
        DataBaseCreator.NewPiece(_connection,piece);
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
        if(id is not { } id2){return;}
        _selectedPieceId = id2;
        
        List<Layer> layers = DataBaseLoader.LoadLayersOfPiece(_connection,id2);
        while (layers.Count != LayersOfSelectedPiece.Count)
        {
            if (layers.Count < LayersOfSelectedPiece.Count)
            {
                LayersOfSelectedPiece.RemoveAt(0);
            }
            else
            {
                LayersOfSelectedPiece.Add(new Layer());
            }
        }

        for (int i = 0; i < layers.Count; i++)
        {
            LayersOfSelectedPiece[i].LayerId = layers[i].LayerId;
            LayersOfSelectedPiece[i].Material = layers[i].Material;
            LayersOfSelectedPiece[i].HeightAtCenter = layers[i].HeightAtCenter;
            LayersOfSelectedPiece[i].HeightOnSides = layers[i].HeightOnSides;
            LayersOfSelectedPiece[i].WidthAtCenter = layers[i].WidthAtCenter;
            LayersOfSelectedPiece[i].WidthOnSides = layers[i].WidthOnSides;
        }
    }

    public void UpdateLayersInPiece(long id,List<Layer> layers)
    {
        DataBaseUpdater.UpdateLayersInPiece(_connection,id,layers);
    }

    public void AddLayerToPiece(long id, Layer layer)
    {
        DataBaseUpdater.AddLayerToPiece(_connection,id,layer);
    }

    public void RemoveLayerToPiece(long id, long order)
    {
        DataBaseUpdater.RemoveLayerToPiece(_connection,id,order);
    }
}
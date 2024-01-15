using System.Collections.Generic;
using System.Collections.ObjectModel;
using FlexionV2.Database.Actions;
using FlexionV2.Logic;

namespace FlexionV2.ViewModels;

public partial class MainViewModel
{
    private long _selectedPieceId;
    
    private ObservableCollection<Layer> _layersOfSelectedPiece= new();

    public ObservableCollection<Layer> LayersOfSelectedPiece
    {
        get => _layersOfSelectedPiece;
        set => SetProperty(ref _layersOfSelectedPiece, value);
    }

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
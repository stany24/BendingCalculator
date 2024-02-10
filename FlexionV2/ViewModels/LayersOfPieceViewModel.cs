using System.Collections.Generic;
using System.Collections.ObjectModel;
using FlexionV2.Database.Actions;
using FlexionV2.Logic;

namespace FlexionV2.ViewModels;

public partial class MainViewModel
{
    private ObservableCollection<Layer> _layersOfSelectedPiece= new();
    public ObservableCollection<Layer> LayersOfSelectedPiece
    {
        get => _layersOfSelectedPiece;
        set => SetProperty(ref _layersOfSelectedPiece, value);
    }

    public ObservableCollection<Layer> SelectedLayersOfSelectedPiece { get; set; } = new();
    public ObservableCollection<Layer> SelectedAvailableLayers { get; set; } = new();

    private long _pieceCurrentlyModifiedId;
    public long PieceCurrentlyModifiedId { get => _pieceCurrentlyModifiedId;
        set
        {
            _pieceCurrentlyModifiedId = value;
            LoadLayersOfPiece(_pieceCurrentlyModifiedId);
        }
    }
    
    public bool BtnMoveUpEnabled { get; set; }
    public bool BtnMoveDownEnabled { get; set; }
    public bool BtnRemoveEnabled { get; set; }
    public bool BtnAddEnabled { get; set; }
    public int SelectedIndexOfLayerInPiece { get; set; }

    private void LoadLayersOfPiece(long id)
    {
        List<Layer> layers = DataBaseLoader.LoadLayersOfPiece(_connection,id);
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
    
    private void SelectedInPieceChanged()
    {
        BtnRemoveEnabled = SelectedLayersOfSelectedPiece.Count > 0;
        BtnMoveUpEnabled = SelectedLayersOfSelectedPiece.Count == 1;
        BtnMoveDownEnabled = SelectedLayersOfSelectedPiece.Count == 1;
    }

    private void SelectedAvailableChanged()
    {
        BtnAddEnabled = SelectedLayersOfSelectedPiece.Count == 1;
    }
    
    public void MoveLayerUpInPiece()
    {
        List<Layer> layers =  new(LayersOfSelectedPiece);
        int indexToMove = SelectedIndexOfLayerInPiece;
        if (indexToMove == 0) return;
        (layers[indexToMove], layers[indexToMove - 1]) = (layers[indexToMove - 1], layers[indexToMove]);
        DataBaseUpdater.UpdateLayersInPiece(_connection,_pieceCurrentlyModifiedId,layers);
        SelectedIndexOfLayerInPiece -= 1;
    }
    
    public void MoveLayerDownInPiece()
    {
        List<Layer> layers =  new(LayersOfSelectedPiece);
        int indexToMove = SelectedIndexOfLayerInPiece;
        if (indexToMove == LayersOfSelectedPiece.Count-1) return;
        (layers[indexToMove], layers[indexToMove + 1]) = (layers[indexToMove + 1], layers[indexToMove]);
        DataBaseUpdater.UpdateLayersInPiece(_connection,_pieceCurrentlyModifiedId,layers);
        SelectedIndexOfLayerInPiece += 1;
    }

    public void RemoveLayersToPiece()
    {
        for (int i = 0; i < SelectedLayersOfSelectedPiece.Count; i++)
        {
            DataBaseUpdater.RemoveLayerToPiece(_connection,_pieceCurrentlyModifiedId,i);
        }
    }

    public void AddLayerToPiece()
    {
        if (SelectedLayersOfSelectedPiece.Count > 0) {return; }
        DataBaseUpdater.AddLayerToPiece(_connection,_pieceCurrentlyModifiedId,SelectedLayersOfSelectedPiece[0]);
    }
}
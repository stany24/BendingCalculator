using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

    private bool _btnMoveUpEnabled;

    public bool BtnMoveUpEnabled
    {
        get => _btnMoveUpEnabled;
        set => SetProperty(ref _btnMoveUpEnabled, value);
    }
    
    private bool _btnMoveDownEnabled;

    public bool BtnMoveDownEnabled
    {
        get => _btnMoveDownEnabled;
        set => SetProperty(ref _btnMoveDownEnabled, value);
    }
    
    private bool _btnAddEnabled;

    public bool BtnAddEnabled
    {
        get => _btnAddEnabled;
        set => SetProperty(ref _btnAddEnabled, value);
    }
    
    private bool _btnRemoveEnabled;

    public bool BtnRemoveEnabled
    {
        get => _btnRemoveEnabled;
        set => SetProperty(ref _btnRemoveEnabled, value);
    }
    
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
        for (int i = 0; i < SelectedLayersOfSelectedPiece.Count; i++)
        {
            Layer selectedItem = SelectedLayersOfSelectedPiece[i];
            int index = LayersOfSelectedPiece.IndexOf(selectedItem);
            if (index <= 0) continue;
            LayersOfSelectedPiece.RemoveAt(index);
            LayersOfSelectedPiece.Insert(index - 1, selectedItem);
            SelectedLayersOfSelectedPiece.Add(selectedItem);
        }
    }
    
    public void MoveLayerDownInPiece()
    {
        for (int i = SelectedLayersOfSelectedPiece.Count - 1; i >= 0; i--)
        {
            Layer selectedItem = SelectedLayersOfSelectedPiece[i];
            int index = LayersOfSelectedPiece.IndexOf(selectedItem);
            if (index == LayersOfSelectedPiece.Count - 1) continue;
            LayersOfSelectedPiece.RemoveAt(index);
            LayersOfSelectedPiece.Insert(index + 1, selectedItem);
            SelectedLayersOfSelectedPiece.Add(selectedItem);
        }
    }
    
    public void RemoveLayersToPiece()
    {
        List<int> idToRemove = SelectedLayersOfSelectedPiece.Select(layer => LayersOfSelectedPiece.IndexOf(layer)).ToList();
        for (int i = idToRemove.Count-1; i >= 0 ; i--)
        {
            DataBaseUpdater.RemoveLayerToPiece(_connection,_pieceCurrentlyModifiedId,idToRemove[i]);
        }
    }

    public void AddLayerToPiece()
    {
        if (SelectedLayersOfSelectedPiece.Count > 0) {return; }
        DataBaseUpdater.AddLayerToPiece(_connection,_pieceCurrentlyModifiedId,SelectedLayersOfSelectedPiece[0]);
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    #region Bindings

    private ObservableCollection<Layer> _layersOfSelectedPiece= new();
    public ObservableCollection<Layer> LayersOfSelectedPiece
    {
        get => _layersOfSelectedPiece;
        set => SetProperty(ref _layersOfSelectedPiece, value);
    }
    public int SelectedIndexOfLayerInPiece { get; set; }

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

    #endregion
    

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

    #region Selection changed

    private void SelectedInPieceChanged()
    {
        BtnRemoveEnabled = BtnMoveUpEnabled = BtnMoveDownEnabled = SelectedLayersOfSelectedPiece.Count > 0;
    }

    private void SelectedAvailableChanged()
    {
        BtnAddEnabled = SelectedAvailableLayers.Count == 1;
    }

    #endregion
    
    #region Move Layer

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

    #endregion

    #region Add/Remove Layer

    public void AddLayerToPiece()
    {
        DataBaseUpdater.AddLayerToPiece(_connection,PieceCurrentlyModifiedId,SelectedAvailableLayers[0]);
    }

    public void RemoveLayersToPiece()
    {
        List<int> idToRemove = SelectedLayersOfSelectedPiece.Select(layer => LayersOfSelectedPiece.IndexOf(layer)).ToList();
        for (int i = idToRemove.Count-1; i >= 0 ; i--)
        {
            DataBaseUpdater.RemoveLayerToPiece(_connection,PieceCurrentlyModifiedId,idToRemove[i]);
        }
    }
    
    #endregion
}
using System;
using System.Collections.ObjectModel;
using System.Linq;
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    private void LoadLayersOfPiece(long id)
    {
        if (SelectedPiece == null) return;
        ObservableCollection<Layer> layers = DataBaseLoader.LoadLayersOfPiece(_connection, id);
        while (layers.Count != SelectedPiece.Layers.Count)
            if (layers.Count < SelectedPiece.Layers.Count)
                SelectedPiece.Layers.RemoveAt(0);
            else
                SelectedPiece.Layers.Add(new Layer());

        for (int i = 0; i < layers.Count; i++)
        {
            SelectedPiece.Layers[i].Id = layers[i].Id;
            SelectedPiece.Layers[i].Material = layers[i].Material;
            SelectedPiece.Layers[i].HeightAtCenter = layers[i].HeightAtCenter;
            SelectedPiece.Layers[i].HeightOnSides = layers[i].HeightOnSides;
            SelectedPiece.Layers[i].WidthAtCenter = layers[i].WidthAtCenter;
            SelectedPiece.Layers[i].WidthOnSides = layers[i].WidthOnSides;
        }
    }

    #region Bindings

    public ObservableCollection<Layer> SelectedLayersOfSelectedPiece { get; set; } = new();
    
    private ObservableCollection<Layer> _layersOfSelectedPiece = new();

    public ObservableCollection<Layer> LayersOfSelectedPiece
    {
        get => _layersOfSelectedPiece;
        set => SetProperty(ref _layersOfSelectedPiece, value);
    }
    
    public ObservableCollection<Layer> SelectedAvailableLayers { get; set; } = new();

    private long _pieceCurrentlyModifiedId;

    public long PieceCurrentlyModifiedId
    {
        get => _pieceCurrentlyModifiedId;
        set
        {
            _pieceCurrentlyModifiedId = value;
            LoadLayersOfPiece(_pieceCurrentlyModifiedId);
        }
    }

    [ObservableProperty] private bool _btnMoveUpEnabled;

    [ObservableProperty] private bool _btnMoveDownEnabled;

    [ObservableProperty] private bool _btnAddEnabled;

    [ObservableProperty] private bool _btnRemoveEnabled;

    #endregion

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
        if (SelectedPiece == null) return;
        for (int i = 0; i < SelectedLayersOfSelectedPiece.Count; i++)
        {
            Layer selectedItem = SelectedLayersOfSelectedPiece[i];
            int index = SelectedPiece.Layers.IndexOf(selectedItem);
            if (index <= 0) continue;
            SelectedPiece.Layers.RemoveAt(index);
            SelectedPiece.Layers.Insert(index - 1, selectedItem);
            SelectedLayersOfSelectedPiece.Add(selectedItem);
        }
        DataBaseUpdater.MoveLayerInPiece(_connection, SelectedPiece);
        LayersOfSelectedPiece = SelectedPiece.Layers;
    }

    public void MoveLayerDownInPiece()
    {
        if (SelectedPiece == null) return;
        for (int i = SelectedLayersOfSelectedPiece.Count - 1; i >= 0; i--)
        {
            Layer selectedItem = SelectedLayersOfSelectedPiece[i];
            int index = SelectedPiece.Layers.IndexOf(selectedItem);
            if (index == SelectedPiece.Layers.Count - 1) continue;
            SelectedPiece.Layers.RemoveAt(index);
            SelectedPiece.Layers.Insert(index + 1, selectedItem);
            SelectedLayersOfSelectedPiece.Add(selectedItem);
        }
        DataBaseUpdater.MoveLayerInPiece(_connection, SelectedPiece);
        LayersOfSelectedPiece = SelectedPiece.Layers;
    }

    #endregion

    #region Add/Remove Layer

    public void AddLayerToPiece()
    {
        DataBaseUpdater.AddLayerToPiece(_connection, PieceCurrentlyModifiedId, SelectedAvailableLayers[0]);
        LayersOfSelectedPiece = SelectedPiece.Layers;
    }

    public void RemoveLayersToPiece()
    {
        if (SelectedPiece == null) return;
        int[] idToRemove = SelectedLayersOfSelectedPiece.Select(layer => SelectedPiece.Layers.IndexOf(layer)).ToArray();
        int nbLayer = SelectedPiece.Layers.Count;
        for (int i = idToRemove.Length - 1; i >= 0; i--)
        {
            DataBaseUpdater.RemoveLayerToPiece(_connection, SelectedPiece.Id, nbLayer, idToRemove[i]);
            nbLayer--;
        }
        LayersOfSelectedPiece = SelectedPiece.Layers;
    }

    #endregion
}
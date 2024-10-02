using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData;

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
    
    private ObservableCollection<Layer> _selectedLayersOfSelectedPiece = new();

    public ObservableCollection<Layer> SelectedLayersOfSelectedPiece
    {
        get => _selectedLayersOfSelectedPiece;
        set => SetProperty(ref _selectedLayersOfSelectedPiece, value);
    }
    
    
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
        List<int> idsToReselect = new();
        List<int> idsToMove = new();
        
        // Find all ids of the layers we need to move
        for (int i = SelectedLayersOfSelectedPiece.Count - 1; i >= 0; i--)
        {
            Layer selectedItem = SelectedLayersOfSelectedPiece[i];
            int index = SelectedPiece.Layers.IndexOf(selectedItem);
            if (index-1 < 0 ) continue;
            idsToMove.Add(index);
        }
        
        // Sort the ids and move the layers
        idsToMove.Sort();
        foreach (int index in idsToMove)
        {
            SelectedPiece.Layers.Move(index,index-1);
            idsToReselect.Add(index-1);
        }
        
        DataBaseUpdater.MoveLayerInPiece(_connection, SelectedPiece);
        
        // Reselect the layers
        LayersOfSelectedPiece = SelectedPiece.Layers;
        foreach (int id in idsToReselect)
        {
            SelectedLayersOfSelectedPiece.Add(LayersOfSelectedPiece[id]);
        }
    }

    public void MoveLayerDownInPiece()
    {
        if (SelectedPiece == null) return;
        List<int> idsToReselect = new();
        List<int> idsToMove = new();
        
        // Find all ids of the layers we need to move
        for (int i = SelectedLayersOfSelectedPiece.Count - 1; i >= 0; i--)
        {
            Layer selectedItem = SelectedLayersOfSelectedPiece[i];
            int index = SelectedPiece.Layers.IndexOf(selectedItem);
            if (index == SelectedPiece.Layers.Count - 1) continue;
            idsToMove.Add(index);
        }

        // Sort the ids and move the layers
        idsToMove = idsToMove.OrderByDescending(c => c).ToList();
        foreach (int index in idsToMove)
        {
            SelectedPiece.Layers.Move(index,index+1);
            idsToReselect.Add(index+1);
        }
        
        // Reselect the layers
        DataBaseUpdater.MoveLayerInPiece(_connection, SelectedPiece);
        LayersOfSelectedPiece = SelectedPiece.Layers;
        foreach (int id in idsToReselect)
        {
            SelectedLayersOfSelectedPiece.Add(LayersOfSelectedPiece[id]);
        }
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
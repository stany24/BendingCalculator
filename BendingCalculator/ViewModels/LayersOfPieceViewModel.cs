using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    #region Bindings

    private ObservableCollection<Layer> _selectedLayersOfSelectedPiece = new();

    public ObservableCollection<Layer> SelectedLayersOfSelectedPiece
    {
        get => _selectedLayersOfSelectedPiece;
        set => SetProperty(ref _selectedLayersOfSelectedPiece, value);
    }

    public ObservableCollection<Layer> SelectedAvailableLayers { get; set; } = new();
    

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
        
        //select the layers ids to move
        List<int> idsToMove = SelectedLayersOfSelectedPiece.Select(layer => SelectedPiece.Layers.IndexOf(layer)).ToList();
        idsToMove.Sort();

        // remove from the list the layers that are already at the top
        List<int> idsToSelect = new();
        if (idsToMove.First() - 1 < 0)
        {
            int id = idsToMove.First();
            idsToSelect.Add(id);
            idsToMove.RemoveAt(0);
            while (idsToMove.Count > 0 && idsToMove.First()-1 == id)
            {
                id = idsToMove.First();
                idsToSelect.Add(id);
                idsToMove.RemoveAt(0);
            }
        }
        
        // Move the layers
        foreach (int index in idsToMove)
        {
            SelectedPiece.Layers.Move(index, index - 1);
        }

        // Save to the database
        DataBaseUpdater.MoveLayerInPiece(_connection, SelectedPiece);
        SelectedLayersOfSelectedPiece.Clear();
        foreach (int index in idsToMove) { SelectedLayersOfSelectedPiece.Add(SelectedPiece.Layers[index-1]); }
        foreach (int index in idsToSelect) { SelectedLayersOfSelectedPiece.Add(SelectedPiece.Layers[index]); }
    }

    public void MoveLayerDownInPiece()
    {
        if (SelectedPiece == null) return;
        
        //select the layers ids to move
        List<int> idsToMove = SelectedLayersOfSelectedPiece.Select(layer => SelectedPiece.Layers.IndexOf(layer)).ToList();
        idsToMove = idsToMove.OrderByDescending(c => c).ToList();

        // remove from the list the layers that are already at the bottom
        List<int> idsToSelect = new();
        if (idsToMove.First() + 1 >= SelectedPiece.Layers.Count)
        {
            int id = idsToMove.First();
            idsToSelect.Add(id);
            idsToMove.RemoveAt(0);
            while (idsToMove.Count > 0 &&idsToMove.First()+1 == id)
            {
                id = idsToMove.First();
                idsToSelect.Add(id);
                idsToMove.RemoveAt(0);
            }
        }
        
        // Move the layers
        foreach (int index in idsToMove)
        {
            SelectedPiece.Layers.Move(index, index + 1);
        }

        // Save to the database
        DataBaseUpdater.MoveLayerInPiece(_connection, SelectedPiece);
        SelectedLayersOfSelectedPiece.Clear();
        foreach (int index in idsToMove) { SelectedLayersOfSelectedPiece.Add(SelectedPiece.Layers[index+1]); }
        foreach (int index in idsToSelect) { SelectedLayersOfSelectedPiece.Add(SelectedPiece.Layers[index]); }
    }

    #endregion

    #region Add/Remove Layer

    public void AddLayerToPiece()
    {
        if (SelectedPiece == null) return;
        DataBaseUpdater.AddLayerToPiece(_connection, SelectedPiece.Id, SelectedAvailableLayers[0]);
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
    }

    #endregion
}
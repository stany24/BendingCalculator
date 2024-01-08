using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Avalonia.Controls;
using FlexionV2.Database.Actions;

namespace FlexionV2.Views.Editors.Piece;

public partial class ListLayersEditor : Window
{
    private readonly SQLiteConnection _connection;
    private readonly long _pieceId;
    public ListLayersEditor(SQLiteConnection connection, long pieceId)
    {
        _connection = connection;
        _pieceId = pieceId;
        InitializeComponent();
        LbxAvailable.SelectionChanged += (_, _) => { if (LbxAvailable.SelectedItems != null) BtnAdd.IsEnabled = LbxAvailable.SelectedItems.Count == 1; };
        LbxInPiece.SelectionChanged += (_, _) => SelectedLayerChanged();
        BtnAdd.Click += (_, _) =>
        {
            LbxInPiece.Items.Add(LbxAvailable.SelectedItems?[0]);
            UpdateListBox();
        };
        BtnRemove.Click += (_, _) =>
        {
            LbxInPiece.Items.Remove(LbxInPiece.SelectedItems?[0]);
            UpdateListBox();
        };
        BtnMoveUp.Click += (_, _) =>MoveUp();
        BtnMoveDown.Click += (_, _) =>MoveDown();
        UpdateAvailableLayers();
        DataBaseEvents.LayersChanged += (_,_) => UpdateAvailableLayers();
        foreach (Logic.Layer layer in DataBaseLoader.LoadLayersOfPiece(_connection, _pieceId))
        {
            LbxInPiece.Items.Add(layer);
        }
    }
    
    private void UpdateListBox()
    {
        List<Logic.Layer> selected = new();
        List<Logic.Layer> items = LbxInPiece.Items.Cast<Logic.Layer>().ToList();
        if (LbxInPiece.SelectedItems != null) { selected = LbxInPiece.SelectedItems.Cast<Logic.Layer>().ToList(); }
        DataBaseUpdater.UpdateLayersInPiece(_connection,_pieceId,items);
        LbxInPiece.Items.Clear();
        foreach (Logic.Layer item in items) LbxInPiece.Items.Add(item);
        LbxInPiece.SelectedItems = new List<Logic.Layer>();
        foreach (Logic.Layer item in selected) LbxInPiece.SelectedItems.Add(item);
    }

    private void UpdateAvailableLayers()
    {
        LbxAvailable.Items.Clear();
        foreach (Logic.Layer layer in DataBaseLoader.LoadLayers(_connection))
        {
            LbxAvailable.Items.Add(layer);
        }
    }

    private void SelectedLayerChanged()
    {
        if (LbxInPiece.SelectedItems == null){return;}
        BtnRemove.IsEnabled = LbxInPiece.SelectedItems.Count == 1;
        BtnMoveUp.IsEnabled = LbxInPiece.SelectedItems.Count == 1;
        BtnMoveDown.IsEnabled = LbxInPiece.SelectedItems.Count == 1;
    }
    
    private void MoveUp()
    {
        int indexToMove = LbxInPiece.SelectedIndex;
        if (indexToMove == 0) return;
        if(LbxInPiece.Items[indexToMove] is not Logic.Layer layer){return;}
        LbxInPiece.Items[indexToMove] = LbxInPiece.Items[indexToMove - 1];
        LbxInPiece.Items[indexToMove - 1] = layer;
        UpdateListBox();
    }
    
    private void MoveDown()
    {
        int indexToMove = LbxInPiece.SelectedIndex;
        if (indexToMove == LbxInPiece.Items.Count-1) return;
        if(LbxInPiece.Items[indexToMove] is not Logic.Layer layer){return;}
        LbxInPiece.Items[indexToMove] = LbxInPiece.Items[indexToMove + 1];
        LbxInPiece.Items[indexToMove + 1] = layer;
        UpdateListBox();
    }
}
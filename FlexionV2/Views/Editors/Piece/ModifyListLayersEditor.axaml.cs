using System.Collections.Generic;
using Avalonia.Controls;

namespace FlexionV2.Views.Editors.Piece;

public partial class ListLayersEditor : Window
{
    public ListLayersEditor(List<Logic.Layer> layersInPiece,List<Logic.Layer> layersAvailable)
    {
        InitializeComponent();
        foreach (Logic.Layer layer in layersInPiece) { LbxInPiece.Items.Add(layer); }
        foreach (Logic.Layer layer in layersAvailable) {LbxAvailable.Items.Add(layer); }

        LbxAvailable.SelectionChanged += (_, _) => { if (LbxAvailable.SelectedItems != null) BtnAdd.IsEnabled = LbxAvailable.SelectedItems.Count == 1; };
        LbxInPiece.SelectionChanged += (_, _) => SelectedLayerChanged();
        BtnAdd.Click += (_, _) => LbxInPiece.Items.Add(LbxAvailable.SelectedItems?[0]);
        BtnRemove.Click += (_, _) => LbxInPiece.Items.Remove(LbxInPiece.SelectedItems?[0]);
        BtnMoveUp.Click += (_, _) =>MoveUp();
        BtnMoveDown.Click += (_, _) =>MoveDown();
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
        Logic.Layer layer = LbxInPiece.Items[indexToMove] as Logic.Layer;
        LbxInPiece.Items[indexToMove] = LbxInPiece.Items[indexToMove - 1];
        LbxInPiece.Items[indexToMove - 1] = layer;
    }
    
    private void MoveDown()
    {
        int indexToMove = LbxInPiece.SelectedIndex;
        if (indexToMove == LbxInPiece.Items.Count-1) return;
        Logic.Layer layer = LbxInPiece.Items[indexToMove] as Logic.Layer;
        LbxInPiece.Items[indexToMove] = LbxInPiece.Items[indexToMove + 1];
        LbxInPiece.Items[indexToMove + 1] = layer;
    }
    
    public void UpdateAvailableLayers(List<Logic.Layer> layers)
    {
        LbxAvailable.Items.Clear();
        foreach (Logic.Layer layer in layers) {LbxAvailable.Items.Add(layer); }
    }
}
using System.Data.SQLite;
using Avalonia.Controls;
using FlexionV2.Logic.Database;

namespace FlexionV2.Views.Editors.Piece;

public partial class ListLayersEditor : Window
{
    private readonly SQLiteConnection _connection;
    public ListLayersEditor(SQLiteConnection connection, long pieceId)
    {
        _connection = connection;
        InitializeComponent();
        LbxAvailable.SelectionChanged += (_, _) => { if (LbxAvailable.SelectedItems != null) BtnAdd.IsEnabled = LbxAvailable.SelectedItems.Count == 1; };
        LbxInPiece.SelectionChanged += (_, _) => SelectedLayerChanged();
        BtnAdd.Click += (_, _) => LbxInPiece.Items.Add(LbxAvailable.SelectedItems?[0]);
        BtnRemove.Click += (_, _) => LbxInPiece.Items.Remove(LbxInPiece.SelectedItems?[0]);
        BtnMoveUp.Click += (_, _) =>MoveUp();
        BtnMoveDown.Click += (_, _) =>MoveDown();
        UpdateLayers();
        foreach (Logic.Layer layer in DataBaseLoader.LoadLayersOfPiece(_connection, pieceId))
        {
            LbxInPiece.Items.Add(layer);
        }
    }

    public void UpdateLayers()
    {
        LbxAvailable.Items.Clear();
        foreach (Logic.Layer layer in DataBaseLoader.LoadLayersFromDatabase(_connection))
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
    }
    
    private void MoveDown()
    {
        int indexToMove = LbxInPiece.SelectedIndex;
        if (indexToMove == LbxInPiece.Items.Count-1) return;
        if(LbxInPiece.Items[indexToMove] is not Logic.Layer layer){return;}
        LbxInPiece.Items[indexToMove] = LbxInPiece.Items[indexToMove + 1];
        LbxInPiece.Items[indexToMove + 1] = layer;
    }
}
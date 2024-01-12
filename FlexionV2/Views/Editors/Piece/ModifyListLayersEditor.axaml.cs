using Avalonia.Controls;
using FlexionV2.ViewModels;

namespace FlexionV2.Views.Editors.Piece;

public partial class ListLayersEditor : Window
{
    private readonly long _pieceId;
    public ListLayersEditor(MainViewModel model, long pieceId)
    {
        DataContext = model;
        _pieceId = pieceId;
        if(DataContext is not MainViewModel model2){return;}
        InitializeComponent();
        LbxAvailable.SelectionChanged += (_, _) => { if (LbxAvailable.SelectedItems != null) BtnAdd.IsEnabled = LbxAvailable.SelectedItems.Count == 1; };
        LbxInPiece.SelectionChanged += (_, _) => SelectedInPieceChanged();
        LbxAvailable.SelectionChanged += (_, _) =>SelectedAvailableChanged();
        BtnAdd.Click += (_, _) => Add();
        BtnRemove.Click += (_, _) => Remove();
        BtnMoveUp.Click += (_, _) =>MoveUp();
        BtnMoveDown.Click += (_, _) =>MoveDown();
        
        model2.LoadLayersOfPiece(_pieceId);
    }

    private void SelectedInPieceChanged()
    {
        if (LbxInPiece.SelectedItems == null){return;}
        BtnRemove.IsEnabled = LbxInPiece.SelectedItems.Count > 0;
        BtnMoveUp.IsEnabled = LbxInPiece.SelectedItems.Count == 1;
        BtnMoveDown.IsEnabled = LbxInPiece.SelectedItems.Count == 1;
    }

    private void SelectedAvailableChanged()
    {
        if(LbxAvailable.SelectedItems == null){return;}
        BtnAdd.IsEnabled = LbxAvailable.SelectedItems.Count == 1;
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

    private void Remove()
    {
        if (LbxInPiece.SelectedItems is null) { return; }
        if(DataContext is not MainViewModel model){return;}
        for (int i = 0; i < LbxInPiece.SelectedItems.Count; i++)
        {
            model.RemoveLayerToPiece(_pieceId,i);
        }
    }

    private void Add()
    {
        if(DataContext is not MainViewModel model){return;}
        if(LbxAvailable.SelectedItems?[0] is not Logic.Layer layer){return;}
        model.AddLayerToPiece(_pieceId,layer);
    }
}
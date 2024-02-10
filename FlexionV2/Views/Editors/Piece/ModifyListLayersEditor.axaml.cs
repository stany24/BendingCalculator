using Avalonia.Controls;
using FlexionV2.ViewModels;

namespace FlexionV2.Views.Editors.Piece;

public partial class ListLayersEditor : Window
{
    public ListLayersEditor(MainViewModel model, long pieceCurrentlyModifiedId)
    {
        InitializeComponent();
        DataContext = model;
        model.PieceCurrentlyModifiedId = pieceCurrentlyModifiedId;
    }
}
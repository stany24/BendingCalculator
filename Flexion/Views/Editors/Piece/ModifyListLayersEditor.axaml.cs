using Avalonia.Controls;
using Flexion.ViewModels;

namespace Flexion.Views.Editors.Piece;

public partial class ListLayersEditor : Window
{
    public ListLayersEditor(MainViewModel model, long pieceCurrentlyModifiedId)
    {
        InitializeComponent();
        DataContext = model;
        model.PieceCurrentlyModifiedId = pieceCurrentlyModifiedId;
    }
}
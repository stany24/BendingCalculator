using Avalonia.Controls;
using Flexion.ViewModels;

namespace Flexion.Views.Editors.Piece;

public partial class PieceEditor : Window
{
    public PieceEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        Closing += (_, _) => CloseLayerOfPieceEditor();
    }

    private void CloseLayerOfPieceEditor()
    {
        if(DataContext is not MainViewModel model){return;}
        model.CloseLayerOfPieceEditor();
    }
}
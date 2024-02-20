using Avalonia.Controls.Shapes;
using Flexion.Logic.Helper;
using Flexion.Logic.Preview;
using Flexion.ViewModels;

namespace Flexion.Views.Editors.Piece;

public partial class PieceEditor : WindowWithHelp
{
    public PieceEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        Closing += (_, _) => CloseLayerOfPieceEditor();
        HelpButton.Click += (_,_) => OpenHelpWindow(HelperInfo.PieceWindowModules);
        model.UpdatePreviewPiece += (_,_) => UpdatePreviewPiece();
        SizeChanged += (_,_) => UpdatePreviewPiece();
    }

    private void CloseLayerOfPieceEditor()
    {
        if(DataContext is not MainViewModel model){return;}
        model.CloseLayerOfPieceEditor();
    }
    
    private void UpdatePreviewPiece()
    {
        if(DataContext is not MainViewModel model){return;}
        PiecePreviewCanvas.Children.Clear();
        if (model.SelectedPieces.Count != 1) { return; }
        double width = Width-10;
        double height = Grid.RowDefinitions[2].ActualHeight-10;
        foreach (Shape shape in Preview.GetPreviewPiece(model.SelectedPieces[0],width,height))
        {
            PiecePreviewCanvas.Children.Add(shape);
        }
    }
}
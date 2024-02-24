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
        GridPiecePreview.Children.Clear();
        if (model.SelectedPieces.Count != 1) { return; }
        if (model.SelectedPieces[0].Layers.Count< 1) { return; }
        Preview.GetPreviewPiece(ref GridPiecePreview, model.SelectedPieces[0]);
    }
}
using Avalonia.Controls;
using Avalonia.Media;
using Flexion.Logic.Helper;
using Flexion.Logic.Preview;
using Flexion.ViewModels;

namespace Flexion.Views.Editors.Piece;

public partial class PieceEditor : WindowWithHelp
{
    private readonly PiecePreview _piecePreview;
    
    public PieceEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        Closing += (_, _) => CloseLayerOfPieceEditor();
        HelpButton.Click += (_,_) => OpenHelpWindow(HelperInfo.PieceWindowModules);
        model.UpdatePreviewPiece += (_,_) => UpdatePreviewPiece();
        SizeChanged += (_,_) => UpdatePreviewPiece();
        
        _piecePreview = new PiecePreview(null)
        {
            Background= new SolidColorBrush(Color.Parse("#292929"))
        };
        Grid.SetColumn(_piecePreview,0);
        Grid.SetRow(_piecePreview,2);
        Grid.SetColumnSpan(_piecePreview,5);
        MainGrid.Children.Add(_piecePreview);
    }

    private void CloseLayerOfPieceEditor()
    {
        if(DataContext is not MainViewModel model){return;}
        model.CloseLayerOfPieceEditor();
    }
    
    private void UpdatePreviewPiece()
    {
        if(DataContext is not MainViewModel model){return;}
        if (model.SelectedPieces.Count != 1) {_piecePreview.UpdatePreview(null); return; }
        if (model.SelectedPieces[0].Layers.Count< 1) {_piecePreview.UpdatePreview(null); return; }
        _piecePreview.UpdatePreview(model.SelectedPieces[0]);
    }
}
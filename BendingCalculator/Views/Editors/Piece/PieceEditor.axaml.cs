using System.Threading;
using System.Threading.Tasks;
using Avalonia.Threading;
using BendingCalculator.Logic.Helper;
using BendingCalculator.ViewModels;

namespace BendingCalculator.Views.Editors.Piece;

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
        Task.Run(() =>
        {
            Thread.Sleep(10);
            Dispatcher.UIThread.Invoke(() =>
            {
                if(DataContext is not MainViewModel model){return;}
                if (model.SelectedPieces.Count != 1) {PiecePreview.UpdatePreview(null); return; }
                if (model.SelectedPieces[0].Layers.Count< 1) {PiecePreview.UpdatePreview(null); return; }
                PiecePreview.UpdatePreview(model.SelectedPieces[0]);
            });
        });
    }
}
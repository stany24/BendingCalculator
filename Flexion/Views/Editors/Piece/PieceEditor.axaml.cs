using Flexion.Logic.Helper;
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
    }

    private void CloseLayerOfPieceEditor()
    {
        if(DataContext is not MainViewModel model){return;}
        model.CloseLayerOfPieceEditor();
    }
}
using Flexion.Logic.Helper;
using Flexion.ViewModels;

namespace Flexion.Views.Editors.Piece;

public partial class ListLayersEditor : WindowWithHelp
{
    public ListLayersEditor(MainViewModel model, long pieceCurrentlyModifiedId)
    {
        InitializeComponent();
        DataContext = model;
        model.PieceCurrentlyModifiedId = pieceCurrentlyModifiedId;
        HelpButton.Click += (_,_) => OpenHelpWindow(HelperInfo.PieceLayerWindowModules);
    }
}
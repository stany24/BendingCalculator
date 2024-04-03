using BendingCalculator.Logic.Helper;
using BendingCalculator.ViewModels;

namespace BendingCalculator.Views.Editors.Piece;

public partial class ListLayersEditor : WindowWithHelp
{
    public ListLayersEditor(MainViewModel model, long pieceCurrentlyModifiedId)
    {
        InitializeComponent();
        DataContext = model;
        model.PieceCurrentlyModifiedId = pieceCurrentlyModifiedId;
        HelpButton.Click += (_, _) => OpenHelpWindow(HelperInfo.PieceLayerWindowModules);
    }
}
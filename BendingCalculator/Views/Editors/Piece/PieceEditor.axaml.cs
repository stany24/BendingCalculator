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
        HelpButton.Click += (_, _) => OpenHelpWindow("PieceEditorHelper");
    }

    private void CloseLayerOfPieceEditor()
    {
        if (DataContext is not MainViewModel model) return;
        model.CloseLayerOfPieceEditor();
    }
}
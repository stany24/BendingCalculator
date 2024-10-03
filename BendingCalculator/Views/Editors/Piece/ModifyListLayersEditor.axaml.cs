using BendingCalculator.ViewModels;

namespace BendingCalculator.Views.Editors.Piece;

public partial class ListLayersEditor : WindowWithHelp
{
    public ListLayersEditor(MainViewModel model)
    {
        InitializeComponent();
        DataContext = model;
        HelpButton.Click += (_, _) => OpenHelpWindow("ModifyListLayersEditorHelper");
    }
}
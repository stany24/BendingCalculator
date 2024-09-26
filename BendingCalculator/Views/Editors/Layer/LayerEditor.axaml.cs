using BendingCalculator.Logic.Helper;
using BendingCalculator.ViewModels;

namespace BendingCalculator.Views.Editors.Layer;

public partial class LayerEditor : WindowWithHelp
{
    public LayerEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        HelpButton.Click += (_, _) => OpenHelpWindow("LayerEditorHelper");
    }
}
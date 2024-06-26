using BendingCalculator.Logic.Helper;
using BendingCalculator.ViewModels;

namespace BendingCalculator.Views.Editors.Material;

public partial class MaterialEditor : WindowWithHelp
{
    public MaterialEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        HelpButton.Click += (_, _) => OpenHelpWindow(HelperInfo.MaterialWindowModules);
    }
}
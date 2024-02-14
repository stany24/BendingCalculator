using Flexion.Logic.Helper;
using Flexion.ViewModels;

namespace Flexion.Views.Editors.Material;

public partial class MaterialEditor : WindowWithHelp
{
    public MaterialEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        HelpButton.Click += (_,_) => OpenHelpWindow(HelperInfo.MaterialWindowModules);
    }
}
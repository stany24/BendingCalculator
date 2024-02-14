using Flexion.Logic.Helper;
using Flexion.ViewModels;

namespace Flexion.Views.Editors.Layer;

public partial class LayerEditor: WindowWithHelp
{
    public LayerEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        HelpButton.Click += (_,_) => OpenHelpWindow(HelperInfo.LayerWindowModules);
    }
}
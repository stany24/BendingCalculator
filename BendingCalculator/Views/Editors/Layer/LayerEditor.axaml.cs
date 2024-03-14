using BendingCalculator.Logic.Helper;
using BendingCalculator.ViewModels;

namespace BendingCalculator.Views.Editors.Layer;

public partial class LayerEditor: WindowWithHelp
{
    public LayerEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        HelpButton.Click += (_,_) => OpenHelpWindow(HelperInfo.LayerWindowModules);
        model.UpdatePreviewLayer += (_,_) => UpdatePreviewLayer();
        SizeChanged += (_,_) => UpdatePreviewLayer();
    }
    
    private void UpdatePreviewLayer()
    {
        if (DataContext is not MainViewModel model) { return; }
        if(model.SelectedLayers.Count < 1){LayerPreview.UpdatePreview(null);return;}
        LayerPreview.UpdatePreview(model.SelectedLayers[0]);
    }
}
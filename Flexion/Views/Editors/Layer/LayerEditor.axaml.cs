using Flexion.Logic.Helper;
using Flexion.Logic.Preview;
using Flexion.ViewModels;

namespace Flexion.Views.Editors.Layer;

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
        GridLayerPreview.Children.Clear();
        if(model.SelectedLayers.Count < 1){return;}
        Preview.GetPreviewLayer(ref GridLayerPreview, model.SelectedLayers[0]);
    }
}
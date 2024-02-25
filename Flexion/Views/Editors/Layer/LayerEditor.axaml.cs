using Avalonia.Controls;
using Avalonia.Media;
using Flexion.Logic.Helper;
using Flexion.Logic.Preview;
using Flexion.ViewModels;

namespace Flexion.Views.Editors.Layer;

public partial class LayerEditor: WindowWithHelp
{
    private readonly LayerPreview _layerPreview;
    
    public LayerEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        HelpButton.Click += (_,_) => OpenHelpWindow(HelperInfo.LayerWindowModules);
        model.UpdatePreviewLayer += (_,_) => UpdatePreviewLayer();
        SizeChanged += (_,_) => UpdatePreviewLayer();
        _layerPreview = new LayerPreview(null)
        {
            Height = 300,
            Background = new SolidColorBrush(Color.Parse("#292929"))
        };
        Grid.SetColumn(_layerPreview,0);
        Grid.SetRow(_layerPreview,2);
        Grid.SetColumnSpan(_layerPreview,3);
        MainGrid.Children.Add(_layerPreview);
    }
    
    private void UpdatePreviewLayer()
    {
        if (DataContext is not MainViewModel model) { return; }
        GridLayerPreview.Children.Clear();
        if(model.SelectedLayers.Count < 1){return;}
        _layerPreview.UpdatePreview(model.SelectedLayers[0]);
    }
}
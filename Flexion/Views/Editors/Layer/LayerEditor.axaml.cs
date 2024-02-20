using Avalonia.Controls.Shapes;
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
        if(DataContext is not MainViewModel model){return;}
        LayerPreviewCanvas.Children.Clear();
        if (model.SelectedLayers.Count != 1) { return; }
        double width = Width-10;
        double height = Grid.RowDefinitions[2].ActualHeight-10;
        foreach (Shape shape in Preview.GetPreviewLayer(model.SelectedLayers[0],width,height))
        {
            LayerPreviewCanvas.Children.Add(shape);
        }
    }
}
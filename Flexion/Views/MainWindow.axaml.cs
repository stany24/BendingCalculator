using System.Globalization;
using System.Resources;
using Avalonia.Controls.Shapes;
using Flexion.Assets.Localization.MainLocalization;
using Flexion.Logic.Helper;
using Flexion.Logic.Preview;
using Flexion.ViewModels;
using LiveChartsCore.SkiaSharpView;

namespace Flexion.Views;

public partial class Main : WindowWithHelp
{
    public Main(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        Closing += (_, _) => CloseAllWindows();
        model.ReloadLanguage += (_, _) => ReloadLanguage();
        model.UpdatePreviewMainWindow += (_,_) => UpdatePreviewMainWindow();
        ReloadLanguage();
        HelpButton.Click += (_,_) => OpenHelpWindow(HelperInfo.MainWindowModules);
    }

    private void UpdatePreviewMainWindow()
    {
        if((DataContext as MainViewModel).SelectedLayersMainWindow.Count < 1){return;}
        LayerPreviewCanvas.Children.Clear();
        double width = Width-140;//margin
        width /= 4;
        width -= 65;
        double height = Height - 70;//margin
        height /= 2;
        height -= 60;
        height /= 2;
        foreach (Shape shape in PreviewLayer.GetPreview((DataContext as MainViewModel).SelectedLayersMainWindow[0],width,height))
        {
            LayerPreviewCanvas.Children.Add(shape);
        }
    }

    private void CloseAllWindows()
    {
        if(DataContext is not MainViewModel model){return;}
        model.CloseAllWindow();
    }
    
    private void ReloadLanguage()
    {
        ResourceManager resourceManager = new(typeof(MainLocalization));
        if(DataContext is not MainViewModel model){return;}
        ChartResult.XAxes = new[] {
            new Axis {
                Name = resourceManager.GetString("XAxisName", new CultureInfo(model.Language)) }};
        ChartResult.YAxes = new[] {
            new Axis {
                Name = resourceManager.GetString("YAxisName", new CultureInfo(model.Language))}};
    }
}
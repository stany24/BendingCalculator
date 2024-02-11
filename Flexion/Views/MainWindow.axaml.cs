using System.Globalization;
using System.Resources;
using Avalonia.Controls;
using Flexion.Assets.Localization;
using Flexion.ViewModels;
using LiveChartsCore.SkiaSharpView;

namespace Flexion.Views;

public partial class Main : Window
{
    public Main(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        Closing += (_, _) => CloseAllWindows();
        model.ReloadLanguage += (_, _) => ReloadLanguage();
        ReloadLanguage();
    }

    private void CloseAllWindows()
    {
        if(DataContext is not MainViewModel model){return;}
        model.CloseAllWindow();
    }
    
    private void ReloadLanguage()
    {
        ResourceManager resourceManager = new(typeof(Resources));
        if(DataContext is not MainViewModel model){return;}
        ChartResult.XAxes = new[] {
            new Axis {
                Name = resourceManager.GetString("XAxisName", new CultureInfo(model.Language)) }};
        ChartResult.YAxes = new[] {
            new Axis {
                Name = resourceManager.GetString("YAxisName", new CultureInfo(model.Language))}};
    }
}
using System;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Threading;
using BendingCalculator.Assets.Localization.MainLocalization;
using BendingCalculator.Logic;
using BendingCalculator.Logic.Helper;
using BendingCalculator.ViewModels;
using LiveChartsCore.SkiaSharpView;

namespace BendingCalculator.Views;
 
public partial class Main : WindowWithHelp
{
    #region Constructor

    public Main(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        Closing += (_, _) => CloseAllWindows();
        LanguageEvents.LanguageChanged += ReloadLanguage;
        ReloadLanguage(null,EventArgs.Empty);
        HelpButton.Click += (_,_) => OpenHelpWindow(HelperInfo.MainWindowModules);
    }

    #endregion
    
    private void CloseAllWindows()
    {
        if(DataContext is not MainViewModel model){return;}
        model.CloseAllWindow();
    }
    
    private void ReloadLanguage(object? sender, EventArgs eventArgs)
    {
        ResourceManager resourceManager = new(typeof(MainLocalization));
        if(DataContext is not MainViewModel model){return;}
        ChartResult.XAxes = new[] {
            new Axis {
                Name = resourceManager.GetString("XAxisName", new CultureInfo(model.Language))}};
        ChartResult.YAxes = new[] {
            new Axis {
                Name = resourceManager.GetString("YAxisName", new CultureInfo(model.Language))}};
    }
}
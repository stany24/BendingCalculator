using System;
using Avalonia;
using Avalonia.Markup.Xaml.MarkupExtensions;
using BendingCalculator.Logic;
using BendingCalculator.Logic.Helper;
using BendingCalculator.ViewModels;
using LiveChartsCore.SkiaSharpView;

namespace BendingCalculator.Views;
 
public partial class Main : WindowWithHelp
{
    #region Constructor

    public Main() { } // used for compiled bindings
    
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
        ChartResult.XAxes = new[] {
            new Axis {
                Name = Assets.Localization.Static.Static.XAxisName}};
        ChartResult.YAxes = new[] {
            new Axis {
                Name = Assets.Localization.Static.Static.YAxisName}};
    }
}
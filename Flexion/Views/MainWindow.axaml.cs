using System.Globalization;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Threading;
using Flexion.Assets.Localization.MainLocalization;
using Flexion.Logic.Helper;
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
        model.UpdatePreviewMainWindowLayer += (_,_) => UpdatePreviewLayerMainWindow();
        model.UpdatePreviewMainWindowPiece += (_,_) => UpdatePreviewPieceMainWindow();
        SizeChanged += (_,_) => UpdatePreviewMainWindow();
        ReloadLanguage();
        HelpButton.Click += (_,_) => OpenHelpWindow(HelperInfo.MainWindowModules);
    }

    private void UpdatePreviewMainWindow()
    {
        UpdatePreviewLayerMainWindow();
        UpdatePreviewPieceMainWindow();
    }

    private void UpdatePreviewLayerMainWindow()
    {
        if(DataContext is not MainViewModel model){return;}
        if(model.SelectedLayersMainWindow.Count < 1){LayerPreview.UpdatePreview(null);return;}
        LayerPreview.UpdatePreview(model.SelectedLayersMainWindow[0]);
    }
    
    private void UpdatePreviewPieceMainWindow()
    {
        Task.Run(() =>
        {
            Thread.Sleep(10);
            Dispatcher.UIThread.Invoke(() =>
            {
                if(DataContext is not MainViewModel model){return;}
                if(model.SelectedPiecesMainWindow.Count < 1){PiecePreview.UpdatePreview(null);return;}
                if(model.SelectedPiecesMainWindow[0].Layers.Count < 1){PiecePreview.UpdatePreview(null);return;}
                PiecePreview.UpdatePreview(model.SelectedPiecesMainWindow[0]);
            });
        });
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
                Name = resourceManager.GetString("XAxisName", new CultureInfo(model.Language))}};
        ChartResult.YAxes = new[] {
            new Axis {
                Name = resourceManager.GetString("YAxisName", new CultureInfo(model.Language))}};
        if(model.SelectedLayersMainWindow.Count < 1){return;}
        LayerPreview.UpdatePreview(model.SelectedLayersMainWindow[0]);
    }
}
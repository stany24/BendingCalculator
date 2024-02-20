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
        if(model.SelectedLayersMainWindow.Count < 1){return;}
        LayerPreviewCanvasMainWindow.Children.Clear();
        double width = GridLayerPreview.ColumnDefinitions[2].ActualWidth;
        double height = GridLayerPreview.RowDefinitions[0].ActualHeight+GridLayerPreview.RowDefinitions[1].ActualHeight+GridLayerPreview.RowDefinitions[2].ActualHeight;
        foreach (Shape shape in Preview.GetPreviewLayer(model.SelectedLayersMainWindow[0],width,height))
        {
            LayerPreviewCanvasMainWindow.Children.Add(shape);
        }
    }
    
    private void UpdatePreviewPieceMainWindow()
    {
        if(DataContext is not MainViewModel model){return;}
        if(model.SelectedPiecesMainWindow.Count < 1){return;}
        PiecePreviewCanvasMainWindow.Children.Clear();
        double width = GridPiecePreview.ColumnDefinitions[2].ActualWidth;
        double height = GridPiecePreview.RowDefinitions[0].ActualHeight + GridPiecePreview.RowDefinitions[1].ActualHeight +GridPiecePreview.RowDefinitions[2].ActualHeight;
        foreach (Shape shape in Preview.GetPreviewPiece(model.SelectedPiecesMainWindow[0],width,height))
        {
            PiecePreviewCanvasMainWindow.Children.Add(shape);
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
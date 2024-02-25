using System.Globalization;
using System.Resources;
using Avalonia.Controls;
using Avalonia.Media;
using Flexion.Assets.Localization.MainLocalization;
using Flexion.Logic.Helper;
using Flexion.Logic.Preview;
using Flexion.ViewModels;
using LiveChartsCore.SkiaSharpView;

namespace Flexion.Views;
 
public partial class Main : WindowWithHelp
{
    private readonly LayerPreview _layerPreview;
    private readonly PiecePreview _piecePreview;
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
        
        _layerPreview = new LayerPreview(null)
        {
            Background= new SolidColorBrush(Color.Parse("#292929"))
        };
        Grid.SetColumn(_layerPreview,0);
        Grid.SetRow(_layerPreview,4);
        Grid.SetColumnSpan(_layerPreview,4);
        GridLayer.Children.Add(_layerPreview);
        
        _piecePreview = new PiecePreview(null)
        {
            Background= new SolidColorBrush(Color.Parse("#292929"))
        };
        Grid.SetColumn(_piecePreview,0);
        Grid.SetRow(_piecePreview,4);
        Grid.SetColumnSpan(_piecePreview,4);
        GridPiece.Children.Add(_piecePreview);
    }

    private void UpdatePreviewMainWindow()
    {
        UpdatePreviewLayerMainWindow();
        UpdatePreviewPieceMainWindow();
    }

    private void UpdatePreviewLayerMainWindow()
    {
        if(DataContext is not MainViewModel model){return;}
        if(model.SelectedLayersMainWindow.Count < 1){_layerPreview.UpdatePreview(null);return;}
        _layerPreview.UpdatePreview(model.SelectedLayersMainWindow[0]);
    }
    
    private void UpdatePreviewPieceMainWindow()
    {
        if(DataContext is not MainViewModel model){return;}
        if(model.SelectedPiecesMainWindow.Count < 1){_piecePreview.UpdatePreview(null);return;}
        if(model.SelectedPiecesMainWindow[0].Layers.Count < 1){_piecePreview.UpdatePreview(null);return;}
        _piecePreview.UpdatePreview(model.SelectedPiecesMainWindow[0]);
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
    }
}
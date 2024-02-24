using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Flexion.Assets.Localization.MainLocalization;
using Flexion.Logic;
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
        Preview.GetPreviewLayer(ref GridLayerPreview, model.SelectedLayersMainWindow[0]);
    }
    
    private void UpdatePreviewPieceMainWindow()
    {
        if(DataContext is not MainViewModel model){return;}
        PiecePreviewCanvasMainWindow.Children.Clear();
        GridLayerNames.Children.Clear();
        PiecePreviewCanvasMainWindow.Children.Clear();
        if(model.SelectedPiecesMainWindow.Count < 1){return;}
        if(model.SelectedPiecesMainWindow[0].Layers.Count < 1){return;}
        CreateNewTextBlocks(model.SelectedPiecesMainWindow[0]);
        double width = GridPiecePreview.ColumnDefinitions[2].ActualWidth;
        double height = GetFullGridHeight(GridPiecePreview);
        foreach (Shape shape in Preview.GetPreviewPiece(model.SelectedPiecesMainWindow[0],width,height))
        {
            PiecePreviewCanvasMainWindow.Children.Add(shape);
        }
    }

    private double GetFullGridHeight(Grid grid)
    {
        double height = 0;
        int i = 0;
        while (i < 100)
        {
            try
            {
                height += grid.RowDefinitions[i].ActualHeight;
                i++;
            }
            catch (Exception e)
            {
                return height;
            }
        }
        return height;
    }

    private void CreateNewTextBlocks(Piece piece)
    {
        StringBuilder builder = new();
        builder.Append('*');
        for (int i = 0; i < piece.Layers.Count-1; i++)
        {
            builder.Append(",10,*");
        }
        GridLayerNames.RowDefinitions = new RowDefinitions(builder.ToString());
        for (int i = 0; i < piece.Layers.Count; i++)
        {
            TextBlock block = new()
            {
                Text = piece.Layers[i].Material.Display,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(block,0);
            Grid.SetRow(block,2*i);
            GridLayerNames.Children.Add(block);
        }
        Grid.SetRowSpan(PiecePreviewCanvasMainWindow,piece.Layers.Count*2-1);
        GridLayerNames.UpdateLayout();
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
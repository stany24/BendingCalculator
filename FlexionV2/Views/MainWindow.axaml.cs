using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using FlexionV2.Logic;
using FlexionV2.ViewModels;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel;

namespace FlexionV2.Views;

public partial class Main : Window
{
    public Main(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        UiEvents();
    }

    private void UiEvents()
    {
        BtnStart.Click += (_, _) => Task.Run(CalculateFlexion);
        Closing += (_, _) => CloseAllWindows();
    }

    private void CloseAllWindows()
    {
        if(DataContext is not MainViewModel model){return;}
        model.CloseAllWindow();
    }

    private void CalculateFlexion()
    {
        if(DataContext is not MainViewModel model){return;}
        Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() => {
            if(LbxPiece.SelectedItems is { Count: 0 }){return;}
            if(LbxPiece.SelectedItems?[0] is not Piece piece){return;}
            if(piece.Layers.Count == 0){return;}
            if(NudForce.Value == null){return;}
            model.SeriesGraphFlexion[0].Values=piece.CalculateFlexion((int)NudForce.Value, piece.Length/10000).Select((t, i) => new ObservablePoint(i, t)).ToList();
            ChartResult.CoreChart.Update(new ChartUpdateParams { IsAutomaticUpdate = false, Throttling = false });
        });
    }
}
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using FlexionV2.Logic;
using FlexionV2.ViewModels;
using FlexionV2.Views.Editors.Force;
using FlexionV2.Views.Editors.Material;
using FlexionV2.Views.Editors.Layer;
using FlexionV2.Views.Editors.Piece;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel;

namespace FlexionV2.Views;

public partial class Main : Window
{
    private ForceEditor? _forceEditor;
    
    private MaterialEditor? _materialEditor;
    
    private LayerEditor? _layerEditor;
    
    private PieceEditor? _pieceEditor;

    public Main(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        Binding binding2 = new()
        { 
            Source = (DataContext as MainViewModel), 
            Path = nameof(model.Layers)
        }; 
        LbxLayer.Bind(ItemsControl.ItemsSourceProperty,binding2 );
        Binding binding3 = new()
        { 
            Source = (DataContext as MainViewModel), 
            Path = nameof(model.Pieces)
        }; 
        LbxPiece.Bind(ItemsControl.ItemsSourceProperty,binding3 );
        UiEvents();
    }

    private void UiEvents()
    {
        BtnForce.Click += (_, _) => OpenForceEditor();
        BtnMaterial.Click += (_, _) => OpenMaterialEditor();
        BtnLayer.Click += (_, _) => OpenLayerEditor();
        BtnPiece.Click += (_,_) => OpenPieceEditor();
        BtnStart.Click += (_, _) => Task.Run(CalculateFlexion);
        Closing += (_, _) => CloseAllWindows();
    }

    private void CloseAllWindows()
    {
        _materialEditor?.Close();
        _layerEditor?.Close();
        _pieceEditor?.Close();
        _forceEditor?.Close();
    }

    private void OpenForceEditor()
    {
        if(_forceEditor != null){return;}
        _forceEditor = new ForceEditor();
        _forceEditor.Closing += (_, _) => NudForce.Value = _forceEditor?.CalculateForce();
        _forceEditor.Closed += (_, _) => _forceEditor = null;
        _forceEditor.Show();
    }
    
    private void OpenMaterialEditor()
    {
        if(_materialEditor != null){return;}
        _materialEditor = new MaterialEditor((DataContext as MainViewModel));
        _materialEditor.Closed += (_, _) => _materialEditor = null;
        _materialEditor.Show();
    }
    
    private void OpenLayerEditor()
    {
        if(_layerEditor != null){return;}
        _layerEditor = new LayerEditor((DataContext as MainViewModel));
        _layerEditor.Closed += (_, _) => _layerEditor = null;
        _layerEditor.Show();
    }
    
    private void OpenPieceEditor()
    {
        if(_pieceEditor != null){return;}
        _pieceEditor = new PieceEditor((DataContext as MainViewModel));
        _pieceEditor.Closed += (_, _) => _pieceEditor = null;
        _pieceEditor.Show();
    }

    private void CalculateFlexion()
    {
        Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() => {
            if(LbxPiece.SelectedItems is { Count: 0 }){return;}
            if(LbxPiece.SelectedItems?[0] is not Piece piece){return;}
            if(piece.Layers.Count == 0){return;}
            if(NudForce.Value == null){return;}
            (DataContext as MainViewModel).Series[0].Values=piece.Intégrale((int)NudForce.Value, piece.Length/10000).Select((t, i) => new ObservablePoint(i, t)).ToList();
            ChartResult.CoreChart.Update(new ChartUpdateParams { IsAutomaticUpdate = false, Throttling = false });
        });
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Layout;
using FlexionV2.Logic;
using FlexionV2.ViewModels;
using FlexionV2.Views.Editors.Force;
using FlexionV2.Views.Editors.Material;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView;

namespace FlexionV2.Views;

public partial class Main : Window
{
    private double Force = 100;
    private const double Gap = 1e-4;
    private MaterialEditor? _materialEditor;
    private ForceEditor? _forceEditor;
    private NumericUpDown nudForce;
    private ListBox lbxMaterial;

    public Main()
    {
        InitializeComponent();
        InitializeUi();
    }

    private void InitializeUi()
    {
        InitializeForceArea();
        InitializePieceArea();
        InitializeLayerArea();
        InitializeMaterialArea();
    }

    private void InitializeForceArea()
    {
        TextBlock lblForce = new() { Text = "Force:",VerticalAlignment = VerticalAlignment.Center };
        Grid.SetColumn(lblForce,0);
        Grid.SetRow(lblForce,0);
        GridForce.Children.Add(lblForce);
        nudForce = new NumericUpDown { Value = 5 };
        Grid.SetColumn(nudForce,0);
        Grid.SetRow(nudForce,2);
        GridForce.Children.Add(nudForce);
        Button btnForce = new() { Content = "Modifier" };
        btnForce.Click += (_, _) => OpenForceEditor();
        Grid.SetColumn(btnForce,2);
        Grid.SetRow(btnForce,0);
        GridForce.Children.Add(btnForce);
        Button btnStart = new() { Content = "Commencer" };
        btnStart.Click += (_, _) => Task.Run(CalculateFlexion);
        Grid.SetColumn(btnStart,0);
        Grid.SetRow(btnStart,4);
        GridForce.Children.Add(btnStart);
    }

    private void InitializePieceArea()
    {
        TextBlock lblPiece = new() { Text = "Piece:",VerticalAlignment = VerticalAlignment.Center };
        Grid.SetColumn(lblPiece,0);
        Grid.SetRow(lblPiece,0);
        GridPiece.Children.Add(lblPiece);
        ListBox lbxPiece = new(){VerticalAlignment = VerticalAlignment.Stretch,HorizontalAlignment = HorizontalAlignment.Stretch};
        Grid.SetColumn(lbxPiece,0);
        Grid.SetColumnSpan(lbxPiece,4);
        Grid.SetRow(lbxPiece,2);
        GridPiece.Children.Add(lbxPiece);
        Button btnPiece = new() { Content = "Modifier" };
        Grid.SetColumn(btnPiece,2);
        Grid.SetRow(btnPiece,0);
        GridPiece.Children.Add(btnPiece);
    }

    private void InitializeLayerArea()
    {
        TextBlock lblLayer = new() { Text = "Couche:",VerticalAlignment = VerticalAlignment.Center};
        Grid.SetColumn(lblLayer,0);
        Grid.SetRow(lblLayer,0);
        GridLayer.Children.Add(lblLayer);
        ListBox lbxLayer = new(){VerticalAlignment = VerticalAlignment.Stretch,HorizontalAlignment = HorizontalAlignment.Stretch};
        Grid.SetColumn(lbxLayer,0);
        Grid.SetColumnSpan(lbxLayer,4);
        Grid.SetRow(lbxLayer,2);
        GridLayer.Children.Add(lbxLayer);
        Button btnLayer = new() { Content = "Modifier" };
        Grid.SetColumn(btnLayer,2);
        Grid.SetRow(btnLayer,0);
        GridLayer.Children.Add(btnLayer);
    }

    private void InitializeMaterialArea()
    {
        TextBlock lblMaterial = new() { Text = "Material:",VerticalAlignment = VerticalAlignment.Center };
        Grid.SetColumn(lblMaterial,0);
        Grid.SetRow(lblMaterial,0);
        GridMaterial.Children.Add(lblMaterial);
        lbxMaterial = new ListBox {VerticalAlignment = VerticalAlignment.Stretch,HorizontalAlignment = HorizontalAlignment.Stretch};
        Grid.SetColumn(lbxMaterial,0);
        Grid.SetColumnSpan(lbxMaterial,4);
        Grid.SetRow(lbxMaterial,2);
        GridMaterial.Children.Add(lbxMaterial);
        Button btnMaterial = new() { Content = "Modifier" };
        btnMaterial.Click += (_, _) => OpenMaterialEditor();
        Grid.SetColumn(btnMaterial,2);
        Grid.SetRow(btnMaterial,0);
        GridMaterial.Children.Add(btnMaterial);
    }

    private void OpenForceEditor()
    {
        if(_forceEditor != null){return;}
        _forceEditor = new ForceEditor(nudForce.Value);
        _forceEditor.Closing += (_, _) => ForceEditorClosing();
        _forceEditor.Closed += (_, _) => _forceEditor = null;
        _forceEditor.Show();
    }
    
    private void ForceEditorClosing()
    {
        nudForce.Value = _forceEditor.CalculateForce();
    }
    
    private void OpenMaterialEditor()
    {
        if(_materialEditor != null){return;}
        _materialEditor = new MaterialEditor(lbxMaterial.Items.Cast<Material>().ToList());
        _materialEditor.Closing += (_, _) => MaterialEditorClosing();
        _materialEditor.Closed += (_, _) => _materialEditor = null;
        _materialEditor.Show();
    }
    
    private void MaterialEditorClosing()
    {
        lbxMaterial.Items.Clear();
        foreach (Material? material in _materialEditor.LbxItems.Items.Cast<Material>())
        {
            lbxMaterial.Items.Add(material);
        }
    }

    private void CalculateFlexion()
    {
        Piece piece = new(1,"test");
        Material material = new("test",69e9);
        piece.Layers.Add(new Layer(material,5,5));
        FillGraph(piece.Intégrale(500, Gap));
    }

    private void FillGraph(double[] data)
    {
        Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() => {
            if(DataContext is not MainViewModel model)  {return;}

            LineSeries<ObservablePoint> line = new();
            List<ObservablePoint> values = data.Select((t, i) => new ObservablePoint(i, t)).ToList();

            line.Values = values;
            model.Series[0]=line ;
        });
        ChartResult.CoreChart.Update(new ChartUpdateParams { IsAutomaticUpdate = false, Throttling = false });
    }
}
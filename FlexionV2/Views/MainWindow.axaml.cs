using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Layout;
using Dapper;
using FlexionV2.Logic;
using FlexionV2.ViewModels;
using FlexionV2.Views.Editors.Force;
using FlexionV2.Views.Editors.Layer;
using FlexionV2.Views.Editors.Material;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel;
using PieceEditor = FlexionV2.Views.Editors.Piece.PieceEditor;

namespace FlexionV2.Views;

public partial class Main : Window
{
    private const double Gap = 1e-4;
    
    private ForceEditor? _forceEditor;
    private NumericUpDown _nudForce;
    
    private MaterialEditor? _materialEditor;
    private ListBox _lbxMaterial;
    
    private LayerEditor? _layerEditor;
    private ListBox _lbxLayer;
    
    private PieceEditor? _pieceEditor;
    private ListBox _lbxPiece;

    private EventHandler<MaterialsChangedEventArgs>? _materialsChanged;
    private EventHandler<LayersChangedEventArgs>? _layersChanged;

    private SQLiteConnection _connection;

    public Main()
    {
        InitializeComponent();
        InitializeUi();
        InitializeDatabaseConnection();
    }
    
    private void InitializeDatabaseConnection()
    {
        const string fileName = "/home/stan/Git/Flexion/FlexionV2/Database/Database.db";
        const string connectionString = $"Data Source={fileName};";
        try
        {
            _connection = new SQLiteConnection(connectionString);
            _connection.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to the database: {ex.Message}");
        }
    }

    private void AddMaterialsToDatabase(List<Material> materials)
    {
        foreach (Material material in materials)
        {
            if (material.Id != null)
            {
                _connection.Execute($"UPDATE Material SET Name = '{material.Name}', E = {material.E} WHERE Id={material.Id}; ");
            }
            else
            {
                _connection.Execute($"INSERT INTO Material (Name,E) VALUES ('{material.Name}',{material.E});");
            }
        }
    }

    private void InitializeUi()
    {
        InitializeForceArea();
        InitializePieceArea();
        InitializeLayerArea();
        InitializeMaterialArea();
        BtnStart.Click += (_, _) => Task.Run(CalculateFlexion);
    }

    private void InitializeForceArea()
    {
        TextBlock lblForce = new() { Text = "Force:",VerticalAlignment = VerticalAlignment.Center };
        Grid.SetColumn(lblForce,0);
        Grid.SetRow(lblForce,0);
        GridForce.Children.Add(lblForce);
        _nudForce = new NumericUpDown { Value = 5 };
        Grid.SetColumn(_nudForce,2);
        Grid.SetRow(_nudForce,0);
        GridForce.Children.Add(_nudForce);
        Button btnForce = new() { Content = "Modifier" };
        btnForce.Click += (_, _) => OpenForceEditor();
        Grid.SetColumn(btnForce,0);
        Grid.SetRow(btnForce,2);
        GridForce.Children.Add(btnForce);
    }

    private void InitializePieceArea()
    {
        TextBlock lblPiece = new() { Text = "Piece:",VerticalAlignment = VerticalAlignment.Center };
        Grid.SetColumn(lblPiece,0);
        Grid.SetRow(lblPiece,0);
        GridPiece.Children.Add(lblPiece);
        _lbxPiece = new ListBox {VerticalAlignment = VerticalAlignment.Stretch,HorizontalAlignment = HorizontalAlignment.Stretch};
        Grid.SetColumn(_lbxPiece,0);
        Grid.SetColumnSpan(_lbxPiece,4);
        Grid.SetRow(_lbxPiece,2);
        GridPiece.Children.Add(_lbxPiece);
        Button btnPiece = new() { Content = "Modifier" };
        btnPiece.Click += (_,_) => OpenPieceEditor();
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
        _lbxLayer = new ListBox {VerticalAlignment = VerticalAlignment.Stretch,HorizontalAlignment = HorizontalAlignment.Stretch};
        Grid.SetColumn(_lbxLayer,0);
        Grid.SetColumnSpan(_lbxLayer,4);
        Grid.SetRow(_lbxLayer,2);
        GridLayer.Children.Add(_lbxLayer);
        Button btnLayer = new() { Content = "Modifier" };
        btnLayer.Click += (_, _) => OpenLayerEditor();
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
        _lbxMaterial = new ListBox {VerticalAlignment = VerticalAlignment.Stretch,HorizontalAlignment = HorizontalAlignment.Stretch};
        Grid.SetColumn(_lbxMaterial,0);
        Grid.SetColumnSpan(_lbxMaterial,4);
        Grid.SetRow(_lbxMaterial,2);
        GridMaterial.Children.Add(_lbxMaterial);
        Button btnMaterial = new() { Content = "Modifier" };
        btnMaterial.Click += (_, _) => OpenMaterialEditor();
        Grid.SetColumn(btnMaterial,2);
        Grid.SetRow(btnMaterial,0);
        GridMaterial.Children.Add(btnMaterial);
    }

    private void OpenForceEditor()
    {
        if(_forceEditor != null){return;}
        _forceEditor = new ForceEditor();
        _forceEditor.Closing += (_, _) => ForceEditorClosing();
        _forceEditor.Closed += (_, _) => _forceEditor = null;
        _forceEditor.Show();
    }
    
    private void ForceEditorClosing()
    {
        _nudForce.Value = _forceEditor?.CalculateForce();
    }
    
    private void OpenMaterialEditor()
    {
        if(_materialEditor != null){return;}
        List<Material> materials = _connection.QueryAsync<Material>("SELECT * FROM Material;").Result.ToList();
        _materialEditor = new MaterialEditor(materials);
        _materialEditor.Closing += (_, _) => MaterialEditorClosing();
        _materialEditor.Closed += (_, _) => _materialEditor = null;
        _materialEditor.Show();
    }
    
    private void MaterialEditorClosing()
    {
        _lbxMaterial.Items.Clear();
        foreach (Material? material in _materialEditor?.LbxItems.Items.Cast<Material>())
        {
            _lbxMaterial.Items.Add(material);
        }
        AddMaterialsToDatabase(_lbxMaterial.Items.Cast<Material>().ToList());
        _materialsChanged?.Invoke(this,new MaterialsChangedEventArgs(_lbxMaterial.Items.Cast<Material>().ToList()));
    }
    
    private void OpenLayerEditor()
    {
        if(_layerEditor != null){return;}
        _layerEditor = new LayerEditor(_lbxLayer.Items.Cast<Layer>().ToList(),_lbxMaterial.Items.Cast<Material>().ToList());
        _layerEditor.Closing += (_, _) => LayerEditorClosing();
        _layerEditor.Closed += (_, _) => _layerEditor = null;
        _materialsChanged +=(_,e)=> _layerEditor?.UpdateMaterialList(e.Materials);
        _layerEditor.Show();
    }
    
    private void LayerEditorClosing()
    {
        _lbxLayer.Items.Clear();
        foreach (Layer? material in _layerEditor?.LbxItems.Items.Cast<Layer>())
        {
            _lbxLayer.Items.Add(material);
        }
        _layersChanged?.Invoke(this,new LayersChangedEventArgs(_lbxLayer.Items.Cast<Layer>().ToList()));
    }
    
    private void OpenPieceEditor()
    {
        if(_pieceEditor != null){return;}
        _pieceEditor = new PieceEditor(_lbxPiece.Items.Cast<Piece>().ToList(),_lbxLayer.Items.Cast<Layer>().ToList());
        _pieceEditor.Closing += (_, _) => PieceEditorClosing();
        _pieceEditor.Closed += (_, _) => _pieceEditor = null;
        _layersChanged += (_, e) => _pieceEditor.LayersChanged?.Invoke(_pieceEditor, e);
        _pieceEditor.Show();
    }
    
    private void PieceEditorClosing()
    {
        _lbxPiece.Items.Clear();
        foreach (Piece? material in _pieceEditor?.LbxItems.Items.Cast<Piece>())
        {
            _lbxPiece.Items.Add(material);
        }
    }

    private void CalculateFlexion()
    {
        if(_lbxPiece.SelectedItems?[0] is not Piece piece){return;}
        if(_nudForce.Value == null){return;}
        FillGraph(piece.Intégrale((int)_nudForce.Value, Gap));
    }

    private void FillGraph(double[] data)
    {
        Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() => {
            if(DataContext is not MainViewModel model)  {return;}
            model.Series[0].Values=data.Select((t, i) => new ObservablePoint(i, t)).ToList();
        });
        ChartResult.CoreChart.Update(new ChartUpdateParams { IsAutomaticUpdate = false, Throttling = false });
    }
}
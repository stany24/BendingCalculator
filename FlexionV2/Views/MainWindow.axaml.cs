using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using FlexionV2.Database.Actions;
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

    private SQLiteConnection _connection;

    public Main()
    {
        InitializeComponent();
        UiEvents();
        InitializeDatabaseConnection();
        Closing += (_, _) => CloseAllWindows();
    }
    
    private void InitializeDatabaseConnection()
    {
        string databasePath = Path.Combine(Directory.GetCurrentDirectory(), "Database/Database.db");
        string connectionString = $"Data Source={databasePath};";
        try
        {
            Environment.SetEnvironmentVariable("SQLite_ConfigureDirectory", AppContext.BaseDirectory); // used to correct an issue with the last version of sqlite
            _connection = new SQLiteConnection(connectionString);
            _connection.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to the database: {ex.Message}");
            Close();
        }
        DataBaseEvents.LayersChanged += (_, _) => ReloadLayers();
        DataBaseEvents.MaterialsChanged += (_, _) => ReloadMaterials();
        DataBaseEvents.PiecesChanged += (_, _) => ReloadPieces();
        ReloadMaterials();
        ReloadLayers();
        ReloadPieces();
    }   

    private void UiEvents()
    {
        BtnForce.Click += (_, _) => OpenForceEditor();
        BtnMaterial.Click += (_, _) => OpenMaterialEditor();
        BtnLayer.Click += (_, _) => OpenLayerEditor();
        BtnPiece.Click += (_,_) => OpenPieceEditor();
        BtnStart.Click += (_, _) => Task.Run(CalculateFlexion);
    }

    private void CloseAllWindows()
    {
        _materialEditor?.Close();
        _layerEditor?.Close();
        _pieceEditor?.Close();
        _forceEditor?.Close();
    }

    private void ReloadLayers()
    {
        LbxLayer.Items.Clear();
        foreach (Layer layer in DataBaseLoader.LoadLayers(_connection))
        {
            LbxLayer.Items.Add(layer);
        }
    }
    
    private void ReloadPieces()
    {
        LbxPiece.Items.Clear();
        foreach (Piece piece in DataBaseLoader.LoadPieces(_connection))
        {
            LbxPiece.Items.Add(piece);
        }
    }
    
    private void ReloadMaterials()
    {
        LbxMaterial.Items.Clear();
        foreach (Material material in DataBaseLoader.LoadMaterials(_connection))
        {
            LbxMaterial.Items.Add(material);
        }
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
        _materialEditor = new MaterialEditor(_connection);
        _materialEditor.Closed += (_, _) => _materialEditor = null;
        _materialEditor.Show();
    }
    
    private void OpenLayerEditor()
    {
        if(_layerEditor != null){return;}
        _layerEditor = new LayerEditor(_connection);
        _layerEditor.Closed += (_, _) => _layerEditor = null;
        _layerEditor.Show();
    }
    
    private void OpenPieceEditor()
    {
        if(_pieceEditor != null){return;}
        _pieceEditor = new PieceEditor(_connection);
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
            if(DataContext is not MainViewModel model){return;}
            model.Series[0].Values=piece.Intégrale((int)NudForce.Value, piece.Length/10000).Select((t, i) => new ObservablePoint(i, t)).ToList();
            ChartResult.CoreChart.Update(new ChartUpdateParams { IsAutomaticUpdate = false, Throttling = false });
        });
    }
}
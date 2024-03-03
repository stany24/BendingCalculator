using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Flexion.Database.Actions;
using Flexion.Logic;
using Flexion.Logic.Helper;
using Flexion.Setting;
using Flexion.Views.Editors.Force;
using Flexion.Views.Editors.Layer;
using Flexion.Views.Editors.Material;
using Flexion.Views.Editors.Piece;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace Flexion.ViewModels;

public partial class MainViewModel : ObservableObject
{
    #region Bindings

    private readonly SQLiteConnection _connection;
    public decimal Force { get; set; } = 100;
    
    public EventHandler<EventArgs>? UpdatePreviewMainWindowLayer { get; set; }
    public EventHandler<EventArgs>? UpdatePreviewMainWindowPiece { get; set; }
    public EventHandler<EventArgs>? UpdatePreviewPiece { get; set; }

    public ObservableCollection<Piece> SelectedPiecesMainWindow { get; set; } = new();

    private ObservableCollection<string> _languages;
    public ObservableCollection<string> Languages
    {
        get => _languages;
        set => SetProperty(ref _languages, value);
    }
    private string _language;
    public string Language
    {
        get => _language;
        set
        {
            _language = value;
            SettingManager.SetLanguage(Language);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Language);
            LanguageEvents.RaiseLanguageChanged(); 
        }
    }
    
    public ICommand OpenLink { get; }
    
    public ISeries[] SeriesGraphFlexion { get; set; } =
    {
        new LineSeries<ObservablePoint>
        {
            Values = new List<ObservablePoint>
            {
                new(0, 0)
            }
        }
    };

    #endregion

    #region Constructor/Destructor

    public MainViewModel(SQLiteConnection connection)
    {
        LanguageEvents.LanguageChanged += ChangeLanguage;
        OpenLink = new OpenLinkCommand();
        Languages = new ObservableCollection<string>{"fr","en","de"};
        Language = SettingManager.GetLanguage();
        _connection = connection;
        SelectedPieces.CollectionChanged += (_,_) => SelectedPieceChanged();
        SelectedLayersOfSelectedPiece.CollectionChanged += (_, _) => SelectedInPieceChanged();
        SelectedAvailableLayers.CollectionChanged += (_, _) => SelectedAvailableChanged();
        DataBaseEvents.LayersChanged += (_, _) => ReloadLayers();
        DataBaseEvents.MaterialsChanged += (_, _) => ReloadMaterials();
        DataBaseEvents.PiecesChanged += (_, _) => ReloadPieces();
        DataBaseEvents.LayerOfPieceChanged += (_, _) => LoadLayersOfPiece(SelectedPieces[0].PieceId);
        ReloadMaterials();
        ReloadLayers();
        ReloadPieces();
        SelectedMaterial = Materials[0];
        Previews();
    }

    ~MainViewModel()
    {
        LanguageEvents.LanguageChanged -= ChangeLanguage;
    }

    #endregion

    #region Functions

    private void Previews()
    {
        SelectedLayersMainWindow.CollectionChanged += (_, _) => UpdatePreviewMainWindowLayer?.Invoke(null, EventArgs.Empty);
        SelectedPiecesMainWindow.CollectionChanged += (_, _) => UpdatePreviewMainWindowPiece?.Invoke(null, EventArgs.Empty);
        SelectedLayers.CollectionChanged += (_, _) => UpdatePreviewLayer?.Invoke(null, EventArgs.Empty);
        SelectedPieces.CollectionChanged += (_, _) => UpdatePreviewPiece?.Invoke(null, EventArgs.Empty);
    }

    public void CalculateFlexion()
    {
        Task.Run(() =>
        {
            if(SelectedPiecesMainWindow is { Count: 0 }){return;}
            if(SelectedPiecesMainWindow[0].Layers.Count == 0){return;}
            double gap = SelectedPiecesMainWindow[0].Length / 10000;
            IEnumerable<double> values = SelectedPiecesMainWindow[0].CalculateFlexion((int)Force,gap);
            List<ObservablePoint> points = values.Select((t, i) => new ObservablePoint(i, t*1000)).ToList();
            SeriesGraphFlexion[0].Values = points;
        });
    }

    #endregion

    #region Editors

    private MaterialEditor? _materialEditor;
    public void OpenMaterialEditor()
    {
        if(_materialEditor != null){return;}
        _materialEditor = new MaterialEditor(this);
        _materialEditor.Closed += (_, _) => _materialEditor = null;
        _materialEditor.Show();
    }
    
    private LayerEditor? _layerEditor;
    public void OpenLayerEditor()
    {
        if(_layerEditor != null){return;}
        _layerEditor = new LayerEditor(this);
        _layerEditor.Closed += (_, _) => _layerEditor = null;
        _layerEditor.Show();
    }
    
    private PieceEditor? _pieceEditor;
    public void OpenPieceEditor()
    {
        if(_pieceEditor != null){return;}
        _pieceEditor = new PieceEditor(this);
        _pieceEditor.Closed += (_, _) => _pieceEditor = null;
        _pieceEditor.Show();
    }
    
    private ForceEditor? _forceEditor;
    public void OpenForceEditor()
    {
        if(_forceEditor != null){return;}
        _forceEditor = new ForceEditor(this);
        _forceEditor.Closing += (_, _) => Force = _forceEditor?.CalculateForce() ?? 100;
        _forceEditor.Closed += (_, _) => _forceEditor = null;
        _forceEditor.Show();
    }

    public void CloseAllWindow()
    {
        _materialEditor?.Close();
        _layerEditor?.Close();
        _pieceEditor?.Close();
        _forceEditor?.Close();
    }
    
    #endregion
}
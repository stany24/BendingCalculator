using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Threading;
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic;
using BendingCalculator.Logic.Helper;
using BendingCalculator.Logic.Math;
using BendingCalculator.Setting;
using BendingCalculator.Views.Editors.Force;
using BendingCalculator.Views.Editors.Layer;
using BendingCalculator.Views.Editors.Material;
using BendingCalculator.Views.Editors.Piece;
using BendingCalculator.Views.Warning;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace BendingCalculator.ViewModels;

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
    
    public ISeries[] SeriesGraphBending { get; set; } =
    {
        new LineSeries<ObservablePoint>
        {
            Values = new List<ObservablePoint>
            {
                new(0, 0)
            }
        }
    };

    private List<ObservablePoint>? _deformationPoints;
    private double[] _constraintsPoints;
    private double? _pieceInGraphLength = 0;
    public double? PieceInGraphLength
    {
        get=>_pieceInGraphLength;
        set => SetProperty(ref _pieceInGraphLength, value);
    }
    
    private double? _deformationAtDistance = -0;
    public double? DeformationAtDistance
    {
        get=>_deformationAtDistance;
        set => SetProperty(ref _deformationAtDistance, value);
    }
    
    private double? _constraintAtDistance = -0;
    public double? ConstraintAtDistance
    {
        get=>_constraintAtDistance;
        set => SetProperty(ref _constraintAtDistance, value);
    }
    
    private double? _deformationCenter = -0;

    public double? DeformationCenter
    {
        get=>_deformationCenter;
        set => SetProperty(ref _deformationCenter, value);
    }

    private double? _constraintCenter;
    public double? ConstraintCenter
    {
        get=>_constraintCenter;
        set => SetProperty(ref _constraintCenter, value);
    }
    
    private double? _distance = 0;
    public double? Distance
    {
        get=>_distance;
        set
        {
            _distance = value;
            if (Distance is not null && PieceInGraphLength is not null && _deformationPoints is not null) { 
                DeformationAtDistance = _deformationPoints[(int)(Distance/PieceInGraphLength*10000)].Y;
                ConstraintAtDistance = _constraintsPoints[(int)(Distance / PieceInGraphLength * 10000)];
                return;
            }
            DeformationAtDistance = 0;
        }
    }

    #endregion

    #region Constructor/Destructor

    public MainViewModel(SQLiteConnection connection)
    {
        LanguageEvents.LanguageChanged += ChangeLanguage;
        OpenLink = new OpenLinkCommand();
        _languages = new ObservableCollection<string>{"fr","en","de"};
        _language = SettingManager.GetLanguage();
        Language = _language;
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

    public void CalculateBending()
    {
        Task.Run(() =>
        {
            if(SelectedPiecesMainWindow is { Count: 0 }){return;}
            if(SelectedPiecesMainWindow[0].Layers.Count == 0){return;}
            double gap = SelectedPiecesMainWindow[0].Length / 10000;
            PieceInGraphLength = SelectedPiecesMainWindow[0].Length*1000;
            
            SelectedPiecesMainWindow[0].RiskOfSlidingLayer += ShowRiskWindow;
            BendingResult result = SelectedPiecesMainWindow[0].CalculateBending((int)Force,gap);
            SelectedPiecesMainWindow[0].RiskOfSlidingLayer -= ShowRiskWindow;
            
            _deformationPoints = result.Integral2.Select((t, i) => new ObservablePoint(i, t*1000)).ToList();
            _constraintsPoints = result.Moment.Zip(result.I, (x, y) => x / y).ToArray();
            _constraintsPoints = _constraintsPoints.Zip(result.Ns, (x, y) => x * y).ToArray();
            SeriesGraphBending[0].Values = _deformationPoints;
            DeformationCenter = _deformationPoints[_deformationPoints.Count / 2].Y;
            ConstraintCenter = _constraintsPoints[_constraintsPoints.Length / 2];
            DeformationAtDistance = _deformationPoints[0].Y;
        });
    }

    private SlideWarning? _slideWarning;
    private void ShowRiskWindow(object? sender,RiskOfSlidingLayersEventArgs e)
    {
        if(SettingManager.GetWarningDisabled()){return;}
        Dispatcher.UIThread.Invoke(() =>
        {
            WarningSlideLayers = new ObservableCollection<KeyValuePair<int, Layer>>
            {
                new(e.Position1, e.Layer1),
                new(e.Position2, e.Layer2)
            };
            _slideWarning?.Close();
            _slideWarning = new SlideWarning(this);
            _slideWarning.Show();
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
        _slideWarning?.Close();
    }
    
    #endregion
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
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

    private Piece? _selectedPieceMainWindow;
    public Piece? SelectedPieceMainWindow
    {
        get => _selectedPieceMainWindow;
        set => SetProperty(ref _selectedPieceMainWindow, value);
    }
    
    private Layer? _selectedLayerMainWindow;
    public Layer? SelectedLayerMainWindow
    {
        get => _selectedLayerMainWindow;
        set => SetProperty(ref _selectedLayerMainWindow, value);
    }
    
    public ICommand OpenLink { get; }
    
    public ISeries[] SeriesGraphBending { get; set; } =
    {
        new LineSeries<ObservablePoint>
        {
            Values = new List<ObservablePoint>
            {
                new(null, null)
            }
        }
    };

    private List<ObservablePoint>? _deformationPoints;
    private double[] _constraintsPoints = Array.Empty<double>();
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

    private double? _constraintCenter = -0;
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
            if (value > PieceInGraphLength) { value = PieceInGraphLength; }
            if (value < 0) { value = 0; }
            _distance = value;
            if (Distance is not null && PieceInGraphLength is not null && _deformationPoints is not null) { 
                DeformationAtDistance = _deformationPoints[(int)(Distance/PieceInGraphLength*10000)].Y;
                ConstraintAtDistance = _constraintsPoints[(int)(Distance / PieceInGraphLength * 10000)];
                return;
            }
            DeformationAtDistance = 0;
            ConstraintAtDistance = 0;
        }
    }

    #endregion

    #region Constructor/Destructor

    public MainViewModel(SQLiteConnection connection)
    {
        _connection = connection;
        LanguageEvents.LanguageChanged += Translate;
        SelectedLayersOfSelectedPiece.CollectionChanged += (_, _) => SelectedInPieceChanged();
        SelectedAvailableLayers.CollectionChanged += (_, _) => SelectedAvailableChanged();
        DataBaseEvents.LayersChanged +=  ReloadLayers;
        DataBaseEvents.MaterialsChanged +=  ReloadMaterials;
        DataBaseEvents.PiecesChanged += ReloadPieces;
        OpenLink = new OpenLinkCommand();
        ReloadMaterials(null,EventArgs.Empty);
        ReloadLayers(null,EventArgs.Empty);
        ReloadPieces(null,EventArgs.Empty);
    }

    ~MainViewModel()
    {
        LanguageEvents.LanguageChanged -= Translate;
        DataBaseEvents.LayersChanged -= ReloadLayers;
        DataBaseEvents.MaterialsChanged -= ReloadMaterials;
        DataBaseEvents.PiecesChanged -= ReloadPieces;
    }

    #endregion

    #region Functions

    public void CalculateBending()
    {
        Task.Run(() =>
        {
            if(SelectedPieceMainWindow is null){return;}
            double gap = SelectedPieceMainWindow.Length / 10000;
            PieceInGraphLength = SelectedPieceMainWindow.Length*1000;
            
            SelectedPieceMainWindow.RiskOfDetachmentBetweenLayer += ShowRiskWindow;
            BendingResult result = SelectedPieceMainWindow.CalculateBending((int)Force,gap);
            SelectedPieceMainWindow.RiskOfDetachmentBetweenLayer -= ShowRiskWindow;
            
            _deformationPoints = result.Integral2.Select((t, i) => new ObservablePoint(i, t*1000)).ToList();
            SeriesGraphBending[0].Values = _deformationPoints;
            DeformationCenter = _deformationPoints[_deformationPoints.Count / 2].Y;
            DeformationAtDistance = _deformationPoints[0].Y;
            
            _constraintsPoints = result.Moment.Zip(result.I, (x, y) => x / y).ToArray();
            _constraintsPoints = _constraintsPoints.Zip(result.Ns, (x, y) => x * y).ToArray();
            ConstraintCenter = _constraintsPoints[_constraintsPoints.Length / 2];
        });
    }

    private DetachmentWarning? _detachmentWarning;
    private void ShowRiskWindow(object? sender,RiskOfDetachmentOfLayersEventArgs e)
    {
        if(SettingManager.GetWarningDisabled()){return;}
        Dispatcher.UIThread.Invoke(() =>
        {
            _detachmentWarning?.Close();
            _detachmentWarning = new DetachmentWarning(
                new WarningViewModel(
                    new ObservableCollection<KeyValuePair<int, Layer>>
                    {
                        new(e.Position1,e.Layer1),
                        new(e.Position2,e.Layer2)
                    }
                )
            );
            _detachmentWarning.Show();
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
        _detachmentWarning?.Close();
    }
    
    #endregion
}
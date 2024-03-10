using System;
using System.Globalization;
using System.Resources;
using Flexion.Assets.Localization.HelperLocalization;
using Flexion.Assets.Localization.MainLocalization;
using Flexion.Assets.Localization.MainLocalization.Helper;
using Flexion.Assets.Localization.EditorLocalization;
using Flexion.Assets.Localization.Logic;
using Flexion.Assets.Localization.EditorLocalization.ForceEditorLocalization;
using Flexion.Assets.Localization.EditorLocalization.LayerEditorLocalization;
using Flexion.Assets.Localization.EditorLocalization.LayerEditorLocalization.Helper;
using Flexion.Assets.Localization.EditorLocalization.MaterialEditorLocalization.Helper;
using Flexion.Assets.Localization.EditorLocalization.PieceEditorLocalization;
using Flexion.Assets.Localization.EditorLocalization.PieceEditorLocalization.Helper;


namespace Flexion.ViewModels;

public partial class MainViewModel
{
    private void ChangeLanguage(object? sender, EventArgs eventArgs)
    {

        CultureInfo lang = new(Language);
        
        #region Main Window
        
        ResourceManager resourceManagerMain = new(typeof(MainLocalization));
        ModifyBinding = resourceManagerMain.GetString("Modify", lang);
        LanguageWithColonBinding = resourceManagerMain.GetString("LanguageWithColon", lang);
        BeginBinding = resourceManagerMain.GetString("Begin", lang);
        MaterialsWithColonBinding = resourceManagerMain.GetString("MaterialsWithColon", lang);
        PiecesWithColonBinding = resourceManagerMain.GetString("PiecesWithColon", lang);
        LayersWithColonBinding = resourceManagerMain.GetString("LayersWithColon", lang);
        DistanceWithColonBinding = resourceManagerMain.GetString("DistanceWithColon", lang);
        ValueDistanceWithColonBinding  = resourceManagerMain.GetString("ValueDistanceWithColon", lang);
        ValueCenterWithColonBinding = resourceManagerMain.GetString("ValueCenterWithColon", lang);
        
        #endregion

        #region Main Window Helper

        ResourceManager resourceManagerMainHelper = new(typeof(MainHelperLocalization));
        MainWindowHelper1Binding = resourceManagerMainHelper.GetString("MainWindowHelper1", lang);
        MainWindowHelper2Binding = resourceManagerMainHelper.GetString("MainWindowHelper2", lang);
        MainWindowHelper3Binding = resourceManagerMainHelper.GetString("MainWindowHelper3", lang);
        MainWindowHelper4Binding = resourceManagerMainHelper.GetString("MainWindowHelper4", lang);
        MainWindowHelper5Binding = resourceManagerMainHelper.GetString("MainWindowHelper5", lang);
        MainWindowHelper6Binding = resourceManagerMainHelper.GetString("MainWindowHelper6", lang);
        MainWindowHelper7Binding = resourceManagerMainHelper.GetString("MainWindowHelper7", lang);
        MainWindowHelper8Binding = resourceManagerMainHelper.GetString("MainWindowHelper8", lang);
        MainWindowHelper9Binding = resourceManagerMainHelper.GetString("MainWindowHelper9", lang);
        MainWindowHelper10Binding = resourceManagerMainHelper.GetString("MainWindowHelper10", lang);

        #endregion

        #region Logic

        ResourceManager resourceManagerLogic = new(typeof(LogicLocalization));
        NoBinding = resourceManagerLogic.GetString("No", lang);
        SidesBinding = resourceManagerLogic.GetString("Sides", lang);
        CenterBinding = resourceManagerLogic.GetString("Center", lang);

        #endregion

        #region All Editors

        ResourceManager resourceManagerEditor = new(typeof(EditorLocalization));
        AddBinding = resourceManagerEditor.GetString("Add", lang);
        RemoveBinding = resourceManagerEditor.GetString("Remove", lang);
        NameWithColonBinding = resourceManagerEditor.GetString("NameWithColon", lang);
        LayersBinding = resourceManagerEditor.GetString("Layers", lang);

        #endregion

        #region Material Editor Helper
        
        ResourceManager resourceManagerMaterialEditorHelper = new(typeof(MaterialEditorHelperLocalization));
        MaterialEditorHelper1Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper1", lang);
        MaterialEditorHelper2Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper2", lang);
        MaterialEditorHelper3Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper3", lang);
        MaterialEditorHelper4Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper4", lang);
        MaterialEditorHelper5Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper5", lang);

        #endregion

        #region Layer Editor

        ResourceManager resourceManagerLayerEditor = new(typeof(LayerEditorLocalization));
        HeightCenterWithColonBinding = resourceManagerLayerEditor.GetString("HeightCenterWithColon", lang);
        HeightOnSidesWithColonBinding = resourceManagerLayerEditor.GetString("HeightOnSidesWithColon", lang);
        WidthCenterWithColonBinding = resourceManagerLayerEditor.GetString("WidthCenterWithColon", lang);
        WidthSidesWithColonBinding = resourceManagerLayerEditor.GetString("WidthSidesWithColon", lang);
        MaterialWithColonBinding = resourceManagerLayerEditor.GetString("MaterialWithColon", lang);

        #endregion

        #region Layer Editor Helper

        ResourceManager resourceManagerLayerEditorHelper = new(typeof(LayerEditorHelperLocalization));
        LayerEditorHelper1Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper1", lang);
        LayerEditorHelper2Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper2", lang);
        LayerEditorHelper3Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper3", lang);
        LayerEditorHelper4Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper4", lang);
        LayerEditorHelper5Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper5", lang);
        LayerEditorHelper6Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper6", lang);
        LayerEditorHelper7Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper7", lang);
        LayerEditorHelper8Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper8", lang);

        #endregion

        #region Piece Editor

        ResourceManager resourceManagerPieceEditor = new(typeof(PieceEditorLocalization));
        ChangeLayersBinding = resourceManagerPieceEditor.GetString("ChangeLayers", lang);
        InPieceWithColonBinding = resourceManagerPieceEditor.GetString("InPieceWithColon", lang);
        AvailableWithColonBinding = resourceManagerPieceEditor.GetString("AvailableWithColon", lang);
        MoveDownBinding = resourceManagerPieceEditor.GetString("MoveDown", lang);
        MoveUpBinding = resourceManagerPieceEditor.GetString("MoveUp", lang);
        LengthWithColonBinding = resourceManagerPieceEditor.GetString("LengthWithColon", lang);

        #endregion

        #region Piece Editor Helper

        ResourceManager resourceManagerPieceEditorHelper = new(typeof(PieceEditorHelperLocalization));
        PieceEditorHelper1Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper1", lang);
        PieceEditorHelper2Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper2", lang);
        PieceEditorHelper3Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper3", lang);
        PieceEditorHelper4Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper4", lang);
        PieceEditorHelper5Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper5", lang);
        PieceEditorHelper6Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper6", lang);
        PieceEditorHelper7Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper7", lang);
        PieceEditorHelper8Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper8", lang);
        PieceEditorHelper9Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper9", lang);
        PieceEditorHelper10Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper10", lang);
        PieceEditorHelper11Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper11", lang);
        PieceEditorHelper12Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper12", lang);
        PieceEditorHelper13Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper13", lang);
        PieceEditorHelper14Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper14", lang);
        PieceEditorHelper15Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper15", lang);

        #endregion

        #region All Helper

        ResourceManager resourceManagerHelper = new(typeof(HelperLocalization));
        HelpBinding = resourceManagerHelper.GetString("Help", lang);

        #endregion

        #region Force Editor

        ResourceManager resourceManagerForceEditor = new(typeof(ForceEditorLocalization));
        ForceWithColonBinding = resourceManagerForceEditor.GetString("ForceWithColon", lang);
        MassWithColonBinding = resourceManagerForceEditor.GetString("MassWithColon", lang);
        RadiusWithColonBinding = resourceManagerForceEditor.GetString("RadiusWithColon", lang);
        GravityWithColonBinding = resourceManagerForceEditor.GetString("GravityWithColon", lang);
        SpeedWithColonBinding = resourceManagerForceEditor.GetString("SpeedWithColon", lang);

        #endregion
    }

    #region Bindings

    private string? _materialEditorHelper1Binding;
    public string? MaterialEditorHelper1Binding
    {
        get =>_materialEditorHelper1Binding;
        set => SetProperty(ref _materialEditorHelper1Binding, value);
    }
    
    private string? _materialEditorHelper2Binding;
    public string? MaterialEditorHelper2Binding
    {
        get =>_materialEditorHelper2Binding;
        set => SetProperty(ref _materialEditorHelper2Binding, value);
    }
    
    private string? _materialEditorHelper3Binding;
    public string? MaterialEditorHelper3Binding
    {
        get =>_materialEditorHelper3Binding;
        set => SetProperty(ref _materialEditorHelper3Binding, value);
    }
    
    private string? _materialEditorHelper4Binding;
    public string? MaterialEditorHelper4Binding
    {
        get =>_materialEditorHelper4Binding;
        set => SetProperty(ref _materialEditorHelper4Binding, value);
    }
    
    private string? _materialEditorHelper5Binding;
    public string? MaterialEditorHelper5Binding
    {
        get =>_materialEditorHelper5Binding;
        set => SetProperty(ref _materialEditorHelper5Binding, value);
    }
    
    private string? _layerEditorHelper1Binding;
    public string? LayerEditorHelper1Binding
    {
        get =>_layerEditorHelper1Binding;
        set => SetProperty(ref _layerEditorHelper1Binding, value);
    }
    
    private string? _layerEditorHelper2Binding;
    public string? LayerEditorHelper2Binding
    {
        get =>_layerEditorHelper2Binding;
        set => SetProperty(ref _layerEditorHelper2Binding, value);
    }
    
    private string? _layerEditorHelper3Binding;
    public string? LayerEditorHelper3Binding
    {
        get =>_layerEditorHelper3Binding;
        set => SetProperty(ref _layerEditorHelper3Binding, value);
    }
    
    private string? _layerEditorHelper4Binding;
    public string? LayerEditorHelper4Binding
    {
        get =>_layerEditorHelper4Binding;
        set => SetProperty(ref _layerEditorHelper4Binding, value);
    }
    
    private string? _layerEditorHelper5Binding;
    public string? LayerEditorHelper5Binding
    {
        get =>_layerEditorHelper5Binding;
        set => SetProperty(ref _layerEditorHelper5Binding, value);
    }
    
    private string? _layerEditorHelper6Binding;
    public string? LayerEditorHelper6Binding
    {
        get =>_layerEditorHelper6Binding;
        set => SetProperty(ref _layerEditorHelper6Binding, value);
    }
    
    private string? _layerEditorHelper7Binding;
    public string? LayerEditorHelper7Binding
    {
        get =>_layerEditorHelper7Binding;
        set => SetProperty(ref _layerEditorHelper7Binding, value);
    }
    
    private string? _layerEditorHelper8Binding;
    public string? LayerEditorHelper8Binding
    {
        get =>_layerEditorHelper8Binding;
        set => SetProperty(ref _layerEditorHelper8Binding, value);
    }
    
    private string? _pieceEditorHelper1Binding;
    public string? PieceEditorHelper1Binding
    {
        get =>_pieceEditorHelper1Binding;
        set => SetProperty(ref _pieceEditorHelper1Binding, value);
    }
    
    private string? _pieceEditorHelper2Binding;
    public string? PieceEditorHelper2Binding
    {
        get =>_pieceEditorHelper2Binding;
        set => SetProperty(ref _pieceEditorHelper2Binding, value);
    }
    
    private string? _pieceEditorHelper3Binding;
    public string? PieceEditorHelper3Binding
    {
        get =>_pieceEditorHelper3Binding;
        set => SetProperty(ref _pieceEditorHelper3Binding, value);
    }
    
    private string? _pieceEditorHelper4Binding;
    public string? PieceEditorHelper4Binding
    {
        get =>_pieceEditorHelper4Binding;
        set => SetProperty(ref _pieceEditorHelper4Binding, value);
    }
    
    private string? _pieceEditorHelper5Binding;
    public string? PieceEditorHelper5Binding
    {
        get =>_pieceEditorHelper5Binding;
        set => SetProperty(ref _pieceEditorHelper5Binding, value);
    }
    
    private string? _pieceEditorHelper6Binding;
    public string? PieceEditorHelper6Binding
    {
        get =>_pieceEditorHelper6Binding;
        set => SetProperty(ref _pieceEditorHelper6Binding, value);
    }
    
    private string? _pieceEditorHelper7Binding;
    public string? PieceEditorHelper7Binding
    {
        get =>_pieceEditorHelper7Binding;
        set => SetProperty(ref _pieceEditorHelper7Binding, value);
    }
    
    private string? _pieceEditorHelper8Binding;
    public string? PieceEditorHelper8Binding
    {
        get =>_pieceEditorHelper8Binding;
        set => SetProperty(ref _pieceEditorHelper8Binding, value);
    }
    
    private string? _pieceEditorHelper9Binding;
    public string? PieceEditorHelper9Binding
    {
        get =>_pieceEditorHelper9Binding;
        set => SetProperty(ref _pieceEditorHelper9Binding, value);
    }
    
    private string? _pieceEditorHelper10Binding;
    public string? PieceEditorHelper10Binding
    {
        get =>_pieceEditorHelper10Binding;
        set => SetProperty(ref _pieceEditorHelper10Binding, value);
    }
    
    private string? _pieceEditorHelper11Binding;
    public string? PieceEditorHelper11Binding
    {
        get =>_pieceEditorHelper11Binding;
        set => SetProperty(ref _pieceEditorHelper11Binding, value);
    }
    
    private string? _pieceEditorHelper12Binding;
    public string? PieceEditorHelper12Binding
    {
        get =>_pieceEditorHelper12Binding;
        set => SetProperty(ref _pieceEditorHelper12Binding, value);
    }
    
    private string? _pieceEditorHelper13Binding;
    public string? PieceEditorHelper13Binding
    {
        get =>_pieceEditorHelper13Binding;
        set => SetProperty(ref _pieceEditorHelper13Binding, value);
    }
    
    private string? _pieceEditorHelper14Binding;
    public string? PieceEditorHelper14Binding
    {
        get =>_pieceEditorHelper14Binding;
        set => SetProperty(ref _pieceEditorHelper14Binding, value);
    }
    
    private string? _pieceEditorHelper15Binding;
    public string? PieceEditorHelper15Binding
    {
        get =>_pieceEditorHelper15Binding;
        set => SetProperty(ref _pieceEditorHelper15Binding, value);
    }
    
    private string? _mainWindowHelper1Binding;
    public string? MainWindowHelper1Binding
    {
        get =>_mainWindowHelper1Binding;
        set => SetProperty(ref _mainWindowHelper1Binding, value);
    }
    
    private string? _mainWindowHelper2Binding;
    public string? MainWindowHelper2Binding
    {
        get =>_mainWindowHelper2Binding;
        set => SetProperty(ref _mainWindowHelper2Binding, value);
    }
    
    private string? _mainWindowHelper3Binding;
    public string? MainWindowHelper3Binding
    {
        get =>_mainWindowHelper3Binding;
        set => SetProperty(ref _mainWindowHelper3Binding, value);
    }
    
    private string? _mainWindowHelper4Binding;
    public string? MainWindowHelper4Binding
    {
        get =>_mainWindowHelper4Binding;
        set => SetProperty(ref _mainWindowHelper4Binding, value);
    }
    
    private string? _mainWindowHelper5Binding;
    public string? MainWindowHelper5Binding
    {
        get =>_mainWindowHelper5Binding;
        set => SetProperty(ref _mainWindowHelper5Binding, value);
    }
    
    private string? _mainWindowHelper6Binding;
    public string? MainWindowHelper6Binding
    {
        get =>_mainWindowHelper6Binding;
        set => SetProperty(ref _mainWindowHelper6Binding, value);
    }
    
    private string? _mainWindowHelper7Binding;
    public string? MainWindowHelper7Binding
    {
        get =>_mainWindowHelper7Binding;
        set => SetProperty(ref _mainWindowHelper7Binding, value);
    }
    
    private string? _mainWindowHelper8Binding;
    public string? MainWindowHelper8Binding
    {
        get =>_mainWindowHelper8Binding;
        set => SetProperty(ref _mainWindowHelper8Binding, value);
    }
    
    private string? _mainWindowHelper9Binding;
    public string? MainWindowHelper9Binding
    {
        get =>_mainWindowHelper9Binding;
        set => SetProperty(ref _mainWindowHelper9Binding, value);
    }
    
    private string? _mainWindowHelper10Binding;
    public string? MainWindowHelper10Binding
    {
        get =>_mainWindowHelper10Binding;
        set => SetProperty(ref _mainWindowHelper10Binding, value);
    }
    
    private string? _addBinding;
    public string? AddBinding
    {
        get =>_addBinding;
        set => SetProperty(ref _addBinding, value);
    }
    
    private string? _availableWithColonBinding;
    public string? AvailableWithColonBinding
    {
        get =>_availableWithColonBinding;
        set => SetProperty(ref _availableWithColonBinding, value);
    }
    
    private string? _beginBinding;
    public string? BeginBinding
    {
        get =>_beginBinding;
        set => SetProperty(ref _beginBinding, value);
    }
    
    private string? _centerBinding;
    public string? CenterBinding
    {
        get =>_centerBinding;
        set => SetProperty(ref _centerBinding, value);
    }
    
    private string? _changeLayersBinding;
    public string? ChangeLayersBinding
    {
        get =>_changeLayersBinding;
        set => SetProperty(ref _changeLayersBinding, value);
    }
    
    private string? _forceWithColonBinding;
    public string? ForceWithColonBinding
    {
        get =>_forceWithColonBinding;
        set => SetProperty(ref _forceWithColonBinding, value);
    }
    
    private string? _gravityWithColonBinding;
    public string? GravityWithColonBinding
    {
        get =>_gravityWithColonBinding;
        set => SetProperty(ref _gravityWithColonBinding, value);
    }
    
    private string? _heightCenterWithColonBinding;
    public string? HeightCenterWithColonBinding
    {
        get =>_heightCenterWithColonBinding;
        set => SetProperty(ref _heightCenterWithColonBinding, value);
    }
    
    private string? _heightOnSidesWithColonBinding;
    public string? HeightOnSidesWithColonBinding
    {
        get =>_heightOnSidesWithColonBinding;
        set => SetProperty(ref _heightOnSidesWithColonBinding, value);
    }
    
    private string? _helpBinding;
    public string? HelpBinding
    {
        get =>_helpBinding;
        set => SetProperty(ref _helpBinding, value);
    }
    
    private string? _inPieceWithColonBinding;
    public string? InPieceWithColonBinding
    {
        get =>_inPieceWithColonBinding;
        set => SetProperty(ref _inPieceWithColonBinding, value);
    }
    
    private string? _languageWithColonBinding;
    public string? LanguageWithColonBinding
    {
        get =>_languageWithColonBinding;
        set => SetProperty(ref _languageWithColonBinding, value);
    }
    
    private string? _layersBinding;
    public string? LayersBinding
    {
        get =>_layersBinding;
        set => SetProperty(ref _layersBinding, value);
    }
    
    private string? _layersWithColonBinding;
    public string? LayersWithColonBinding
    {
        get =>_layersWithColonBinding;
        set => SetProperty(ref _layersWithColonBinding, value);
    }
    
    private string? _lengthWithColonBinding;
    public string? LengthWithColonBinding
    {
        get =>_lengthWithColonBinding;
        set => SetProperty(ref _lengthWithColonBinding, value);
    }
    
    private string? _massWithColonBinding;
    public string? MassWithColonBinding
    {
        get =>_massWithColonBinding;
        set => SetProperty(ref _massWithColonBinding, value);
    }
    
    private string? _materialsWithColonBinding;
    public string? MaterialsWithColonBinding
    {
        get =>_materialsWithColonBinding;
        set => SetProperty(ref _materialsWithColonBinding, value);
    }
    
    private string? _materialWithColonBinding;
    public string? MaterialWithColonBinding
    {
        get =>_materialWithColonBinding;
        set => SetProperty(ref _materialWithColonBinding, value);
    }
    
    private string? _modifyBinding;
    public string? ModifyBinding
    {
        get =>_modifyBinding;
        set => SetProperty(ref _modifyBinding, value);
    }
    
    private string? _moveDownBinding;
    public string? MoveDownBinding
    {
        get =>_moveDownBinding;
        set => SetProperty(ref _moveDownBinding, value);
    }
    
    private string? _moveUpBinding;
    public string? MoveUpBinding
    {
        get =>_moveUpBinding;
        set => SetProperty(ref _moveUpBinding, value);
    }
    
    private string? _nameWithColonBinding;
    public string? NameWithColonBinding
    {
        get =>_nameWithColonBinding;
        set => SetProperty(ref _nameWithColonBinding, value);
    }
    
    private string? _noBinding;
    public string? NoBinding
    {
        get =>_noBinding;
        set => SetProperty(ref _noBinding, value);
    }
    
    private string? _piecesWithColonBinding;
    public string? PiecesWithColonBinding
    {
        get =>_piecesWithColonBinding;
        set => SetProperty(ref _piecesWithColonBinding, value);
    }

    private string? _radiusWithColonBinding;
    public string? RadiusWithColonBinding
    {
        get =>_radiusWithColonBinding;
        set => SetProperty(ref _radiusWithColonBinding, value);
    }

    private string? _removeBinding;
    public string? RemoveBinding
    {
        get =>_removeBinding;
        set => SetProperty(ref _removeBinding, value);
    }

    
    private string? _sidesBinding;
    public string? SidesBinding
    {
        get =>_sidesBinding;
        set => SetProperty(ref _sidesBinding, value);
    }
    
    private string? _speedWithColonBinding;
    public string? SpeedWithColonBinding
    {
        get =>_speedWithColonBinding;
        set => SetProperty(ref _speedWithColonBinding, value);
    }
    
    private string? _widthCenterWithColonBinding;
    public string? WidthCenterWithColonBinding
    {
        get =>_widthCenterWithColonBinding;
        set => SetProperty(ref _widthCenterWithColonBinding, value);
    }
    
    private string? _widthSidesWithColonBinding;
    public string? WidthSidesWithColonBinding
    {
        get =>_widthSidesWithColonBinding;
        set => SetProperty(ref _widthSidesWithColonBinding, value);
    }
    
    private string? _distanceWithColonBinding;
    public string? DistanceWithColonBinding
    {
        get =>_distanceWithColonBinding;
        set => SetProperty(ref _distanceWithColonBinding, value);
    }
    
    private string? _valueDistanceWithColonBinding;
    public string? ValueDistanceWithColonBinding
    {
        get =>_valueDistanceWithColonBinding;
        set => SetProperty(ref _valueDistanceWithColonBinding, value);
    }
    
    private string? _valueCenterWithColonBinding;
    public string? ValueCenterWithColonBinding
    {
        get =>_valueCenterWithColonBinding;
        set => SetProperty(ref _valueCenterWithColonBinding, value);
    }

    #endregion
}
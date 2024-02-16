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
    private void ChangeLanguage()
    {
        #pragma warning disable CS8601 // Possible null reference assignment.
        
        // Main window
        ResourceManager resourceManagerMain = new(typeof(MainLocalization));

        ModifyBinding = resourceManagerMain.GetString("Modify", new CultureInfo(Language));
        LanguageWithColonBinding = resourceManagerMain.GetString("LanguageWithColon", new CultureInfo(Language));
        BeginBinding = resourceManagerMain.GetString("Begin", new CultureInfo(Language));
        MaterialsWithColonBinding = resourceManagerMain.GetString("MaterialsWithColon", new CultureInfo(Language));
        PiecesWithColonBinding = resourceManagerMain.GetString("PiecesWithColon", new CultureInfo(Language));
        LayersWithColonBinding = resourceManagerMain.GetString("LayersWithColon", new CultureInfo(Language));
        
        ResourceManager resourceManagerMainHelper = new(typeof(MainHelperLocalization));
        MainWindowHelper1Binding = resourceManagerMainHelper.GetString("MainWindowHelper1", new CultureInfo(Language));
        MainWindowHelper2Binding = resourceManagerMainHelper.GetString("MainWindowHelper2", new CultureInfo(Language));
        
        ResourceManager resourceManagerLogic = new(typeof(LogicLocalization));
        NoBinding = resourceManagerLogic.GetString("No", new CultureInfo(Language));
        SidesBinding = resourceManagerLogic.GetString("Sides", new CultureInfo(Language));
        CenterBinding = resourceManagerLogic.GetString("Center", new CultureInfo(Language));
        
        // Editors
        ResourceManager resourceManagerEditor = new(typeof(EditorLocalization));
        AddBinding = resourceManagerEditor.GetString("Add", new CultureInfo(Language));
        RemoveBinding = resourceManagerEditor.GetString("Remove", new CultureInfo(Language));
        NameWithColonBinding = resourceManagerEditor.GetString("NameWithColon", new CultureInfo(Language));
        LayersBinding = resourceManagerEditor.GetString("Layers", new CultureInfo(Language));
        
        //material editor
        ResourceManager resourceManagerMaterialEditorHelper = new(typeof(MaterialEditorHelperLocalization));
        MaterialEditorHelper1Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper1", new CultureInfo(Language));
        MaterialEditorHelper2Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper2", new CultureInfo(Language));
        MaterialEditorHelper3Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper3", new CultureInfo(Language));
        MaterialEditorHelper4Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper4", new CultureInfo(Language));
        MaterialEditorHelper5Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper5", new CultureInfo(Language));
        
        // Layer editor
        ResourceManager resourceManagerLayerEditor = new(typeof(LayerEditorLocalization));
        HeightCenterWithColonBinding = resourceManagerLayerEditor.GetString("HeightCenterWithColon", new CultureInfo(Language));
        HeightOnSidesWithColonBinding = resourceManagerLayerEditor.GetString("HeightOnSidesWithColon", new CultureInfo(Language));
        WidthCenterWithColonBinding = resourceManagerLayerEditor.GetString("WidthCenterWithColon", new CultureInfo(Language));
        WidthSidesWithColonBinding = resourceManagerLayerEditor.GetString("WidthSidesWithColon", new CultureInfo(Language));
        MaterialWithColonBinding = resourceManagerLayerEditor.GetString("MaterialWithColon", new CultureInfo(Language));
        
        ResourceManager resourceManagerLayerEditorHelper = new(typeof(LayerEditorHelperLocalization));
        LayerEditorHelper1Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper1", new CultureInfo(Language));
        LayerEditorHelper2Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper2", new CultureInfo(Language));
        LayerEditorHelper3Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper3", new CultureInfo(Language));
        LayerEditorHelper4Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper4", new CultureInfo(Language));
        LayerEditorHelper5Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper5", new CultureInfo(Language));
        LayerEditorHelper6Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper6", new CultureInfo(Language));
        LayerEditorHelper7Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper7", new CultureInfo(Language));
        LayerEditorHelper8Binding = resourceManagerLayerEditorHelper.GetString("LayerEditorHelper8", new CultureInfo(Language));
        
        // Piece editor
        ResourceManager resourceManagerPieceEditor = new(typeof(PieceEditorLocalization));
        ChangeLayersBinding = resourceManagerPieceEditor.GetString("ChangeLayers", new CultureInfo(Language));
        InPieceWithColonBinding = resourceManagerPieceEditor.GetString("InPieceWithColon", new CultureInfo(Language));
        AvailableWithColonBinding = resourceManagerPieceEditor.GetString("AvailableWithColon", new CultureInfo(Language));
        MoveDownBinding = resourceManagerPieceEditor.GetString("MoveDown", new CultureInfo(Language));
        MoveUpBinding = resourceManagerPieceEditor.GetString("MoveUp", new CultureInfo(Language));
        LengthWithColonBinding = resourceManagerPieceEditor.GetString("LengthWithColon", new CultureInfo(Language));
        
        ResourceManager resourceManagerPieceEditorHelper = new(typeof(PieceEditorHelperLocalization));
        PieceEditorHelper1Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper1", new CultureInfo(Language));
        PieceEditorHelper2Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper2", new CultureInfo(Language));
        PieceEditorHelper3Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper3", new CultureInfo(Language));
        PieceEditorHelper4Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper4", new CultureInfo(Language));
        PieceEditorHelper5Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper5", new CultureInfo(Language));
        PieceEditorHelper6Binding = resourceManagerPieceEditorHelper.GetString("PieceEditorHelper6", new CultureInfo(Language));
        
        // Help Window
        ResourceManager resourceManagerHelper = new(typeof(HelperLocalization));
        HelpBinding = resourceManagerHelper.GetString("Help", new CultureInfo(Language));
        
        // force window
        ResourceManager resourceManagerForceEditor = new(typeof(ForceEditorLocalization));
        ForceWithColonBinding = resourceManagerForceEditor.GetString("ForceWithColon", new CultureInfo(Language));
        MassWithColonBinding = resourceManagerForceEditor.GetString("MassWithColon", new CultureInfo(Language));
        RadiusWithColonBinding = resourceManagerForceEditor.GetString("RadiusWithColon", new CultureInfo(Language));
        GravityWithColonBinding = resourceManagerForceEditor.GetString("GravityWithColon", new CultureInfo(Language));
        SpeedWithColonBinding = resourceManagerForceEditor.GetString("SpeedWithColon", new CultureInfo(Language));
        
        #pragma warning restore CS8601 // Possible null reference assignment.
    }
    
    private string _materialEditorHelper1Binding;
    public string MaterialEditorHelper1Binding
    {
        get =>_materialEditorHelper1Binding;
        set => SetProperty(ref _materialEditorHelper1Binding, value);
    }
    
    private string _materialEditorHelper2Binding;
    public string MaterialEditorHelper2Binding
    {
        get =>_materialEditorHelper2Binding;
        set => SetProperty(ref _materialEditorHelper2Binding, value);
    }
    
    private string _materialEditorHelper3Binding;
    public string MaterialEditorHelper3Binding
    {
        get =>_materialEditorHelper3Binding;
        set => SetProperty(ref _materialEditorHelper3Binding, value);
    }
    
    private string _materialEditorHelper4Binding;
    public string MaterialEditorHelper4Binding
    {
        get =>_materialEditorHelper4Binding;
        set => SetProperty(ref _materialEditorHelper4Binding, value);
    }
    
    private string _materialEditorHelper5Binding;
    public string MaterialEditorHelper5Binding
    {
        get =>_materialEditorHelper5Binding;
        set => SetProperty(ref _materialEditorHelper5Binding, value);
    }
    
    private string _layerEditorHelper1Binding;
    public string LayerEditorHelper1Binding
    {
        get =>_layerEditorHelper1Binding;
        set => SetProperty(ref _layerEditorHelper1Binding, value);
    }
    
    private string _layerEditorHelper2Binding;
    public string LayerEditorHelper2Binding
    {
        get =>_layerEditorHelper2Binding;
        set => SetProperty(ref _layerEditorHelper2Binding, value);
    }
    
    private string _layerEditorHelper3Binding;
    public string LayerEditorHelper3Binding
    {
        get =>_layerEditorHelper3Binding;
        set => SetProperty(ref _layerEditorHelper3Binding, value);
    }
    
    private string _layerEditorHelper4Binding;
    public string LayerEditorHelper4Binding
    {
        get =>_layerEditorHelper4Binding;
        set => SetProperty(ref _layerEditorHelper4Binding, value);
    }
    
    private string _layerEditorHelper5Binding;
    public string LayerEditorHelper5Binding
    {
        get =>_layerEditorHelper5Binding;
        set => SetProperty(ref _layerEditorHelper5Binding, value);
    }
    
    private string _layerEditorHelper6Binding;
    public string LayerEditorHelper6Binding
    {
        get =>_layerEditorHelper6Binding;
        set => SetProperty(ref _layerEditorHelper6Binding, value);
    }
    
    private string _layerEditorHelper7Binding;
    public string LayerEditorHelper7Binding
    {
        get =>_layerEditorHelper7Binding;
        set => SetProperty(ref _layerEditorHelper7Binding, value);
    }
    
    private string _layerEditorHelper8Binding;
    public string LayerEditorHelper8Binding
    {
        get =>_layerEditorHelper8Binding;
        set => SetProperty(ref _layerEditorHelper8Binding, value);
    }
    
    private string _pieceEditorHelper1Binding;
    public string PieceEditorHelper1Binding
    {
        get =>_pieceEditorHelper1Binding;
        set => SetProperty(ref _pieceEditorHelper1Binding, value);
    }
    
    private string _pieceEditorHelper2Binding;
    public string PieceEditorHelper2Binding
    {
        get =>_pieceEditorHelper2Binding;
        set => SetProperty(ref _pieceEditorHelper2Binding, value);
    }
    
    private string _pieceEditorHelper3Binding;
    public string PieceEditorHelper3Binding
    {
        get =>_pieceEditorHelper3Binding;
        set => SetProperty(ref _pieceEditorHelper3Binding, value);
    }
    
    private string _pieceEditorHelper4Binding;
    public string PieceEditorHelper4Binding
    {
        get =>_pieceEditorHelper4Binding;
        set => SetProperty(ref _pieceEditorHelper4Binding, value);
    }
    
    private string _pieceEditorHelper5Binding;
    public string PieceEditorHelper5Binding
    {
        get =>_pieceEditorHelper5Binding;
        set => SetProperty(ref _pieceEditorHelper5Binding, value);
    }
    
    private string _pieceEditorHelper6Binding;
    public string PieceEditorHelper6Binding
    {
        get =>_pieceEditorHelper6Binding;
        set => SetProperty(ref _pieceEditorHelper6Binding, value);
    }
    
    private string _mainWindowHelper1Binding;
    public string MainWindowHelper1Binding
    {
        get =>_mainWindowHelper1Binding;
        set => SetProperty(ref _mainWindowHelper1Binding, value);
    }
    
    private string _mainWindowHelper2Binding;
    public string MainWindowHelper2Binding
    {
        get =>_mainWindowHelper2Binding;
        set => SetProperty(ref _mainWindowHelper2Binding, value);
    }
    
    private string _addBinding;
    public string AddBinding
    {
        get =>_addBinding;
        set => SetProperty(ref _addBinding, value);
    }
    
    private string _availableWithColonBinding;
    public string AvailableWithColonBinding
    {
        get =>_availableWithColonBinding;
        set => SetProperty(ref _availableWithColonBinding, value);
    }
    
    private string _beginBinding;
    public string BeginBinding
    {
        get =>_beginBinding;
        set => SetProperty(ref _beginBinding, value);
    }
    
    private string _centerBinding;
    public string CenterBinding
    {
        get =>_centerBinding;
        set => SetProperty(ref _centerBinding, value);
    }
    
    private string _changeLayersBinding;
    public string ChangeLayersBinding
    {
        get =>_changeLayersBinding;
        set => SetProperty(ref _changeLayersBinding, value);
    }
    
    private string _forceWithColonBinding;
    public string ForceWithColonBinding
    {
        get =>_forceWithColonBinding;
        set => SetProperty(ref _forceWithColonBinding, value);
    }
    
    private string _gravityWithColonBinding;
    public string GravityWithColonBinding
    {
        get =>_gravityWithColonBinding;
        set => SetProperty(ref _gravityWithColonBinding, value);
    }
    
    private string _heightCenterWithColonBinding;
    public string HeightCenterWithColonBinding
    {
        get =>_heightCenterWithColonBinding;
        set => SetProperty(ref _heightCenterWithColonBinding, value);
    }
    
    private string _heightOnSidesWithColonBinding;
    public string HeightOnSidesWithColonBinding
    {
        get =>_heightOnSidesWithColonBinding;
        set => SetProperty(ref _heightOnSidesWithColonBinding, value);
    }
    
    private string _helpBinding;
    public string HelpBinding
    {
        get =>_helpBinding;
        set => SetProperty(ref _helpBinding, value);
    }
    
    private string _inPieceWithColonBinding;
    public string InPieceWithColonBinding
    {
        get =>_inPieceWithColonBinding;
        set => SetProperty(ref _inPieceWithColonBinding, value);
    }
    
    private string _languageWithColonBinding;
    public string LanguageWithColonBinding
    {
        get =>_languageWithColonBinding;
        set => SetProperty(ref _languageWithColonBinding, value);
    }
    
    private string _layersBinding;
    public string LayersBinding
    {
        get =>_layersBinding;
        set => SetProperty(ref _layersBinding, value);
    }
    
    private string _layersWithColonBinding;
    public string LayersWithColonBinding
    {
        get =>_layersWithColonBinding;
        set => SetProperty(ref _layersWithColonBinding, value);
    }
    
    private string _lengthWithColonBinding;
    public string LengthWithColonBinding
    {
        get =>_lengthWithColonBinding;
        set => SetProperty(ref _lengthWithColonBinding, value);
    }
    
    private string _massWithColonBinding;
    public string MassWithColonBinding
    {
        get =>_massWithColonBinding;
        set => SetProperty(ref _massWithColonBinding, value);
    }
    
    private string _materialsWithColonBinding;
    public string MaterialsWithColonBinding
    {
        get =>_materialsWithColonBinding;
        set => SetProperty(ref _materialsWithColonBinding, value);
    }
    
    private string _materialWithColonBinding;
    public string MaterialWithColonBinding
    {
        get =>_materialWithColonBinding;
        set => SetProperty(ref _materialWithColonBinding, value);
    }
    
    private string _modifyBinding;
    public string ModifyBinding
    {
        get =>_modifyBinding;
        set => SetProperty(ref _modifyBinding, value);
    }
    
    private string _moveDownBinding;
    public string MoveDownBinding
    {
        get =>_moveDownBinding;
        set => SetProperty(ref _moveDownBinding, value);
    }
    
    private string _moveUpBinding;
    public string MoveUpBinding
    {
        get =>_moveUpBinding;
        set => SetProperty(ref _moveUpBinding, value);
    }
    
    private string _nameWithColonBinding;
    public string NameWithColonBinding
    {
        get =>_nameWithColonBinding;
        set => SetProperty(ref _nameWithColonBinding, value);
    }
    
    private string _noBinding;
    public string NoBinding
    {
        get =>_noBinding;
        set => SetProperty(ref _noBinding, value);
    }
    
    private string _piecesWithColonBinding;
    public string PiecesWithColonBinding
    {
        get =>_piecesWithColonBinding;
        set => SetProperty(ref _piecesWithColonBinding, value);
    }

    private string _radiusWithColonBinding;
    public string RadiusWithColonBinding
    {
        get =>_radiusWithColonBinding;
        set => SetProperty(ref _radiusWithColonBinding, value);
    }

    private string _removeBinding;
    public string RemoveBinding
    {
        get =>_removeBinding;
        set => SetProperty(ref _removeBinding, value);
    }

    
    private string _sidesBinding;
    public string SidesBinding
    {
        get =>_sidesBinding;
        set => SetProperty(ref _sidesBinding, value);
    }
    
    private string _speedWithColonBinding;
    public string SpeedWithColonBinding
    {
        get =>_speedWithColonBinding;
        set => SetProperty(ref _speedWithColonBinding, value);
    }
    
    private string _widthCenterWithColonBinding;
    public string WidthCenterWithColonBinding
    {
        get =>_widthCenterWithColonBinding;
        set => SetProperty(ref _widthCenterWithColonBinding, value);
    }
    
    private string _widthSidesWithColonBinding;
    public string WidthSidesWithColonBinding
    {
        get =>_widthSidesWithColonBinding;
        set => SetProperty(ref _widthSidesWithColonBinding, value);
    }
}
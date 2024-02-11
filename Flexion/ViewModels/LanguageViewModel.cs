using System.Globalization;
using System.Resources;
using Flexion.Assets.Localization;

namespace Flexion.ViewModels;

public partial class MainViewModel
{
    private void ChangeLanguage()
    {
        ResourceManager resourceManager = new(typeof(Resources));
        AddBinding = resourceManager.GetString("Add", new CultureInfo(Language));
        AvailableWithColonBinding = resourceManager.GetString("AvailableWithColon", new CultureInfo(Language));
        BeginBinding = resourceManager.GetString("Begin", new CultureInfo(Language));
        CenterBinding = resourceManager.GetString("Center", new CultureInfo(Language));
        ChangeLayersBinding = resourceManager.GetString("ChangeLayers", new CultureInfo(Language));
        DeformationWithUnitBinding = resourceManager.GetString("DeformationWithUnit", new CultureInfo(Language));
        ForceWithColonBinding = resourceManager.GetString("ForceWithColon", new CultureInfo(Language));
        GravityWithColonBinding = resourceManager.GetString("GravityWithColon", new CultureInfo(Language));
        HeightCenterWithColonBinding = resourceManager.GetString("HeightCenterWithColon", new CultureInfo(Language));
        HeightOnSidesWithColonBinding = resourceManager.GetString("HeightOnSidesWithColon", new CultureInfo(Language));
        InPieceWithColonBinding = resourceManager.GetString("InPieceWithColon", new CultureInfo(Language));
        LanguageWithColonBinding = resourceManager.GetString("LanguageWithColon", new CultureInfo(Language));
        LayersBinding = resourceManager.GetString("Layers", new CultureInfo(Language));
        LayersWithColonBinding = resourceManager.GetString("LayersWithColon", new CultureInfo(Language));
        LengthWithColonBinding = resourceManager.GetString("LengthWithColon", new CultureInfo(Language));
        LengthWithUnitBinding = resourceManager.GetString("LengthWithUnit", new CultureInfo(Language));
        MassWithColonBinding = resourceManager.GetString("MassWithColon", new CultureInfo(Language));
        MaterialsWithColonBinding = resourceManager.GetString("MaterialsWithColon", new CultureInfo(Language));
        MaterialWithColonBinding = resourceManager.GetString("MaterialWithColon", new CultureInfo(Language));
        ModifyBinding = resourceManager.GetString("Modify", new CultureInfo(Language));
        MoveDownBinding = resourceManager.GetString("MoveDown", new CultureInfo(Language));
        MoveUpBinding = resourceManager.GetString("MoveUp", new CultureInfo(Language));
        NameWithColonBinding = resourceManager.GetString("NameWithColon", new CultureInfo(Language));
        NoBinding = resourceManager.GetString("No", new CultureInfo(Language));
        PiecesWithColonBinding = resourceManager.GetString("PiecesWithColon", new CultureInfo(Language));
        RadiusWithColonBinding = resourceManager.GetString("RadiusWithColon", new CultureInfo(Language));
        RemoveBinding = resourceManager.GetString("Remove", new CultureInfo(Language));
        SidesBinding = resourceManager.GetString("Sides", new CultureInfo(Language));
        SpeedWithColonBinding = resourceManager.GetString("SpeedWithColon", new CultureInfo(Language));
        WidthCenterWithColonBinding = resourceManager.GetString("WidthCenterWithColon", new CultureInfo(Language));
        WidthSidesWithColonBinding = resourceManager.GetString("WidthSidesWithColon", new CultureInfo(Language));
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
    
    private string _deformationWithUnitBinding;
    public string DeformationWithUnitBinding
    {
        get =>_deformationWithUnitBinding;
        set => SetProperty(ref _deformationWithUnitBinding, value);
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
    
    private string _lengthWithUnitBinding;
    public string LengthWithUnitBinding
    {
        get =>_lengthWithUnitBinding;
        set => SetProperty(ref _lengthWithUnitBinding, value);
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
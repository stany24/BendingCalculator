using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using Avalonia;
using Avalonia.Markup.Xaml.Styling;
using BendingCalculator.Assets.Localization.EditorLocalization;
using BendingCalculator.Assets.Localization.EditorLocalization.LayerEditorLocalization;
using BendingCalculator.Assets.Localization.EditorLocalization.LayerEditorLocalization.Helper;
using BendingCalculator.Assets.Localization.EditorLocalization.MaterialEditorLocalization;
using BendingCalculator.Assets.Localization.EditorLocalization.MaterialEditorLocalization.Helper;
using BendingCalculator.Assets.Localization.EditorLocalization.PieceEditorLocalization;
using BendingCalculator.Assets.Localization.EditorLocalization.PieceEditorLocalization.Helper;
using BendingCalculator.Assets.Localization.HelperLocalization;
using BendingCalculator.Assets.Localization.MainLocalization.Helper;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    private static void Translate(string targetLanguage)
    {
        ResourceInclude? translations = Application.Current?.Resources.MergedDictionaries.OfType<ResourceInclude>().FirstOrDefault(x => x.Source?.OriginalString?.Contains("/Lang/") ?? false);

        if (translations != null)
            Application.Current?.Resources.MergedDictionaries.Remove(translations);
            
        Application.Current?.Resources.MergedDictionaries.Add(
            new ResourceInclude(new Uri($"avares://BendingCalculator/Assets/Lang/{targetLanguage}.axaml"))
            {
                Source = new Uri($"avares://BendingCalculator/Assets/Lang/{targetLanguage}.axaml")
            });
    }
    
    private void ChangeLanguage(object? sender, EventArgs eventArgs)
    {
        Translate(Language);
        CultureInfo lang = new(Language);

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

        #region All Editors

        ResourceManager resourceManagerEditor = new(typeof(EditorLocalization));
        AddBinding = resourceManagerEditor.GetString("Add", lang);
        RemoveBinding = resourceManagerEditor.GetString("Remove", lang);
        NameWithColonBinding = resourceManagerEditor.GetString("NameWithColon", lang);

        #endregion

        #region Material Editor

        ResourceManager resourceManagerMaterialEditor = new(typeof(MaterialEditorLocalization));
        TitleMaterialWindowBinding = resourceManagerMaterialEditor.GetString("TitleMaterialWindow", lang);

        #endregion

        #region Material Editor Helper
        
        ResourceManager resourceManagerMaterialEditorHelper = new(typeof(MaterialEditorHelperLocalization));
        MaterialEditorHelper1Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper1", lang);
        MaterialEditorHelper2Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper2", lang);
        MaterialEditorHelper3Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper3", lang);
        MaterialEditorHelper4Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper4", lang);
        MaterialEditorHelper5Binding = resourceManagerMaterialEditorHelper.GetString("MaterialEditorHelper5", lang);

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
    
    private string? _helpBinding;
    public string? HelpBinding
    {
        get =>_helpBinding;
        set => SetProperty(ref _helpBinding, value);
    }
    
    private string? _nameWithColonBinding;
    public string? NameWithColonBinding
    {
        get =>_nameWithColonBinding;
        set => SetProperty(ref _nameWithColonBinding, value);
    }

    private string? _removeBinding;
    public string? RemoveBinding
    {
        get =>_removeBinding;
        set => SetProperty(ref _removeBinding, value);
    }
    
    private string? _titleMaterialWindowBinding;
    public string? TitleMaterialWindowBinding
    {
        get =>_titleMaterialWindowBinding;
        set => SetProperty(ref _titleMaterialWindowBinding, value);
    }

    #endregion
}
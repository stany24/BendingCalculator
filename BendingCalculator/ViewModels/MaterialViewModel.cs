using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Media;
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    #region Bindings
    [ObservableProperty] private ObservableCollection<string> _unit = new() { "GPa", "MPa" };
    [ObservableProperty] private bool _uiEnabledMaterialEditor;
    [ObservableProperty] private ObservableCollection<Material> _materials = new();

    private Color _color;
    public Color Color
    {
        get => _color;
        set
        {
            SetProperty(ref _color, value);
            MaterialColorChanged();
        }
    }

    private Material? _selectedMaterial;
    public Material? SelectedMaterial
    {
        get => _selectedMaterial;
        set
        {
            SetProperty(ref _selectedMaterial, value);
            SelectedMaterialChanged();
        }
    }

    private string _selectedUnit = "GPa";

    public string SelectedUnit
    {
        get => _selectedUnit;
        set
        {
            SetProperty(ref _selectedUnit, value);
            MaterialEChanged();
        }
    }

    private string _materialName = string.Empty;

    public string MaterialName
    {
        get => _materialName;
        set
        {
            SetProperty(ref _materialName, value);
            MaterialNameChanged();
        }
    }

    private double _eValue;

    public double EValue
    {
        get => _eValue;
        set
        {
            SetProperty(ref _eValue, value);
            MaterialEChanged();
        }
    }

    #endregion

    #region Material Edition

    public void CreateNewMaterial()
    {
        Material material = new("new", 69000000000);
        DataBaseCreator.NewMaterial(_connection, material);
        SelectedMaterial = Materials[^1];
    }

    public void RemoveMaterial()
    {
        if (SelectedMaterial is null) return;
        DataBaseRemover.RemoveMaterial(_connection, SelectedMaterial.Id);
        SelectedMaterial = null;
    }

    private void MaterialNameChanged()
    {
        if (SelectedMaterial is null) return;
        if(SelectedMaterial.Name == MaterialName) return;
        SelectedMaterial.Name = MaterialName;
        DataBaseUpdater.UpdateMaterials(_connection, SelectedMaterial);
    }
    
    private void MaterialColorChanged()
    {
        if (SelectedMaterial is null) return;
        if(SelectedMaterial.Color == Color) return;
        SelectedMaterial.Color= Color;
        DataBaseUpdater.UpdateMaterials(_connection, SelectedMaterial);
    }

    private void MaterialEChanged()
    {
        if (SelectedMaterial is null) return;
        int multiplication;
        switch (SelectedUnit)
        {
            case "GPa":
                multiplication = 1000000000;
                break;
            case "MPa":
                multiplication = 1000000;
                break;
            default: return;
        }

        if (Math.Abs(SelectedMaterial.E - EValue * multiplication) < 0.000001) return;
        SelectedMaterial.E = (long)EValue * multiplication;
        DataBaseUpdater.UpdateMaterials(_connection, SelectedMaterial);
    }

    private void ReloadMaterials(object? sender, EventArgs eventArgs)
    {
        List<Material> materials = DataBaseLoader.LoadMaterials(_connection);
        while (materials.Count != Materials.Count)
            if (materials.Count < Materials.Count)
                Materials.RemoveAt(0);
            else
                Materials.Add(new Material());

        for (int i = 0; i < materials.Count; i++)
        {
            Materials[i].Id = materials[i].Id;
            Materials[i].Name = materials[i].Name;
            Materials[i].E = materials[i].E;
        }
    }

    private void SelectedMaterialChanged()
    {
        
        if (SelectedMaterial == null)
        {
            UiEnabledMaterialEditor = false;
            MaterialName = string.Empty;
            EValue = 0;
            Color = Color.FromArgb(0,0,0,0);
            return;
        }

        UiEnabledMaterialEditor = true;
        MaterialName = SelectedMaterial.Name;
        Color = SelectedMaterial.Color;
        if (SelectedMaterial.E >= 1000000000)
        {
            EValue = (double)SelectedMaterial.E / 1000000000;
            SelectedUnit = "GPa";
        }
        else
        {
            EValue = (double)SelectedMaterial.E / 1000000;
            SelectedUnit = "MPa";
        }
    }

    #endregion
}
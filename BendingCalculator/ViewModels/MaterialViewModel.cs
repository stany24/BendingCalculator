using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    #region Bindings

    [ObservableProperty] private ObservableCollection<Material> _materials = new();

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

    [ObservableProperty] private ObservableCollection<string> _unit = new() { "GPa", "MPa" };

    [ObservableProperty] private bool _uiEnabledMaterialEditor;

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
        DataBaseRemover.RemoveMaterial(_connection, SelectedMaterial.MaterialId);
        SelectedMaterial = null;
    }

    private void MaterialNameChanged()
    {
        if (SelectedMaterial is null) return;
        SelectedMaterial.Name = MaterialName;
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
            Materials[i].MaterialId = materials[i].MaterialId;
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
            return;
        }

        UiEnabledMaterialEditor = true;
        MaterialName = SelectedMaterial.Name;
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
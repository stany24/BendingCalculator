using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    #region Bindings

    [ObservableProperty] private ObservableCollection<Unit> _unit = new() { Logic.Math.Unit.GPa, Logic.Math.Unit.MPa };
    [ObservableProperty] private bool _uiEnabledMaterialEditor;
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

    #endregion

    #region Material Edition

    public void CreateNewMaterial()
    {
        Material material = new("new", 69);
        DataBaseCreator.NewMaterial(_connection, material);
        SelectedMaterial = Materials[^1];
    }

    public void RemoveMaterial()
    {
        if (SelectedMaterial is null) return;
        DataBaseRemover.RemoveMaterial(_connection, SelectedMaterial.Id);
        SelectedMaterial = null;
    }

    private void SelectedMaterialPropertyChanged()
    {
        if (SelectedMaterial is null) return;
        DataBaseUpdater.UpdateMaterial(_connection, SelectedMaterial);
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
            Materials[i].Color = materials[i].Color;
        }
    }

    private void SelectedMaterialChanged()
    {
        if (SelectedMaterial == null)
        {
            UiEnabledMaterialEditor = false;
            return;
        }
        SelectedMaterial.PropertyChanged += (_, e) => SelectedMaterialPropertyChanged(e);
        UiEnabledMaterialEditor = true;
    }
    
    private void SelectedMaterialPropertyChanged(PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(SelectedMaterial.Name):
            case nameof(SelectedMaterial.Color):
            case nameof(SelectedMaterial.E):
            case nameof(SelectedMaterial.Unit):
                SelectedMaterialPropertyChanged();
                break;
        }
    }

    #endregion
}
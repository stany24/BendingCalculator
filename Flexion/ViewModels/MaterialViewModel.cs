using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Flexion.Database.Actions;
using Flexion.Logic;

namespace Flexion.ViewModels;

public partial class MainViewModel
{
    private ObservableCollection<Material> _materials = new();
    public ObservableCollection<Material> Materials { 
        get => _materials;
        set => SetProperty(ref _materials, value);
    }
    
    private ObservableCollection<Material> _selectedMaterials = new();
    public ObservableCollection<Material> SelectedMaterials { 
        get => _selectedMaterials;
        set => SetProperty(ref _selectedMaterials, value);
    }
    
    private ObservableCollection<string> _unit = new(){"GPa","MPa"};
    public ObservableCollection<string> Unit { 
        get => _unit;
        set => SetProperty(ref _unit, value);
    }
    
    private string _selectedUnit = "GPa";
    public string SelectedUnit { 
        get => _selectedUnit;
        set => SetProperty(ref _selectedUnit, value);
    }
    
    private void ReloadMaterials()
    {
        List<Material> materials = DataBaseLoader.LoadMaterials(_connection);
        while (materials.Count != Materials.Count)
        {
            if (materials.Count < Materials.Count)
            {
                Materials.RemoveAt(0);
            }
            else
            {
                Materials.Add(new Material());
            }
        }

        for (int i = 0; i < materials.Count; i++)
        {
            Materials[i].MaterialId = materials[i].MaterialId;
            Materials[i].Name = materials[i].Name;
            Materials[i].E = materials[i].E;
        }
    }
    
    private string _materialName = string.Empty;
    public string Name { get => _materialName;
        set
        {
            _materialName = value;
            MaterialNameChanged();
        }
    }

    private void MaterialNameChanged()
    {
        List<Material> materials = new(SelectedMaterials);
        foreach (Material material in materials)
        {
            material.Name = Name;
        }
        DataBaseUpdater.UpdateMaterials(_connection,materials);
    }

    private double _eValue = 69;

    public double EValue
    {
        get => _eValue;
        set
        {
            _eValue = value;
            MaterialEChanged();
        }
    }

    private void MaterialEChanged()
    {
        int multiplication;
        switch (SelectedUnit)
        {
            case "GPa" : multiplication = 1000000000;
                break;
            case "MPa" : multiplication = 1000000;
                break;
            default: return;
        }

        List<Material> materials = new(SelectedMaterials);
        foreach (Material material in materials)
        {
            material.E = (long)EValue*multiplication;
        }
        DataBaseUpdater.UpdateMaterials(_connection,materials);
    }

    public int SelectedMaterialIndex { get; set; }
    public void RemoveMaterials()
    {
        int index = SelectedMaterialIndex;
        List<long> selected = SelectedMaterials.Select(x => x.MaterialId).ToList();
        foreach (long id in selected)
        {
            DataBaseRemover.RemoveMaterial(_connection,id);
        }
        if (index <= 0) return;
        SelectedMaterialIndex = _materials.Count > index ? index : _materials.Count;
    }

    public void CreateNewMaterial()
    {
        int multiplication;
        switch (SelectedUnit)
        {
            case "GPa" : multiplication = 1000000000;
                break;
            case "MPa" : multiplication = 1000000;
                break;
            default: return;
        }
        Material material = new(Name,Convert.ToInt64(EValue*multiplication));
        DataBaseCreator.NewMaterial(_connection,material);
    }
}
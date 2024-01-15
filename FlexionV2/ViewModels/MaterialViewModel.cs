using System.Collections.Generic;
using System.Collections.ObjectModel;
using FlexionV2.Database.Actions;
using FlexionV2.Logic;

namespace FlexionV2.ViewModels;

public partial class MainViewModel
{
    private ObservableCollection<Material> _materials = new();
    public ObservableCollection<Material> Materials { 
        get => _materials;
        set => SetProperty(ref _materials, value);
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

    public void NewMaterial(Material material)
    {
        DataBaseCreator.NewMaterial(_connection,material);
    }

    public void UpdateMaterials(List<Material> materials)
    {
        DataBaseUpdater.UpdateMaterials(_connection,materials);
    }

    public void RemoveMaterial(long id)
    {
        DataBaseRemover.RemoveMaterial(_connection,id);
    }
}
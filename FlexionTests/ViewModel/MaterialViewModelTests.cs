using FlexionV2.Database.Actions;
using FlexionV2.Logic;
using FlexionV2.ViewModels;
using Xunit;

namespace FlexionTests.ViewModel;

public class MaterialViewModelTests
{
    private MainViewModel _model = new(DataBaseInitializer.InitializeDatabaseConnection());

    [Fact]
    public void ClearDatabase()
    {
        while (_model.Materials.Count> 0)
        {
            _model.RemoveMaterial(_model.Materials[0].MaterialId);
        }
        Assert.Empty(_model.Materials);
    }
    
    [Fact]
    public void CreateNewMaterialTest()
    {
        const string name = "test";
        const long e = 55000000000;
        int id = _model.Materials.Count;
        _model.NewMaterial(new Material(name,e));
        Assert.Equal(id+1,_model.Materials.Count);
        Assert.Equal(name,_model.Materials[id].Name);
        Assert.Equal(e,_model.Materials[id].E);
    }

    [Fact]
    public void UpdateMaterialTest()
    {
        const string name = "test2";
        const long e = 23000000000;
        int count = _model.Materials.Count;
        List<Material> materials = new(_model.Materials);
        materials[0].Name = name;
        materials[0].E = e;
        _model.UpdateMaterials(materials);
        Assert.Equal(count,_model.Materials.Count);
        Assert.Equal(name,_model.Materials[0].Name);
        Assert.Equal(e,_model.Materials[0].E);
    }
}
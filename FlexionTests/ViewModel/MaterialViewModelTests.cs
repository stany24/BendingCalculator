using Flexion.Database.Actions;
using Flexion.ViewModels;
using Xunit;

namespace FlexionTests.ViewModel;

public class MaterialViewModelTests
{
    private readonly MainViewModel _model = new(DataBaseInitializer.InitializeDatabaseConnection());
    
    [Fact]
    public void CreateNewMaterialTest()
    {
        int before = _model.Materials.Count;
        _model.CreateNewMaterial();
        Assert.Equal(_model.Materials.Count,before+1);
    }

    [Fact]
    public void UpdateMaterialTest()
    {

    }
    
    [Fact]
    public void RemoveMaterialTest()
    {
        Random rand = new();
        int nbMaterial = rand.Next(1, 11);
        for (int i = 0; i < nbMaterial; i++)
        {
            _model.CreateNewMaterial();
            if (rand.Next(0, 2) != 1) continue;
            _model.SelectedMaterials.Add(_model.Materials[^1]);
        }
        int finalCount = _model.Materials.Count - _model.SelectedMaterials.Count;
        _model.RemoveMaterials();
        Assert.Equal(finalCount,_model.Materials.Count);
    }
}
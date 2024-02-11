using Flexion.Database.Actions;
using Flexion.ViewModels;
using Xunit;

namespace FlexionTests.ViewModel;

public class MaterialViewModelTests
{
    private MainViewModel _model = new(DataBaseInitializer.InitializeDatabaseConnection());
    
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

    }
}
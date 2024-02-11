using Flexion.Database.Actions;
using Flexion.ViewModels;
using Xunit;

namespace FlexionTests.ViewModel;

public class LayerViewModelTests
{
    private readonly MainViewModel _model = new(DataBaseInitializer.InitializeDatabaseConnection());
    
    [Fact]
    public void CreateNewLayerTest()
    {
        int before = _model.Layers.Count;
        _model.CreateNewLayer();
        Assert.Equal(_model.Layers.Count,before+1);
    }

    [Fact]
    public void UpdateLayerTest()
    {

    }
    
    [Fact]
    public void RemoveLayerTest()
    {

    }
}
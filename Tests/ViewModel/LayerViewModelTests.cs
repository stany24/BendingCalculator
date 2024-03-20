using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using BendingCalculator.ViewModels;
using Xunit;

namespace Tests.ViewModel;

[Collection("SettingsCollection")]
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
        _model.CreateNewMaterial();
        _model.CreateNewMaterial();
        _model.CreateNewLayer();
        _model.SelectedLayer = _model.Layers[0];
        Layer layer = new(_model.Materials[0],1,1,1,1);
        _model.WidthCenter = 1000;
        _model.WidthSide = 1000;
        _model.HeightCenter = 1000;
        _model.HeightSide = 1000;
        _model.SelectedMaterialForLayer = _model.Materials[0];
        Assert.Equal(layer.WidthAtCenter,_model.SelectedLayer.WidthAtCenter);
        Assert.Equal(layer.WidthOnSides,_model.SelectedLayer.WidthOnSides);
        Assert.Equal(layer.HeightAtCenter,_model.SelectedLayer.HeightAtCenter);
        Assert.Equal(layer.HeightOnSides,_model.SelectedLayer.HeightOnSides);
        Assert.Equal(layer.Material?.Name,_model.SelectedLayer.Material?.Name);
        Assert.Equal(layer.Material?.E,_model.SelectedLayer.Material?.E);
        Assert.Equal(layer.Material?.MaterialId,_model.SelectedLayer.Material?.MaterialId);
    }
    
    [Fact]
    public void RemoveLayerTest()
    {
        Random rand = new();
        int nbLayer = rand.Next(1, 11);
        for (int i = 0; i < nbLayer; i++)
        {
            _model.CreateNewLayer();
            if (rand.Next(0, 2) != 1) continue;
            _model.SelectedLayer = _model.Layers[^1];
        }
        int finalCount = _model.Layers.Count - 1;
        _model.RemoveLayers();
        Assert.Equal(finalCount,_model.Layers.Count);
    }
}
using FlexionV2.Database.Actions;
using FlexionV2.Logic;
using FlexionV2.ViewModels;
using Xunit;

namespace FlexionTests.ViewModel;

public class LayerViewModelTests
{
    private readonly MainViewModel _model = new(DataBaseInitializer.InitializeDatabaseConnection());

    [Fact]
    public void ClearDatabase()
    {
        while (_model.Layers.Count> 0)
        {
            _model.RemoveLayer(_model.Layers[0].LayerId);
        }
        Assert.Empty(_model.Layers);
        while (_model.Materials.Count> 0)
        {
            _model.RemoveMaterial(_model.Materials[0].MaterialId);
        }
        Assert.Empty(_model.Materials);
    }
    
    [Fact]
    public void CreateNewLayerTest()
    {
        const double widthCenter = 0.3;
        const double widthSides = 0.3;
        const double heightCenter = 0.01;
        const double heightSides = 0.01;
        _model.NewMaterial(new Material("test",69000000000));
        Material material = _model.Materials[^1];
        int id = _model.Layers.Count;
        _model.NewLayer(new Layer(material, widthCenter, widthSides, heightCenter, heightSides));
        Assert.Equal(id+1,_model.Layers.Count);
        Assert.Equal(widthCenter,_model.Layers[id].WidthAtCenter);
        Assert.Equal(widthSides,_model.Layers[id].WidthOnSides);
        Assert.Equal(heightCenter,_model.Layers[id].HeightAtCenter);
        Assert.Equal(heightSides,_model.Layers[id].HeightOnSides);
        Assert.Equal(material.Name,_model.Layers[id].Material.Name);
        Assert.Equal(material.E,_model.Layers[id].Material.E);
    }

    [Fact]
    public void UpdateLayerTest()
    {
        const double widthCenter = 0.2;
        const double widthSides = 0.2;
        const double heightCenter = 0.02;
        const double heightSides = 0.02;
        _model.NewMaterial(new Material("test2",23000000000));
        Material material = _model.Materials[^1];
        int count = _model.Layers.Count;
        List<Layer> layers = new(_model.Layers);
        layers[0].WidthAtCenter = widthCenter;
        layers[0].WidthOnSides = widthSides;
        layers[0].HeightAtCenter = heightCenter;
        layers[0].HeightOnSides = heightSides;
        layers[0].Material = material;
        _model.UpdateLayers(layers);
        Assert.Equal(count,_model.Layers.Count);
        Assert.Equal(widthCenter,_model.Layers[0].WidthAtCenter);
        Assert.Equal(widthSides,_model.Layers[0].WidthOnSides);
        Assert.Equal(heightCenter,_model.Layers[0].HeightAtCenter);
        Assert.Equal(heightSides,_model.Layers[0].HeightOnSides);
        Assert.Equal(material.Name,_model.Layers[0].Material.Name);
        Assert.Equal(material.E,_model.Layers[0].Material.E);
    }
}
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using BendingCalculator.ViewModels;

namespace BendingCalculatorTests.ViewModel;

[TestClass]
public class LayerViewModelTests
{
    private readonly MainViewModel _model = new(DataBaseInitializer.InitializeDatabaseConnection());

    [TestInitialize]
    public void Clear()
    {
        while (_model.Pieces.Count > 1)
        {
            _model.SelectedPiece = _model.Pieces[0];
            _model.RemovePiece();
        }
        while (_model.Layers.Count > 1)
        {
            _model.SelectedLayer = _model.Layers[0];
            _model.RemoveLayer();
        }
        while (_model.Materials.Count > 1)
        {
            _model.SelectedMaterial = _model.Materials[0];
            _model.RemoveMaterial();
        }
    }
    
    [TestMethod]
    public void CreateNewLayerTest()
    {
        int before = _model.Layers.Count;
        _model.CreateNewLayer();
        Assert.AreEqual(_model.Layers.Count,before+1);
    }

    [TestMethod]
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
        Assert.AreEqual(layer.WidthAtCenter,_model.SelectedLayer.WidthAtCenter);
        Assert.AreEqual(layer.WidthOnSides,_model.SelectedLayer.WidthOnSides);
        Assert.AreEqual(layer.HeightAtCenter,_model.SelectedLayer.HeightAtCenter);
        Assert.AreEqual(layer.HeightOnSides,_model.SelectedLayer.HeightOnSides);
        Assert.AreEqual(layer.Material?.Name,_model.SelectedLayer.Material?.Name);
        Assert.AreEqual(layer.Material?.E,_model.SelectedLayer.Material?.E);
        Assert.AreEqual(layer.Material?.MaterialId,_model.SelectedLayer.Material?.MaterialId);
    }
    
    [TestMethod]
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
        _model.RemoveLayer();
        Assert.AreEqual(finalCount,_model.Layers.Count);
    }
}
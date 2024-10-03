using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using BendingCalculator.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BendingCalculatorTests.ViewModel;

[TestClass]
public class LayerViewModelTests
{
    private readonly MainViewModel _model =
        new(DataBaseInitializer.InitializeDatabaseConnection() ?? throw new InvalidOperationException());

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
        Assert.AreEqual(_model.Layers.Count, before + 1);
    }

    [TestMethod]
    public void UpdateLayerTest()
    {
        _model.CreateNewMaterial();
        _model.CreateNewMaterial();
        _model.CreateNewLayer();
        _model.SelectedLayer = _model.Layers[0];
        Material material = _model.Materials[0];
        const int value = 1000;
        _model.SelectedLayer.WidthAtCenter = 1000;
        _model.SelectedLayer.WidthOnSides = 1000;
        _model.SelectedLayer.HeightAtCenter = 1000;
        _model.SelectedLayer.HeightOnSides = 1000;
        _model.SelectedLayer.Material = _model.Materials[0];
        Assert.AreEqual(value, _model.SelectedLayer.WidthAtCenter);
        Assert.AreEqual(value, _model.SelectedLayer.WidthOnSides);
        Assert.AreEqual(value, _model.SelectedLayer.HeightAtCenter);
        Assert.AreEqual(value, _model.SelectedLayer.HeightOnSides);
        Assert.AreEqual(material.Name, _model.SelectedLayer.Material?.Name);
        Assert.AreEqual(material.E, _model.SelectedLayer.Material?.E);
        Assert.AreEqual(material.Id, _model.SelectedLayer.Material?.Id);
        Assert.AreEqual(material.Unit, _model.SelectedLayer.Material?.Unit);
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
        Assert.AreEqual(finalCount, _model.Layers.Count);
    }
}
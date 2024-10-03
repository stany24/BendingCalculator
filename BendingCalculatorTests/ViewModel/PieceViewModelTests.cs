using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using BendingCalculator.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BendingCalculatorTests.ViewModel;

[TestClass]
public class PieceViewModelTests
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
    public void CreateNewPieceTest()
    {
        int before = _model.Pieces.Count;
        _model.CreateNewPiece();
        Assert.AreEqual(_model.Pieces.Count, before + 1);
    }

    [TestMethod]
    public void UpdatePieceTest()
    {
        _model.CreateNewPiece();
        _model.CreateNewLayer();
        _model.SelectedPiece = _model.Pieces[^1];
        _model.SelectedAvailableLayers.Add(_model.Layers[^1]);
        Layer layer = _model.Layers[^1];
        _model.AddLayerToPiece();
        const int length = 770;
        const string name = "test";
        _model.SelectedPiece.Length = length;
        _model.SelectedPiece.Name = name;
        Assert.AreEqual(name, _model.SelectedPiece.Name);
        Assert.AreEqual(length, _model.SelectedPiece.Length);
        Assert.AreEqual(1, _model.SelectedPiece.Layers.Count);
        Assert.AreEqual(layer.WidthAtCenter, _model.SelectedPiece.Layers[0].WidthAtCenter);
        Assert.AreEqual(layer.WidthOnSides, _model.SelectedPiece.Layers[0].WidthOnSides);
        Assert.AreEqual(layer.HeightAtCenter, _model.SelectedPiece.Layers[0].HeightAtCenter);
        Assert.AreEqual(layer.HeightOnSides, _model.SelectedPiece.Layers[0].HeightOnSides);
        Assert.AreEqual(layer.Id, _model.SelectedPiece.Layers[0].Id);
        Assert.AreEqual(layer.Material?.Name, _model.SelectedPiece.Layers[0].Material?.Name);
        Assert.AreEqual(layer.Material?.E, _model.SelectedPiece.Layers[0].Material?.E);
        Assert.AreEqual(layer.Material?.Id, _model.SelectedPiece.Layers[0].Material?.Id);
    }

    [TestMethod]
    public void RemovePieceTest()
    {
        Random rand = new();
        int nbPiece = rand.Next(1, 11);
        for (int i = 0; i < nbPiece; i++)
        {
            _model.CreateNewPiece();
            if (rand.Next(0, 2) != 1) continue;
            _model.SelectedPiece = _model.Pieces[^1];
        }

        int finalCount = _model.Pieces.Count - 1;
        _model.RemovePiece();
        Assert.AreEqual(finalCount, _model.Pieces.Count);
    }
}
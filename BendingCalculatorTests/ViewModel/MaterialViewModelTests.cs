using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using BendingCalculator.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BendingCalculatorTests.ViewModel;

[TestClass]
public class MaterialViewModelTests
{
    private readonly MainViewModel _model = new(DataBaseInitializer.InitializeDatabaseConnection() ?? throw new InvalidOperationException());
    
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
    public void CreateNewMaterialTest()
    {
        int before = _model.Materials.Count;
        _model.CreateNewMaterial();
        Assert.AreEqual(_model.Materials.Count,before+1);
    }

    [TestMethod]
    public void UpdateMaterialTest()
    {
        _model.SelectedUnit = "GPa";
        _model.CreateNewMaterial();
        _model.SelectedMaterial = _model.Materials[0];
        Material material = new("test",33000000000);
        _model.MaterialName = "test";
        _model.EValue = 33;
        Assert.AreEqual(material.Name,_model.SelectedMaterial.Name);
        Assert.AreEqual(material.E,_model.SelectedMaterial.E);
    }
    
    [TestMethod]
    public void RemoveMaterialTest()
    {
        Random rand = new();
        int nbMaterial = rand.Next(1, 11);
        for (int i = 0; i < nbMaterial; i++)
        {
            _model.CreateNewMaterial();
            if (rand.Next(0, 2) != 1) continue;
            _model.SelectedMaterial = _model.Materials[^1];
        }
        int finalCount = _model.Materials.Count - 1;
        _model.RemoveMaterial();
        Assert.AreEqual(finalCount,_model.Materials.Count);
    }
}
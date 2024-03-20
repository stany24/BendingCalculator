using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using BendingCalculator.ViewModels;

namespace BendingCalculatorTests.ViewModel;

[TestClass]
public class PieceViewModelTests
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
    public void CreateNewPieceTest()
    {
        int before = _model.Pieces.Count;
        _model.CreateNewPiece();
        Assert.AreEqual(_model.Pieces.Count,before+1);
    }

    [TestMethod]
    public void UpdatePieceTest()
    {
        _model.CreateNewPiece();
        _model.CreateNewLayer();
        _model.SelectedPiece = _model.Pieces[^1];
        _model.PieceCurrentlyModifiedId = _model.SelectedPiece.PieceId;
        Piece piece = new(0.77,"test");
        piece.Layers.Add(_model.Layers[^1]);
        _model.SelectedAvailableLayers.Add(_model.Layers[^1]);
        _model.AddLayerToPiece();
        _model.PieceLength = 770;
        _model.PieceName = "test";
        Assert.AreEqual(piece.Name,_model.SelectedPiece.Name);
        Assert.AreEqual(piece.Length,_model.SelectedPiece.Length);
        Assert.AreEqual(piece.Layers.Count,_model.SelectedPiece.Layers.Count);
        Assert.AreEqual(piece.Layers[^1].WidthAtCenter,_model.SelectedPiece.Layers[0].WidthAtCenter);
        Assert.AreEqual(piece.Layers[^1].WidthOnSides,_model.SelectedPiece.Layers[0].WidthOnSides);
        Assert.AreEqual(piece.Layers[^1].HeightAtCenter,_model.SelectedPiece.Layers[0].HeightAtCenter);
        Assert.AreEqual(piece.Layers[^1].HeightOnSides,_model.SelectedPiece.Layers[0].HeightOnSides);
        Assert.AreEqual(piece.Layers[^1].LayerId,_model.SelectedPiece.Layers[0].LayerId);
        Assert.AreEqual(piece.Layers[^1].Material?.Name,_model.SelectedPiece.Layers[0].Material?.Name);
        Assert.AreEqual(piece.Layers[^1].Material?.E,_model.SelectedPiece.Layers[0].Material?.E);
        Assert.AreEqual(piece.Layers[^1].Material?.MaterialId,_model.SelectedPiece.Layers[0].Material?.MaterialId);
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
        Assert.AreEqual(finalCount,_model.Pieces.Count);
    }
}
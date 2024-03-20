using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using BendingCalculator.ViewModels;
using Xunit;

namespace Tests.ViewModel;

[Collection("SettingsCollection")]
public class PieceViewModelTests
{
    private readonly MainViewModel _model = new(DataBaseInitializer.InitializeDatabaseConnection());
    
    [Fact]
    public void CreateNewPieceTest()
    {
        int before = _model.Pieces.Count;
        _model.CreateNewPiece();
        Assert.Equal(_model.Pieces.Count,before+1);
    }

    [Fact]
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
        Assert.Equal(piece.Name,_model.SelectedPiece.Name);
        Assert.Equal(piece.Length,_model.SelectedPiece.Length);
        Assert.Equal(piece.Layers.Count,_model.SelectedPiece.Layers.Count);
        Assert.Equal(piece.Layers[^1].WidthAtCenter,_model.SelectedPiece.Layers[0].WidthAtCenter);
        Assert.Equal(piece.Layers[^1].WidthOnSides,_model.SelectedPiece.Layers[0].WidthOnSides);
        Assert.Equal(piece.Layers[^1].HeightAtCenter,_model.SelectedPiece.Layers[0].HeightAtCenter);
        Assert.Equal(piece.Layers[^1].HeightOnSides,_model.SelectedPiece.Layers[0].HeightOnSides);
        Assert.Equal(piece.Layers[^1].LayerId,_model.SelectedPiece.Layers[0].LayerId);
        Assert.Equal(piece.Layers[^1].Material?.Name,_model.SelectedPiece.Layers[0].Material?.Name);
        Assert.Equal(piece.Layers[^1].Material?.E,_model.SelectedPiece.Layers[0].Material?.E);
        Assert.Equal(piece.Layers[^1].Material?.MaterialId,_model.SelectedPiece.Layers[0].Material?.MaterialId);
    }
    
    [Fact]
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
        _model.RemovePieces();
        Assert.Equal(finalCount,_model.Pieces.Count);
    }
}
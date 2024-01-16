using FlexionV2.Database.Actions;
using FlexionV2.Logic;
using FlexionV2.ViewModels;
using Xunit;

namespace FlexionTests.ViewModel;

public class PieceViewModelTests
{
    private readonly MainViewModel _model = new(DataBaseInitializer.InitializeDatabaseConnection());

    [Fact]
    public void ClearDatabase()
    {
        while (_model.Pieces.Count> 0)
        {
            _model.RemovePiece(_model.Pieces[0].PieceId);
        }
        Assert.Empty(_model.Pieces);
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
    public void CreateNewPieceTest()
    {
        const double length = 1;
        const string name = "test";
        _model.NewMaterial(new Material("test",69000000000));
        _model.NewLayer(new Layer(_model.Materials[^1], 0.03, 0.03, 0.01, 0.01));
        int id = _model.Pieces.Count;
        _model.NewPiece(new Piece(length,name));
        Assert.Equal(id+1,_model.Pieces.Count);
        Assert.Equal(length,_model.Pieces[id].Length);
        Assert.Equal(name,_model.Pieces[id].Name);
    }

    [Fact]
    public void UpdatePieceTest()
    {
        const string name = "newName";
        const double length = 2;
        _model.NewMaterial(new Material("test1",55000000000));
        _model.NewMaterial(new Material("test2",69000000000));
        _model.NewLayer(new Layer(_model.Materials[^1], 0.01, 0.01, 0.03, 0.03));
        _model.NewLayer(new Layer(_model.Materials[^2], 0.03, 0.03, 0.01, 0.01));
        _model.NewPiece(new Piece(1,"name"));
        Piece piece = _model.Pieces[^1];
        List<Layer> layers = new(){ _model.Layers[^1], _model.Layers[^2], _model.Layers[^1] };
        piece.Name = name;
        piece.Length = length;
        _model.UpdatePieces(new List<Piece>{piece});
        _model.UpdateLayersInPiece(piece.PieceId,layers);
        Assert.Equal(name,_model.Pieces[^1].Name);
        Assert.Equal(length,_model.Pieces[^1].Length);
        Assert.Equal(layers,_model.Pieces[^1].Layers);
    }
}
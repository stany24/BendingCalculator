using System.Data.SQLite;
using BendingCalculator.Logic.Math;

namespace BendingCalculator.Database.Actions;

public static class DataBaseUpdater
{
    public static void UpdateMaterials(SQLiteConnection connection, Material material)
    {
        using SQLiteCommand cmd = new(
            "UPDATE Material SET Name = @WidthAtCenter, E = @WidthOnSides WHERE MaterialId= @Id;", connection);
        cmd.Parameters.AddWithValue("@WidthAtCenter", material.Name);
        cmd.Parameters.AddWithValue("@WidthOnSides", material.E);
        cmd.Parameters.AddWithValue("@Id", material.MaterialId);
        cmd.ExecuteNonQuery();
        DataBaseEvents.RaiseMaterialsChangedEvent();
    }

    public static void UpdateLayers(SQLiteConnection connection, Layer layer)
    {
        using SQLiteCommand cmd = new(
            "UPDATE Layer SET WidthAtCenter = @WidthAtCenter, WidthOnSides = @WidthOnSides, HeightAtCenter = @HeightAtCenter , HeightOnSides = @HeightOnSides , MaterialId = @MaterialId WHERE LayerId= @Id;",
            connection);
        cmd.Parameters.AddWithValue("@WidthAtCenter", layer.WidthAtCenter);
        cmd.Parameters.AddWithValue("@WidthOnSides", layer.WidthOnSides);
        cmd.Parameters.AddWithValue("@HeightAtCenter", layer.HeightAtCenter);
        cmd.Parameters.AddWithValue("@HeightOnSides", layer.HeightOnSides);
        cmd.Parameters.AddWithValue("@MaterialId", layer.Material?.MaterialId);
        cmd.Parameters.AddWithValue("@Id", layer.LayerId);
        cmd.ExecuteNonQuery();
        DataBaseEvents.RaiseLayersChangedEvent();
    }

    public static void UpdatePieces(SQLiteConnection connection, Piece piece)
    {
        using SQLiteCommand cmd1 = new(
            "UPDATE Piece SET Name = @Name, Length = @Length WHERE PieceId= @Id;", connection);
        cmd1.Parameters.AddWithValue("@Name", piece.Name);
        cmd1.Parameters.AddWithValue("@Length", piece.Length);
        cmd1.Parameters.AddWithValue("@Id", piece.PieceId);
        cmd1.ExecuteNonQuery();
        DataBaseEvents.RaisePiecesChangedEvent();
    }

    public static void AddLayerToPiece(SQLiteConnection connection, long pieceId, Layer layer)
    {
        using SQLiteCommand cmd1 = new("SELECT * FROM PieceToLayer WHERE PieceId = @PieceId", connection);
        cmd1.Parameters.AddWithValue("@PieceId", pieceId);
        using SQLiteDataReader reader = cmd1.ExecuteReader();
        int id = 0;
        while (reader.Read()) id++;
        using SQLiteCommand cmd2 =
            new("INSERT INTO PieceToLayer (PieceId,LayerId,LayerOrder) VALUES (@PieceId, @LayerId, @LayerOrder);",
                connection);
        cmd2.Parameters.AddWithValue("@PieceId", pieceId);
        cmd2.Parameters.AddWithValue("@LayerId", layer.LayerId);
        cmd2.Parameters.AddWithValue("@LayerOrder", id);
        cmd2.ExecuteNonQuery();
        DataBaseEvents.RaisePiecesChangedEvent();
    }

    public static void RemoveLayerToPiece(SQLiteConnection connection, long pieceId, int nbLayer, long idToRemove)
    {
        using SQLiteCommand remove =
            new("DELETE FROM PieceToLayer WHERE PieceId = @PieceId and LayerOrder = @LayerOrder", connection);
        remove.Parameters.AddWithValue("@PieceId", pieceId);
        remove.Parameters.AddWithValue("@LayerOrder", idToRemove);
        remove.ExecuteNonQuery();
        for (long i = idToRemove; i < nbLayer - 1; i++)
        {
            using SQLiteCommand changeOrder = new(
                "UPDATE PieceToLayer SET LayerOrder = @NewLayerOrder WHERE PieceId= @Id And LayerOrder = @OldLayerOrder;",
                connection);
            changeOrder.Parameters.AddWithValue("@NewLayerOrder", i);
            changeOrder.Parameters.AddWithValue("@OldLayerOrder", i + 1);
            changeOrder.Parameters.AddWithValue("@Id", pieceId);
            changeOrder.ExecuteNonQuery();
        }

        DataBaseEvents.RaisePiecesChangedEvent();
    }
}
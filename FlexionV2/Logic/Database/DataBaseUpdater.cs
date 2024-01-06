using System.Data.SQLite;

namespace FlexionV2.Logic.Database;

public static class DataBaseUpdater
{
    public static void UpdateMaterial(SQLiteConnection connection,Material? material)
    {
        if(material == null){return;}
        using SQLiteCommand cmd = new(
            "UPDATE Material SET Name = @WidthAtCenter, E = @WidthOnSides WHERE MaterialId= @Id;", connection);
        cmd.Parameters.AddWithValue("@WidthAtCenter",material.Name);
        cmd.Parameters.AddWithValue("@WidthOnSides",material.E);
        cmd.Parameters.AddWithValue("@Id",material.MaterialId);
        cmd.ExecuteNonQuery();
    }
    
    public static void UpdateLayer(SQLiteConnection connection,Layer? layer)
    {
        if(layer == null){return;}
        using SQLiteCommand cmd = new(
            "UPDATE Layer SET WidthAtCenter = @WidthAtCenter, WidthOnSides = @WidthOnSides, HeightAtCenter = @HeightAtCenter , HeightOnSides = @HeightOnSides , MaterialId = @MaterialId WHERE LayerId= @Id;", connection);
        cmd.Parameters.AddWithValue("@WidthAtCenter",layer.WidthAtCenter);
        cmd.Parameters.AddWithValue("@WidthOnSides",layer.WidthOnSides);
        cmd.Parameters.AddWithValue("@HeightAtCenter",layer.HeightAtCenter);
        cmd.Parameters.AddWithValue("@HeightOnSides",layer.HeightOnSides);
        cmd.Parameters.AddWithValue("@MaterialId", layer.Material?.MaterialId);
        cmd.Parameters.AddWithValue("@Id",layer.LayerId);
        cmd.ExecuteNonQuery();
    }
    
    public static void UpdatePiece(SQLiteConnection connection,Piece? piece)
    {
        if(piece == null){return;}
        using SQLiteCommand cmd1 = new(
            "UPDATE Piece SET Name = @Name, Length = @Length, Eref = @Eref WHERE PieceId= @Id;", connection);
        cmd1.Parameters.AddWithValue("@Name",piece.Name);
        cmd1.Parameters.AddWithValue("@Length",piece.Length);
        cmd1.Parameters.AddWithValue("@Eref",piece.Eref);
        cmd1.Parameters.AddWithValue("@Id",piece.PieceId);
        cmd1.ExecuteNonQuery();
        using SQLiteCommand cmd2 = new("DELETE FROM PieceToLayer WHERE PieceId = @PieceId", connection);
        cmd2.Parameters.AddWithValue("@PieceId",piece.PieceId);
        cmd2.ExecuteNonQuery();
        for (int i = 0; i < piece.Layers.Count; i++)
        {
            using SQLiteCommand cmd3 = new("INSERT INTO PieceToLayer (PieceId,LayerId,LayerOrder) VALUES (@PieceId, @LayerId, @LayerOrder);", connection);
            cmd3.Parameters.AddWithValue("@PieceId",piece.PieceId);
            cmd3.Parameters.AddWithValue("@LayerId",piece.Layers[i].LayerId);
            cmd3.Parameters.AddWithValue("@LayerOrder",i);
            cmd3.ExecuteNonQuery();
        }
    }
}
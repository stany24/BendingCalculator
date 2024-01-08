using System.Collections.Generic;
using System.Data.SQLite;
using FlexionV2.Logic;

namespace FlexionV2.Database.Actions;

public static class DataBaseUpdater
{
    public static void UpdateMaterials(SQLiteConnection connection,List<Material> materials)
    {
        foreach (Material? material in materials)
        {
            if(material == null){return;}
            using SQLiteCommand cmd = new(
                "UPDATE Material SET Name = @WidthAtCenter, E = @WidthOnSides WHERE MaterialId= @Id;", connection);
            cmd.Parameters.AddWithValue("@WidthAtCenter",material.Name);
            cmd.Parameters.AddWithValue("@WidthOnSides",material.E);
            cmd.Parameters.AddWithValue("@Id",material.MaterialId);
            cmd.ExecuteNonQuery();
        }
        DataBaseEvents.RaiseMaterialsChangedEvent();
    }
    
    public static void UpdateLayers(SQLiteConnection connection,List<Layer> layers)
    {
        foreach (Layer? layer in layers)
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
        DataBaseEvents.RaiseLayersChangedEvent();
    }
    
    public static void UpdatePiece(SQLiteConnection connection,List<Piece> pieces)
    {
        foreach (Piece? piece in pieces)
        {
            if(piece == null){return;}
            using SQLiteCommand cmd1 = new(
                "UPDATE Piece SET Name = @Name, Length = @Length, Eref = @Eref WHERE PieceId= @Id;", connection);
            cmd1.Parameters.AddWithValue("@Name",piece.Name);
            cmd1.Parameters.AddWithValue("@Length",piece.Length);
            cmd1.Parameters.AddWithValue("@Eref",piece.Eref);
            cmd1.Parameters.AddWithValue("@Id",piece.PieceId);
            cmd1.ExecuteNonQuery();
        }
        DataBaseEvents.RaisePiecesChangedEvent();
    }

    public static void UpdateLayersInPiece(SQLiteConnection connection, long pieceId, List<Layer> layers)
    {
        using SQLiteCommand cmd1 = new("DELETE FROM PieceToLayer WHERE PieceId = @PieceId", connection);
        cmd1.Parameters.AddWithValue("@PieceId",pieceId);
        cmd1.ExecuteNonQuery();
        for (int i = 0; i < layers.Count; i++)
        {
            using SQLiteCommand cmd2 = new("INSERT INTO PieceToLayer (PieceId,LayerId,LayerOrder) VALUES (@PieceId, @LayerId, @LayerOrder);", connection);
            cmd2.Parameters.AddWithValue("@PieceId",pieceId);
            cmd2.Parameters.AddWithValue("@LayerId",layers[i].LayerId);
            cmd2.Parameters.AddWithValue("@LayerOrder",i);
            cmd2.ExecuteNonQuery();
        }
        DataBaseEvents.RaiseLayerOfPieceChanged();
        DataBaseEvents.RaisePiecesChangedEvent();
    }
}
using System.Data.SQLite;
using BendingCalculator.Logic.Math;

namespace BendingCalculator.Database.Actions;

public static class DataBaseCreator
{
    private const int NotRemoved = 0;
    public static void NewPiece(SQLiteConnection connection,Piece piece)
    {
        using SQLiteCommand cmd = new(
            @"INSERT INTO Piece (Name,Length,IsRemoved) 
                                VALUES (@Name, @Length, @IsRemoved);SELECT LAST_INSERT_ROWID();", connection);
        cmd.Parameters.AddWithValue("@Name",piece.Name);
        cmd.Parameters.AddWithValue("@Length",piece.Length);
        cmd.Parameters.AddWithValue("@IsRemoved",NotRemoved);
        piece.PieceId = (long)cmd.ExecuteScalar();
        DataBaseEvents.RaisePiecesChangedEvent();
    }
    
    public static void NewLayer(SQLiteConnection connection,Layer layer)
    {
        using SQLiteCommand cmd = new(
            @"INSERT INTO Layer (WidthAtCenter,WidthOnSides,HeightAtCenter,HeightOnSides,MaterialId,IsRemoved) 
                                VALUES (@WidthAtCenter, @WidthOnSides, @HeightAtCenter, @HeightOnSides ,@MaterialId, @IsRemoved);SELECT LAST_INSERT_ROWID();", connection);
        cmd.Parameters.AddWithValue("@WidthAtCenter",layer.WidthAtCenter);
        cmd.Parameters.AddWithValue("@WidthOnSides",layer.WidthOnSides);
        cmd.Parameters.AddWithValue("@HeightAtCenter",layer.HeightAtCenter);
        cmd.Parameters.AddWithValue("@HeightOnSides",layer.HeightOnSides);
        cmd.Parameters.AddWithValue("@IsRemoved",NotRemoved);
        
        if (layer.Material != null)
        {
            cmd.Parameters.AddWithValue("@MaterialId",layer.Material!.MaterialId);
        }
        else
        {
            cmd.Parameters.AddWithValue("@MaterialId",null);
        }
        layer.LayerId = (long)cmd.ExecuteScalar();
        DataBaseEvents.RaiseLayersChangedEvent();
    }
    
    public static void NewMaterial(SQLiteConnection connection,Material material)
    {
        using SQLiteCommand cmd = new(
            @"INSERT INTO Material (Name,E,IsRemoved) 
                                VALUES (@Name, @E, @IsRemoved);SELECT LAST_INSERT_ROWID();", connection);
        cmd.Parameters.AddWithValue("@Name",material.Name);
        cmd.Parameters.AddWithValue("@E",material.E);
        cmd.Parameters.AddWithValue("@IsRemoved",NotRemoved);
        material.MaterialId = (long)cmd.ExecuteScalar();
        DataBaseEvents.RaiseMaterialsChangedEvent();
    }
}
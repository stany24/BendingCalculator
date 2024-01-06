using System.Data.SQLite;

namespace FlexionV2.Logic.Database;

public static class DataBaseCreator
{
    public static Piece NewPiece(SQLiteConnection connection)
    {
        Piece piece = new(1, "nouveau", 69e9);
        using SQLiteCommand cmd = new(
            @"INSERT INTO Piece (Name,Length,Eref,IsRemoved) 
                                VALUES (@Name, @Length, @Eref, @IsRemoved);SELECT LAST_INSERT_ROWID();", connection);
        cmd.Parameters.AddWithValue("@Name",piece.Name);
        cmd.Parameters.AddWithValue("@Length",piece.Length);
        cmd.Parameters.AddWithValue("@Eref",piece.Eref);
        cmd.Parameters.AddWithValue("@IsRemoved",0);
        piece.PieceId = (long)cmd.ExecuteScalar();
        return piece;
    }
    
    public static Layer NewLayer(SQLiteConnection connection,Material? material)
    {
        Layer layer = new(1,1);
        using SQLiteCommand cmd = new(
            @"INSERT INTO Layer (WidthAtCenter,WidthOnSides,HeightAtCenter,HeightOnSides,MaterialId,IsRemoved) 
                                VALUES (@WidthAtCenter, @WidthOnSides, @HeightAtCenter, @HeightOnSides ,@MaterialId, @IsRemoved);SELECT LAST_INSERT_ROWID();", connection);
        cmd.Parameters.AddWithValue("@WidthAtCenter",layer.WidthAtCenter);
        cmd.Parameters.AddWithValue("@WidthOnSides",layer.WidthOnSides);
        cmd.Parameters.AddWithValue("@HeightAtCenter",layer.HeightAtCenter);
        cmd.Parameters.AddWithValue("@HeightOnSides",layer.HeightOnSides);
        cmd.Parameters.AddWithValue("@IsRemoved",0);
        
        if (material != null)
        {
            layer.Material =material;
            cmd.Parameters.AddWithValue("@MaterialId",layer.Material!.MaterialId);
        }
        else
        {
            cmd.Parameters.AddWithValue("@MaterialId",null);
        }
        layer.LayerId = (long)cmd.ExecuteScalar();
        return layer;
    }
    
    public static Material NewMaterial(SQLiteConnection connection)
    {
        Material material = new("nouveau",69000000000);
        using SQLiteCommand cmd = new(
            @"INSERT INTO Material (Name,E,IsRemoved) 
                                VALUES (@Name, @E, @IsRemoved);SELECT LAST_INSERT_ROWID();", connection);
        cmd.Parameters.AddWithValue("@Name",material.Name);
        cmd.Parameters.AddWithValue("@E",material.E);
        cmd.Parameters.AddWithValue("@IsRemoved",0);
        material.MaterialId = (long)cmd.ExecuteScalar();
        return material;
    }
}
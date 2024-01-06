using System.Data.SQLite;

namespace FlexionV2.Database.Actions;

public static class DataBaseRemover
{
    public static void RemoveMaterial(SQLiteConnection connection, long materialId)
    {
        using SQLiteCommand cmd = new(
            "UPDATE Material SET IsRemoved = 1 WHERE MaterialId=@Id; ", connection);
        cmd.Parameters.AddWithValue("@Id",materialId);
        cmd.ExecuteNonQuery();
        DataBaseEvents.RaiseMaterialsChangedEvent();
    }
    
    public static void RemoveLayer(SQLiteConnection connection, long layerId)
    {
        using SQLiteCommand cmd = new(
            "UPDATE Layer SET IsRemoved = 1 WHERE LayerId=@Id; ", connection);
        cmd.Parameters.AddWithValue("@Id",layerId);
        cmd.ExecuteNonQuery();
        DataBaseEvents.RaiseLayersChangedEvent();
    }
    
    public static void RemovePiece(SQLiteConnection connection, long pieceId)
    {
        using SQLiteCommand cmd = new(
            "UPDATE Piece SET IsRemoved = 1 WHERE PieceId=@Id; ", connection);
        cmd.Parameters.AddWithValue("@Id",pieceId);
        cmd.ExecuteNonQuery();
        DataBaseEvents.RaisePiecesChangedEvent();
    }
}
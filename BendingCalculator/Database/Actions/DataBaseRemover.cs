using System.Data.SQLite;

namespace BendingCalculator.Database.Actions;

public static class DataBaseRemover
{
    private const int Removed = 1;

    public static void RemoveMaterial(SQLiteConnection connection, long materialId)
    {
        using SQLiteCommand cmd = new(
            "UPDATE Material SET IsRemoved = @Removed WHERE MaterialId=@Id; ", connection);
        cmd.Parameters.AddWithValue("@Id", materialId);
        cmd.Parameters.AddWithValue("@Removed", Removed);
        cmd.ExecuteNonQuery();
        DataBaseEvents.RaiseMaterialsChangedEvent();
    }

    public static void RemoveLayer(SQLiteConnection connection, long layerId)
    {
        using SQLiteCommand cmd = new(
            "UPDATE Layer SET IsRemoved = @Removed WHERE LayerId=@Id; ", connection);
        cmd.Parameters.AddWithValue("@Id", layerId);
        cmd.Parameters.AddWithValue("@Removed", Removed);
        cmd.ExecuteNonQuery();
        DataBaseEvents.RaiseLayersChangedEvent();
    }

    public static void RemovePiece(SQLiteConnection connection, long pieceId)
    {
        using SQLiteCommand cmd = new(
            "UPDATE Piece SET IsRemoved = @Removed WHERE PieceId=@Id; ", connection);
        cmd.Parameters.AddWithValue("@Id", pieceId);
        cmd.Parameters.AddWithValue("@Removed", Removed);
        cmd.ExecuteNonQuery();
        DataBaseEvents.RaisePiecesChangedEvent();
    }
}
using System;
using System.Data.SQLite;
using System.IO;

namespace BendingCalculator.Database.Actions;

public static class DataBaseInitializer
{
    private const string CreateMaterialTable = @"create table Material(
                                                MaterialId integer not null constraint MaterialId primary key autoincrement,
                                                Name TEXT, E BIGINT not null,
                                                IsRemoved BOOL not null,
                                                Color TEXT(6) default 0 not null);";

    private const string CreateLayerTable = @"create table Layer(
                                            LayerId integer not null constraint LayerId primary key autoincrement,
                                            MaterialId integer constraint MaterialId references Material,
                                            WidthAtCenter FLOAT(32) not null,
                                            WidthOnSides FLOAT(32) not null,
                                            HeightAtCenter FLOAT(32) not null,
                                            HeightOnSides FLOAT(32) not null,
                                            IsRemoved BOOL not null);";

    private const string CreatePieceTable = @"create table Piece(
                                            PieceId integer not null constraint PieceId primary key autoincrement,
                                            Name TEXT not null,
                                            Length FLOAT(32) not null,
                                            IsRemoved BOOL not null);";

    private const string CreatePieceToLayerTable = @"create table PieceToLayer(
                                                    PieceId integer not null constraint PieceId references Piece,
                                                    LayerId integer not null constraint LayerId references Layer,
                                                    LayerOrder integer not null,
                                                    constraint RelationId primary key (LayerId, PieceId, LayerOrder));";

    private static readonly string DatabaseLocation =
        Path.Combine(Directory.GetCurrentDirectory(), "Database", "Database.db");

    public static SQLiteConnection? InitializeDatabaseConnection()
    {
        if (!File.Exists(DatabaseLocation)) return CreateDataBase();
        string connectionString = $"Data Source={DatabaseLocation};";
        try
        {
            Environment.SetEnvironmentVariable("SQLite_ConfigureDirectory",
                AppContext.BaseDirectory); // used to correct an issue with the last version of sqlite
            SQLiteConnection connection = new(connectionString);
            connection.Open();
            return connection;
        }
        catch
        {
            return null;
        }
    }

    private static SQLiteConnection CreateDataBase()
    {
        if (!Directory.Exists("Database")) Directory.CreateDirectory("Database");
        SQLiteConnection.CreateFile(DatabaseLocation);
        string connectionString = $"Data Source={DatabaseLocation};";
        SQLiteConnection connection = new(connectionString);
        connection.Open();

        SQLiteCommand enableForeignKeys = new("PRAGMA foreign_keys = ON;", connection);
        enableForeignKeys.ExecuteNonQuery();

        SQLiteCommand commandMaterial = new(CreateMaterialTable, connection);
        commandMaterial.ExecuteNonQuery();
        SQLiteCommand commandLayer = new(CreateLayerTable, connection);
        commandLayer.ExecuteNonQuery();
        SQLiteCommand commandPiece = new(CreatePieceTable, connection);
        commandPiece.ExecuteNonQuery();
        SQLiteCommand commandPieceToLayer = new(CreatePieceToLayerTable, connection);
        commandPieceToLayer.ExecuteNonQuery();

        return connection;
    }
}
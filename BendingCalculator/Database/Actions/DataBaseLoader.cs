using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using Avalonia.Media;
using BendingCalculator.Logic.Math;

namespace BendingCalculator.Database.Actions;

public static class DataBaseLoader
{
    private const string PieceId = "PieceId";
    private const string LayerId = "LayerId";
    private const string MaterialId = "MaterialId";

    public static ObservableCollection<Layer> LoadLayersOfPiece(SQLiteConnection connection, long pieceId)
    {
        using SQLiteCommand cmd = new(
            @"SELECT *
            FROM PieceToLayer pl
            LEFT JOIN Layer l ON pl.LayerId = l.LayerId
            LEFT JOIN Material m on l.MaterialId = m.MaterialId
            WHERE pl.PieceId = @PieceId
            ORDER BY pl.LayerOrder;", connection);
        cmd.Parameters.AddWithValue("@PieceId", pieceId);

        using SQLiteDataReader reader = cmd.ExecuteReader();
        ObservableCollection<Layer> layers = new();

        while (reader.Read())
        {
            if (reader[LayerId] == DBNull.Value) continue;
            Layer layer = LoadLayer(reader);
            if (reader[MaterialId] == DBNull.Value) continue;
            layer.Material = LoadMaterial(reader);
            layers.Add(layer);
        }

        return layers;
    }

    public static List<Piece> LoadPieces(SQLiteConnection connection)
    {
        using SQLiteCommand cmd = new(
            @"SELECT piece.*, layer.*, material.*, piece.Name AS PieceName, material.Name AS MaterialName
            FROM Piece piece
            LEFT JOIN PieceToLayer pieceOfLayer ON piece.PieceId = pieceOfLayer.PieceId
            LEFT JOIN Layer layer ON pieceOfLayer.LayerId = layer.LayerId
            LEFT JOIN Material material on layer.MaterialId = material.MaterialId
            WHERE piece.IsRemoved = 0
            ORDER BY piece.PieceId, pieceOfLayer.LayerOrder;", connection);

        using SQLiteDataReader reader = cmd.ExecuteReader();
        List<Piece> pieces = new();
        Piece? currentPiece = null;

        while (reader.Read())
        {
            int pieceId = Convert.ToInt32(reader[PieceId]);

            if (currentPiece == null || currentPiece.Id != pieceId)
            {
                currentPiece = LoadPiece(reader);
                pieces.Add(currentPiece);
            }

            currentPiece.Layers = LoadLayersOfPiece(connection, pieceId);
        }

        return pieces;
    }

    public static List<Layer> LoadLayers(SQLiteConnection connection)
    {
        using SQLiteCommand cmd = new(
            @"SELECT Layer.*, Material.*
          FROM Layer
          LEFT JOIN Material ON Layer.MaterialId = Material.MaterialId
          WHERE Layer.IsRemoved = 0;", connection);

        using SQLiteDataReader reader = cmd.ExecuteReader();
        List<Layer> layers = new();
        while (reader.Read())
        {
            Layer layer = LoadLayer(reader);

            if (reader[MaterialId] != DBNull.Value) layer.Material = LoadMaterial(reader);
            layers.Add(layer);
        }

        return layers;
    }

    public static List<Material> LoadMaterials(SQLiteConnection connection)
    {
        using SQLiteCommand cmd = new(
            @"SELECT Material.*
          FROM Material
          WHERE Material.IsRemoved = 0;", connection);

        using SQLiteDataReader reader = cmd.ExecuteReader();
        List<Material> materials = new();
        while (reader.Read()) materials.Add(LoadMaterial(reader));

        return materials;
    }

    private static Material LoadMaterial(IDataRecord reader)
    {
        string colorHexadecimal = Convert.ToString(reader["Color"]) ?? "ffffff";
        if (colorHexadecimal.Length < 6) colorHexadecimal = "ffffff";
        byte r = byte.Parse(colorHexadecimal[..2], NumberStyles.HexNumber);
        byte g = byte.Parse(colorHexadecimal.Substring(2, 2), NumberStyles.HexNumber);
        byte b = byte.Parse(colorHexadecimal.Substring(4, 2), NumberStyles.HexNumber);
        Color color = Color.FromRgb(r, g, b);
        return new Material
        {
            Id = Convert.ToInt32(reader[MaterialId]),
            E = Convert.ToInt64(reader["E"]),
            Name = Convert.ToString(reader["Name"]) ?? string.Empty,
            Color = color,
            Unit = (Unit)Convert.ToInt64(reader["Unit"])
        };
    }

    private static Layer LoadLayer(IDataRecord reader)
    {
        return new Layer
        {
            Id = Convert.ToInt32(reader[LayerId]),
            WidthAtCenter = Convert.ToDouble(reader["WidthAtCenter"]),
            WidthOnSides = Convert.ToDouble(reader["WidthOnSides"]),
            HeightAtCenter = Convert.ToDouble(reader["HeightAtCenter"]),
            HeightOnSides = Convert.ToDouble(reader["HeightOnSides"])
        };
    }

    private static Piece LoadPiece(IDataRecord reader)
    {
        return new Piece
        {
            Layers = new ObservableCollection<Layer>(),
            Id = Convert.ToInt64(reader[PieceId]),
            Name = Convert.ToString(reader["PieceName"]) ?? string.Empty,
            Length = Convert.ToDouble(reader["Length"])
        };
    }
}
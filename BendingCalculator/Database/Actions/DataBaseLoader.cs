using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using BendingCalculator.Logic.Math;

namespace BendingCalculator.Database.Actions;

public static class DataBaseLoader
{
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
        Piece? currentPiece = null;
        
        while (reader.Read())
        {
            currentPiece ??= new Piece
            {
                PieceId = pieceId,
                Layers = new ObservableCollection<Layer>()
            };
            if (reader["LayerId"] == DBNull.Value) continue;
            Layer layer = new()
            {
                LayerId = Convert.ToInt32(reader["LayerId"]),
                WidthAtCenter = Convert.ToDouble(reader["WidthAtCenter"]),
                WidthOnSides = Convert.ToDouble(reader["WidthOnSides"]),
                HeightAtCenter = Convert.ToDouble(reader["HeightAtCenter"]),
                HeightOnSides = Convert.ToDouble(reader["HeightOnSides"])
            };
            if (reader["MaterialId"] != DBNull.Value)
            {
                layer.Material = new Material
                {
                    MaterialId = Convert.ToInt32(reader["MaterialId"]),
                    E=Convert.ToInt64(reader["E"]),
                    Name = Convert.ToString(reader["Name"]) ?? string.Empty
                };
            }

            currentPiece.Layers.Add(layer);
        }

        return currentPiece?.Layers ?? new ObservableCollection<Layer>();
    }
    
    public static List<Piece> LoadPieces(SQLiteConnection connection)
    {
        using SQLiteCommand cmd = new(
            @"SELECT p.*, l.*, m.*, p.Name AS PieceName, m.Name AS MaterialName
            FROM Piece p
            LEFT JOIN PieceToLayer pl ON p.PieceId = pl.PieceId
            LEFT JOIN Layer l ON pl.LayerId = l.LayerId
            LEFT JOIN Material m on l.MaterialId = m.MaterialId
            WHERE p.IsRemoved = 0
            ORDER BY p.PieceId, pl.LayerOrder;", connection);
        
        using SQLiteDataReader reader = cmd.ExecuteReader();
        List<Piece> pieces = new();
        Piece? currentPiece = null;
        
        while (reader.Read())
        {
            int pieceId = Convert.ToInt32(reader["PieceId"]);
            
            if (currentPiece == null || currentPiece.PieceId != pieceId)
            {
                currentPiece = new Piece
                {
                    Layers = new ObservableCollection<Layer>(),
                    PieceId = pieceId,
                    Name = Convert.ToString(reader["PieceName"]) ?? string.Empty,
                    Length = Convert.ToDouble(reader["Length"])
                };
                pieces.Add(currentPiece);
            }
            
            if (reader["LayerId"] == DBNull.Value) continue;
            Layer layer = new()
            {
                LayerId = Convert.ToInt32(reader["LayerId"]),
                WidthAtCenter = Convert.ToDouble(reader["WidthAtCenter"]),
                WidthOnSides = Convert.ToDouble(reader["WidthOnSides"]),
                HeightAtCenter = Convert.ToDouble(reader["HeightAtCenter"]),
                HeightOnSides = Convert.ToDouble(reader["HeightOnSides"])
            };
            
            if (reader["MaterialId"] != DBNull.Value)
            {
                layer.Material = new Material
                {
                    MaterialId = Convert.ToInt32(reader["MaterialId"]),
                    E=Convert.ToInt64(reader["E"]),
                    Name = Convert.ToString(reader["MaterialName"]) ?? string.Empty
                };
            }

            currentPiece.Layers.Add(layer);
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
            Layer layer = new()
            {
                LayerId = Convert.ToInt32(reader["LayerId"]),
                WidthAtCenter = Convert.ToDouble(reader["WidthAtCenter"]),
                WidthOnSides = Convert.ToDouble(reader["WidthOnSides"]),
                HeightAtCenter = Convert.ToDouble(reader["HeightAtCenter"]),
                HeightOnSides = Convert.ToDouble(reader["HeightOnSides"])
            };
            
            if (reader["MaterialId"] != DBNull.Value)
            {
                layer.Material = new Material
                {
                    MaterialId = Convert.ToInt32(reader["MaterialId"]),
                    E=Convert.ToInt64(reader["E"]),
                    Name = Convert.ToString(reader["Name"]) ?? string.Empty
                };
            }
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
        while (reader.Read())
        {
            Material material = new()
            {
                MaterialId = Convert.ToInt32(reader["MaterialId"]),
                E=Convert.ToInt64(reader["E"]),
                Name = Convert.ToString(reader["Name"]) ?? string.Empty
            };
            materials.Add(material);
        }

        return materials;
    }
}
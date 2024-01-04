using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Avalonia.Controls;
using Dapper;

namespace FlexionV2.Views.Editors.Layer;

public partial class LayerEditor : Editor
{
    private readonly SQLiteConnection _connection;
    public LayerEditor(SQLiteConnection connection)
    {
        _connection = connection;
        InitializeComponent();
        InitializeUi();
        NudHeightCenter.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"HeightAtCenter");
        NudHeightSide.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"HeightOnSides");
        NudWidthCenter.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"WidthAtCenter");
        NudWidthSide.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"WidthOnSides");
        CbxMaterial.SelectionChanged += (_, e) => ComboboxChanged<Logic.Layer,Logic.Material>(e,"Material");
        IEnumerable<Logic.Material> materials = _connection.QueryAsync<Logic.Material>("SELECT * FROM Material WHERE IsRemoved=0;").Result;
        foreach (Logic.Material material in materials) { CbxMaterial.Items.Add(material); }
        LoadFromDatabase();
    }

    private void LoadFromDatabase()
    {
        using SQLiteCommand cmd = new(
            @"SELECT Layer.*, Material.*
          FROM Layer
          LEFT JOIN Material ON Layer.MaterialId = Material.MaterialId
          WHERE Layer.IsRemoved = 0;", _connection);
        
        using SQLiteDataReader reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            Logic.Layer layer = new()
            {
                LayerId = Convert.ToInt32(reader["LayerId"]),
                WidthAtCenter = Convert.ToDouble(reader["WidthAtCenter"]),
                WidthOnSides = Convert.ToDouble(reader["WidthOnSides"]),
                HeightAtCenter = Convert.ToDouble(reader["HeightAtCenter"]),
                HeightOnSides = Convert.ToDouble(reader["HeightOnSides"])
            };
            
            if (reader["MaterialId"] != DBNull.Value)
            {
                layer.Material = new Logic.Material
                {
                    MaterialId = Convert.ToInt32(reader["MaterialId"]),
                    E=Convert.ToInt64(reader["E"]),
                    Name = Convert.ToString(reader["Name"])
                };
            }

            LbxItems.Items.Add(layer);
        }
    }

    protected override void RemoveItems()
    {
        if (LbxItems.SelectedItems == null) return;
        int index = LbxItems.SelectedIndex;
        while (LbxItems.SelectedItems.Count > 0)
        {
            Logic.Layer layer = LbxItems.SelectedItems[0] as Logic.Layer;
            using SQLiteCommand cmd = new(
                "UPDATE Layer SET IsRemoved = 1 WHERE LayerId=@Id; ", _connection);
            cmd.Parameters.AddWithValue("@Id",layer.LayerId);
            cmd.ExecuteNonQuery();
            LbxItems.Items.Remove(LbxItems.SelectedItems[0]);
        }

        if (index <= 0) return;
        LbxItems.SelectedIndex = LbxItems.Items.Count > index ? index : LbxItems.Items.Count;
    }
    
    protected override void UpdateListBox<TItem>()
    {
        List<TItem> selected = new();
        List<TItem> items = new();
        if (LbxItems.SelectedItems != null) { selected = LbxItems.SelectedItems.Cast<TItem>().ToList(); }
        if (LbxItems.Items != null) { items = LbxItems.Items.Cast<TItem>().ToList(); }
        foreach (Logic.Layer layer in LbxItems.Items)
        {
            using SQLiteCommand cmd = new(
                "UPDATE Layer SET WidthAtCenter = @WidthAtCenter, WidthOnSides = @WidthOnSides, HeightAtCenter = @HeightAtCenter , HeightOnSides = @HeightOnSides , MaterialId = @MaterialId WHERE LayerId= @Id;", _connection);
            cmd.Parameters.AddWithValue("@WidthAtCenter",layer.WidthAtCenter);
            cmd.Parameters.AddWithValue("@WidthOnSides",layer.WidthOnSides);
            cmd.Parameters.AddWithValue("@HeightAtCenter",layer.HeightAtCenter);
            cmd.Parameters.AddWithValue("@HeightOnSides",layer.HeightOnSides);
            cmd.Parameters.AddWithValue("@MaterialId", layer.Material?.MaterialId);
            cmd.Parameters.AddWithValue("@Id",layer.LayerId);
            cmd.ExecuteNonQuery();
        }
        LbxItems.Items.Clear();
        foreach (TItem item in items) LbxItems.Items.Add(item);
        foreach (TItem item in selected) LbxItems.SelectedItems.Add(item);
    }
    
    public void UpdateMaterialList(List<Logic.Material>materials)
    {
        CbxMaterial.Items.Clear();
        foreach (Logic.Material material in materials)
        {
            CbxMaterial.Items.Add(material);
        }
    }
    
    private void InitializeUi()
    {
        Grid.SetColumn(LbxItems,0);
        Grid.SetRow(LbxItems,0);
        Grid.SetRowSpan(LbxItems,12);
        LbxItems.MinWidth = 200;
        Grid.Children.Add(LbxItems);
        Grid.SetColumn(BtnAdd,2);
        Grid.SetRow(BtnAdd,10);
        Grid.Children.Add(BtnAdd);
        Grid.SetColumn(BtnRemove,4);
        Grid.SetRow(BtnRemove,10);
        Grid.Children.Add(BtnRemove);
        BtnAdd.Click += (_, _) => NewLayer();
    }

    private void NewLayer()
    {
        Logic.Layer layer = new(1,1);
        using SQLiteCommand cmd = new(
            @"INSERT INTO Layer (WidthAtCenter,WidthOnSides,HeightAtCenter,HeightOnSides,MaterialId,IsRemoved) 
                                VALUES (@WidthAtCenter, @WidthOnSides, @HeightAtCenter, @HeightOnSides ,@MaterialId, @IsRemoved);SELECT LAST_INSERT_ROWID();", _connection);
        cmd.Parameters.AddWithValue("@WidthAtCenter",layer.WidthAtCenter);
        cmd.Parameters.AddWithValue("@WidthOnSides",layer.WidthOnSides);
        cmd.Parameters.AddWithValue("@HeightAtCenter",layer.HeightAtCenter);
        cmd.Parameters.AddWithValue("@HeightOnSides",layer.HeightOnSides);
        cmd.Parameters.AddWithValue("@IsRemoved",0);
        
        if (CbxMaterial.SelectedItem != null)
        {
            layer.Material = CbxMaterial.SelectedItem as Logic.Material;
            cmd.Parameters.AddWithValue("@MaterialId",layer.Material.MaterialId);
        }
        else
        {
            cmd.Parameters.AddWithValue("@MaterialId",null);
        }
        layer.LayerId = (long)cmd.ExecuteScalar();
        LbxItems.Items.Add(layer);
    }
}
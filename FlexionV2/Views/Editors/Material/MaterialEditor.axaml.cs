using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Avalonia.Controls;
using FlexionV2.Logic;
using FlexionV2.Logic.Database;

namespace FlexionV2.Views.Editors.Material;

public partial class MaterialEditor : Editor
{
    private readonly SQLiteConnection _connection;
    public MaterialEditor(SQLiteConnection connection)
    {
        _connection = connection;
        InitializeComponent();
        InitializeUi();
        NudE.ValueChanged += (_, e) => NumericChanged<Logic.Material>(e,"E");
        TbxName.TextChanged += (_, _) => TextChanged<Logic.Material>(TbxName, "Name");
        foreach (Logic.Material material in DataBaseLoader.LoadMaterialsFromDatabase(_connection))
        {
            LbxItems.Items.Add(material);
        }
    }

    protected override void RemoveItems()
    {
        if (LbxItems.SelectedItems == null) return;
        int index = LbxItems.SelectedIndex;
        while (LbxItems.SelectedItems.Count > 0)
        {
            if(LbxItems.SelectedItems[0] is not Logic.Material material){return;}
            using SQLiteCommand cmd = new(
                "UPDATE Material SET IsRemoved = 1 WHERE MaterialId=@Id; ", _connection);
            cmd.Parameters.AddWithValue("@Id",material.MaterialId);
            cmd.ExecuteNonQuery();
            LbxItems.Items.Remove(LbxItems.SelectedItems[0]);
        }

        if (index <= 0) return;
        LbxItems.SelectedIndex = LbxItems.Items.Count > index ? index : LbxItems.Items.Count;
    }
    
    protected override void UpdateListBox<TItem>()
    {
        List<TItem> selected = new();
        List<TItem> items = LbxItems.Items.Cast<TItem>().ToList();
        if (LbxItems.SelectedItems != null) { selected = LbxItems.SelectedItems.Cast<TItem>().ToList(); }
        foreach (Logic.Material? layer in LbxItems.Items)
        {
            if(layer == null){continue;}
            using SQLiteCommand cmd = new(
                "UPDATE Material SET Name = @WidthAtCenter, E = @WidthOnSides WHERE MaterialId= @Id;", _connection);
            cmd.Parameters.AddWithValue("@WidthAtCenter",layer.Name);
            cmd.Parameters.AddWithValue("@WidthOnSides",layer.E);
            cmd.Parameters.AddWithValue("@Id",layer.MaterialId);
            cmd.ExecuteNonQuery();
        }
        LbxItems.Items.Clear();
        foreach (TItem item in items) LbxItems.Items.Add(item);
        LbxItems.SelectedItems = new List<TItem>();
        foreach (TItem item in selected) LbxItems.SelectedItems.Add(item);
    }

    private void InitializeUi()
    {
        Grid.SetColumn(LbxItems,0);
        Grid.SetRow(LbxItems,0);
        Grid.SetRowSpan(LbxItems,6);
        LbxItems.MinWidth = 200;
        Grid.Children.Add(LbxItems);
        Grid.SetColumn(BtnAdd,2);
        Grid.SetRow(BtnAdd,4);
        Grid.Children.Add(BtnAdd);
        Grid.SetColumn(BtnRemove,4);
        Grid.SetRow(BtnRemove,4);
        Grid.Children.Add(BtnRemove);
        BtnAdd.Click += (_, _) => NewMaterial();
    }
    
    private void NewMaterial()
    {
        Logic.Material material = new("nouveau",69000000000);
        using SQLiteCommand cmd = new(
            @"INSERT INTO Material (Name,E,IsRemoved) 
                                VALUES (@Name, @E, @IsRemoved);SELECT LAST_INSERT_ROWID();", _connection);
        cmd.Parameters.AddWithValue("@Name",material.Name);
        cmd.Parameters.AddWithValue("@E",material.E);
        cmd.Parameters.AddWithValue("@IsRemoved",0);
        material.MaterialId = (long)cmd.ExecuteScalar();
        LbxItems.Items.Add(material);
    }
}
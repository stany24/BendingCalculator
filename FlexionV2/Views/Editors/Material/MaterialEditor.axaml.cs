using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Avalonia.Controls;
using FlexionV2.Database.Actions;
using FlexionV2.Logic;

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
        foreach (Logic.Material material in DataBaseLoader.LoadMaterials(_connection))
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
            DataBaseRemover.RemoveMaterial(_connection,material.MaterialId);
            LbxItems.Items.Remove(LbxItems.SelectedItems[0]);
        }
        if (index <= 0) return;
        LbxItems.SelectedIndex = LbxItems.Items.Count > index ? index : LbxItems.Items.Count;
    }
    
    protected override void UpdateListBox<TItem>()
    {
        List<Logic.Material> items = LbxItems.Items.Cast<Logic.Material>().ToList();
        List<Logic.Material> selected = new();
        if (LbxItems.SelectedItems != null) { selected = LbxItems.SelectedItems.Cast<Logic.Material>().ToList(); }
        DataBaseUpdater.UpdateMaterials(_connection,items);
        LbxItems.Items.Clear();
        foreach (Logic.Material item in items) LbxItems.Items.Add(item);
        if (LbxItems.SelectedItems == null) return;
        foreach (Logic.Material item in selected) LbxItems.SelectedItems.Add(item);
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
        BtnAdd.Click += (_, _) => CreateNewMaterial();
    }

    private void CreateNewMaterial()
    {
        Logic.Material material = new(TbxName.Text ?? "nouveau",Convert.ToInt64(NudE.Value ?? 69000000000));
        LbxItems.Items.Add(DataBaseCreator.NewMaterial(_connection,material));
    }
}
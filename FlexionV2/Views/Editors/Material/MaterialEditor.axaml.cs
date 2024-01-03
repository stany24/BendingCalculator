using System;
using System.Collections.Generic;
using System.Data;
using Avalonia.Controls;
using Dapper;

namespace FlexionV2.Views.Editors.Material;

public partial class MaterialEditor : Editor
{
    private readonly IDbConnection _connection;
    public MaterialEditor(IDbConnection connection)
    {
        _connection = connection;
        InitializeComponent();
        InitializeUi();
        NudE.ValueChanged += (_, e) => NumericChanged<Logic.Material>(e,"E");
        TbxName.TextChanged += (_, _) => TextChanged<Logic.Material>(TbxName, "Name");
        IEnumerable<Logic.Material> materials = _connection.QueryAsync<Logic.Material>("SELECT * FROM Material WHERE IsRemoved=0;").Result;
        foreach (Logic.Material material in materials) { LbxItems.Items.Add(material); }
    }

    protected override void RemoveItems()
    {
        if (LbxItems.SelectedItems == null) return;
        int index = LbxItems.SelectedIndex;
        while (LbxItems.SelectedItems.Count > 0)
        {
            Logic.Material material = LbxItems.SelectedItems[0] as Logic.Material;
            _connection.Execute($"UPDATE Material SET IsRemoved = 1 WHERE Id={material.Id}; ");
            LbxItems.Items.Remove(LbxItems.SelectedItems[0]);
        }

        if (index <= 0) return;
        LbxItems.SelectedIndex = LbxItems.Items.Count > index ? index : LbxItems.Items.Count;
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
        BtnAdd.Click += (_, _) => LbxItems.Items.Add(new Logic.Material("new", Convert.ToInt64(69e9)));
    }
}
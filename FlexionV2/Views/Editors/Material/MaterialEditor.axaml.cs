using System;
using System.Collections.Generic;
using Avalonia.Controls;

namespace FlexionV2.Views.Editors.Material;

public partial class MaterialEditor : Editor
{
    public MaterialEditor(List<Logic.Material> materials)
    {
        InitializeComponent();
        InitializeUi();
        NudE.ValueChanged += (_, e) => NumericChanged<Logic.Material>(e,"E");
        TbxName.TextChanged += (_, _) => TextChanged<Logic.Material>(TbxName, "Name");
        foreach (Logic.Material material in materials) { LbxItems.Items.Add(material); }
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
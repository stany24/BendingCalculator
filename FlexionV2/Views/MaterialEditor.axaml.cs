using System.Collections.Generic;
using Avalonia.Controls;
using FlexionV2.Logic;

namespace FlexionV2.Views;

public partial class MaterialEditor : Editor
{
    public MaterialEditor(List<Material> materials)
    {
        InitializeComponent();
        InitializeUi();
        NudE.ValueChanged += (_, e) => NumericChanged<Material>(e,"E");
        TbxName.TextChanged += (_, _) => TextChanged<Material>(TbxName, "Nom");
        foreach (Material material in materials) { LbxItems.Items.Add(material); }
    }

    private void InitializeUi()
    {
        Grid.SetColumn(LbxItems,0);
        Grid.SetRow(LbxItems,0);
        Grid.SetRowSpan(LbxItems,6);
        Grid.Children.Add(LbxItems);
        Grid.SetColumn(BtnAdd,2);
        Grid.SetRow(BtnAdd,4);
        Grid.Children.Add(BtnAdd);
        Grid.SetColumn(BtnRemove,4);
        Grid.SetRow(BtnRemove,4);
        Grid.Children.Add(BtnRemove);
        BtnAdd.Click += (_, _) => LbxItems.Items.Add(new Material("new", 69e9));
    }
}
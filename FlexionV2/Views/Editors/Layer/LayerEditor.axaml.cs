using System.Collections.Generic;

using Avalonia.Controls;

namespace FlexionV2.Views.Editors.Layer;

public partial class LayerEditor : Editor
{
    public LayerEditor(List<Logic.Layer> layers,List<Logic.Material> materials)
    {
        InitializeComponent();
        InitializeUi();
        NudHeightCenter.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"HeightAtCenter");
        NudHeightSide.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"HeightOnSide");
        NudWidthCenter.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"WidthAtCenter");
        NudWidthSide.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"WidthOnSide");
        CbxMaterial.SelectionChanged += (_, e) => ComboboxChanged<Logic.Layer,Logic.Material>(e,"Material");
        foreach (Logic.Layer material in layers) { LbxItems.Items.Add(material); }
        foreach (Logic.Material material in materials) { CbxMaterial.Items.Add(material); }
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
        BtnAdd.Click += (_, _) => LbxItems.Items.Add(new Logic.Layer(new Logic.Material("alu",69e9),1,0.1));
    }
}
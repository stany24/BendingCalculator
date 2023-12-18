using System.Collections.Generic;
using FivemEconomy.Window.Editor;
using FlexionV2.Logic;

namespace FlexionV2.Views;

public partial class MaterialEditor : Editor
{
    public MaterialEditor(List<Material> materials)
    {
        InitializeComponent();
        BtnRemove.Click += (_, _) => RemoveItems(LbxMaterial);
        BtnAdd.Click += (_,_) => LbxMaterial.Items.Add(new Material("defaut",69e9));
        TbxName.TextChanged += (_,_) => TextChanged<Material>(LbxMaterial, TbxName, "Nom");
        NudValue.ValueChanged += (_, e) => NumericChanged<Material>(LbxMaterial, e, "E");
        foreach (Material material in materials)
        {
            LbxMaterial.Items.Add(material);
        }
    }
}
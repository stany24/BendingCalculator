using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using FlexionV2.ViewModels;

namespace FlexionV2.Views.Editors.Material;

public partial class MaterialEditor: Window
{
    public MaterialEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        
        NudE.ValueChanged += (_, e) => NumericChanged<Logic.Material>(e,"E");
        TbxName.TextChanged += (_, _) => TextChanged();
        BtnRemove.Click +=(_,_) => RemoveItems();
        BtnAdd.Click += (_, _) => CreateNewMaterial();

        CbxUnits.Items.Add("GPa");
        CbxUnits.SelectedItem = "GPa";
        CbxUnits.Items.Add("MPa");
    }

    private void TextChanged()
    {
        List<Logic.Material> materials = LbxItems.SelectedItems.Cast<Logic.Material>().ToList();
        foreach (Logic.Material material in materials)
        {
            material.Name = TbxName.Text;
        }
        (DataContext as MainViewModel).UpdateMaterials(materials);
    }
    
    private void NumericChanged<TItem>(NumericUpDownValueChangedEventArgs e, string propertyName)
    {
        if (LbxItems.SelectedItems == null) return;
        if (e.NewValue == null) return;
        int multiplication;
        switch (CbxUnits.SelectedItem)
        {
            case "GPa" : multiplication = 1000000000;
                break;
            case "MPa" : multiplication = 1000000;
                break;
            default: return;
        }
        foreach (TItem item in LbxItems.SelectedItems)
            
            item.GetType().GetProperty(propertyName)?.SetValue(item, (long)e.NewValue*multiplication);
    }

    private void RemoveItems()
    {
        if (LbxItems.SelectedItems == null) return;
        int index = LbxItems.SelectedIndex;
        List<long> selected = LbxItems.SelectedItems.Cast<Logic.Material>().Select(x => x.MaterialId).ToList();
        foreach (long id in selected)
        {
            (DataContext as MainViewModel).RemoveMaterial(id);
        }
        if (index <= 0) return;
        LbxItems.SelectedIndex = LbxItems.Items.Count > index ? index : LbxItems.Items.Count;
    }

    private void CreateNewMaterial()
    {
        int multiplication;
        switch (CbxUnits.SelectedItem)
        {
            case "GPa" : multiplication = 1000000000;
                break;
            case "MPa" : multiplication = 1000000;
                break;
            default: return;
        }
        Logic.Material material = new(TbxName.Text ?? "nouveau",Convert.ToInt64(NudE.Value*multiplication ?? 69000000000));
        (DataContext as MainViewModel).NewMaterial(material);
    }
}
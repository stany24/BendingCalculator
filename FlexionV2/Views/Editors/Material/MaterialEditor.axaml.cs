using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using FlexionV2.ViewModels;

namespace FlexionV2.Views.Editors.Material;

public partial class MaterialEditor : Editor
{
    private readonly MainViewModel _model;
    public MaterialEditor(MainViewModel model)
    {
        _model = model;
        InitializeComponent();
        InitializeUi();
        NudE.ValueChanged += (_, e) => NumericChanged<Logic.Material>(e,"E");
        TbxName.TextChanged += (_, _) => TextChanged<Logic.Material>(TbxName, "Name");
        Binding binding = new()
        { 
            Source = _model, 
            Path = nameof(_model.Materials)
        }; 
        LbxItems.Bind(ItemsControl.ItemsSourceProperty,binding );

        CbxUnits.Items.Add("GPa");
        CbxUnits.SelectedItem = "GPa";
        CbxUnits.Items.Add("MPa");
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
        UpdateListBox<TItem>();
    }

    protected override void RemoveItems()
    {
        if (LbxItems.SelectedItems == null) return;
        int index = LbxItems.SelectedIndex;
        List<long> selected = LbxItems.SelectedItems.Cast<Logic.Material>().Select(x => x.MaterialId).ToList();
        foreach (long id in selected)
        {
            _model.RemoveMaterial(id);
        }
        if (index <= 0) return;
        LbxItems.SelectedIndex = LbxItems.Items.Count > index ? index : LbxItems.Items.Count;
    }
    
    protected override void UpdateListBox<TItem>()
    {
        List<Logic.Material> items = LbxItems.Items.Cast<Logic.Material>().ToList();
        List<Logic.Material> selected = new();
        if (LbxItems.SelectedItems != null) { selected = LbxItems.SelectedItems.Cast<Logic.Material>().ToList(); }
        _model.UpdateMaterials(items);
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
        _model.NewMaterial(material);
    }
}
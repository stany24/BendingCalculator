using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using FlexionV2.ViewModels;

namespace FlexionV2.Views.Editors.Layer;

public partial class LayerEditor : Editor
{
    private readonly MainViewModel _model;
    public LayerEditor(MainViewModel model)
    {
        _model = model;
        InitializeComponent();
        InitializeUi();
        NudHeightCenter.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"HeightAtCenter");
        NudHeightSide.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"HeightOnSides");
        NudWidthCenter.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"WidthAtCenter");
        NudWidthSide.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"WidthOnSides");
        CbxMaterial.SelectionChanged += (_, e) => ComboboxChanged<Logic.Layer,Logic.Material>(LbxItems,e,"Material");
        BtnRemove.Click +=(_,_) => RemoveItems();
        Binding binding = new()
        { 
            Source = _model,
            Path = nameof(_model.Layers)
        }; 
        LbxItems.Bind(ItemsControl.ItemsSourceProperty,binding );
    }
    
    private void NumericChanged<TItem>(NumericUpDownValueChangedEventArgs e, string propertyName)
    {
        if (LbxItems.SelectedItems == null) return;
        if (e.NewValue == null) return;
        foreach (TItem item in LbxItems.SelectedItems)
            item.GetType().GetProperty(propertyName)?.SetValue(item, (double)e.NewValue/1000);
        UpdateListBox();
    }

    private void RemoveItems()
    {
        if (LbxItems.SelectedItems == null) return;
        int index = LbxItems.SelectedIndex;
        List<long> selected = LbxItems.SelectedItems.Cast<Logic.Layer>().Select(x => x.LayerId).ToList();
        foreach (long id in selected)
        {
            _model.RemoveLayer(id);
        }
        if (index <= 0) return;
        LbxItems.SelectedIndex = LbxItems.Items.Count > index ? index : LbxItems.Items.Count;
    }

    private void UpdateListBox()
    {
        List<Logic.Layer> items = LbxItems.Items.Cast<Logic.Layer>().ToList();
        List<Logic.Layer> selected = new();
        if (LbxItems.SelectedItems != null) { selected = LbxItems.SelectedItems.Cast<Logic.Layer>().ToList(); }
        _model.UpdateLayers(items);
        LbxItems.Items.Clear();
        foreach (Logic.Layer item in items) LbxItems.Items.Add(item);
        if (LbxItems.SelectedItems == null) return;
        foreach (Logic.Layer item in selected) LbxItems.SelectedItems.Add(item);
    }
    
    private void InitializeUi()
    {
        Grid.SetColumn(BtnAdd,2);
        Grid.SetRow(BtnAdd,10);
        Grid.Children.Add(BtnAdd);
        Grid.SetColumn(BtnRemove,4);
        Grid.SetRow(BtnRemove,10);
        Grid.Children.Add(BtnRemove);
        BtnAdd.Click += (_, _) =>CreateNewLayer();
    }

    private void CreateNewLayer()
    {
        Logic.Layer layer = new(CbxMaterial.SelectedItem as Logic.Material , Convert.ToDouble(NudWidthCenter.Value/1000 ?? 1),
            Convert.ToDouble(NudWidthSide.Value/1000 ?? 1), Convert.ToDouble(NudHeightCenter.Value/1000 ?? 1),
            Convert.ToDouble(NudHeightSide.Value/1000 ?? 1));
        _model.NewLayer(layer);
    }
}
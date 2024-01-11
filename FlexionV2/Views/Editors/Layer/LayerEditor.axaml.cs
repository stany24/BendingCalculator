using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using FlexionV2.ViewModels;

namespace FlexionV2.Views.Editors.Layer;

public partial class LayerEditor: Window
{
    public LayerEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        NudHeightCenter.ValueChanged += (_, e) => NumericChanged(e,"HeightAtCenter");
        NudHeightSide.ValueChanged += (_, e) => NumericChanged(e,"HeightOnSides");
        NudWidthCenter.ValueChanged += (_, e) => NumericChanged(e,"WidthAtCenter");
        NudWidthSide.ValueChanged += (_, e) => NumericChanged(e,"WidthOnSides");
        CbxMaterial.SelectionChanged += (_, e) => ComboboxChanged();
        BtnRemove.Click +=(_,_) => RemoveItems();
        BtnAdd.Click += (_, _) =>CreateNewLayer();
    }
    
    private void NumericChanged(NumericUpDownValueChangedEventArgs e, string propertyName)
    {
        if (LbxItems.SelectedItems == null) {return;}
        if(DataContext is not MainViewModel model){return;}
        if (e.NewValue == null) return;
        
        List<Logic.Layer> layers = LbxItems.SelectedItems.Cast<Logic.Layer>().ToList();
        foreach (Logic.Layer layer in layers)
        {
            layer.GetType().GetProperty(propertyName)?.SetValue(layer, (double)e.NewValue/1000);
        }
        model.UpdateLayers(layers);
    }

    private void ComboboxChanged()
    {
        if (LbxItems.SelectedItems == null) {return;}
        if (CbxMaterial.SelectedItem == null) {return;}
        if(DataContext is not MainViewModel model){return;}
        if(CbxMaterial.SelectedItem is not Logic.Material material){return;}
        List<Logic.Layer> layers = LbxItems.SelectedItems.Cast<Logic.Layer>().ToList();
        foreach (Logic.Layer layer in layers)
        {
            layer.Material = material;
        }
        model.UpdateLayers(layers);
    }

    private void RemoveItems()
    {
        if (LbxItems.SelectedItems == null) return;
        int index = LbxItems.SelectedIndex;
        if(DataContext is not MainViewModel model){return;}
        List<long> selected = LbxItems.SelectedItems.Cast<Logic.Layer>().Select(x => x.LayerId).ToList();
        foreach (long id in selected)
        {
            model.RemoveLayer(id);
        }
        if (index <= 0) return;
        LbxItems.SelectedIndex = LbxItems.Items.Count > index ? index : LbxItems.Items.Count;
    }

    private void CreateNewLayer()
    {
        if(DataContext is not MainViewModel model){return;}
        Logic.Layer layer = new(CbxMaterial.SelectedItem as Logic.Material , Convert.ToDouble(NudWidthCenter.Value/1000 ?? 1),
            Convert.ToDouble(NudWidthSide.Value/1000 ?? 1), Convert.ToDouble(NudHeightCenter.Value/1000 ?? 1),
            Convert.ToDouble(NudHeightSide.Value/1000 ?? 1));
        model.NewLayer(layer);
    }
}
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Avalonia.Controls;
using FlexionV2.Database.Actions;

namespace FlexionV2.Views.Editors.Layer;

public partial class LayerEditor : Editor
{
    private readonly SQLiteConnection _connection;
    public LayerEditor(SQLiteConnection connection)
    {
        _connection = connection;
        InitializeComponent();
        InitializeUi();
        NudHeightCenter.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"HeightAtCenter");
        NudHeightSide.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"HeightOnSides");
        NudWidthCenter.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"WidthAtCenter");
        NudWidthSide.ValueChanged += (_, e) => NumericChanged<Logic.Layer>(e,"WidthOnSides");
        CbxMaterial.SelectionChanged += (_, e) => ComboboxChanged<Logic.Layer,Logic.Material>(e,"Material");
        DataBaseEvents.MaterialsChanged += UpdateMaterials;
        UpdateMaterials(null,EventArgs.Empty);
        foreach (Logic.Layer layer in DataBaseLoader.LoadLayers(_connection))
        {
            LbxItems.Items.Add(layer);
        }
    }
    
    ~LayerEditor()
    {
        DataBaseEvents.MaterialsChanged -= UpdateMaterials;
    }
    
    private void NumericChanged<TItem>(NumericUpDownValueChangedEventArgs e, string propertyName)
    {
        if (LbxItems.SelectedItems == null) return;
        if (e.NewValue == null) return;
        foreach (TItem item in LbxItems.SelectedItems)
            item.GetType().GetProperty(propertyName)?.SetValue(item, (double)e.NewValue/1000);
        UpdateListBox<TItem>();
    }

    private void UpdateMaterials(object? s, EventArgs e)
    {
        CbxMaterial.Items.Clear();
        foreach (Logic.Material material in DataBaseLoader.LoadMaterials(_connection))
        {
            CbxMaterial.Items.Add(material);
        }
    }

    protected override void RemoveItems()
    {
        if (LbxItems.SelectedItems == null) return;
        int index = LbxItems.SelectedIndex;
        while (LbxItems.SelectedItems.Count > 0)
        {
            if(LbxItems.SelectedItems[0] is not Logic.Layer layer){continue;}
            DataBaseRemover.RemoveLayer(_connection,layer.LayerId);
            LbxItems.Items.Remove(LbxItems.SelectedItems[0]);
        }

        if (index <= 0) return;
        LbxItems.SelectedIndex = LbxItems.Items.Count > index ? index : LbxItems.Items.Count;
    }
    
    protected override void UpdateListBox<TItem>()
    {
        List<Logic.Layer> items = LbxItems.Items.Cast<Logic.Layer>().ToList();
        List<Logic.Layer> selected = new();
        if (LbxItems.SelectedItems != null) { selected = LbxItems.SelectedItems.Cast<Logic.Layer>().ToList(); }
        DataBaseUpdater.UpdateLayers(_connection,items);
        LbxItems.Items.Clear();
        foreach (Logic.Layer item in items) LbxItems.Items.Add(item);
        if (LbxItems.SelectedItems == null) return;
        foreach (Logic.Layer item in selected) LbxItems.SelectedItems.Add(item);
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
        BtnAdd.Click += (_, _) =>CreateNewLayer();
    }

    private void CreateNewLayer()
    {
        Logic.Layer layer = new(CbxMaterial.SelectedItem as Logic.Material , Convert.ToDouble(NudWidthCenter.Value/1000 ?? 1),
            Convert.ToDouble(NudWidthSide.Value/1000 ?? 1), Convert.ToDouble(NudHeightCenter.Value/1000 ?? 1),
            Convert.ToDouble(NudHeightSide.Value/1000 ?? 1));
        LbxItems.Items.Add(DataBaseCreator.NewLayer(_connection,layer ));
    }
}
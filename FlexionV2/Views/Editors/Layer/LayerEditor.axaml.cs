using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Avalonia.Controls;
using Dapper;
using FlexionV2.Logic;
using FlexionV2.Logic.Database;

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
        List<TItem> selected = new();
        List<TItem> items = LbxItems.Items.Cast<TItem>().ToList();
        if (LbxItems.SelectedItems != null) { selected = LbxItems.SelectedItems.Cast<TItem>().ToList(); }
        foreach (Logic.Layer? layer in LbxItems.Items)
        {
            DataBaseUpdater.UpdateLayer(_connection,layer);
        }
        LbxItems.Items.Clear();
        foreach (TItem item in items) LbxItems.Items.Add(item);
        LbxItems.SelectedItems = new List<TItem>();
        foreach (TItem item in selected) LbxItems.SelectedItems.Add(item);
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
        BtnAdd.Click += (_, _) =>LbxItems.Items.Add(DataBaseCreator.NewLayer(_connection,CbxMaterial.SelectedItem as Logic.Material));
    }
}
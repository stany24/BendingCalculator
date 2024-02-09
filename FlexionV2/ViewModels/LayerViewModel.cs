using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FlexionV2.Database.Actions;
using FlexionV2.Logic;

namespace FlexionV2.ViewModels;

public partial class MainViewModel
{
    private ObservableCollection<Layer> _layers = new();
    public ObservableCollection<Layer> Layers { 
        get => _layers;
        set => SetProperty(ref _layers, value);
    }
    
    private ObservableCollection<Layer> _selectedLayers = new();
    public ObservableCollection<Layer> SelectedLayers { 
        get => _selectedLayers;
        set => SetProperty(ref _selectedLayers, value);
    }

    public double WidthSide { get; set; }
    public double WidthCenter { get; set; }
    public double HeightSide { get; set; }
    public double HeightCenter { get; set; }
    public Material SelectedMaterial { get; set; }
    
    private void ReloadLayers()
    {
        List<Layer> layers = DataBaseLoader.LoadLayers(_connection);
        while (layers.Count != Layers.Count)
        {
            if (layers.Count < Layers.Count)
            {
                Layers.RemoveAt(0);
            }
            else
            {
                Layers.Add(new Layer());
            }
        }

        for (int i = 0; i < layers.Count; i++)
        {
            Layers[i].LayerId = layers[i].LayerId;
            Layers[i].Material = layers[i].Material;
            Layers[i].HeightAtCenter = layers[i].HeightAtCenter;
            Layers[i].HeightOnSides = layers[i].HeightOnSides;
            Layers[i].WidthAtCenter = layers[i].WidthAtCenter;
            Layers[i].WidthOnSides = layers[i].WidthOnSides;
        }
    }

    public void ChangeWidthSide()
    {
        foreach (Layer selectedLayer in SelectedLayers)
        {
            selectedLayer.WidthOnSides = WidthSide;
        }
        DataBaseUpdater.UpdateLayers(_connection,SelectedLayers.ToList());
    }
    public void ChangeWidthCenter()
    {
        foreach (Layer selectedLayer in SelectedLayers)
        {
            selectedLayer.WidthAtCenter = WidthCenter;
        }
        DataBaseUpdater.UpdateLayers(_connection,SelectedLayers.ToList());
    }
    public void ChangeHeightSide()
    {
        foreach (Layer selectedLayer in SelectedLayers)
        {
            selectedLayer.HeightOnSides = HeightSide;
        }
        DataBaseUpdater.UpdateLayers(_connection,SelectedLayers.ToList());
    }
    public void ChangeHeightCenter()
    {
        foreach (Layer selectedLayer in SelectedLayers)
        {
            selectedLayer.HeightAtCenter = HeightCenter;
        }
        DataBaseUpdater.UpdateLayers(_connection,SelectedLayers.ToList());
    }

    public void ComboboxChanged()
    {
        foreach (Layer layer in SelectedLayers)
        {
            layer.Material = SelectedMaterial;
        }
        DataBaseUpdater.UpdateLayers(_connection,SelectedLayers.ToList());
    }

    public int SelectedLayerIndex { get; set; }
    public void RemoveLayers()
    {
        int index = SelectedLayerIndex;
        List<long> selected = SelectedLayers.Select(x => x.LayerId).ToList();
        foreach (long id in selected)
        {
            DataBaseRemover.RemoveLayer(_connection,id);
        }
        if (index <= 0) return;
        SelectedLayerIndex = Layers.Count > index ? index : Layers.Count;
    }

    public void CreateNewLayer()
    {
        Layer layer = new(SelectedMaterial , WidthCenter/1000,WidthSide/1000, HeightCenter/1000, HeightSide/1000);
        DataBaseCreator.NewLayer(_connection,layer);
    }
}
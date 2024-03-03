using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Flexion.Database.Actions;
using Flexion.Logic;

namespace Flexion.ViewModels;

public partial class MainViewModel
{
    #region Bindings

    private ObservableCollection<Layer> _layers = new();
    public ObservableCollection<Layer> Layers { 
        get => _layers;
        set => SetProperty(ref _layers, value);
    }
    
    public EventHandler<EventArgs>? UpdatePreviewLayer { get; set; }
    
    private ObservableCollection<Layer> _selectedLayers = new();
    public ObservableCollection<Layer> SelectedLayers { 
        get => _selectedLayers;
        set => SetProperty(ref _selectedLayers, value);
    }
    
    private int SelectedLayerIndex { get; set; }
    
    private ObservableCollection<Layer> _selectedLayersMainWindow = new();
    public ObservableCollection<Layer> SelectedLayersMainWindow { 
        get => _selectedLayersMainWindow;
        set => SetProperty(ref _selectedLayersMainWindow, value);
    }
    
    private double _widthSide;

    public double? WidthSide
    {
        get => _widthSide;
        set
        {
            _widthSide = value ?? _widthSide;
            ChangeWidthSide();
        }
    }
    
    private double _widthCenter;

    public double? WidthCenter
    {
        get => _widthCenter;
        set
        {
            _widthCenter = value ?? _widthCenter;
            ChangeWidthCenter();
        }
    }
    
    private double _heightSide;

    public double? HeightSide
    {
        get => _heightSide;
        set
        {
            _heightSide = value ?? _heightSide;
            ChangeHeightSide();
        }
    }
    
    private double _heightCenter;

    public double? HeightCenter
    {
        get => _heightCenter;
        set
        {
            _heightCenter = value ?? _heightCenter;
            ChangeHeightCenter();
        }
    }

    private Material? _selectedMaterial;
    public Material? SelectedMaterial
    {
        get => _selectedMaterial;
        set
        {
            _selectedMaterial = value;
            MaterialChanged();
        }
    }

    #endregion

    #region Layer Edition

    public void CreateNewLayer()
    {
        Layer layer = new(SelectedMaterial , _widthCenter/1000,_widthSide/1000, _heightCenter/1000, _heightSide/1000);
        DataBaseCreator.NewLayer(_connection,layer);
    }
    
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
    
    private void ChangeWidthSide()
    {
        foreach (Layer selectedLayer in SelectedLayers)
        {
            selectedLayer.WidthOnSides = _widthSide/1000;
        }
        DataBaseUpdater.UpdateLayers(_connection,SelectedLayers.ToList());
    }

    private void ChangeWidthCenter()
    {
        foreach (Layer selectedLayer in SelectedLayers)
        {
            selectedLayer.WidthAtCenter = _widthCenter/1000;
        }
        DataBaseUpdater.UpdateLayers(_connection,SelectedLayers.ToList());
    }

    private void ChangeHeightSide()
    {
        foreach (Layer selectedLayer in SelectedLayers)
        {
            selectedLayer.HeightOnSides = _heightSide/1000;
        }
        DataBaseUpdater.UpdateLayers(_connection,SelectedLayers.ToList());
    }

    private void ChangeHeightCenter()
    {
        foreach (Layer selectedLayer in SelectedLayers)
        {
            selectedLayer.HeightAtCenter = _heightCenter/1000;
        }
        DataBaseUpdater.UpdateLayers(_connection,SelectedLayers.ToList());
    }

    private void MaterialChanged()
    {
        foreach (Layer layer in SelectedLayers)
        {
            layer.Material = SelectedMaterial;
        }
        DataBaseUpdater.UpdateLayers(_connection,SelectedLayers.ToList());
    }
    
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

    #endregion
}
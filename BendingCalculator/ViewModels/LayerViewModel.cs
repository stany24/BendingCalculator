using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    #region Bindings
    
    private const double Tolerance = 0.00001;
    private bool _locked;

    [ObservableProperty] private ObservableCollection<Layer> _layers = new();
    [ObservableProperty] private bool _uiEnabledLayerEditor;

    private Layer? _selectedLayer;

    public Layer? SelectedLayer
    {
        get => _selectedLayer;
        set
        {
            SetProperty(ref _selectedLayer, value);
            SelectedLayerChanged();
        }
    }
    
    #endregion

    #region Layer Edition

    public void CreateNewLayer()
    {
        Material? material = null;
        if (Materials.Count > 0) material = Materials[0];

        Layer layer = new(material, 0.045, 0.045, 0.01, 0.01);
        DataBaseCreator.NewLayer(_connection, layer);
        SelectedLayer = Layers[^1];
    }

    public void RemoveLayer()
    {
        if (SelectedLayer == null) return;
        DataBaseRemover.RemoveLayer(_connection, SelectedLayer.Id);
        SelectedLayer = null;
    }

    private void LenghtChanged()
    {
        if (SelectedLayer == null) return;
        DataBaseUpdater.UpdateLayer(_connection, SelectedLayer);
    }

    private void MaterialChanged()
    {
        if (SelectedLayer?.Material == null) return;
        DataBaseUpdater.UpdateLayer(_connection, SelectedLayer);
    }

    private void ReloadLayers(object? sender, EventArgs eventArgs)
    {
        List<Layer> layers = DataBaseLoader.LoadLayers(_connection);
        while (layers.Count != Layers.Count)
            if (layers.Count < Layers.Count)
                Layers.RemoveAt(0);
            else
                Layers.Add(new Layer());

        for (int i = 0; i < layers.Count; i++)
        {
            Layers[i].Id = layers[i].Id;
            Layers[i].Material = layers[i].Material;
            Layers[i].HeightAtCenter = layers[i].HeightAtCenter;
            Layers[i].HeightOnSides = layers[i].HeightOnSides;
            Layers[i].WidthAtCenter = layers[i].WidthAtCenter;
            Layers[i].WidthOnSides = layers[i].WidthOnSides;
        }
    }

    private void SelectedLayerChanged()
    {
        if (SelectedLayer == null)
        {
            UiEnabledLayerEditor = false;
            return;
        }

        UiEnabledLayerEditor = true;
        SelectedLayer.PropertyChanged += (_, e) => SelectedLayerPropertyChanged(e);
    }
    
    private void SelectedLayerPropertyChanged(PropertyChangedEventArgs e)
    {
        if(_locked){return;}
        _locked = true;
        switch (e.PropertyName)
        {
            case nameof(SelectedLayer.Material):
                MaterialChanged();
                break;
            case nameof(SelectedLayer.WidthOnSides):
            case nameof(SelectedLayer.WidthAtCenter):
            case nameof(SelectedLayer.HeightAtCenter):
            case nameof(SelectedLayer.HeightOnSides):
                LenghtChanged();
                break;
        }
        _locked = false;
    }

    #endregion
}
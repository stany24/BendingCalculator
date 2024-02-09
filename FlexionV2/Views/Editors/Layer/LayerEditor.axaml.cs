using Avalonia.Controls;
using FlexionV2.ViewModels;

namespace FlexionV2.Views.Editors.Layer;

public partial class LayerEditor: Window
{
    public LayerEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
    }
}
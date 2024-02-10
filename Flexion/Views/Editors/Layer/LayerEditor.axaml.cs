using Avalonia.Controls;
using Flexion.ViewModels;

namespace Flexion.Views.Editors.Layer;

public partial class LayerEditor: Window
{
    public LayerEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
    }
}
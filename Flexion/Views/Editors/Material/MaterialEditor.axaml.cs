using Avalonia.Controls;
using Flexion.ViewModels;

namespace Flexion.Views.Editors.Material;

public partial class MaterialEditor : Window
{
    public MaterialEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
    }
}
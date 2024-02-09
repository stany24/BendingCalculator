using Avalonia.Controls;
using FlexionV2.ViewModels;

namespace FlexionV2.Views.Editors.Material;

public partial class MaterialEditor : Window
{
    public MaterialEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
    }
}
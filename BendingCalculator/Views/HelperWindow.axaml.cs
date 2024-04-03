using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;
using BendingCalculator.Logic.Helper;
using BendingCalculator.ViewModels;

namespace BendingCalculator.Views;

public partial class HelperWindow : Window
{
    public HelperWindow(IReadOnlyList<IHelperControl> modules,MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        CreateUi(modules);
    }

    private void CreateUi(IReadOnlyList<IHelperControl> modules)
    {
        StringBuilder rowDefinition = new();
        for (int i = 0; i < modules.Count; i++)
        {
            rowDefinition.Append("Auto,10,");
        }
        MainGrid.RowDefinitions = RowDefinitions.Parse(rowDefinition.ToString().Remove(rowDefinition.Length - 4));
        for (int i = 0; i < modules.Count; i++)
        {
            Control control = modules[i].GetControl();
            Grid.SetColumn(control,0);
            Grid.SetRow(control,2*i);
            MainGrid.Children.Add(control);
        }
    }
}
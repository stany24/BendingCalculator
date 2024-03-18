using Avalonia.Controls;
using BendingCalculator.ViewModels;

namespace BendingCalculator.Views.Warning;

public partial class SlideWarning : Window
{
    public SlideWarning(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
    }
}
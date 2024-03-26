using Avalonia.Controls;
using BendingCalculator.ViewModels;

namespace BendingCalculator.Views.Warning;

public partial class DetachmentWarning : Window
{
    public DetachmentWarning(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
    }
}
using Avalonia.Controls;
using BendingCalculator.ViewModels;

namespace BendingCalculator.Views.Warning;

public partial class DetachmentWarning : Window
{
    public DetachmentWarning(){} //used by compiled bindings
    public DetachmentWarning(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
    }
}
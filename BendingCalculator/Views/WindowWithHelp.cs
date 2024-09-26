using Avalonia.Controls;

namespace BendingCalculator.Views;

public class WindowWithHelp : Window
{
    private HelperWindow? _helperWindow;

    protected WindowWithHelp()
    {
        Closing += (_, _) => _helperWindow?.Close();
    }

    internal void OpenHelpWindow(string ressource)
    {
        if (_helperWindow != null) return;
        _helperWindow = new HelperWindow(ressource);
        _helperWindow.Show();
        _helperWindow.Closed += (_, _) => _helperWindow = null;
    }
}
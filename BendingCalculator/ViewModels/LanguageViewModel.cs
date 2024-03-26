using System;
using System.Linq;
using Avalonia;
using Avalonia.Markup.Xaml.Styling;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    private void Translate(object? sender, EventArgs e)
    {
        ResourceInclude? translations = Application.Current?.Resources.MergedDictionaries.OfType<ResourceInclude>().FirstOrDefault(x => x.Source?.OriginalString.Contains("/Lang/") ?? false);

        if (translations != null)
            Application.Current?.Resources.MergedDictionaries.Remove(translations);
            
        Application.Current?.Resources.MergedDictionaries.Add(
            new ResourceInclude(new Uri($"avares://BendingCalculator/Assets/Localization/Dynamic/{Language}.axaml"))
            {
                Source = new Uri($"avares://BendingCalculator/Assets/Localization/Dynamic/{Language}.axaml")
            });
    }
}
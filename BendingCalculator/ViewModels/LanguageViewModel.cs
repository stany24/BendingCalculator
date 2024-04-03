using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Avalonia;
using Avalonia.Markup.Xaml.Styling;
using BendingCalculator.Logic;
using BendingCalculator.Setting;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    public List<string> Languages { get; set; } = new() { "en", "fr", "de" };
    private string _language = SettingManager.GetLanguage();
    public string Language
    {
        get => _language;
        set
        {
            _language = value;
            SettingManager.SetLanguage(Language);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Language);
            LanguageEvents.RaiseLanguageChanged(); 
        }
    }
    
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
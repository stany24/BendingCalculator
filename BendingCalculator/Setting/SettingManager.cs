using System.IO;
using System.Text.Json;

namespace BendingCalculator.Setting;

public static class SettingManager
{
    public static string GetLanguage()
    {
        return GetSettings().Language;
    }
    
    public static bool GetWarningDisabled()
    {
        return GetSettings().WarningDisabled;
    }

    public static void SetLanguage(string language)
    {
        string settingPath = Path.Combine(Directory.GetCurrentDirectory(), "Setting/Settings.json");
        Setting setting = GetSettings();
        setting.Language = language;
        string serialized = JsonSerializer.Serialize(setting);
        File.WriteAllText(settingPath,serialized);
    }

    private static Setting GetSettings()
    {
        string settingPath = Path.Combine(Directory.GetCurrentDirectory(), "Setting/Settings.json");
        if (!File.Exists(settingPath))
        {
            string serialized = JsonSerializer.Serialize(new Setting("en",false));
            File.WriteAllText(settingPath,serialized);
        }
        Setting? setting = JsonSerializer.Deserialize<Setting>(File.ReadAllText(settingPath));
        return setting ?? new Setting();
    }
}
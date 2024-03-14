using System.IO;
using System.Text.Json;

namespace BendingCalculator.Setting;

public static class SettingManager
{
    public static string GetLanguage()
    {
        string settingPath = Path.Combine(Directory.GetCurrentDirectory(), "Setting/Settings.json");
        if (!File.Exists(settingPath))
        {
            string serialized = JsonSerializer.Serialize(new Setting("en"));
            File.WriteAllText(settingPath,serialized);
        }
        Setting? setting = JsonSerializer.Deserialize<Setting>(File.ReadAllText(settingPath));
        return setting == null ? "en" : setting.Language;
    }

    public static void SetLanguage(string language)
    {
        string settingPath = Path.Combine(Directory.GetCurrentDirectory(), "Setting/Settings.json");
        string serialized = JsonSerializer.Serialize(new Setting(language));
        File.WriteAllText(settingPath,serialized);
    }
}
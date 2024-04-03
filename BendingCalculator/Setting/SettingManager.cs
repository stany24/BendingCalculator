using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using HarfBuzzSharp;

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
        string serialized = JsonSerializer.Serialize(setting,JsonSerializerSetting.Default.Setting);
        File.WriteAllText(settingPath,serialized);
    }

    private static Setting GetSettings()
    {
        string settingPath = Path.Combine(Directory.GetCurrentDirectory(), "Setting/Settings.json");
        if (!File.Exists(settingPath))
        {
            string serialized = JsonSerializer.Serialize(new Setting("en",false),JsonSerializerSetting.Default.Setting);
            File.WriteAllText(settingPath,serialized);
        }
        Setting? setting = JsonSerializer.Deserialize<Setting>(File.ReadAllText(settingPath),JsonSerializerSetting.Default.Setting);
        return setting ?? new Setting();
    }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(Setting))]
internal partial class JsonSerializerSetting : JsonSerializerContext
{
}
using System.Text.Json.Serialization;

namespace Flexion.Setting;

public class Setting
{
    [JsonInclude]
    public string Language { get; set; }

    [JsonConstructor]
    public Setting()
    {
        Language = "en";
    }

    public Setting(string language)
    {
        Language = language;
    }
}
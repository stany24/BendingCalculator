using System.Text.Json.Serialization;

namespace FlexionV2.Setting;

public class Setting
{
    [JsonInclude]
    public string Language;
    
    [JsonConstructor]
    public Setting(){}

    public Setting(string language)
    {
        Language = language;
    }
}
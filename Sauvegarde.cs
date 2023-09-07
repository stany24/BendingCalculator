using System.Collections.Generic;
using System.Text.Json;

namespace Flexion
{
    public static class Sauvegarde
    {
        public static List<Matiere> GetMatières()
        {
            return JsonSerializer.Deserialize<List<Matiere>>(Properties.Settings.Default.Matières) ?? new List<Matiere>();
        }

        public static void SetMatières(List<Matiere> matieres)
        {
            string str = JsonSerializer.Serialize(matieres);
            Properties.Settings.Default.Matières = str;
            Properties.Settings.Default.Save();
        }
    }
}

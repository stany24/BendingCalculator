using System.Collections.Generic;
using System.Text.Json;

namespace Flexion
{
    public static class Sauvegarde
    {
        public static List<Matiere> GetMatières()
        {
            if(Properties.Settings.Default.Matières.Equals(string.Empty)) { SetMatières(new List<Matiere>()); }
            return JsonSerializer.Deserialize<List<Matiere>>(Properties.Settings.Default.Matières) ?? new List<Matiere>();
        }

        public static void SetMatières(List<Matiere> matieres)
        {
            Properties.Settings.Default.Matières = JsonSerializer.Serialize(matieres);
            Properties.Settings.Default.Save();
        }

        public static List<Couche> GetCouches()
        {
            if(Properties.Settings.Default.Couches.Equals(string.Empty)) { SetCouches(new List<Couche>()); }
            return JsonSerializer.Deserialize<List<Couche>>(Properties.Settings.Default.Couches) ?? new List<Couche>();
        }

        public static void SetCouches(List<Couche> couches)
        {
            Properties.Settings.Default.Couches = JsonSerializer.Serialize(couches);
            Properties.Settings.Default.Save();
        }
    }
}

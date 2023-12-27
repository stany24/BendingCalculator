namespace Flexion
{
    public static class Sauvegarde
    {
        public static List<Matiere> GetMatières()
        {
            if (Properties.Settings.Default.Matières.Equals(string.Empty)) { SetMatières(new List<Matiere>()); }
            return JsonSerializer.Deserialize<List<Matiere>>(Properties.Settings.Default.Matières) ?? new List<Matiere>();
        }

        public static void SetMatières(List<Matiere> matieres)
        {
            Properties.Settings.Default.Matières = JsonSerializer.Serialize(matieres);
            Properties.Settings.Default.Save();
        }

        public static List<Couche> GetCouches()
        {
            if (Properties.Settings.Default.Couches.Equals(string.Empty)) { SetCouches(new List<Couche>()); }
            return JsonSerializer.Deserialize<List<Couche>>(Properties.Settings.Default.Couches) ?? new List<Couche>();
        }

        public static void SetCouches(List<Couche> couches)
        {
            Properties.Settings.Default.Couches = JsonSerializer.Serialize(couches);
            Properties.Settings.Default.Save();
        }

        public static List<Piece> GetPieces()
        {
            if (Properties.Settings.Default.Pièces.Equals(string.Empty)) { SetPieces(new List<Piece>()); }
            return JsonSerializer.Deserialize<List<Piece>>(Properties.Settings.Default.Pièces) ?? new List<Piece>();
        }

        public static void SetPieces(List<Piece> pieces)
        {
            Properties.Settings.Default.Pièces = JsonSerializer.Serialize(pieces);
            Properties.Settings.Default.Save();
        }

        public static int GetForce()
        {
            try { return Properties.Settings.Default.Force; }
            catch
            {
                SetForce(500);
                return Properties.Settings.Default.Force;
            }
        }

        public static void SetForce(int force)
        {
            Properties.Settings.Default.Force = force;
            Properties.Settings.Default.Save();
        }
    }
}

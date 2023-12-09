using System.Text.Json.Serialization;

namespace FlexionV2.Logic
{
    public class Material
    {
        private string _nom;

        [JsonInclude]
        public string Nom
        {
            get => _nom;
            set {if (value != "") { _nom = value; }}
        }

        private double _e;
        [JsonInclude]
        public double E
        {
            get => _e;
            set { if (value > 0) { _e = value; } }
        }

        /// <summary>
        /// Instancie une nouvelle matière avec un nom et une valeur E
        /// </summary>
        /// <param name="nom">Le nom de la matière</param>
        /// <param name="e">La valeur E de la matière</param>
        public Material(string nom, double e)
        {
            Nom = nom;
            E = e;
        }

        [JsonConstructor]
        public Material() { }

        /// <summary>
        /// Retourne le nom de la matière avec sa valeur E 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Nom}:{E / 1e9}";
        }
    }
}

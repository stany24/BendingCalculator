using System.Text.Json.Serialization;

namespace FlexionV2.Logic
{
    public class Material
    {
        public int? Id { get; set; }
        
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
        
        public Material(string nom, double e)
        {
            Nom = nom;
            E = e;
        }

        [JsonConstructor]
        public Material() { }
        
        public override string ToString()
        {
            return $"{Nom}:{E / 1e9}";
        }
    }
}

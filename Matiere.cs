using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexion
{
    public class Matiere
    {
        private string Nom;
        public string GetNom() { return Nom; }
        public void SetNom(string value) { if (value != "") { Nom = value; } }

        private double E;
        public double GetE() { return E; }
        public void SetE(double value) { if (value > 0) { E = value; } }


        public Matiere(string nom, double e)
        {
            Nom = nom;
            E = e;
        }

        public override string ToString()
        {
            return $"{Nom} de constante {E}";
        }
    }
}

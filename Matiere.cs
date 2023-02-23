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

        /// <summary>
        /// Instancie une nouvelle matière avec un nom et une valeur E
        /// </summary>
        /// <param name="nom">Le nom de la matière</param>
        /// <param name="e">La valeur E de la matière</param>
        public Matiere(string nom, double e)
        {
            Nom = nom;
            E = e;
        }

        /// <summary>
        /// Retourne le nom de la matière avec sa valeur E 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Nom}:{E}";
        }
    }
}

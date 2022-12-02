using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexion
{
    public class Couche
    {
        public readonly double Largeur;
        public readonly double Hauteur;
        public readonly Matiere Matiere;

        public Couche(Matiere matiere,double largeur,double hauteur)
        {
            Matiere = matiere;
            Largeur = largeur;
            Hauteur = hauteur;
        }

        public override string ToString()
        {
            return $"Couche de {Matiere.Nom} L={Largeur} H={Hauteur}";
        }
    }
}

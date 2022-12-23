using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexion
{
    public class Couche
    {
        public readonly double LargeurCenter;
        public readonly double LargeurSide;
        public readonly double HauteurCenter;
        public readonly double HauteurSide;
        public readonly Matiere Matiere;

        public Couche(Matiere matiere,double largeur,double hauteur)
        {
            Matiere = matiere;
            LargeurCenter = largeur;
            LargeurSide = largeur;
            HauteurCenter = hauteur;
            HauteurSide = hauteur;
        }
        public Couche(Matiere matiere, double largeurCenter, double largeurSide, double hauteurCenter ,double hauteurSide)
        {
            Matiere = matiere;
            LargeurCenter = largeurCenter;
            LargeurSide = largeurSide;
            HauteurCenter = hauteurCenter;
            HauteurSide = hauteurSide;
        }

        public override string ToString()
        {
            return $"C de {Matiere.Nom} Lm={LargeurCenter} Lc={LargeurSide} Hm={HauteurCenter} Hc={HauteurSide}";
        }

        public double EstimateVolumeFromX(double Lo,double Lp,double Le,double Ep,double Ee,double X,double Ecart)
        {
            double Px = X * (X / Lo + Lo - 2);
            double P2 = ((8 + Lo) / 16) - Lo * Lo;
            double P31 = Ee - Ep;
            double P32 = (-2 * Lp - 2 * Le) * Lo;
            double P33 = Math.Pow(Lo, 3) * (Le + Lo * Lo / 2 - Ee - Ep - Lp);
            double P3 = P31 * P32 + P33;
            double Estimate = Px * P2 * P3;
            return Estimate;
        }

        public double I(double Longueur,double Z)
        {
            double Base = Longueur * LargeurCenter;
            return (Base * Math.Pow(HauteurCenter, 3)) / 12 + HauteurCenter * Base * Z*Z;
        }
    }
}

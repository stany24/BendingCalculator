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
            HauteurCenter = hauteur;
        }
        public Couche(Matiere matiere, double largeurCenter, double largeurSide, double hauteurCenter ,double hauteurSide)
        {
            Matiere = matiere;
            LargeurCenter = largeurCenter;
            LargeurSide = largeurSide;
            HauteurCenter = hauteurCenter;
            HauteurCenter = hauteurSide;
        }

        public override string ToString()
        {
            return $"C de {Matiere.Nom} Lm={LargeurCenter} Lc={LargeurSide} Hm={HauteurCenter} Hc={HauteurSide}";
        }

        public double EstimateVolumeFromX(double Lo,double Lp,double Le,double Ep,double Ee,double X,double Ecart)
        {
            double Estimate = 0;
            double P2 = ((8 + Lo) / 16) - Lo * Lo;
            double P31 = Ee - Ep;
            double P32 = (-2 * Lp - 2 * Le) * Lo;
            double P33 = Math.Pow(Lo, 3) * (Le + Lo * Lo / 2 - Ee - Ep - Lp);
            double P3 = P31 * P32 + P33;
            double P23 = P2 * P3;
            double X1 = 0;
            for (double i = 0 ; i < X ; i += Ecart)
            {
                X1 = (i + X1) * i;
                double Px = X * (X / Lo + Lo - 2);
                Estimate += Px * P23;
            }
            return Estimate * Ecart;
        }
    }
}

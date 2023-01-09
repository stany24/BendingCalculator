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

        public double double Surface()
        {
            double Lf, Li = Largeur();
            double Ef, Ei = Hauteur();
            double Sf = Lf * Ef;
            double Si = Li * Ei;
            return Sf,Si;
        }

        public double double Largeur()
        {
            double L1 = (4 * Le1 - 4 * Lp1) / (Lo * Lo);
            double L2 = (x - Lo / 2) * (x - Lo / 2);
            double L3 = (Xi - Lo / 2) * (Xi - Lo / 2);
            double Lf = L11 * L12 + Lp1;
            double Li = L11 * L13 + Lp1;
            return Lf,Li
        }

        public double double Hauteur()
        {
            double E1 = (4 * Ee1 - 4 * Ep1) / (Lo * *2);
            double E2 = (x - Lo / 2) * *2;
            double E3 = (Xi - Lo / 2) * *2;
            double Ef = E11 * E12 + Ep1;
            double Ei = E11 * E13 + Ep1;
            return Ef,Ei;
        }

        public double Integrale(double e, double p,bool temp)
        {
            double X113 = (((4 * e) - (4 * p)) / (3 * (Lo * *2))) * Math.Pow(Xi,3)
            double X112 = (((2 * e) - (2 * p)) / Lo) * (Xi * *2)
            double X111 = e * Xi
            double X103 = (((4 * e) - (4 * p)) / (3 * (Lo * *2))) * Math.Pow(Dep, 3)
            double X102 = (((2 * e) - (2 * p)) / Lo) * (Dep * *2)
            double X101 = e * Dep

            double Int11 = (X113 - X112 + X111) - (X103 - X102 - X101);
            double B1 = Int11 / Xi;
            if(temp) { return B1; }
            else { return B1f = B1 / Eref * Ela1; }
        }
    }
}

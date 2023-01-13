using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexion
{
    public class Couche
    {
        public readonly double LargeurCenter; //lp
        public readonly double LargeurSide; //le
        public readonly double HauteurCenter; //ep
        public readonly double HauteurSide; // ee
        public readonly Matiere Matiere;

        Dictionary<string, double> values = new Dictionary<string, double>();

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

        public void Surface()
        {
            double Sf = values["Lf"] * values["Ef"];
            double Si = values["Li"] * values["Ei"];
            values.Add("Sf", Sf);
            values.Add("Si", Si);
        }

        public void Largeur(double lenght, double Xi)
        {
            double L1 = (4 * LargeurSide - 4 * LargeurCenter) / (lenght * lenght);
            double L2 = (x - lenght / 2) * (x - lenght / 2);
            double L3 = (Xi - lenght / 2) * (Xi - lenght / 2);
            double Lf = L1 * L2 + LargeurCenter;
            double Li = L1 * L3 + LargeurCenter;
            values.Add("Lf", Lf);
            values.Add("Li", Li);
        }

        public void Hauteur(double lenght, double Xi)
        {
            double E1 = (4 * HauteurSide - 4 * HauteurCenter) / (lenght * lenght);
            double E2 = Math.Pow(x - lenght / 2,2);
            double E3 = Math.Pow(Xi - lenght / 2,2);
            double Ef = E1 * E2 + HauteurCenter;
            double Ei = E1 * E3 + HauteurCenter;
            values.Add("Ef", Ef);
            values.Add("Ei", Ei);
        }

        public double Integrale(bool temp, double lenght, double Xi, double Dep, double Eref)
        {
            double X3 = (((4 * Matiere.E) - (4 * LargeurCenter)) / (3 * (lenght * lenght))) * Math.Pow(Xi, 3);
            double X2 = (((2 * Matiere.E) - (2 * LargeurCenter)) / lenght) * (Xi * Xi);
            double X1 = Matiere.E * Xi;
            double X13 = (((4 * Matiere.E) - (4 * LargeurCenter)) / (3 * (lenght * lenght))) * Math.Pow(Dep, 3);
            double X12 = (((2 * Matiere.E) - (2 * LargeurCenter)) / lenght) * (Dep * Dep);
            double X11 = Matiere.E * Dep;

            double Int11 = (X3 - X2 + X1) - (X13 - X12 - X11);
            double B1 = Int11 / Xi;
            if(temp) { return B1; }
            else { return B1 / Eref * Matiere.E; }
        }
    }
}

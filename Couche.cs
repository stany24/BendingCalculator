using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexion
{
    public class Couche
    {
        private double LargeurCenter; //lp
        public void SetLargeurCenter(double largeurCenter){if (largeurCenter > 0){LargeurCenter = largeurCenter; }}
        public double GetLargeurCenter() { return LargeurCenter; }

        private double LargeurSide; //le
        public void SetLargeurSide(double largeurSide) { if (largeurSide > 0) { LargeurSide = largeurSide; } }
        public double GetLargeurSide() { return LargeurSide; }

        private double HauteurCenter; //ep
        public void SetHauteurCenter(double hauteurCenter) { if (hauteurCenter > 0) { HauteurCenter = hauteurCenter; } }
        public double GetHauteurCenter() { return HauteurCenter; }

        private double HauteurSide; // ee
        public void SetHauteurSide(double hauteurSide) { if (hauteurSide > 0) { HauteurSide = hauteurSide; } }
        public double GetHauteurSide() { return HauteurSide; }

        private Matiere MatiereCouche;
        public void SetMatiere(Matiere matiere) { MatiereCouche = matiere; }
        public Matiere GetMatiere() { return MatiereCouche; }

        Dictionary<string, double> values = new Dictionary<string, double>();

        /// <summary>
        /// Crée une nouvelle couche avec la matière donnée et une longueur et un largeur uniforme.
        /// </summary>
        /// <param name="matiere">Matière de la couche</param>
        /// <param name="largeur">Largeur au centre et sur les côté de la couche</param>
        /// <param name="hauteur">Hauteur au centre et sur les côté de la couche</param>
        public Couche(Matiere matiere,double largeur,double hauteur)
        {
            SetMatiere(matiere);
            SetLargeurCenter(largeur);
            SetLargeurSide(largeur);
            SetHauteurCenter(hauteur);
            SetHauteurSide(hauteur);
        }

        /// <summary>
        /// Crée une nouvelle couche avec la matière donnée et une longueur et un largeur non-uniforme.
        /// </summary>
        /// <param name="matiere">Matière de la couche</param>
        /// <param name="largeurCenter">Largeur au centre de la couche</param>
        /// <param name="largeurSide">Largeur sur les côté de la couche</param>
        /// <param name="hauteurCenter">Hauteur au centre  de la couche</param>
        /// <param name="hauteurSide">Hauteur sur les côté de la couche</param>
        public Couche(Matiere matiere, double largeurCenter, double largeurSide, double hauteurCenter ,double hauteurSide)
        {
            SetMatiere(matiere);
            SetLargeurCenter(largeurCenter);
            SetLargeurSide(largeurSide);
            SetHauteurCenter(hauteurCenter);
            SetHauteurSide(hauteurSide);
        }

        /// <summary>
        /// Retourne un résumé de la couche
        /// </summary>
        /// <returns>Le nom de la matière, la largeur au centre, la largeur sur les côtés, la hauteur au centre, la hauteur sur les côtés</returns>
        public override string ToString()
        {
            return $"C de {MatiereCouche.GetNom()} Lm={LargeurCenter} Lc={LargeurSide} Hm={HauteurCenter} Hc={HauteurSide}";
        }

        public List<double> CalcutateX(double longueur,double ecart)
        {
            List<double> X = new List<double>();
            for(double i = 0; i<= longueur+ecart; i+= ecart)
            {
                X.Add(i);
            }
            return X;
        }

        public double I(double Longueur,double Z)
        {
            double Base = Longueur * LargeurCenter;
            return (Base * Math.Pow(HauteurCenter, 3)) / 12 + HauteurCenter * Base * Z*Z;
        }
       
        public List<double> Largeur(double longueur, double Eref,double ecart)
        {
            double L1 = (4*LargeurSide - 4*LargeurCenter)/Math.Pow(longueur,2);

            List<double> L2 = new List<double>();
            foreach (double x in CalcutateX(longueur,ecart))
            {
                L2.Add(Math.Pow(x - longueur / 2, 2));
            }

            List<double> Lf = new List<double>();
            foreach (double l2 in L2)
            {
                Lf.Add(L1 * l2 + LargeurCenter);
            }
            
            List<double> Largeur = new List<double>();
            foreach (double lf in Lf)
            {
                Largeur.Add(lf / Eref * MatiereCouche.GetE());
            }
            return Largeur;
        }

        public List<double> Hauteur(double longueur, double ecart)
        {
            double E1 = (4 * HauteurSide - 4 * HauteurCenter) / Math.Pow(longueur, 2);

            List<double> E2 = new List<double>();
            foreach (double x in CalcutateX(longueur,ecart))
            {
                E2.Add(Math.Pow(x - longueur / 2, 2));
            }

            List<double> Ef = new List<double>();
            foreach (double l2 in E2)
            {
                Ef.Add(E1 * l2 + HauteurCenter);
            }
            return Ef;
        }

        public List<double> Surface(double lenght, double Eref,double ecart)
        {
            List<double> Surfaces = new List<double>();
            List<double> Largeurs = Largeur(lenght,Eref,ecart);
            List<double> Hauteurs = Hauteur(lenght,ecart);
            for (int i = 0; i < Largeurs.Count; i++)
            {
                Surfaces.Add(Largeurs[i] * Hauteurs[i]);
            }
            return Surfaces;
        }
    }
}
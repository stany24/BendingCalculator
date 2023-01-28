using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexion
{
    public class Piece
    {
        public List<Couche> Couches = new List<Couche>();
        private string Nom;

        public string GetNom(){return Nom;}
        public void SetNom(string value){ if (value != "") { Nom = value; }}

        private double Longueur;//lo
        public double GetLongueur() { return Longueur; }
        public void SetLongueur(double value) {if (value > 0) { Longueur = value; }}

        private double Xi = 1.5;
        public double GetXi() { return Xi; }
        public void SetXi(double value) {if (value > 0) { Xi = value; }}

        private double Dep = 0;
        public double GetDep() { return Dep; }
        public void SetDep(double value) {if (value > 0) { Dep = value; }}

        private double Eref = 69e9;
        public double GetEref() { return Eref; }
        public void SetEref(double value) {if (value > 0) { Eref = value; }}

        /// <summary>
        /// Instancie une pièce avec une longueur et un nom
        /// </summary>
        /// <param name="longueur">Longueur de la pièce</param>
        /// <param name="nom">Nom de la pièce</param>
        public Piece(double longueur, string nom)
        {
            SetLongueur(longueur);
            SetNom(nom);
        }

        /// <summary>
        /// Retourne le nom et la longueur de la pièce
        /// </summary>
        /// <returns></returns>
        public override string ToString(){return $"{GetNom()} de {Longueur} cm.";}

        public double Zf(double F, double E){return -F * (Math.Pow(Longueur, 3) / (48 * E * IGeneral()));}

        public double IGeneral()
        {
            double I=0;
            foreach (Couche couche in Couches)
            {
                I+= couche.I(Longueur,1);
            }
            return I;
        }

        public List<double> Ns()
        {
            List<double> Ns = new List<double>();
            double[][] Nx = new double[Couches.Count][];
            double[][] divise = new double[Couches.Count][];

            //Calcule de tout les n1, n2, n3... dans le tableau Nx
            for (int i = 0; i < Couches.Count; i++)
            {
                while(i< Couches.Count-1)
                {
                    for (int j = 0; j < Couches[i].Hauteur(Longueur).Count; j++)
                    {
                        Nx[i][j] = Couches[i].Hauteur(Longueur).ToArray()[j];
                    }
                }
                for (int k = 0; k < Couches[i].Hauteur(Longueur).Count; k++)
                {
                    Nx[i][k] = Couches[i].Hauteur(Longueur).ToArray()[k]/2;
                }
            }

            // Calcule de tout les divisé dans le tableau divise
            for (int i = 0; i < Couches.Count; i++)
            {
                for (int j = 0; j < Couches[i].Surface(Longueur,Eref).Count; j++)
                {
                    divise[i][j] = Nx[i][j] * Couches[i].Surface(Longueur, Eref).ToArray()[j];
                }
            }

            for (int i = 0; i < Nx[0].Length; i++)
            {
                double top = 0;
                for(int j = 0;j < Nx.Length;j++)
                {
                    top += Nx[j][i];
                }
                double bottom = 0;
                for (int k = 0;k < Couches.Count;k++)
                {
                    bottom += Couches[k].Surface(Longueur, Eref)[i];
                }
                Ns.Add(top / bottom);
            }

            return Ns;
        }
    }
}

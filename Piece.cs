using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flexion;

namespace Flexion
{
    public class Piece
    {
        readonly private AdditionalMath math = new AdditionalMath();
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

        private double Ecart = 1e-2;
        public double GetEcart() { return Ecart; }
        public void SetEcart(double ecart) { if (ecart > 0) { Ecart = ecart; } }

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

        public double[] Ns()
        {
            int nbX = Couches[0].CalcutateX(Longueur,Ecart).Count();
            double[] Ns = new double[nbX];
            double[][] Nx = new double[Couches.Count][];
            double[] divise = new double[nbX];
            double[] divisant = new double[nbX];

            //initialise les arrays
            for (int i = 0; i < Nx.Length; i++)
            {
                Nx[i] = new double[nbX];
            }

            //calcule les Nx de manière généralisé.
            for (int i = 0; i < Couches.Count; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if(j == i)
                    {
                        double[] add = math.DivideArrayBydouble(Couches[j].Hauteur(Longueur,Ecart).ToArray(), 2);
                        Nx[i] = math.AddDoubleArray(Nx[i],add);
                    }
                    else
                    {
                        Nx[i] = math.AddDoubleArray(Nx[i], Couches[j].Hauteur(Longueur,Ecart).ToArray());
                    }
                }
            }

            //calucule du divisé
            for (int i = 0; i < Couches.Count; i++)
            {
                double[] ajout = math.MultiplyDoubleArray(Couches[i].Surface(Longueur, Eref, Ecart).ToArray(), Nx[i]);
                divise = math.AddDoubleArray(divise, ajout);
            }

            // calcule du divisant
            for (int i = 0; i < Couches.Count; i++)
            {
                divisant = math.AddDoubleArray(divisant, Couches[i].Surface(Longueur,Eref,Ecart).ToArray());
            }
            //calcule de Ns
            Ns = math.DivideDoubleArrayByDoubleArray(divise, divisant);
            return Ns;
        }
    }
}

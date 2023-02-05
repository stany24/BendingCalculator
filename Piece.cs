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
        /*
        public double[][] MomentForce()
        {
            double F1 = 0;
            double b1 = 0;
            int nbX = Couches[0].CalcutateX(Longueur, Ecart).Count();
            double[][] moments = new double[nbX][];
            foreach (double[] moment in moments)
            {
                if (< nbX / 2)
                {
                    double[] divise = math.MultiplyArrayBydouble(Couches[0].CalcutateX(Longueur,Ecart).ToArray(), -F1 * b1);
                    moment = math.DivideArrayBydouble(divise, Longueur);
                }
                else
                {

                }
            }
            return moments;
        }*/

        public double[] CalculateI()
        {
            int nbX = Couches[0].CalcutateX(Longueur, Ecart).Count();
            double[][] Ix = new double[Couches.Count][];
            double[] I = new double[nbX];

            //initialise les arrays
            for (int i = 0; i < Ix.Length; i++)
            {
                Ix[i] = new double[nbX];
            }

            //calcule les Ix de manière généralisé.
            for (int i = 0; i < Couches.Count; i++)
            {
                double[] power = math.PowerArrayBydouble(Couches[i].Hauteur(Longueur,Ecart).ToArray(),3);
                double[] divise = math.MultiplyDoubleArrayByDoubleArray(power, Couches[i].Base(Longueur,Ecart,Eref));
                Ix[i] = math.DivideArrayBydouble(divise, 12);
            }

            for (int i = 0; i < Couches.Count; i++)
            {
                double[] P1 = math.PowerArrayBydouble(Ns(), 2);
                double[] P2 = math.RemoveDoubleArrayToDoubleArray(CalculateNx(i,nbX), P1);
                double[] P3 = math.MultiplyDoubleArrayByDoubleArray(Couches[i].Surface(Longueur,Eref,Ecart).ToArray(), P2);
                I = math.Add2DoubleArray(I, P3);
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
                Nx[i] = CalculateNx(i,nbX);
            }

            //calucule du divisé
            for (int i = 0; i < Couches.Count; i++)
            {
                double[] ajout = math.MultiplyDoubleArrayByDoubleArray(Couches[i].Surface(Longueur, Eref, Ecart).ToArray(), Nx[i]);
                divise = math.Add2DoubleArray(divise, ajout);
            }

            // calcule du divisant
            for (int i = 0; i < Couches.Count; i++)
            {
                divisant = math.Add2DoubleArray(divisant, Couches[i].Surface(Longueur,Eref,Ecart).ToArray());
            }
            //calcule de Ns
            Ns = math.DivideDoubleArrayByDoubleArray(divise, divisant);
            return Ns;
        }

        public double[] CalculateNx(int i,int length)
        {
            double[] Nx= new double[length];
            for (int j = 0; j <= i; j++)
            {
                if (j == i)
                {
                    double[] add = math.DivideArrayBydouble(Couches[j].Hauteur(Longueur, Ecart).ToArray(), 2);
                    Nx = math.Add2DoubleArray(Nx, add);
                }
                else
                {
                    Nx = math.Add2DoubleArray(Nx, Couches[j].Hauteur(Longueur, Ecart).ToArray());
                }
            }
            return Nx;
        }
    }
}

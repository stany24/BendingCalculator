using System;
using System.Collections.Generic;
using System.Linq;

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

        private double Eref = 69e9;
        public double GetEref() { return Eref; }
        public void SetEref(double value) {if (value > 0) { Eref = value; }}

        private double Ecart = 1e-4;
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

        public Piece(double longueur, string nom, double eref)
        {
            SetLongueur(longueur);
            SetNom(nom);
            SetEref(eref);
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
        public double[] MomentForce()
        {
            double F = CalcuateF();
            double b1 = Longueur/2;
            double[] X = CalcutateX().ToArray();
            int nbX = CalcutateX().Count();
            double[] moments = new double[nbX];

            double[] Mfa1 = math.OperationDoubleArray(CalcutateX().ToArray(), -F * b1, AdditionalMath.Operation.Fois);
            Mfa1 = math.OperationDoubleArray(Mfa1, Longueur, AdditionalMath.Operation.Divisé);
            
            double[] Mfb1 = math.OperationDoubleArray(CalcutateX().ToArray(), Longueur - b1, AdditionalMath.Operation.Moins);
            Mfb1 = math.OperationDoubleArray(Mfb1, F, AdditionalMath.Operation.Fois);
            Mfb1 = math.OperationDoubleArray(Mfa1, Mfb1, AdditionalMath.Operation.Plus);

            for (int i = 0; i < nbX; i++)
            {
                if (X[i] < b1)
                {
                    moments[i] = Mfa1[i];
                }
                else
                {
                    moments[i] = Mfb1[i];
                }
            }
            return moments;
        }

        public double[] Intégrale()
        {
            double[] integrale1 = new double[CalcutateX().Count()];
            double[] integrale2 = new double[CalcutateX().Count()];
            double[] integrale3 = new double[CalcutateX().Count()];
            double[] moment = MomentForce();
            double[] I = CalculateI();
            // calcule
            for (int i = 0; i < moment.Count(); i++)
            {
                integrale1[i] = moment[i] / I[i];
            }
            // première intégrale
            for (int i = 0; i < moment.Count(); i++)
            {
                if(i-1 <0)
                {
                    integrale2[i] = integrale1[i] * Ecart;
                }
                else
                {
                    integrale2[i] = integrale2[i - 1] + integrale1[i] * Ecart;
                }
            }

            // 
            double offset = integrale2[Convert.ToInt32(integrale2.Count() / 2)];
            for (int i = 0; i < integrale2.Count(); i++)
            {
                integrale2[i] -= offset;
            }

            // deuxième intégrale
            for (int i = 0; i < integrale3.Count(); i++)
            {
                if (i - 1 < 0)
                {
                    integrale3[i] = integrale2[i] * Ecart;
                }
                else
                {
                    integrale3[i] = integrale3[i - 1] + integrale2[i] * Ecart;
                }
            }
            //
            for (int i = 0; i < integrale3.Count(); i++)
            {
                integrale3[i] = integrale3[i] / -Eref;
            }

            return integrale3;
        }

        public int getNbMoment()
        {
            return MomentForce().Count();
        }

        public double CalcuateF()
        {
            double m = 70;
            double r = 22;
            double v = 60 / 3.6;
            double g = 9.81;
            return 500;
            return m*Math.Sqrt(Math.Pow(g,2) + (Math.Pow(v,4) / Math.Pow(r,2)));
        }

        public double[] CalcutateX()
        {
            List<double> X = new List<double>();
            for (double i = 0; i <= Longueur + Ecart; i += Ecart)
            {
                X.Add(i);
            }
            return X.ToArray();
        }

        public double[] CalculateI()
        {
            int nbX = CalcutateX().Count();
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
                double[] power = math.OperationDoubleArray(Couches[i].Hauteur(Longueur,Ecart, CalcutateX()).ToArray(),3,AdditionalMath.Operation.Puissance);
                double[] divise = math.OperationDoubleArray(power, Couches[i].Base(Longueur,Ecart,Eref, CalcutateX()),AdditionalMath.Operation.Fois);
                Ix[i] = math.OperationDoubleArray(divise, 12,AdditionalMath.Operation.Divisé);
            }

            for (int i = 0; i < Couches.Count; i++)
            {
                double[] P1 = math.OperationDoubleArray(CalculateNx(i, nbX), Ns(),AdditionalMath.Operation.Moins);
                double[] P2 = math.OperationDoubleArray(P1, 2,AdditionalMath.Operation.Puissance);
                double[] P3 = math.OperationDoubleArray(Couches[i].Surface(Longueur,Eref,Ecart, CalcutateX()).ToArray(), P2,AdditionalMath.Operation.Fois);
                double[] P4 = math.OperationDoubleArray(Ix[i], P3, AdditionalMath.Operation.Plus);
                I = math.OperationDoubleArray(I, P4,AdditionalMath.Operation.Plus);
            }
            return I;
        }

        public double[] Ns()
        {
            int nbX = CalcutateX().Count();
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
                double[] ajout = math.OperationDoubleArray(Couches[i].Surface(Longueur, Eref, Ecart, CalcutateX()).ToArray(), Nx[i], AdditionalMath.Operation.Fois);
                divise = math.OperationDoubleArray(divise, ajout,AdditionalMath.Operation.Plus);
            }

            // calcule du divisant
            for (int i = 0; i < Couches.Count; i++)
            {
                divisant = math.OperationDoubleArray(divisant, Couches[i].Surface(Longueur,Eref,Ecart, CalcutateX()).ToArray(),AdditionalMath.Operation.Plus);
            }
            //calcule de Ns
            return math.OperationDoubleArray(divise, divisant, AdditionalMath.Operation.Divisé); ;
        }

        public double[] CalculateNx(int i,int length)
        {
            double[] Nx= new double[length];
            for (int j = 0; j <= i; j++)
            {
                if (j == i)
                {
                    double[] add = math.OperationDoubleArray(Couches[j].Hauteur(Longueur, Ecart, CalcutateX()).ToArray(), 2,AdditionalMath.Operation.Divisé);
                    Nx = math.OperationDoubleArray(Nx, add,AdditionalMath.Operation.Plus);
                }
                else
                {
                    Nx = math.OperationDoubleArray(Nx, Couches[j].Hauteur(Longueur, Ecart, CalcutateX()).ToArray(),AdditionalMath.Operation.Plus);
                }
            }
            return Nx;
        }
    }
}

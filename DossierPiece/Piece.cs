﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private double Longueur = 1;//lo
        public double GetLongueur() { return Longueur; }
        public void SetLongueur(double value) {if (value > 0) { Longueur = value; }}

        private double Eref = 69e9;
        public double GetEref() { return Eref; }
        public void SetEref(double value) {if (value > 0) { Eref = value; }}

        private double[] Xs;

        public double[] SetX(double ecart)
        {
            List<double> X = new List<double>();
            for (double i = 0; i <= Longueur + ecart; i += ecart)
            {
                X.Add(i);
            }
            return X.ToArray();
        }

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

        public Piece(double longueur, string nom, double eref,double ecart)
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

        public double[] MomentForce(double Force)
        {
            double b1 = Longueur/2;
            double[] X = Xs;
            double[] moments = new double[Xs.Length];

            double[] Mfa1 = math.OperationDoubleArray((double[])Xs.Clone(), -Force * b1, AdditionalMath.Operation.Fois);
            Mfa1 = math.OperationDoubleArray(Mfa1, Longueur, AdditionalMath.Operation.Divisé);
            
            double[] Mfb1 = math.OperationDoubleArray((double[])Xs.Clone(), Longueur - b1, AdditionalMath.Operation.Moins);
            Mfb1 = math.OperationDoubleArray(Mfb1, Force, AdditionalMath.Operation.Fois);
            Mfb1 = math.OperationDoubleArray(Mfa1, Mfb1, AdditionalMath.Operation.Plus);

            for (int i = 0; i < Xs.Length; i++)
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

        public double[] Intégrale(double Force,double ecart)
        {
            Xs = SetX(ecart);
            double[] integrale1 = new double[Xs.Length];
            double[] integrale2 = new double[Xs.Length];
            double[] integrale3 = new double[Xs.Length];
            double[] moment = MomentForce(Force);
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
                    integrale2[i] = integrale1[i] * ecart;
                }
                else
                {
                    integrale2[i] = integrale2[i - 1] + integrale1[i] * ecart;
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
                    integrale3[i] = integrale2[i] * ecart;
                }
                else
                {
                    integrale3[i] = integrale3[i - 1] + integrale2[i] * ecart;
                }
            }
            //
            for (int i = 0; i < integrale3.Count(); i++)
            {
                integrale3[i] = integrale3[i] / -Eref;
            }
            return integrale3;
        }

        public double[] CalculateI()
        {
            double[][] Ix = new double[Couches.Count][];
            double[] I = new double[Xs.Length];

            //initialise les arrays
            for (int i = 0; i < Ix.Length; i++)
            {
                Ix[i] = new double[Xs.Length];
            }

            //calcule les Ix de manière généralisé.
            for (int i = 0; i < Couches.Count; i++)
            {
                double[] power = math.OperationDoubleArray(Couches[i].Hauteur(Longueur, (double[])Xs.Clone()).ToArray(),3,AdditionalMath.Operation.Puissance);
                double[] divise = math.OperationDoubleArray(power, Couches[i].Base(Longueur,Eref, (double[])Xs.Clone()),AdditionalMath.Operation.Fois);
                Ix[i] = math.OperationDoubleArray(divise, 12,AdditionalMath.Operation.Divisé);
            }

            for (int i = 0; i < Couches.Count; i++)
            {
                double[] P1 = math.OperationDoubleArray(CalculateNx(i, Xs.Length), Ns(),AdditionalMath.Operation.Moins);
                double[] P2 = math.OperationDoubleArray(P1, 2,AdditionalMath.Operation.Puissance);
                double[] P3 = math.OperationDoubleArray(Couches[i].Surface(Longueur,Eref, (double[])Xs.Clone()).ToArray(), P2,AdditionalMath.Operation.Fois);
                double[] P4 = math.OperationDoubleArray(Ix[i], P3, AdditionalMath.Operation.Plus);
                I = math.OperationDoubleArray(I, P4,AdditionalMath.Operation.Plus);
            }
            return I;
        }

        public double[] Ns()
        {
            double[][] Nx = new double[Couches.Count][];
            double[] divise = new double[Xs.Length];
            double[] divisant = new double[Xs.Length];

            //initialise les arrays
            for (int i = 0; i < Nx.Length; i++)
            {
                Nx[i] = new double[Xs.Length];
            }

            //calcule les Nx de manière généralisé.
            for (int i = 0; i < Couches.Count; i++)
            {
                Nx[i] = CalculateNx(i, Xs.Length);
            }

            //calucule du divisé
            for (int i = 0; i < Couches.Count; i++)
            {
                double[] ajout = math.OperationDoubleArray(Couches[i].Surface(Longueur, Eref, (double[])Xs.Clone()).ToArray(), Nx[i], AdditionalMath.Operation.Fois);
                divise = math.OperationDoubleArray(divise, ajout,AdditionalMath.Operation.Plus);
            }

            // calcule du divisant
            for (int i = 0; i < Couches.Count; i++)
            {
                divisant = math.OperationDoubleArray(divisant, Couches[i].Surface(Longueur,Eref, (double[])Xs.Clone()).ToArray(),AdditionalMath.Operation.Plus);
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
                    double[] add = math.OperationDoubleArray(Couches[j].Hauteur(Longueur, (double[])Xs.Clone()).ToArray(), 2,AdditionalMath.Operation.Divisé);
                    Nx = math.OperationDoubleArray(Nx, add,AdditionalMath.Operation.Plus);
                }
                else
                {
                    Nx = math.OperationDoubleArray(Nx, Couches[j].Hauteur(Longueur, (double[])Xs.Clone()).ToArray(),AdditionalMath.Operation.Plus);
                }
            }
            return Nx;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace FlexionV2.Logic
{
    public class Layer
    {
        private double _widthAtCenter;
        [JsonInclude]
        public double WidthAtCenter
        {
            get =>_widthAtCenter;
            set { if (value > 0) { _widthAtCenter = value; } }
        }

        private double _widthOnSide;
        [JsonInclude]
        public double WidthOnSide
        {
            get =>_widthOnSide;
            set { if (value > 0) { _widthOnSide = value; } }
        }

        private double _heightAtCenter;
        [JsonInclude]
        public double HeightAtCenter
        {
            get =>_heightAtCenter;
            set { if (value > 0) { _heightAtCenter = value; } }
        }

        private double _heightOnSide;
        [JsonInclude]
        public double HeightOnSide
        {
            get =>_heightOnSide;
            set { if (value > 0) { _heightOnSide = value; } }
        }

        [JsonInclude]
        public Material Material { get; set; }
        
        [JsonConstructor]
        public Layer() { }

        /// <summary>
        /// Cr�e une nouvelle couche avec la mati�re donn�e et une longueur et un largeur uniforme.
        /// </summary>
        /// <param name="material">Mati�re de la couche</param>
        /// <param name="width">Largeur au centre et sur les c�t� de la couche</param>
        /// <param name="height">Hauteur au centre et sur les c�t� de la couche</param>
        public Layer(Material material, double width, double height)
        {
            Material = material;
            WidthAtCenter=width;
            WidthOnSide=width;
            HeightAtCenter=height;
            HeightOnSide = height;
        }

        /// <summary>
        /// Cr�e une nouvelle couche avec la mati�re donn�e et une longueur et un largeur non-uniforme.
        /// </summary>
        /// <param name="material">Mati�re de la couche</param>
        /// <param name="widthCenter">Largeur au centre de la couche</param>
        /// <param name="widthSide">Largeur sur les c�t� de la couche</param>
        /// <param name="heightCenter">Hauteur au centre  de la couche</param>
        /// <param name="heightSide">Hauteur sur les c�t� de la couche</param>
        public Layer(Material material, double widthCenter, double widthSide, double heightCenter, double heightSide)
        {
            Material = material;
            WidthAtCenter = widthCenter;
            WidthOnSide=widthSide;
            HeightAtCenter=heightCenter;
            HeightOnSide=heightSide;
        }

        /// <summary>
        /// Retourne un r�sum� de la couche
        /// </summary>
        /// <returns>Le nom de la mati�re, la largeur au centre, la largeur sur les c�t�s, la hauteur au centre, la hauteur sur les c�t�s</returns>
        public override string ToString()
        {
            return $"{Material.GetNom()} M={WidthAtCenter * 1000}x{HeightAtCenter * 1000} C={WidthOnSide * 1000}x{HeightOnSide * 1000}";
        }

        public double[] Base(double longueur, double eref, double[] xs)
        {
            double l1 = (4 * WidthOnSide - 4 * WidthAtCenter) / Math.Pow(longueur, 2);
            double[] l2 = AdditionalMath.OperationDoubleArray(xs, longueur / 2, AdditionalMath.Operation.Minus);
            l2 = AdditionalMath.OperationDoubleArray(l2, 2, AdditionalMath.Operation.Power);
            double[] baseArea = AdditionalMath.OperationDoubleArray(l2, l1, AdditionalMath.Operation.Multiplication);
            baseArea = AdditionalMath.OperationDoubleArray(baseArea, WidthAtCenter, AdditionalMath.Operation.Plus);
            double divider = eref / Material.GetE();
            return AdditionalMath.OperationDoubleArray(baseArea, divider, AdditionalMath.Operation.Divided);
        }

        private IEnumerable<double> Width(double longueur, double eref, IEnumerable<double> xs)
        {
            double l1 = (4 * WidthOnSide - 4 * WidthAtCenter) / Math.Pow(longueur, 2);

            List<double> L2 = xs.Select(x => Math.Pow(x - longueur / 2, 2)).ToList();

            List<double> Lf = L2.Select(l2 => l1 * l2 + WidthAtCenter).ToList();

            return Lf.Select(lf => lf / eref * Material.GetE()).ToList();
        }

        public List<double> Height(double longueur, IEnumerable<double> xs)
        {
            double e1 = (4 * HeightOnSide - 4 * HeightAtCenter) / Math.Pow(longueur, 2);

            List<double> e2 = xs.Select(x => Math.Pow(x - longueur / 2, 2)).ToList();

            return e2.Select(l2 => e1 * l2 + HeightAtCenter).ToList();
        }

        public List<double> Surface(double length, double eref, double[] xs)
        {
            IEnumerable<double> widths = Width(length, eref, xs);
            List<double> heights = Height(length, xs);
            return widths.Select((t, i) => t * heights[i]).ToList();
        }
    }
}
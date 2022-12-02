using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexion
{
    public class Piece
    {
        Couche[] Couches;
        public readonly double Longueur;

        public Piece(double longueur)
        {
            Longueur = longueur;
        }

        public override string ToString()
        {
            string retourPiece = $"Piece de {Longueur} cm composé de: ";
            foreach (Couche couche in Couches)
            {
                retourPiece += $"{couche}/";
            }
            return retourPiece;
        }
    }
}

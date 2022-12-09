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
        public readonly string Nom;
        public readonly double Longueur;

        public Piece(double longueur, string nom)
        {
            Longueur = longueur;
            Nom = nom;
        }
        public override string ToString()
        {
            string retourPiece = $"{Nom} de {Longueur} cm.";
            return retourPiece;
        }
    }
}

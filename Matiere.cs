using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexion
{
    public class Matiere
    {
        public readonly string Nom;
        public readonly double E;


        public Matiere(string nom, double e)
        {
            Nom = nom;
            E = e;
        }

        public override string ToString()
        {
            return $"{Nom} de constante {E}";
        }
    }
}

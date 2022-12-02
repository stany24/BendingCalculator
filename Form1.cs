using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flexion
{
    public partial class Form1 : Form
    {
        public  List<Couche> ListCouches = new List<Couche>();
        public List<Matiere> ListMatieres = new List<Matiere>();
        public Form1()
        {
            InitializeComponent();
            ListMatieres.Add(new Matiere("aluminium", 2));
            ListMatieres.Add(new Matiere("aluminium", 2));
            ListMatieres.Add(new Matiere("etain", 3));
            ListMatieres.Add(new Matiere("carbon", 4));
        }

        private void btnAjouterCouche_Click(object sender, EventArgs e)
        {
            Couche couche = new Couche(lbxMatiere.SelectedItem as Matiere,(double)nudLargeurCouche.Value,(double)nudHauteurCouche.Value);
            lbxCouche.Items.Add(couche);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Flexion
{
    public partial class CreateurCouche : Form
    {
        readonly List<Couche> ListCouches;
        readonly List<Matiere> ListMatiere;
        readonly Form1 Main;
        public CreateurCouche(List<Couche> couches, List<Matiere> matieres,Form1 main)
        {
            InitializeComponent();
            Main = main;
            ListCouches = couches;
            cbxCouche.DataSource = ListCouches;
            ListMatiere = matieres;
            cbxMatiere.DataSource = ListMatiere;
        }

        private void CreerCouche(object sender, EventArgs e)
        {
            Couche newcouche = new Couche((Matiere)cbxMatiere.SelectedItem,(double)nudLargeurCoucheCenter.Value, (double)nudLargeurCoucheSide.Value, (double)nudHauteurCenter.Value, (double)nudHauterSide.Value);
            if(newcouche != null)
            {
                ListCouches.Add(newcouche);
                cbxCouche.DataSource = null;
                cbxCouche.DataSource = ListCouches;
            }
        }

        private void CreateurCouche_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.ListCouches = ListCouches;
            Main.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flexion.DossierCouche
{
    public partial class EditeurCouche : Form
    {
        List<Couche> ListCouches;
        List<Matiere> ListMatiere;
        Form1 Main;
        public EditeurCouche(List<Couche> couches, List<Matiere> matieres, Form1 main)
        {
            InitializeComponent();
            Main = main;
            ListCouches = couches;
            cbxCouche.DataSource = ListCouches;
            ListMatiere = matieres;
            cbxMatiere.DataSource = ListMatiere;
        }

        private void EditorCouche_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.ListCouches = ListCouches;
            Main.Show();
        }

        private void cbxCouche_SelectedIndexChanged(object sender, EventArgs e)
        {
            Couche selected = cbxCouche.SelectedItem as Couche;
            if (selected == null) { return; }
            nudLargeurCoucheCenter.Value = (decimal)selected.GetLargeurCenter();
            nudLargeurCoucheSide.Value = (decimal)selected.GetLargeurSide();
            nudHauteurSide.Value = (decimal)selected.GetHauteurSide();
            nudHauteurCenter.Value = (decimal)selected.GetHauteurCenter();
            cbxMatiere.SelectedItem = selected.GetMatiere();
        }

        private void btnModifierCouche_Click(object sender, EventArgs e)
        {
            Couche modified = cbxCouche.SelectedItem as Couche;
            modified.SetMatiere(cbxMatiere.SelectedItem as Matiere);
            modified.SetLargeurCenter((double)nudLargeurCoucheCenter.Value);
            modified.SetLargeurSide((double)nudLargeurCoucheSide.Value);
            modified.SetHauteurCenter((double)nudHauteurCenter.Value);
            modified.SetHauteurSide((double)nudHauteurSide.Value);
            cbxCouche.DataSource = null;
            cbxCouche.DataSource = ListCouches;
        }
    }
}

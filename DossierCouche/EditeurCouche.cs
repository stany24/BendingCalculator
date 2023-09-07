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
        readonly List<Couche> ListCouches;
        readonly List<Matiere> ListMatiere;
        public EditeurCouche()
        {
            InitializeComponent();
            ListCouches = Sauvegarde.GetCouches();
            cbxCouche.DataSource = ListCouches;
            ListMatiere = Sauvegarde.GetMatières();
            cbxMatiere.DataSource = ListMatiere;
        }

        private void EditorCouche_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sauvegarde.SetCouches(ListCouches);
        }

        private void AfficherCoucheSelectionne(object sender, EventArgs e)
        {
            if (!(cbxCouche.SelectedItem is Couche selected)) { return; }
            nudLargeurCoucheCenter.Value = (decimal)selected.GetLargeurCenter()*1000;
            nudLargeurCoucheSide.Value = (decimal)selected.GetLargeurSide() * 1000;
            nudHauteurSide.Value = (decimal)selected.GetHauteurSide() * 1000;
            nudHauteurCenter.Value = (decimal)selected.GetHauteurCenter() * 1000;
            cbxMatiere.SelectedItem = selected.MatiereCouche;
        }

        private void ModifierCouche(object sender, EventArgs e)
        {
            Couche modified = cbxCouche.SelectedItem as Couche;
            modified.MatiereCouche = cbxMatiere.SelectedItem as Matiere;
            modified.SetLargeurCenter((double)nudLargeurCoucheCenter.Value/1000);
            modified.SetLargeurSide((double)nudLargeurCoucheSide.Value / 1000);
            modified.SetHauteurCenter((double)nudHauteurCenter.Value / 1000);
            modified.SetHauteurSide((double)nudHauteurSide.Value / 1000);
            cbxCouche.DataSource = null;
            cbxCouche.DataSource = ListCouches;
            lblInfo.Text = "Modification effectuée";
        }

        private void RemoveText(object sender, EventArgs e)
        {
            lblInfo.Text = string.Empty;
        }
    }
}

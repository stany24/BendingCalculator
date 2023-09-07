using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Flexion
{
    public partial class EditeurMatiere : Form
    {
        readonly private List<Matiere> ListMatieres;
        public EditeurMatiere()
        {
            InitializeComponent();
            ListMatieres = Sauvegarde.GetMatières();
            cbxMatieres.DataSource = ListMatieres;
        }

        private void AfficherMatiereSelectionne(object sender, EventArgs e)
        {
            if (!(cbxMatieres.SelectedItem is Matiere selected)) { return; }
            tbxNomMatiere.Text = selected.GetNom();
            nudE.Value = Convert.ToDecimal(selected.GetE() / 1e9);
        }

        private void ModifierMatiere(object sender, EventArgs e)
        {
            if (tbxNomMatiere.Text == string.Empty)
            {
                lblInfo.Text = "pas de nom donné";
                return;
            }
            Matiere selected = cbxMatieres.SelectedItem as Matiere;
            selected.SetNom(tbxNomMatiere.Text);
            selected.SetE((double)nudE.Value * 1e9);
            cbxMatieres.DataSource = null;
            cbxMatieres.DataSource = ListMatieres;
            lblInfo.Text = "Modification effectuée";
        }

        private void EditeurMatiere_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sauvegarde.SetMatières(ListMatieres);
        }

        private void RemoveText(object sender, EventArgs e)
        {
            lblInfo.Text = string.Empty;
        }
    }
}

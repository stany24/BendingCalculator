using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Flexion
{
    public partial class CreateurMatiere : Form
    {
        public List<Matiere> ListMatieres;
        public CreateurMatiere()
        {
            InitializeComponent();
            ListMatieres = Sauvegarde.GetMatières();
            cbxMatieres.DataSource = ListMatieres;
        }

        private void CreateurMatiere_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sauvegarde.SetMatières(ListMatieres);
        }

        private void CreerMatiere(object sender, EventArgs e)
        {
            if (tbxNomMatiere.Text == string.Empty)
            {
                lblInfo.Text = "pas de nom donné";
                return;
            }
            Matiere newmatiere = new Matiere(tbxNomMatiere.Text,(double)nudE.Value*1e9);
            ListMatieres.Add(newmatiere);
            cbxMatieres.DataSource = null;
            cbxMatieres.DataSource = ListMatieres;
            lblInfo.Text = "Création effectuée";
        }
        private void RemoveText(object sender, EventArgs e)
        {
            lblInfo.Text = string.Empty;
        }
    }
}

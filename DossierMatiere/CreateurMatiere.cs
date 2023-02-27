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
    public partial class CreateurMatiere : Form
    {
        public List<Matiere> ListMatieres;
        public Form1 Main;
        public CreateurMatiere(List<Matiere> listmatiere,Form1 main)
        {
            InitializeComponent();
            Main = main;
            ListMatieres = listmatiere;
            cbxMatieres.DataSource = ListMatieres;
        }

        private void CreateurMatiere_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.ListMatieres = ListMatieres;
            Main.Enabled = true;
        }

        private void CreerMatiere(object sender, EventArgs e)
        {
            if (tbxNomMatiere.Text == string.Empty)
            {
                lblInfo.Text = "pas de nom donné";
                return;
            }
            Matiere newmatiere = new Matiere(tbxNomMatiere.Text,(double)nudE.Value*1e9);
            if(newmatiere != null)
            {
                ListMatieres.Add(newmatiere);
                cbxMatieres.DataSource = null;
                cbxMatieres.DataSource = ListMatieres;
            }
            lblInfo.Text = "Création effectuée";
        }
        private void RemoveText(object sender, EventArgs e)
        {
            lblInfo.Text = string.Empty;
        }
    }
}

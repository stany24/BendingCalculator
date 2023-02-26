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
            Matiere newmatiere = new Matiere(tbxNomMatiere.Text,(double)nudE.Value);
            if(newmatiere != null)
            {
                ListMatieres.Add(newmatiere);
                cbxMatieres.DataSource = null;
                cbxMatieres.DataSource = ListMatieres;
            }
        }
    }
}

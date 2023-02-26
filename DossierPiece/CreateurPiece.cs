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
    public partial class CreateurPiece : Form
    {
        public List<Piece> ListPieces;
        public Form1 Main;
        public CreateurPiece(List<Piece> listpiece, Form1 main)
        {
            InitializeComponent();
            Main = main;
            ListPieces = listpiece;
            cbxPieces.DataSource = ListPieces;
        }

        private void CreateurPiece_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.ListPiece = ListPieces;
            Main.Enabled = true;
        }

        private void CreerPiece(object sender, EventArgs e)
        {
            Piece newmatiere = new Piece((double)nudLongueurPiece.Value,tbxNomPiece.Text);
            if (newmatiere != null)
            {
                ListPieces.Add(newmatiere);
                cbxPieces.DataSource = null;
                cbxPieces.DataSource = ListPieces;
            }
        }
    }
}

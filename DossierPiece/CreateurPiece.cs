using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Flexion
{
    public partial class CreateurPiece : Form
    {
        readonly private List<Piece> ListPieces;
        public CreateurPiece()
        {
            InitializeComponent();
            ListPieces = Sauvegarde.GetPieces();
            cbxPieces.DataSource = ListPieces;
        }

        private void CreateurPiece_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sauvegarde.SetPieces(ListPieces);
        }

        private void CreerPiece(object sender, EventArgs e)
        {
            if (tbxNomPiece.Text == string.Empty)
            {
                lblInfo.Text = "pas de nom donné";
                return;
            }
            Piece newmatiere = new Piece((double)nudLongueurPiece.Value/1000,tbxNomPiece.Text);
            ListPieces.Add(newmatiere);
            cbxPieces.DataSource = null;
            cbxPieces.DataSource = ListPieces;
            lblInfo.Text = "Création effectuée";
        }

        private void RemoveText(object sender, EventArgs e)
        {
            lblInfo.Text = string.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Flexion
{
    public partial class EditeurPiece : Form
    {
        public List<Piece> ListPieces;
        public List<Couche> ListCouches;
        public EditeurPiece()
        {
            InitializeComponent();
            ListPieces = Sauvegarde.GetPieces();
            ListCouches = Sauvegarde.GetCouches();
            cbxPieces.DataSource = ListPieces;
            lbxCoucheOut.DataSource = ListCouches;
        }

        private void EditeurPiece_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sauvegarde.SetPieces(ListPieces);
        }

        private void ModifierPiece(object sender, EventArgs e)
        {
            if (tbxNomPiece.Text == string.Empty)
            {
                lblInfo.Text = "pas de nom donné";
                return;
            }
            Piece selected = cbxPieces.SelectedItem as Piece;
            selected.SetNom(tbxNomPiece.Text);
            selected.SetLongueur((double)nudLongueurPiece.Value / 1000);
            selected.Couches = new List<Couche>();
            foreach(Couche couche in lbxCoucheIn.Items)
            {
                selected.Couches.Add(couche);
            }
            lblInfo.Text = "Modifications effectuées";
        }

        private void AfficherPieceSelectionee(object sender, EventArgs e)
        {
            if (!(cbxPieces.SelectedItem is Piece selected)) { return; }
            tbxNomPiece.Text = selected.GetNom();
            nudLongueurPiece.Value = (decimal)selected.GetLongueur()*1000;
            lbxCoucheIn.DataSource = null;
            lbxCoucheIn.DataSource = selected.Couches;
        }

        private void DeplacerADroite(object sender, EventArgs e)
        {
            int id = lbxCoucheIn.SelectedIndex;
            Piece piece = cbxPieces.SelectedItem as Piece;
            piece.Couches.RemoveAt(id);
            lbxCoucheIn.DataSource = null;
            lbxCoucheIn.DataSource = piece.Couches;
            try{lbxCoucheIn.SelectedItem = lbxCoucheIn.Items[id];}
            catch
            {
                if(lbxCoucheIn.Items.Count > 0){ lbxCoucheIn.SelectedItem = lbxCoucheIn.Items[id - 1]; }
            }
            lblInfo.Text = string.Empty;
        }

        private void DeplacerAGauche(object sender, EventArgs e)
        {
            Piece piece = cbxPieces.SelectedItem as Piece;
            piece.Couches.Add(lbxCoucheOut.SelectedItem as Couche);
            lbxCoucheIn.DataSource = null;
            lbxCoucheIn.DataSource = piece.Couches;
            lblInfo.Text = string.Empty;
        }

        private void DeplacerCoucheHaut(object sender, EventArgs e)
        {
            DeplacerItem(-1);
            lblInfo.Text = string.Empty;
        }
        private void DeplacerCoucheBas(object sender, EventArgs e)
        {
            DeplacerItem(1);
            lblInfo.Text = string.Empty;
        }

        public void DeplacerItem(int direction)
        {
            if (lbxCoucheIn.SelectedItem == null || lbxCoucheIn.SelectedIndex < 0)
                return;
            int newIndex = lbxCoucheIn.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= lbxCoucheIn.Items.Count)
                return;
            int id = lbxCoucheIn.SelectedIndex;
            Piece piece = cbxPieces.SelectedItem as Piece;
            Couche selected = lbxCoucheIn.Items[id] as Couche;
            piece.Couches.RemoveAt(id);
            piece.Couches.Insert(newIndex, selected);
            lbxCoucheIn.SetSelected(newIndex, true);
            lbxCoucheIn.DataSource = null;
            lbxCoucheIn.DataSource = piece.Couches;
        }

        private void RemoveText(object sender, EventArgs e)
        {
            lblInfo.Text = string.Empty;
        }
    }
}

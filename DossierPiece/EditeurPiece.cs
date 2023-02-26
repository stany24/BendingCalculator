using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Flexion
{
    public partial class EditeurPiece : Form
    {
        public List<Piece> ListPieces;
        public List<Couche> ListCouches;
        public Form1 Main;
        public EditeurPiece(List<Piece> listpiece,List<Couche> listcouche, Form1 main)
        {
            InitializeComponent();
            Main = main;
            ListPieces = listpiece;
            ListCouches = listcouche;
            cbxPieces.DataSource = ListPieces;
            lbxCoucheOut.DataSource = listcouche;
            Piece selected = cbxPieces.SelectedItem as Piece;
            foreach(Couche couche in selected.Couches) { lbxCoucheIn.Items.Add(couche); }
        }

        private void EditeurPiece_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.ListPiece = ListPieces;
            Main.Enabled = true;
        }

        private void ModifierPiece(object sender, EventArgs e)
        {
            Piece selected = cbxPieces.SelectedItem as Piece;
            selected.SetNom(tbxNomPiece.Text);
            selected.SetLongueur((double)nudLongueurPiece.Value);
            selected.Couches = new List<Couche>();
            foreach(Couche couche in lbxCoucheIn.Items)
            {
                selected.Couches.Add(couche);
            }
        }

        private void AfficherPieceSelectionee(object sender, EventArgs e)
        {
            if (!(cbxPieces.SelectedItem is Piece selected)) { return; }
            tbxNomPiece.Text = selected.GetNom();
            nudLongueurPiece.Value = (decimal)selected.GetLongueur();
        }

        private void DeplacerADroite(object sender, EventArgs e)
        {
            int id = lbxCoucheIn.SelectedIndex;
            lbxCoucheIn.Items.RemoveAt(id);
            try{lbxCoucheIn.SelectedItem = lbxCoucheIn.Items[id];}
            catch
            {
                if(lbxCoucheIn.Items.Count > 0){ lbxCoucheIn.SelectedItem = lbxCoucheIn.Items[id - 1]; }
            }
        }

        private void DeplacerAGauche(object sender, EventArgs e)
        {
            lbxCoucheIn.Items.Add(lbxCoucheOut.SelectedItem);
        }

        private void DeplacerCoucheHaut(object sender, EventArgs e)
        {
            DeplacerItem(-1);
        }
        private void DeplacerCoucheBas(object sender, EventArgs e)
        {
            DeplacerItem(1);
        }

        public void DeplacerItem(int direction)
        {
            if (lbxCoucheIn.SelectedItem == null || lbxCoucheIn.SelectedIndex < 0)
                return;
            int newIndex = lbxCoucheIn.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= lbxCoucheIn.Items.Count)
                return;
            object selected = lbxCoucheIn.SelectedItem;
            lbxCoucheIn.Items.Remove(selected);
            lbxCoucheIn.Items.Insert(newIndex, selected);
            lbxCoucheIn.SetSelected(newIndex, true);
        }
    }
}

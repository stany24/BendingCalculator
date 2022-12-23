using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Integration; //pour les intégrales
using System.IO;
using Newtonsoft.Json;

namespace Flexion
{
    public partial class Form1 : Form
    {
        public  List<Couche> ListCouches = new List<Couche>();
        public List<Matiere> ListMatieres = new List<Matiere>();
        public List<Piece> ListPiece = new List<Piece>();
        public Form1()
        {
            InitializeComponent();
            ListMatieres.Add(new Matiere("fer", 1));
            ListMatieres.Add(new Matiere("aluminium", 2));
            ListMatieres.Add(new Matiere("etain", 3));
            ListMatieres.Add(new Matiere("carbon", 4));
            foreach (Matiere matiere in ListMatieres){lbxMatiere.Items.Add(matiere);}

            ListCouches.Add(new Couche(lbxMatiere.Items[1] as Matiere, 53, 4.3));
            ListCouches.Add(new Couche(lbxMatiere.Items[2] as Matiere, 54, 4.4));
            ListCouches.Add(new Couche(lbxMatiere.Items[3] as Matiere, 55, 4.5));
            ListCouches.Add(new Couche(lbxMatiere.Items[0] as Matiere, 56, 4.6));
            foreach (Couche couche in ListCouches){lbxCouche.Items.Add(couche);}
            Couche test = new Couche(lbxMatiere.Items[1] as Matiere, 53, 4.3);
            lblTest.Text = Convert.ToString(test.EstimateVolumeFromX(1.5, 0.1, 1.5, 0.012, 0.006, 0.75,0.00001));
        }

        public void SaveFile()
        {
            foreach(Matiere matiere in lbxMatiere.Items)
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter file = File.CreateText("C:\\Users\\gouvernonst\\Downloads\\Matière-"+matiere.Nom+".json"))
                {
                    serializer.Serialize(file, matiere);
                }
            }
            foreach (Couche couche in lbxCouche.Items)
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter file = File.CreateText("C:\\Users\\gouvernonst\\Downloads\\Couche-" + couche.Matiere.Nom+" de "+couche.LargeurCenter+"x"+couche.HauteurCenter+" "+couche.LargeurSide +"x"+couche.HauteurSide + ".json"))
                {
                    serializer.Serialize(file, couche);
                }
            }
            foreach (Piece piece in lbxPiece.Items)
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter file = File.CreateText("C:\\Users\\gouvernonst\\Downloads\\Piece-" +piece.Nom+ ".json"))
                {
                    serializer.Serialize(file, piece);
                }
            }
        }

        public void LoadFile()
        {
            string savePath = "C:\\Users\\gouvernonst\\Downloads\\";
            string[] Matières = Directory.GetFiles(savePath, "Matière-*.json");
            JsonSerializer serializer = new JsonSerializer();
            foreach (string matiere in Matières)
            {
                using (StreamReader file = new StreamReader(matiere))
                {
                    file.ReadLine;
                }
            }
            string[] Couches = Directory.GetFiles(savePath, "Couche-*.json");
            string[] Pieces = Directory.GetFiles(savePath, "Piece-*.json");
        }

        private void UpdateListBox()
        {
            lbxMatiere.Items.Clear();
            foreach (Matiere matiere in ListMatieres){lbxMatiere.Items.Add(matiere);}
            lbxCouche.Items.Clear();
            foreach (Couche couche in ListCouches){lbxCouche.Items.Add(couche);}
            lbxPiece.Items.Clear();
            foreach (Piece piece in ListPiece){lbxPiece.Items.Add(piece);}
        }

        private void CreerCouche(object sender, EventArgs e)
        {
            ListCouches.Add(new Couche(lbxMatiere.SelectedItem as Matiere, (double)nudLargeurCoucheCenter.Value,(double)nudLargeurCoucheSide.Value, (double)nudHauteurCenter.Value,(double)nudHauterSide.Value));
            UpdateListBox();
        }

        private void CreerMatiere(object sender, EventArgs e)
        {
            ListMatieres.Add(new Matiere(tbxNomMatiere.Text, (double) nudE.Value));
            UpdateListBox();
        }

        private void CreerPiece(object sender, EventArgs e)
        {
            ListPiece.Add(new Piece((double)nudLongueurPiece.Value, tbxNomPiece.Text));
            UpdateListBox();
        }

        private void AjouterCouche(object sender, EventArgs e)
        {
            ListPiece[lbxPiece.SelectedIndex].Couches.Add(lbxCouche.SelectedItem as Couche);
            UpdateListBox();
        }

        private void ShowCoucheInPiece(object sender, EventArgs e)
        {
            lbxShowCouchePiece.Items.Clear();
            Piece piece = lbxPiece.SelectedItem as Piece;
            foreach (Couche couche in piece.Couches)
            {
                lbxShowCouchePiece.Items.Add(couche);
            }
        }


        private void btnTest_Click(object sender, EventArgs e)
        {
            LoadFile();
        }
    }
}
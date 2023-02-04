using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MathNet.Numerics.Integration; //pour les intégrales
using System.IO;
using Newtonsoft.Json;

namespace Flexion
{
    public partial class Form1 : Form
    {
        
        public List<Couche> ListCouches = new List<Couche>();
        public List<Matiere> ListMatieres = new List<Matiere>();
        public List<Piece> ListPiece = new List<Piece>();

        /// <summary>
        /// Initialise la page avec des matières et des couches par défault
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            /*Couche couchetest = new Couche(new Matiere("chène", 12e9), 120, 50, 25, 10);
            foreach (double x in couchetest.CalcutateX(1500))
            {
                lbxPiece.Items.Add(x);
            }
            foreach (double largeur in couchetest.Largeur(1500,69e9))
            {
                lbxShowCouchePiece.Items.Add(largeur);
            }*/
        }

        /// <summary>
        /// Sauvegarde les matières, les couches et les pièces en fichier json
        /// </summary>
        public void SaveFile()
        {
            JsonSerializer serializer = new JsonSerializer();
            foreach (Matiere matiere in lbxMatiere.Items)
            {
                using (TextWriter file = File.CreateText("C:\\Users\\gouvernonst\\Downloads\\Matière-"+matiere.GetNom()+".json"))
                {
                    serializer.Serialize(file, matiere);
                }
            }

            foreach (Couche couche in lbxCouche.Items)
            {
                using (TextWriter file = File.CreateText("C:\\Users\\gouvernonst\\Downloads\\Couche-" + couche.GetMatiere().GetNom() + " de "+ couche.GetLargeurCenter()+"x"+couche.GetHauteurCenter() + " "+couche.GetLargeurCenter() + "x"+couche.GetHauteurSide() + ".json"))
                {
                    serializer.Serialize(file, couche);
                }
            }

            foreach (Piece piece in lbxPiece.Items)
            {
                using (TextWriter file = File.CreateText("C:\\Users\\gouvernonst\\Downloads\\Piece-" +piece.GetNom() + ".json"))
                {
                    serializer.Serialize(file, piece);
                }
            }
        }

        /// <summary>
        /// Charge les données sauvegardées par SaveFile()
        /// </summary>
        public void LoadFile()
        {
            string savePath = "C:\\Users\\gouvernonst\\Downloads\\";
            string[] Matières = Directory.GetFiles(savePath, "Matière-*.json");
            JsonSerializer serializer = new JsonSerializer();
            foreach (string matiere in Matières)
            {
                using (StreamReader file = new StreamReader(matiere))
                {
                    lblTest.Text=file.ReadLine();
                }
            }
            string[] Couches = Directory.GetFiles(savePath, "Couche-*.json");
            string[] Pieces = Directory.GetFiles(savePath, "Piece-*.json");
        }

        /// <summary>
        /// Met à jour les listbox des matières, des couches et des pièces
        /// </summary>
        private void UpdateListBox()
        {
            lbxMatiere.Items.Clear();
            foreach (Matiere matiere in ListMatieres){lbxMatiere.Items.Add(matiere);}
            lbxCouche.Items.Clear();
            foreach (Couche couche in ListCouches){lbxCouche.Items.Add(couche);}
            lbxPiece.Items.Clear();
            foreach (Piece piece in ListPiece){lbxPiece.Items.Add(piece);}
        }

        /// <summary>
        /// Crée un nouvelle couche avec les paramétres donnés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreerCouche(object sender, EventArgs e)
        {
            ListCouches.Add(new Couche(lbxMatiere.SelectedItem as Matiere, (double)nudLargeurCoucheCenter.Value,(double)nudLargeurCoucheSide.Value, (double)nudHauteurCenter.Value,(double)nudHauterSide.Value));
            UpdateListBox();
        }

        /// <summary>
        /// Crée une nouvelle couche avec les paramétres donnés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreerMatiere(object sender, EventArgs e)
        {
            ListMatieres.Add(new Matiere(tbxNomMatiere.Text, (double) nudE.Value));
            UpdateListBox();
        }

        /// <summary>
        /// Crée une nouvelle pièce avec les paramétres donnés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreerPiece(object sender, EventArgs e)
        {
            ListPiece.Add(new Piece((double)nudLongueurPiece.Value, tbxNomPiece.Text));
            UpdateListBox();
        }

        /// <summary>
        /// Ajoute la couche séléctionnée à la pièce séléctionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterCouche(object sender, EventArgs e)
        {
            ListPiece[lbxPiece.SelectedIndex].Couches.Add(lbxCouche.SelectedItem as Couche);
            UpdateListBox();
        }

        /// <summary>
        /// Affiche toutes les couches dans la pièce séléctionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            Piece piece = new Piece(1500e-3, "test");
            piece.Couches.Add(new Couche(new Matiere("alu", 69e9), 100e-3, 150e-3, 10e-3, 5e-3));
            piece.Couches.Add(new Couche(new Matiere("alu", 69e9), 100e-3, 150e-3, 5e-3, 5e-3));
            piece.Couches.Add(new Couche(new Matiere("alu", 69e9), 100e-3, 150e-3, 5e-3, 5e-3));
            string array = " NEW ";
            foreach (double temp in piece.Ns())
            {
                array += temp +" / ";
                
            }
            tbxOutput.Text += array;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MathNet.Numerics.Integration; //pour les intégrales
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
            Piece piece = new Piece(1500e-3, "Démo");
            ListPiece.Add(piece);
            piece.Couches.Add(new Couche(new Matiere("alu", 69e9), 100e-3, 100e-3, 5e-3, 5e-3));
            piece.Couches.Add(new Couche(new Matiere("alu", 69e9), 100e-3, 100e-3, 5e-3, 5e-3));
            piece.Couches.Add(new Couche(new Matiere("alu", 69e9), 100e-3, 100e-3, 5e-3, 5e-3));
            ListCouches.Add(piece.Couches[0]);
            ListCouches.Add(piece.Couches[1]);
            ListMatieres.Add(piece.Couches[0].GetMatiere());
            UpdateListBox();
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
                    lblError.Text=file.ReadLine();
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
            if (nudLargeurCoucheCenter.Value == 0)
            {
                lblError.Text = "Pas de valeur donnée à la largeur au centre";
                return;
            }

            if (nudLargeurCoucheSide.Value == 0)
            {
                lblError.Text = "Pas de valeur donnée à la largeur sur les côté";
                return;
            }

            if (nudHauteurCenter.Value == 0)
            {
                lblError.Text = "Pas de valeur donnée à la hauteur au centre";
                return;
            }

            if (nudHauterSide.Value == 0)
            {
                lblError.Text = "Pas de valeur donnée à la hauteur sur les côté";
                return;
            }

            if (lbxMatiere.SelectedItem == null)
            {
                lblError.Text = "Pas de matière sélétionnée";
                return;
            }

            if (!(lbxMatiere.SelectedItem is Matiere))
            {
                lblError.Text = "L'objet sélécionné n'est pas une matière";
                return;
            }
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
            if(tbxNomMatiere.Text == string.Empty)
            {
                lblError.Text = "Pas de nom donné à la matière";
                return;
            }

            if(nudE.Value == 0)
            {
                lblError.Text = "Pas de valeur donnée à E";
                return;
            }

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
            if (tbxNomPiece.Text == string.Empty)
            {
                lblError.Text = "Pas de nom donné à la pièce";
                return;
            }

            if (nudLongueurPiece.Value == 0)
            {
                lblError.Text = "Pas de valeur donnée à la longueur";
                return;
            }
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
            if (lbxCouche.SelectedItem == null)
            {
                lblError.Text = "Pas de couche sélétionnée";
                return;
            }

            if (lbxPiece.SelectedItem == null)
            {
                lblError.Text = "Pas de piece sélétionnée";
                return;
            }

            if (!(lbxCouche.SelectedItem is Couche))
            {
                lblError.Text = "L'objet sélécionné n'est pas une couche";
                return;
            }

            if (!(lbxPiece.SelectedItem is Piece))
            {
                lblError.Text = "L'objet sélécionné n'est pas une pièce";
                return;
            }

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
            if(!(lbxPiece.SelectedItem is Piece))
            {
                lblError.Text = "L'objet sélécionné n'est pas une pièce";
                return;
            }

            lbxShowCouchePiece.Items.Clear();
            Piece piece = lbxPiece.SelectedItem as Piece;
            foreach (Couche couche in piece.Couches)
            {
                lbxShowCouchePiece.Items.Add(couche);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if(lbxPiece.SelectedItem == null)
            {
                lblError.Text = "Pas de pièce sélétionnée";
                return;
            }

            if (!(lbxPiece.SelectedItem is Piece))
            {
                lblError.Text = "L'objet sélécionné n'est pas une pièce";
                return;
            }

            Piece piece = lbxPiece.SelectedItem as Piece;
            lbxNs.Items.Clear();
            lbxI.Items.Clear();
            lbxMoment.Items.Clear();
            lbxIntegrale.Items.Clear();

            double[] moment1 = piece.MomentForce();
            double[] moment2 = piece.MomentForce();
            double[] iiii = piece.CalculateI();
            double[] moment3 = piece.MomentForce();


            double[] intégrale = piece.Intégrale();
            double[] moment = piece.MomentForce();
            foreach (double n in piece.Ns())
            {
                lbxNs.Items.Add(n);
            }

            foreach (double i in piece.CalculateI())
            {
                lbxI.Items.Add(i);
            }

            foreach(double i in moment)
            {
                lbxMoment.Items.Add(i);
            }
            foreach (double i in intégrale)
            {
                lbxIntegrale.Items.Add(i);
            }

            //Graphe de l'intégrale
            chrIntegrale.Series.Clear();
            Series serieI =  chrIntegrale.Series.Add("intégrale");
            serieI.ChartType = SeriesChartType.Spline;
            for (int i = 1;i < intégrale.Length+1;i++)
            {
                serieI.Points.AddXY(i, intégrale[i-1]);
            }
            //Graphe du moment de force
            chrMomentForce.Series.Clear();
            Series serieM = chrMomentForce.Series.Add("moment de force");
            serieM.ChartType = SeriesChartType.Spline;
            for (int i = 1; i < moment.Length+1; i++)
            {
                serieM.Points.AddXY(i, moment[i-1]);
            }

            lblTest.Text = Convert.ToString(piece.MomentForce().Count());
        }
    }
}
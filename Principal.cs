using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using MathNet.Numerics;
using System.Threading.Tasks;

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
            lblErreurCouche.Text = string.Empty;
            lblErreurPiece.Text = string.Empty;
            lblErreurProcess.Text = string.Empty;
            Piece piece = new Piece(1500e-3, "Démo");
            ListPiece.Add(piece);
            piece.Couches.Add(new Couche(new Matiere("alu", 69e9), 100e-3, 100e-3, 5e-3, 5e-3));
            piece.Couches.Add(new Couche(new Matiere("alu", 69e9), 100e-3, 100e-3, 5e-3, 5e-3));
            piece.Couches.Add(new Couche(new Matiere("alu", 69e9), 100e-3, 100e-3, 5e-3, 5e-3));
            ListCouches.Add(piece.Couches[0]);
            ListCouches.Add(piece.Couches[1]);
            ListMatieres.Add(piece.Couches[0].GetMatiere());
            UpdateListBox();
            cbxMatiere.DataSource= ListMatieres;
            cbxCouche.DataSource= ListCouches;
        }

        /// <summary>
        /// Sauvegarde les matières, les couches et les pièces en fichier json
        /// </summary>
        public void SaveFile()
        {
            JsonSerializer serializer = new JsonSerializer();
            foreach (Matiere matiere in ListMatieres)
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
                    lblErreurPiece.Text=file.ReadLine();
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
            cbxMatiere.DataSource = null;
            cbxMatiere.DataSource = ListMatieres;
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
            lblErreurCouche.Text = String.Empty;
            if (nudLargeurCoucheCenter.Value == 0)
            {
                lblErreurCouche.Text = "Pas de valeur donnée à la largeur au centre";
                return;
            }

            if (nudLargeurCoucheSide.Value == 0)
            {
                lblErreurCouche.Text = "Pas de valeur donnée à la largeur sur les côté";
                return;
            }

            if (nudHauteurCenter.Value == 0)
            {
                lblErreurCouche.Text = "Pas de valeur donnée à la hauteur au centre";
                return;
            }

            if (nudHauterSide.Value == 0)
            {
                lblErreurCouche.Text = "Pas de valeur donnée à la hauteur sur les côté";
                return;
            }

            if (cbxMatiere.SelectedItem== null)
            {
                lblErreurCouche.Text = "Pas de matière sélétionnée";
                return;
            }

            if (!(cbxMatiere.SelectedItem is Matiere))
            {
                lblErreurCouche.Text = "L'objet sélécionné n'est pas une matière";
                return;
            }
            //ListCouches.Add(new Couche(lbxMatiere.SelectedItem as Matiere, (double)nudLargeurCoucheCenter.Value/1000,(double)nudLargeurCoucheSide.Value / 1000, (double)nudHauteurCenter.Value / 1000, (double)nudHauterSide.Value / 1000));
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
                lblErreurPiece.Text = "Pas de nom donné à la pièce";
                return;
            }

            if (nudLongueurPiece.Value == 0)
            {
                lblErreurPiece.Text = "Pas de valeur donnée à la longueur";
                return;
            }
            ListPiece.Add(new Piece((double)nudLongueurPiece.Value/1000, tbxNomPiece.Text));
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
                lblErreurPiece.Text = "Pas de couche sélétionnée";
                return;
            }

            if (lbxPiece.SelectedItem == null)
            {
                lblErreurPiece.Text = "Pas de piece sélétionnée";
                return;
            }

            if (!(lbxCouche.SelectedItem is Couche))
            {
                lblErreurPiece.Text = "L'objet sélécionné n'est pas une couche";
                return;
            }

            if (!(lbxPiece.SelectedItem is Piece))
            {
                lblErreurPiece.Text = "L'objet sélécionné n'est pas une pièce";
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
                lblErreurPiece.Text = "L'objet sélécionné n'est pas une pièce";
                return;
            }

            lbxShowCouchePiece.Items.Clear();
            Piece piece = lbxPiece.SelectedItem as Piece;
            foreach (Couche couche in piece.Couches)
            {
                lbxShowCouchePiece.Items.Add(couche);
            }
        }

        private void DisplayGraphForPiece(object sender, EventArgs e)
        {
            lblErreurProcess.Text = string.Empty;
            if(lbxPiece.SelectedItem == null)
            {
                lblErreurProcess.Text = "Pas de pièce sélétionnée";
                return;
            }

            if (!(lbxPiece.SelectedItem is Piece))
            {
                lblErreurProcess.Text = "L'objet sélécionné n'est pas une pièce";
                return;
            }
            
            Piece piece = lbxPiece.SelectedItem as Piece;
            piece.SetF((double)nudForce.Value);
            FillGraph(chrIntegrale, "intégrale", piece.Intégrale(), Convert.ToInt32(1/piece.GetEcart())/100);
            FillGraph(chrMomentForce, "moment de force", piece.MomentForce(), Convert.ToInt32(1 / piece.GetEcart())/100);
        }

        public void FillGraph(Chart graph,string seriename, double[] data, int diviseur)
        {
            graph.Invoke(new MethodInvoker(delegate { graph.Series.Clear(); }));
            System.Windows.Forms.DataVisualization.Charting.Series serie = new System.Windows.Forms.DataVisualization.Charting.Series(seriename)
            {
                ChartType = SeriesChartType.Spline
            };
            for (int i = diviseur; i < data.Length; i+=diviseur)
            {
                serie.Points.AddXY(i, data[i]);
            }
            graph.Invoke(new MethodInvoker(delegate { graph.Series.Add(serie); }));
        }

        public void CalcuateF(object sender, EventArgs e)
        {
            double m = (double)nudMasse.Value;
            double r = (double)nudRayon.Value;
            double v = (double)nudVitesse.Value;
            double g = (double)nudGravite.Value;
            nudForce.Value = Convert.ToInt32(m * Math.Sqrt(Math.Pow(g, 2) + (Math.Pow(v, 4) / Math.Pow(r, 2))));
        }

        private void btnModiferMatiere_Click(object sender, EventArgs e)
        {
            EditeurMatiere editor = new EditeurMatiere(ListMatieres,(Form1)ActiveForm);
            editor.Show();
            this.Hide();
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible == true)
            {
                cbxMatiere.DataSource = null;
                cbxMatiere.DataSource = ListMatieres;
            }
        }

        private void btnCreerMatiere_Click(object sender, EventArgs e)
        {
            CreateurMatiere createur = new CreateurMatiere(ListMatieres, (Form1)ActiveForm);
            createur.Show();
            this.Hide();
        }
    }
}
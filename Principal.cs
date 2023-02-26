using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms.DataVisualization.Charting;
using Flexion.DossierCouche;

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
            ListMatieres.Add(piece.Couches[0].GetMatiere());
            cbxMatiere.DataSource= ListMatieres;
            cbxCouche.DataSource= ListCouches;
            cbxPiece.DataSource= ListPiece;
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

            foreach (Couche couche in ListCouches)
            {
                using (TextWriter file = File.CreateText("C:\\Users\\gouvernonst\\Downloads\\Couche-" + couche.GetMatiere().GetNom() + " de "+ couche.GetLargeurCenter()+"x"+couche.GetHauteurCenter() + " "+couche.GetLargeurCenter() + "x"+couche.GetHauteurSide() + ".json"))
                {
                    serializer.Serialize(file, couche);
                }
            }

            foreach (Piece piece in ListPiece)
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
                    lblErreur.Text=file.ReadLine();
                }
            }
            string[] Couches = Directory.GetFiles(savePath, "Couche-*.json");
            string[] Pieces = Directory.GetFiles(savePath, "Piece-*.json");
        }


        private void DisplayGraphForPiece(object sender, EventArgs e)
        {
            lblErreur.Text = string.Empty;
            if(cbxPiece.SelectedItem == null)
            {
                lblErreur.Text = "Pas de pièce sélétionnée";
                return;
            }

            if (!(cbxPiece.SelectedItem is Piece))
            {
                lblErreur.Text = "L'objet sélécionné n'est pas une pièce";
                return;
            }
            
            Piece piece = cbxPiece.SelectedItem as Piece;
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

        private void ModiferMatiere(object sender, EventArgs e)
        {
            EditeurMatiere editor = new EditeurMatiere(ListMatieres,this);
            editor.Show();
            this.Enabled = false;
        }

        private void CreerMatiere(object sender, EventArgs e)
        {
            CreateurMatiere createur = new CreateurMatiere(ListMatieres, this);
            createur.Show();
            this.Enabled = false;
        }

        private void CreerCouche(object sender, EventArgs e)
        {
            CreateurCouche createur = new CreateurCouche(ListCouches,ListMatieres,this);
            createur.Show();
            this.Enabled = false;
        }

        private void ModifierCouche(object sender, EventArgs e)
        {
            EditeurCouche editor = new EditeurCouche(ListCouches, ListMatieres, this);
            editor.Show();
            this.Enabled = false;
        }

        private void Form1_EnabledChanged(object sender, EventArgs e)
        {
            if (Visible == true)
            {
                cbxMatiere.DataSource = null;
                cbxMatiere.DataSource = ListMatieres;
                cbxCouche.DataSource = null;
                cbxCouche.DataSource = ListCouches;
                cbxPiece.DataSource = null;
                cbxPiece.DataSource = ListPiece;
            }
        }

        private void CreerPiece(object sender, EventArgs e)
        {
            CreateurPiece creator = new CreateurPiece(ListPiece, this);
            creator.Show();
            this.Enabled = false;
        }

        private void ModifierPiece(object sender, EventArgs e)
        {
            EditeurPiece editor = new EditeurPiece(ListPiece,ListCouches,this);
            editor.Show();
            this.Enabled = false;
        }
    }
}
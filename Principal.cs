using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms.DataVisualization.Charting;
using Flexion.DossierCouche;
using System.Linq;
using System.Threading.Tasks;

namespace Flexion
{
    public partial class Form1 : Form
    {
        Task calculator;
        public List<Couche> ListCouches = new List<Couche>();
        public List<Matiere> ListMatieres = new List<Matiere>();
        public List<Piece> ListPiece = new List<Piece>();
        public double Force = 500;
        public double Ecart = 1e-4;

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
            if (cbxPiece.SelectedItem == null)
            {
                lblErreur.Text = "Pas de pièce sélétionnée";
                return;
            }

            if (!(cbxPiece.SelectedItem is Piece))
            {
                lblErreur.Text = "L'objet sélécionné n'est pas une pièce";
                return;
            }
            if(calculator == null)
            {
                calculator = new Task(CalculateFlexion);
                calculator.Start();
            }
            else
            {
                if (calculator.IsCompleted)
                {
                    calculator = new Task(CalculateFlexion);
                    calculator.Start();
                }
                else
                {
                    lblErreur.Text = "Une calcul est déjà en cours";
                    return;
                }
            }
        }

        public void CalculateFlexion()
        {
            Piece piece = null;
            cbxPiece.Invoke(new MethodInvoker(delegate {  piece = cbxPiece.SelectedItem as Piece; }));
            FillGraph(chrIntegrale, "intégrale", piece.Intégrale(Force, Ecart), Convert.ToInt32(piece.GetLongueur() / Ecart) / 100, piece.GetLongueur());
            FillGraph(chrMomentForce, "moment de force", piece.MomentForce(Force), Convert.ToInt32(piece.GetLongueur() / Ecart) / 100, piece.GetLongueur());
        }

        public void FillGraph(Chart graph,string seriename, double[] data, int diviseur,double longueur)
        {
            graph.Invoke(new MethodInvoker(delegate { graph.Series[0].Points.Clear(); }));
            graph.Invoke(new MethodInvoker(delegate { graph.Series.Clear(); }));
            Series serie = new Series(seriename+ $" Min {data.Min() * 1000:F2} mm")
            {
                ChartType = SeriesChartType.Spline,
            };

            for (int i = 0; i <= 100; i+=1)
            {
                serie.Points.AddXY(i*longueur*10, data[i* diviseur] *1000);
            }
            graph.Invoke(new MethodInvoker(delegate { graph.Series.Add(serie); }));
            graph.Invoke(new MethodInvoker(delegate { graph.ChartAreas[0].AxisX.Minimum = 0;}));
            graph.Invoke(new MethodInvoker(delegate { graph.ChartAreas[0].AxisX.Title = "Deformation (mm)";}));
            graph.Invoke(new MethodInvoker(delegate { graph.ChartAreas[0].AxisY.Title = "Longueur (mm)";}));

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
            if (Enabled == true)
            {
                cbxMatiere.DataSource = null;
                cbxMatiere.DataSource = ListMatieres;
                cbxCouche.DataSource = null;
                cbxCouche.DataSource = ListCouches;
                cbxPiece.DataSource = null;
                cbxPiece.DataSource = ListPiece;
                nudForce.Value = (decimal)Force;
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

        private void CalculerForce(object sender, EventArgs e)
        {
            CalculeForce calculeForce = new CalculeForce(this);
            calculeForce.Show();
            this.Enabled = false;
        }

        private void EcartChanged(object sender, EventArgs e)
        {
            Ecart = (double)nudEcart.Value/10000;
        }

        private void ForceChanged(object sender, EventArgs e)
        {
            Force = (double)nudForce.Value;
        }
    }
}
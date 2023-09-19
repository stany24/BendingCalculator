using Flexion.DossierCouche;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Flexion
{
    public partial class Form1 : Form
    {
        Task calculator;
        private List<Couche> ListCouches;
        private List<Matiere> ListMatieres;
        private List<Piece> ListPiece;
        private double Ecart = 1e-4;

        /// <summary>
        /// Initialise la page avec des matières et des couches par défault
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            ListPiece = Sauvegarde.GetPieces();
            ListCouches = Sauvegarde.GetCouches();
            ListMatieres = Sauvegarde.GetMatières();
            cbxMatiere.DataSource = ListMatieres;
            cbxCouche.DataSource = ListCouches;
            cbxPiece.DataSource = ListPiece;
            nudForce.Value = Sauvegarde.GetForce();
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
            if (calculator == null)
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
                }
            }
        }

        public void CalculateFlexion()
        {
            Piece piece = null;
            cbxPiece.Invoke(new MethodInvoker(delegate { piece = cbxPiece.SelectedItem as Piece; }));
            FillGraph(chrIntegrale, piece.Intégrale(Sauvegarde.GetForce(), Ecart), Convert.ToInt32(piece.GetLongueur() / Ecart) / 100, piece.GetLongueur());
        }

        public void FillGraph(Chart graph, double[] data, int diviseur, double longueur)
        {
            graph.Invoke(new MethodInvoker(delegate { graph.Series[0].Points.Clear(); }));
            graph.Invoke(new MethodInvoker(delegate { graph.Series.Clear(); }));
            Series serie = new Series($" Min {data.Min() * 1000:F2} mm")
            {
                ChartType = SeriesChartType.Spline,
            };

            for (int i = 0; i <= 100; i += 1)
            {
                serie.Points.AddXY(i * longueur * 10, data[i * diviseur] * 1000);
            }
            graph.Invoke(new MethodInvoker(delegate { graph.Series.Add(serie); }));
            graph.Invoke(new MethodInvoker(delegate { graph.ChartAreas[0].AxisX.Minimum = 0; }));
            graph.Invoke(new MethodInvoker(delegate { graph.ChartAreas[0].AxisX.Title = "Longueur (mm)"; }));
            graph.Invoke(new MethodInvoker(delegate { graph.ChartAreas[0].AxisY.Title = "Deformation (mm)"; }));

        }

        private void ModiferMatiere(object sender, EventArgs e)
        {
            EditeurMatiere editor = new EditeurMatiere();
            editor.FormClosed += new FormClosedEventHandler(UpdateMatieres);
            editor.Show();
            this.Enabled = false;
        }


        private void CreerMatiere(object sender, EventArgs e)
        {
            CreateurMatiere createur = new CreateurMatiere();
            createur.FormClosed += new FormClosedEventHandler(UpdateMatieres);
            createur.Show();
            this.Enabled = false;
        }
        private void UpdateMatieres(object sender, EventArgs e)
        {
            ListMatieres = Sauvegarde.GetMatières();
            this.Enabled = true;
        }

        private void CreerCouche(object sender, EventArgs e)
        {
            CreateurCouche createur = new CreateurCouche();
            createur.FormClosed += new FormClosedEventHandler(UpdateCouches);
            createur.Show();
            this.Enabled = false;
        }

        private void ModifierCouche(object sender, EventArgs e)
        {
            EditeurCouche editor = new EditeurCouche();
            editor.FormClosed += new FormClosedEventHandler(UpdateCouches);
            editor.Show();
            this.Enabled = false;
        }

        private void UpdateCouches(Object sender, EventArgs e)
        {
            ListCouches = Sauvegarde.GetCouches();
            this.Enabled = true;
        }

        private void Form1_EnabledChanged(object sender, EventArgs e)
        {
            if (Enabled)
            {
                cbxMatiere.DataSource = null;
                cbxMatiere.DataSource = ListMatieres;
                cbxCouche.DataSource = null;
                cbxCouche.DataSource = ListCouches;
                cbxPiece.DataSource = null;
                cbxPiece.DataSource = ListPiece;
                nudForce.Value = Sauvegarde.GetForce();
            }
        }

        private void CreerPiece(object sender, EventArgs e)
        {
            CreateurPiece creator = new CreateurPiece();
            creator.FormClosed += new FormClosedEventHandler(UpdatePieces);
            creator.Show();
            this.Enabled = false;
        }

        private void ModifierPiece(object sender, EventArgs e)
        {
            EditeurPiece editor = new EditeurPiece();
            editor.FormClosed += new FormClosedEventHandler(UpdatePieces);
            editor.Show();
            this.Enabled = false;
        }

        private void UpdatePieces(Object sender, EventArgs e)
        {
            ListPiece = Sauvegarde.GetPieces();
            this.Enabled = true;
        }

        private void CalculerForce(object sender, EventArgs e)
        {
            CalculeForce calculeForce = new CalculeForce();
            calculeForce.FormClosed += new FormClosedEventHandler(UpdateForce);
            calculeForce.Show();
            this.Enabled = false;
        }

        private void UpdateForce(object sender, EventArgs e)
        {
            this.Enabled = true;
            nudForce.Value = Sauvegarde.GetForce();
        }

        private void EcartChanged(object sender, EventArgs e)
        {
            Ecart = (double)nudEcart.Value / 10000;
        }

        private void ForceChanged(object sender, EventArgs e)
        {
            Sauvegarde.SetForce((int)nudForce.Value);
        }

        private void LoadFromJson(object sender, EventArgs e)
        {
            FileDialogJson.Filter = "Fichiers json (*.json)|*.json";
            FileDialogJson.Title = "Ficher json à charcher";
            FileDialogJson.Multiselect = false;
            FileDialogJson.ShowDialog();
            try{
                List<Piece> pieces  = JsonSerializer.Deserialize<List<Piece>>(FileDialogJson.OpenFile());
                pieces.AddRange(Sauvegarde.GetPieces());
                Sauvegarde.SetPieces(pieces);
                return;
            }catch{}
            try{
                List<Couche> couches = JsonSerializer.Deserialize<List<Couche>>(FileDialogJson.OpenFile());
                couches.AddRange(Sauvegarde.GetCouches());
                Sauvegarde.SetCouches(couches);
            }catch { }
            try{
                List<Matiere> matieres = JsonSerializer.Deserialize<List<Matiere>>(FileDialogJson.OpenFile());
                matieres.AddRange(Sauvegarde.GetMatières());
                Sauvegarde.SetMatières(matieres);
            }catch { }
            try{
                Piece piece = JsonSerializer.Deserialize<Piece>(FileDialogJson.OpenFile());
                List<Piece> pieces = Sauvegarde.GetPieces();
                pieces.Add(piece);
                Sauvegarde.SetPieces(pieces);
            }catch { }
            try{
                Couche couche = JsonSerializer.Deserialize<Couche>(FileDialogJson.OpenFile());
                List<Couche> couches = Sauvegarde.GetCouches();
                couches.Add(couche);
                Sauvegarde.SetCouches(couches);
            }
            catch { }
            try{
                Piece piece = JsonSerializer.Deserialize<Piece>(FileDialogJson.OpenFile());
                List<Piece> pieces = Sauvegarde.GetPieces();
                pieces.Add(piece);
                Sauvegarde.SetPieces(pieces);
            }
            catch { }
        }
    }
}
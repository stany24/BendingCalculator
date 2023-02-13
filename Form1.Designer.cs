
namespace Flexion
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblForce = new System.Windows.Forms.Label();
            this.lblDeformation = new System.Windows.Forms.Label();
            this.nudForce = new System.Windows.Forms.NumericUpDown();
            this.nudDeformation = new System.Windows.Forms.NumericUpDown();
            this.nudLongueurPiece = new System.Windows.Forms.NumericUpDown();
            this.lblLongueur = new System.Windows.Forms.Label();
            this.nudHauteurCenter = new System.Windows.Forms.NumericUpDown();
            this.lblHauteurCenter = new System.Windows.Forms.Label();
            this.nudLargeurCoucheCenter = new System.Windows.Forms.NumericUpDown();
            this.lblLargeurCenter = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLargeurSide = new System.Windows.Forms.Label();
            this.nudLargeurCoucheSide = new System.Windows.Forms.NumericUpDown();
            this.lblHauteurSide = new System.Windows.Forms.Label();
            this.nudHauterSide = new System.Windows.Forms.NumericUpDown();
            this.lbxCouche = new System.Windows.Forms.ListBox();
            this.btnCreerCouche = new System.Windows.Forms.Button();
            this.gbxMatiere = new System.Windows.Forms.GroupBox();
            this.tbxNomMatiere = new System.Windows.Forms.TextBox();
            this.lblNomMatiere = new System.Windows.Forms.Label();
            this.nudE = new System.Windows.Forms.NumericUpDown();
            this.lbxMatiere = new System.Windows.Forms.ListBox();
            this.lblE = new System.Windows.Forms.Label();
            this.btnCreerMatiere = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxNomPiece = new System.Windows.Forms.TextBox();
            this.lblNomPiece = new System.Windows.Forms.Label();
            this.btnCreerPiece = new System.Windows.Forms.Button();
            this.lbxPiece = new System.Windows.Forms.ListBox();
            this.btnAjouterCouche = new System.Windows.Forms.Button();
            this.lbxShowCouchePiece = new System.Windows.Forms.ListBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.lbxNs = new System.Windows.Forms.ListBox();
            this.lbxI = new System.Windows.Forms.ListBox();
            this.lblNs = new System.Windows.Forms.Label();
            this.lblI = new System.Windows.Forms.Label();
            this.lblTest = new System.Windows.Forms.Label();
            this.lbxMoment = new System.Windows.Forms.ListBox();
            this.lblMoment = new System.Windows.Forms.Label();
            this.lbxIntegrale = new System.Windows.Forms.ListBox();
            this.lblIntegrale = new System.Windows.Forms.Label();
            this.chrIntegrale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chrMomentForce = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbxOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongueurPiece)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauteurCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCoucheCenter)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCoucheSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauterSide)).BeginInit();
            this.gbxMatiere.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudE)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrIntegrale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrMomentForce)).BeginInit();
            this.SuspendLayout();
            // 
            // lblForce
            // 
            this.lblForce.AutoSize = true;
            this.lblForce.Enabled = false;
            this.lblForce.Location = new System.Drawing.Point(12, 42);
            this.lblForce.Name = "lblForce";
            this.lblForce.Size = new System.Drawing.Size(51, 13);
            this.lblForce.TabIndex = 0;
            this.lblForce.Text = "Force (N)";
            // 
            // lblDeformation
            // 
            this.lblDeformation.AutoSize = true;
            this.lblDeformation.Enabled = false;
            this.lblDeformation.Location = new System.Drawing.Point(12, 75);
            this.lblDeformation.Name = "lblDeformation";
            this.lblDeformation.Size = new System.Drawing.Size(87, 13);
            this.lblDeformation.TabIndex = 2;
            this.lblDeformation.Text = "Déformation (cm)";
            // 
            // nudForce
            // 
            this.nudForce.DecimalPlaces = 1;
            this.nudForce.Enabled = false;
            this.nudForce.Location = new System.Drawing.Point(125, 40);
            this.nudForce.Name = "nudForce";
            this.nudForce.Size = new System.Drawing.Size(120, 20);
            this.nudForce.TabIndex = 5;
            // 
            // nudDeformation
            // 
            this.nudDeformation.DecimalPlaces = 1;
            this.nudDeformation.Enabled = false;
            this.nudDeformation.Location = new System.Drawing.Point(125, 73);
            this.nudDeformation.Name = "nudDeformation";
            this.nudDeformation.Size = new System.Drawing.Size(120, 20);
            this.nudDeformation.TabIndex = 6;
            // 
            // nudLongueurPiece
            // 
            this.nudLongueurPiece.DecimalPlaces = 1;
            this.nudLongueurPiece.Location = new System.Drawing.Point(101, 30);
            this.nudLongueurPiece.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudLongueurPiece.Name = "nudLongueurPiece";
            this.nudLongueurPiece.Size = new System.Drawing.Size(120, 20);
            this.nudLongueurPiece.TabIndex = 8;
            // 
            // lblLongueur
            // 
            this.lblLongueur.AutoSize = true;
            this.lblLongueur.Location = new System.Drawing.Point(6, 32);
            this.lblLongueur.Name = "lblLongueur";
            this.lblLongueur.Size = new System.Drawing.Size(75, 13);
            this.lblLongueur.TabIndex = 7;
            this.lblLongueur.Text = "Longueur (cm)";
            // 
            // nudHauteurCenter
            // 
            this.nudHauteurCenter.DecimalPlaces = 1;
            this.nudHauteurCenter.Location = new System.Drawing.Point(92, 79);
            this.nudHauteurCenter.Name = "nudHauteurCenter";
            this.nudHauteurCenter.Size = new System.Drawing.Size(131, 20);
            this.nudHauteurCenter.TabIndex = 10;
            // 
            // lblHauteurCenter
            // 
            this.lblHauteurCenter.AutoSize = true;
            this.lblHauteurCenter.Location = new System.Drawing.Point(8, 81);
            this.lblHauteurCenter.Name = "lblHauteurCenter";
            this.lblHauteurCenter.Size = new System.Drawing.Size(78, 13);
            this.lblHauteurCenter.TabIndex = 9;
            this.lblHauteurCenter.Text = "Hauteur centre";
            // 
            // nudLargeurCoucheCenter
            // 
            this.nudLargeurCoucheCenter.DecimalPlaces = 1;
            this.nudLargeurCoucheCenter.Location = new System.Drawing.Point(92, 26);
            this.nudLargeurCoucheCenter.Name = "nudLargeurCoucheCenter";
            this.nudLargeurCoucheCenter.Size = new System.Drawing.Size(131, 20);
            this.nudLargeurCoucheCenter.TabIndex = 12;
            // 
            // lblLargeurCenter
            // 
            this.lblLargeurCenter.AutoSize = true;
            this.lblLargeurCenter.Location = new System.Drawing.Point(8, 28);
            this.lblLargeurCenter.Name = "lblLargeurCenter";
            this.lblLargeurCenter.Size = new System.Drawing.Size(76, 13);
            this.lblLargeurCenter.TabIndex = 11;
            this.lblLargeurCenter.Text = "Largeur centre";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLargeurSide);
            this.groupBox1.Controls.Add(this.nudLargeurCoucheSide);
            this.groupBox1.Controls.Add(this.lblHauteurSide);
            this.groupBox1.Controls.Add(this.nudHauterSide);
            this.groupBox1.Controls.Add(this.lbxCouche);
            this.groupBox1.Controls.Add(this.btnCreerCouche);
            this.groupBox1.Controls.Add(this.lblHauteurCenter);
            this.groupBox1.Controls.Add(this.nudHauteurCenter);
            this.groupBox1.Controls.Add(this.lblLargeurCenter);
            this.groupBox1.Controls.Add(this.nudLargeurCoucheCenter);
            this.groupBox1.Location = new System.Drawing.Point(484, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 375);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Couche";
            // 
            // lblLargeurSide
            // 
            this.lblLargeurSide.AutoSize = true;
            this.lblLargeurSide.Location = new System.Drawing.Point(8, 54);
            this.lblLargeurSide.Name = "lblLargeurSide";
            this.lblLargeurSide.Size = new System.Drawing.Size(67, 13);
            this.lblLargeurSide.TabIndex = 17;
            this.lblLargeurSide.Text = "Largeur côté";
            // 
            // nudLargeurCoucheSide
            // 
            this.nudLargeurCoucheSide.DecimalPlaces = 1;
            this.nudLargeurCoucheSide.Location = new System.Drawing.Point(92, 52);
            this.nudLargeurCoucheSide.Name = "nudLargeurCoucheSide";
            this.nudLargeurCoucheSide.Size = new System.Drawing.Size(131, 20);
            this.nudLargeurCoucheSide.TabIndex = 18;
            // 
            // lblHauteurSide
            // 
            this.lblHauteurSide.AutoSize = true;
            this.lblHauteurSide.Location = new System.Drawing.Point(8, 109);
            this.lblHauteurSide.Name = "lblHauteurSide";
            this.lblHauteurSide.Size = new System.Drawing.Size(69, 13);
            this.lblHauteurSide.TabIndex = 15;
            this.lblHauteurSide.Text = "Hauteur côté";
            // 
            // nudHauterSide
            // 
            this.nudHauterSide.DecimalPlaces = 1;
            this.nudHauterSide.Location = new System.Drawing.Point(92, 107);
            this.nudHauterSide.Name = "nudHauterSide";
            this.nudHauterSide.Size = new System.Drawing.Size(131, 20);
            this.nudHauterSide.TabIndex = 16;
            // 
            // lbxCouche
            // 
            this.lbxCouche.FormattingEnabled = true;
            this.lbxCouche.Location = new System.Drawing.Point(9, 196);
            this.lbxCouche.Name = "lbxCouche";
            this.lbxCouche.Size = new System.Drawing.Size(212, 173);
            this.lbxCouche.TabIndex = 14;
            // 
            // btnCreerCouche
            // 
            this.btnCreerCouche.Location = new System.Drawing.Point(55, 167);
            this.btnCreerCouche.Name = "btnCreerCouche";
            this.btnCreerCouche.Size = new System.Drawing.Size(118, 23);
            this.btnCreerCouche.TabIndex = 13;
            this.btnCreerCouche.Text = "Créer couche";
            this.btnCreerCouche.UseVisualStyleBackColor = true;
            this.btnCreerCouche.Click += new System.EventHandler(this.CreerCouche);
            // 
            // gbxMatiere
            // 
            this.gbxMatiere.Controls.Add(this.tbxNomMatiere);
            this.gbxMatiere.Controls.Add(this.lblNomMatiere);
            this.gbxMatiere.Controls.Add(this.nudE);
            this.gbxMatiere.Controls.Add(this.lbxMatiere);
            this.gbxMatiere.Controls.Add(this.lblE);
            this.gbxMatiere.Controls.Add(this.btnCreerMatiere);
            this.gbxMatiere.Location = new System.Drawing.Point(717, 11);
            this.gbxMatiere.Name = "gbxMatiere";
            this.gbxMatiere.Size = new System.Drawing.Size(227, 375);
            this.gbxMatiere.TabIndex = 17;
            this.gbxMatiere.TabStop = false;
            this.gbxMatiere.Text = "Matière";
            // 
            // tbxNomMatiere
            // 
            this.tbxNomMatiere.Location = new System.Drawing.Point(101, 32);
            this.tbxNomMatiere.Name = "tbxNomMatiere";
            this.tbxNomMatiere.Size = new System.Drawing.Size(100, 20);
            this.tbxNomMatiere.TabIndex = 21;
            // 
            // lblNomMatiere
            // 
            this.lblNomMatiere.AutoSize = true;
            this.lblNomMatiere.Location = new System.Drawing.Point(6, 35);
            this.lblNomMatiere.Name = "lblNomMatiere";
            this.lblNomMatiere.Size = new System.Drawing.Size(29, 13);
            this.lblNomMatiere.TabIndex = 20;
            this.lblNomMatiere.Text = "Nom";
            // 
            // nudE
            // 
            this.nudE.DecimalPlaces = 1;
            this.nudE.Location = new System.Drawing.Point(101, 65);
            this.nudE.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudE.Name = "nudE";
            this.nudE.Size = new System.Drawing.Size(100, 20);
            this.nudE.TabIndex = 19;
            // 
            // lbxMatiere
            // 
            this.lbxMatiere.FormattingEnabled = true;
            this.lbxMatiere.Location = new System.Drawing.Point(9, 196);
            this.lbxMatiere.Name = "lbxMatiere";
            this.lbxMatiere.Size = new System.Drawing.Size(212, 173);
            this.lbxMatiere.TabIndex = 14;
            // 
            // lblE
            // 
            this.lblE.AutoSize = true;
            this.lblE.Location = new System.Drawing.Point(6, 67);
            this.lblE.Name = "lblE";
            this.lblE.Size = new System.Drawing.Size(14, 13);
            this.lblE.TabIndex = 18;
            this.lblE.Text = "E";
            // 
            // btnCreerMatiere
            // 
            this.btnCreerMatiere.Location = new System.Drawing.Point(55, 167);
            this.btnCreerMatiere.Name = "btnCreerMatiere";
            this.btnCreerMatiere.Size = new System.Drawing.Size(120, 23);
            this.btnCreerMatiere.TabIndex = 13;
            this.btnCreerMatiere.Text = "Créer matière";
            this.btnCreerMatiere.UseVisualStyleBackColor = true;
            this.btnCreerMatiere.Click += new System.EventHandler(this.CreerMatiere);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxNomPiece);
            this.groupBox2.Controls.Add(this.lblNomPiece);
            this.groupBox2.Controls.Add(this.btnCreerPiece);
            this.groupBox2.Controls.Add(this.lbxPiece);
            this.groupBox2.Controls.Add(this.btnAjouterCouche);
            this.groupBox2.Controls.Add(this.lblLongueur);
            this.groupBox2.Controls.Add(this.nudLongueurPiece);
            this.groupBox2.Location = new System.Drawing.Point(251, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 375);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Piece";
            // 
            // tbxNomPiece
            // 
            this.tbxNomPiece.Location = new System.Drawing.Point(101, 65);
            this.tbxNomPiece.Name = "tbxNomPiece";
            this.tbxNomPiece.Size = new System.Drawing.Size(120, 20);
            this.tbxNomPiece.TabIndex = 22;
            // 
            // lblNomPiece
            // 
            this.lblNomPiece.AutoSize = true;
            this.lblNomPiece.Location = new System.Drawing.Point(6, 65);
            this.lblNomPiece.Name = "lblNomPiece";
            this.lblNomPiece.Size = new System.Drawing.Size(29, 13);
            this.lblNomPiece.TabIndex = 16;
            this.lblNomPiece.Text = "Nom";
            // 
            // btnCreerPiece
            // 
            this.btnCreerPiece.Location = new System.Drawing.Point(62, 90);
            this.btnCreerPiece.Name = "btnCreerPiece";
            this.btnCreerPiece.Size = new System.Drawing.Size(115, 23);
            this.btnCreerPiece.TabIndex = 15;
            this.btnCreerPiece.Text = "Créer une pièce";
            this.btnCreerPiece.UseVisualStyleBackColor = true;
            this.btnCreerPiece.Click += new System.EventHandler(this.CreerPiece);
            // 
            // lbxPiece
            // 
            this.lbxPiece.FormattingEnabled = true;
            this.lbxPiece.Location = new System.Drawing.Point(9, 196);
            this.lbxPiece.Name = "lbxPiece";
            this.lbxPiece.Size = new System.Drawing.Size(212, 173);
            this.lbxPiece.TabIndex = 14;
            this.lbxPiece.SelectedIndexChanged += new System.EventHandler(this.ShowCoucheInPiece);
            // 
            // btnAjouterCouche
            // 
            this.btnAjouterCouche.Location = new System.Drawing.Point(62, 167);
            this.btnAjouterCouche.Name = "btnAjouterCouche";
            this.btnAjouterCouche.Size = new System.Drawing.Size(115, 23);
            this.btnAjouterCouche.TabIndex = 13;
            this.btnAjouterCouche.Text = "Ajouter couche";
            this.btnAjouterCouche.UseVisualStyleBackColor = true;
            this.btnAjouterCouche.Click += new System.EventHandler(this.AjouterCouche);
            // 
            // lbxShowCouchePiece
            // 
            this.lbxShowCouchePiece.FormattingEnabled = true;
            this.lbxShowCouchePiece.Location = new System.Drawing.Point(12, 208);
            this.lbxShowCouchePiece.Name = "lbxShowCouchePiece";
            this.lbxShowCouchePiece.Size = new System.Drawing.Size(233, 173);
            this.lbxShowCouchePiece.TabIndex = 23;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(455, 437);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(40, 13);
            this.lblError.TabIndex = 23;
            this.lblError.Text = "Erreurs";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(1079, 16);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(104, 23);
            this.btnTest.TabIndex = 23;
            this.btnTest.Text = "Calculer Ns et I";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lbxNs
            // 
            this.lbxNs.FormattingEnabled = true;
            this.lbxNs.Location = new System.Drawing.Point(966, 46);
            this.lbxNs.Name = "lbxNs";
            this.lbxNs.Size = new System.Drawing.Size(170, 433);
            this.lbxNs.TabIndex = 24;
            // 
            // lbxI
            // 
            this.lbxI.FormattingEnabled = true;
            this.lbxI.Location = new System.Drawing.Point(1142, 46);
            this.lbxI.Name = "lbxI";
            this.lbxI.Size = new System.Drawing.Size(164, 433);
            this.lbxI.TabIndex = 25;
            // 
            // lblNs
            // 
            this.lblNs.AutoSize = true;
            this.lblNs.Location = new System.Drawing.Point(1025, 21);
            this.lblNs.Name = "lblNs";
            this.lblNs.Size = new System.Drawing.Size(20, 13);
            this.lblNs.TabIndex = 22;
            this.lblNs.Text = "Ns";
            // 
            // lblI
            // 
            this.lblI.AutoSize = true;
            this.lblI.Location = new System.Drawing.Point(1220, 21);
            this.lblI.Name = "lblI";
            this.lblI.Size = new System.Drawing.Size(10, 13);
            this.lblI.TabIndex = 26;
            this.lblI.Text = "I";
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(105, 145);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(35, 13);
            this.lblTest.TabIndex = 28;
            this.lblTest.Text = "label2";
            // 
            // lbxMoment
            // 
            this.lbxMoment.FormattingEnabled = true;
            this.lbxMoment.Location = new System.Drawing.Point(1312, 46);
            this.lbxMoment.Name = "lbxMoment";
            this.lbxMoment.Size = new System.Drawing.Size(164, 433);
            this.lbxMoment.TabIndex = 29;
            // 
            // lblMoment
            // 
            this.lblMoment.AutoSize = true;
            this.lblMoment.Location = new System.Drawing.Point(1370, 21);
            this.lblMoment.Name = "lblMoment";
            this.lblMoment.Size = new System.Drawing.Size(45, 13);
            this.lblMoment.TabIndex = 30;
            this.lblMoment.Text = "Moment";
            // 
            // lbxIntegrale
            // 
            this.lbxIntegrale.FormattingEnabled = true;
            this.lbxIntegrale.Location = new System.Drawing.Point(1482, 46);
            this.lbxIntegrale.Name = "lbxIntegrale";
            this.lbxIntegrale.Size = new System.Drawing.Size(164, 433);
            this.lbxIntegrale.TabIndex = 31;
            // 
            // lblIntegrale
            // 
            this.lblIntegrale.AutoSize = true;
            this.lblIntegrale.Location = new System.Drawing.Point(1532, 21);
            this.lblIntegrale.Name = "lblIntegrale";
            this.lblIntegrale.Size = new System.Drawing.Size(48, 13);
            this.lblIntegrale.TabIndex = 32;
            this.lblIntegrale.Text = "Intégrale";
            // 
            // chrIntegrale
            // 
            chartArea1.Name = "ChartArea1";
            this.chrIntegrale.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrIntegrale.Legends.Add(legend1);
            this.chrIntegrale.Location = new System.Drawing.Point(15, 497);
            this.chrIntegrale.Name = "chrIntegrale";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrIntegrale.Series.Add(series1);
            this.chrIntegrale.Size = new System.Drawing.Size(1002, 300);
            this.chrIntegrale.TabIndex = 34;
            this.chrIntegrale.Text = "Graphe de l\'intégrale";
            // 
            // chrMomentForce
            // 
            chartArea2.Name = "ChartArea1";
            this.chrMomentForce.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrMomentForce.Legends.Add(legend2);
            this.chrMomentForce.Location = new System.Drawing.Point(15, 803);
            this.chrMomentForce.Name = "chrMomentForce";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chrMomentForce.Series.Add(series2);
            this.chrMomentForce.Size = new System.Drawing.Size(1002, 300);
            this.chrMomentForce.TabIndex = 35;
            this.chrMomentForce.Text = "Graphe de l\'intégrale";
            // 
            // tbxOutput
            // 
            this.tbxOutput.Location = new System.Drawing.Point(1047, 557);
            this.tbxOutput.Multiline = true;
            this.tbxOutput.Name = "tbxOutput";
            this.tbxOutput.Size = new System.Drawing.Size(577, 485);
            this.tbxOutput.TabIndex = 36;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1655, 1125);
            this.Controls.Add(this.tbxOutput);
            this.Controls.Add(this.chrMomentForce);
            this.Controls.Add(this.chrIntegrale);
            this.Controls.Add(this.lblIntegrale);
            this.Controls.Add(this.lbxIntegrale);
            this.Controls.Add(this.lblMoment);
            this.Controls.Add(this.lbxMoment);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.lblI);
            this.Controls.Add(this.lblNs);
            this.Controls.Add(this.lbxI);
            this.Controls.Add(this.lbxNs);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lbxShowCouchePiece);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxMatiere);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nudDeformation);
            this.Controls.Add(this.nudForce);
            this.Controls.Add(this.lblDeformation);
            this.Controls.Add(this.lblForce);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Flexion TIP";
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongueurPiece)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauteurCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCoucheCenter)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCoucheSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauterSide)).EndInit();
            this.gbxMatiere.ResumeLayout(false);
            this.gbxMatiere.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudE)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrIntegrale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrMomentForce)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblForce;
        private System.Windows.Forms.Label lblDeformation;
        private System.Windows.Forms.NumericUpDown nudForce;
        private System.Windows.Forms.NumericUpDown nudDeformation;
        private System.Windows.Forms.NumericUpDown nudLongueurPiece;
        private System.Windows.Forms.Label lblLongueur;
        private System.Windows.Forms.NumericUpDown nudHauteurCenter;
        private System.Windows.Forms.Label lblHauteurCenter;
        private System.Windows.Forms.NumericUpDown nudLargeurCoucheCenter;
        private System.Windows.Forms.Label lblLargeurCenter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreerCouche;
        private System.Windows.Forms.ListBox lbxCouche;
        private System.Windows.Forms.GroupBox gbxMatiere;
        private System.Windows.Forms.TextBox tbxNomMatiere;
        private System.Windows.Forms.Label lblNomMatiere;
        private System.Windows.Forms.NumericUpDown nudE;
        private System.Windows.Forms.ListBox lbxMatiere;
        private System.Windows.Forms.Label lblE;
        private System.Windows.Forms.Button btnCreerMatiere;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbxPiece;
        private System.Windows.Forms.Button btnAjouterCouche;
        private System.Windows.Forms.Button btnCreerPiece;
        private System.Windows.Forms.TextBox tbxNomPiece;
        private System.Windows.Forms.Label lblNomPiece;
        private System.Windows.Forms.ListBox lbxShowCouchePiece;
        private System.Windows.Forms.Label lblHauteurSide;
        private System.Windows.Forms.NumericUpDown nudHauterSide;
        private System.Windows.Forms.Label lblLargeurSide;
        private System.Windows.Forms.NumericUpDown nudLargeurCoucheSide;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ListBox lbxNs;
        private System.Windows.Forms.ListBox lbxI;
        private System.Windows.Forms.Label lblNs;
        private System.Windows.Forms.Label lblI;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.ListBox lbxMoment;
        private System.Windows.Forms.Label lblMoment;
        private System.Windows.Forms.ListBox lbxIntegrale;
        private System.Windows.Forms.Label lblIntegrale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrIntegrale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrMomentForce;
        private System.Windows.Forms.TextBox tbxOutput;
    }
}


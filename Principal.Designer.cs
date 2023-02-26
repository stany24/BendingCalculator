
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
            this.nudForce = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnModifierCouche = new System.Windows.Forms.Button();
            this.cbxCouche = new System.Windows.Forms.ComboBox();
            this.btnCreerCouche = new System.Windows.Forms.Button();
            this.cbxMatiere = new System.Windows.Forms.ComboBox();
            this.gbxMatiere = new System.Windows.Forms.GroupBox();
            this.btnModiferMatiere = new System.Windows.Forms.Button();
            this.btnCreerMatiere = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCreerPiece = new System.Windows.Forms.Button();
            this.lbxPiece = new System.Windows.Forms.ListBox();
            this.lblErreurPiece = new System.Windows.Forms.Label();
            this.lbxShowCouchePiece = new System.Windows.Forms.ListBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.lbxNs = new System.Windows.Forms.ListBox();
            this.lbxI = new System.Windows.Forms.ListBox();
            this.lblNs = new System.Windows.Forms.Label();
            this.lblI = new System.Windows.Forms.Label();
            this.lbxMoment = new System.Windows.Forms.ListBox();
            this.lblMoment = new System.Windows.Forms.Label();
            this.lbxIntegrale = new System.Windows.Forms.ListBox();
            this.lblIntegrale = new System.Windows.Forms.Label();
            this.chrIntegrale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chrMomentForce = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbxOutput = new System.Windows.Forms.TextBox();
            this.nudGravite = new System.Windows.Forms.NumericUpDown();
            this.lblGravité = new System.Windows.Forms.Label();
            this.nudVitesse = new System.Windows.Forms.NumericUpDown();
            this.lblVitesse = new System.Windows.Forms.Label();
            this.nudRayon = new System.Windows.Forms.NumericUpDown();
            this.lblRayon = new System.Windows.Forms.Label();
            this.nudMasse = new System.Windows.Forms.NumericUpDown();
            this.lblMasse = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblErreurProcess = new System.Windows.Forms.Label();
            this.cbxPiece = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbxMatiere.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrIntegrale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrMomentForce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitesse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRayon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMasse)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblForce
            // 
            this.lblForce.AutoSize = true;
            this.lblForce.Location = new System.Drawing.Point(22, 245);
            this.lblForce.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForce.Name = "lblForce";
            this.lblForce.Size = new System.Drawing.Size(75, 20);
            this.lblForce.TabIndex = 0;
            this.lblForce.Text = "Force (N)";
            // 
            // nudForce
            // 
            this.nudForce.DecimalPlaces = 1;
            this.nudForce.Location = new System.Drawing.Point(192, 242);
            this.nudForce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudForce.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudForce.Name = "nudForce";
            this.nudForce.Size = new System.Drawing.Size(180, 26);
            this.nudForce.TabIndex = 5;
            this.nudForce.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModifierCouche);
            this.groupBox1.Controls.Add(this.cbxCouche);
            this.groupBox1.Controls.Add(this.btnCreerCouche);
            this.groupBox1.Location = new System.Drawing.Point(760, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(276, 115);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Couche";
            // 
            // btnModifierCouche
            // 
            this.btnModifierCouche.Location = new System.Drawing.Point(14, 68);
            this.btnModifierCouche.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModifierCouche.Name = "btnModifierCouche";
            this.btnModifierCouche.Size = new System.Drawing.Size(121, 35);
            this.btnModifierCouche.TabIndex = 29;
            this.btnModifierCouche.Text = "Modifer";
            this.btnModifierCouche.UseVisualStyleBackColor = true;
            this.btnModifierCouche.Click += new System.EventHandler(this.ModifierCouche);
            // 
            // cbxCouche
            // 
            this.cbxCouche.FormattingEnabled = true;
            this.cbxCouche.Location = new System.Drawing.Point(14, 28);
            this.cbxCouche.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxCouche.Name = "cbxCouche";
            this.cbxCouche.Size = new System.Drawing.Size(250, 28);
            this.cbxCouche.TabIndex = 28;
            // 
            // btnCreerCouche
            // 
            this.btnCreerCouche.Location = new System.Drawing.Point(143, 68);
            this.btnCreerCouche.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreerCouche.Name = "btnCreerCouche";
            this.btnCreerCouche.Size = new System.Drawing.Size(121, 35);
            this.btnCreerCouche.TabIndex = 27;
            this.btnCreerCouche.Text = "Créer";
            this.btnCreerCouche.UseVisualStyleBackColor = true;
            this.btnCreerCouche.Click += new System.EventHandler(this.CreerCouche);
            // 
            // cbxMatiere
            // 
            this.cbxMatiere.FormattingEnabled = true;
            this.cbxMatiere.Location = new System.Drawing.Point(14, 29);
            this.cbxMatiere.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxMatiere.Name = "cbxMatiere";
            this.cbxMatiere.Size = new System.Drawing.Size(250, 28);
            this.cbxMatiere.TabIndex = 24;
            // 
            // gbxMatiere
            // 
            this.gbxMatiere.Controls.Add(this.btnModiferMatiere);
            this.gbxMatiere.Controls.Add(this.cbxMatiere);
            this.gbxMatiere.Controls.Add(this.btnCreerMatiere);
            this.gbxMatiere.Location = new System.Drawing.Point(1044, 18);
            this.gbxMatiere.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxMatiere.Name = "gbxMatiere";
            this.gbxMatiere.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxMatiere.Size = new System.Drawing.Size(278, 116);
            this.gbxMatiere.TabIndex = 17;
            this.gbxMatiere.TabStop = false;
            this.gbxMatiere.Text = "Matières";
            // 
            // btnModiferMatiere
            // 
            this.btnModiferMatiere.Location = new System.Drawing.Point(14, 69);
            this.btnModiferMatiere.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModiferMatiere.Name = "btnModiferMatiere";
            this.btnModiferMatiere.Size = new System.Drawing.Size(121, 35);
            this.btnModiferMatiere.TabIndex = 26;
            this.btnModiferMatiere.Text = "Modifer";
            this.btnModiferMatiere.UseVisualStyleBackColor = true;
            this.btnModiferMatiere.Click += new System.EventHandler(this.ModiferMatiere);
            // 
            // btnCreerMatiere
            // 
            this.btnCreerMatiere.Location = new System.Drawing.Point(143, 69);
            this.btnCreerMatiere.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreerMatiere.Name = "btnCreerMatiere";
            this.btnCreerMatiere.Size = new System.Drawing.Size(121, 35);
            this.btnCreerMatiere.TabIndex = 13;
            this.btnCreerMatiere.Text = "Créer";
            this.btnCreerMatiere.UseVisualStyleBackColor = true;
            this.btnCreerMatiere.Click += new System.EventHandler(this.CreerMatiere);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxPiece);
            this.groupBox2.Controls.Add(this.btnCreerPiece);
            this.groupBox2.Controls.Add(this.lbxPiece);
            this.groupBox2.Controls.Add(this.lblErreurPiece);
            this.groupBox2.Location = new System.Drawing.Point(411, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(340, 577);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Piece";
            // 
            // btnCreerPiece
            // 
            this.btnCreerPiece.Location = new System.Drawing.Point(144, 65);
            this.btnCreerPiece.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreerPiece.Name = "btnCreerPiece";
            this.btnCreerPiece.Size = new System.Drawing.Size(108, 35);
            this.btnCreerPiece.TabIndex = 15;
            this.btnCreerPiece.Text = "Créer";
            this.btnCreerPiece.UseVisualStyleBackColor = true;
            this.btnCreerPiece.Click += new System.EventHandler(this.CreerPiece);
            // 
            // lbxPiece
            // 
            this.lbxPiece.FormattingEnabled = true;
            this.lbxPiece.ItemHeight = 20;
            this.lbxPiece.Location = new System.Drawing.Point(14, 362);
            this.lbxPiece.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbxPiece.Name = "lbxPiece";
            this.lbxPiece.Size = new System.Drawing.Size(316, 204);
            this.lbxPiece.TabIndex = 14;
            this.lbxPiece.SelectedIndexChanged += new System.EventHandler(this.ShowCoucheInPiece);
            // 
            // lblErreurPiece
            // 
            this.lblErreurPiece.AutoSize = true;
            this.lblErreurPiece.Location = new System.Drawing.Point(147, 268);
            this.lblErreurPiece.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErreurPiece.Name = "lblErreurPiece";
            this.lblErreurPiece.Size = new System.Drawing.Size(61, 20);
            this.lblErreurPiece.TabIndex = 23;
            this.lblErreurPiece.Text = "Erreurs";
            // 
            // lbxShowCouchePiece
            // 
            this.lbxShowCouchePiece.FormattingEnabled = true;
            this.lbxShowCouchePiece.ItemHeight = 20;
            this.lbxShowCouchePiece.Location = new System.Drawing.Point(44, 380);
            this.lbxShowCouchePiece.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbxShowCouchePiece.Name = "lbxShowCouchePiece";
            this.lbxShowCouchePiece.Size = new System.Drawing.Size(348, 204);
            this.lbxShowCouchePiece.TabIndex = 23;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(675, 605);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(156, 35);
            this.btnTest.TabIndex = 23;
            this.btnTest.Text = "Calculer la flexion";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.DisplayGraphForPiece);
            // 
            // lbxNs
            // 
            this.lbxNs.FormattingEnabled = true;
            this.lbxNs.ItemHeight = 20;
            this.lbxNs.Location = new System.Drawing.Point(1474, 71);
            this.lbxNs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbxNs.Name = "lbxNs";
            this.lbxNs.Size = new System.Drawing.Size(253, 664);
            this.lbxNs.TabIndex = 24;
            // 
            // lbxI
            // 
            this.lbxI.FormattingEnabled = true;
            this.lbxI.ItemHeight = 20;
            this.lbxI.Location = new System.Drawing.Point(1713, 71);
            this.lbxI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbxI.Name = "lbxI";
            this.lbxI.Size = new System.Drawing.Size(244, 664);
            this.lbxI.TabIndex = 25;
            // 
            // lblNs
            // 
            this.lblNs.AutoSize = true;
            this.lblNs.Location = new System.Drawing.Point(1538, 32);
            this.lblNs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNs.Name = "lblNs";
            this.lblNs.Size = new System.Drawing.Size(28, 20);
            this.lblNs.TabIndex = 22;
            this.lblNs.Text = "Ns";
            // 
            // lblI
            // 
            this.lblI.AutoSize = true;
            this.lblI.Location = new System.Drawing.Point(1830, 32);
            this.lblI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblI.Name = "lblI";
            this.lblI.Size = new System.Drawing.Size(14, 20);
            this.lblI.TabIndex = 26;
            this.lblI.Text = "I";
            // 
            // lbxMoment
            // 
            this.lbxMoment.FormattingEnabled = true;
            this.lbxMoment.ItemHeight = 20;
            this.lbxMoment.Location = new System.Drawing.Point(1968, 71);
            this.lbxMoment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbxMoment.Name = "lbxMoment";
            this.lbxMoment.Size = new System.Drawing.Size(244, 664);
            this.lbxMoment.TabIndex = 29;
            // 
            // lblMoment
            // 
            this.lblMoment.AutoSize = true;
            this.lblMoment.Location = new System.Drawing.Point(2055, 32);
            this.lblMoment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoment.Name = "lblMoment";
            this.lblMoment.Size = new System.Drawing.Size(67, 20);
            this.lblMoment.TabIndex = 30;
            this.lblMoment.Text = "Moment";
            // 
            // lbxIntegrale
            // 
            this.lbxIntegrale.FormattingEnabled = true;
            this.lbxIntegrale.ItemHeight = 20;
            this.lbxIntegrale.Location = new System.Drawing.Point(2223, 71);
            this.lbxIntegrale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbxIntegrale.Name = "lbxIntegrale";
            this.lbxIntegrale.Size = new System.Drawing.Size(244, 664);
            this.lbxIntegrale.TabIndex = 31;
            // 
            // lblIntegrale
            // 
            this.lblIntegrale.AutoSize = true;
            this.lblIntegrale.Location = new System.Drawing.Point(2298, 32);
            this.lblIntegrale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIntegrale.Name = "lblIntegrale";
            this.lblIntegrale.Size = new System.Drawing.Size(72, 20);
            this.lblIntegrale.TabIndex = 32;
            this.lblIntegrale.Text = "Intégrale";
            // 
            // chrIntegrale
            // 
            chartArea1.Name = "ChartArea1";
            this.chrIntegrale.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrIntegrale.Legends.Add(legend1);
            this.chrIntegrale.Location = new System.Drawing.Point(22, 649);
            this.chrIntegrale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chrIntegrale.Name = "chrIntegrale";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrIntegrale.Series.Add(series1);
            this.chrIntegrale.Size = new System.Drawing.Size(1428, 462);
            this.chrIntegrale.TabIndex = 34;
            this.chrIntegrale.Text = "Graphe de l\'intégrale";
            // 
            // chrMomentForce
            // 
            chartArea2.Name = "ChartArea1";
            this.chrMomentForce.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrMomentForce.Legends.Add(legend2);
            this.chrMomentForce.Location = new System.Drawing.Point(22, 1120);
            this.chrMomentForce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chrMomentForce.Name = "chrMomentForce";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chrMomentForce.Series.Add(series2);
            this.chrMomentForce.Size = new System.Drawing.Size(1428, 462);
            this.chrMomentForce.TabIndex = 35;
            this.chrMomentForce.Text = "Graphe de l\'intégrale";
            // 
            // tbxOutput
            // 
            this.tbxOutput.Location = new System.Drawing.Point(1570, 857);
            this.tbxOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxOutput.Multiline = true;
            this.tbxOutput.Name = "tbxOutput";
            this.tbxOutput.Size = new System.Drawing.Size(864, 744);
            this.tbxOutput.TabIndex = 36;
            // 
            // nudGravite
            // 
            this.nudGravite.DecimalPlaces = 2;
            this.nudGravite.Location = new System.Drawing.Point(192, 191);
            this.nudGravite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudGravite.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudGravite.Name = "nudGravite";
            this.nudGravite.Size = new System.Drawing.Size(180, 26);
            this.nudGravite.TabIndex = 38;
            this.nudGravite.Value = new decimal(new int[] {
            981,
            0,
            0,
            131072});
            this.nudGravite.ValueChanged += new System.EventHandler(this.CalcuateF);
            // 
            // lblGravité
            // 
            this.lblGravité.AutoSize = true;
            this.lblGravité.Location = new System.Drawing.Point(22, 194);
            this.lblGravité.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGravité.Name = "lblGravité";
            this.lblGravité.Size = new System.Drawing.Size(85, 20);
            this.lblGravité.TabIndex = 37;
            this.lblGravité.Text = "Gravité (N)";
            // 
            // nudVitesse
            // 
            this.nudVitesse.DecimalPlaces = 2;
            this.nudVitesse.Location = new System.Drawing.Point(192, 140);
            this.nudVitesse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudVitesse.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudVitesse.Name = "nudVitesse";
            this.nudVitesse.Size = new System.Drawing.Size(180, 26);
            this.nudVitesse.TabIndex = 40;
            this.nudVitesse.Value = new decimal(new int[] {
            1666,
            0,
            0,
            131072});
            this.nudVitesse.ValueChanged += new System.EventHandler(this.CalcuateF);
            // 
            // lblVitesse
            // 
            this.lblVitesse.AutoSize = true;
            this.lblVitesse.Location = new System.Drawing.Point(22, 143);
            this.lblVitesse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVitesse.Name = "lblVitesse";
            this.lblVitesse.Size = new System.Drawing.Size(101, 20);
            this.lblVitesse.TabIndex = 39;
            this.lblVitesse.Text = "Vitesse (m/s)";
            // 
            // nudRayon
            // 
            this.nudRayon.DecimalPlaces = 2;
            this.nudRayon.Location = new System.Drawing.Point(192, 89);
            this.nudRayon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudRayon.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudRayon.Name = "nudRayon";
            this.nudRayon.Size = new System.Drawing.Size(180, 26);
            this.nudRayon.TabIndex = 42;
            this.nudRayon.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.nudRayon.ValueChanged += new System.EventHandler(this.CalcuateF);
            // 
            // lblRayon
            // 
            this.lblRayon.AutoSize = true;
            this.lblRayon.Location = new System.Drawing.Point(22, 92);
            this.lblRayon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRayon.Name = "lblRayon";
            this.lblRayon.Size = new System.Drawing.Size(82, 20);
            this.lblRayon.TabIndex = 41;
            this.lblRayon.Text = "Rayon (m)";
            // 
            // nudMasse
            // 
            this.nudMasse.DecimalPlaces = 2;
            this.nudMasse.Location = new System.Drawing.Point(192, 38);
            this.nudMasse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMasse.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudMasse.Name = "nudMasse";
            this.nudMasse.Size = new System.Drawing.Size(180, 26);
            this.nudMasse.TabIndex = 44;
            this.nudMasse.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nudMasse.ValueChanged += new System.EventHandler(this.CalcuateF);
            // 
            // lblMasse
            // 
            this.lblMasse.AutoSize = true;
            this.lblMasse.Location = new System.Drawing.Point(22, 42);
            this.lblMasse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMasse.Name = "lblMasse";
            this.lblMasse.Size = new System.Drawing.Size(87, 20);
            this.lblMasse.TabIndex = 43;
            this.lblMasse.Text = "Masse (kg)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudForce);
            this.groupBox3.Controls.Add(this.nudMasse);
            this.groupBox3.Controls.Add(this.lblForce);
            this.groupBox3.Controls.Add(this.lblMasse);
            this.groupBox3.Controls.Add(this.lblGravité);
            this.groupBox3.Controls.Add(this.nudRayon);
            this.groupBox3.Controls.Add(this.nudGravite);
            this.groupBox3.Controls.Add(this.lblRayon);
            this.groupBox3.Controls.Add(this.lblVitesse);
            this.groupBox3.Controls.Add(this.nudVitesse);
            this.groupBox3.Location = new System.Drawing.Point(16, 18);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(386, 288);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Force appliquée";
            // 
            // lblErreurProcess
            // 
            this.lblErreurProcess.AutoSize = true;
            this.lblErreurProcess.Location = new System.Drawing.Point(840, 612);
            this.lblErreurProcess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErreurProcess.Name = "lblErreurProcess";
            this.lblErreurProcess.Size = new System.Drawing.Size(61, 20);
            this.lblErreurProcess.TabIndex = 24;
            this.lblErreurProcess.Text = "Erreurs";
            // 
            // cbxPiece
            // 
            this.cbxPiece.FormattingEnabled = true;
            this.cbxPiece.Location = new System.Drawing.Point(14, 29);
            this.cbxPiece.Name = "cbxPiece";
            this.cbxPiece.Size = new System.Drawing.Size(238, 28);
            this.cbxPiece.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 1050);
            this.Controls.Add(this.lblErreurProcess);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tbxOutput);
            this.Controls.Add(this.chrMomentForce);
            this.Controls.Add(this.chrIntegrale);
            this.Controls.Add(this.lblIntegrale);
            this.Controls.Add(this.lbxIntegrale);
            this.Controls.Add(this.lblMoment);
            this.Controls.Add(this.lbxMoment);
            this.Controls.Add(this.lblI);
            this.Controls.Add(this.lblNs);
            this.Controls.Add(this.lbxI);
            this.Controls.Add(this.lbxNs);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lbxShowCouchePiece);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxMatiere);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Flexion TIP";
            this.EnabledChanged += new System.EventHandler(this.Form1_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gbxMatiere.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrIntegrale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrMomentForce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitesse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRayon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMasse)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblForce;
        private System.Windows.Forms.NumericUpDown nudForce;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbxMatiere;
        private System.Windows.Forms.Button btnCreerMatiere;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbxPiece;
        private System.Windows.Forms.Button btnCreerPiece;
        private System.Windows.Forms.ListBox lbxShowCouchePiece;
        private System.Windows.Forms.Label lblErreurPiece;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ListBox lbxNs;
        private System.Windows.Forms.ListBox lbxI;
        private System.Windows.Forms.Label lblNs;
        private System.Windows.Forms.Label lblI;
        private System.Windows.Forms.ListBox lbxMoment;
        private System.Windows.Forms.Label lblMoment;
        private System.Windows.Forms.ListBox lbxIntegrale;
        private System.Windows.Forms.Label lblIntegrale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrIntegrale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrMomentForce;
        private System.Windows.Forms.TextBox tbxOutput;
        private System.Windows.Forms.NumericUpDown nudGravite;
        private System.Windows.Forms.Label lblGravité;
        private System.Windows.Forms.NumericUpDown nudVitesse;
        private System.Windows.Forms.Label lblVitesse;
        private System.Windows.Forms.NumericUpDown nudRayon;
        private System.Windows.Forms.Label lblRayon;
        private System.Windows.Forms.NumericUpDown nudMasse;
        private System.Windows.Forms.Label lblMasse;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblErreurProcess;
        private System.Windows.Forms.ComboBox cbxMatiere;
        private System.Windows.Forms.Button btnModiferMatiere;
        private System.Windows.Forms.Button btnModifierCouche;
        private System.Windows.Forms.ComboBox cbxCouche;
        private System.Windows.Forms.Button btnCreerCouche;
        private System.Windows.Forms.ComboBox cbxPiece;
    }
}



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
            this.btnModifierPiece = new System.Windows.Forms.Button();
            this.cbxPiece = new System.Windows.Forms.ComboBox();
            this.btnCreerPiece = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.lbxMoment = new System.Windows.Forms.ListBox();
            this.lblMoment = new System.Windows.Forms.Label();
            this.lbxIntegrale = new System.Windows.Forms.ListBox();
            this.lblIntegrale = new System.Windows.Forms.Label();
            this.chrIntegrale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chrMomentForce = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nudEcart = new System.Windows.Forms.NumericUpDown();
            this.lblGravité = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCalculerForce = new System.Windows.Forms.Button();
            this.lblErreur = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbxMatiere.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrIntegrale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrMomentForce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEcart)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblForce
            // 
            this.lblForce.AutoSize = true;
            this.lblForce.Location = new System.Drawing.Point(8, 83);
            this.lblForce.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForce.Name = "lblForce";
            this.lblForce.Size = new System.Drawing.Size(75, 20);
            this.lblForce.TabIndex = 0;
            this.lblForce.Text = "Force (N)";
            // 
            // nudForce
            // 
            this.nudForce.DecimalPlaces = 1;
            this.nudForce.Location = new System.Drawing.Point(100, 82);
            this.nudForce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudForce.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudForce.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudForce.Name = "nudForce";
            this.nudForce.Size = new System.Drawing.Size(130, 26);
            this.nudForce.TabIndex = 5;
            this.nudForce.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudForce.ValueChanged += new System.EventHandler(this.ForceChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModifierCouche);
            this.groupBox1.Controls.Add(this.cbxCouche);
            this.groupBox1.Controls.Add(this.btnCreerCouche);
            this.groupBox1.Location = new System.Drawing.Point(626, 14);
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
            this.btnModifierCouche.Size = new System.Drawing.Size(122, 35);
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
            this.btnCreerCouche.Location = new System.Drawing.Point(142, 68);
            this.btnCreerCouche.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreerCouche.Name = "btnCreerCouche";
            this.btnCreerCouche.Size = new System.Drawing.Size(122, 35);
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
            this.gbxMatiere.Location = new System.Drawing.Point(909, 14);
            this.gbxMatiere.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxMatiere.Name = "gbxMatiere";
            this.gbxMatiere.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxMatiere.Size = new System.Drawing.Size(278, 115);
            this.gbxMatiere.TabIndex = 17;
            this.gbxMatiere.TabStop = false;
            this.gbxMatiere.Text = "Matières";
            // 
            // btnModiferMatiere
            // 
            this.btnModiferMatiere.Location = new System.Drawing.Point(14, 69);
            this.btnModiferMatiere.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModiferMatiere.Name = "btnModiferMatiere";
            this.btnModiferMatiere.Size = new System.Drawing.Size(122, 35);
            this.btnModiferMatiere.TabIndex = 26;
            this.btnModiferMatiere.Text = "Modifer";
            this.btnModiferMatiere.UseVisualStyleBackColor = true;
            this.btnModiferMatiere.Click += new System.EventHandler(this.ModiferMatiere);
            // 
            // btnCreerMatiere
            // 
            this.btnCreerMatiere.Location = new System.Drawing.Point(142, 69);
            this.btnCreerMatiere.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreerMatiere.Name = "btnCreerMatiere";
            this.btnCreerMatiere.Size = new System.Drawing.Size(122, 35);
            this.btnCreerMatiere.TabIndex = 13;
            this.btnCreerMatiere.Text = "Créer";
            this.btnCreerMatiere.UseVisualStyleBackColor = true;
            this.btnCreerMatiere.Click += new System.EventHandler(this.CreerMatiere);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnModifierPiece);
            this.groupBox2.Controls.Add(this.cbxPiece);
            this.groupBox2.Controls.Add(this.btnCreerPiece);
            this.groupBox2.Controls.Add(this.btnTest);
            this.groupBox2.Location = new System.Drawing.Point(351, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(266, 163);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Piece";
            // 
            // btnModifierPiece
            // 
            this.btnModifierPiece.Location = new System.Drawing.Point(14, 65);
            this.btnModifierPiece.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModifierPiece.Name = "btnModifierPiece";
            this.btnModifierPiece.Size = new System.Drawing.Size(108, 35);
            this.btnModifierPiece.TabIndex = 25;
            this.btnModifierPiece.Text = "Modifier";
            this.btnModifierPiece.UseVisualStyleBackColor = true;
            this.btnModifierPiece.Click += new System.EventHandler(this.ModifierPiece);
            // 
            // cbxPiece
            // 
            this.cbxPiece.FormattingEnabled = true;
            this.cbxPiece.Location = new System.Drawing.Point(14, 29);
            this.cbxPiece.Name = "cbxPiece";
            this.cbxPiece.Size = new System.Drawing.Size(238, 28);
            this.cbxPiece.TabIndex = 24;
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
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(14, 111);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(238, 35);
            this.btnTest.TabIndex = 23;
            this.btnTest.Text = "Calculer la flexion";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.DisplayGraphForPiece);
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
            this.chrIntegrale.Location = new System.Drawing.Point(14, 188);
            this.chrIntegrale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chrIntegrale.Name = "chrIntegrale";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrIntegrale.Series.Add(series1);
            this.chrIntegrale.Size = new System.Drawing.Size(1174, 462);
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
            // nudEcart
            // 
            this.nudEcart.DecimalPlaces = 2;
            this.nudEcart.Location = new System.Drawing.Point(100, 31);
            this.nudEcart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudEcart.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudEcart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudEcart.Name = "nudEcart";
            this.nudEcart.Size = new System.Drawing.Size(130, 26);
            this.nudEcart.TabIndex = 38;
            this.nudEcart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEcart.ValueChanged += new System.EventHandler(this.EcartChanged);
            // 
            // lblGravité
            // 
            this.lblGravité.AutoSize = true;
            this.lblGravité.Location = new System.Drawing.Point(8, 32);
            this.lblGravité.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGravité.Name = "lblGravité";
            this.lblGravité.Size = new System.Drawing.Size(87, 20);
            this.lblGravité.TabIndex = 37;
            this.lblGravité.Text = "Ecart (mm)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCalculerForce);
            this.groupBox3.Controls.Add(this.nudForce);
            this.groupBox3.Controls.Add(this.lblForce);
            this.groupBox3.Controls.Add(this.lblGravité);
            this.groupBox3.Controls.Add(this.nudEcart);
            this.groupBox3.Location = new System.Drawing.Point(16, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(327, 125);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Paramètres";
            // 
            // btnCalculerForce
            // 
            this.btnCalculerForce.Location = new System.Drawing.Point(238, 82);
            this.btnCalculerForce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCalculerForce.Name = "btnCalculerForce";
            this.btnCalculerForce.Size = new System.Drawing.Size(80, 34);
            this.btnCalculerForce.TabIndex = 26;
            this.btnCalculerForce.Text = "Calculer";
            this.btnCalculerForce.UseVisualStyleBackColor = true;
            this.btnCalculerForce.Click += new System.EventHandler(this.CalculerForce);
            // 
            // lblErreur
            // 
            this.lblErreur.AutoSize = true;
            this.lblErreur.Location = new System.Drawing.Point(752, 266);
            this.lblErreur.Name = "lblErreur";
            this.lblErreur.Size = new System.Drawing.Size(0, 20);
            this.lblErreur.TabIndex = 46;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 655);
            this.Controls.Add(this.lblErreur);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chrMomentForce);
            this.Controls.Add(this.chrIntegrale);
            this.Controls.Add(this.lblIntegrale);
            this.Controls.Add(this.lbxIntegrale);
            this.Controls.Add(this.lblMoment);
            this.Controls.Add(this.lbxMoment);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxMatiere);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Flexion TIP";
            this.EnabledChanged += new System.EventHandler(this.Form1_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gbxMatiere.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrIntegrale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrMomentForce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEcart)).EndInit();
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
        private System.Windows.Forms.Button btnCreerPiece;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ListBox lbxMoment;
        private System.Windows.Forms.Label lblMoment;
        private System.Windows.Forms.ListBox lbxIntegrale;
        private System.Windows.Forms.Label lblIntegrale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrIntegrale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrMomentForce;
        private System.Windows.Forms.NumericUpDown nudEcart;
        private System.Windows.Forms.Label lblGravité;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbxMatiere;
        private System.Windows.Forms.Button btnModiferMatiere;
        private System.Windows.Forms.Button btnModifierCouche;
        private System.Windows.Forms.ComboBox cbxCouche;
        private System.Windows.Forms.Button btnCreerCouche;
        private System.Windows.Forms.ComboBox cbxPiece;
        private System.Windows.Forms.Button btnModifierPiece;
        private System.Windows.Forms.Label lblErreur;
        private System.Windows.Forms.Button btnCalculerForce;
    }
}


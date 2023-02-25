namespace Flexion
{
    partial class CreateurCouche
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxMatiere = new System.Windows.Forms.ComboBox();
            this.lblMatiere = new System.Windows.Forms.Label();
            this.lblLargeurSide = new System.Windows.Forms.Label();
            this.nudLargeurCoucheSide = new System.Windows.Forms.NumericUpDown();
            this.lblHauteurSide = new System.Windows.Forms.Label();
            this.nudHauterSide = new System.Windows.Forms.NumericUpDown();
            this.lblHauteurCenter = new System.Windows.Forms.Label();
            this.nudHauteurCenter = new System.Windows.Forms.NumericUpDown();
            this.lblLargeurCenter = new System.Windows.Forms.Label();
            this.nudLargeurCoucheCenter = new System.Windows.Forms.NumericUpDown();
            this.cbxCouche = new System.Windows.Forms.ComboBox();
            this.btnCreerCouche = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCoucheSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauterSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauteurCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCoucheCenter)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxMatiere
            // 
            this.cbxMatiere.FormattingEnabled = true;
            this.cbxMatiere.Location = new System.Drawing.Point(169, 219);
            this.cbxMatiere.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxMatiere.Name = "cbxMatiere";
            this.cbxMatiere.Size = new System.Drawing.Size(168, 28);
            this.cbxMatiere.TabIndex = 36;
            // 
            // lblMatiere
            // 
            this.lblMatiere.AutoSize = true;
            this.lblMatiere.Location = new System.Drawing.Point(8, 220);
            this.lblMatiere.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatiere.Name = "lblMatiere";
            this.lblMatiere.Size = new System.Drawing.Size(62, 20);
            this.lblMatiere.TabIndex = 35;
            this.lblMatiere.Text = "Matière";
            // 
            // lblLargeurSide
            // 
            this.lblLargeurSide.AutoSize = true;
            this.lblLargeurSide.Location = new System.Drawing.Point(8, 94);
            this.lblLargeurSide.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLargeurSide.Name = "lblLargeurSide";
            this.lblLargeurSide.Size = new System.Drawing.Size(139, 20);
            this.lblLargeurSide.TabIndex = 33;
            this.lblLargeurSide.Text = "Largeur côté (mm)";
            // 
            // nudLargeurCoucheSide
            // 
            this.nudLargeurCoucheSide.DecimalPlaces = 1;
            this.nudLargeurCoucheSide.Location = new System.Drawing.Point(169, 92);
            this.nudLargeurCoucheSide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudLargeurCoucheSide.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudLargeurCoucheSide.Name = "nudLargeurCoucheSide";
            this.nudLargeurCoucheSide.Size = new System.Drawing.Size(168, 26);
            this.nudLargeurCoucheSide.TabIndex = 34;
            // 
            // lblHauteurSide
            // 
            this.lblHauteurSide.AutoSize = true;
            this.lblHauteurSide.Location = new System.Drawing.Point(8, 179);
            this.lblHauteurSide.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHauteurSide.Name = "lblHauteurSide";
            this.lblHauteurSide.Size = new System.Drawing.Size(142, 20);
            this.lblHauteurSide.TabIndex = 31;
            this.lblHauteurSide.Text = "Hauteur côté (mm)";
            // 
            // nudHauterSide
            // 
            this.nudHauterSide.DecimalPlaces = 1;
            this.nudHauterSide.Location = new System.Drawing.Point(169, 177);
            this.nudHauterSide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudHauterSide.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHauterSide.Name = "nudHauterSide";
            this.nudHauterSide.Size = new System.Drawing.Size(168, 26);
            this.nudHauterSide.TabIndex = 32;
            // 
            // lblHauteurCenter
            // 
            this.lblHauteurCenter.AutoSize = true;
            this.lblHauteurCenter.Location = new System.Drawing.Point(8, 136);
            this.lblHauteurCenter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHauteurCenter.Name = "lblHauteurCenter";
            this.lblHauteurCenter.Size = new System.Drawing.Size(156, 20);
            this.lblHauteurCenter.TabIndex = 27;
            this.lblHauteurCenter.Text = "Hauteur centre (mm)";
            // 
            // nudHauteurCenter
            // 
            this.nudHauteurCenter.DecimalPlaces = 1;
            this.nudHauteurCenter.Location = new System.Drawing.Point(169, 134);
            this.nudHauteurCenter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudHauteurCenter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHauteurCenter.Name = "nudHauteurCenter";
            this.nudHauteurCenter.Size = new System.Drawing.Size(168, 26);
            this.nudHauteurCenter.TabIndex = 28;
            // 
            // lblLargeurCenter
            // 
            this.lblLargeurCenter.AutoSize = true;
            this.lblLargeurCenter.Location = new System.Drawing.Point(8, 54);
            this.lblLargeurCenter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLargeurCenter.Name = "lblLargeurCenter";
            this.lblLargeurCenter.Size = new System.Drawing.Size(153, 20);
            this.lblLargeurCenter.TabIndex = 29;
            this.lblLargeurCenter.Text = "Largeur centre (mm)";
            // 
            // nudLargeurCoucheCenter
            // 
            this.nudLargeurCoucheCenter.DecimalPlaces = 1;
            this.nudLargeurCoucheCenter.Location = new System.Drawing.Point(169, 52);
            this.nudLargeurCoucheCenter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudLargeurCoucheCenter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudLargeurCoucheCenter.Name = "nudLargeurCoucheCenter";
            this.nudLargeurCoucheCenter.Size = new System.Drawing.Size(168, 26);
            this.nudLargeurCoucheCenter.TabIndex = 30;
            // 
            // cbxCouche
            // 
            this.cbxCouche.FormattingEnabled = true;
            this.cbxCouche.Location = new System.Drawing.Point(12, 12);
            this.cbxCouche.Name = "cbxCouche";
            this.cbxCouche.Size = new System.Drawing.Size(325, 28);
            this.cbxCouche.TabIndex = 37;
            // 
            // btnCreerCouche
            // 
            this.btnCreerCouche.Location = new System.Drawing.Point(122, 255);
            this.btnCreerCouche.Name = "btnCreerCouche";
            this.btnCreerCouche.Size = new System.Drawing.Size(87, 32);
            this.btnCreerCouche.TabIndex = 38;
            this.btnCreerCouche.Text = "Créer";
            this.btnCreerCouche.UseVisualStyleBackColor = true;
            this.btnCreerCouche.Click += new System.EventHandler(this.CreerCouche);
            // 
            // CreateurCouche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Controls.Add(this.btnCreerCouche);
            this.Controls.Add(this.cbxCouche);
            this.Controls.Add(this.cbxMatiere);
            this.Controls.Add(this.lblMatiere);
            this.Controls.Add(this.lblLargeurSide);
            this.Controls.Add(this.nudLargeurCoucheSide);
            this.Controls.Add(this.lblHauteurSide);
            this.Controls.Add(this.nudHauterSide);
            this.Controls.Add(this.lblHauteurCenter);
            this.Controls.Add(this.nudHauteurCenter);
            this.Controls.Add(this.lblLargeurCenter);
            this.Controls.Add(this.nudLargeurCoucheCenter);
            this.Name = "CreateurCouche";
            this.Text = "CreateurCouche";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateurCouche_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCoucheSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauterSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauteurCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCoucheCenter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxMatiere;
        private System.Windows.Forms.Label lblMatiere;
        private System.Windows.Forms.Label lblLargeurSide;
        private System.Windows.Forms.NumericUpDown nudLargeurCoucheSide;
        private System.Windows.Forms.Label lblHauteurSide;
        private System.Windows.Forms.NumericUpDown nudHauterSide;
        private System.Windows.Forms.Label lblHauteurCenter;
        private System.Windows.Forms.NumericUpDown nudHauteurCenter;
        private System.Windows.Forms.Label lblLargeurCenter;
        private System.Windows.Forms.NumericUpDown nudLargeurCoucheCenter;
        private System.Windows.Forms.ComboBox cbxCouche;
        private System.Windows.Forms.Button btnCreerCouche;
    }
}
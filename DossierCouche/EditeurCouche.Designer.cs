namespace Flexion.DossierCouche
{
    partial class EditeurCouche
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
            this.btnModifierCouche = new System.Windows.Forms.Button();
            this.cbxCouche = new System.Windows.Forms.ComboBox();
            this.cbxMatiere = new System.Windows.Forms.ComboBox();
            this.lblMatiere = new System.Windows.Forms.Label();
            this.lblLargeurSide = new System.Windows.Forms.Label();
            this.nudLargeurCoucheSide = new System.Windows.Forms.NumericUpDown();
            this.lblHauteurSide = new System.Windows.Forms.Label();
            this.nudHauteurSide = new System.Windows.Forms.NumericUpDown();
            this.lblHauteurCenter = new System.Windows.Forms.Label();
            this.nudHauteurCenter = new System.Windows.Forms.NumericUpDown();
            this.lblLargeurCenter = new System.Windows.Forms.Label();
            this.nudLargeurCoucheCenter = new System.Windows.Forms.NumericUpDown();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCoucheSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauteurSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauteurCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCoucheCenter)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModifierCouche
            // 
            this.btnModifierCouche.Location = new System.Drawing.Point(122, 255);
            this.btnModifierCouche.Name = "btnModifierCouche";
            this.btnModifierCouche.Size = new System.Drawing.Size(87, 32);
            this.btnModifierCouche.TabIndex = 50;
            this.btnModifierCouche.Text = "Modifier";
            this.btnModifierCouche.UseVisualStyleBackColor = true;
            this.btnModifierCouche.Click += new System.EventHandler(this.ModifierCouche);
            // 
            // cbxCouche
            // 
            this.cbxCouche.FormattingEnabled = true;
            this.cbxCouche.Location = new System.Drawing.Point(12, 12);
            this.cbxCouche.Name = "cbxCouche";
            this.cbxCouche.Size = new System.Drawing.Size(325, 28);
            this.cbxCouche.TabIndex = 49;
            this.cbxCouche.SelectedIndexChanged += new System.EventHandler(this.AfficherCoucheSelectionne);
            // 
            // cbxMatiere
            // 
            this.cbxMatiere.FormattingEnabled = true;
            this.cbxMatiere.Location = new System.Drawing.Point(169, 219);
            this.cbxMatiere.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxMatiere.Name = "cbxMatiere";
            this.cbxMatiere.Size = new System.Drawing.Size(168, 28);
            this.cbxMatiere.TabIndex = 48;
            this.cbxMatiere.SelectedIndexChanged += new System.EventHandler(this.RemoveText);
            // 
            // lblMatiere
            // 
            this.lblMatiere.AutoSize = true;
            this.lblMatiere.Location = new System.Drawing.Point(8, 220);
            this.lblMatiere.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatiere.Name = "lblMatiere";
            this.lblMatiere.Size = new System.Drawing.Size(62, 20);
            this.lblMatiere.TabIndex = 47;
            this.lblMatiere.Text = "Matière";
            // 
            // lblLargeurSide
            // 
            this.lblLargeurSide.AutoSize = true;
            this.lblLargeurSide.Location = new System.Drawing.Point(8, 94);
            this.lblLargeurSide.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLargeurSide.Name = "lblLargeurSide";
            this.lblLargeurSide.Size = new System.Drawing.Size(139, 20);
            this.lblLargeurSide.TabIndex = 45;
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
            this.nudLargeurCoucheSide.TabIndex = 46;
            this.nudLargeurCoucheSide.ValueChanged += new System.EventHandler(this.RemoveText);
            // 
            // lblHauteurSide
            // 
            this.lblHauteurSide.AutoSize = true;
            this.lblHauteurSide.Location = new System.Drawing.Point(8, 179);
            this.lblHauteurSide.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHauteurSide.Name = "lblHauteurSide";
            this.lblHauteurSide.Size = new System.Drawing.Size(142, 20);
            this.lblHauteurSide.TabIndex = 43;
            this.lblHauteurSide.Text = "Hauteur côté (mm)";
            // 
            // nudHauteurSide
            // 
            this.nudHauteurSide.DecimalPlaces = 1;
            this.nudHauteurSide.Location = new System.Drawing.Point(169, 177);
            this.nudHauteurSide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudHauteurSide.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHauteurSide.Name = "nudHauteurSide";
            this.nudHauteurSide.Size = new System.Drawing.Size(168, 26);
            this.nudHauteurSide.TabIndex = 44;
            this.nudHauteurSide.ValueChanged += new System.EventHandler(this.RemoveText);
            // 
            // lblHauteurCenter
            // 
            this.lblHauteurCenter.AutoSize = true;
            this.lblHauteurCenter.Location = new System.Drawing.Point(8, 136);
            this.lblHauteurCenter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHauteurCenter.Name = "lblHauteurCenter";
            this.lblHauteurCenter.Size = new System.Drawing.Size(156, 20);
            this.lblHauteurCenter.TabIndex = 39;
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
            this.nudHauteurCenter.TabIndex = 40;
            this.nudHauteurCenter.ValueChanged += new System.EventHandler(this.RemoveText);
            // 
            // lblLargeurCenter
            // 
            this.lblLargeurCenter.AutoSize = true;
            this.lblLargeurCenter.Location = new System.Drawing.Point(8, 54);
            this.lblLargeurCenter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLargeurCenter.Name = "lblLargeurCenter";
            this.lblLargeurCenter.Size = new System.Drawing.Size(153, 20);
            this.lblLargeurCenter.TabIndex = 41;
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
            this.nudLargeurCoucheCenter.TabIndex = 42;
            this.nudLargeurCoucheCenter.ValueChanged += new System.EventHandler(this.RemoveText);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(118, 295);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 20);
            this.lblInfo.TabIndex = 51;
            // 
            // EditeurCouche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 324);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnModifierCouche);
            this.Controls.Add(this.cbxCouche);
            this.Controls.Add(this.cbxMatiere);
            this.Controls.Add(this.lblMatiere);
            this.Controls.Add(this.lblLargeurSide);
            this.Controls.Add(this.nudLargeurCoucheSide);
            this.Controls.Add(this.lblHauteurSide);
            this.Controls.Add(this.nudHauteurSide);
            this.Controls.Add(this.lblHauteurCenter);
            this.Controls.Add(this.nudHauteurCenter);
            this.Controls.Add(this.lblLargeurCenter);
            this.Controls.Add(this.nudLargeurCoucheCenter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditeurCouche";
            this.Text = "EditeurCouche";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorCouche_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCoucheSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauteurSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauteurCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCoucheCenter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModifierCouche;
        private System.Windows.Forms.ComboBox cbxCouche;
        private System.Windows.Forms.ComboBox cbxMatiere;
        private System.Windows.Forms.Label lblMatiere;
        private System.Windows.Forms.Label lblLargeurSide;
        private System.Windows.Forms.NumericUpDown nudLargeurCoucheSide;
        private System.Windows.Forms.Label lblHauteurSide;
        private System.Windows.Forms.NumericUpDown nudHauteurSide;
        private System.Windows.Forms.Label lblHauteurCenter;
        private System.Windows.Forms.NumericUpDown nudHauteurCenter;
        private System.Windows.Forms.Label lblLargeurCenter;
        private System.Windows.Forms.NumericUpDown nudLargeurCoucheCenter;
        private System.Windows.Forms.Label lblInfo;
    }
}
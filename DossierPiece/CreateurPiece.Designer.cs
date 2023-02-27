namespace Flexion
{
    partial class CreateurPiece
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
            this.cbxPieces = new System.Windows.Forms.ComboBox();
            this.tbxNomPiece = new System.Windows.Forms.TextBox();
            this.lblNomPiece = new System.Windows.Forms.Label();
            this.btnCreerPiece = new System.Windows.Forms.Button();
            this.lblLongueur = new System.Windows.Forms.Label();
            this.nudLongueurPiece = new System.Windows.Forms.NumericUpDown();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongueurPiece)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxPieces
            // 
            this.cbxPieces.FormattingEnabled = true;
            this.cbxPieces.Location = new System.Drawing.Point(12, 12);
            this.cbxPieces.Name = "cbxPieces";
            this.cbxPieces.Size = new System.Drawing.Size(288, 28);
            this.cbxPieces.TabIndex = 0;
            // 
            // tbxNomPiece
            // 
            this.tbxNomPiece.Location = new System.Drawing.Point(151, 117);
            this.tbxNomPiece.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxNomPiece.Name = "tbxNomPiece";
            this.tbxNomPiece.Size = new System.Drawing.Size(149, 26);
            this.tbxNomPiece.TabIndex = 27;
            this.tbxNomPiece.TextChanged += new System.EventHandler(this.RemoveText);
            // 
            // lblNomPiece
            // 
            this.lblNomPiece.AutoSize = true;
            this.lblNomPiece.Location = new System.Drawing.Point(8, 117);
            this.lblNomPiece.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomPiece.Name = "lblNomPiece";
            this.lblNomPiece.Size = new System.Drawing.Size(42, 20);
            this.lblNomPiece.TabIndex = 26;
            this.lblNomPiece.Text = "Nom";
            // 
            // btnCreerPiece
            // 
            this.btnCreerPiece.Location = new System.Drawing.Point(87, 160);
            this.btnCreerPiece.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreerPiece.Name = "btnCreerPiece";
            this.btnCreerPiece.Size = new System.Drawing.Size(105, 35);
            this.btnCreerPiece.TabIndex = 25;
            this.btnCreerPiece.Text = "Créer";
            this.btnCreerPiece.UseVisualStyleBackColor = true;
            this.btnCreerPiece.Click += new System.EventHandler(this.CreerPiece);
            // 
            // lblLongueur
            // 
            this.lblLongueur.AutoSize = true;
            this.lblLongueur.Location = new System.Drawing.Point(8, 66);
            this.lblLongueur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLongueur.Name = "lblLongueur";
            this.lblLongueur.Size = new System.Drawing.Size(117, 20);
            this.lblLongueur.TabIndex = 23;
            this.lblLongueur.Text = "Longueur (mm)";
            // 
            // nudLongueurPiece
            // 
            this.nudLongueurPiece.DecimalPlaces = 1;
            this.nudLongueurPiece.Location = new System.Drawing.Point(151, 63);
            this.nudLongueurPiece.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudLongueurPiece.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudLongueurPiece.Name = "nudLongueurPiece";
            this.nudLongueurPiece.Size = new System.Drawing.Size(149, 26);
            this.nudLongueurPiece.TabIndex = 24;
            this.nudLongueurPiece.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudLongueurPiece.ValueChanged += new System.EventHandler(this.RemoveText);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(83, 200);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 20);
            this.lblInfo.TabIndex = 41;
            // 
            // CreateurPiece
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 238);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.tbxNomPiece);
            this.Controls.Add(this.lblNomPiece);
            this.Controls.Add(this.btnCreerPiece);
            this.Controls.Add(this.lblLongueur);
            this.Controls.Add(this.nudLongueurPiece);
            this.Controls.Add(this.cbxPieces);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateurPiece";
            this.Text = "CreateurPiece";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateurPiece_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudLongueurPiece)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxPieces;
        private System.Windows.Forms.TextBox tbxNomPiece;
        private System.Windows.Forms.Label lblNomPiece;
        private System.Windows.Forms.Button btnCreerPiece;
        private System.Windows.Forms.Label lblLongueur;
        private System.Windows.Forms.NumericUpDown nudLongueurPiece;
        private System.Windows.Forms.Label lblInfo;
    }
}
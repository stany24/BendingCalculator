namespace Flexion
{
    partial class EditeurPiece
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
            this.tbxNomPiece = new System.Windows.Forms.TextBox();
            this.lblNomPiece = new System.Windows.Forms.Label();
            this.btnModiferPiece = new System.Windows.Forms.Button();
            this.lblLongueur = new System.Windows.Forms.Label();
            this.nudLongueurPiece = new System.Windows.Forms.NumericUpDown();
            this.cbxPieces = new System.Windows.Forms.ComboBox();
            this.lbxCoucheIn = new System.Windows.Forms.ListBox();
            this.lbxCoucheOut = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCoucheDown = new System.Windows.Forms.Button();
            this.btnCoucheUp = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongueurPiece)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxNomPiece
            // 
            this.tbxNomPiece.Location = new System.Drawing.Point(151, 117);
            this.tbxNomPiece.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxNomPiece.Name = "tbxNomPiece";
            this.tbxNomPiece.Size = new System.Drawing.Size(149, 26);
            this.tbxNomPiece.TabIndex = 33;
            // 
            // lblNomPiece
            // 
            this.lblNomPiece.AutoSize = true;
            this.lblNomPiece.Location = new System.Drawing.Point(8, 117);
            this.lblNomPiece.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomPiece.Name = "lblNomPiece";
            this.lblNomPiece.Size = new System.Drawing.Size(42, 20);
            this.lblNomPiece.TabIndex = 32;
            this.lblNomPiece.Text = "Nom";
            // 
            // btnModiferPiece
            // 
            this.btnModiferPiece.Location = new System.Drawing.Point(485, 324);
            this.btnModiferPiece.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModiferPiece.Name = "btnModiferPiece";
            this.btnModiferPiece.Size = new System.Drawing.Size(105, 35);
            this.btnModiferPiece.TabIndex = 31;
            this.btnModiferPiece.Text = "-->";
            this.btnModiferPiece.UseVisualStyleBackColor = true;
            this.btnModiferPiece.Click += new System.EventHandler(this.DeplacerADroite);
            // 
            // lblLongueur
            // 
            this.lblLongueur.AutoSize = true;
            this.lblLongueur.Location = new System.Drawing.Point(8, 66);
            this.lblLongueur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLongueur.Name = "lblLongueur";
            this.lblLongueur.Size = new System.Drawing.Size(117, 20);
            this.lblLongueur.TabIndex = 29;
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
            this.nudLongueurPiece.TabIndex = 30;
            this.nudLongueurPiece.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // cbxPieces
            // 
            this.cbxPieces.FormattingEnabled = true;
            this.cbxPieces.Location = new System.Drawing.Point(12, 12);
            this.cbxPieces.Name = "cbxPieces";
            this.cbxPieces.Size = new System.Drawing.Size(288, 28);
            this.cbxPieces.TabIndex = 28;
            this.cbxPieces.SelectedIndexChanged += new System.EventHandler(this.AfficherPieceSelectionee);
            // 
            // lbxCoucheIn
            // 
            this.lbxCoucheIn.FormattingEnabled = true;
            this.lbxCoucheIn.ItemHeight = 20;
            this.lbxCoucheIn.Location = new System.Drawing.Point(307, 12);
            this.lbxCoucheIn.Name = "lbxCoucheIn";
            this.lbxCoucheIn.Size = new System.Drawing.Size(228, 304);
            this.lbxCoucheIn.TabIndex = 34;
            // 
            // lbxCoucheOut
            // 
            this.lbxCoucheOut.FormattingEnabled = true;
            this.lbxCoucheOut.ItemHeight = 20;
            this.lbxCoucheOut.Location = new System.Drawing.Point(541, 12);
            this.lbxCoucheOut.Name = "lbxCoucheOut";
            this.lbxCoucheOut.Size = new System.Drawing.Size(228, 304);
            this.lbxCoucheOut.TabIndex = 35;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(485, 369);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 35);
            this.button1.TabIndex = 36;
            this.button1.Text = "<--";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DeplacerAGauche);
            // 
            // btnCoucheDown
            // 
            this.btnCoucheDown.Location = new System.Drawing.Point(360, 369);
            this.btnCoucheDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCoucheDown.Name = "btnCoucheDown";
            this.btnCoucheDown.Size = new System.Drawing.Size(105, 35);
            this.btnCoucheDown.TabIndex = 38;
            this.btnCoucheDown.Text = "Down";
            this.btnCoucheDown.UseVisualStyleBackColor = true;
            this.btnCoucheDown.Click += new System.EventHandler(this.DeplacerCoucheBas);
            // 
            // btnCoucheUp
            // 
            this.btnCoucheUp.Location = new System.Drawing.Point(360, 324);
            this.btnCoucheUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCoucheUp.Name = "btnCoucheUp";
            this.btnCoucheUp.Size = new System.Drawing.Size(105, 35);
            this.btnCoucheUp.TabIndex = 37;
            this.btnCoucheUp.Text = "Up";
            this.btnCoucheUp.UseVisualStyleBackColor = true;
            this.btnCoucheUp.Click += new System.EventHandler(this.DeplacerCoucheHaut);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 166);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 35);
            this.button2.TabIndex = 39;
            this.button2.Text = "Appliquer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ModifierPiece);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(110, 206);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 20);
            this.lblInfo.TabIndex = 40;
            // 
            // EditeurPiece
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCoucheDown);
            this.Controls.Add(this.btnCoucheUp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbxCoucheOut);
            this.Controls.Add(this.lbxCoucheIn);
            this.Controls.Add(this.tbxNomPiece);
            this.Controls.Add(this.lblNomPiece);
            this.Controls.Add(this.btnModiferPiece);
            this.Controls.Add(this.lblLongueur);
            this.Controls.Add(this.nudLongueurPiece);
            this.Controls.Add(this.cbxPieces);
            this.Name = "EditeurPiece";
            this.Text = "EditeurPiece";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditeurPiece_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudLongueurPiece)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxNomPiece;
        private System.Windows.Forms.Label lblNomPiece;
        private System.Windows.Forms.Button btnModiferPiece;
        private System.Windows.Forms.Label lblLongueur;
        private System.Windows.Forms.NumericUpDown nudLongueurPiece;
        private System.Windows.Forms.ComboBox cbxPieces;
        private System.Windows.Forms.ListBox lbxCoucheIn;
        private System.Windows.Forms.ListBox lbxCoucheOut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCoucheDown;
        private System.Windows.Forms.Button btnCoucheUp;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblInfo;
    }
}
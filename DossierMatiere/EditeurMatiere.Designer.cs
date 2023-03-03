namespace Flexion
{
    partial class EditeurMatiere
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
            this.cbxMatieres = new System.Windows.Forms.ComboBox();
            this.tbxNomMatiere = new System.Windows.Forms.TextBox();
            this.lblNomMatiere = new System.Windows.Forms.Label();
            this.nudE = new System.Windows.Forms.NumericUpDown();
            this.lblE = new System.Windows.Forms.Label();
            this.btnModifier = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudE)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxMatieres
            // 
            this.cbxMatieres.FormattingEnabled = true;
            this.cbxMatieres.Location = new System.Drawing.Point(12, 12);
            this.cbxMatieres.Name = "cbxMatieres";
            this.cbxMatieres.Size = new System.Drawing.Size(329, 28);
            this.cbxMatieres.TabIndex = 0;
            this.cbxMatieres.SelectedIndexChanged += new System.EventHandler(this.AfficherMatiereSelectionne);
            // 
            // tbxNomMatiere
            // 
            this.tbxNomMatiere.Location = new System.Drawing.Point(213, 66);
            this.tbxNomMatiere.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxNomMatiere.Name = "tbxNomMatiere";
            this.tbxNomMatiere.Size = new System.Drawing.Size(126, 26);
            this.tbxNomMatiere.TabIndex = 25;
            this.tbxNomMatiere.TextChanged += new System.EventHandler(this.RemoveText);
            // 
            // lblNomMatiere
            // 
            this.lblNomMatiere.AutoSize = true;
            this.lblNomMatiere.Location = new System.Drawing.Point(18, 60);
            this.lblNomMatiere.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomMatiere.Name = "lblNomMatiere";
            this.lblNomMatiere.Size = new System.Drawing.Size(42, 20);
            this.lblNomMatiere.TabIndex = 24;
            this.lblNomMatiere.Text = "Nom";
            // 
            // nudE
            // 
            this.nudE.DecimalPlaces = 3;
            this.nudE.Location = new System.Drawing.Point(213, 106);
            this.nudE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudE.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudE.Name = "nudE";
            this.nudE.Size = new System.Drawing.Size(128, 26);
            this.nudE.TabIndex = 23;
            this.nudE.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudE.ValueChanged += new System.EventHandler(this.RemoveText);
            // 
            // lblE
            // 
            this.lblE.AutoSize = true;
            this.lblE.Location = new System.Drawing.Point(18, 109);
            this.lblE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblE.Name = "lblE";
            this.lblE.Size = new System.Drawing.Size(185, 20);
            this.lblE.TabIndex = 22;
            this.lblE.Text = "Module d\'élasticité (GPa)";
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(128, 161);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(85, 32);
            this.btnModifier.TabIndex = 26;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.ModifierMatiere);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(124, 204);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 20);
            this.lblInfo.TabIndex = 27;
            // 
            // EditeurMatiere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 233);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.tbxNomMatiere);
            this.Controls.Add(this.lblNomMatiere);
            this.Controls.Add(this.nudE);
            this.Controls.Add(this.lblE);
            this.Controls.Add(this.cbxMatieres);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditeurMatiere";
            this.Text = "Editeur matière";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditeurMatiere_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxMatieres;
        private System.Windows.Forms.TextBox tbxNomMatiere;
        private System.Windows.Forms.Label lblNomMatiere;
        private System.Windows.Forms.NumericUpDown nudE;
        private System.Windows.Forms.Label lblE;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Label lblInfo;
    }
}
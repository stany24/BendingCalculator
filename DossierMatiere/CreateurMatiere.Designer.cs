namespace Flexion
{
    partial class CreateurMatiere
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
            this.btnCreer = new System.Windows.Forms.Button();
            this.tbxNomMatiere = new System.Windows.Forms.TextBox();
            this.lblNomMatiere = new System.Windows.Forms.Label();
            this.nudE = new System.Windows.Forms.NumericUpDown();
            this.lblE = new System.Windows.Forms.Label();
            this.cbxMatieres = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudE)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreer
            // 
            this.btnCreer.Location = new System.Drawing.Point(128, 149);
            this.btnCreer.Name = "btnCreer";
            this.btnCreer.Size = new System.Drawing.Size(85, 32);
            this.btnCreer.TabIndex = 34;
            this.btnCreer.Text = "Créer";
            this.btnCreer.UseVisualStyleBackColor = true;
            this.btnCreer.Click += new System.EventHandler(this.btnCreer_Click);
            // 
            // tbxNomMatiere
            // 
            this.tbxNomMatiere.Location = new System.Drawing.Point(213, 66);
            this.tbxNomMatiere.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxNomMatiere.Name = "tbxNomMatiere";
            this.tbxNomMatiere.Size = new System.Drawing.Size(126, 26);
            this.tbxNomMatiere.TabIndex = 32;
            // 
            // lblNomMatiere
            // 
            this.lblNomMatiere.AutoSize = true;
            this.lblNomMatiere.Location = new System.Drawing.Point(18, 60);
            this.lblNomMatiere.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomMatiere.Name = "lblNomMatiere";
            this.lblNomMatiere.Size = new System.Drawing.Size(42, 20);
            this.lblNomMatiere.TabIndex = 31;
            this.lblNomMatiere.Text = "Nom";
            // 
            // nudE
            // 
            this.nudE.DecimalPlaces = 1;
            this.nudE.Location = new System.Drawing.Point(213, 106);
            this.nudE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudE.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudE.Name = "nudE";
            this.nudE.Size = new System.Drawing.Size(128, 26);
            this.nudE.TabIndex = 30;
            // 
            // lblE
            // 
            this.lblE.AutoSize = true;
            this.lblE.Location = new System.Drawing.Point(18, 109);
            this.lblE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblE.Name = "lblE";
            this.lblE.Size = new System.Drawing.Size(185, 20);
            this.lblE.TabIndex = 29;
            this.lblE.Text = "Module d\'élasticité (GPa)";
            // 
            // cbxMatieres
            // 
            this.cbxMatieres.FormattingEnabled = true;
            this.cbxMatieres.Location = new System.Drawing.Point(12, 12);
            this.cbxMatieres.Name = "cbxMatieres";
            this.cbxMatieres.Size = new System.Drawing.Size(329, 28);
            this.cbxMatieres.TabIndex = 28;
            // 
            // CreateurMatiere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 192);
            this.Controls.Add(this.btnCreer);
            this.Controls.Add(this.tbxNomMatiere);
            this.Controls.Add(this.lblNomMatiere);
            this.Controls.Add(this.nudE);
            this.Controls.Add(this.lblE);
            this.Controls.Add(this.cbxMatieres);
            this.Name = "CreateurMatiere";
            this.Text = "Création de matières";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateurMatiere_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreer;
        private System.Windows.Forms.TextBox tbxNomMatiere;
        private System.Windows.Forms.Label lblNomMatiere;
        private System.Windows.Forms.NumericUpDown nudE;
        private System.Windows.Forms.Label lblE;
        private System.Windows.Forms.ComboBox cbxMatieres;
    }
}
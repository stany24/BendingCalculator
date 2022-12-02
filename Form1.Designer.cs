
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
            this.lblForce = new System.Windows.Forms.Label();
            this.lblDeformation = new System.Windows.Forms.Label();
            this.tbxFlexion = new System.Windows.Forms.TextBox();
            this.nudForce = new System.Windows.Forms.NumericUpDown();
            this.nudDeformation = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblLongueur = new System.Windows.Forms.Label();
            this.nudHauteurCouche = new System.Windows.Forms.NumericUpDown();
            this.lblHauteur = new System.Windows.Forms.Label();
            this.nudLargeurCouche = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbxCouche = new System.Windows.Forms.ListBox();
            this.btnAjouterCouche = new System.Windows.Forms.Button();
            this.gbxMatiere = new System.Windows.Forms.GroupBox();
            this.tbxNomMatiere = new System.Windows.Forms.TextBox();
            this.lblNomMatiere = new System.Windows.Forms.Label();
            this.nudE = new System.Windows.Forms.NumericUpDown();
            this.lbxMatiere = new System.Windows.Forms.ListBox();
            this.lblE = new System.Windows.Forms.Label();
            this.btnAjouterMatiere = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauteurCouche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCouche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbxMatiere.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudE)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblForce
            // 
            this.lblForce.AutoSize = true;
            this.lblForce.Location = new System.Drawing.Point(12, 42);
            this.lblForce.Name = "lblForce";
            this.lblForce.Size = new System.Drawing.Size(51, 13);
            this.lblForce.TabIndex = 0;
            this.lblForce.Text = "Force (N)";
            // 
            // lblDeformation
            // 
            this.lblDeformation.AutoSize = true;
            this.lblDeformation.Location = new System.Drawing.Point(13, 72);
            this.lblDeformation.Name = "lblDeformation";
            this.lblDeformation.Size = new System.Drawing.Size(87, 13);
            this.lblDeformation.TabIndex = 2;
            this.lblDeformation.Text = "Déformation (cm)";
            // 
            // tbxFlexion
            // 
            this.tbxFlexion.Location = new System.Drawing.Point(49, 362);
            this.tbxFlexion.Name = "tbxFlexion";
            this.tbxFlexion.ReadOnly = true;
            this.tbxFlexion.Size = new System.Drawing.Size(155, 20);
            this.tbxFlexion.TabIndex = 4;
            // 
            // nudForce
            // 
            this.nudForce.DecimalPlaces = 1;
            this.nudForce.Location = new System.Drawing.Point(125, 40);
            this.nudForce.Name = "nudForce";
            this.nudForce.Size = new System.Drawing.Size(120, 20);
            this.nudForce.TabIndex = 5;
            // 
            // nudDeformation
            // 
            this.nudDeformation.DecimalPlaces = 1;
            this.nudDeformation.Location = new System.Drawing.Point(126, 70);
            this.nudDeformation.Name = "nudDeformation";
            this.nudDeformation.Size = new System.Drawing.Size(120, 20);
            this.nudDeformation.TabIndex = 6;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Location = new System.Drawing.Point(126, 103);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 8;
            // 
            // lblLongueur
            // 
            this.lblLongueur.AutoSize = true;
            this.lblLongueur.Location = new System.Drawing.Point(13, 105);
            this.lblLongueur.Name = "lblLongueur";
            this.lblLongueur.Size = new System.Drawing.Size(75, 13);
            this.lblLongueur.TabIndex = 7;
            this.lblLongueur.Text = "Longueur (cm)";
            // 
            // nudHauteurCouche
            // 
            this.nudHauteurCouche.DecimalPlaces = 1;
            this.nudHauteurCouche.Location = new System.Drawing.Point(90, 33);
            this.nudHauteurCouche.Name = "nudHauteurCouche";
            this.nudHauteurCouche.Size = new System.Drawing.Size(131, 20);
            this.nudHauteurCouche.TabIndex = 10;
            // 
            // lblHauteur
            // 
            this.lblHauteur.AutoSize = true;
            this.lblHauteur.Location = new System.Drawing.Point(6, 35);
            this.lblHauteur.Name = "lblHauteur";
            this.lblHauteur.Size = new System.Drawing.Size(68, 13);
            this.lblHauteur.TabIndex = 9;
            this.lblHauteur.Text = "Hauteur (cm)";
            // 
            // nudLargeurCouche
            // 
            this.nudLargeurCouche.DecimalPlaces = 1;
            this.nudLargeurCouche.Location = new System.Drawing.Point(90, 63);
            this.nudLargeurCouche.Name = "nudLargeurCouche";
            this.nudLargeurCouche.Size = new System.Drawing.Size(131, 20);
            this.nudLargeurCouche.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Largeur (cm)";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(125, 193);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown4.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nombre de matériaux";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(49, 237);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbxCouche);
            this.groupBox1.Controls.Add(this.btnAjouterCouche);
            this.groupBox1.Controls.Add(this.lblHauteur);
            this.groupBox1.Controls.Add(this.nudHauteurCouche);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudLargeurCouche);
            this.groupBox1.Location = new System.Drawing.Point(641, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 375);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Couche";
            // 
            // lbxCouche
            // 
            this.lbxCouche.FormattingEnabled = true;
            this.lbxCouche.Location = new System.Drawing.Point(9, 172);
            this.lbxCouche.Name = "lbxCouche";
            this.lbxCouche.Size = new System.Drawing.Size(176, 173);
            this.lbxCouche.TabIndex = 14;
            // 
            // btnAjouterCouche
            // 
            this.btnAjouterCouche.Location = new System.Drawing.Point(81, 123);
            this.btnAjouterCouche.Name = "btnAjouterCouche";
            this.btnAjouterCouche.Size = new System.Drawing.Size(75, 23);
            this.btnAjouterCouche.TabIndex = 13;
            this.btnAjouterCouche.Text = "Ajouter couche";
            this.btnAjouterCouche.UseVisualStyleBackColor = true;
            this.btnAjouterCouche.Click += new System.EventHandler(this.btnAjouterCouche_Click);
            // 
            // gbxMatiere
            // 
            this.gbxMatiere.Controls.Add(this.tbxNomMatiere);
            this.gbxMatiere.Controls.Add(this.lblNomMatiere);
            this.gbxMatiere.Controls.Add(this.nudE);
            this.gbxMatiere.Controls.Add(this.lbxMatiere);
            this.gbxMatiere.Controls.Add(this.lblE);
            this.gbxMatiere.Controls.Add(this.btnAjouterMatiere);
            this.gbxMatiere.Location = new System.Drawing.Point(361, 21);
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
            this.nudE.Name = "nudE";
            this.nudE.Size = new System.Drawing.Size(100, 20);
            this.nudE.TabIndex = 19;
            // 
            // lbxMatiere
            // 
            this.lbxMatiere.FormattingEnabled = true;
            this.lbxMatiere.Location = new System.Drawing.Point(9, 172);
            this.lbxMatiere.Name = "lbxMatiere";
            this.lbxMatiere.Size = new System.Drawing.Size(176, 173);
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
            // btnAjouterMatiere
            // 
            this.btnAjouterMatiere.Location = new System.Drawing.Point(81, 123);
            this.btnAjouterMatiere.Name = "btnAjouterMatiere";
            this.btnAjouterMatiere.Size = new System.Drawing.Size(75, 23);
            this.btnAjouterMatiere.TabIndex = 13;
            this.btnAjouterMatiere.Text = "Ajouter couche";
            this.btnAjouterMatiere.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(915, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 375);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Piece";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 172);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(176, 173);
            this.listBox1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Ajouter couche";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxMatiere);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblLongueur);
            this.Controls.Add(this.nudDeformation);
            this.Controls.Add(this.nudForce);
            this.Controls.Add(this.tbxFlexion);
            this.Controls.Add(this.lblDeformation);
            this.Controls.Add(this.lblForce);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Flexion TIP";
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHauteurCouche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargeurCouche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxMatiere.ResumeLayout(false);
            this.gbxMatiere.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudE)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblForce;
        private System.Windows.Forms.Label lblDeformation;
        private System.Windows.Forms.TextBox tbxFlexion;
        private System.Windows.Forms.NumericUpDown nudForce;
        private System.Windows.Forms.NumericUpDown nudDeformation;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblLongueur;
        private System.Windows.Forms.NumericUpDown nudHauteurCouche;
        private System.Windows.Forms.Label lblHauteur;
        private System.Windows.Forms.NumericUpDown nudLargeurCouche;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAjouterCouche;
        private System.Windows.Forms.ListBox lbxCouche;
        private System.Windows.Forms.GroupBox gbxMatiere;
        private System.Windows.Forms.TextBox tbxNomMatiere;
        private System.Windows.Forms.Label lblNomMatiere;
        private System.Windows.Forms.NumericUpDown nudE;
        private System.Windows.Forms.ListBox lbxMatiere;
        private System.Windows.Forms.Label lblE;
        private System.Windows.Forms.Button btnAjouterMatiere;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
    }
}


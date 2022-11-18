
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
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeformation)).BeginInit();
            this.SuspendLayout();
            // 
            // lblForce
            // 
            this.lblForce.AutoSize = true;
            this.lblForce.Location = new System.Drawing.Point(13, 32);
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
            this.tbxFlexion.Location = new System.Drawing.Point(51, 133);
            this.tbxFlexion.Name = "tbxFlexion";
            this.tbxFlexion.ReadOnly = true;
            this.tbxFlexion.Size = new System.Drawing.Size(155, 20);
            this.tbxFlexion.TabIndex = 4;
            // 
            // nudForce
            // 
            this.nudForce.DecimalPlaces = 1;
            this.nudForce.Location = new System.Drawing.Point(106, 30);
            this.nudForce.Name = "nudForce";
            this.nudForce.Size = new System.Drawing.Size(120, 20);
            this.nudForce.TabIndex = 5;
            this.nudForce.ValueChanged += new System.EventHandler(this.nudForce_ValueChanged);
            // 
            // nudDeformation
            // 
            this.nudDeformation.DecimalPlaces = 1;
            this.nudDeformation.Location = new System.Drawing.Point(106, 70);
            this.nudDeformation.Name = "nudDeformation";
            this.nudDeformation.Size = new System.Drawing.Size(120, 20);
            this.nudDeformation.TabIndex = 6;
            this.nudDeformation.ValueChanged += new System.EventHandler(this.nudDeformation_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblForce;
        private System.Windows.Forms.Label lblDeformation;
        private System.Windows.Forms.TextBox tbxFlexion;
        private System.Windows.Forms.NumericUpDown nudForce;
        private System.Windows.Forms.NumericUpDown nudDeformation;
    }
}


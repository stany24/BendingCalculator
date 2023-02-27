namespace Flexion
{
    partial class CalculeForce
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
            this.nudForce = new System.Windows.Forms.NumericUpDown();
            this.nudMasse = new System.Windows.Forms.NumericUpDown();
            this.lblForce = new System.Windows.Forms.Label();
            this.lblMasse = new System.Windows.Forms.Label();
            this.lblGravité = new System.Windows.Forms.Label();
            this.nudRayon = new System.Windows.Forms.NumericUpDown();
            this.nudGravite = new System.Windows.Forms.NumericUpDown();
            this.lblRayon = new System.Windows.Forms.Label();
            this.lblVitesse = new System.Windows.Forms.Label();
            this.nudVitesse = new System.Windows.Forms.NumericUpDown();
            this.btnModifier = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRayon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitesse)).BeginInit();
            this.SuspendLayout();
            // 
            // nudForce
            // 
            this.nudForce.DecimalPlaces = 1;
            this.nudForce.Location = new System.Drawing.Point(182, 218);
            this.nudForce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudForce.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudForce.Name = "nudForce";
            this.nudForce.Size = new System.Drawing.Size(180, 26);
            this.nudForce.TabIndex = 46;
            this.nudForce.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // nudMasse
            // 
            this.nudMasse.DecimalPlaces = 2;
            this.nudMasse.Location = new System.Drawing.Point(182, 14);
            this.nudMasse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMasse.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudMasse.Name = "nudMasse";
            this.nudMasse.Size = new System.Drawing.Size(180, 26);
            this.nudMasse.TabIndex = 54;
            this.nudMasse.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nudMasse.ValueChanged += new System.EventHandler(this.CalcuateF);
            // 
            // lblForce
            // 
            this.lblForce.AutoSize = true;
            this.lblForce.Location = new System.Drawing.Point(12, 221);
            this.lblForce.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForce.Name = "lblForce";
            this.lblForce.Size = new System.Drawing.Size(75, 20);
            this.lblForce.TabIndex = 45;
            this.lblForce.Text = "Force (N)";
            // 
            // lblMasse
            // 
            this.lblMasse.AutoSize = true;
            this.lblMasse.Location = new System.Drawing.Point(12, 18);
            this.lblMasse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMasse.Name = "lblMasse";
            this.lblMasse.Size = new System.Drawing.Size(87, 20);
            this.lblMasse.TabIndex = 53;
            this.lblMasse.Text = "Masse (kg)";
            // 
            // lblGravité
            // 
            this.lblGravité.AutoSize = true;
            this.lblGravité.Location = new System.Drawing.Point(12, 170);
            this.lblGravité.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGravité.Name = "lblGravité";
            this.lblGravité.Size = new System.Drawing.Size(85, 20);
            this.lblGravité.TabIndex = 47;
            this.lblGravité.Text = "Gravité (N)";
            // 
            // nudRayon
            // 
            this.nudRayon.DecimalPlaces = 2;
            this.nudRayon.Location = new System.Drawing.Point(182, 65);
            this.nudRayon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudRayon.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudRayon.Name = "nudRayon";
            this.nudRayon.Size = new System.Drawing.Size(180, 26);
            this.nudRayon.TabIndex = 52;
            this.nudRayon.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.nudRayon.ValueChanged += new System.EventHandler(this.CalcuateF);
            // 
            // nudGravite
            // 
            this.nudGravite.DecimalPlaces = 2;
            this.nudGravite.Location = new System.Drawing.Point(182, 167);
            this.nudGravite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudGravite.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudGravite.Name = "nudGravite";
            this.nudGravite.Size = new System.Drawing.Size(180, 26);
            this.nudGravite.TabIndex = 48;
            this.nudGravite.Value = new decimal(new int[] {
            981,
            0,
            0,
            131072});
            this.nudGravite.ValueChanged += new System.EventHandler(this.CalcuateF);
            // 
            // lblRayon
            // 
            this.lblRayon.AutoSize = true;
            this.lblRayon.Location = new System.Drawing.Point(12, 68);
            this.lblRayon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRayon.Name = "lblRayon";
            this.lblRayon.Size = new System.Drawing.Size(82, 20);
            this.lblRayon.TabIndex = 51;
            this.lblRayon.Text = "Rayon (m)";
            // 
            // lblVitesse
            // 
            this.lblVitesse.AutoSize = true;
            this.lblVitesse.Location = new System.Drawing.Point(12, 119);
            this.lblVitesse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVitesse.Name = "lblVitesse";
            this.lblVitesse.Size = new System.Drawing.Size(101, 20);
            this.lblVitesse.TabIndex = 49;
            this.lblVitesse.Text = "Vitesse (m/s)";
            // 
            // nudVitesse
            // 
            this.nudVitesse.DecimalPlaces = 2;
            this.nudVitesse.Location = new System.Drawing.Point(182, 116);
            this.nudVitesse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudVitesse.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudVitesse.Name = "nudVitesse";
            this.nudVitesse.Size = new System.Drawing.Size(180, 26);
            this.nudVitesse.TabIndex = 50;
            this.nudVitesse.Value = new decimal(new int[] {
            1666,
            0,
            0,
            131072});
            this.nudVitesse.ValueChanged += new System.EventHandler(this.CalcuateF);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(140, 252);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(88, 32);
            this.btnModifier.TabIndex = 55;
            this.btnModifier.Text = "Appliquer";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.ModifierForce);
            // 
            // CalculeForce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 300);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.nudForce);
            this.Controls.Add(this.nudMasse);
            this.Controls.Add(this.lblForce);
            this.Controls.Add(this.lblMasse);
            this.Controls.Add(this.lblGravité);
            this.Controls.Add(this.nudRayon);
            this.Controls.Add(this.nudGravite);
            this.Controls.Add(this.lblRayon);
            this.Controls.Add(this.lblVitesse);
            this.Controls.Add(this.nudVitesse);
            this.Name = "CalculeForce";
            this.Text = "CalculeForce";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalculerForce_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRayon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitesse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudForce;
        private System.Windows.Forms.NumericUpDown nudMasse;
        private System.Windows.Forms.Label lblForce;
        private System.Windows.Forms.Label lblMasse;
        private System.Windows.Forms.Label lblGravité;
        private System.Windows.Forms.NumericUpDown nudRayon;
        private System.Windows.Forms.NumericUpDown nudGravite;
        private System.Windows.Forms.Label lblRayon;
        private System.Windows.Forms.Label lblVitesse;
        private System.Windows.Forms.NumericUpDown nudVitesse;
        private System.Windows.Forms.Button btnModifier;
    }
}
using System;
using System.Windows.Forms;

namespace Flexion
{
    public partial class CalculeForce : Form
    {
        public CalculeForce()
        {
            InitializeComponent();
        }
        public void CalcuateF(object sender, EventArgs e)
        {
            double m = (double)nudMasse.Value;
            double r = (double)nudRayon.Value;
            double v = (double)nudVitesse.Value;
            double g = (double)nudGravite.Value;
            nudForce.Value = Convert.ToInt32(m * Math.Sqrt(Math.Pow(g, 2) + (Math.Pow(v, 4) / Math.Pow(r, 2))));
        }

        private void ModifierForce(object sender, EventArgs e)
        {
            Sauvegarde.SetForce((int)nudForce.Value);
        }
    }
}

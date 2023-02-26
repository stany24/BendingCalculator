using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flexion
{
    public partial class CalculeForce : Form
    {
        Form1 Main;
        public CalculeForce(Form1 form)
        {
            InitializeComponent();
            Main = form;
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
            Main.Force = (double)nudForce.Value;
        }
    }
}

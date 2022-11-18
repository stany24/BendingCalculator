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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string CalculateFlexion(decimal force,decimal deformation)
        {
            try
            {
                double dForce = Convert.ToDouble(force);
                double dDeformation = Convert.ToDouble(deformation);
                return Convert.ToString(dForce * dDeformation*0.01);
            }
            catch{return "Veuillez entrez deux nombres";}
        }

        private void nudForce_ValueChanged(object sender, EventArgs e)
        {
            tbxFlexion.Text = CalculateFlexion(nudForce.Value, nudDeformation.Value);
        }

        private void nudDeformation_ValueChanged(object sender, EventArgs e)
        {
            tbxFlexion.Text = CalculateFlexion(nudForce.Value, nudDeformation.Value);
        }
    }
}

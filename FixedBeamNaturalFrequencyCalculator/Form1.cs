using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FixedBeamNaturalFrequencyCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double fn = 0;
        double fnCM = 0;
        double fnCM2 = 0;
        double[] knArray = { 22.4, 61.7, 121, 200, 299 };
        double[] ResultArray = new double[5];

        private void btnCalculateFixed_Click(object sender, EventArgs e)
        {
            double elasticity;
            double inertia;
            double beamLength;
            double w;
            double m;
            int j = 0;
            double g = 9806.0;
            double.TryParse(txtElFixed.Text, out elasticity);
            double.TryParse(txtInFixed.Text, out inertia);
            double.TryParse(txtBeamFixed.Text, out beamLength);
            double.TryParse(txtWFixed.Text, out w);
            double.TryParse(txtMFixed.Text, out m);
            if (txtElFixed.Text == "" || txtInFixed.Text == "" || txtBeamFixed.Text == "" || txtWFixed.Text == "" || txtMFixed.Text == "")
            {
                MessageBox.Show("Please enter values!", "Warning!");
            }
            else
            {
                foreach (double kn in knArray)
                {
                    fn = ((kn / (2.0 * Math.PI)) * Math.Sqrt((elasticity * inertia * g * 1000) / (w * Math.Pow(beamLength, 4))));
                    fn = Math.Round(fn, 2);
                    ResultArray[j] = fn;
                    j += 1;
                }
                lbRsCant1.Text = Convert.ToString(ResultArray[0]);
                lbRsCant2.Text = Convert.ToString(ResultArray[1]);
                lbRsCant3.Text = Convert.ToString(ResultArray[2]);
                lbRsCant4.Text = Convert.ToString(ResultArray[3]);
                lbRsCant5.Text = Convert.ToString(ResultArray[4]);
                lbRsCant1.TextAlign = ContentAlignment.MiddleLeft;
                lbRsCant2.TextAlign = ContentAlignment.MiddleLeft;
                lbRsCant3.TextAlign = ContentAlignment.MiddleLeft;
                lbRsCant4.TextAlign = ContentAlignment.MiddleLeft;
                lbRsCant5.TextAlign = ContentAlignment.MiddleLeft;
                lbRsCant1.Anchor = AnchorStyles.Left;
                lbRsCant2.Anchor = AnchorStyles.Left;
                lbRsCant3.Anchor = AnchorStyles.Left;
                lbRsCant4.Anchor = AnchorStyles.Left;
                lbRsCant5.Anchor = AnchorStyles.Left;

                hz1.Visible = true;
                hz2.Visible = true;
                hz3.Visible = true;
                hz4.Visible = true;
                hz5.Visible = true;
                hz6.Visible = true;
                hz7.Visible = true;
                fnCM = ((13.86 / (2.0 * Math.PI)) * Math.Sqrt((elasticity * inertia * g * 1000) / (m * Math.Pow(beamLength, 3))));
                fnCM = Math.Round(fnCM, 2);
                lbCenterLoad.Text = Convert.ToString(fnCM);
                fnCM2 = ((13.86 / (2.0 * Math.PI)) * Math.Sqrt((elasticity * inertia * g * 1000) / ((0.383 * w * Math.Pow(beamLength, 4)) +(m * Math.Pow(beamLength, 3)))));
                fnCM2 = Math.Round(fnCM2, 2);
                lbCenterLoad2.Text = Convert.ToString(fnCM2);
                lbCenterLoad.Visible = true;
                lbCenterLoad2.Visible = true;


            }

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtWFixed.Text = "";
            txtBeamFixed.Text = "";
            txtInFixed.Text = "";
            txtElFixed.Text = "";
            txtMFixed.Text = "";

            hz1.Visible = false;
            hz2.Visible = false;
            hz3.Visible = false;
            hz4.Visible = false;
            hz5.Visible = false;
            hz6.Visible = false;
            hz7.Visible = false;
            lbRsCant1.Text = "";
            lbRsCant2.Text = "";
            lbRsCant3.Text = "";
            lbRsCant4.Text = "";
            lbRsCant5.Text = "";
            lbCenterLoad.Text = "";
            lbCenterLoad2.Text = "";

        }

        private void txtElFixed_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txtElFixed.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtElFixed.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (txtElFixed.Text.StartsWith("0") && !txtElFixed.Text.StartsWith("0.") && e.KeyChar != '\b' && e.KeyChar != (int)'.')
            {
                e.Handled = true;
            }
        }

        private void txtInFixed_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txtInFixed.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtInFixed.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (txtInFixed.Text.StartsWith("0") && !txtInFixed.Text.StartsWith("0.") && e.KeyChar != '\b' && e.KeyChar != (int)'.')
            {
                e.Handled = true;
            }
        }

        private void txtBeamFixed_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txtBeamFixed.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtBeamFixed.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (txtBeamFixed.Text.StartsWith("0") && !txtBeamFixed.Text.StartsWith("0.") && e.KeyChar != '\b' && e.KeyChar != (int)'.')
            {
                e.Handled = true;
            }
        }

        private void txtWFixed_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txtWFixed.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtWFixed.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (txtWFixed.Text.StartsWith("0") && !txtWFixed.Text.StartsWith("0.") && e.KeyChar != '\b' && e.KeyChar != (int)'.')
            {
                e.Handled = true;
            }
        }

        private void txtMFixed_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txtMFixed.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtMFixed.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (txtMFixed.Text.StartsWith("0") && !txtMFixed.Text.StartsWith("0.") && e.KeyChar != '\b' && e.KeyChar != (int)'.')
            {
                e.Handled = true;
            }
        }

        
    }
}

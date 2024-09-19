using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        float sothu1, sothu2;
        string pheptinh;
        private void button15_Click(object sender, EventArgs e)
        {
            if (hienthi.Text == "0" && hienthi.Text != null)
            {
                hienthi.Text = "1";
            }
            else hienthi.Text = hienthi.Text + "1";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (hienthi.Text == "0" && hienthi.Text != null)
            {
                hienthi.Text = "0";
            }
            else hienthi.Text = hienthi.Text + "0";
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (hienthi.Text == "0" && hienthi.Text != null)
            {
                hienthi.Text = "2";
            }
            else hienthi.Text = hienthi.Text + "2";
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (hienthi.Text == "0" && hienthi.Text != null)
            {
                hienthi.Text = "3";
            }
            else hienthi.Text = hienthi.Text + "3";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (hienthi.Text == "0" && hienthi.Text != null)
            {
                hienthi.Text = "4";
            }
            else hienthi.Text = hienthi.Text + "4";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (hienthi.Text == "0" && hienthi.Text != null)
            {
                hienthi.Text = "5";
            }
            else hienthi.Text = hienthi.Text + "5";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (hienthi.Text == "0" && hienthi.Text != null)
            {
                hienthi.Text = "6";
            }
            else hienthi.Text = hienthi.Text + "6";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(hienthi.Text == "0" && hienthi.Text!= null)
            {
                hienthi.Text = "7";
            }
            else hienthi.Text = hienthi.Text + "7";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (hienthi.Text == "0" && hienthi.Text != null)
            {
                hienthi.Text = "8";
            }
            else hienthi.Text = hienthi.Text + "8";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (hienthi.Text == "0" && hienthi.Text != null)
            {
                hienthi.Text = "9";
            }
            else hienthi.Text = hienthi.Text + "9";
        }
        private void button16_Click(object sender, EventArgs e)
        {
            hienthi.Text = hienthi.Text + ".";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            pheptinh = "cong";
            sothu1=float.Parse(hienthi.Text);
            hienthi.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (pheptinh=="cong")
            {
                sothu2=sothu1+float.Parse(hienthi.Text);
                hienthi.Text=sothu2.ToString();
            }
            if (pheptinh == "tru")
            {
                sothu2 = sothu1 - float.Parse(hienthi.Text);
                hienthi.Text = sothu2.ToString();
            }
            if (pheptinh == "nhan")
            {
                sothu2 = sothu1 * float.Parse(hienthi.Text);
                hienthi.Text = sothu2.ToString();
            }
            if (pheptinh == "chia")
            {
                if (float.Parse(hienthi.Text) == 0)
                {
                    hienthi.Text = "Error";
                }
                else
                {
                    sothu2 = sothu1 / float.Parse(hienthi.Text);
                    hienthi.Text = sothu2.ToString();
                }
            }
            if(pheptinh == "mod")
            {
                sothu2=sothu1%float.Parse(hienthi.Text);
                hienthi.Text = sothu2.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pheptinh = "tru";
            if (hienthi.Text == "0" && hienthi.Text != null)
            {
                hienthi.Text = "-";
            }
            sothu1 = float.Parse(hienthi.Text);
            hienthi.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pheptinh = "nhan";
            sothu1 = float.Parse(hienthi.Text);
            hienthi.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pheptinh = "chia";
            sothu1 = float.Parse(hienthi.Text);
            hienthi.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (hienthi.Text.Length > 0)
            {
                hienthi.Text = hienthi.Text.Substring(0, hienthi.Text.Length - 1);
                if (hienthi.Text.Length == 0) hienthi.Text = "0";
            }
        }

        private float FactorialRecursive(float n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * FactorialRecursive(n - 1);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            pheptinh = "mod";
            sothu1 = float.Parse(hienthi.Text);
            hienthi.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hienthi.Text = "0";
        }
    }
}

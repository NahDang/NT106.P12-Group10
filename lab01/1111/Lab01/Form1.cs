using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void buttonBai5_Click(object sender, EventArgs e)
        { 
           Form2Bai05 f2= new Form2Bai05();
           f2.ShowDialog();
           
        }

        private void buttonBai1_Click(object sender, EventArgs e)
        {
            Form3Bai01 f3 = new Form3Bai01();
            f3.ShowDialog();
        }

        private void buttonBai3_Click(object sender, EventArgs e)
        {
            Form4Bai03 f4 = new Form4Bai03();
            f4.ShowDialog();
        }

        private void buttonBai2_Click(object sender, EventArgs e)
        {
            Form5Bai02 f5 = new Form5Bai02();
            f5.ShowDialog();
        }

        private void buttonBai4_Click(object sender, EventArgs e)
        {
            Form6Bai04 form6 = new Form6Bai04();
            form6.ShowDialog();
        }
    }
}

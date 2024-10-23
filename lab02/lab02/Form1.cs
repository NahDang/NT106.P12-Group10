using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      

        private void buttonBai5_Click(object sender, EventArgs e)
        {
            Bai05 b5=new Bai05();
            b5.Show();
        }

        private void buttonBai2_Click(object sender, EventArgs e)
        {
            Bai02 b2 =new Bai02();
            b2.Show();
        }

        private void buttonBai4_Click(object sender, EventArgs e)
        {
            Bai04 b4=new Bai04();
            b4.Show();
        }

        private void buttonBai1_Click(object sender, EventArgs e)
        {
            Bai1 bai1=new Bai1();
            bai1.Show();
        }

        private void buttonBai3_Click(object sender, EventArgs e)
        {
            Bai03 b3=new Bai03();
            b3.Show();
        }
    }
}

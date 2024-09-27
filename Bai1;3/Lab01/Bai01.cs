using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01
{
    public partial class Bai01 : Form
    {
        public Bai01()
        {
            InitializeComponent();
            
        }


        private void Bai01_Load(object sender, EventArgs e)
        {

        }

        private void txtNo1_TextChanged(object sender, EventArgs e)
        {
            bool t1 = float.TryParse(txtNo1.Text,NumberStyles.Any, CultureInfo.InvariantCulture, out float t2);
            if (!t1 && txtNo1.Text != " " &&  txtNo1.Text !="-")
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
            }    
        }
       
        private void txtNo2_TextChanged(object sender, EventArgs e)
        {
            bool t1 = float.TryParse(txtNo1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float t2);
            if (!t1 && txtNo1.Text != " " && txtNo1.Text != "-")
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
            }
        }
        private void txtNo3_TextChanged(object sender, EventArgs e)
        {
            bool t1 = float.TryParse(txtNo1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float t2);
            if (!t1 && txtNo1.Text != " " && txtNo1.Text != "-")
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
            }
        }
        private void btFind_Click(object sender, EventArgs e)
        {
            float n1, n2, n3;
            if (!float.TryParse(txtNo1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out n1) || !float.TryParse(txtNo2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out n2) || !float.TryParse(txtNo3.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out n3))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
            }
            else
            {
                float mx = Math.Max(n1, Math.Max(n2, n3));
                float mn = Math.Min(n1, Math.Min(n2, n3));
                txtMax.Text = mx.ToString(CultureInfo.InvariantCulture);
                txtMin.Text = mn.ToString(CultureInfo.InvariantCulture);
            }
        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            txtNo1.Text = txtNo2.Text = txtNo3.Text = txtMax.Text = txtMin.Text = " ";
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

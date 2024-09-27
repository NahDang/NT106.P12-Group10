using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab01
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Bai2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtboxNhapA_TextChanged(object sender, EventArgs e)
        {
            bool success = int.TryParse(txtboxNhapA.Text, out int val);
            string message = "Vui lòng nhập số nguyên!";
            if (!success && txtboxNhapA.Text != "" && txtboxNhapA.Text != "-")
            {
                MessageBox.Show(message);
            }
        }

        private void txtboxNhapB_TextChanged(object sender, EventArgs e)
        {
            bool success = int.TryParse(txtboxNhapB.Text, out int val);
            string message = "Vui lòng nhập số nguyên!";
            if (!success && txtboxNhapB.Text != "" && txtboxNhapB.Text != "-")
            {
                MessageBox.Show(message);
            }
        }

        private void KetQua_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btTinhCacGiaTri_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtboxNhapA.Text, out int A) || !int.TryParse(txtboxNhapB.Text, out int B))
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ cho A và B.");
                return;
            }
            if ((A > B) && comboBox1.Text=="Bảng cửu chương")
            {
                MessageBox.Show("Vui long nhap B lon hon A");
            }
            if (comboBox1.Text == "Bảng cửu chương")
            {
                for (int i = 1; i <= 10; i++)
                {
                    txtKetQua.AppendText($"{B-A} x {i} = {(B-A) * i}{Environment.NewLine}");
                }
            }
            if ((A<B) && comboBox1.Text=="Tính toán giá trị")
            {
                MessageBox.Show("Vui long nhap A lon hon B");
            }
            if (comboBox1.Text == "Tính toán giá trị")
            {
                int gt = 1;
                for (int i=A-B; i>=1;i--)
                {
                    gt = gt * i;
                }
                txtKetQua.AppendText("Giai thua [(A-B)!] = " + gt.ToString() + Environment.NewLine);
                int sum = 0;
                for (int i = 1; i <= B; i++)
                {
                    sum += (int)Math.Pow(A, i);
                }
                txtKetQua.AppendText("Tổng S (A^1 + A^2 + ... + A^B) = " + sum.ToString() + Environment.NewLine);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            txtboxNhapA.Clear();
            txtboxNhapB.Clear();
            txtKetQua.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

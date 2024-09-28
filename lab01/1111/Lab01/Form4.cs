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
    public partial class Form4Bai03 : Form
    {
        public Form4Bai03()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string input = txtIn.Text.Trim();
            if (long.TryParse(input, out long number) && input.Length <= 12)
            {
                string textResult = NumTrans(number);
                txtOut.Text = textResult;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ không quá 12 chữ số!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtIn.Text = txtOut.Text = " ";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIn_TextChanged(object sender, EventArgs e)
        {
            string input = txtIn.Text;
            bool t1 = float.TryParse(txtIn.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float t2);
            if (!t1 && txtIn.Text != " " && txtIn.Text != "-" && input.Length <= 12)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
            }
        }
        private readonly string[] VNNum = { "", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín", "Mười" };
        private string NumTrans(long number)
        {
            if (number < 0)
                return "Âm " + NumTrans(-number);
            if (number < 10)
                return VNNum[number];
            else if (number == 15)
                return "Mười Lăm";
            else if (number >= 10 && number < 20)
                return "Mười " + VNNum[number % 10];
            else if (number < 100)
            {
                string result = VNNum[number / 10] + " Mươi";
                if (number % 10 != 0)
                {
                    if (number % 10 == 5)
                        result += " Lăm";
                    else
                        result += " " + VNNum[number % 10];
                }
                return result;
            }
            else if (number < 1000)
            {
                string result = VNNum[number / 100] + " Trăm";
                if (number % 100 != 0)
                {
                    if ((number % 100) < 10)
                        result += " Lẻ " + VNNum[number % 10];
                    else
                        result += " " + NumTrans(number % 100);
                }
                return result;
            }
            else if (number < 1000000)
            {
                string result = NumTrans(number / 1000) + " Nghìn";
                if (number % 1000 != 0)
                {
                    if ((number % 1000) < 100)
                        result += " Lẻ " + NumTrans(number % 1000);
                    else
                        result += " " + NumTrans(number % 1000);
                }
                return result;
            }
            else if (number < 1000000000)
            {
                string result = NumTrans(number / 1000000) + " Triệu";
                if (number % 1000000 != 0)
                {
                    if ((number % 1000000) < 1000)
                        result += " Lẻ " + NumTrans(number % 1000000);
                    else
                        result += " " + NumTrans(number % 1000000);
                }
                return result;
            }
            else if (number < 1000000000000)
            {
                string result = NumTrans(number / 1000000000) + " Tỷ";
                if (number % 1000000000 != 0)
                {
                    if ((number % 1000000000) < 1000000)
                        result += " Lẻ " + NumTrans(number % 1000000000);
                    else
                        result += " " + NumTrans(number % 1000000000);
                }
                return result;
            }
            else
            {
                return "Số quá lớn!";
            }
        }
    }
}

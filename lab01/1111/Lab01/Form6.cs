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
    public partial class Form6Bai04 : Form
    {
        public Form6Bai04()
        {
            InitializeComponent();
        }

        private void txtNgay_TextChanged(object sender, EventArgs e)
        {
            bool successDay = int.TryParse(txtNgay.Text, out int day);
            bool successMonth = int.TryParse(txtThang.Text, out int month);

            if (!successDay && txtNgay.Text != "")
            {
                MessageBox.Show("Vui lòng nhập số nguyên cho ngày!");
                return;
            }
            if (!successMonth && txtThang.Text != "")
            {
                MessageBox.Show("Vui lòng nhập số nguyên cho tháng!");
                return;
            }

            if (month < 1 || month > 12)
            {
                MessageBox.Show("Vui lòng nhập số nguyên trong khoảng từ 1 đến 12 cho tháng!");
                return;
            }

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (day < 1 || day > 31)
                    {
                        MessageBox.Show("Ngày không hợp lệ cho tháng " + month + ". Tháng này có 31 ngày.");
                    }
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    if (day < 1 || day > 30)
                    {
                        MessageBox.Show("Ngày không hợp lệ cho tháng " + month + ". Tháng này có 30 ngày.");
                    }
                    break;

                case 2:
                    if (day < 1 || day > 29)
                    {
                        MessageBox.Show("Ngày không hợp lệ cho tháng " + month + ". Tháng này có 29 ngày.");
                    }
                    break;
            }
        }

        private void btKQ_Click(object sender, EventArgs e)
        {
            int Ngay = Int32.Parse(txtNgay.Text);
            int Thang = Int32.Parse(txtThang.Text);
            string kq = "";
            if ((Ngay >= 21 && Thang == 3) || (Ngay <= 19 && Thang == 4))
            {
                kq = "Bạch Dương";
            }
            else if ((Ngay >= 20 && Thang == 4) || (Ngay <= 20 && Thang == 5))
            {
                kq = "Kim Ngưu";
            }
            else if ((Ngay >= 21 && Thang == 5) || (Ngay <= 21 && Thang == 6))
            {
                kq = "Song Tử";
            }
            else if ((Ngay >= 22 && Thang == 6) || (Ngay <= 22 && Thang == 7))
            {
                kq = "Cự Giải";
            }
            else if ((Ngay >= 23 && Thang == 7) || (Ngay <= 22 && Thang == 8))
            {
                kq = "Sư Tử";
            }
            else if ((Ngay >= 23 && Thang == 8) || (Ngay <= 22 && Thang == 9))
            {
                kq = "Xử Nữ";
            }
            else if ((Ngay >= 23 && Thang == 9) || (Ngay <= 23 && Thang == 10))
            {
                kq = "Thiên Bình";
            }
            else if ((Ngay >= 24 && Thang == 10) || (Ngay <= 22 && Thang == 11))
            {
                kq = "Bọ Cạp";
            }
            else if ((Ngay >= 23 && Thang == 11) || (Ngay <= 21 && Thang == 12))
            {
                kq = "Nhân Mã";
            }
            else if ((Ngay >= 22 && Thang == 12) || (Ngay <= 19 && Thang == 1))
            {
                kq = "Ma Kết";
            }
            else if ((Ngay >= 20 && Thang == 1) || (Ngay <= 18 && Thang == 2))
            {
                kq = "Bảo Bình";
            }
            else if ((Ngay >= 19 && Thang == 2) || (Ngay <= 20 && Thang == 3))
            {
                kq = "Song Ngư";
            }
            txtKetQua.Text = kq;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

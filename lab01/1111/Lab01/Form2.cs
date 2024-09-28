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

namespace Lab01
{
    public partial class Form2Bai05 : Form
    {
        public Form2Bai05()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Xóa")
            
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa thí sinh này?", "Xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    danhsachthisinh.RemoveAt(e.RowIndex);
                    UpdateDataGridView();
                }
            }
        }

        public class ThiSinh
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Phai { get; set; }
            public double Mon1 { get; set; }
            public double Mon2 { get; set; }
            public double Mon3 { get; set; }
            public double DTB { get; set; }
            public string Xeploai { get; set; }
        }

        List<ThiSinh> danhsachthisinh = new List<ThiSinh>();

        private void Form2Bai05_Load(object sender, EventArgs e)
        {
            cmbphai.Items.Add("Nam");
            cmbphai.Items.Add("Nu");
            cmbphai.SelectedIndex = 0;
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Họ và Tên", typeof(string));
            dt.Columns.Add("Phái", typeof(string));
            dt.Columns.Add("Môn 1", typeof(double));
            dt.Columns.Add("Môn 2", typeof(double));
            dt.Columns.Add("Môn 3", typeof(double));
            dt.Columns.Add("Trung Binh", typeof(double));
            dt.Columns.Add("Xếp loại", typeof(string));
            DataGridViewButtonColumn ButtonDelete = new DataGridViewButtonColumn
            {
                Text = "Xóa",
                HeaderText = "Xóa",
                UseColumnTextForButtonValue = true,

            };
            dataGridView1.Columns.Add(ButtonDelete);

            dataGridView1.DataSource = dt;
        }
        ComboBox cmbphai = new ComboBox();
        private void UpdateDataGridView()
        {
            dt.Clear();
            foreach(var ts in danhsachthisinh)
            {
                dt.Rows.Add(ts.ID,ts.Name,ts.Phai,ts.Mon1,ts.Mon2,ts.Mon3,ts.DTB,ts.Xeploai);
            }
        }

        public double TinhDiemTrungBinh(double Mon1, double Mon2, double Mon3)
        {
            return Math.Round((Mon1 + Mon2 + Mon3) / 3, 2);
        }
        public string XepLoai(double Mon1, double Mon2, double Mon3, double DTB)
        {
            if (DTB >= 8 && Mon1 >= 6.5 && Mon2 >= 6.5 && Mon3 >= 6.5) return "Giỏi";
            else if (DTB >= 6.5 && Mon1 >= 5 && Mon2 >= 5 && Mon3 >= 5) return "Khá";
            else if (DTB >= 5 && Mon1 >= 3.5 && Mon2 >= 3.5 && Mon3 >= 3.5) return "Trung Bình";
            else if (DTB >= 3.5 && Mon1 >= 2 && Mon2 >= 2 && Mon3 >= 2) return "Yếu";
            else return "kém";
        }
        public string CreateID(int ID)
        {
            return "TS" + ID.ToString("D3");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonThongKe_Click_1(object sender, EventArgs e)
        {
            int tongSoThiSinh = danhsachthisinh.Count;
            if (tongSoThiSinh == 0)
            {
                MessageBox.Show("Chưa có thí sinh nào trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ThiSinh thiSinhCaoDiemNhat = danhsachthisinh.OrderByDescending(ts => ts.DTB).First();
            int soGioi = danhsachthisinh.Count(ts => ts.Xeploai == "Giỏi");
            int soKha = danhsachthisinh.Count(ts => ts.Xeploai == "Khá");
            int soTrungBinh = danhsachthisinh.Count(ts => ts.Xeploai == "Trung Bình");
            int soKhongDat = danhsachthisinh.Count(ts => ts.Xeploai == "Yếu" || ts.Xeploai == "Kém");
            MessageBox.Show(
                $"Tổng số thí sinh: {tongSoThiSinh}\n" +
                $"Thí sinh có ĐTB cao nhất: {thiSinhCaoDiemNhat.Name} - ĐTB: {thiSinhCaoDiemNhat.DTB}\n" +
                $"Số thí sinh Giỏi: {soGioi}\n" +
                $"Số thí sinh Khá: {soKha}\n" +
                $"Số thí sinh Trung Bình: {soTrungBinh}\n" +
                $"Số thí sinh không đạt (Yếu/Kém): {soKhongDat}",
                "Kết quả thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            comboBoxPhai.SelectedIndex = 0;
            textBoxMon1.Text = "";
            textBoxMon2.Text = "";
            textBoxMon3.Text = "";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string phai = cmbphai.SelectedItem.ToString();
            double mon1 = double.Parse(textBoxMon1.Text);
            double mon2 = double.Parse(textBoxMon2.Text);
            double mon3 = double.Parse(textBoxMon3.Text);

            double dtb = TinhDiemTrungBinh(mon1, mon2, mon3);
            string xeploai = XepLoai(mon1, mon2, mon3, dtb);
            string id = CreateID(danhsachthisinh.Count + 1);

            if (!double.TryParse(textBoxMon1.Text, out mon1) || mon1 < 0 || mon1 > 10)
            {
                MessageBox.Show("Điểm môn 1 không hợp lệ (0-10).", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(textBoxMon2.Text, out mon2) || mon2 < 0 || mon2 > 10)
            {
                MessageBox.Show("Điểm môn 2 không hợp lệ (0-10).", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(textBoxMon3.Text, out mon3) || mon2 < 0 || mon2 > 10)
            {
                MessageBox.Show("Điểm môn 3 không hợp lệ (0-10).", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ThiSinh ts = new ThiSinh();
            ts.ID = id;
            ts.Name = name;
            ts.Phai = phai;
            ts.Mon1 = mon1;
            ts.Mon2 = mon2;
            ts.Mon3 = mon3;
            ts.DTB = dtb;
            ts.Xeploai = xeploai;
            danhsachthisinh.Add(ts);
            UpdateDataGridView();
        }
    }

}

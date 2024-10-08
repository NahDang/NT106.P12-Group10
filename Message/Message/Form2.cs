using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Message.Properties;
using System.Runtime.InteropServices;
namespace Message
{
    public partial class Form2 : Form
    {
        public string emailname {set;get ;}
        public Form2()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        string constring = "Data Source=LAPTOP-AA3MGNUM\\SQLEXPRESS;Initial Catalog=dd;Integrated Security=True;TrustServerCertificate=True";
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Form1 f1=new Form1();
            this.Hide();
            f1.Show();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = emailname;
            byte[] getimage = new byte[0];
            SqlConnection con= new SqlConnection(constring);
            con.Open();
            string q = "Select * from Login WHERE email = '" + label2.Text + "'";
            SqlCommand cmd= new SqlCommand(q, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                label2.Text = dataReader["email"].ToString();
                guna2TextBox1.Text = dataReader["username"].ToString();
                guna2TextBox2.Text = dataReader["email"].ToString();
                guna2TextBox3.Text = dataReader["password"].ToString();
                byte[] images = (byte[])dataReader["image"];
                if (images == null)
                {
                    guna2CirclePictureBox1.Image= null;
                    guna2CirclePictureBox2.Image= null;

                }
                else
                {
                    MemoryStream me = new MemoryStream(images);
                    guna2CirclePictureBox1.Image=Image.FromStream(me);
                    guna2CirclePictureBox2.Image= Image.FromStream(me);

                }
            }
             con.Close();

        }
        private bool check;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                panel2.Width += 10;
                if(panel2.Size== panel2.MaximumSize)
                {
                    pictureBox1.Left = +230;
                    timer1.Stop();
                    check=false;
                    pictureBox1.Image = Resources.download__6_;
                }
            }
            else
            {
                panel2.Width -= 10;
                if(panel2.Size== panel2.MinimumSize)
                {
                    pictureBox1.Left = 23;
                    timer1.Stop();
                    check = true;
                    pictureBox1.Image = Resources.download__3_;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == false)
            {
                panel5.Visible = true;
            }
            else
            {
                panel5.Visible = false;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}

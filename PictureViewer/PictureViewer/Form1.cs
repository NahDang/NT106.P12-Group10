using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Form1 : Form
    {
        private List<string> imagePaths = new List<string>();
        private int currentImageIndex = -1;
        private FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
        public Form1()
        {
         InitializeComponent();
            flowLayoutPanel2.PreviewKeyDown += new PreviewKeyDownEventHandler(flowLayoutPanel2_PreviewKeyDown);
            flowLayoutPanel2.KeyDown += new KeyEventHandler(flowLayoutPanel2_KeyDown);
            flowLayoutPanel2.TabStop = true;
            flowLayoutPanel2.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog o= new OpenFileDialog();
            o.Title = "File Explore";
            o.Filter = "File anh (*.pnq , *.gif , *.jpg)|*.pnq ; *.gif;*.jpg|All file|*.*";
            if(o.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image=Image.FromFile(o.FileName);
            }
            imagePaths.Add(o.FileName);
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(o.FileName);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Width = 100;
            pictureBox.Height = 100;
            pictureBox.Click += new EventHandler(pictureBox_Click);
            flowLayoutPanel2.Controls.Add(pictureBox);

            flowLayoutPanel2.Dock = DockStyle.Top;
            Controls.Add(flowLayoutPanel2);
            if (currentImageIndex == -1)
            {
                currentImageIndex = 0;
                pictureBox1.Image = Image.FromFile(imagePaths[currentImageIndex]);
            }
            flowLayoutPanel.Focus();
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            int index = flowLayoutPanel2.Controls.IndexOf(pictureBox);
            currentImageIndex = index;
            pictureBox1.Image = Image.FromFile(imagePaths[currentImageIndex]);
            flowLayoutPanel2.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {   
                if (currentImageIndex >0)
                {
                    currentImageIndex--;
                    pictureBox1.Image = Image.FromFile(imagePaths[currentImageIndex]);
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (currentImageIndex < imagePaths.Count - 1)
                {
                    currentImageIndex++;
                    pictureBox1.Image = Image.FromFile(imagePaths[currentImageIndex]);
                }
            }
        }
        private void flowLayoutPanel2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (currentImageIndex > 0)
                {
                    currentImageIndex--;
                    pictureBox1.Image = Image.FromFile(imagePaths[currentImageIndex]);
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (currentImageIndex < imagePaths.Count - 1)
                {
                    currentImageIndex++;
                    pictureBox1.Image = Image.FromFile(imagePaths[currentImageIndex]);
                }
            }
        }
        private void flowLayoutPanel2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}

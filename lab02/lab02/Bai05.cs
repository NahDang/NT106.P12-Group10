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
    public partial class Bai05 : Form
    {
        public Bai05()
        {
            InitializeComponent();
            TaiDrives();
        }
        private void TaiDrives()
        {
            TreeNode rootNode;
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    rootNode = new TreeNode(drive.Name);
                    rootNode.Tag = drive;
                    rootNode.Nodes.Add("...");
                    TV1.Nodes.Add(rootNode);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node= e.Node;
            node.Nodes.Clear();

            DirectoryInfo DI =new DirectoryInfo(node.FullPath);
            try
            {
                foreach(DirectoryInfo dir in DI.GetDirectories())
                {
                    TreeNode dirNode = new TreeNode(dir.Name);
                    dirNode.Tag = dir;
                    dirNode.Nodes.Add("...");
                    node.Nodes.Add(dirNode);
                }
                foreach(FileInfo file in DI.GetFiles())
                {
                    TreeNode FileNode = new TreeNode(file.Name);
                    FileNode.Tag = file;
                    node.Nodes.Add(FileNode);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " +  ex.Message);
            }
        }

        private void Bai05_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FileInfo file = e.Node.Tag as FileInfo;
            if (file != null)
            {
                if(file.Extension.ToLower()==".txt") 
                {
                    ptBox.Image = null;
                    txtBox.Visible = true;
                    ptBox.Visible = false;
                    txtBox.Text=File.ReadAllText(file.FullName);
                }
                else if(file.Extension.ToLower()==".jpg" || file.Extension.ToLower() == ".pnq")
                {
                    ptBox.Visible = true;
                    txtBox.Visible = false;
                    ptBox.Image = new Bitmap(file.FullName);
                }
                else
                {
                    MessageBox.Show("File không hỗ trợ hiện thị. ");
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            txtBox.Visible = false;
            ptBox.Visible = false;
        }
    }
}

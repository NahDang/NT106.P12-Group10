using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()
            { Description = "Select your path." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    webBrowser.Url = new Uri(fbd.SelectedPath);
                    textPath.Text = fbd.SelectedPath;
                }

            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoBack)
                webBrowser.GoBack();
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoForward)
                webBrowser.GoForward();
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public static class FileCopyHelper
        {
            public static void CopyBigFile(string sSource, string sTarget)
            {
                using (FileStream fsRead = new FileStream(sSource, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream fsWrite = new FileStream(sTarget, FileMode.Create, FileAccess.Write))
                    {                      
                        byte[] bteData = new byte[12 * 1024 * 1024];
                        int r = fsRead.Read(bteData, 0, bteData.Length);
                        while (r > 0)
                        {
                            fsWrite.Write(bteData, 0, r);
                            double d = 100 * (fsWrite.Position / (double)fsRead.Length);
                            Console.WriteLine("{0}%", d);
                            r = fsRead.Read(bteData, 0, bteData.Length);
                        }
                    }
                }
            }
        }
    }
}

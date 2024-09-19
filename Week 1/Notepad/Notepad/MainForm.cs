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

namespace Notepad
{
    public partial class Form1 : Form
    {
        private bool fileAleadySaved;
        private bool fileUpdated;
        private string currentfilename;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileUpdated)
            {
                DialogResult newresult = MessageBox.Show("Do you want to save your change?", "File Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                switch (newresult)
                {
                    case DialogResult.Yes:
                        SaveFileUpdate11();
                        break;
                    case DialogResult.No:
                        clearscreen();
                        break;

                }
            }
            else
            {
                clearscreen();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            fileUpdated = true;

        }

        private void rtb_click(object sender, EventArgs e)
        {
        }

        private void rtb_right(object sender, EventArgs e)
        {
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
            richTextBox1.Text = "";

        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Text file (*.txt)|*.txt|Rich text Files (*.rtf)|*.rtf";
            DialogResult result= o.ShowDialog();

            if(result == DialogResult.OK)
            {
                if (Path.GetExtension(o.FileName) == ".txt")
                {
                    richTextBox1.LoadFile(o.FileName, RichTextBoxStreamType.PlainText);
                }
                if (Path.GetExtension(o.FileName) == ".rtf")
                {
                    richTextBox1.LoadFile(o.FileName, RichTextBoxStreamType.RichText);
                }
                this.Text = Path.GetFileName(o.FileName) + " - Notepad. ";

                fileAleadySaved = true;
                fileUpdated = false;
                currentfilename = o.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileUpdate11();
        }

        private void SaveFileUpdate11()
        {
            if (fileAleadySaved)
            {
                if (Path.GetExtension(currentfilename) == ".txt")
                {
                    richTextBox1.SaveFile(currentfilename, RichTextBoxStreamType.PlainText);
                }
                if (Path.GetExtension(currentfilename) == ".rtf")
                {
                    richTextBox1.SaveFile(currentfilename, RichTextBoxStreamType.RichText);
                }
                fileUpdated = false;
            }
            else
            {
                if (fileUpdated)
                {
                    savefile();
                }
                else
                {
                    clearscreen();
                }

            }
        }

        private void clearscreen()
        {
            richTextBox1.Clear();
            fileUpdated = false;
            this.Text = "Notepad";
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Clipboard.GetText();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void NewMethod()
        {
            savefile();
        }

        private void savefile()
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Text file (*.txt)|*.txt|Rich Text Files (*.rtf)|*.rtf";

            DialogResult saveresult = s.ShowDialog();

            if (saveresult == DialogResult.OK)
            {
                if (Path.GetExtension(s.FileName) == ".txt")
                {
                    richTextBox1.SaveFile(s.FileName, RichTextBoxStreamType.PlainText);
                }
                if (Path.GetExtension(s.FileName) == ".rtf")
                {
                    richTextBox1.SaveFile(s.FileName, RichTextBoxStreamType.RichText);
                }
                this.Text = Path.GetFileName(s.FileName) + " - Notepad. ";

                fileAleadySaved = true;
                fileUpdated = false;
                currentfilename = s.FileName;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileAleadySaved = false;
            fileUpdated = false;
            currentfilename = "";
        }
    }
}

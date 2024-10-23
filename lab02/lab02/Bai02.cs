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

namespace lab02
{
    public partial class Bai02 : Form
    {
        public Bai02()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            txtFileContent.Text = sr.ReadToEnd();
            ShowFileName(openFileDialog.SafeFileName);
            ShowSize(fs.Length);
            ShowURL(openFileDialog.FileName);
            ShowLineCount(fs);
            ShowWordsCount(fs);
            ShowCharacterCount(fs);
            sr.Close();
        }
        void ShowFileName(string filename)
        {
            txtFileName.Text = filename;
        }
        void ShowSize(long size)
        {
            if (size >= 1073741824)
            {
                double sizeInGB = size / 1073741824.0;
                txtSize.Text = sizeInGB.ToString("F2") + " GB";
            }
            else
            {
                txtSize.Text = size.ToString() + " bytes";
            }
        }
        void ShowURL(string url)
        {
            txtURL.Text = url;
        }
        void ShowLineCount(FileStream fs)
        {
            fs.Position = 0;
            StreamReader reader = new StreamReader(fs);
            int linecount = 0;
            while (reader.ReadLine() != null)
            {
                linecount++;
            }
            txtLineCount.Text = linecount.ToString();
        }
        void ShowWordsCount(FileStream fs)
        {
            fs.Position = 0;
            StreamReader reader = new StreamReader(fs);
            int wordscount = 0;
            bool wordcounted = false;
            while (reader.Read() != -1)
            {
                if (reader.Peek() == ' ' || reader.Peek() == '\n' || reader.Peek() == -1 || reader.Peek() == '\t')
                {
                    if (wordcounted == false)
                    {
                        wordscount++;
                        wordcounted = true;
                    }
                    else
                    {
                        reader.Read();
                        wordcounted = true;
                    }
                }
                else
                {
                    wordcounted = false;
                }
            }
            txtWordsCount.Text = wordscount.ToString();
        }
        void ShowCharacterCount(FileStream fs)
        {
            fs.Position = 0;
            StreamReader reader = new StreamReader(fs);
            int charactercount = 0;
            while (reader.Read() != -1)
            {
                charactercount++;
            }
            txtCharacterCount.Text = charactercount.ToString();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class Bai03 : Form
    {
        public Bai03()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd;

        private void readfile_Click(object sender, EventArgs e)
        {
            try
            {
                ofd = new OpenFileDialog();
                ofd.Filter = "Text Files|*.txt";
                ofd.ShowDialog();
                FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);
                rtbRead.Text = sr.ReadToEnd();
                sr.BaseStream.Position = 0;
                writefile.Enabled = true;
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi! Không đọc được file này. " + ex.Message);
            }
        }

        private void writefile_Click(object sender, EventArgs e)
        {
            File.WriteAllText("..\\..\\output3.txt", "");
            FileStream fsw = new FileStream("..\\..\\output3.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fsw, Encoding.UTF8);
            FileStream fsr = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fsr, Encoding.UTF8);

            string[] res = Calc(sr);
            foreach (var item in res)
            {
                sw.WriteLine(item);
            }

            sw.Close();
            rtbWrite.Text = File.ReadAllText(fsw.Name);
            fsw.Close();
            fsr.Close();
        }

        private string[] Calc(StreamReader sr)
        {
            try
            {
                var content = sr.ReadToEnd();
                var Lines = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                for (int i = 0; i < Lines.Length; i++)
                {
                    if (Lines[i].Contains('+') || Lines[i].Contains('-') || Lines[i].Contains('*') || Lines[i].Contains('/'))
                    {
                        string[] tokens = Lines[i].Split(new char[] { '+', '-', '*', '/' });
                        List<decimal> numbers = new List<decimal>(); ;
                        List<char> operators = new List<char>();
                        foreach (var token in tokens)
                        {
                            decimal number;
                            if (decimal.TryParse(token, out number))
                            {
                                numbers.Add(number);
                            }
                            else
                            {
                                MessageBox.Show("Dữ liệu nhập vào không chính xác theo yêu cầu đề bài!");
                                return new string[] { };
                            }
                        }
                        for (int j = 0; j < Lines[i].Length; j++)
                        {
                            if (Lines[i][j] == '+' || Lines[i][j] == '-' || Lines[i][j] == '*' || Lines[i][j] == '/')
                            {
                                operators.Add(Lines[i][j]);
                            }
                        }
                        decimal result = numbers[0];
                        for (int j = 1; j < numbers.Count; j++)
                        {
                            if (operators[j - 1] == '+') result += numbers[j];
                            else if (operators[j - 1] == '-') result -= numbers[j];
                            else if (operators[j - 1] == '*') result *= numbers[j];
                            else if (operators[j - 1] == '/') result /= numbers[j];
                        }
                        Lines[i] = Lines[i] + " = " + result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu nhập vào không chính xác theo yêu cầu đề bài!");
                    }
                }

                return Lines;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi! Không thể tính toán. " + ex.Message);
                return new string[] { };
            }
        }
    }
}

using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClientChat
{
    
    public partial class Form1 : Form
    {
        private TcpClient tcpClient;
        private StreamReader sReader;
        private StreamWriter sWriter;
        private Thread clientThread;
        private int serverPort = 8000;
        private int filePort = 8001;
        private bool stopTcpClient = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void ClientRecv()
        {
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            try
            {
                while (!stopTcpClient)
                {
                    Application.DoEvents();
                    string data = sr.ReadLine();
                    if (data != null)
                    {
                        UpdateChatHistoryThreadSafe($"{data}\n");
                    }
                }
            }
            catch (SocketException)
            {
                tcpClient.Close();
                sr.Close();
            }
        }
        private delegate void SafeCallDelegate(string text);
        private void UpdateChatHistoryThreadSafe(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateChatHistoryThreadSafe);
                richTextBox1.Invoke(d, new object[] { text });
            }
            else
            {
                richTextBox1.Text += text;
            }
        }

        private void btnSend_Click(object sender, System.EventArgs e)
        {
            try
            {
                sWriter.WriteLine(txtMessage.Text);
                txtMessage.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form1_Close(object sender, FormClosingEventArgs e)
        {
            stopTcpClient = true;
            tcpClient?.Close();
            clientThread?.Abort();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                stopTcpClient = false;

                this.tcpClient = new TcpClient();
                this.tcpClient.Connect(new IPEndPoint(IPAddress.Parse(txtIP.Text), serverPort));
                this.sWriter = new StreamWriter(tcpClient.GetStream());
                this.sWriter.AutoFlush = true;
                sWriter.WriteLine(this.txtName.Text); 
                clientThread = new Thread(this.ClientRecv);
                clientThread.Start();
                MessageBox.Show("Đã kết nối");
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show(sockEx.Message, "Lỗi mạng", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                SendFile(filePath);
            }
        }
        private void SendFile(string filePath)
        {
            try
            {
                TcpClient fileClient = new TcpClient(txtIP.Text, filePort);
                NetworkStream ns = fileClient.GetStream();
                byte[] fileNameBytes = Encoding.UTF8.GetBytes(Path.GetFileName(filePath) + "\n");
                ns.Write(fileNameBytes, 0, fileNameBytes.Length);

               
                byte[] fileData = File.ReadAllBytes(filePath);
                ns.Write(fileData, 0, fileData.Length);
                ns.Close();
                fileClient.Close();
                MessageBox.Show("Tệp được gửi thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

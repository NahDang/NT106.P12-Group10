using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ServerChat
{
    public partial class Form1 : Form
    {
        private Thread listenThread;
        private Thread fileThread;
        private TcpListener tcpListener;
        private TcpListener fileListener;
        private bool stopChatServer = true;
        private readonly int _serverPort = 8000; 
        private readonly int _filePort = 8001;   
        private Dictionary<string, TcpClient> dict = new Dictionary<string, TcpClient>();
        public Form1()
        {
            InitializeComponent();
        }
        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Parse(txtIP.Text), _serverPort);
                tcpListener.Start();

                while (!stopChatServer)
                {
                    TcpClient _client = tcpListener.AcceptTcpClient();

                    StreamReader sr = new StreamReader(_client.GetStream());
                    StreamWriter sw = new StreamWriter(_client.GetStream());
                    sw.AutoFlush = true;
                    string username = sr.ReadLine();

                    if (string.IsNullOrWhiteSpace(username))
                    {
                        sw.WriteLine("Vui lòng chọn tên người dùng");
                    }
                    else
                    {
                        if (!dict.ContainsKey(username))
                        {
                            Thread clientThread = new Thread(() => ClientRecv(username, _client));
                            dict.Add(username, _client);
                            clientThread.Start();
                            UpdateChatHistoryThreadSafe($"User {username} connected.\n");
                        }
                        else
                        {
                            sw.WriteLine("Tên người dùng đã tồn tại, hãy chọn tên khác");
                        }
                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ListenForFiles()
        {
            try
            {
                fileListener = new TcpListener(IPAddress.Parse(txtIP.Text), _filePort);
                fileListener.Start();

                while (!stopChatServer)
                {
                    TcpClient fileClient = fileListener.AcceptTcpClient();
                    Thread receiveFileThread = new Thread(() => ReceiveFile(fileClient));
                    receiveFileThread.Start();
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReceiveFile(TcpClient client)
        {
            try
            {
                NetworkStream ns = client.GetStream();
                StreamReader sr = new StreamReader(ns);


                string fileName = sr.ReadLine();

                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = ns.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, bytesRead);
                    }

                    
                    UpdateChatHistoryThreadSafe($"Received file: {fileName} with size: {ms.Length} bytes\n");
                }

                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ClientRecv(string username, TcpClient tcpClient)
        {
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            try
            {
                while (!stopChatServer)
                {
                    string msg = sr.ReadLine();
                    string formattedMsg = $"[{DateTime.Now:MM/dd/yyyy h:mm tt}] {username}: {msg}\n";

                    foreach (TcpClient otherClient in dict.Values)
                    {
                        StreamWriter sw = new StreamWriter(otherClient.GetStream());
                        sw.WriteLine(formattedMsg);
                        sw.AutoFlush = true;
                    }

                    UpdateChatHistoryThreadSafe(formattedMsg);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (stopChatServer)
            {
                stopChatServer = false;
                listenThread = new Thread(Listen);
                fileThread = new Thread(ListenForFiles);
                listenThread.Start();
                fileThread.Start();
                MessageBox.Show("Máy chủ đã khởi động, đang lắng nghe kết nối.");
                button1.Text = "Dừng";
            }
            else
            {
                stopChatServer = true;
                tcpListener.Stop();
                fileListener.Stop();
                listenThread = null;
                fileThread = null;
                dict.Clear();
                MessageBox.Show("Máy chủ đã dừng.");
                button1.Text = "Bắt đầu nghe.";
            }
        }
    }
}

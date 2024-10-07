using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        IPEndPoint IP;
        Socket client;

        void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1997);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        void Close()
        {
            client.Close();
        }

        void Send()
        {
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                byte[] message = Serialize("MSG:" + txtMessage.Text);
                client.Send(message);
                AddMessage("Client: " + txtMessage.Text);
            }
        }

        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000]; 
                    int bytesRead = client.Receive(data);
                    string message = (string)Deseriliaze(data);

                    if (message.StartsWith("MSG:"))
                    {
                        AddMessage("Server: " + message.Substring(4)); 
                    }
                    else if (message.StartsWith("FILE:"))
                    {
                        string fileName = message.Substring(5);
                        ReceiveFile(fileName);
                    }
                }
            }
            catch
            {
                Close();
            }
        }

        void ReceiveFile(string fileName)
        {
            try
            {
                byte[] fileData = new byte[1024 * 5000]; 
                int bytesRead = client.Receive(fileData);
                if (bytesRead > 0)
                {
                    File.WriteAllBytes(Path.Combine("ReceivedFiles", fileName), fileData.Take(bytesRead).ToArray());
                    AddMessage($"File received: {fileName}");
                }
            }
            catch (Exception ex)
            {
                AddMessage("Error receiving file: " + ex.Message);
            }
        }

        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
            txtMessage.Clear();
        }

        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        object Deseriliaze(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }

        async Task SendFileAsync(string filePath)
        {
            if (client != null && client.Connected)
            {
                string fileName = Path.GetFileName(filePath);
                byte[] fileHeader = Serialize("FILE:" + fileName);
                byte[] fileData = File.ReadAllBytes(filePath);

                client.Send(fileHeader);

                await Task.Run(() => client.Send(fileData));

                AddMessage($"File sent: {fileName}");
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            Send();
        }

        private async void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                await SendFileAsync(ofd.FileName); 
            }
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}

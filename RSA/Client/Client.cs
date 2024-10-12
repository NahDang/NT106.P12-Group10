using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        private static RSACryptoServiceProvider rsaProvider;
        private static string publicKey;
        private static string privateKey;
        private static string serverPublicKey; // Khóa công khai của server (nhận từ server)

        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            GenerateRSAKeys(); // Tạo cặp khóa RSA
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

            // Gửi khóa công khai của client đến server ngay sau khi kết nối
            client.Send(Encoding.UTF8.GetBytes("KEY:" + publicKey));

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
                string encryptedMessage = EncryptWithPrivateKey("MSG:" + txtMessage.Text); // Mã hóa tin nhắn bằng khóa riêng
                byte[] message = Encoding.UTF8.GetBytes(encryptedMessage); // Chuyển đổi chuỗi sang byte[]
                client.Send(message);
                AddMessage("Client: " + txtMessage.Text); // Hiển thị tin nhắn đã gửi
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
                    if (bytesRead > 0)
                    {
                        string message = Encoding.UTF8.GetString(data.Take(bytesRead).ToArray());

                        if (message.StartsWith("MSG:"))
                        {
                            // Giải mã tin nhắn từ các client khác bằng khóa công khai
                            string decryptedMessage = DecryptWithPublicKey(message.Substring(4));
                            AddMessage("Client: " + decryptedMessage); // Hiển thị tin nhắn đã giải mã
                        }
                        else if (message.StartsWith("FILE:"))
                        {
                            string fileName = message.Substring(5);
                            ReceiveFile(fileName);
                        }
                        else if (message.StartsWith("KEY:"))
                        {
                            // Nhận khóa công khai của server
                            serverPublicKey = message.Substring(4);
                            AddMessage("Server public key received.");
                        }
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

        // Tạo cặp khóa RSA
        void GenerateRSAKeys()
        {
            rsaProvider = new RSACryptoServiceProvider(2048); // Sử dụng độ dài khóa 2048 bits
            publicKey = rsaProvider.ToXmlString(false); // Chỉ lấy khóa công khai
            privateKey = rsaProvider.ToXmlString(true); // Lấy cả khóa công khai và khóa riêng
        }

        // Mã hóa bằng khóa riêng của client (để gửi đi)
        string EncryptWithPrivateKey(string plainText)
        {
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
            rsaProvider.FromXmlString(privateKey); // Sử dụng khóa riêng để mã hóa
            byte[] encryptedData = rsaProvider.Encrypt(dataToEncrypt, false);
            return Convert.ToBase64String(encryptedData); // Trả về chuỗi base64
        }

        // Giải mã bằng khóa công khai của client khác (sau khi nhận)
        string DecryptWithPublicKey(string cipherText)
        {
            byte[] dataToDecrypt = Convert.FromBase64String(cipherText);
            rsaProvider.FromXmlString(serverPublicKey); // Sử dụng khóa công khai để giải mã
            byte[] decryptedData = rsaProvider.Decrypt(dataToDecrypt, false);
            return Encoding.UTF8.GetString(decryptedData);
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}

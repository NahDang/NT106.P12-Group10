﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using SeverMessage;
using System.Drawing;


namespace SeverMessage
{
    public partial class Sever : Form
    {
        private Aes aes;
        private Dictionary<Socket, byte[]> clientAesKeys;

        public Sever()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            aes = Aes.Create();
            clientAesKeys = new Dictionary<Socket, byte[]>();
            lsvMessage.OwnerDraw = true; // Chọn chế độ vẽ tùy chỉnh
            lsvMessage.DrawItem += lsvMessage_DrawItem;
            Connect();
        }
        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;
        void Connect()
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 1997);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            server.Bind(IP);

            Thread listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);
                        AddMessage("Client connected "); /*+ client.RemoteEndPoint.ToString())*/
                        aes.GenerateKey();
                        byte[] keyMessage = aes.Key;
                        clientAesKeys[client] = keyMessage; // Store AES key for the client
                        client.Send(keyMessage); // Send AES key to the client
                        // Create a separate thread to receive data from the client
                        Thread receive = new Thread(() => Receive(client));
                        receive.IsBackground = true;
                        receive.Start();

                     
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 1997);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            listen.IsBackground = true;
            listen.Start();
        }
        void Close()
        {
            server.Close();
        }

        void Receive(Socket client)
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    int bytesRead = client.Receive(data);

                    // Check if data was received
                    if (bytesRead > 0)
                    {
                        string message = Encoding.UTF8.GetString(data.Take(bytesRead).ToArray());

                        if (message.StartsWith("IP:"))
                        {
                            string encryptedIPBase64 = message.Substring(3);

                            // Giải mã IP bằng khóa AES tương ứng
                            if (clientAesKeys.ContainsKey(client))
                            {
                                byte[] encryptedIP = Convert.FromBase64String(encryptedIPBase64);
                                string decryptedIP = DecryptIP(encryptedIP, clientAesKeys[client]); // Decrypt IP
                                AddMessage($"Client sent decrypted IP: {decryptedIP}");
                            }
                            else
                            {
                                AddMessage("No AES key available to decrypt IP.");
                            }
                        }

                        else if (message.StartsWith("MSG:"))
                        {
                            // Extract the message content without decrypting it
                            string encryptedMessageBase64 = message.Substring(4);
                            string encryptedClientIPBase64 = Convert.ToBase64String(EncryptMessage(client.RemoteEndPoint.ToString(), clientAesKeys[client]));
                            AddMessage ("Client IP: " + encryptedClientIPBase64 + ") sent message :  " + encryptedMessageBase64);

                            // Send the encrypted message to all other clients
                            foreach (Socket otherClient in clientList)
                            {
                                if (otherClient != client) // Do not send back to the sender
                                {
                                    if (clientAesKeys.ContainsKey(otherClient))
                                    {
                                        byte[] encryptedMessage = EncryptMessage(DecryptMessage(Convert.FromBase64String(encryptedMessageBase64), clientAesKeys[client]), clientAesKeys[otherClient]);
                                        string messageToSend = "MSG:" + Convert.ToBase64String(encryptedMessage);
                                        byte[] dataToSend = Encoding.UTF8.GetBytes(messageToSend);
                                        otherClient.Send(dataToSend);
                                    }
                                    else
                                    {
                                        AddMessage("No AES key for client: " + otherClient.RemoteEndPoint.ToString());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        AddMessage("No data received.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Show message when a client disconnects
                string encryptedClientIPBase64 = Convert.ToBase64String(EncryptMessage(client.RemoteEndPoint.ToString(), clientAesKeys[client]));
                AddMessage("Client disconnected: " + encryptedClientIPBase64);
                clientList.Remove(client);
                client.Close();
                if (clientAesKeys.ContainsKey(client))
                {
                    clientAesKeys.Remove(client);
                }
            }
        }
        byte[] EncryptMessage(string message, byte[] key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.GenerateIV();
                using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        // Write IV to the stream for later decryption
                        msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(message);
                            }
                            return msEncrypt.ToArray();
                        }
                    }
                }
            }
        }

        string DecryptMessage(byte[] cipherText, byte[] key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;

                // The IV is the first 16 bytes of the cipher text
                byte[] iv = cipherText.Take(16).ToArray();
                aesAlg.IV = iv;

                using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                {
                    using (var msDecrypt = new MemoryStream(cipherText.Skip(16).ToArray()))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
        // Hàm mã hóa IP với AES
        public byte[] EncryptIP(string ip, byte[] key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV();
                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length); // Ghi IV vào đầu stream
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(ip);
                    }
                    return ms.ToArray();
                }
            }
        }

        // Hàm giải mã IP với AES
        public string DecryptIP(byte[] encryptedIP, byte[] key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;

                // The IV is the first 16 bytes of the cipher text
                byte[] iv = encryptedIP.Take(16).ToArray();
                aesAlg.IV = iv;

                using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                using (var msDecrypt = new MemoryStream(encryptedIP.Skip(16).ToArray()))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
        void ReceiveFile(Socket client, string fileName)
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
            string fileName = Path.GetFileName(filePath);
            byte[] fileHeader = Serialize("FILE:" + fileName);
            byte[] fileData = File.ReadAllBytes(filePath);

            foreach (Socket client in clientList)
            {
                if (client != null && client.Connected)
                {
                    client.Send(fileHeader);

                    await Task.Run(() => client.Send(fileData));
                }
            }

            AddMessage($"File sent: {fileName}");
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void lsvMessage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lsvMessage_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Lấy địa chỉ IP từ text
            string itemText = e.Item.Text;

            // Chọn màu sắc dựa trên địa chỉ IP
            Color itemColor;
            if (itemText.Contains("Client 1"))
            {
                itemColor = Color.Red; // Màu cho Client 1
            }
            else if (itemText.Contains("Client 2"))
            {
                itemColor = Color.Green; // Màu cho Client 2
            }
            else
            {
                itemColor = Color.Black; // Mặc định màu đen cho các client khác
            }

            // Vẽ item với màu đã chọn
            e.DrawBackground();
            using (Brush brush = new SolidBrush(itemColor))
            {
                e.Graphics.DrawString(itemText, e.Item.Font, brush, e.Bounds);
            }
            e.DrawFocusRectangle();
        }
    }
}
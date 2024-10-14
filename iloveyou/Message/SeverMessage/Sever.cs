using System;
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
                        AddMessage("Client connected: " + client.RemoteEndPoint.ToString());
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

                        if (message.StartsWith("MSG:"))
                        {
                            // Extract the message content without decrypting it
                            string encryptedMessageBase64 = message.Substring(4);
                            AddMessage("Client " + client.RemoteEndPoint.ToString() + " sent an encrypted message: " + encryptedMessageBase64);

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
                AddMessage("Client disconnected: " + client.RemoteEndPoint.ToString());
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
    }
}

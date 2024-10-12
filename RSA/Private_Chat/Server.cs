using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Private_Chat
{
    public partial class Server : Form
    {
        private RSACryptoServiceProvider rsaProvider;
        private string publicKey;
        private string privateKey;

        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            GenerateRSAKeys(); // Create RSA key pair
            Connect();
        }

        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;

        void GenerateRSAKeys()
        {
            rsaProvider = new RSACryptoServiceProvider(2048);
            publicKey = rsaProvider.ToXmlString(false); // Public key only
            privateKey = rsaProvider.ToXmlString(true); // Both public and private keys
        }

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

                        // Show message when a client connects
                        AddMessage("Client connected: " + client.RemoteEndPoint.ToString());

                        // Create a separate thread to receive data from the client
                        Thread receive = new Thread(() => Receive(client));
                        receive.IsBackground = true;
                        receive.Start();
                    }
                }
                catch (Exception ex)
                {
                    AddMessage("Error: " + ex.Message);
                }
            });
            listen.IsBackground = true;
            listen.Start();
        }

        void Close()
        {
            server.Close();
        }

        // Receive encrypted message from client and send to all other clients
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
                        // Convert byte[] to base64 string
                        string encryptedMessageBase64 = Convert.ToBase64String(data.Take(bytesRead).ToArray());

                        // Display the received encrypted message
                        AddMessage("[Encrypted Message] " + encryptedMessageBase64);

                        // Check if the message is a regular message
                        if (encryptedMessageBase64.StartsWith("MSG:"))
                        {
                            // Send the encrypted message to all other clients
                            foreach (Socket otherClient in clientList)
                            {
                                if (otherClient != client) // Do not send back to the sender
                                {
                                    otherClient.Send(data.Take(bytesRead).ToArray());
                                }
                            }
                        }
                        else if (encryptedMessageBase64.StartsWith("FILE:"))
                        {
                            string fileName = encryptedMessageBase64.Substring(5);
                            ReceiveFile(client, fileName); // Receive file from client
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

        // Add message to ListView
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}

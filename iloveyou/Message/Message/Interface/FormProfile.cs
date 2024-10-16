﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Message.Properties;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Security.Cryptography;
using Message;
using System.Net.NetworkInformation;
namespace Message
{
    public partial class FormProfile : Form
    {
        public string emailname {set;get ;}
        public string username { set;get ;}
        private Aes aes;
        private byte[] aesKey; // Store the AES key received from the server

        public FormProfile()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            aes = Aes.Create();
    
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        string constring = "Data Source=LAPTOP-AA3MGNUM\\SQLEXPRESS;Initial Catalog=dd;Integrated Security=True;TrustServerCertificate=True";
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            FormLogin f1=new FormLogin();
            this.Hide();
            f1.Show();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = emailname;
            byte[] getimage = new byte[0];
            SqlConnection con= new SqlConnection(constring);
            con.Open();
            string q = "Select * from Login WHERE email = '" + label2.Text + "'";
            SqlCommand cmd= new SqlCommand(q, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                username = dataReader["username"].ToString();
                label2.Text = dataReader["email"].ToString();
                guna2TextBox1.Text = dataReader["username"].ToString();
                guna2TextBox2.Text = dataReader["email"].ToString();
                guna2TextBox3.Text = dataReader["password"].ToString();
                guna2TextBox4.Text= dataReader["username"].ToString();
                byte[] images = (byte[])dataReader["image"];
                if (images == null)
                {
                    guna2CirclePictureBox1.Image= null;
                    guna2CirclePictureBox2.Image= null;

                }
                else
                {
                    MemoryStream me = new MemoryStream(images);
                    guna2CirclePictureBox1.Image=Image.FromStream(me);
                    guna2CirclePictureBox2.Image= Image.FromStream(me);

                }
            }
            panel6.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            con.Close();
            lsvMessage1.View = View.Details;
            lsvMessage1.Columns.Add("User", lsvMessage1.Width / 2 - 5, HorizontalAlignment.Left);  // Cột tin nhắn người khác
            lsvMessage1.Columns.Add("Me", lsvMessage1.Width / 2 - 5, HorizontalAlignment.Right);  // Cột tin nhắn của bạn
            lsvMessage1.HeaderStyle = ColumnHeaderStyle.None;  // Ẩn tiêu đề
            lsvMessage1.Font = new Font("Times New Roman", 14, FontStyle.Regular); // Thay đổi font chữ
        }
        private bool check;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                panel2.Width += 10;
                if(panel2.Size== panel2.MaximumSize)
                {
                    pictureBox1.Left = +230;
                    timer1.Stop();
                    check=false;
                    pictureBox1.Image = Resources.download__6_;
                }
            }
            else
            {
                panel2.Width -= 10;
                if(panel2.Size== panel2.MinimumSize)
                {
                    pictureBox1.Left = 23;
                    timer1.Stop();
                    check = true;
                    pictureBox1.Image = Resources.download__3_;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == false)
            {
                panel5.Visible = true;
            }
            else
            {
                panel5.Visible = false;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (panel6.Visible == false)
            {
                panel6.Visible = true;
            }
            else
            {
                panel6.Visible = false;
            }
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
            aesKey = new byte[32]; // AES key size is 256 bits (32 bytes)
            client.Receive(aesKey); // Receive AES key from the server


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
            if (!string.IsNullOrEmpty(txtMessage1.Text))
            {
                string fullMessage = $"{username}: {txtMessage1.Text}";
                byte[] encryptedMessage = EncryptMessage(fullMessage, aesKey);
                string encryptedMessageBase64 = Convert.ToBase64String(encryptedMessage);
                string messageToSend = "MSG:" + encryptedMessageBase64;
                byte[] dataToSend = Encoding.UTF8.GetBytes(messageToSend);

                client.Send(dataToSend);
                AddMessage(fullMessage); // Hiển thị tin nhắn đã gửi
                txtMessage1.Clear();

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
                            string encryptedMessageBase64 = message.Substring(4);
                            byte[] encryptedData = Convert.FromBase64String(encryptedMessageBase64);
                            // Decrypt message using client's AES key
                            string decryptedMessage = DecryptMessage(encryptedData, aesKey);
                            AddMessage(decryptedMessage); // Display decrypted message

                        }
                    }
                }
            }
            catch
            {
                Close();
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
        private StringBuilder messages = new StringBuilder();
        void AddMessage(string message)
        {
            ListViewItem item;

            if (message.StartsWith($"{username}:")) // Tin nhắn của bạn
            {
                item = new ListViewItem(new[] { "", message });
                item.ForeColor = Color.White;
                item.Font = new Font("Times New Roman", 14, FontStyle.Regular); // Thay đổi font chữ
            }
            else // Tin nhắn từ người khác
            {
                item = new ListViewItem(new[] { message, "" });
                item.ForeColor = Color.White;
                item.Font = new Font("Times New Roman", 14, FontStyle.Regular); // Thay đổi font chữ
            }

            lsvMessage1.Items.Add(item);  // Thêm vào ListView
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

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            Send();
        }

        private async void btnFile_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                await SendFileAsync(ofd.FileName);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            Connect();
        }
    }
}

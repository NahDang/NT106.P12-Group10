using System;
using System.IO;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace Bai1
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void bt_DocFile_Click(object sender, EventArgs e)
        {
            // Tạo OpenFileDialog để người dùng chọn file .txt hoặc .docx
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files|*.txt|Word Documents|*.docx",
                Title = "Chọn file văn bản (.txt hoặc .docx)"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Kiểm tra loại file
                    if (Path.GetExtension(filePath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        // Đọc nội dung từ file .txt
                        string fileContent = File.ReadAllText(filePath);
                        richTextBox1.Text = fileContent;
                    }
                    else if (Path.GetExtension(filePath).Equals(".docx", StringComparison.OrdinalIgnoreCase))
                    {
                        // Sử dụng DocX để mở file và đọc nội dung
                        using (DocX document = DocX.Load(filePath))
                        {
                            // Đọc toàn bộ văn bản từ file .docx
                            string fileContent = document.Text;

                            // Hiển thị nội dung trong RichTextBox
                            richTextBox1.Text = fileContent;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi đọc file: " + ex.Message);
                }
            }
        }

        private void bt_GhiFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy nội dung từ richTextBox1
                string contentToWrite = richTextBox1.Text.ToUpper();  // Chuyển nội dung thành in hoa

                // Sử dụng SaveFileDialog để chọn nơi lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Text Files|*.txt|Word Documents|*.docx",
                    Title = "Lưu file văn bản"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Kiểm tra loại file để ghi
                    if (Path.GetExtension(filePath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        // Ghi nội dung vào file .txt
                        File.WriteAllText(filePath, contentToWrite);
                    }
                    else if (Path.GetExtension(filePath).Equals(".docx", StringComparison.OrdinalIgnoreCase))
                    {
                        // Tạo một file .docx mới và ghi nội dung vào
                        using (DocX document = DocX.Create(filePath))
                        {
                            document.InsertParagraph(contentToWrite);
                            document.Save();
                        }
                    }

                    MessageBox.Show("Ghi file thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi ghi file: " + ex.Message);
            }
        }
    }
}

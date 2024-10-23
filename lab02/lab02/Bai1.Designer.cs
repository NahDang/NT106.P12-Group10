namespace lab02
{
    partial class Bai1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_GhiFile = new System.Windows.Forms.Button();
            this.bt_DocFile = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // bt_GhiFile
            // 
            this.bt_GhiFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.bt_GhiFile.Location = new System.Drawing.Point(88, 484);
            this.bt_GhiFile.Name = "bt_GhiFile";
            this.bt_GhiFile.Size = new System.Drawing.Size(273, 169);
            this.bt_GhiFile.TabIndex = 0;
            this.bt_GhiFile.Text = "Ghi File";
            this.bt_GhiFile.UseVisualStyleBackColor = true;
            this.bt_GhiFile.Click += new System.EventHandler(this.bt_GhiFile_Click);
            // 
            // bt_DocFile
            // 
            this.bt_DocFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.bt_DocFile.Location = new System.Drawing.Point(88, 129);
            this.bt_DocFile.Name = "bt_DocFile";
            this.bt_DocFile.Size = new System.Drawing.Size(273, 169);
            this.bt_DocFile.TabIndex = 1;
            this.bt_DocFile.Text = "Doc File";
            this.bt_DocFile.UseVisualStyleBackColor = true;
            this.bt_DocFile.Click += new System.EventHandler(this.bt_DocFile_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.richTextBox1.Location = new System.Drawing.Point(487, 129);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(851, 524);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // Bai1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 766);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.bt_DocFile);
            this.Controls.Add(this.bt_GhiFile);
            this.Name = "Bai1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_GhiFile;
        private System.Windows.Forms.Button bt_DocFile;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
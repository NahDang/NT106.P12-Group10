namespace Bai3
{
    partial class Bai03
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
            this.readfile = new System.Windows.Forms.Button();
            this.writefile = new System.Windows.Forms.Button();
            this.rtbRead = new System.Windows.Forms.TextBox();
            this.rtbWrite = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // readfile
            // 
            this.readfile.Location = new System.Drawing.Point(22, 44);
            this.readfile.Name = "readfile";
            this.readfile.Size = new System.Drawing.Size(218, 123);
            this.readfile.TabIndex = 0;
            this.readfile.Text = "Read File";
            this.readfile.UseVisualStyleBackColor = true;
            this.readfile.Click += new System.EventHandler(this.readfile_Click);
            // 
            // writefile
            // 
            this.writefile.Location = new System.Drawing.Point(22, 360);
            this.writefile.Name = "writefile";
            this.writefile.Size = new System.Drawing.Size(218, 123);
            this.writefile.TabIndex = 1;
            this.writefile.Text = "Write File";
            this.writefile.UseVisualStyleBackColor = true;
            this.writefile.Click += new System.EventHandler(this.writefile_Click);
            // 
            // rtbRead
            // 
            this.rtbRead.Location = new System.Drawing.Point(257, 44);
            this.rtbRead.Multiline = true;
            this.rtbRead.Name = "rtbRead";
            this.rtbRead.Size = new System.Drawing.Size(728, 257);
            this.rtbRead.TabIndex = 4;
            // 
            // rtbWrite
            // 
            this.rtbWrite.Location = new System.Drawing.Point(257, 360);
            this.rtbWrite.Multiline = true;
            this.rtbWrite.Name = "rtbWrite";
            this.rtbWrite.Size = new System.Drawing.Size(728, 257);
            this.rtbWrite.TabIndex = 5;
            // 
            // Bai03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1965, 763);
            this.Controls.Add(this.rtbWrite);
            this.Controls.Add(this.rtbRead);
            this.Controls.Add(this.writefile);
            this.Controls.Add(this.readfile);
            this.Name = "Bai03";
            this.Text = "Bai03";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readfile;
        private System.Windows.Forms.Button writefile;
        private System.Windows.Forms.TextBox rtbRead;
        private System.Windows.Forms.TextBox rtbWrite;
    }
}


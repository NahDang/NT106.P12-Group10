namespace FileExplorer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textPath = new System.Windows.Forms.TextBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonBack.Location = new System.Drawing.Point(8, 15);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(41, 26);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "<<";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonForward
            // 
            this.buttonForward.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonForward.Location = new System.Drawing.Point(47, 15);
            this.buttonForward.Margin = new System.Windows.Forms.Padding(2);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(40, 26);
            this.buttonForward.TabIndex = 1;
            this.buttonForward.Text = ">>";
            this.buttonForward.UseVisualStyleBackColor = false;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonOpen.Location = new System.Drawing.Point(745, 15);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(93, 26);
            this.buttonOpen.TabIndex = 2;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = false;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Path:";
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(132, 19);
            this.textPath.Margin = new System.Windows.Forms.Padding(2);
            this.textPath.Multiline = true;
            this.textPath.Name = "textPath";
            this.textPath.ReadOnly = true;
            this.textPath.Size = new System.Drawing.Size(611, 21);
            this.textPath.TabIndex = 4;
            // 
            // webBrowser
            // 
            this.webBrowser.ContextMenuStrip = this.contextMenuStrip1;
            this.webBrowser.Location = new System.Drawing.Point(8, 45);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser.MinimumSize = new System.Drawing.Size(13, 13);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(830, 519);
            this.webBrowser.TabIndex = 5;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.cutToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 128);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.copyToolStripMenuItem.Text = "&copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.pasteToolStripMenuItem.Text = "&paste";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.deleteToolStripMenuItem.Text = "&delete";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.cutToolStripMenuItem.Text = "&cut";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 572);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonForward);
            this.Controls.Add(this.buttonBack);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "File Explorer";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonForward;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
    }
}


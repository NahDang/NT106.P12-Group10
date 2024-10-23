namespace lab02
{
    partial class Bai05
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TV1 = new System.Windows.Forms.TreeView();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.ptBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ptBox);
            this.groupBox1.Controls.Add(this.txtBox);
            this.groupBox1.Location = new System.Drawing.Point(192, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 836);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Content";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // TV1
            // 
            this.TV1.Location = new System.Drawing.Point(-1, 26);
            this.TV1.Name = "TV1";
            this.TV1.Size = new System.Drawing.Size(187, 532);
            this.TV1.TabIndex = 2;
            this.TV1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.TV1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.TV1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // txtBox
            // 
            this.txtBox.BackColor = System.Drawing.SystemColors.Control;
            this.txtBox.Location = new System.Drawing.Point(0, 15);
            this.txtBox.Multiline = true;
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(830, 814);
            this.txtBox.TabIndex = 0;
            this.txtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ptBox
            // 
            this.ptBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptBox.Location = new System.Drawing.Point(0, 21);
            this.ptBox.Name = "ptBox";
            this.ptBox.Size = new System.Drawing.Size(817, 808);
            this.ptBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptBox.TabIndex = 1;
            this.ptBox.TabStop = false;
            // 
            // Bai05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 853);
            this.Controls.Add(this.TV1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Bai05";
            this.Text = "Bai05";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Bai05_MouseDoubleClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView TV1;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.PictureBox ptBox;
    }
}
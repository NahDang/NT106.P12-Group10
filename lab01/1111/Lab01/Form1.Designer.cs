﻿namespace Lab01
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
            this.buttonBai1 = new System.Windows.Forms.Button();
            this.buttonBai2 = new System.Windows.Forms.Button();
            this.buttonBai3 = new System.Windows.Forms.Button();
            this.buttonBai4 = new System.Windows.Forms.Button();
            this.buttonBai5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBai1
            // 
            this.buttonBai1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonBai1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonBai1.Location = new System.Drawing.Point(75, 79);
            this.buttonBai1.Name = "buttonBai1";
            this.buttonBai1.Size = new System.Drawing.Size(210, 50);
            this.buttonBai1.TabIndex = 0;
            this.buttonBai1.Text = "Bài 1";
            this.buttonBai1.UseVisualStyleBackColor = false;
            this.buttonBai1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonBai2
            // 
            this.buttonBai2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonBai2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonBai2.Location = new System.Drawing.Point(483, 79);
            this.buttonBai2.Name = "buttonBai2";
            this.buttonBai2.Size = new System.Drawing.Size(210, 50);
            this.buttonBai2.TabIndex = 1;
            this.buttonBai2.Text = "Bài 2";
            this.buttonBai2.UseVisualStyleBackColor = false;
            // 
            // buttonBai3
            // 
            this.buttonBai3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonBai3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonBai3.Location = new System.Drawing.Point(75, 180);
            this.buttonBai3.Name = "buttonBai3";
            this.buttonBai3.Size = new System.Drawing.Size(210, 50);
            this.buttonBai3.TabIndex = 2;
            this.buttonBai3.Text = "Bài 3";
            this.buttonBai3.UseVisualStyleBackColor = false;
            // 
            // buttonBai4
            // 
            this.buttonBai4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonBai4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonBai4.Location = new System.Drawing.Point(483, 180);
            this.buttonBai4.Name = "buttonBai4";
            this.buttonBai4.Size = new System.Drawing.Size(210, 50);
            this.buttonBai4.TabIndex = 3;
            this.buttonBai4.Text = "Bài 4";
            this.buttonBai4.UseVisualStyleBackColor = false;
            // 
            // buttonBai5
            // 
            this.buttonBai5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonBai5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonBai5.Location = new System.Drawing.Point(277, 292);
            this.buttonBai5.Name = "buttonBai5";
            this.buttonBai5.Size = new System.Drawing.Size(210, 50);
            this.buttonBai5.TabIndex = 4;
            this.buttonBai5.Text = "Bài 5";
            this.buttonBai5.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Note : Vui lòng chọn một bài để xem";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBai5);
            this.Controls.Add(this.buttonBai4);
            this.Controls.Add(this.buttonBai3);
            this.Controls.Add(this.buttonBai2);
            this.Controls.Add(this.buttonBai1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBai1;
        private System.Windows.Forms.Button buttonBai2;
        private System.Windows.Forms.Button buttonBai3;
        private System.Windows.Forms.Button buttonBai4;
        private System.Windows.Forms.Button buttonBai5;
        private System.Windows.Forms.Label label1;
    }
}

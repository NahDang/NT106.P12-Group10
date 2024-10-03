using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System;

namespace Lab01
{
    partial class Form2Bai05
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
            this.textBoxMon3 = new System.Windows.Forms.TextBox();
            this.textBoxMon2 = new System.Windows.Forms.TextBox();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxMon1 = new System.Windows.Forms.TextBox();
            this.comboBoxPhai = new System.Windows.Forms.ComboBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonThongKe = new System.Windows.Forms.Button();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MediumVioletRed;
            this.groupBox1.Controls.Add(this.textBoxMon3);
            this.groupBox1.Controls.Add(this.textBoxMon2);
            this.groupBox1.Controls.Add(this.buttonXoa);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.textBoxMon1);
            this.groupBox1.Controls.Add(this.comboBoxPhai);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(33, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(830, 284);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập Thí Sinh";
            // 
            // textBoxMon3
            // 
            this.textBoxMon3.Location = new System.Drawing.Point(644, 175);
            this.textBoxMon3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxMon3.Name = "textBoxMon3";
            this.textBoxMon3.Size = new System.Drawing.Size(175, 35);
            this.textBoxMon3.TabIndex = 6;
            // 
            // textBoxMon2
            // 
            this.textBoxMon2.Location = new System.Drawing.Point(644, 123);
            this.textBoxMon2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxMon2.Name = "textBoxMon2";
            this.textBoxMon2.Size = new System.Drawing.Size(175, 35);
            this.textBoxMon2.TabIndex = 7;
            // 
            // buttonXoa
            // 
            this.buttonXoa.BackColor = System.Drawing.Color.Transparent;
            this.buttonXoa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXoa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonXoa.Location = new System.Drawing.Point(130, 231);
            this.buttonXoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(112, 41);
            this.buttonXoa.TabIndex = 3;
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.UseVisualStyleBackColor = false;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSave.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSave.Location = new System.Drawing.Point(9, 231);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(112, 44);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Lưu";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxMon1
            // 
            this.textBoxMon1.Location = new System.Drawing.Point(644, 72);
            this.textBoxMon1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxMon1.Name = "textBoxMon1";
            this.textBoxMon1.Size = new System.Drawing.Size(175, 35);
            this.textBoxMon1.TabIndex = 5;
            // 
            // comboBoxPhai
            // 
            this.comboBoxPhai.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPhai.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPhai.FormattingEnabled = true;
            this.comboBoxPhai.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.comboBoxPhai.Location = new System.Drawing.Point(147, 141);
            this.comboBoxPhai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxPhai.Name = "comboBoxPhai";
            this.comboBoxPhai.Size = new System.Drawing.Size(276, 35);
            this.comboBoxPhai.TabIndex = 1;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(147, 70);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(276, 35);
            this.textBoxName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(494, 180);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 33);
            this.label5.TabIndex = 4;
            this.label5.Text = "Điểm môn 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(80, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phái";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(494, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "Điểm môn 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(22, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Họ và Tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(494, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Điểm môn 1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.HotPink;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 439);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1856, 498);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.MediumVioletRed;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(18, 405);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 33);
            this.label7.TabIndex = 3;
            this.label7.Text = "Danh Sách Thí Sinh";
            // 
            // buttonThongKe
            // 
            this.buttonThongKe.BackColor = System.Drawing.Color.MediumVioletRed;
            this.buttonThongKe.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThongKe.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonThongKe.Location = new System.Drawing.Point(894, 69);
            this.buttonThongKe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonThongKe.Name = "buttonThongKe";
            this.buttonThongKe.Size = new System.Drawing.Size(177, 88);
            this.buttonThongKe.TabIndex = 4;
            this.buttonThongKe.Text = "Thống Kê";
            this.buttonThongKe.UseVisualStyleBackColor = false;
            this.buttonThongKe.Click += new System.EventHandler(this.buttonThongKe_Click_1);
            // 
            // buttonThoat
            // 
            this.buttonThoat.BackColor = System.Drawing.Color.MediumVioletRed;
            this.buttonThoat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThoat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonThoat.Location = new System.Drawing.Point(894, 222);
            this.buttonThoat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(177, 88);
            this.buttonThoat.TabIndex = 6;
            this.buttonThoat.Text = "Thoat";
            this.buttonThoat.UseVisualStyleBackColor = false;
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // Form2Bai05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Lab01.Properties.Resources.pink_pastel_background_fubdyima1gpioo62;
            this.ClientSize = new System.Drawing.Size(1906, 982);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.buttonThongKe);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2Bai05";
            this.Text = "Bai05-QuanLiThiSinhDuThi";
            this.Load += new System.EventHandler(this.Form2Bai05_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxPhai;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonThongKe;
        private System.Windows.Forms.TextBox textBoxMon3;
        private System.Windows.Forms.TextBox textBoxMon2;
        private System.Windows.Forms.TextBox textBoxMon1;
        private Button buttonThoat;
    }
}
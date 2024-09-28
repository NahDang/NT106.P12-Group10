namespace Lab01
{
    partial class Form6Bai04
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNgay = new System.Windows.Forms.TextBox();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.btKQ = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(433, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(47, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập tháng";
            // 
            // txtNgay
            // 
            this.txtNgay.Font = new System.Drawing.Font("Times New Roman", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtNgay.Location = new System.Drawing.Point(586, 79);
            this.txtNgay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(159, 38);
            this.txtNgay.TabIndex = 2;
            this.txtNgay.TextChanged += new System.EventHandler(this.txtNgay_TextChanged);
            // 
            // txtThang
            // 
            this.txtThang.Font = new System.Drawing.Font("Times New Roman", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtThang.Location = new System.Drawing.Point(211, 79);
            this.txtThang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(167, 38);
            this.txtThang.TabIndex = 3;
            // 
            // txtKetQua
            // 
            this.txtKetQua.Font = new System.Drawing.Font("Times New Roman", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtKetQua.Location = new System.Drawing.Point(63, 256);
            this.txtKetQua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKetQua.Multiline = true;
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(681, 144);
            this.txtKetQua.TabIndex = 4;
            // 
            // btKQ
            // 
            this.btKQ.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btKQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btKQ.Location = new System.Drawing.Point(123, 180);
            this.btKQ.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btKQ.Name = "btKQ";
            this.btKQ.Size = new System.Drawing.Size(197, 49);
            this.btKQ.TabIndex = 5;
            this.btKQ.Text = "KẾT QUẢ";
            this.btKQ.UseVisualStyleBackColor = false;
            this.btKQ.Click += new System.EventHandler(this.btKQ_Click);
            // 
            // btThoat
            // 
            this.btThoat.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btThoat.Location = new System.Drawing.Point(463, 180);
            this.btThoat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(197, 49);
            this.btThoat.TabIndex = 6;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = false;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // Form6Bai04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btKQ);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.txtNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form6Bai04";
            this.Text = "Bai4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNgay;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.Button btKQ;
        private System.Windows.Forms.Button btThoat;
    }
}
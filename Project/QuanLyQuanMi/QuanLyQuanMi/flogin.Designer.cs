namespace QuanLyQuanMi
{
    partial class flogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(flogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtThoat = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TextBoxMatKhau = new System.Windows.Forms.TextBox();
            this.MatKhau = new System.Windows.Forms.Label();
            this.BtDangNhap = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TextBoxDangNhap = new System.Windows.Forms.TextBox();
            this.TenDangNhap = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.BtThoat);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.BtDangNhap);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-6, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 384);
            this.panel1.TabIndex = 0;
            // 
            // BtThoat
            // 
            this.BtThoat.BackColor = System.Drawing.Color.OldLace;
            this.BtThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtThoat.Location = new System.Drawing.Point(479, 204);
            this.BtThoat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtThoat.Name = "BtThoat";
            this.BtThoat.Size = new System.Drawing.Size(187, 96);
            this.BtThoat.TabIndex = 2;
            this.BtThoat.Text = "Thoát";
            this.BtThoat.UseVisualStyleBackColor = false;
            this.BtThoat.Click += new System.EventHandler(this.BtThoat_Click_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TextBoxMatKhau);
            this.panel3.Controls.Add(this.MatKhau);
            this.panel3.Location = new System.Drawing.Point(18, 116);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(652, 48);
            this.panel3.TabIndex = 1;
            // 
            // TextBoxMatKhau
            // 
            this.TextBoxMatKhau.Location = new System.Drawing.Point(270, 5);
            this.TextBoxMatKhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxMatKhau.Name = "TextBoxMatKhau";
            this.TextBoxMatKhau.Size = new System.Drawing.Size(376, 31);
            this.TextBoxMatKhau.TabIndex = 1;
            this.TextBoxMatKhau.UseSystemPasswordChar = true;
            // 
            // MatKhau
            // 
            this.MatKhau.AutoSize = true;
            this.MatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatKhau.Location = new System.Drawing.Point(9, 8);
            this.MatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.Size = new System.Drawing.Size(155, 32);
            this.MatKhau.TabIndex = 0;
            this.MatKhau.Text = "Mật khẩu: ";
            // 
            // BtDangNhap
            // 
            this.BtDangNhap.BackColor = System.Drawing.Color.OldLace;
            this.BtDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtDangNhap.Location = new System.Drawing.Point(275, 204);
            this.BtDangNhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtDangNhap.Name = "BtDangNhap";
            this.BtDangNhap.Size = new System.Drawing.Size(187, 96);
            this.BtDangNhap.TabIndex = 1;
            this.BtDangNhap.Text = "Đăng nhập";
            this.BtDangNhap.UseVisualStyleBackColor = false;
            this.BtDangNhap.Click += new System.EventHandler(this.BtDangNhap_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TextBoxDangNhap);
            this.panel2.Controls.Add(this.TenDangNhap);
            this.panel2.Location = new System.Drawing.Point(22, 23);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(648, 83);
            this.panel2.TabIndex = 0;
            // 
            // TextBoxDangNhap
            // 
            this.TextBoxDangNhap.Location = new System.Drawing.Point(266, 28);
            this.TextBoxDangNhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxDangNhap.Name = "TextBoxDangNhap";
            this.TextBoxDangNhap.Size = new System.Drawing.Size(376, 31);
            this.TextBoxDangNhap.TabIndex = 1;
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.AutoSize = true;
            this.TenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenDangNhap.Location = new System.Drawing.Point(4, 28);
            this.TenDangNhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TenDangNhap.Name = "TenDangNhap";
            this.TenDangNhap.Size = new System.Drawing.Size(235, 32);
            this.TenDangNhap.TabIndex = 0;
            this.TenDangNhap.Text = "Tên đăng nhập: ";
            // 
            // flogin
            // 
            this.AcceptButton = this.BtDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtThoat;
            this.ClientSize = new System.Drawing.Size(758, 383);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "flogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.flogin_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TenDangNhap;
        private System.Windows.Forms.TextBox TextBoxDangNhap;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox TextBoxMatKhau;
        private System.Windows.Forms.Label MatKhau;
        private System.Windows.Forms.Button BtThoat;
        private System.Windows.Forms.Button BtDangNhap;
    }
}


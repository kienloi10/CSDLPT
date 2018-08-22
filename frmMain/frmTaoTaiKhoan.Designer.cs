namespace frmMain
{
    partial class frmTaoTaiKhoan
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
            this.Hủy = new System.Windows.Forms.Button();
            this.btnTao = new System.Windows.Forms.Button();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtTenTaiKhoan = new System.Windows.Forms.TextBox();
            this.cmbDSChuaTao = new System.Windows.Forms.ComboBox();
            this.radioButtonSinhVien = new System.Windows.Forms.RadioButton();
            this.radioButtonCoSo = new System.Windows.Forms.RadioButton();
            this.radioButtonGiangVien = new System.Windows.Forms.RadioButton();
            this.radioButtonTruong = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Hủy);
            this.groupBox1.Controls.Add(this.btnTao);
            this.groupBox1.Controls.Add(this.txtMatKhau);
            this.groupBox1.Controls.Add(this.txtTenDangNhap);
            this.groupBox1.Controls.Add(this.txtTenTaiKhoan);
            this.groupBox1.Controls.Add(this.cmbDSChuaTao);
            this.groupBox1.Controls.Add(this.radioButtonSinhVien);
            this.groupBox1.Controls.Add(this.radioButtonCoSo);
            this.groupBox1.Controls.Add(this.radioButtonGiangVien);
            this.groupBox1.Controls.Add(this.radioButtonTruong);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(103, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(808, 376);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Hủy
            // 
            this.Hủy.Location = new System.Drawing.Point(430, 311);
            this.Hủy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Hủy.Name = "Hủy";
            this.Hủy.Size = new System.Drawing.Size(81, 33);
            this.Hủy.TabIndex = 4;
            this.Hủy.Text = "Hủy";
            this.Hủy.UseVisualStyleBackColor = true;
            this.Hủy.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTao
            // 
            this.btnTao.Location = new System.Drawing.Point(274, 311);
            this.btnTao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(73, 33);
            this.btnTao.TabIndex = 4;
            this.btnTao.Text = "Tạo";
            this.btnTao.UseVisualStyleBackColor = true;
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(301, 262);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(212, 20);
            this.txtMatKhau.TabIndex = 3;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(301, 221);
            this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(212, 20);
            this.txtTenDangNhap.TabIndex = 3;
            // 
            // txtTenTaiKhoan
            // 
            this.txtTenTaiKhoan.Location = new System.Drawing.Point(301, 181);
            this.txtTenTaiKhoan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            this.txtTenTaiKhoan.Size = new System.Drawing.Size(212, 20);
            this.txtTenTaiKhoan.TabIndex = 3;
            this.txtTenTaiKhoan.TextChanged += new System.EventHandler(this.txtTenTaiKhoan_TextChanged);
            // 
            // cmbDSChuaTao
            // 
            this.cmbDSChuaTao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDSChuaTao.FormattingEnabled = true;
            this.cmbDSChuaTao.Location = new System.Drawing.Point(301, 132);
            this.cmbDSChuaTao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbDSChuaTao.Name = "cmbDSChuaTao";
            this.cmbDSChuaTao.Size = new System.Drawing.Size(212, 21);
            this.cmbDSChuaTao.TabIndex = 2;
            this.cmbDSChuaTao.SelectedIndexChanged += new System.EventHandler(this.cmbDSChuaTao_SelectedIndexChanged);
            // 
            // radioButtonSinhVien
            // 
            this.radioButtonSinhVien.AutoSize = true;
            this.radioButtonSinhVien.Location = new System.Drawing.Point(446, 89);
            this.radioButtonSinhVien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonSinhVien.Name = "radioButtonSinhVien";
            this.radioButtonSinhVien.Size = new System.Drawing.Size(69, 17);
            this.radioButtonSinhVien.TabIndex = 1;
            this.radioButtonSinhVien.TabStop = true;
            this.radioButtonSinhVien.Text = "Sinh viên";
            this.radioButtonSinhVien.UseVisualStyleBackColor = true;
            this.radioButtonSinhVien.CheckedChanged += new System.EventHandler(this.radioButtonSinhVien_CheckedChanged);
            // 
            // radioButtonCoSo
            // 
            this.radioButtonCoSo.AutoSize = true;
            this.radioButtonCoSo.Location = new System.Drawing.Point(446, 44);
            this.radioButtonCoSo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonCoSo.Name = "radioButtonCoSo";
            this.radioButtonCoSo.Size = new System.Drawing.Size(52, 17);
            this.radioButtonCoSo.TabIndex = 1;
            this.radioButtonCoSo.TabStop = true;
            this.radioButtonCoSo.Text = "Cơ sở";
            this.radioButtonCoSo.UseVisualStyleBackColor = true;
            this.radioButtonCoSo.CheckedChanged += new System.EventHandler(this.radioButtonCoSo_CheckedChanged);
            // 
            // radioButtonGiangVien
            // 
            this.radioButtonGiangVien.AutoSize = true;
            this.radioButtonGiangVien.Location = new System.Drawing.Point(301, 89);
            this.radioButtonGiangVien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonGiangVien.Name = "radioButtonGiangVien";
            this.radioButtonGiangVien.Size = new System.Drawing.Size(76, 17);
            this.radioButtonGiangVien.TabIndex = 1;
            this.radioButtonGiangVien.TabStop = true;
            this.radioButtonGiangVien.Text = "Giảng viên";
            this.radioButtonGiangVien.UseVisualStyleBackColor = true;
            this.radioButtonGiangVien.CheckedChanged += new System.EventHandler(this.radioButtonGiangVien_CheckedChanged);
            // 
            // radioButtonTruong
            // 
            this.radioButtonTruong.AutoSize = true;
            this.radioButtonTruong.Location = new System.Drawing.Point(301, 44);
            this.radioButtonTruong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonTruong.Name = "radioButtonTruong";
            this.radioButtonTruong.Size = new System.Drawing.Size(59, 17);
            this.radioButtonTruong.TabIndex = 1;
            this.radioButtonTruong.TabStop = true;
            this.radioButtonTruong.Text = "Trường";
            this.radioButtonTruong.UseVisualStyleBackColor = true;
            this.radioButtonTruong.CheckedChanged += new System.EventHandler(this.radioButtonTruong_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 266);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mật khẩu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 225);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên đăng nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên tài khoản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Danh sách chưa có tài khoản:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn quyền:";
            // 
            // frmTaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 421);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmTaoTaiKhoan";
            this.Text = "frmTaoTaiKhoan";
            this.Load += new System.EventHandler(this.frmTaoTaiKhoan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Hủy;
        private System.Windows.Forms.Button btnTao;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtTenTaiKhoan;
        private System.Windows.Forms.ComboBox cmbDSChuaTao;
        private System.Windows.Forms.RadioButton radioButtonSinhVien;
        private System.Windows.Forms.RadioButton radioButtonCoSo;
        private System.Windows.Forms.RadioButton radioButtonGiangVien;
        private System.Windows.Forms.RadioButton radioButtonTruong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
namespace AEONSHOP.UI
{
    partial class QuanLyHoaDon
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
            this.lsvHoaDon = new System.Windows.Forms.ListView();
            this.MaHoaDon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HoTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NgayBan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Grb_ThongTinKhachHang = new System.Windows.Forms.GroupBox();
            this.Txt_SoThich = new System.Windows.Forms.TextBox();
            this.Cmb_SucKhoe = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Cmb_ThuNhap = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Cmb_CongViec = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Cmb_GioiTinh = new System.Windows.Forms.ComboBox();
            this.Lbl_GioiTinh = new System.Windows.Forms.Label();
            this.Dtp_NgaySinh = new System.Windows.Forms.DateTimePicker();
            this.Lbl_NgaySinh = new System.Windows.Forms.Label();
            this.Txt_HoTen = new System.Windows.Forms.TextBox();
            this.Lbl_HoTen = new System.Windows.Forms.Label();
            this.Txt_SDT = new System.Windows.Forms.TextBox();
            this.Lbl_SDT = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lbl_TrangThai = new System.Windows.Forms.Label();
            this.Cmb_TrangThai = new System.Windows.Forms.ComboBox();
            this.SDT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Grb_ThongTinKhachHang.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvHoaDon
            // 
            this.lsvHoaDon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaHoaDon,
            this.HoTen,
            this.SDT,
            this.NgayBan,
            this.TongTien});
            this.lsvHoaDon.GridLines = true;
            this.lsvHoaDon.HideSelection = false;
            this.lsvHoaDon.Location = new System.Drawing.Point(7, 51);
            this.lsvHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.lsvHoaDon.Name = "lsvHoaDon";
            this.lsvHoaDon.Size = new System.Drawing.Size(496, 132);
            this.lsvHoaDon.TabIndex = 13;
            this.lsvHoaDon.UseCompatibleStateImageBehavior = false;
            this.lsvHoaDon.View = System.Windows.Forms.View.Details;
            this.lsvHoaDon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lsvHoaDon_MouseClick);
            // 
            // MaHoaDon
            // 
            this.MaHoaDon.Text = "Mã Hóa Đơn";
            this.MaHoaDon.Width = 73;
            // 
            // HoTen
            // 
            this.HoTen.Text = "Khách Hàng";
            this.HoTen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HoTen.Width = 147;
            // 
            // NgayBan
            // 
            this.NgayBan.Text = "Ngày Bán";
            this.NgayBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NgayBan.Width = 80;
            // 
            // TongTien
            // 
            this.TongTien.Text = "Tổng Tiền";
            this.TongTien.Width = 89;
            // 
            // Grb_ThongTinKhachHang
            // 
            this.Grb_ThongTinKhachHang.Controls.Add(this.Txt_SoThich);
            this.Grb_ThongTinKhachHang.Controls.Add(this.Cmb_SucKhoe);
            this.Grb_ThongTinKhachHang.Controls.Add(this.label8);
            this.Grb_ThongTinKhachHang.Controls.Add(this.Cmb_ThuNhap);
            this.Grb_ThongTinKhachHang.Controls.Add(this.label7);
            this.Grb_ThongTinKhachHang.Controls.Add(this.Cmb_CongViec);
            this.Grb_ThongTinKhachHang.Controls.Add(this.label6);
            this.Grb_ThongTinKhachHang.Controls.Add(this.label5);
            this.Grb_ThongTinKhachHang.Controls.Add(this.Cmb_GioiTinh);
            this.Grb_ThongTinKhachHang.Controls.Add(this.Lbl_GioiTinh);
            this.Grb_ThongTinKhachHang.Controls.Add(this.Dtp_NgaySinh);
            this.Grb_ThongTinKhachHang.Controls.Add(this.Lbl_NgaySinh);
            this.Grb_ThongTinKhachHang.Controls.Add(this.Txt_HoTen);
            this.Grb_ThongTinKhachHang.Controls.Add(this.Lbl_HoTen);
            this.Grb_ThongTinKhachHang.Controls.Add(this.Txt_SDT);
            this.Grb_ThongTinKhachHang.Controls.Add(this.Lbl_SDT);
            this.Grb_ThongTinKhachHang.Location = new System.Drawing.Point(6, 204);
            this.Grb_ThongTinKhachHang.Name = "Grb_ThongTinKhachHang";
            this.Grb_ThongTinKhachHang.Size = new System.Drawing.Size(512, 137);
            this.Grb_ThongTinKhachHang.TabIndex = 14;
            this.Grb_ThongTinKhachHang.TabStop = false;
            this.Grb_ThongTinKhachHang.Text = "Thông Tin Khách Hàng";
            // 
            // Txt_SoThich
            // 
            this.Txt_SoThich.Enabled = false;
            this.Txt_SoThich.Location = new System.Drawing.Point(68, 76);
            this.Txt_SoThich.Name = "Txt_SoThich";
            this.Txt_SoThich.Size = new System.Drawing.Size(180, 20);
            this.Txt_SoThich.TabIndex = 5;
            // 
            // Cmb_SucKhoe
            // 
            this.Cmb_SucKhoe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_SucKhoe.FormattingEnabled = true;
            this.Cmb_SucKhoe.Location = new System.Drawing.Point(324, 101);
            this.Cmb_SucKhoe.Name = "Cmb_SucKhoe";
            this.Cmb_SucKhoe.Size = new System.Drawing.Size(180, 21);
            this.Cmb_SucKhoe.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Sức Khỏe";
            // 
            // Cmb_ThuNhap
            // 
            this.Cmb_ThuNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_ThuNhap.FormattingEnabled = true;
            this.Cmb_ThuNhap.Location = new System.Drawing.Point(68, 101);
            this.Cmb_ThuNhap.Name = "Cmb_ThuNhap";
            this.Cmb_ThuNhap.Size = new System.Drawing.Size(180, 21);
            this.Cmb_ThuNhap.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Thu nhập";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Cmb_CongViec
            // 
            this.Cmb_CongViec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_CongViec.FormattingEnabled = true;
            this.Cmb_CongViec.Location = new System.Drawing.Point(324, 74);
            this.Cmb_CongViec.Name = "Cmb_CongViec";
            this.Cmb_CongViec.Size = new System.Drawing.Size(180, 21);
            this.Cmb_CongViec.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Công việc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Sở thích";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Cmb_GioiTinh
            // 
            this.Cmb_GioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_GioiTinh.FormattingEnabled = true;
            this.Cmb_GioiTinh.Location = new System.Drawing.Point(324, 47);
            this.Cmb_GioiTinh.Name = "Cmb_GioiTinh";
            this.Cmb_GioiTinh.Size = new System.Drawing.Size(59, 21);
            this.Cmb_GioiTinh.TabIndex = 4;
            // 
            // Lbl_GioiTinh
            // 
            this.Lbl_GioiTinh.AutoSize = true;
            this.Lbl_GioiTinh.Location = new System.Drawing.Point(270, 51);
            this.Lbl_GioiTinh.Name = "Lbl_GioiTinh";
            this.Lbl_GioiTinh.Size = new System.Drawing.Size(47, 13);
            this.Lbl_GioiTinh.TabIndex = 6;
            this.Lbl_GioiTinh.Text = "Giới tính";
            // 
            // Dtp_NgaySinh
            // 
            this.Dtp_NgaySinh.CustomFormat = "dd/MM/yyyy";
            this.Dtp_NgaySinh.Enabled = false;
            this.Dtp_NgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_NgaySinh.Location = new System.Drawing.Point(68, 47);
            this.Dtp_NgaySinh.Name = "Dtp_NgaySinh";
            this.Dtp_NgaySinh.Size = new System.Drawing.Size(102, 20);
            this.Dtp_NgaySinh.TabIndex = 3;
            // 
            // Lbl_NgaySinh
            // 
            this.Lbl_NgaySinh.AutoSize = true;
            this.Lbl_NgaySinh.Location = new System.Drawing.Point(10, 51);
            this.Lbl_NgaySinh.Name = "Lbl_NgaySinh";
            this.Lbl_NgaySinh.Size = new System.Drawing.Size(54, 13);
            this.Lbl_NgaySinh.TabIndex = 4;
            this.Lbl_NgaySinh.Text = "Ngày sinh";
            this.Lbl_NgaySinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Txt_HoTen
            // 
            this.Txt_HoTen.Enabled = false;
            this.Txt_HoTen.Location = new System.Drawing.Point(324, 20);
            this.Txt_HoTen.Name = "Txt_HoTen";
            this.Txt_HoTen.Size = new System.Drawing.Size(180, 20);
            this.Txt_HoTen.TabIndex = 2;
            // 
            // Lbl_HoTen
            // 
            this.Lbl_HoTen.AutoSize = true;
            this.Lbl_HoTen.Location = new System.Drawing.Point(270, 24);
            this.Lbl_HoTen.Name = "Lbl_HoTen";
            this.Lbl_HoTen.Size = new System.Drawing.Size(39, 13);
            this.Lbl_HoTen.TabIndex = 2;
            this.Lbl_HoTen.Text = "Họ tên";
            // 
            // Txt_SDT
            // 
            this.Txt_SDT.Enabled = false;
            this.Txt_SDT.Location = new System.Drawing.Point(68, 20);
            this.Txt_SDT.MaxLength = 10;
            this.Txt_SDT.Name = "Txt_SDT";
            this.Txt_SDT.Size = new System.Drawing.Size(102, 20);
            this.Txt_SDT.TabIndex = 1;
            // 
            // Lbl_SDT
            // 
            this.Lbl_SDT.AutoSize = true;
            this.Lbl_SDT.Location = new System.Drawing.Point(10, 24);
            this.Lbl_SDT.Name = "Lbl_SDT";
            this.Lbl_SDT.Size = new System.Drawing.Size(29, 13);
            this.Lbl_SDT.TabIndex = 0;
            this.Lbl_SDT.Text = "SDT";
            this.Lbl_SDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cmb_TrangThai);
            this.groupBox1.Controls.Add(this.Lbl_TrangThai);
            this.groupBox1.Controls.Add(this.lsvHoaDon);
            this.groupBox1.Location = new System.Drawing.Point(6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 196);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Hóa Đơn";
            // 
            // Lbl_TrangThai
            // 
            this.Lbl_TrangThai.AutoSize = true;
            this.Lbl_TrangThai.Location = new System.Drawing.Point(13, 23);
            this.Lbl_TrangThai.Name = "Lbl_TrangThai";
            this.Lbl_TrangThai.Size = new System.Drawing.Size(105, 13);
            this.Lbl_TrangThai.TabIndex = 15;
            this.Lbl_TrangThai.Text = "Trạng Thái Hóa Đơn";
            this.Lbl_TrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Cmb_TrangThai
            // 
            this.Cmb_TrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_TrangThai.FormattingEnabled = true;
            this.Cmb_TrangThai.Location = new System.Drawing.Point(127, 20);
            this.Cmb_TrangThai.Name = "Cmb_TrangThai";
            this.Cmb_TrangThai.Size = new System.Drawing.Size(169, 21);
            this.Cmb_TrangThai.TabIndex = 16;
            this.Cmb_TrangThai.SelectedIndexChanged += new System.EventHandler(this.Cmb_TrangThai_SelectedIndexChanged);
            // 
            // SDT
            // 
            this.SDT.Text = "SDT";
            this.SDT.Width = 94;
            // 
            // QuanLyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 385);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Grb_ThongTinKhachHang);
            this.Name = "QuanLyHoaDon";
            this.Text = "Danh Sách Hóa Đơn";
            this.Load += new System.EventHandler(this.QuanLyHoaDon_Load);
            this.Grb_ThongTinKhachHang.ResumeLayout(false);
            this.Grb_ThongTinKhachHang.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lsvHoaDon;
        private System.Windows.Forms.ColumnHeader MaHoaDon;
        private System.Windows.Forms.ColumnHeader HoTen;
        private System.Windows.Forms.ColumnHeader NgayBan;
        private System.Windows.Forms.ColumnHeader TongTien;
        private System.Windows.Forms.GroupBox Grb_ThongTinKhachHang;
        private System.Windows.Forms.TextBox Txt_SoThich;
        private System.Windows.Forms.ComboBox Cmb_SucKhoe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox Cmb_ThuNhap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Cmb_CongViec;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Cmb_GioiTinh;
        private System.Windows.Forms.Label Lbl_GioiTinh;
        private System.Windows.Forms.DateTimePicker Dtp_NgaySinh;
        private System.Windows.Forms.Label Lbl_NgaySinh;
        private System.Windows.Forms.TextBox Txt_HoTen;
        private System.Windows.Forms.Label Lbl_HoTen;
        private System.Windows.Forms.TextBox Txt_SDT;
        private System.Windows.Forms.Label Lbl_SDT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Cmb_TrangThai;
        private System.Windows.Forms.Label Lbl_TrangThai;
        private System.Windows.Forms.ColumnHeader SDT;
    }
}
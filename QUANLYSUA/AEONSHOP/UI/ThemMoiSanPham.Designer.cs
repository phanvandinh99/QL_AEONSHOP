namespace AEONSHOP.UI
{
    partial class ThemMoiSanPham
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
            this.Grb_ThongTinSanPham = new System.Windows.Forms.GroupBox();
            this.Pal_ = new System.Windows.Forms.Panel();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.Btn_ThemMoi = new System.Windows.Forms.Button();
            this.Txt_MoTa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmb_LoaiSanPham = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Lbl_NgaySinh = new System.Windows.Forms.Label();
            this.Txt_TenSanPham = new System.Windows.Forms.TextBox();
            this.Txt_MaSanPham = new System.Windows.Forms.TextBox();
            this.Lbl_SDT = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Grb_ThongTinSanPham.SuspendLayout();
            this.Pal_.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Grb_ThongTinSanPham
            // 
            this.Grb_ThongTinSanPham.Controls.Add(this.pictureBox1);
            this.Grb_ThongTinSanPham.Controls.Add(this.Txt_MaSanPham);
            this.Grb_ThongTinSanPham.Controls.Add(this.Lbl_SDT);
            this.Grb_ThongTinSanPham.Controls.Add(this.button1);
            this.Grb_ThongTinSanPham.Controls.Add(this.textBox1);
            this.Grb_ThongTinSanPham.Controls.Add(this.label2);
            this.Grb_ThongTinSanPham.Controls.Add(this.Pal_);
            this.Grb_ThongTinSanPham.Controls.Add(this.Txt_MoTa);
            this.Grb_ThongTinSanPham.Controls.Add(this.label1);
            this.Grb_ThongTinSanPham.Controls.Add(this.Cmb_LoaiSanPham);
            this.Grb_ThongTinSanPham.Controls.Add(this.label6);
            this.Grb_ThongTinSanPham.Controls.Add(this.Lbl_NgaySinh);
            this.Grb_ThongTinSanPham.Controls.Add(this.Txt_TenSanPham);
            this.Grb_ThongTinSanPham.Location = new System.Drawing.Point(8, 7);
            this.Grb_ThongTinSanPham.Name = "Grb_ThongTinSanPham";
            this.Grb_ThongTinSanPham.Size = new System.Drawing.Size(408, 459);
            this.Grb_ThongTinSanPham.TabIndex = 30;
            this.Grb_ThongTinSanPham.TabStop = false;
            this.Grb_ThongTinSanPham.Text = "Thông Tin Sản Phẩm";
            // 
            // Pal_
            // 
            this.Pal_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pal_.Controls.Add(this.Btn_Clear);
            this.Pal_.Controls.Add(this.Btn_ThemMoi);
            this.Pal_.Location = new System.Drawing.Point(225, 404);
            this.Pal_.Name = "Pal_";
            this.Pal_.Size = new System.Drawing.Size(171, 38);
            this.Pal_.TabIndex = 30;
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.ForeColor = System.Drawing.Color.Black;
            this.Btn_Clear.Location = new System.Drawing.Point(88, 5);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(76, 26);
            this.Btn_Clear.TabIndex = 22;
            this.Btn_Clear.Text = "Clear";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // Btn_ThemMoi
            // 
            this.Btn_ThemMoi.ForeColor = System.Drawing.Color.Black;
            this.Btn_ThemMoi.Location = new System.Drawing.Point(6, 5);
            this.Btn_ThemMoi.Name = "Btn_ThemMoi";
            this.Btn_ThemMoi.Size = new System.Drawing.Size(76, 26);
            this.Btn_ThemMoi.TabIndex = 21;
            this.Btn_ThemMoi.Text = "Thêm Mới";
            this.Btn_ThemMoi.UseVisualStyleBackColor = true;
            this.Btn_ThemMoi.Click += new System.EventHandler(this.Btn_ThemMoi_Click);
            // 
            // Txt_MoTa
            // 
            this.Txt_MoTa.Location = new System.Drawing.Point(94, 255);
            this.Txt_MoTa.Multiline = true;
            this.Txt_MoTa.Name = "Txt_MoTa";
            this.Txt_MoTa.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Txt_MoTa.Size = new System.Drawing.Size(302, 143);
            this.Txt_MoTa.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mô Tả";
            // 
            // Cmb_LoaiSanPham
            // 
            this.Cmb_LoaiSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_LoaiSanPham.FormattingEnabled = true;
            this.Cmb_LoaiSanPham.Location = new System.Drawing.Point(94, 84);
            this.Cmb_LoaiSanPham.Name = "Cmb_LoaiSanPham";
            this.Cmb_LoaiSanPham.Size = new System.Drawing.Size(180, 21);
            this.Cmb_LoaiSanPham.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Loại SP";
            // 
            // Lbl_NgaySinh
            // 
            this.Lbl_NgaySinh.AutoSize = true;
            this.Lbl_NgaySinh.Location = new System.Drawing.Point(14, 52);
            this.Lbl_NgaySinh.Name = "Lbl_NgaySinh";
            this.Lbl_NgaySinh.Size = new System.Drawing.Size(75, 13);
            this.Lbl_NgaySinh.TabIndex = 4;
            this.Lbl_NgaySinh.Text = "Tên sản phẩm";
            this.Lbl_NgaySinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Txt_TenSanPham
            // 
            this.Txt_TenSanPham.Location = new System.Drawing.Point(94, 49);
            this.Txt_TenSanPham.Name = "Txt_TenSanPham";
            this.Txt_TenSanPham.Size = new System.Drawing.Size(302, 20);
            this.Txt_TenSanPham.TabIndex = 2;
            // 
            // Txt_MaSanPham
            // 
            this.Txt_MaSanPham.Location = new System.Drawing.Point(94, 19);
            this.Txt_MaSanPham.MaxLength = 10;
            this.Txt_MaSanPham.Name = "Txt_MaSanPham";
            this.Txt_MaSanPham.ReadOnly = true;
            this.Txt_MaSanPham.Size = new System.Drawing.Size(102, 20);
            this.Txt_MaSanPham.TabIndex = 1;
            // 
            // Lbl_SDT
            // 
            this.Lbl_SDT.AutoSize = true;
            this.Lbl_SDT.Location = new System.Drawing.Point(14, 23);
            this.Lbl_SDT.Name = "Lbl_SDT";
            this.Lbl_SDT.Size = new System.Drawing.Size(36, 13);
            this.Lbl_SDT.TabIndex = 0;
            this.Lbl_SDT.Text = "MaSP";
            this.Lbl_SDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Hình ảnh";
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 223);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(268, 20);
            this.textBox1.TabIndex = 34;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(368, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 26);
            this.button1.TabIndex = 23;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(94, 119);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // ThemMoiSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 573);
            this.Controls.Add(this.Grb_ThongTinSanPham);
            this.Name = "ThemMoiSanPham";
            this.Text = "Thêm Mới Sản Phẩm";
            this.Grb_ThongTinSanPham.ResumeLayout(false);
            this.Grb_ThongTinSanPham.PerformLayout();
            this.Pal_.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grb_ThongTinSanPham;
        private System.Windows.Forms.Panel Pal_;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.Button Btn_ThemMoi;
        private System.Windows.Forms.TextBox Txt_MoTa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cmb_LoaiSanPham;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Lbl_NgaySinh;
        private System.Windows.Forms.TextBox Txt_TenSanPham;
        private System.Windows.Forms.TextBox Txt_MaSanPham;
        private System.Windows.Forms.Label Lbl_SDT;
        private System.Windows.Forms.Label label2;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
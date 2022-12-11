namespace AEONSHOP.UI
{
    partial class QuanLySua
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Cmb_Filter = new System.Windows.Forms.ComboBox();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.Txt_Search = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cmb_DanhMuc = new System.Windows.Forms.ComboBox();
            this.Lbl_DanhMuc = new System.Windows.Forms.Label();
            this.FLP_Product = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(182, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "DANH SÁCH SẢN PHẨM HIỆN CÓ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Cmb_Filter);
            this.panel2.Controls.Add(this.Btn_Search);
            this.panel2.Controls.Add(this.Txt_Search);
            this.panel2.Location = new System.Drawing.Point(326, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 38);
            this.panel2.TabIndex = 29;
            // 
            // Cmb_Filter
            // 
            this.Cmb_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Filter.FormattingEnabled = true;
            this.Cmb_Filter.Location = new System.Drawing.Point(4, 9);
            this.Cmb_Filter.Name = "Cmb_Filter";
            this.Cmb_Filter.Size = new System.Drawing.Size(59, 21);
            this.Cmb_Filter.TabIndex = 22;
            // 
            // Btn_Search
            // 
            this.Btn_Search.ForeColor = System.Drawing.Color.Black;
            this.Btn_Search.Location = new System.Drawing.Point(240, 6);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(76, 26);
            this.Btn_Search.TabIndex = 24;
            this.Btn_Search.Text = "Tìm kiếm";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // Txt_Search
            // 
            this.Txt_Search.Location = new System.Drawing.Point(69, 9);
            this.Txt_Search.Name = "Txt_Search";
            this.Txt_Search.Size = new System.Drawing.Size(169, 20);
            this.Txt_Search.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Cmb_DanhMuc);
            this.panel1.Controls.Add(this.Lbl_DanhMuc);
            this.panel1.Location = new System.Drawing.Point(12, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 38);
            this.panel1.TabIndex = 28;
            // 
            // Cmb_DanhMuc
            // 
            this.Cmb_DanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_DanhMuc.FormattingEnabled = true;
            this.Cmb_DanhMuc.Location = new System.Drawing.Point(76, 9);
            this.Cmb_DanhMuc.Name = "Cmb_DanhMuc";
            this.Cmb_DanhMuc.Size = new System.Drawing.Size(216, 21);
            this.Cmb_DanhMuc.TabIndex = 21;
            this.Cmb_DanhMuc.SelectedIndexChanged += new System.EventHandler(this.Cmb_DanhMuc_SelectedIndexChanged);
            // 
            // Lbl_DanhMuc
            // 
            this.Lbl_DanhMuc.AutoSize = true;
            this.Lbl_DanhMuc.Location = new System.Drawing.Point(14, 13);
            this.Lbl_DanhMuc.Name = "Lbl_DanhMuc";
            this.Lbl_DanhMuc.Size = new System.Drawing.Size(56, 13);
            this.Lbl_DanhMuc.TabIndex = 18;
            this.Lbl_DanhMuc.Text = "Danh mục";
            this.Lbl_DanhMuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FLP_Product
            // 
            this.FLP_Product.AutoScroll = true;
            this.FLP_Product.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FLP_Product.Location = new System.Drawing.Point(12, 68);
            this.FLP_Product.Name = "FLP_Product";
            this.FLP_Product.Size = new System.Drawing.Size(638, 645);
            this.FLP_Product.TabIndex = 30;
            // 
            // QuanLySua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 730);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FLP_Product);
            this.Controls.Add(this.label1);
            this.Name = "QuanLySua";
            this.Text = "Form Quản Lý Sữa";
            this.Load += new System.EventHandler(this.QuanLySua_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox Cmb_Filter;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.TextBox Txt_Search;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox Cmb_DanhMuc;
        private System.Windows.Forms.Label Lbl_DanhMuc;
        private System.Windows.Forms.FlowLayoutPanel FLP_Product;
    }
}
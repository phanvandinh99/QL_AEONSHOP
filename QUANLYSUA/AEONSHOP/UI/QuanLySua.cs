using AEONSHOP.COMMON;
using AEONSHOP.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AEONSHOP.UI
{
    public partial class QuanLySua : Form
    {
        public QuanLySua()
        {
            InitializeComponent();
        }

        #region Khởi tạo đối tượng
        EF_AEONSHOP db = new EF_AEONSHOP();
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        #endregion

        #region Load màn hình
        private void QuanLySua_Load(object sender, EventArgs e)
        {
            // Hiển thị danh mục (loại sản phẩm)
            var lst_LoaiSanPham = db.LoaiSanPham.ToList();
            Cmb_DanhMuc.DataSource = lst_LoaiSanPham;
            Cmb_DanhMuc.DisplayMember = "TenLoaiSanPham";
            Cmb_DanhMuc.ValueMember = "MaLoaiSanPham";

            // hiển thị filter theo tên hoặc giá
            Cmb_Filter.DisplayMember = "Text";
            Cmb_Filter.ValueMember = "Value";
            var filter = new[] {
                new { Text = "Tên", Value = "0" },
                new { Text = "Giá", Value = "1" },
            };
            Cmb_Filter.DataSource = filter;

            // Hiển thị danh sách sản phẩm
            this.HienThiSanPham("ALL");
        }
        #endregion

        #region Hiển thị load sản phẩm
        void HienThiSanPham(string sMaLoaiSanPham)
        {
            // Xóa rỗng sản phẩm
            FLP_Product.Controls.Clear();

            if ("ALL".Equals(sMaLoaiSanPham))
            {
                // Hiển thị danh sách sản phẩm
                var lst_Producr = db.SanPham.Join(db.ChiTietSanPham,
                                                  n => n.MaSanPham,
                                                  m => m.MaSanPham,
                                                  (n, m) => new
                                                  {
                                                      n.MaSanPham,
                                                      n.TenSanPham,
                                                      m.DonGiaBan,
                                                      m.NgaySuDungConLai,
                                                      n.Anh
                                                  });

                // Hiển thị
                foreach (var item in lst_Producr)
                {
                    Button btn_product = new Button() { Width = 72, Height = 100 };

                    // gán btnTag = item
                    btn_product.Tag = item;

                    // hiển thị ảnh cho button
                    string dir = Path.GetDirectoryName(Application.ExecutablePath);
                    string filename = Path.Combine(dir, item.Anh);
                    filename = filename.Replace("QUANLYSUA\\AEONSHOP\\bin\\Debug\\", "Image\\AnhSanPham\\");
                    btn_product.BackgroundImage = Image.FromFile(filename);
                    btn_product.BackgroundImageLayout = ImageLayout.Stretch;


                    // Hiển thị tên sản phẩm và giá
                    Label lbl_Product_Name = new Label() { Width = 120, Height = 50 };
                    lbl_Product_Name.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Regular);
                    lbl_Product_Name.Text = item.TenSanPham + "\nHSD: " + item.NgaySuDungConLai + " Tháng.\nGiá: " + item.DonGiaBan.ToString("#,###", cul.NumberFormat) + " vnđ.";

                    lbl_Product_Name.Dock = DockStyle.Fill;
                    lbl_Product_Name.TextAlign = ContentAlignment.MiddleLeft;
                    lbl_Product_Name.AutoSize = false;

                    FLP_Product.Controls.Add(btn_product); // Thêm danh sách hình ảnh sản phẩm
                    FLP_Product.Controls.Add(lbl_Product_Name); // Thêm danh sách tên sản phẩm
                }
            }
            else
            {
                var lst_Producr = db.SanPham.Join(db.ChiTietSanPham,
                                  n => n.MaSanPham,
                                  m => m.MaSanPham,
                                  (n, m) => new
                                  {
                                      n.MaSanPham,
                                      n.TenSanPham,
                                      m.DonGiaBan,
                                      n.MaLoaiSanPham,
                                      n.Anh
                                  }).Where(n => n.MaLoaiSanPham == sMaLoaiSanPham);

                // hiển thị
                foreach (var item in lst_Producr)
                {
                    Button btn_product = new Button() { Width = 72, Height = 100 };

                    // gán btnTag = item
                    btn_product.Tag = item;

                    // hiển thị ảnh cho button
                    string dir = Path.GetDirectoryName(Application.ExecutablePath);
                    string filename = Path.Combine(dir, item.Anh);
                    filename = filename.Replace("QUANLYSUA\\AEONSHOP\\bin\\Debug\\", "Image\\AnhSanPham\\");
                    btn_product.BackgroundImage = Image.FromFile(filename);
                    btn_product.BackgroundImageLayout = ImageLayout.Stretch;

                    // Hiển thị tên sản phẩm và giá
                    Label lbl_Product_Name = new Label() { Width = 120, Height = 50 };
                    lbl_Product_Name.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Regular);
                    lbl_Product_Name.Text = item.TenSanPham + ".\nGiá: " + item.DonGiaBan.ToString("#,###", cul.NumberFormat) + " vnđ.";

                    lbl_Product_Name.Dock = DockStyle.Fill;
                    lbl_Product_Name.TextAlign = ContentAlignment.MiddleLeft;
                    lbl_Product_Name.AutoSize = false;

                    FLP_Product.Controls.Add(btn_product); // Thêm danh sách hình ảnh sản phẩm
                    FLP_Product.Controls.Add(lbl_Product_Name); // Thêm danh sách tên sản phẩm
                }
            }

        }
        #endregion

        #region Hiển thị sản phẩm theo loại
        private void Cmb_DanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThiSanPham(Convert.ToString(this.Cmb_DanhMuc.SelectedValue));
        }
        #endregion

        #region Chức năng tìm kiếm
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            // Khởi tạo giá trị
            string sFilter = this.Txt_Search.Text.Trim();
            string sLoaiTimKiem = Convert.ToString(this.Cmb_Filter.SelectedValue);

            #region Kiểm tra nhập
            if (string.IsNullOrEmpty(sFilter))
            {
                // Hiển thị toàn bộ sản phẩm
                this.HienThiSanPham("ALL");
                return;
            }

            // Kiểm tra nhập giá tiền
            int chk_price = 0;
            if ("1".Equals(sLoaiTimKiem))
            {
                if (!int.TryParse(sFilter, out chk_price))
                {
                    MessageBox.Show("Giá tiền chỉ được nhập số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Txt_Search.Focus();
                    return;
                }
            }
            #endregion

            // Thực hiện tìm kiếm
            // Xóa rỗng sản phẩm
            FLP_Product.Controls.Clear();

            if ("0".Equals(this.Cmb_Filter.SelectedValue))
            {
                var lst_Producr = db.SanPham.Join(db.ChiTietSanPham,
                                  n => n.MaSanPham,
                                  m => m.MaSanPham,
                                  (n, m) => new
                                  {
                                      n.MaSanPham,
                                      n.TenSanPham,
                                      m.DonGiaBan,
                                      n.MaLoaiSanPham,
                                      n.Anh
                                  }).Where(n => n.TenSanPham.Contains(sFilter));

                // hiển thị
                foreach (var item in lst_Producr)
                {
                    Button btn_product = new Button() { Width = 72, Height = 100 };

                    // gán btnTag = item
                    btn_product.Tag = item;

                    // hiển thị ảnh cho button
                    string dir = Path.GetDirectoryName(Application.ExecutablePath);
                    string filename = Path.Combine(dir, item.Anh);
                    filename = filename.Replace("QUANLYSUA\\AEONSHOP\\bin\\Debug\\", "Image\\AnhSanPham\\");
                    btn_product.BackgroundImage = Image.FromFile(filename);
                    btn_product.BackgroundImageLayout = ImageLayout.Stretch;

                    // thực hiện chức năng click
                    //btn_product.Click += btn_Click;

                    // Hiển thị tên sản phẩm và giá
                    Label lbl_Product_Name = new Label() { Width = 120, Height = 50 };
                    lbl_Product_Name.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Regular);
                    lbl_Product_Name.Text = item.TenSanPham + ".\nGiá: " + item.DonGiaBan.ToString("#,###", cul.NumberFormat) + " vnđ.";

                    lbl_Product_Name.Dock = DockStyle.Fill;
                    lbl_Product_Name.TextAlign = ContentAlignment.MiddleLeft;
                    lbl_Product_Name.AutoSize = false;

                    FLP_Product.Controls.Add(btn_product); // Thêm danh sách hình ảnh sản phẩm
                    FLP_Product.Controls.Add(lbl_Product_Name); // Thêm danh sách tên sản phẩm
                }
            }
            else
            {
                var lst_Producr = db.SanPham.Join(db.ChiTietSanPham,
                                n => n.MaSanPham,
                                m => m.MaSanPham,
                                (n, m) => new
                                {
                                    n.MaSanPham,
                                    n.TenSanPham,
                                    m.DonGiaBan,
                                    n.MaLoaiSanPham,
                                    n.Anh
                                }).Where(n => n.DonGiaBan == Convert.ToDouble(sFilter));

                // hiển thị
                foreach (var item in lst_Producr)
                {
                    Button btn_product = new Button() { Width = 72, Height = 100 };

                    // gán btnTag = item
                    btn_product.Tag = item;

                    // hiển thị ảnh cho button
                    string dir = Path.GetDirectoryName(Application.ExecutablePath);
                    string filename = Path.Combine(dir, item.Anh);
                    filename = filename.Replace("QUANLYSUA\\AEONSHOP\\bin\\Debug\\", "Image\\AnhSanPham\\");
                    btn_product.BackgroundImage = Image.FromFile(filename);
                    btn_product.BackgroundImageLayout = ImageLayout.Stretch;

                    // thực hiện chức năng click
                    //btn_product.Click += btn_Click;

                    // Hiển thị tên sản phẩm và giá
                    Label lbl_Product_Name = new Label() { Width = 120, Height = 50 };
                    lbl_Product_Name.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Regular);
                    lbl_Product_Name.Text = item.TenSanPham + ".\nGiá: " + item.DonGiaBan.ToString("#,###", cul.NumberFormat) + " vnđ.";

                    lbl_Product_Name.Dock = DockStyle.Fill;
                    lbl_Product_Name.TextAlign = ContentAlignment.MiddleLeft;
                    lbl_Product_Name.AutoSize = false;

                    FLP_Product.Controls.Add(btn_product); // Thêm danh sách hình ảnh sản phẩm
                    FLP_Product.Controls.Add(lbl_Product_Name); // Thêm danh sách tên sản phẩm
                }
            }
        }

        #endregion
    }
}

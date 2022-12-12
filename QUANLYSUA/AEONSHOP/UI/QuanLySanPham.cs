using AEONSHOP.COMMON;
using AEONSHOP.EF;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AEONSHOP.UI
{
    public partial class QuanLySanPham : Form
    {
        public QuanLySanPham()
        {
            InitializeComponent();
        }

        #region Khởi tạo đối tượng
        EF_AEONSHOP db = new EF_AEONSHOP();
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        Common cm = new Common();
        #endregion

        #region ========== EVENT ==========

        #region Load màn hình
        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            #region Hiển thị combobox
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
            #endregion

            // Hiển thị sản phẩm lên listview
            this.HienThiSanPham("ALL");
        }
        #endregion

        #endregion

        #region ========== METHOD ==========

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

                    // thực hiện chức năng click
                    btn_product.Click += btn_Click;

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
                                      m.NgaySuDungConLai,
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

                    // thực hiện chức năng click
                    btn_product.Click += btn_Click;

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

        #region Đổ dữ liệu vào thông tin sản phẩm
        void btn_Click(object sender, EventArgs e)
        {
            #region Khởi tạo giá trị
            string sMaSanPham = string.Empty;
            double fLai = 0;
            #endregion

            #region Lấy mã sản phẩm tương ứng ở button click
            string sSanPham = Convert.ToString((sender as Button).Tag);
            var pattern = @"= \S*\b";
            var result = Regex.Matches(sSanPham, pattern);

            // Mã sản phẩm
            sMaSanPham = result[0].ToString().Substring(2);
            #endregion

            // Lấy thông tin sản phẩm theo mã sản phẩm
            SanPham sanpham = db.SanPham.SingleOrDefault(n => n.MaSanPham == sMaSanPham);

            // Hiển thị thông tin sản phẩm vào txt
            this.Txt_TenSanPham.Text = sanpham.TenSanPham;
            this.Txt_MaSanPham.Text = sanpham.MaSanPham;
            this.Txt_DaBan.Text = Convert.ToString(sanpham.DaBan);
            this.Cmb_LoaiSanPham.SelectedValue = sanpham.MaLoaiSanPham;
            this.Txt_MoTa.Text = sanpham.MoTa;

            // Hiển thị sanh sách chi tiết sản phẩm
            var chitietsanpham = db.ChiTietSanPham.Where(n => n.MaSanPham == sMaSanPham).ToList();

            // Xóa rỗng listview hóa đơn
            lsvSanPham.Items.Clear();

            // Trường hợp null
            if (0 != chitietsanpham.Count())
            {
                foreach (var item in chitietsanpham)
                {
                    // lấy tên sản phẩm
                    ListViewItem lsvItem = new ListViewItem(item.NgaySanXuat.ToString("yyyy/MM/DD"));
                    lsvItem.SubItems.Add(item.HanSuDung.ToString("yyyy/MM/DD"));
                    lsvItem.SubItems.Add((item.NgaySuDungConLai).ToString());
                    lsvItem.SubItems.Add((item.SoLuongHienCon).ToString());
                    lsvItem.SubItems.Add(item.DonGiaNhap.ToString("#,###", cul.NumberFormat));
                    lsvItem.SubItems.Add(item.DonGiaBan.ToString("#,###", cul.NumberFormat));

                    fLai = (item.DonGiaBan - item.DonGiaNhap);
                    if (fLai < 0)
                    {
                        lsvItem.SubItems.Add("Lỗ: " + fLai + "đ");
                    }
                    else
                    {
                        lsvItem.SubItems.Add("Lãi: " + fLai + "đ");
                    }
                    lsvSanPham.Items.Add(lsvItem);
                }
            }
        }
        #endregion

        #endregion
    }
}

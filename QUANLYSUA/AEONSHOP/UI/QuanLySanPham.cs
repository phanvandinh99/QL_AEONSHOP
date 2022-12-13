using AEONSHOP.COMMON;
using AEONSHOP.EF;
using System;
using System.Collections.Generic;
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

            // Hiển thị ngày hệ thống
            this.Lbl_NgayHeThong.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Hiển thị danh mục (loại sản phẩm)
            var lst_LoaiSanPham = db.LoaiSanPham.ToList();
            Cmb_DanhMuc.DataSource = lst_LoaiSanPham;
            Cmb_DanhMuc.DisplayMember = "TenLoaiSanPham";
            Cmb_DanhMuc.ValueMember = "MaLoaiSanPham";

            // Hiển thị danh mục (loại sản phẩm)
            var lst_LoaiSanPham_ThongTin = db.LoaiSanPham.ToList();
            Cmb_LoaiSanPham.DataSource = lst_LoaiSanPham_ThongTin;
            Cmb_LoaiSanPham.DisplayMember = "TenLoaiSanPham";
            Cmb_LoaiSanPham.ValueMember = "MaLoaiSanPham";

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

        #region Hiển thị danh sách sản phẩm (menu)
        private void Cmb_DanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThiSanPham(Convert.ToString(this.Cmb_DanhMuc.SelectedValue));
        }
        #endregion

        #region Tìm kiếm
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
                                      m.NgaySuDungConLai,
                                      n.MaLoaiSanPham,
                                      n.Anh
                                  }).Where(n => n.TenSanPham.Contains(sFilter) & n.NgaySuDungConLai > 0).ToList();

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
                                }).ToList().Where(n => n.DonGiaBan == Convert.ToDouble(sFilter) & n.NgaySuDungConLai > 0);

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

        #region xóa rỗng textbox
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            this.XoaRongTextbox();
        }
        #endregion

        #region Xóa sản phẩm
        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            // khởi tạo giá trị
            string sMaSanPham = this.Txt_MaSanPham.Text;

            if (string.IsNullOrEmpty(sMaSanPham))
            {
                MessageBox.Show("Không có sản phẩm được chỉ định xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var SanPham = db.SanPham.SingleOrDefault(n => n.MaSanPham == sMaSanPham);
                db.SanPham.Remove(SanPham);
                db.SaveChanges();
                this.XoaRongTextbox();
                MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không thể xóa\nKiểm tra lại khóa quan hệ trong sql", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region Thêm mới sản phẩm
        private void Btn_ThemMoi_Click(object sender, EventArgs e)
        {
            ThemMoiSanPham fThemMoi = new ThemMoiSanPham();
            fThemMoi.ShowDialog();
        }
        #endregion

        #region Cập nhật sản phẩm
        private void Btn_CapNhat_Click(object sender, EventArgs e)
        {
            // khởi tạo giá trị
            string sMaSanPham = this.Txt_MaSanPham.Text;

            if (string.IsNullOrEmpty(sMaSanPham))
            {
                MessageBox.Show("Không có sản phẩm được chỉ định cập nhật", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.Txt_TenSanPham.Text))
            {
                MessageBox.Show("Không bỏ trống tên sản phẩm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.Txt_MoTa.Text))
            {
                MessageBox.Show("Không bỏ trống mô tả", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var SanPham = db.SanPham.SingleOrDefault(n => n.MaSanPham == sMaSanPham);
            SanPham.TenSanPham = this.Txt_TenSanPham.Text;
            SanPham.MoTa = this.Txt_MoTa.Text;
            SanPham.MaLoaiSanPham = Convert.ToString(this.Cmb_LoaiSanPham.SelectedValue);
            db.SaveChanges();
            MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion


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
                                                  }).Where(n => n.NgaySuDungConLai > 0);

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
                    lbl_Product_Name.Text = item.TenSanPham + "\nHSD: " + item.NgaySuDungConLai + " Ngày.\nGiá: " + item.DonGiaBan.ToString("#,###", cul.NumberFormat) + " vnđ.";

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
                                  }).Where(n => n.MaLoaiSanPham == sMaLoaiSanPham & n.NgaySuDungConLai > 0);

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

            this.HienThiListView(chitietsanpham);
        }
        #endregion

        void HienThiListView(List<ChiTietSanPham> lstChiTiet)
        {
            double fLai = 0;

            // Xóa rỗng listview hóa đơn
            lsvSanPham.Items.Clear();

            // Trường hợp null
            if (0 != lstChiTiet.Count())
            {
                foreach (var item in lstChiTiet)
                {
                    // lấy tên sản phẩm
                    ListViewItem lsvItem = new ListViewItem(item.NgaySanXuat.ToString("dd/MM/yyyy"));
                    lsvItem.SubItems.Add(item.HanSuDung.ToString("dd/MM/yyyy"));
                    lsvItem.SubItems.Add(item.NgaySuDungConLai.ToString());
                    lsvItem.SubItems.Add((item.SoLuongHienCon).ToString());
                    lsvItem.SubItems.Add(item.DonGiaNhap.ToString("#,###", cul.NumberFormat));
                    lsvItem.SubItems.Add(item.DonGiaBan.ToString("#,###", cul.NumberFormat));

                    fLai = (item.DonGiaBan - item.DonGiaNhap);
                    if (fLai < 0)
                    {
                        lsvItem.SubItems.Add("Lỗ: " + fLai.ToString("#,###", cul.NumberFormat) + "đ");
                    }
                    else
                    {
                        lsvItem.SubItems.Add("Lãi: " + fLai.ToString("#,###", cul.NumberFormat) + "đ");
                    }
                    lsvSanPham.Items.Add(lsvItem);
                }
            }
        }

        #region Clear textbox
        void XoaRongTextbox()
        {
            this.Txt_TenSanPham.Clear();
            this.Txt_TenSanPham.Focus();
            this.Txt_MaSanPham.Clear();
            this.Txt_DaBan.Clear();
            this.Txt_MoTa.Clear();
            this.Txt_GiaBanMoi.Clear();
            this.Txt_Search.Clear();
            lsvSanPham.Items.Clear();
        }
        #endregion

        #endregion

        #region Cập nhật lại giá bán
        private void Btn_CapNhatGiaBan_Click(object sender, EventArgs e)
        {
            // khởi tạo giá trị
            string sMaSanPham = this.Txt_MaSanPham.Text;
            double fGiaMoi = float.Parse(this.Txt_GiaBanMoi.Text);
            string sNgaySanXuat = Convert.ToDateTime(this.Lbl_NgaySanXuat.Text).ToString("ddMMyyyy");
            string sHanSuDung = Convert.ToDateTime(this.Lbl_HanSuDung.Text).ToString("ddMMyyyy");

            if (0 == fGiaMoi)
            {
                MessageBox.Show("Mời nhập giá bán mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(sMaSanPham))
            {
                MessageBox.Show("Không có sản phẩm được chỉ định cập nhật", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var chiTietSanPham = db.ChiTietSanPham.FirstOrDefault(n => n.NgaySanXuat.ToString("ddMMyyyy").Equals(sNgaySanXuat)
                                                                        & n.HanSuDung.ToString("ddMMyyyy").Equals(sHanSuDung)
                                                                        & n.MaSanPham == sMaSanPham);

            double kq = 0;
            if (null != chiTietSanPham)
            {
                double fGiaCu = chiTietSanPham.DonGiaNhap;

                if (fGiaMoi > fGiaCu)
                {
                    kq = fGiaMoi - fGiaCu;
                    MessageBox.Show("Lãi: " + kq.ToString("#,###", cul.NumberFormat) + " vnđ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (fGiaMoi > fGiaCu)
                {
                    kq = fGiaCu - fGiaMoi;
                    MessageBox.Show("Lỗ: " + kq.ToString("#,###", cul.NumberFormat) + " vnđ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cân bằng (Không lời, không lỗ)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // thực hiện cập nhật
                chiTietSanPham.DonGiaBan = fGiaMoi;
                db.SaveChanges();

                // Hiển thị sanh sách chi tiết sản phẩm
                var chitietsanpham = db.ChiTietSanPham.Where(n => n.MaSanPham == sMaSanPham).ToList();

                this.HienThiListView(chitietsanpham);
                this.Txt_GiaBanCu.Clear();
                this.Txt_GiaBanMoi.Clear();
                MessageBox.Show("Cập nhật giá bán thành công)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        private void lsvSanPham_MouseClick(object sender, MouseEventArgs e)
        {
            this.Lbl_NgaySanXuat.Text = lsvSanPham.SelectedItems[0].SubItems[0].Text;
            this.Lbl_HanSuDung.Text = lsvSanPham.SelectedItems[0].SubItems[1].Text;
            this.Txt_GiaBanCu.Text = lsvSanPham.SelectedItems[0].SubItems[5].Text;
        }

    }
}

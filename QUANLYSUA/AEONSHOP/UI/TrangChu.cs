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
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace AEONSHOP.UI
{
    public partial class TrangChu : Form
    {
        #region Khởi tạo đối tượng
        EF_AEONSHOP db = new EF_AEONSHOP();
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        Common cm = new Common();

        // Khai báo biến
        string sMaSanPham = string.Empty;
        string sDonGiaBan = string.Empty;
        string sHSD = string.Empty;
        bool bCheckKhachHang = true;        // = true => khách hàng đã tồn tại
        #endregion

        #region TrangChu()
        public TrangChu()
        {
            InitializeComponent();
        }
        #endregion

        #region ========== EVENT ==========

        #region Load màn hình
        private void TrangChu_Load(object sender, EventArgs e)
        {
            LoadTable();
        }
        #endregion

        #region Nhập số điện thoại để tiến hành mua hàng
        private void Txt_SDT_Leave(object sender, EventArgs e)
        {
            #region Validation

            // trường hợp sdt bỏ trống
            if (string.IsNullOrEmpty(this.Txt_SDT.Text.Trim()))
            {
                MessageBox.Show("Mời nhập số điện thoại khách hàng để mua hàng.\n Trường hợp khách hàng không có SDT hãy nhập: '0123456789'", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Txt_SDT.Focus();
                return;
            }

            // trường hợp sdt chưa đủ 10 số
            if (10 != this.Txt_SDT.Text.Length)
            {
                MessageBox.Show("Số điện thoại phải đủ 10 kí tự", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Txt_SDT.Focus();
                return;
            }
            #endregion

            #region Kiểm tra khách hàng đã tồn tại trong hệ thống chưa?
            var Infor_KhachHang = db.KhachHang.SingleOrDefault(n => n.SDT == this.Txt_SDT.Text);

            // trường hợp chưa tồn tại
            if (null == Infor_KhachHang)
            {

                this.Txt_HoTen.Clear();
                this.Txt_HoTen.Focus();
                this.Txt_SoThich.Clear();
                this.Txt_TamTinh.Text = "0";
                this.Txt_GiamGia.Text = "0";
                this.Txt_TongTien.Text = "0";
                this.Txt_SoLuong.Text = "0";
                this.bCheckKhachHang = false; // khách hàng chưa tồn tại
                this.Btn_Luu.Visible = true;
                this.Btn_CapNhat.Visible = false;

                // Hiển thị mã hóa đơn
                this.Txt_MaHoaDon.Text = cm.MaHoaDon();
                MessageBox.Show("Khách hàng mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Trường hợp đã tồn tại trong hệ thống
            else
            {
                // Hiển thị thông báo khách hàng
                MessageBox.Show("Xin chào khách hàng: " + Infor_KhachHang.HoTen, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Txt_HoTen.Text = Infor_KhachHang.HoTen;
                this.Dtp_NgaySinh.Text = Infor_KhachHang.NgaySinh.ToString();
                this.Cmb_GioiTinh.Text = Infor_KhachHang.GioiTinh;
                this.Txt_SoThich.Text = Infor_KhachHang.Sothich;
                this.Cmb_SucKhoe.SelectedItem = Infor_KhachHang.TinhTrangSucKhoe;
                this.Cmb_CongViec.SelectedItem = Infor_KhachHang.CongViec;
                this.Cmb_ThuNhap.SelectedItem = Infor_KhachHang.ThuNhap;
                this.bCheckKhachHang = true; // khách hàng đã tồn tại
                this.Btn_Luu.Visible = false;
                this.Btn_CapNhat.Visible = true;

                // Hiên thị thông tin hóa đơn theo số điện thoại (Trường hợp tình trạng hóa đơn là chưa thanh toán)
                this.HienThiHoaDon(this.Txt_SDT.Text);
            }
            #endregion

            // Hiển thị texbox khách hàng
            this.Hidden_Controll(true);
        }
        #endregion

        #region Chỉ được nhập số trong textbox số điện thoại, Số lượng cập nhật và giảm giá
        private void Txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Txt_GiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Txt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Điều khiển textbox
        public bool Hidden_Controll(bool bCheck)
        {
            this.Txt_HoTen.Enabled = bCheck;
            this.Dtp_NgaySinh.Enabled = bCheck;
            this.Cmb_GioiTinh.Enabled = bCheck;
            this.Txt_SoThich.Enabled = bCheck;
            this.Cmb_CongViec.Enabled = bCheck;
            this.Cmb_ThuNhap.Enabled = bCheck;
            this.Cmb_SucKhoe.Enabled = bCheck;
            return true;
        }
        #endregion

        #region Thực hiện lưu khách hàng
        private void Btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                #region Kiểm tra thông tin khách hàng

                // kiểm tra họ tên
                if (string.IsNullOrEmpty(this.Txt_HoTen.Text))
                {
                    MessageBox.Show("Mời nhập họ tên khách hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Txt_HoTen.Focus();
                    return;
                }

                // kiểm tra sở thích
                if (string.IsNullOrEmpty(this.Txt_SoThich.Text))
                {
                    MessageBox.Show("Mời nhập sở thích khách hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Txt_SoThich.Focus();
                    return;
                }
                #endregion

                KhachHang kh = new KhachHang();
                kh.SDT = this.Txt_SDT.Text.Trim();
                kh.HoTen = this.Txt_HoTen.Text.Trim();
                kh.NgaySinh = this.Dtp_NgaySinh.Value;
                kh.GioiTinh = this.Cmb_GioiTinh.Text;
                kh.Sothich = this.Txt_SoThich.Text.Trim();
                kh.MaCongViec = Convert.ToString(this.Cmb_CongViec.SelectedValue);
                kh.MaThuNhap = Convert.ToString(this.Cmb_ThuNhap.SelectedValue);
                kh.MaTinhTrangSK = Convert.ToString(this.Cmb_SucKhoe.SelectedValue);
                db.KhachHang.Add(kh);
                db.SaveChanges();
                this.Btn_Luu.Visible = false;
                this.Btn_CapNhat.Visible = true;
                MessageBox.Show("Thêm mới thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Thực hiện thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region Danh mục (MENU)
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

        #region Sư kiện khi nhấn vào listview
        private void lsvHoaDon_MouseClick(object sender, MouseEventArgs e)
        {
            this.Txt_TenSanPham.Text = lsvHoaDon.SelectedItems[0].SubItems[0].Text;
            this.Txt_MaSP.Text = lsvHoaDon.SelectedItems[0].SubItems[4].Text;
            this.Txt_SoLuong.Text = lsvHoaDon.SelectedItems[0].SubItems[1].Text;

            // Hiển thị button xóa
            this.Btn_Xoa.Enabled = true;
        }
        #endregion

        #region Tính mã giảm giá
        private void Txt_GiamGia_TextChanged(object sender, EventArgs e)
        {
            // tính tổng tiền
            this.TinhTongTien();
        }
        #endregion

        #region Tính mã giảm giá
        private void Txt_TamTinh_TextChanged(object sender, EventArgs e)
        {
            // tính tổng tiền
            this.TinhTongTien();
        }
        #endregion

        #region Cập nhật số lượng trong đơn hàng
        private void Btn_CapNhatSoLuong_Click(object sender, EventArgs e)
        {
            // khởi tạo giá trị
            string sMaHoaDon = this.Txt_MaHoaDon.Text.Trim();
            int iSoLuongMua = int.Parse(this.Txt_SoLuong.Text.Trim());
            string sMaSanPham = this.Txt_MaSP.Text.Trim();

            // kiểm tra hóa đơn
            var HoaDon = db.HoaDon.SingleOrDefault(n => n.MaHoaDon == sMaHoaDon);

            // Lấy ra hóa đơn sản phẩm hiện tại
            var chiTietHoaDon = db.ChiTietHoaDon.SingleOrDefault(n => n.MaHoaDon == sMaHoaDon & n.MaSanPham == sMaSanPham);

            // cập nhật lại số lượng trong chi tiết hóa đơn
            // trường hợp số lượng = 0 => xóa sản phẩm khỏi đơn hàng
            if (iSoLuongMua == 0)
            {
                // xóa khỏi hệ thống
                db.ChiTietHoaDon.Remove(chiTietHoaDon);
                db.SaveChanges();

                // Cập nhật tổng tiền
            }
            // trường hợp cập nhật số lượng => cập nhật số tiền
            else
            {
                chiTietHoaDon.SoLuongMua = iSoLuongMua;
                chiTietHoaDon.ThanhTien = (iSoLuongMua * chiTietHoaDon.GiaBan);
                db.SaveChanges();
            }

            // tính tông tiền cho đơn hàng
            var TongTien = db.ChiTietHoaDon.Where(n => n.MaHoaDon == sMaHoaDon).Sum(n => n.ThanhTien);
            HoaDon.TongTien = TongTien;

            // Hiển thị lên listview hóa đơn
            this.HienThiHoaDon(this.Txt_SDT.Text.Trim());

            // Hiển thị thông báo hoàn tất cập nhật
            MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Btn_CapNhatSoLuong.Enabled = false;
        }
        #endregion

        #region Thay đổi số lượng sản phẩm => hiển thị btn cập nhật
        private void Txt_SoLuong_TextChanged(object sender, EventArgs e)
        {
            // Khởi tạo giá trị
            string sMaHoaDon = this.Txt_MaHoaDon.Text.Trim();
            string sMaSanPham = this.Txt_MaSP.Text.Trim();


            if (string.IsNullOrEmpty(this.Txt_SoLuong.Text.Trim()))
            {
                return;
            }

            int iSoLuongMua = int.Parse(this.Txt_SoLuong.Text.Trim());

            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDon.SingleOrDefault(n => n.MaHoaDon == sMaHoaDon & n.MaSanPham == sMaSanPham);

            if (null != chiTietHoaDon)
            {
                // có thay đổi
                if (iSoLuongMua != chiTietHoaDon.SoLuongMua && iSoLuongMua != 0)
                {
                    this.Btn_CapNhatSoLuong.Enabled = true;
                }
                else
                {
                    this.Btn_CapNhatSoLuong.Enabled = false;
                }
            }
            else
            {
                this.Btn_CapNhatSoLuong.Enabled = false;
            }
        }
        #endregion

        #region Xóa sản phẩm khỏi giỏ hàng
        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            // khởi tạo giá trị
            string sMaHoaDon = this.Txt_MaHoaDon.Text.Trim();
            int iSoLuongMua = int.Parse(this.Txt_SoLuong.Text.Trim());
            string sMaSanPham = this.Txt_MaSP.Text.Trim();
            double TongTien = 0;

            // kiểm tra hóa đơn
            var HoaDon = db.HoaDon.SingleOrDefault(n => n.MaHoaDon == sMaHoaDon);

            // Lấy ra hóa đơn sản phẩm hiện tại
            var chiTietHoaDon = db.ChiTietHoaDon.SingleOrDefault(n => n.MaHoaDon == sMaHoaDon & n.MaSanPham == sMaSanPham);

            // Xóa khỏi giỏ hàng
            db.ChiTietHoaDon.Remove(chiTietHoaDon);
            db.SaveChanges();

            // tính tông tiền cho đơn hàng
            var Chk_SLDonHang = db.ChiTietHoaDon.Where(n => n.MaHoaDon == sMaHoaDon).ToList();
            if (0 != Chk_SLDonHang.Count())
            {
                HoaDon.TongTien = db.ChiTietHoaDon.Where(n => n.MaHoaDon == sMaHoaDon).Sum(n => n.ThanhTien);
            }
            else
            {
                HoaDon.TongTien = TongTien;
                this.Txt_TamTinh.Text = "0";
                this.Txt_GiamGia.Text = "0";
                this.Txt_TongTien.Text = "0";
            }
            db.SaveChanges();

            // Hiển thị lên listview hóa đơn
            this.HienThiHoaDon(this.Txt_SDT.Text.Trim());

            this.Txt_TenSanPham.Clear();
            this.Txt_SoLuong.Clear();
            this.Btn_Xoa.Enabled = false;
            this.Btn_CapNhatSoLuong.Enabled = false;

            // Hiển thị thông báo hoàn tất cập nhật
            MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Hoàn tất thanh toán đơn hàng cho khách hàng
        private void Btn_ThanhToan_Click(object sender, EventArgs e)
        {
            // khởi tạo giá trị
            string sMaHoaDon = this.Txt_MaHoaDon.Text.Trim();

            // kiểm tra hóa đơn
            var HoaDon = db.HoaDon.SingleOrDefault(n => n.MaHoaDon == sMaHoaDon);


            // Hiển thị sản phẩm thuộc đơn hàng này
            var chiTietHoaDon = db.ChiTietHoaDon.Where(n => n.MaHoaDon == sMaHoaDon).ToList();
            foreach (var item in chiTietHoaDon)
            {
                // Cập nhật số lượng hiện còn trong chi tiết sản phẩm
                var chiTietSanPham = db.ChiTietSanPham.SingleOrDefault(n => n.MaSanPham == item.MaSanPham & n.NgaySuDungConLai == item.HanSuDung);

                // số lượng mua lớn hơn số lượng kho
                if (item.SoLuongMua > chiTietSanPham.SoLuongHienCon)
                {
                    MessageBox.Show("Số lượng trong kho không đủ đáp ứng.\nKho hiện còn: " + chiTietSanPham.SoLuongHienCon + " sản phẩm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                chiTietSanPham.SoLuongHienCon -= item.SoLuongMua;



                // Cập nhật số lượng đã bán trong sản phẩm
                var sanpham = db.SanPham.SingleOrDefault(n => n.MaSanPham == item.MaSanPham);

                // trường hợp số lượng mua nhiều hơn số lượng trong kho
                sanpham.DaBan += item.SoLuongMua;

            }

            // Cập nhật trạng thái
            HoaDon.TrangThai = 1;
            db.SaveChanges();

            // Hiển thị lên listview hóa đơn
            this.HienThiHoaDon(this.Txt_SDT.Text.Trim());

            // Hiển thị thông báo hoàn tất đặt hàng
            MessageBox.Show("Thanh toán thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        #endregion

        #region Cập nhật thông tin khách hàng
        private void Btn_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                #region Kiểm tra thông tin khách hàng

                // kiểm tra họ tên
                if (string.IsNullOrEmpty(this.Txt_HoTen.Text))
                {
                    MessageBox.Show("Mời nhập họ tên khách hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Txt_HoTen.Focus();
                    return;
                }

                // kiểm tra sở thích
                if (string.IsNullOrEmpty(this.Txt_SoThich.Text))
                {
                    MessageBox.Show("Mời nhập sở thích khách hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Txt_SoThich.Focus();
                    return;
                }
                #endregion

                KhachHang kh = db.KhachHang.SingleOrDefault(n => n.SDT == this.Txt_SDT.Text);
                kh.SDT = this.Txt_SDT.Text.Trim();
                kh.HoTen = this.Txt_HoTen.Text.Trim();
                kh.NgaySinh = this.Dtp_NgaySinh.Value;
                kh.GioiTinh = this.Cmb_GioiTinh.Text;
                kh.Sothich = this.Txt_SoThich.Text.Trim();
                kh.MaCongViec = Convert.ToString(this.Cmb_CongViec.SelectedValue);
                kh.MaThuNhap = Convert.ToString(this.Cmb_ThuNhap.SelectedValue);
                kh.MaTinhTrangSK = Convert.ToString(this.Cmb_SucKhoe.SelectedValue);
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Thực hiện thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion


        #endregion

        #region ========== METHOD ==========

        #region Hiển thị danh sách sản phẩm
        void LoadTable()
        {
            // Hiển thị combobox
            this.HienThiCombobox();

            // Ẩn các button thông tin khách hàng. Chỉ hiển thị textbox sdt
            this.Hidden_Controll(false);
            this.Btn_Luu.Visible = false;
            this.Btn_CapNhatSoLuong.Enabled = false;
            this.Btn_Xoa.Enabled = false;

            // Hiển thị danh sách sản phẩm
            this.HienThiSanPham("ALL");

        }
        #endregion

        #region Đổ dữ liệu lên combobox
        void HienThiCombobox()
        {
            // Hiển thị công việc
            var lst_CongViec = db.CongViec.ToList();
            Cmb_CongViec.DataSource = lst_CongViec;
            Cmb_CongViec.DisplayMember = "TenCongViec";
            Cmb_CongViec.ValueMember = "MaCongViec";

            // Hiển thị thu nhập
            var lst_ThuNhap = db.ThuNhap.ToList();
            Cmb_ThuNhap.DataSource = lst_ThuNhap;
            Cmb_ThuNhap.DisplayMember = "TenThuNhap";
            Cmb_ThuNhap.ValueMember = "MaThuNhap";

            // Hiển thị tình trạng sức khỏe
            var lst_TTSucKhoe = db.TinhTrangSucKhoe.ToList();
            Cmb_SucKhoe.DataSource = lst_TTSucKhoe;
            Cmb_SucKhoe.DisplayMember = "TenTinhTrang";
            Cmb_SucKhoe.ValueMember = "MaTinhTrangSK";

            // Hiển thị danh mục (loại sản phẩm)
            var lst_LoaiSanPham = db.LoaiSanPham.ToList();
            Cmb_DanhMuc.DataSource = lst_LoaiSanPham;
            Cmb_DanhMuc.DisplayMember = "TenLoaiSanPham";
            Cmb_DanhMuc.ValueMember = "MaLoaiSanPham";

            // hiển thị giới tính
            Cmb_GioiTinh.DisplayMember = "Text";
            Cmb_GioiTinh.ValueMember = "Value";
            var sex = new[] {
                new { Text = "Nam", Value = "Nam" },
                new { Text = "Nữ", Value = "Nữ" },
            };
            Cmb_GioiTinh.DataSource = sex;

            // hiển thị filter theo tên hoặc giá
            Cmb_Filter.DisplayMember = "Text";
            Cmb_Filter.ValueMember = "Value";
            var filter = new[] {
                new { Text = "Tên", Value = "0" },
                new { Text = "Giá", Value = "1" },
            };
            Cmb_Filter.DataSource = filter;


        }
        #endregion

        #region Hiển thị thông tin hóa đơn theo số điện thoại (TrangThai = 0 chưa thanh toán)
        void HienThiHoaDon(string sSDT)
        {
            // Xóa rỗng listview hóa đơn
            lsvHoaDon.Items.Clear();

            // Tìm kiếm hóa đơn theo SDT đã nhập
            var listHoaDonSDT = db.ChiTietHoaDon.Where(n => n.HoaDon.SDT == sSDT & n.HoaDon.TrangThai == 0).ToList();

            // Trường hợp tồn tại hóa đơn theo sdt
            if (0 != listHoaDonSDT.Count())
            {
                foreach (var item in listHoaDonSDT)
                {
                    // lấy tên sản phẩm
                    var tenSanPham = db.SanPham.SingleOrDefault(n => n.MaSanPham == item.MaSanPham);
                    string tensanpham = item.SanPham.TenSanPham;
                    ListViewItem lsvItem = new ListViewItem(tenSanPham.TenSanPham);
                    lsvItem.SubItems.Add(item.SoLuongMua.ToString());
                    lsvItem.SubItems.Add(item.GiaBan.ToString("#,###", cul.NumberFormat));
                    lsvItem.SubItems.Add(item.ThanhTien.ToString("#,###", cul.NumberFormat));
                    lsvItem.SubItems.Add(item.MaSanPham.ToString());
                    lsvHoaDon.Items.Add(lsvItem);
                    this.Txt_TamTinh.Text = item.HoaDon.TongTien.ToString("#,###", cul.NumberFormat);
                    this.Txt_MaHoaDon.Text = item.MaHoaDon;
                    this.Txt_GiamGia.Text = "0";
                    this.Txt_TongTien.Text = this.Txt_TamTinh.Text;
                }
            }
            else
            {
                this.Txt_MaHoaDon.Text = cm.MaHoaDon();
            }
        }
        #endregion

        #region Thêm sản phẩm vào listView
        void btn_Click(object sender, EventArgs e)
        {
            #region Khởi tạo giá trị
            string sMaHoaDon = this.Txt_MaHoaDon.Text.Trim();
            string sSDT = this.Txt_SDT.Text.Trim();

            #endregion

            #region Kiểm tra nhập sdt chưa
            if (string.IsNullOrEmpty(sSDT))
            {
                MessageBox.Show("Mời nhập số điện thoại khách hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Txt_SDT.Focus();
                return;
            }

            // kiểm tra đã lưu người này hay chưa
            var KhachHang = db.KhachHang.SingleOrDefault(n => n.SDT == sSDT);
            if (null == KhachHang)
            {
                MessageBox.Show("Lưu khách hàng trước khi mua hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Btn_Luu.Focus();
                return;
            }
            #endregion

            // Trường hợp đã nhập sđt => đã có mã hóa đơn
            // Kiểm tra hóa đơn này đã tồn tại trong db chưa?
            var chk_HoaDon = db.HoaDon.SingleOrDefault(n => n.MaHoaDon == sMaHoaDon & n.TrangThai == 0);

            // trường hợp chưa tồn tại hóa đơn với trạng thái chưa thanh toán
            if (null == chk_HoaDon)
            {
                HoaDon hd = new HoaDon();
                hd.MaHoaDon = sMaHoaDon;
                hd.NgayBan = DateTime.Now;
                hd.TrangThai = 0; // chưa thanh toán
                hd.TongTien = 0;
                hd.SDT = this.Txt_SDT.Text;
                hd.TaiKhoanNV = "Admin";
                db.HoaDon.Add(hd);
                db.SaveChanges();
            }
            // trường hợp đã tồn tại hóa đơn trước đó r

            // lấy thông tin sản phẩm từ button đang click
            string sSanPham = Convert.ToString((sender as Button).Tag);
            var pattern = @"= \S*\b";
            var result = Regex.Matches(sSanPham, pattern);

            sMaSanPham = result[0].ToString().Substring(2);
            sDonGiaBan = result[2].ToString().Substring(2);
            sHSD = result[3].ToString().Substring(2);

            // Thêm mới chi tiết đơn hàng
            // kiểm tra sản phẩm này đã tồn tại trong ctdh hay chưa: Nếu tồn tại số lượng mua = số lượng mua + 1
            var chk_CTHD = db.ChiTietHoaDon.SingleOrDefault(n => n.MaHoaDon == sMaHoaDon & n.MaSanPham == sMaSanPham);
            if (null == chk_CTHD)
            {
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.MaHoaDon = sMaHoaDon;
                cthd.MaSanPham = sMaSanPham;
                cthd.HanSuDung = int.Parse(sHSD);
                cthd.SoLuongMua = 1;
                cthd.GiaBan = float.Parse(sDonGiaBan);
                cthd.ThanhTien = float.Parse(sDonGiaBan);
                db.ChiTietHoaDon.Add(cthd);
                db.SaveChanges();
            }
            else
            {
                chk_CTHD.SoLuongMua += 1;
                chk_CTHD.ThanhTien += float.Parse(sDonGiaBan);
                db.SaveChanges();
            }

            // tính tông tiền cho đơn hàng
            var TongTien = db.ChiTietHoaDon.Where(n => n.MaHoaDon == sMaHoaDon).Sum(n => n.ThanhTien);
            var HoaDon = db.HoaDon.SingleOrDefault(n => n.MaHoaDon == sMaHoaDon & n.TrangThai == 0);
            HoaDon.TongTien = TongTien;

            // Hiển thị lên listview hóa đơn
            this.HienThiHoaDon(this.Txt_SDT.Text.Trim());
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

        #region Tính mã giảm giá
        void TinhTongTien()
        {
            if (string.IsNullOrEmpty(this.Txt_GiamGia.Text))
            {
                return;
            }
            float fTamTinh = float.Parse(this.Txt_TamTinh.Text.Replace(".", ""));
            float fGiamGia = float.Parse(this.Txt_GiamGia.Text.Replace(".", ""));

            if (fGiamGia > fTamTinh)
            {
                MessageBox.Show("Giảm giá không hợp lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Txt_GiamGia.Clear();
                this.Txt_GiamGia.Focus();
                this.Txt_TongTien.Text = this.Txt_TamTinh.Text;
                return;
            }

            this.Txt_TongTien.Text = (fTamTinh - fGiamGia).ToString("#,###", cul.NumberFormat);
        }
        #endregion

        #endregion

        #region ========== SUBFORM ==========

        #region Hiển thị form quản lý sữa
        private void SanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLySanPham fQuanLySanPham = new QuanLySanPham();
            fQuanLySanPham.ShowDialog();
        }
        #endregion

        #region Hiển thị from Quản lý hóa đơn
        private void QuanLyHoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon fQLHD = new QuanLyHoaDon();
            fQLHD.ShowDialog();
        }
        #endregion

        #endregion

        private void SuaTonKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuaTonKho fSTK = new SuaTonKho();
            fSTK.ShowDialog();
        }

        private void SuaHetHanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuaQuaHan fSQH = new SuaQuaHan();
            fSQH.ShowDialog();
        }
    }
}

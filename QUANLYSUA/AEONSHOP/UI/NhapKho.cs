using AEONSHOP.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AEONSHOP.UI
{
    public partial class NhapKho : Form
    {
        EF_AEONSHOP db = new EF_AEONSHOP();
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

        public NhapKho()
        {
            InitializeComponent();
        }

        private void NhapKho_Load(object sender, EventArgs e)
        {
            // Hiển thị mã nhập kho và mã sản phẩm
            var lst_SanPham = db.SanPham.ToList();
            CmbMaSanPham.DataSource = lst_SanPham;
            CmbMaSanPham.DisplayMember = "TenSanPham";
            CmbMaSanPham.ValueMember = "MaSanPham";

            var lst_NhapKho = db.NhapKho.ToList();
            Cmb_MaNhapKho.DataSource = lst_NhapKho;
            Cmb_MaNhapKho.DisplayMember = "MaNhapKho";
            Cmb_MaNhapKho.ValueMember = "MaNhapKho";
        }

        private void Cmb_MaNhapKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sMaNhapKho = Convert.ToString(this.Cmb_MaNhapKho.Text);

            var nhapkho = db.NhapKho.SingleOrDefault(n => n.MaNhapKho == sMaNhapKho);
            if (null != nhapkho)
            {
                this.Txt_NgayNhapKho.Text = nhapkho.NgayNhapKho.ToString("dd/MM/yyyy");
                this.Txt_TongTien.Text = nhapkho.TongTien.ToString("#,###", cul.NumberFormat);
            }
        }

        private void CmbMaSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sMaSanPham = Convert.ToString(this.CmbMaSanPham.SelectedValue);

            var sanpham = db.SanPham.SingleOrDefault(n => n.MaSanPham == sMaSanPham);
            if (null != sanpham)
            {
                this.Txt_MaSanPham.Text = sanpham.MaSanPham;
                this.Txt_SoLuongNhap.Text = "1";
                this.Txt_SoLuongNhap.Text = "0";
                this.Txt_TongTien.Text = "0";
            }
        }

        private void Btn_NhapKho_Click(object sender, EventArgs e)
        {
            DateTime dt_NgaySX = DateTime.ParseExact(this.Dtp_NgaySanXuat.Text.Substring(0,10), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dt_HanSD = DateTime.ParseExact(this.Dtp_NgayHetHan.Text.Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string sMaNhapKho = Convert.ToString(this.Cmb_MaNhapKho.Text);
            string sMaSanPham = this.Txt_MaSanPham.Text;
            string sSoLuongNhap = this.Txt_SoLuongNhap.Text;

            #region Kiểm tra

            if (string.IsNullOrEmpty(this.Txt_MaSanPham.Text))
            {
                MessageBox.Show("Hãy chọn lại sảm phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ngày sai
            if (1 < DateTime.Compare(dt_NgaySX, dt_HanSD))
            {
                MessageBox.Show("Ngày SX < Ngày SD", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dtp_NgayHetHan.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.Txt_SoLuongNhap.Text))
            {
                MessageBox.Show("Không bỏ trống số lượng nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Txt_SoLuongNhap.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.Txt_SoLuongNhap.Text))
            {
                MessageBox.Show("Không bỏ trống đơn giá nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Txt_SoLuongNhap.Focus();
                return;
            }
            #endregion

            #region Xu ly

            // lưu sp nhập
            ChiTietNhapKho ctnk = new ChiTietNhapKho();
            ctnk.MaNhapKho = sMaNhapKho;
            ctnk.MaSanPham = sMaSanPham;
            ctnk.SoLuongNhap = int.Parse(this.Txt_SoLuongNhap.Text);
            ctnk.DonGiaNhap = int.Parse(this.Txt_DonGiaNhap.Text);
            ctnk.ThanhTien = int.Parse(this.Txt_SoLuongNhap.Text) * int.Parse(this.Txt_DonGiaNhap.Text);
            db.ChiTietNhapKho.Add(ctnk);
            db.SaveChanges();

            //tính lại tổng tiền
            var tongtien = db.NhapKho.SingleOrDefault(n => n.MaNhapKho == sMaNhapKho);
            tongtien.TongTien = db.ChiTietNhapKho.Sum(n => n.ThanhTien);
            db.SaveChanges();

            // thêm vào chi tiết sản phẩm
            var chitietsanpham = db.ChiTietSanPham.Where(n => n.MaSanPham == sMaSanPham).ToList();
            foreach (var item in chitietsanpham)
            {
                if (0 == DateTime.Compare(item.NgaySanXuat, dt_NgaySX)
                    && 0 == DateTime.Compare(item.HanSuDung, dt_HanSD))
                {
                    // đã tồn tại => cộng số lượng + đơn giá nhập, giá bán
                    item.SoLuongHienCon += int.Parse(sSoLuongNhap);
                    item.DonGiaNhap = double.Parse(this.Txt_DonGiaNhap.Value.ToString());
                    item.DonGiaBan = double.Parse(this.Txt_DonGiaNhap.Value.ToString()) * (0.1);
                    db.SaveChanges();
                }
                else
                {
                    // trường hợp mới => thêm mới sản phẩm
                    ChiTietSanPham ctsp = new ChiTietSanPham();
                    ctsp.NgaySanXuat = dt_NgaySX;
                    ctsp.HanSuDung = dt_HanSD;
                    ctsp.MaSanPham = sMaSanPham;
                    ctsp.NgaySuDungConLai = (DateTime.Now - dt_HanSD).Days;
                    ctsp.SoLuongHienCon = int.Parse(sSoLuongNhap);
                    ctsp.DonGiaNhap = double.Parse(this.Txt_DonGiaNhap.Value.ToString());
                    ctsp.DonGiaBan = double.Parse(this.Txt_DonGiaNhap.Value.ToString()) * (0.1);
                    db.ChiTietSanPham.Add(ctsp);
                    db.SaveChanges();
                }
            }
            #endregion
        }
    }
}

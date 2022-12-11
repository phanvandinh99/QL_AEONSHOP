using AEONSHOP.COMMON;
using AEONSHOP.EF;
using System;
using System.CodeDom;
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
    public partial class QuanLyHoaDon : Form
    {
        public QuanLyHoaDon()
        {
            InitializeComponent();
        }

        #region Khởi tạo đối tượng
        EF_AEONSHOP db = new EF_AEONSHOP();
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        #endregion

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            // hiển thị theo loại hóa đơn
            Cmb_TrangThai.DisplayMember = "Text";
            Cmb_TrangThai.ValueMember = "Value";
            var filter = new[] {
                new { Text = "Chưa Thanh Toán", Value = "0" },
                new { Text = "Đã Thanh Toán", Value = "1" },
            };
            Cmb_TrangThai.DataSource = filter;

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

            // hiển thị giới tính
            Cmb_GioiTinh.DisplayMember = "Text";
            Cmb_GioiTinh.ValueMember = "Value";
            var sex = new[] {
                new { Text = "Nam", Value = "Nam" },
                new { Text = "Nữ", Value = "Nữ" },
            };
            Cmb_GioiTinh.DataSource = sex;

            this.HienThiHoaDon(1);
        }
        #region Hiển thị danh sách hóa đơn
        void HienThiHoaDon(int iTrangThai)
        {
            var hoaDon = db.HoaDon.Where(n => n.TrangThai == iTrangThai).ToList();

            // Xóa rỗng listview hóa đơn
            lsvHoaDon.Items.Clear();

            // Trường hợp tồn tại hóa đơn theo sdt
            if (0 != hoaDon.Count())
            {
                foreach (var item in hoaDon)
                {
                    ListViewItem lsvItem = new ListViewItem(item.MaHoaDon);
                    lsvItem.SubItems.Add(item.KhachHang.HoTen.ToString());
                    lsvItem.SubItems.Add(item.KhachHang.SDT.ToString());
                    lsvItem.SubItems.Add(item.NgayBan.ToString("dd/MM/yyyy"));
                    lsvItem.SubItems.Add(item.TongTien.ToString("#,###", cul.NumberFormat));
                    lsvHoaDon.Items.Add(lsvItem);
                }
            }
            else
            {
                //this.Txt_MaHoaDon.Text = cm.MaHoaDon();
            }
        }
        #endregion

        private void Cmb_TrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThiHoaDon(int.Parse(this.Cmb_TrangThai.SelectedValue.ToString()));
        }

        private void lsvHoaDon_MouseClick(object sender, MouseEventArgs e)
        {
            string sSDT = lsvHoaDon.SelectedItems[2].SubItems[0].Text;

            var Infor_KhachHang = db.KhachHang.SingleOrDefault(n => n.SDT == sSDT);

            // Hiển thị leen textbox
            this.Txt_HoTen.Text = Infor_KhachHang.HoTen;
            this.Dtp_NgaySinh.Text = Infor_KhachHang.NgaySinh.ToString();
            this.Cmb_GioiTinh.Text = Infor_KhachHang.GioiTinh;
            this.Txt_SoThich.Text = Infor_KhachHang.Sothich;
            this.Cmb_SucKhoe.SelectedItem = Infor_KhachHang.TinhTrangSucKhoe;
            this.Cmb_CongViec.SelectedItem = Infor_KhachHang.CongViec;
            this.Cmb_ThuNhap.SelectedItem = Infor_KhachHang.ThuNhap;

        }
    }
}

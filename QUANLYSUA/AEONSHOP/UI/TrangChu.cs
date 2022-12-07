using AEONSHOP.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AEONSHOP.UI
{
    public partial class TrangChu : Form
    {
        EF_AEONSHOP db = new EF_AEONSHOP();

        #region Khởi tạo giá trị
        private DataTable datatable;
        #endregion

        public TrangChu()
        {
            InitializeComponent();
        }

        #region Hiển thị danh sách sản phẩm
        void LoadTable()
        {
            // Xóa rỗng sản phẩm
            FLP_Product.Controls.Clear();

            // Hiển thị danh sách sản phẩm
            var lst_Producr = db.SanPham.Join(db.ChiTietSanPham,
                                              n => n.MaSanPham,
                                              m => m.MaSanPham,
                                              (n, m) => new { n, m });

            foreach (var item in lst_Producr)
            {
                Button btn_product = new Button() { Width = 73, Height = 72 };
                Label lbl_Product_Name = new Label() { Width = 120, Height = 50 };

                lbl_Product_Name.Text = item.n.TenSanPham + ".\nGiá: " + item.m.DonGiaBan;

                lbl_Product_Name.Dock = DockStyle.Fill;
                lbl_Product_Name.TextAlign = ContentAlignment.MiddleLeft;
                lbl_Product_Name.AutoSize = false;

                FLP_Product.Controls.Add(btn_product); // Thêm danh sách hình ảnh sản phẩm
                FLP_Product.Controls.Add(lbl_Product_Name); // Thêm danh sách tên sản phẩm
            }
        }
        #endregion

        #region Load màn hình
        private void TrangChu_Load(object sender, EventArgs e)
        {
            LoadTable();

            // Add collum hóa đơn
            datatable = new DataTable();
            datatable.Columns.Add("Tên Sản Phẩm");
            datatable.Columns.Add("Số lượng");
            datatable.Columns.Add("Thành tiền");
            Grid_Order.DataSource = datatable;
        }
        #endregion

        #region Kiểm tra thông tin khách hàng
        private void Txt_SDT_Leave(object sender, EventArgs e)
        {
            #region Validation

            // trường hợp sdt chưa đủ 10 số
            if (10 != this.Txt_SDT.Text.Length)
            {
                MessageBox.Show("Số điện thoại phải đủ 10 kí tự", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Txt_SDT.Focus();
                return;
            }

            // Trường hợp chưa nhập tên khách hàng
            //if (string.IsNullOrEmpty(this.Txt_HoTen.Text))
            //{
            //    MessageBox.Show("Tên khách hàng không được bỏ trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Txt_HoTen.Focus();
            //    return;
            //}

            #endregion

            #region Kiểm tra khách hàng đã tồn tại trong hệ thống chưa?
            var Infor_KhachHang = db.KhachHang.SingleOrDefault(n => n.SDT == this.Txt_SDT.Text);

            // trường hợp chưa tồn tại
            if (null == Infor_KhachHang)
            {
                this.Txt_HoTen.Clear();
            }
            // Trường hợp đã tồn tại trong hệ thống
            else
            {
                this.Txt_HoTen.Text = Infor_KhachHang.HoTen;
                this.Dtp_NgaySinh.Text = Infor_KhachHang.NgaySinh.ToString();
                this.Cmb_GioiTinh.SelectedItem = Infor_KhachHang.NgaySinh;
                this.Cmb_SoThich.SelectedItem = Infor_KhachHang.Sothich;
                this.Cmb_SucKhoe.SelectedItem = Infor_KhachHang.CongViec;
                this.Cmb_CongViec.SelectedItem = Infor_KhachHang.ThuNhap;
                this.Cmb_ThuNhap.SelectedItem = Infor_KhachHang.ThuNhap;
            }
            #endregion
        }
        #endregion

        #region Chỉ được nhập số trong textbox số điện thoại
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
        #endregion
    }
}

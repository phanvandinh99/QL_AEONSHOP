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
    public partial class DangNhap : Form
    {
        private EF_AEONSHOP db = new EF_AEONSHOP();

        public DangNhap()
        {
            InitializeComponent();
        }
        #region Button Đăng nhập
        private void Btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị trạng thái trỏ chuột
                Cursor = Cursors.WaitCursor;

                // Khởi tạo và gán giá trị cho biến
                string sUserName = this.Txt_UserName.Text.Trim();
                string sPassword = this.Txt_Password.Text.Trim();

                #region Check điều kiện đăng nhập

                // trường hợp bỏ trống tên đăng nhập
                if (string.IsNullOrEmpty(this.Txt_UserName.Text))
                {
                    MessageBox.Show("Không được bỏ trống tên đăng nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Txt_UserName.Focus();
                    return;
                }

                // trường hợp bỏ trống mật khẩu
                if (string.IsNullOrEmpty(this.Txt_Password.Text))
                {
                    MessageBox.Show("Không được bỏ trống mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Txt_Password.Focus();
                    return;
                }

                // Trường hợp tên đăng nhập chưa tồn tại trong hệ thống
                var chk_TaiKhoanKhongTonTai = db.NhanVien.SingleOrDefault(n => n.TaiKhoanNV == sUserName);
                if (null == chk_TaiKhoanKhongTonTai)
                {
                    MessageBox.Show("Tài khoản không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Txt_UserName.Clear();
                    this.Txt_Password.Clear();
                    this.Txt_UserName.Focus();
                    return;
                }
                #endregion

                #region Xử lý đăng nhập
                var chk_DangNhap = db.NhanVien.SingleOrDefault(n => n.TaiKhoanNV == sUserName & n.MatKhau == sPassword);
                if (null == chk_DangNhap)
                {
                    MessageBox.Show("Tài khoản không tồn tại trong hệ thống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Hide();
                    TrangChu frm_TrangChu = new TrangChu();
                    frm_TrangChu.ShowDialog();
                }
                #endregion
            }
            finally
            {
                // マウスカーソルを元に戻す
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Button thoát
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            DialogResult Lresult = DialogResult.None;
            Lresult = MessageBox.Show("Bạn muốn đóng ứng dụng",
                                      "Thông Báo",
                                      MessageBoxButtons.OKCancel,
                                      MessageBoxIcon.Information,
                                      MessageBoxDefaultButton.Button2);

            if (Lresult.Equals(DialogResult.Cancel))
            {
                return;
            }

            this.Close();
        }
        #endregion

        #region Hiển thị mật khẩu
        private void Chk_DislayPassword_CheckedChanged(object sender, EventArgs e)
        {
            #region Kiểm tra hiển thị/ không hiển thị
            if (this.Chk_DislayPassword.Checked == true)
            {
                this.Txt_Password.UseSystemPasswordChar = false;
            }
            else
            {
                this.Txt_Password.UseSystemPasswordChar = true;
            }
            #endregion
        }
        #endregion

    }
}

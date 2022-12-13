using AEONSHOP.COMMON;
using AEONSHOP.EF;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AEONSHOP.UI
{
    public partial class ThemMoiSanPham : Form
    {
        EF_AEONSHOP db = new EF_AEONSHOP();

        public ThemMoiSanPham()
        {
            InitializeComponent();
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            this.XoaRong();
        }

        void XoaRong()
        {
            this.Txt_TenSanPham.Clear();
            this.Txt_TenSanPham.Focus();
            this.Txt_Link.Clear();
            this.Txt_MoTa.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                // image file path  
                Txt_Link.Text = open.FileName;
            }
        }

        private void Btn_ThemMoi_Click(object sender, EventArgs e)
        {
            string sTenSanPham = this.Txt_TenSanPham.Text;
            string sMoTa = this.Txt_MoTa.Text;
            string sAnh = this.Txt_Link.Text;

            if (string.IsNullOrEmpty(sTenSanPham))
            {
                MessageBox.Show("Không được bỏ trống tên sản phẩm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(sTenSanPham))
            {
                MessageBox.Show("Không được bỏ trống mô tả", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(sTenSanPham))
            {
                MessageBox.Show("Không được bỏ trống hình ảnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Định dạng thư mục lưu hình ảnh
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string filename = Path.Combine(dir, "");
            filename = filename.Replace("QUANLYSUA\\AEONSHOP\\bin\\Debug", "Image\\AnhSanPham\\");
            File.Copy(Txt_Link.Text, Path.Combine(filename, Path.GetFileName(sAnh)));


            SanPham sp = new SanPham();
            sp.MaSanPham = this.Txt_MaSanPham.Text;
            sp.TenSanPham = sTenSanPham;
            sp.DaBan = 0;
            sp.Anh = Path.GetFileName(sAnh);
            sp.MoTa = sMoTa;
            sp.MaLoaiSanPham = Convert.ToString(this.Cmb_LoaiSanPham.SelectedValue);
            db.SanPham.Add(sp);
            db.SaveChanges();
            this.XoaRong();
            MessageBox.Show("Thêm mới sản phẩm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ThemMoiSanPham_Load(object sender, EventArgs e)
        {
            Common cm = new Common();
            this.Txt_MaSanPham.Text = cm.MaSanPham();

            // Hiển thị danh mục (loại sản phẩm)
            var lst_LoaiSanPham = db.LoaiSanPham.Where(n=>n.MaLoaiSanPham != "ALL").ToList();
            Cmb_LoaiSanPham.DataSource = lst_LoaiSanPham;
            Cmb_LoaiSanPham.DisplayMember = "TenLoaiSanPham";
            Cmb_LoaiSanPham.ValueMember = "MaLoaiSanPham";
        }
    }
}

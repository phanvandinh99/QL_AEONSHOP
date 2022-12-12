using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace AEONSHOP.UI
{
    public partial class ThemMoiSanPham : Form
    {
        public ThemMoiSanPham()
        {
            InitializeComponent();
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            this.Txt_TenSanPham.Clear();
            this.Txt_TenSanPham.Focus();
            this.textBox1.Clear();
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
                textBox1.Text = open.FileName;
            }
        }

        private void Btn_ThemMoi_Click(object sender, EventArgs e)
        {
            string sTenSanPham = this.Txt_TenSanPham.Text;
            string sMoTa = this.Txt_MoTa.Text;
            string sAnh = this.textBox1.Text;

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

            pictureBox1.Image.Save(textBox1.Text);

        }
    }
}

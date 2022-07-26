using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiSanBong
{
    public partial class DangNhap : Form
    {
        TaiKhoan tk = new TaiKhoan();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            if (tk.DangNhap(txtDangNhap.Text, txtPass.Text) == true)
            {
                MessageBox.Show("Đăng Nhập Thành Công!");
                    Main_QuanLiSanBong main = new Main_QuanLiSanBong();
                    this.Hide();
                    main.Show();
            }
            else
            {
                MessageBox.Show("Đăng Nhập Thất Bại");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

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
    public partial class ThongTinTaiKhoan : Form
    {
        TaiKhoan tk = new TaiKhoan();
        public static string username;
        public static string name;
        public ThongTinTaiKhoan()
        {
            InitializeComponent();
        }

        private void ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            DataTable tttk = tk.thongtintaikhoan(username);
            txtHoTen.Text = tttk.Rows[0][0].ToString();
            txtSDT.Text = tttk.Rows[0][1].ToString();
            DateTime datens = DateTime.Parse(tttk.Rows[0][2].ToString());
            dtpNs.Value = DateTime.Parse(datens.ToShortDateString());
            cbGioiTinh.SelectedItem = tttk.Rows[0][3].ToString();
            label11.Text = username;
            label12.Text = name;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string ngaysinh = dtpNs.Value.ToString("dd/MM/yyyy");
            if (tk.CapNhatThongTin(username, txtHoTen.Text, txtSDT.Text, ngaysinh, cbGioiTinh.SelectedItem.ToString()) == true)
            {
                MessageBox.Show("Cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnDoiPass_Click(object sender, EventArgs e)
        {

            if (tk.KiemTraPass(username, txtPass.Text) == true)
            {
                if (!txtNewPass.Text.Equals(txtRePass.Text))
                {

                    errorProvider1.SetError(txtRePass, "Mật khẩu nhập lại không khớp");
                }
                else
                {
                    errorProvider1.SetError(txtRePass, null);
                    if (tk.DoiPass(username, txtNewPass.Text) == true)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công!");
                    }
                    else
                    {
                        {
                            MessageBox.Show("Đổi mật khẩu thất bại!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng!");
            }
        }

    }
}

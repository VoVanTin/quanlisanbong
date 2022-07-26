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
    public partial class QuanLyNhanVien : Form
    {
        TaiKhoan tk = new TaiKhoan();
        QuanLyXuLy ql = new QuanLyXuLy();
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void btnQuyen_Click(object sender, EventArgs e)
        {
            string quyen;
            if(cbbQuyen.SelectedItem == "Quản Lý")
            {
                quyen = "1";
            }
            else
            {
                quyen = "2";
            }

            if (ql.capnhatQuyen(txtTenDangNhap.Text, quyen) == true)
            {
                MessageBox.Show("Cập nhật quyền "+cbbQuyen.SelectedItem+" cho username "+txtTenDangNhap.Text+" thành công!");
                dataGridView1.DataSource = ql.loadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show("Cập nhật quyền " + cbbQuyen.SelectedItem + " cho username " + txtTenDangNhap.Text + " thất bại!");
            }
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            if(ql.Datlaimk(txtTenDangNhap.Text)==true)
            {
                MessageBox.Show("Đặt lại mật khẩu cho username "+txtTenDangNhap.Text+" thành công!");
                dataGridView1.DataSource = ql.loadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu cho username " + txtTenDangNhap.Text + " thất bại!");
            }
        }

        private void btnCapNhatThongTin_Click(object sender, EventArgs e)
        {
            if (tk.kiemtratontai_sdt_capnhat(txtTenDangNhap.Text, txtSdt.Text) == true)
            {
                MessageBox.Show("Số điện thoại này thuộc về nhân viên khác!");
            }
            else
            {
                if (ql.capnhatthongtin(txtTenDangNhap.Text, txtHoTen.Text, cbbGioiTinh.SelectedItem.ToString(), txtSdt.Text, dtpNs.Value.ToString("dd/MM/yyyy")) == true)
                {
                    MessageBox.Show("Cập nhật thông tin cho username " + txtTenDangNhap.Text + " thành công!");
                    dataGridView1.DataSource = ql.loadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin cho username " + txtTenDangNhap.Text + " thất bại!");
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ql.loadDanhSachNhanVien();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin muốn tìm kiếm!");
            }
            dataGridView1.DataSource = ql.timKiemNhanVien(txtTimKiem.Text);
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string user = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DataTable nv = ql.GetNhanVien(user);
            txtTenDangNhap.Text = nv.Rows[0][0].ToString();
            txtHoTen.Text = nv.Rows[0][2].ToString();
            txtSdt.Text = nv.Rows[0][3].ToString();
            DateTime datens = DateTime.Parse(nv.Rows[0][4].ToString());
            dtpNs.Value = DateTime.Parse(datens.ToShortDateString());
            cbbGioiTinh.SelectedItem = nv.Rows[0][5].ToString();
            if (nv.Rows[0][6].ToString() == "1")
            {
                cbbQuyen.SelectedItem = "Quản Lý";
            }
            else
            {
                cbbQuyen.SelectedItem = "Nhân Viên";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string quyen;
            if(cbbQuyen.SelectedItem == "Quản Lý")
            {
                quyen = "1";
            }
            else
            {
                quyen = "2";
            }
            if(tk.kiemtratontai_username_sdt(txtTenDangNhap.Text,txtSdt.Text)==true)
            {
                MessageBox.Show("Tên đăng nhập hoặc sđt đã được sử dụng!");
            }
            else
            {
                if (ql.themNV(txtTenDangNhap.Text, txtHoTen.Text, txtSdt.Text, dtpNs.Value.ToString("dd/MM/yyyy"), cbbGioiTinh.SelectedItem.ToString(), quyen) == true)
                {
                    MessageBox.Show("Thêm nhân viên thành công!");
                    dataGridView1.DataSource = ql.loadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa nhân viên này!", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string username = txtTenDangNhap.Text;
                if (username == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên muốn xóa");
                }
                else
                {
                    if (ql.kiemtrakhoangoai(username) == true)
                    {
                        MessageBox.Show("Không thể xóa nhân viên này! (Lỗi Khóa Ngoại)");
                    }
                    else
                    {
                        if (ql.xoaNV(username) == true)
                        {
                            MessageBox.Show("Xóa Nhân Viên thành công!");
                            dataGridView1.DataSource = ql.loadDanhSachNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Xóa Nhân Viên thất bại!");
                        }
                    }

                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            
        }
    }
}

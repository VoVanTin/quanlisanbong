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
    public partial class QuanLyKhachHang : Form
    {
        DatSanXuLy xl = new DatSanXuLy();
        QuanLyXuLy ql = new QuanLyXuLy();
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ql.capnhatkhachhang(txtMaKH.Text, txtTenKH.Text, cbbGioiTinh.SelectedItem.ToString(), txtSDT.Text, dtpNs.Value.ToString("dd/MM/yyyy")) == true)
            {
                MessageBox.Show("Cập nhật khách hàng thành công!");
                dataGridView1.DataSource = ql.loadDanhSachKhachHang();
            }
            else
            {
                MessageBox.Show("Cập nhật khách hàng thất bại!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (xl.kiemtrakhachhang(txtSDT.Text) > 0)
            {
                MessageBox.Show("Số điện thoại này đã có tài khoản!");
            }
            else
            {
                if (ql.themKH(txtTenKH.Text, txtSDT.Text, dtpNs.Value.ToString("dd/MM/yyyy"), cbbGioiTinh.SelectedItem.ToString()) == true)
                {
                    MessageBox.Show("Thêm Khách hàng thành công)");
                    dataGridView1.DataSource = ql.loadDanhSachKhachHang();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin muốn tìm kiếm!");
            }
            dataGridView1.DataSource = ql.timkiemKhachHang(txtTimKiem.Text);
            
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;
            dataGridView1.DataSource = ql.loadDanhSachKhachHang();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataTable kh = ql.GetKhachHang(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtMaKH.Text = kh.Rows[0][0].ToString();
            txtTenKH.Text = kh.Rows[0][1].ToString();
            txtSDT.Text = kh.Rows[0][2].ToString();
            DateTime datens = DateTime.Parse(kh.Rows[0][4].ToString());
            dtpNs.Value = DateTime.Parse(datens.ToShortDateString());
            cbbGioiTinh.SelectedItem = kh.Rows[0][3].ToString();

        }
    }
}

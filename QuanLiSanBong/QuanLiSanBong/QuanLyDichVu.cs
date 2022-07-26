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
    public partial class QuanLyDichVu : Form
    {
        QuanLyXuLy ql = new QuanLyXuLy();
        public QuanLyDichVu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void QuanLyDichVu_Load(object sender, EventArgs e)
        {
            txtMa.Enabled = false;
            dataGridView1.DataSource = ql.loadDanhSachDichVu();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataTable dv = ql.GetDichVu(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtMa.Text = dv.Rows[0][0].ToString();
            txtTenDV.Text = dv.Rows[0][1].ToString();
            txtLoai.Text = dv.Rows[0][2].ToString();
            txtGia.Text = dv.Rows[0][3].ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin muốn tìm kiếm!");
            }
            dataGridView1.DataSource = ql.timKiemDV(txtTimKiem.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ql.themDV(txtTenDV.Text, txtLoai.Text, txtGia.Text) == true)
            {
                MessageBox.Show("Thêm dịch vụ thành công!");
                dataGridView1.DataSource = ql.loadDanhSachDichVu();
            }
            else
            {
                MessageBox.Show("Thêm dịch vụ thất bại!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(ql.capnhatdichvu(txtMa.Text,txtTenDV.Text, txtLoai.Text, txtGia.Text) == true)
            {
                MessageBox.Show("Cập nhật dịch vụ thành công!");
                dataGridView1.DataSource = ql.loadDanhSachDichVu();
            }
            else
            {
                MessageBox.Show("Cập nhật vụ thất bại!");
            }
        }
    }
}

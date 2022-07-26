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
    public partial class QuanLySan : Form
    {
        QuanLyXuLy ql = new QuanLyXuLy();
        public QuanLySan()
        {
            InitializeComponent();
        }

        private void QuanLySan_Load(object sender, EventArgs e)
        {
            txtMaSan.Enabled = false;
            dataGridView1.DataSource = ql.loadDanhSachSan();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string matensan = txtTimKiem.Text;
            dataGridView1.DataSource =ql.timKiemSan(matensan);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string masan = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DataTable sanbong = ql.GetSanBong(masan);
            txtMaSan.Text = sanbong.Rows[0][0].ToString();
            txtTenSan.Text = sanbong.Rows[0][1].ToString();
            txtGiaSan.Text = sanbong.Rows[0][2].ToString();
            txtTrangThai.Text = sanbong.Rows[0][3].ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(ql.themsan(txtTenSan.Text,txtGiaSan.Text)==true)
            {
                MessageBox.Show("Thêm sân thành công!");
                dataGridView1.DataSource = ql.loadDanhSachSan();
            }
            else
            {
                MessageBox.Show("Thêm sân thất bại");
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
             if(ql.capnhatsan(txtMaSan.Text,txtTenSan.Text,txtGiaSan.Text)==true)
            {
                MessageBox.Show("cập nhật sân thành công!");
                dataGridView1.DataSource = ql.loadDanhSachSan();
            }
            else
            {
                MessageBox.Show("Cập nhật sân thất bại!");
            }
        }
    }
}

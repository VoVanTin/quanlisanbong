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
    public partial class DanhSachDatSan : Form
    {
        XemChiTietDatSan ct = new XemChiTietDatSan();
        DatSanXuLy xl = new DatSanXuLy();
        public DanhSachDatSan()
        {
            InitializeComponent();
        }
        

        private void DanhSachDatSan_Load(object sender, EventArgs e)
        {
            txtMaLoai.Enabled = false;
            txtTenLoai.Enabled = false;
            txtDonGia.Enabled = false;
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            dataGridView1.DataSource = xl.loadDatSan();
            comboBox1.DataSource = xl.loadcbbLoaiSan();
            comboBox1.DisplayMember = "LoaiSan";
            comboBox1.ValueMember = "MaSan";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable thontinsanbong = xl.loadSanBong_cbb(comboBox1.SelectedValue.ToString());
            txtMaLoai.Text = thontinsanbong.Rows[0][0].ToString();
            txtTenLoai.Text = thontinsanbong.Rows[0][1].ToString();
            txtDonGia.Text = thontinsanbong.Rows[0][2].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text == string.Empty )
            {
                errorProvider1.SetError(comboBox1, "Vui lòng chọn sân!");
            }
            else if (cbGioiTinh.SelectedItem == null)
            {
                errorProvider1.SetError(comboBox1, null);
                errorProvider1.SetError(cbGioiTinh, "Vui lòng chọn giới tính!");
            }
            else
            {
                errorProvider1.SetError(comboBox1, null);
                errorProvider1.SetError(cbGioiTinh,null);
                string date = dtpNgayApDung.Value.ToString("yyyy/MM/dd");
                if (xl.kiemtraDatSan(date, txtGioVao.Text, txtGioRa.Text, txtMaLoai.Text) == false)
                {
                    MessageBox.Show("Khung giờ này đã có sân được đặt!");
                }
                else
                {
                    string ngayapdung = dtpNgayApDung.Value.ToString("dd/MM/yyyy");
                    string ngaysinh = dtpNgaySinh.Value.ToString("dd/MM/yyyy");
                    string gioitinh = cbGioiTinh.SelectedItem.ToString();
                    if (xl.DatSan(ngayapdung, txtGioVao.Text, txtGioRa.Text, txtMaLoai.Text, txtHoTen.Text, txtSoGio.Text, txtSDT.Text, gioitinh, ngaysinh) == true)
                    {
                        MessageBox.Show("Đặt sân thành công!");
                        dataGridView1.DataSource = xl.loadDatSan();
                    }
                    else
                    {
                        MessageBox.Show("Đặt sân thất bại!");
                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            string makh, mads, masan;

            makh = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            masan = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            mads = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            XemChiTietDatSan.masan = masan;
            XemChiTietDatSan.makh = makh;
            XemChiTietDatSan.mads = mads;
            txtHoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtGioVao.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtGioRa.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSoGio.Text = (int.Parse(txtGioRa.Text) - int.Parse(txtGioVao.Text)).ToString();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            XemChiTietDatSan ct = new XemChiTietDatSan();
            ct.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            dataGridView1.DataSource = xl.loadDatSan();
            comboBox1.DataSource = xl.loadcbbLoaiSan();
            comboBox1.DisplayMember = "LoaiSan";
            comboBox1.ValueMember = "MaSan";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn hủy sân ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (xl.huySan(dataGridView1.CurrentRow.Cells[0].Value.ToString()) == true)
                {
                    MessageBox.Show("Hủy Sân thành công!");
                    dataGridView1.DataSource = xl.loadDatSan();
                }
                else
                {
                    MessageBox.Show("Hủy Sân thất bại!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            
        }


    }
}

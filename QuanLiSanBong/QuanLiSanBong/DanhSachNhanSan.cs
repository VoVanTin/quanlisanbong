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
    public partial class DanhSachNhanSan : Form
    {
        DatSanXuLy dt = new DatSanXuLy();
        NhanSanXuLy xl = new NhanSanXuLy();
        public DanhSachNhanSan()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaDatSan.TextLength == 0)
            {

                errorProvider1.SetError(txtMaDatSan, "Vui lòng nhập mã đặt sân!");
            }
            else
            {
                errorProvider1.SetError(txtMaDatSan, null);

                DataTable tt = xl.timkiem(txtMaDatSan.Text);
                if (tt.Rows.Count > 0)
                {
                    txtHoTen.Text = tt.Rows[0][0].ToString();
                    txtSDT.Text = tt.Rows[0][1].ToString();
                    txtTenSan.Text = tt.Rows[0][2].ToString();
                    DateTime datenap = DateTime.Parse(tt.Rows[0][3].ToString());
                    dtpNgayApDung.Value = DateTime.Parse(datenap.ToShortDateString());
                    DateTime datens = DateTime.Parse(tt.Rows[0][4].ToString());
                    dtpNgaySinh.Value = DateTime.Parse(datens.ToShortDateString());
                    txtGioVao.Text = tt.Rows[0][5].ToString();
                    txtGioRa.Text = tt.Rows[0][6].ToString();
                    cbGioiTinh.SelectedItem = tt.Rows[0][7].ToString();
                    txtSoGio.Text = tt.Rows[0][8].ToString();
                    txtGiaSan.Text = tt.Rows[0][9].ToString();
                    txtLoaiSan.Text = tt.Rows[0][11].ToString();
                }
                else
                {
                    MessageBox.Show("Không tồn tại mã đặt sân này!");
                }
            }
            
        }

        private void DanhSachNhanSan_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.loadNhanSan();
        }

        private void btnNhanSan_Click(object sender, EventArgs e)
        {
            string ngayapdung = dtpNgayApDung.Value.ToString("dd/MM/yyyy");
            string ngaysinh = dtpNgaySinh.Value.ToString("dd/MM/yyyy");
            string gioitinh = cbGioiTinh.Text;
            string username = Main_QuanLiSanBong.username;
            if (xl.NhanSan(ngayapdung, txtGioVao.Text, txtGioRa.Text, txtLoaiSan.Text, txtHoTen.Text, txtSoGio.Text, txtSDT.Text, gioitinh, ngaysinh) == true)
            {
                dataGridView1.DataSource = xl.loadNhanSan();
                //DateTime now = DateTime.Now;
                //string datenow = now.ToShortDateString();
                string datenow = string.Empty;
                int r = dataGridView1.Rows.Count - 1;
                string manhansan = dataGridView1.Rows[r].Cells[0].Value.ToString();
                string trangthai = "Chưa Thanh Toán";
                if (xl.ThemHoaDon(datenow, manhansan,username, trangthai, txtSDT.Text, txtSoGio.Text, txtGiaSan.Text) == true)
                {
                    MessageBox.Show("Nhận sân thành công!");
                }
                else
                {
                    MessageBox.Show("Nhận sân Thất Bại!");
                }
            }
            else
            {
                MessageBox.Show("Khách chưa đặt sân!");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

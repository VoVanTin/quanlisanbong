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
    public partial class DichVuVaThanhToan : Form
    {
        DichVuThanhToanXuLy xl = new DichVuThanhToanXuLy();
        public DichVuVaThanhToan()
        {
            InitializeComponent();
        }

        private void DichVuVaThanhToan_Load(object sender, EventArgs e)
        {
            txtMaHD.Enabled = false;
            txtTongTien.Enabled = false;
            cbbLoaiDV.SelectedIndexChanged -= cbbLoaiDV_SelectedIndexChanged;
            dataGridView1.DataSource = xl.loadDanhSachSanChuaThanhToan();
            cbbLoaiDV.DataSource = xl.loadcbbDichVu();
            cbbLoaiDV.DisplayMember = "Loai";
            cbbLoaiDV.ValueMember = "Loai";
            cbbLoaiDV.SelectedIndexChanged += cbbLoaiDV_SelectedIndexChanged;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                txtMaHD.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                dataGridView2.DataSource = xl.loadHoaDonTienSan(txtMaHD.Text);
                dataGridView3.DataSource = xl.loadHoaDonDichVu(txtMaHD.Text);
                if (dataGridView2.Rows.Count > 0)
                {
                    txtTongTien.Text = dataGridView2.Rows[0].Cells[6].Value.ToString();
                }
                else
                {
                    txtTongTien.Text = "0";
                }
            }
            else
            {
                txtMaHD.Text = string.Empty;
            }
        }

        private void cbbLoaiDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbTenDV.SelectedIndexChanged -= cbbTenDV_SelectedIndexChanged;
            string maloai = cbbLoaiDV.SelectedValue.ToString();
            cbbTenDV.DataSource = xl.LoadDichVu_cbb(maloai);
            cbbTenDV.DisplayMember = "TenDV";
            cbbTenDV.ValueMember = "MaDV";
            cbbTenDV.SelectedIndexChanged += cbbTenDV_SelectedIndexChanged;
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Hiện tại đang không có hóa đơn nào!");
            }
            else
            {
                if (cbbTenDV.SelectedItem == null)
                {
                    errorProvider1.SetError(cbbTenDV, "Vui lòng chọn dịch vụ!");

                
                }
                else
                {
                    errorProvider1.SetError(cbbTenDV, null);
                    string mahd = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string madv = cbbTenDV.SelectedValue.ToString();
                    string sl = numericUpDown1.Value.ToString();
                    int gia = int.Parse(txtGia.Text);
                    string tongtiendv = (gia * numericUpDown1.Value).ToString();
                    if (xl.themDichVu(mahd, madv, sl, tongtiendv) == true)
                    {
                        MessageBox.Show("Thêm dịch vụ thành công!");
                        dataGridView3.DataSource = xl.loadHoaDonDichVu(mahd);
                        if (xl.capnhatTongTien(mahd) == true)
                        {
                            dataGridView2.DataSource = xl.loadHoaDonTienSan(mahd);
                            txtTongTien.Text = dataGridView2.Rows[0].Cells[6].Value.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật giá tiền thất bại!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm dịch vụ thất bại!");
                    }
                }
            }
        }

        private void cbbTenDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string madv = cbbTenDV.SelectedValue.ToString();
            DataTable dv = xl.GiaDichVu(madv);
            txtGia.Text = dv.Rows[0][0].ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string year = now.Year.ToString();
            string month = now.Month.ToString();
            string datenow = now.ToShortDateString();
            string trangthai = "Đã Thanh Toán";
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thanh toán hóa đơn này!", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (xl.thanhtoan(trangthai, txtMaHD.Text, datenow) == true && xl.themvaothongke(txtTongTien.Text, month, year) == true)
                {
                    MessageBox.Show("Thanh toán thành công!");
                    dataGridView1.DataSource = xl.loadDanhSachSanChuaThanhToan();
                    if (dataGridView1.RowCount == 0)
                    {
                        txtMaHD.Text = string.Empty;
                    }
                    dataGridView2.DataSource = xl.loadHoaDonTienSan(txtMaHD.Text);
                    dataGridView3.DataSource = xl.loadHoaDonDichVu(txtMaHD.Text);
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.RowCount ==0)
            {
                MessageBox.Show("Hiện tại không có hóa đơn nào!");
                return;
            }
            string mahd = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (mahd == null)
            {
                MessageBox.Show("Không có dòng nào được chọn!");
            }
            else
            {
                DataTable rp = xl.xuatcthoadon(mahd);
                if (rp.Rows.Count == 0)
                {
                    DataTable rphd = xl.xuathoadon(mahd);
                    XuatHoaDon baocao = new XuatHoaDon();
                    baocao.SetDataSource(rphd);
                    FrmReportcs f = new FrmReportcs();
                    f.crystalReportViewer1.ReportSource = baocao;
                    f.ShowDialog();
                }
                else
                {
                    XuatCTHoaDon baocao = new XuatCTHoaDon();
                    baocao.SetDataSource(rp);
                    FrmReportcs f = new FrmReportcs();
                    f.crystalReportViewer1.ReportSource = baocao;
                    f.ShowDialog();
                }
            }    
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView3.RowCount ==0)
            {
                MessageBox.Show("Hiện tại hóa đơn không có dịch vụ nào!");
            }
            else
            {
                string tendv = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                string madv = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                string mahd = txtMaHD.Text;
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa dịch vụ " + tendv + " ra khỏi hóa đơn này không!", "Thông Báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (xl.xoaDichVu(mahd, madv) == true)
                    {
                        MessageBox.Show("Xóa dịch vụ thành công!");
                        dataGridView3.DataSource = xl.loadHoaDonDichVu(mahd);
                        if (dataGridView3.RowCount == 0)
                        {
                            xl.capnhatTongTien_0(mahd);
                            dataGridView2.DataSource = xl.loadHoaDonTienSan(mahd);
                            txtTongTien.Text = dataGridView2.Rows[0].Cells[6].Value.ToString();
                        }
                        else
                        {
                            xl.capnhatTongTien(mahd);
                            dataGridView2.DataSource = xl.loadHoaDonTienSan(mahd);
                            txtTongTien.Text = dataGridView2.Rows[0].Cells[6].Value.ToString();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Xóa dịch vụ thất bại!");
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }





    }
}

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
    public partial class XemChiTietDatSan : Form
    {
        DatSanXuLy xl = new DatSanXuLy();
        public static string makh, masan, mads;
        public XemChiTietDatSan()
        {
            InitializeComponent();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            if (xl.kiemtraDatSan(date, txtGioVao.Text, txtGioRa.Text, cbbLoaiSan.SelectedValue.ToString()) == false)
            {
                MessageBox.Show("Khung giờ này đã có sân được đặt!");
            }
            else
            {
                if (xl.updateDatSan(txtMaSan.Text, cbbLoaiSan.SelectedValue.ToString(), dateTimePicker1.Value.ToString("dd/MM/yyyy"), txtGioVao.Text, txtGioRa.Text) == true)
                {
                    MessageBox.Show("Lưu thành công!");

                }
                else
                {
                    MessageBox.Show("Lưu thất bại!");
                }
            }
            
        }

        private void XemChiTietDatSan_Load(object sender, EventArgs e)
        {
            txtMaSan.Enabled = false;
            cbbLoaiSan.DataSource = xl.loadcbbLoaiSan();
            cbbLoaiSan.DisplayMember = "LoaiSan";
            cbbLoaiSan.ValueMember = "MaSan";
            DataTable ct = xl.loadChiTietDatSan(mads, makh, masan);
            if (ct.Rows.Count > 0)
            {
                txtMaSan.Text = ct.Rows[0][0].ToString();
                cbbLoaiSan.SelectedValue = ct.Rows[0][9].ToString();
                DateTime datedate = DateTime.Parse(ct.Rows[0][2].ToString());
                dateTimePicker1.Value = DateTime.Parse(datedate.ToShortDateString());
                txtGioVao.Text = ct.Rows[0][3].ToString();
                txtGioRa.Text = ct.Rows[0][4].ToString();
                txtHoTen.Text = ct.Rows[0][5].ToString();
                DateTime datens = DateTime.Parse(ct.Rows[0][6].ToString());
                dtpns.Value = DateTime.Parse(datens.ToShortDateString());
                txtSdt.Text = ct.Rows[0][7].ToString();
                cbbGioiTinh.SelectedItem = ct.Rows[0][8].ToString();
            }
            else
            {
                MessageBox.Show("Không tồn tại!");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (xl.updateKhachHang(makh, txtHoTen.Text, txtSdt.Text, cbbGioiTinh.SelectedItem.ToString(),dtpns.Value.ToString("dd/MM/yyyy")) == true)
            {
                MessageBox.Show("Cập nhật khách hàng thành công!");

            }
            else
            {
                MessageBox.Show("Cập nhật khách hàng thất bại!");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}

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
    public partial class QuanLyHoaDon : Form
    {
        DichVuThanhToanXuLy dv = new DichVuThanhToanXuLy();
        QuanLyXuLy ql = new QuanLyXuLy();
        public QuanLyHoaDon()
        {
            InitializeComponent();
        }

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ql.loadDanhSachHoaDon();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin muốn tìm kiếm!");
            }
            dataGridView1.DataSource = ql.timKiemHD(txtTimKiem.Text);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mahd = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (mahd == null)
            {
                MessageBox.Show("Không có dòng nào được chọn!");
            }
            else
            {
                DataTable rp = dv.xuatcthoadon(mahd);
                if (rp.Rows.Count == 0)
                {
                    DataTable rphd = dv.xuathoadon(mahd);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

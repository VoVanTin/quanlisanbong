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
    public partial class ThongKeDoanhThu : Form
    {
        ThongKeXuLy xl = new ThongKeXuLy();
        public ThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            cbbNam.SelectedIndexChanged -= cbbNam_SelectedIndexChanged;
            
            DataTable nam = xl.loadcbbNam();
            cbbNam.DataSource = nam;
            cbbNam.DisplayMember = "nam";
            cbbNam.ValueMember = "nam";
            int namtk = int.Parse(cbbNam.SelectedValue.ToString());
            dataGridView1.DataSource = xl.loadThongKe(namtk.ToString());
            using (QLSBEntities1 db = new QLSBEntities1())
            {
                chartDoanhThu.DataSource = db.ThongKes.Where(t => t.nam == namtk).ToList();
                chartDoanhThu.Series["DoanhThu"].XValueMember = "thang";
                chartDoanhThu.Series["DoanhThu"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                chartDoanhThu.Series["DoanhThu"].YValueMembers = "doanhthu";
                chartDoanhThu.Series["DoanhThu"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            }
            cbbNam.SelectedIndexChanged += cbbNam_SelectedIndexChanged;
           
        }
        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int namtk = int.Parse(cbbNam.SelectedValue.ToString());
            using (QLSBEntities1 db = new QLSBEntities1())
            {
                chartDoanhThu.DataSource = db.ThongKes.Where(t => t.nam == namtk).ToList();
                chartDoanhThu.Series["DoanhThu"].XValueMember = "thang";
                chartDoanhThu.Series["DoanhThu"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                chartDoanhThu.Series["DoanhThu"].YValueMembers = "doanhthu";
                chartDoanhThu.Series["DoanhThu"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            }

            dataGridView1.DataSource = xl.loadThongKe(namtk.ToString());

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

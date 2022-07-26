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
    public partial class Main_QuanLiSanBong : Form
    {
        public static string username;
        public static string name;
        public static int quyen;
        public Main_QuanLiSanBong()
        {
            InitializeComponent();
            
            
        }


        private void Main_QuanLiSanBong_Load(object sender, EventArgs e)
        {
            ptb1.Image = QuanLiSanBong.Properties.Resources.main_background;
            if (quyen == 1)
            {
                MessageBox.Show("Xin chào quản lý ^^");
                
            }
            else
            {
                MessageBox.Show("Xin chào nhân viên "+name+" ^^");
                quảnLýToolStripMenuItem1.Enabled = false;
            }
            label2.Text = "Xin Chào: "+name+"";
        }


        private void đặtSânChoKháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachDatSan bg = new DanhSachDatSan();
            bg.ShowDialog();
        }

        private void nhậnSânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachNhanSan ns = new DanhSachNhanSan();
            ns.ShowDialog();
        }

        private void thanhToánHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DichVuVaThanhToan dvtt = new DichVuVaThanhToan();
            dvtt.ShowDialog();
        }

        private void quảnLýSânBóngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLySan ql = new QuanLySan();
            ql.ShowDialog();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang ql = new QuanLyKhachHang();
            ql.ShowDialog();
        }

        private void quảnLýHóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon ql = new QuanLyHoaDon();
            ql.ShowDialog();
        }

        private void quảnLýNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien ql = new QuanLyNhanVien();
            ql.ShowDialog();
        }

        private void quảnLýDịchVụToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QuanLyDichVu ql = new QuanLyDichVu();
            ql.ShowDialog();
        }

        private void thốngKêDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeDoanhThu tk = new ThongKeDoanhThu();
            tk.ShowDialog();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan tk = new ThongTinTaiKhoan();
            ThongTinTaiKhoan.username = username;
            ThongTinTaiKhoan.name = name;
            tk.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            username = string.Empty;
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }





    }
}

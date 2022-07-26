using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QuanLiSanBong
{
    class ThongKeXuLy
    {
        SqlConnection con = new SqlConnection(QuanLyXuLy.constring);
        public DataTable Thongke()
        {
            try
            {
                DataTable thongke = new DataTable();
                string sql = " Select * from ThongKe";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(thongke);
                return thongke;
            }
            catch
            {
                return null;
            }
        }

        public DataTable loadcbbNam()
        {
            try
            {


                string sql = "select DISTINCT(nam) from ThongKe";  // lay het du lieu trong bang sinh vien
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dsNam = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dsNam);  // đổ dữ liệu vào kho
                return dsNam;
            }
            catch
            {
                return null;
            }
        }

        public DataTable loadThongKe(string nam)
        {
            try
            {

                string sql = "select thang,doanhthu from ThongKe where nam = "+nam+"";  // lay het du lieu trong bang sinh vien
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dsdt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dsdt);  // đổ dữ liệu vào kho
                return dsdt;
            }
            catch
            {
                return null;
            }
        }
    }
}

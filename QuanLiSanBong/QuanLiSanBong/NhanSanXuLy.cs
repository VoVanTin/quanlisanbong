using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QuanLiSanBong
{
    class NhanSanXuLy
    {
        SqlConnection con = new SqlConnection(QuanLyXuLy.constring);
        public DataTable loadNhanSan()
        {
            try
            {
                con.Open();
                string sql = "select MaNhanSan,HoTen,Sdt,LoaiSan,NgayApDung,GioVao,GioRa,kh.MaKH,s.MaSan from NHANSAN ns,KHACHHANG kh,SanBong s where ns.MaKH= kh.MAKH and ns.MaSan = s.MaSan";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable ds_QLSB = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(ds_QLSB);  // đổ dữ liệu vào kho
                con.Close();  // đóng kết nối
                return ds_QLSB;
            }
            catch
            {
                return null;
            }
        }

        public DataTable timkiem(string madatsan)
        {
            try
            {
                string sql = "select HoTen,Sdt,LoaiSan,NgayApDung,NgaySinh,GioVao,GioRa,Gioitinh,SoGio,Gia,kh.MaKH,s.MaSan from DatSan ns,KHACHHANG kh,SanBong s where ns.MaKH= kh.MAKH and ns.MaSan = s.MaSan and MaDatSan =" + madatsan + "";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable ttct = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(ttct);  // đổ dữ liệu vào kho
                return ttct;
            }
            catch
            {
                return null;
            }
        }

        public bool NhanSan(string ngayapdung, string giovao, string giara, string masan, string tenkh, string sogio, string sdt, string gioitinh, string ngaysinh)
        {
            try
            {
                    con.Open();
                    DatSanXuLy xl = new DatSanXuLy();
                    string makh = xl.kiemtrakhachhang(sdt).ToString();
                    string sql = "set dateformat dmy insert into NhanSan values('" + ngayapdung + "','" + giovao + "','" + giara + "'," + sogio + "," + masan + "," + makh + ")";
                    SqlCommand com = new SqlCommand(sql, con);
                    string sql1 = "set dateformat dmy Update SANBONG set TrangThai = N'Có Người' where MaSan = "+masan+"";
                    SqlCommand com1 = new SqlCommand(sql1, con);
                    int n = com.ExecuteNonQuery();
                    int m = com1.ExecuteNonQuery();
                    con.Close();
                    if (n > 0 && m>0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                
            }
            catch
            {
                return false;
            }
        }

        public bool ThemHoaDon(string ngayxuathd, string manhansan,string username, string trangthai, string sdt, string sogio, string gia)
        {
            try
            {
                con.Open();
                string tongtien = (double.Parse(sogio) * double.Parse(gia)).ToString();
                DatSanXuLy xl = new DatSanXuLy();
                string makh = xl.kiemtrakhachhang(sdt).ToString();
                DataTable datsan = new DataTable();
                string sql = "set dateformat dmy insert into HOADON values(" + makh + "," + tongtien + ",'" + ngayxuathd + "'," + manhansan + ",'"+username+"',N'" + trangthai + "')";
                SqlCommand com = new SqlCommand(sql, con);
                int n = com.ExecuteNonQuery();
                con.Close();
                if (n > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                //SqlDataAdapter da = new SqlDataAdapter(com);
                //da.Fill(datsan);
                //return true;

            }
            catch
            {
                return false;
            }
        }
    }
}

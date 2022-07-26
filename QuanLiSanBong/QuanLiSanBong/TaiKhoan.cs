using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiSanBong
{
    class TaiKhoan
    {
        SqlConnection con = new SqlConnection(QuanLyXuLy.constring);

        public bool DangNhap(string username, string pass)
        {
            try
            {
                
                string sql = "select Username, HoTen,Quyen from TAIKHOAN where Username = '"+username+"' and Pass = '"+pass+"' ";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable tk = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(tk);  // đổ dữ liệu vào kho
                if (tk.Rows.Count > 0)
                {
                    Main_QuanLiSanBong.username = tk.Rows[0][0].ToString();
                    Main_QuanLiSanBong.name = tk.Rows[0][1].ToString();
                    Main_QuanLiSanBong.quyen = int.Parse(tk.Rows[0][2].ToString());
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

        public DataTable thongtintaikhoan(string username)
        {
            try
            {
                string sql = "select HoTen,SDT,NgaySinh,Gioitinh from TAIKHOAN where Username = '"+username+"'";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable tk = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(tk);  // đổ dữ liệu vào kho
                return tk;
            }
            catch
            {
                return null;
            }
        }

        public bool CapNhatThongTin(string username, string HoTen,string sdt,string ngaysinh,string gioitinh)
        {
            try
            {
                con.Open();
                string sql = "set dateformat dmy Update TAIKHOAN set HoTen = N'"+HoTen+"',SDT='"+sdt+"',NgaySinh ='"+ngaysinh+"',Gioitinh = N'"+gioitinh+"' where Username = '"+username+"'";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                int n = com.ExecuteNonQuery();
                con.Close();
                if (n>0)
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

        public bool DoiPass(string username, string PassMoi)
        {
            try
            {
                con.Open();
                string sql = "set dateformat dmy Update TAIKHOAN set Pass = '" + PassMoi + "' where Username = '" + username + "'";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
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

            }
            catch
            {
                return false;
            }
        }

        public bool KiemTraPass(string username, string Pass)
        {
            try
            {
                con.Open();
                string sql = "Select count(*) from TAIKHOAN where Username = '" + username + "' and Pass = '"+Pass+"'";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                int n = (int)com.ExecuteScalar();
                con.Close();
                if (n > 0)
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

        public bool kiemtratontai_username_sdt(string username, string sdt)
        {
            try
            {
                con.Open();
                string sql = "Select count(*) from TAIKHOAN where Username = '" + username + "' or SDT = '" + sdt + "'";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                int n = (int)com.ExecuteScalar();
                con.Close();
                if (n > 0)
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

        public bool kiemtratontai_sdt_capnhat(string username, string sdt)
        {
            try
            {
                con.Open();
                string sql = "Select count(*) from TAIKHOAN where SDT = '" + sdt + "' and Username !='"+username+"'";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                int n = (int)com.ExecuteScalar();
                con.Close();
                if (n > 0)
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



    }
}

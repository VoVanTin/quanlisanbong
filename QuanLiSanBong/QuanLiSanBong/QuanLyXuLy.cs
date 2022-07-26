using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QuanLiSanBong
{
    class QuanLyXuLy
    {
        public static string constring = "Data Source=PHUONGTRAN\\PHUONG;Initial Catalog=QLSB;User ID=sa; Password=123";
        SqlConnection con = new SqlConnection(constring);
        //QuanLySan
        public DataTable loadDanhSachSan()
        {
            try
            {
                string sql = "select * from SanBong";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dsSB = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dsSB);  // đổ dữ liệu vào kho
                return dsSB;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetSanBong(string masan)
        {
            try
            {
                string sql = "select * from SanBong where MaSan = "+masan+"";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dsSB = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dsSB);  // đổ dữ liệu vào kho
                return dsSB;
            }
            catch
            {
                return null;
            }
        }

        public DataTable timKiemSan(string matensan)
        {
            try
            {
                string sql = "select * from SanBong where MaSan LIKE '%" + matensan + "%' or LoaiSan LIKE N'%" + matensan + "%'";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dsSB = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dsSB);  // đổ dữ liệu vào kho
                return dsSB;
            }
            catch
            {
                return null;
            }
        }

        public bool themsan(string loaisan,string gia)
        {
            try
            {
                con.Open();
                string sql = "insert into SanBong values(N'" + loaisan + "'," + gia + ",N'Trống')";
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

        public bool capnhatsan(string masan,string loaisan, string gia)
        {
            try
            {
                con.Open();
                string sql = "update SanBong set Gia = "+gia+",LoaiSan =N'"+loaisan+"' where MaSan = "+masan+"";
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

        //QuanLyNhanVien
        public DataTable loadDanhSachNhanVien()
        {
            try
            {
                string sql = "select Username,HoTen,SDT,NgaySinh,Gioitinh,Quyen from TaiKhoan";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dsnv = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dsnv);  // đổ dữ liệu vào kho
                return dsnv;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetNhanVien(string username)
        {
            try
            {
                string sql = "select * from TaiKhoan where Username = '" + username + "'";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dsnv = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dsnv);  // đổ dữ liệu vào kho
                return dsnv;
            }
            catch
            {
                return null;
            }
        }

        public DataTable timKiemNhanVien(string txtTimKiem)
        {
            try
            {
                string sql = "select * from TaiKhoan where Username LIKE '%" + txtTimKiem + "%' or HoTen LIKE N'%" + txtTimKiem + "%' or SDT LIKE N'%" + txtTimKiem + "%'";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dsnv = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dsnv);  // đổ dữ liệu vào kho
                return dsnv;
            }
            catch
            {
                return null;
            }
        }

        public bool capnhatQuyen(string username, string quyen)
        {
            try
            {
                con.Open();
                string sql = "Update TaiKhoan set Quyen = "+quyen+" where Username = '"+username+"'";
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

        public bool Datlaimk(string username)
        {
            try
            {
                con.Open();
                string sql = "Update TaiKhoan set Pass = '" + username + "' where Username = '" + username + "'";
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

        public bool capnhatthongtin (string username,string hoten,string gioitinh,string sdt,string ngaysinh)
        {
            try
            {
                con.Open();
                string sql = "set dateformat dmy Update TaiKhoan set HoTen = N'" + hoten + "',Gioitinh = N'"+gioitinh+"',SDT = '"+sdt+"',NgaySinh = '"+ngaysinh+"' where Username = '" + username + "'";
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

        public bool themNV(string username, string hoten,string sdt,string ngaysinh,string gioitinh,string quyen)
        {
            try
            {
                con.Open();
                string sql = "set dateformat dmy Insert into TaiKhoan Values('"+username+"','"+username+"',N'"+hoten+"','"+sdt+"','"+ngaysinh+"',N'"+gioitinh+"',"+quyen+")";
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

        public bool xoaNV(string username)
        {
            try
            {
                con.Open();
                string sql = "DELETE FROM TAIKHOAN WHERE Username = '"+username+"';";
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

        public bool kiemtrakhoangoai(string username)
        {
            try
            {
                string sql = "select * from HOADON where Username = '"+username+"'";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dstk = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dstk);  // đổ dữ liệu vào kho
                if (dstk.Rows.Count > 0)
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

        //QuanLyKhachHang

        public DataTable loadDanhSachKhachHang()
        {
            try
            {
                string sql = "select * from KHACHHANG";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dskh = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dskh);  // đổ dữ liệu vào kho
                return dskh;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetKhachHang(string makh)
        {
            try
            {
                string sql = "select * from KhachHang where MaKH = " + makh + "";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dskh = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dskh);  // đổ dữ liệu vào kho
                return dskh;
            }
            catch
            {
                return null;
            }
        }


        public bool capnhatkhachhang(string makh, string hoten, string gioitinh, string sdt, string ngaysinh)
        {
            try
            {
                con.Open();
                string sql = "set dateformat dmy Update KhachHang set HoTen = N'" + hoten + "',Gioitinh = N'" + gioitinh + "',Sdt = '" + sdt + "',NgaySinh = '" + ngaysinh + "' where MaKH = " + makh + "";
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

        public DataTable timkiemKhachHang(string txtTimKiem)
        {
            try
            {
                string sql = "select * from KhachHang where MaKH LIKE '%" + txtTimKiem + "%' or HoTen LIKE N'%" + txtTimKiem + "%' or Sdt LIKE N'%" + txtTimKiem + "%'";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dskh = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dskh);  // đổ dữ liệu vào kho
                return dskh;
            }
            catch
            {
                return null;
            }
        }

        public bool themKH(string hoten, string sdt, string ngaysinh, string gioitinh)
        {
            try
            {
                con.Open();
                string sql = "set dateformat dmy Insert into KHACHHANG Values(N'" + hoten + "','" + sdt + "',N'" + gioitinh + "','" + ngaysinh + "')";
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
        //QuanLyHoaDon
        public DataTable loadDanhSachHoaDon()
        {
            try
            {
                string sql = "select MaHD,LoaiSan,HoTen,NgayXuatHD,hd.TrangThai,TongTien from HoaDon hd,KhachHang kh,SanBong sb,NhanSan ns where hd.MaKH = kh.MaKH and hd.MaNhanSan = ns.MaNhanSan and ns.MaSan = sb.MaSan";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dshd = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dshd);  // đổ dữ liệu vào kho
                return dshd;
            }
            catch
            {
                return null;
            }
        }

        public DataTable timKiemHD(string txtTimKiem)
        {
            try
            {
                string sql = "select MaHD,LoaiSan,HoTen,NgayXuatHD,hd.TrangThai,TongTien from HoaDon hd,KhachHang kh,SanBong sb,NhanSan ns where hd.MaKH = kh.MaKH and hd.MaNhanSan = ns.MaNhanSan and ns.MaSan = sb.MaSan and ( MaHD LIKE '%" + txtTimKiem + "%' or LoaiSan LIKE N'%" + txtTimKiem + "%' or HoTen LIKE N'%" + txtTimKiem + "%')";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dshd = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dshd);  // đổ dữ liệu vào kho
                return dshd;
            }
            catch
            {
                return null;
            }
        }
        //QuanLyDichVu

        public DataTable loadDanhSachDichVu()
        {
            try
            {
                string sql = "select * from DichVu";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dsdv = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dsdv);  // đổ dữ liệu vào kho
                return dsdv;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetDichVu(string madv)
        {
            try
            {
                string sql = "select * from DichVu where MaDV = " + madv + "";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dsdv = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dsdv);  // đổ dữ liệu vào kho
                return dsdv;
            }
            catch
            {
                return null;
            }
        }

        public DataTable timKiemDV(string txtTimKiem)
        {
            try
            {
                string sql = "select * from DichVu where TenDV LIKE N'%" + txtTimKiem + "%' or MaDV LIKE N'%" + txtTimKiem + "%' or Loai LIKE N'%" + txtTimKiem + "%'";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dsdv = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dsdv);  // đổ dữ liệu vào kho
                return dsdv;
            }
            catch
            {
                return null;
            }
        }

        public bool capnhatdichvu(string madv,string TenDV, string loai, string gia)
        {
            try
            {
                con.Open();
                string sql ="update DichVu set TenDv = N'"+TenDV+"',Loai = N'"+loai+"',Gia = "+gia+" where MaDV = "+madv+"";
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

        public bool themDV(string ten, string loai, string gia)
        {
            try
            {
                con.Open();
                string sql = "Insert into DichVu Values(N'" + ten + "',N'" + loai + "'," + gia + ")";
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
    }
}

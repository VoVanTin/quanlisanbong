using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QuanLiSanBong
{
    class DichVuThanhToanXuLy
    {
        SqlConnection con = new SqlConnection(QuanLyXuLy.constring);

        public DataTable loadDanhSachSanChuaThanhToan()
        {
            try
            {
                string sql = "select MaHD,MaKH,NgayXuatHD,MaNhanSan from HOADON where TrangThai = N'Chưa Thanh Toán'";  // lay het du lieu trong bang sinh vien
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable ds_QLSB = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(ds_QLSB);  // đổ dữ liệu vào kho
                return ds_QLSB;
            }
            catch
            {
                return null;
            }
        }

        public DataTable loadHoaDonTienSan(string mahd)
        {
            try
            {
                string sql = "select LoaiSan,Gia,NgayApDung,GioVao,GioRa,SoGio*Gia as TienSan,TongTien from HOADON hd,SANBONG sb,NHANSAN ns where sb.MaSan = ns.MaSan and ns.MaNhanSan = hd.MaNhanSan and MaHD = " + mahd + "";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable ds_QLSB = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(ds_QLSB);  // đổ dữ liệu vào kho
                return ds_QLSB;
            }
            catch
            {
                return null;
            }
        }

        public DataTable loadcbbDichVu()
        {
            try
            {


                string sql = "select DISTINCT(Loai) from DICHVU";  // lay het du lieu trong bang sinh vien
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dsDV = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dsDV);  // đổ dữ liệu vào kho
                return dsDV;
            }
            catch
            {
                return null;
            }
        }

        public DataTable LoadDichVu_cbb(string loai)
        {
            try
            {
                DataTable dv = new DataTable();
                string sql = "select MaDV,tenDV from DICHVU where Loai = N'" + loai + "'";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dv);
                return dv;
            }
            catch
            {
                return null;
            }
        }
        public int kiemtraDichVu(string madv,string mahd)
        {
            try
            {
                DataTable themdv = new DataTable();
                string sql = "select MaDV from CHITIETHD where MaDV = " + madv + " and MaHD = " + mahd + "";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(themdv);
                if (themdv.Rows.Count > 0)
                {
                    return int.Parse(madv);
                }
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
            
        }
        public bool themDichVu(string mahd,string madv, string soluong, string tongtiendv)
        {
            try
            {
                int madv1 = kiemtraDichVu(madv,mahd);
                if (madv1 == 0)
                {
                    con.Open();
                    DataTable themdv = new DataTable();
                    string sql = "insert into CHITIETHD values(" + mahd + "," + madv + "," + soluong + "," + tongtiendv + ")";
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
                }
                else
                {
                    con.Open();
                    DataTable themdv = new DataTable();
                    string sql = "Update CHITIETHD set SoLuong = SoLuong +"+soluong+",TongTienDV =TongTienDV +"+tongtiendv+" where MaDV = "+madv1+"";
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
                }

            }
            catch
            {
                return false;
            }
        }

        public DataTable loadHoaDonDichVu(string mahd)
        {
            try
            {
                string sql = "Select dv.MaDV,TenDv,SoLuong,Gia,TongTienDV from DICHVU dv,CHITIETHD ct where dv.MaDV = ct.MaDV and ct.MaHD = " + mahd + "";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable ds_dv = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(ds_dv);  // đổ dữ liệu vào kho
                return ds_dv;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GiaDichVu(string madv)
        {
            try
            {
                con.Open();
                string sql = "select Gia from DICHVU where MaDV =" + madv + "";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dv = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dv);  // đổ dữ liệu vào kho
                con.Close();  // đóng kết nối
                return dv;
            }
            catch
            {
                return null;
            }
        }

        public bool capnhatTongTien(string mahd)
        {
            try
            {
                con.Open();
                DataTable themdv = new DataTable();
                string sql = "UPDATE HOADON SET TongTien = (Select Gia*SoGio from SANBONG sb ,NHANSAN ns ,HOADON hd where ns.MaSan = sb.MaSan and ns.MaNhanSan = hd.MaNhanSan and MaHD = " + mahd + " ) + (Select SUM(TongTienDV) from CHITIETHD where MaHD = " + mahd + ") Where MaHD = " + mahd + " ";
                SqlCommand com = new SqlCommand(sql, con);
                int n = com.ExecuteNonQuery();
                con.Close();
                if(n>0)
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

        public bool capnhatTongTien_0(string mahd)
        {
            try
            {
                con.Open();
                DataTable themdv = new DataTable();
                string sql = "UPDATE HOADON SET TongTien = (Select Gia*SoGio from SANBONG sb ,NHANSAN ns ,HOADON hd where ns.MaSan = sb.MaSan and ns.MaNhanSan = hd.MaNhanSan and MaHD = " + mahd + " ) Where MaHD = " + mahd + " ";
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
            }
            catch
            {
                return false;
            }
        }

        public int kiemtramasan(string mahd)
        {
            try
            {
                con.Open();
                DataTable themdv = new DataTable();
                string sql = "select MaSan from HoaDon hd,NhanSan ns where hd.MaHD = " + mahd + " and ns.MaNhanSan = hd.MaNhanSan";
                SqlCommand com = new SqlCommand(sql, con);
                int n = (int)com.ExecuteScalar();
                con.Close();
                if (n > 0)
                {
                    return n;
                }
                else
                {
                    return 0;
                }

            }
            catch
            {
                return 0;
            }
        }

        public bool thanhtoan(string trangthai, string mahd,string ngayxuathd)
        {
            try
            {
                string masan = kiemtramasan(mahd).ToString();
                con.Open();
                DataTable themdv = new DataTable();
                string sql = "Update HOADON set TrangThai = '" + trangthai + "',NgayXuatHD ='"+ngayxuathd+"' where MaHD = " + mahd + "";
                SqlCommand com = new SqlCommand(sql, con);
                int n = com.ExecuteNonQuery();
                string sql1 = "Update SanBong set TrangThai = N'Trống' where MaSan = " + masan + "";
                SqlCommand com1 = new SqlCommand(sql1, con);
                int m = com1.ExecuteNonQuery();
                con.Close();
                if (n > 0 && m > 0)
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

        public bool themvaothongke(string tien, string thang, string nam)
        {
            try
            {
                con.Open();
                DataTable themdv = new DataTable();
                string sql = "Update ThongKe set doanhthu = doanhthu + " + tien + " where thang = " + thang + " and nam = " + nam + "";
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
            }
            catch
            {
                return false;
            }
        }

        public bool xoaDichVu(string mahd, string madv)
        {
            try
            {
                con.Open();
                DataTable themdv = new DataTable();
                string sql = "Delete from ChiTietHD where MaHD = "+mahd+" and MaDV = "+madv+"";
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
            }
            catch
            {
                return false;
            }
        }

        public DataTable xuatcthoadon(string mahd)
        {
            try
            {
                string sql = "select ct.MaHD,LoaiSan,sb.Gia as GiaSan,NgayApDung,ns.GioVao,ns.GioRa,hd.Username,tk.HoTen as HoTenNV,dv.MaDV,dv.Gia as GiaDV,TenDV,Soluong,TongTienDV,TongTien,kh.HoTen as HoTenKH,kh.MaKH from TAIKHOAN tk,DICHVU dv,NhanSan ns,HoaDon hd,CHITIETHD ct,SANBONG sb,KHACHHANG kh where tk.Username =hd.Username and dv.MaDV= ct.MaDV and ns.MaNhanSan = hd.MaNhanSan and hd.MaKH = kh.MaKH and sb.MaSan = ns.MaSan and hd.MaHD = ct.MaHD and hd.MaHD ="+mahd+"";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable ds_dv = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(ds_dv);  // đổ dữ liệu vào kho
                return ds_dv;
            }
            catch
            {
                return null;
            }
        }

        public DataTable xuathoadon(string mahd)
        {
            try
            {
                string sql = "select hd.MaHD,LoaiSan,sb.Gia as GiaSan,hd.Username,tk.HoTen as HoTenNV,NgayApDung,ns.GioVao,ns.GioRa ,TongTien,kh.HoTen as HoTenKH,kh.MaKH from TAIKHOAN tk, NhanSan ns,HoaDon hd,SANBONG sb,KHACHHANG kh where hd.MaHD = " + mahd + " and sb.MaSan = ns.MaSan and ns.MaNhanSan = hd.MaNhanSan and hd.MaKH = kh.MaKH and tk.Username = hd.Username";
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable ds_dv = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(ds_dv);  // đổ dữ liệu vào kho
                return ds_dv;
            }
            catch
            {
                return null;
            }
        }

    }
}

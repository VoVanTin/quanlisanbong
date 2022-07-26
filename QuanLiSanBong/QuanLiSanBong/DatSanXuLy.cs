using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiSanBong
{
    class DatSanXuLy
    {
        SqlConnection con = new SqlConnection(QuanLyXuLy.constring);

        public DataTable loadDatSan()
        {
            try
            {
                string sql = "select MaDatSan,HoTen,Sdt,LoaiSan,NgayApDung,GioVao,GioRa,kh.MaKH,s.MaSan from DATSAN ds,KHACHHANG kh,SanBong s where ds.MaKH= kh.MAKH and ds.MaSan = s.MaSan";  // lay het du lieu trong bang sinh vien
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

        public DataTable loadcbbLoaiSan()
        {
            try
            {
                string sql = "select * from SanBong";  // lay het du lieu trong bang sinh vien
                SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dsLoaiSan = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dsLoaiSan);  // đổ dữ liệu vào kho
                return dsLoaiSan;
            }
            catch
            {
                return null;
            }
        }

        public DataTable loadSanBong_cbb(string masan)
        {
            try
            {
                DataTable dsSanBong = new DataTable();
                string sql = "select * from SanBong where MaSan = " + masan + "";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dsSanBong);
                return dsSanBong;
            }
            catch
            {
                return null;
            }
        }

        public bool DatSan(string ngayapdung,string giovao,string giara, string masan,string tenkh,string sogio,string sdt,string gioitinh,string ngaysinh)
        {
            try
            {
                int makh = kiemtrakhachhang(sdt);
                if (makh != 0)
                {
                    con.Open();
                    DataTable datsan = new DataTable();
                    string sql = "set dateformat dmy insert into DatSan values('" + ngayapdung + "','" + giovao + "','" + giara + "'," + sogio + "," + masan + "," + makh + ")";
                    SqlCommand com = new SqlCommand(sql, con);
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
                else
                {
                    con.Open();
                    
                    DataTable khachhang = new DataTable();
                    string sql = "set dateformat dmy insert into KhachHang values(N'" + tenkh + "','" + sdt + "',N'" + gioitinh + "','" + ngaysinh + "')";
                    SqlCommand com = new SqlCommand(sql, con);
                    int n = com.ExecuteNonQuery();

                    makh = kiemtrakhachhang(sdt);
                    DataTable datsan = new DataTable();
                    string sql1 = "set dateformat dmy insert into DatSan values('" + ngayapdung + "','" + giovao + "','" + giara + "'," + sogio + "," + masan + "," + makh + ")";
                    SqlCommand com1 = new SqlCommand(sql1, con);
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
            }
            catch
            {
                return false;
            }
        }
            

        public int kiemtrakhachhang(string sdt)
        {
            try
            {
                DataTable khachhang = new DataTable();
                string sql = "select * from KhachHang where Sdt = '" + sdt + "'";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(khachhang);
                if (khachhang.Rows.Count == 0)
                {
                    return 0;
                }
                else
                    return int.Parse(khachhang.Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }
        }

        public DataTable loadChiTietDatSan(string madatsan,string makh,string masan)
        {
            try
            {
                DataTable ChiTietDatSan = new DataTable();
                string sql = "select MaDatSan,LoaiSan,NgayApDung,GioVao,GioRa,HoTen,NgaySinh,Sdt,GioiTinh,ds.MaSan from DatSan ds,KhachHang kh,SanBong s where kh.MaKH = ds.MaKH AND s.MaSan = ds.MaSan AND ds.MaSan = " + masan + " AND ds.MaKH = " + makh + " AND MaDatSan = " + madatsan + "";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ChiTietDatSan);
                return ChiTietDatSan;
            }
            catch
            {
                return null;
            }
        }

        public bool kiemtraDatSan(string ngay, string giovao, string giora,string masan)
        {
            try
            {
                DataTable kt = new DataTable();
                string sql = "select * from DATSAN where NgayApDung ='" + ngay + "' and MaSan = "+ masan +" and (GioVao >= " + giovao + " and GioVao <= " + giora + " or GioRa >= " + giovao + " and GioRa <= " + giora + ")";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(kt);
                if (kt.Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        

        public bool updateDatSan(string madatsan,string masan,string ngaydat,string giovao,string giora)
        {
            try
            {
                con.Open();
                string sql = "set dateformat dmy update DATSAN set MaSan = " + masan + ",NgayApDung = '" + ngaydat + "',GioVao ='" + giovao + "',GioRa ='" + giora + "' where MaDatSan = " + madatsan + "";
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

        public bool updateKhachHang(string makh, string hoten, string sdt, string gioitinh, string ngaysinh)
        {
            try
            {
                con.Open();
                string sql = "set dateformat dmy update KHACHHANG set HoTen = N'" + hoten + "',Sdt = '" + sdt + "',Gioitinh = N'" + gioitinh + "',NgaySinh ='" + ngaysinh + "' where MaKH = " + makh + "";
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

        public bool huySan(string madatsan)
        {
            try
            {
                con.Open();
                string sql = "delete from DATSAN where MaDatSan = "+madatsan+"";
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



    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLHS.Model;
using System.Windows.Forms;
using System.Collections;

namespace QLHS.dal
{
    public class TaiKhoanDAL:DBConnection
    {
        private SqlDataAdapter da;
        private SqlCommand cmd;

        public TaiKhoan Authentication(String username, String pass)
        {
            String txt = "";
            String query = "select giaovien.ma_gv ho_ten, loai_tai_khoan from taikhoan inner join giaovien " +
            "on taikhoan.ma_gv = giaovien.ma_gv where ten_dang_nhap = @ten_dang_nhap and mat_khau = @mat_khau";
            String hoTen = "";
            byte loai = 0;
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@ten_dang_nhap", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@mat_khau", SqlDbType.VarChar).Value = pass;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) {
                   GiaoVien gv = new GiaoVien(reader.GetString(0), null, reader.GetString(1), false, null, null, null);
                    TaiKhoan tk = new TaiKhoan(1, username, pass, reader.GetByte(2), gv);
                    return tk;
                }
                txt = hoTen + "," + loai.ToString();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi!!");
                return null;
            }
            return null;
        }
        public DataTable getAccount()
        {
            //B1 Tạo câu lệnh truy vấn
            String query = "SELECT* FROM taikhoan";
            //B2 Mở kết nối
            conn.Open();
            //B3 Tạo cầu kết nối giữa DataSet và SQL để truy xuất(Đơn giản là tạo cầu nối)
            da = new SqlDataAdapter(query, conn);
            //B4 Đổ dữ liệu vào DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);
            //B5 Đóng kết nối
            conn.Close();
            return dt;
        }

        public bool AddAccount(TaiKhoan ta)
        {
            String query = "INSERT INTO taikhoan(ten_dang_nhap, mat_khau, loai_tai_khoan, ma_gv) " +
                "VALUES (@ten_dang_nhap, @mat_khau, @loai_tai_khoan, @ma_gv);";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@ten_dang_nhap", SqlDbType.VarChar).Value = ta.getTenDangNhap();
                cmd.Parameters.Add("@mat_khau", SqlDbType.VarChar).Value = ta.getMatKhau();
                cmd.Parameters.Add("@loai_tai_khoan", SqlDbType.TinyInt).Value = ta.getLoaiTaiKhoan();
                cmd.Parameters.Add("@ma_gv", SqlDbType.VarChar).Value = ta.getGiaoVien().getMaGV();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi!!");
                return false;
            }
            return true;
        }

        public bool updateAccount(TaiKhoan tk)
        {
            String query = "UPDATE taikhoan SET mat_khau=@mat_khau where id_tk = @id";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@mat_khau", SqlDbType.VarChar).Value = tk.getMatKhau();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = tk.getId_tk();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi!!");
                return false;
            }
            return true;
        }

        public bool deleteAccount(int id)
        {
            String query = "DELETE from taikhoan where id_tk = @id";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi!!");
                return false;
            }
            return true;
        }
    }
}

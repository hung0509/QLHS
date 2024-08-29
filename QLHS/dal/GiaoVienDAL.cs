using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLHS.Model;
using System.Windows.Forms;

namespace QLHS.dal
{
    public class GiaoVienDAL:DBConnection
    {
        private SqlDataAdapter da;
        private SqlCommand cmd;
        public DataTable getAllTeacher()
        {
            //B1 Tạo câu lệnh truy vấn
            String query = "SELECT* FROM giaovien";
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

        public DataTable searchTeacher(String ma_mh, String ho_ten)
        {
            String query = "";
            if (ma_mh.Equals("all"))
            {
                query = "SELECT ma_gv, ho_ten, gioi_tinh, ngay_sinh, dia_chi, email, ten_mon_hoc FROM giaovien inner join monhoc on giaovien.ma_mh = monhoc.ma_mh " +
                    "where ho_ten like '" + ho_ten + "%';";
            }
            else
            {
                query = "SELECT ma_gv, ho_ten, gioi_tinh, ngay_sinh, dia_chi, email, ten_mon_hoc FROM giaovien inner join monhoc on giaovien.ma_mh = monhoc.ma_mh " +
                    "where ho_ten like '" + ho_ten + "%' and monhoc.ma_mh like '" + ma_mh +"';";
            }
            
            conn.Open();
            da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            dt.Columns.Add("ma_gv", typeof(String));
            dt.Columns.Add("ho_ten", typeof(String));
            dt.Columns.Add("gioi_tinh", typeof(bool));
            dt.Columns.Add("ngay_sinh", typeof(String));
            dt.Columns.Add("dia_chi", typeof(String));
            dt.Columns.Add("email", typeof(String));
            dt.Columns.Add("ten_mon_hoc", typeof(String));
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public bool AddGiaoVien(GiaoVien giaoVien)
        {
            String query = "INSERT INTO giaovien (ma_gv, ho_ten, gioi_tinh, ngay_sinh, dia_chi, email, ma_mh) " +
                "VALUES (@ma_gv, @ho_ten, @gioi_tinh, @ngay_sinh, @dia_chi, @email, @ma_mh);";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                
                cmd.Parameters.Add("@ma_gv", SqlDbType.VarChar).Value = giaoVien.getMaGV();
                cmd.Parameters.Add("@ho_ten", SqlDbType.NVarChar).Value = giaoVien.getHo_ten();
                cmd.Parameters.Add("@gioi_tinh", SqlDbType.Bit).Value = giaoVien.getGioi_tinh();
                cmd.Parameters.Add("@ngay_sinh", SqlDbType.DateTime).Value = giaoVien.getNgay_sinh();
                cmd.Parameters.Add("@dia_chi", SqlDbType.NVarChar).Value = giaoVien.getDia_chi();
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = giaoVien.getEmail();
                cmd.Parameters.Add("@ma_mh", SqlDbType.VarChar).Value = giaoVien.getMonHoc().getMaMH();
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

        public bool updateTeacher(GiaoVien giaoVien)
        {
            String query = "UPDATE giaovien SET ho_ten = @ho_ten, gioi_tinh = @gioi_tinh, ngay_sinh = @ngay_sinh," +
                " dia_chi = @dia_chi, email = @email, ma_mh = @ma_mh where ma_gv = @ma_gv";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@ho_ten", SqlDbType.NVarChar).Value = giaoVien.getHo_ten();
                cmd.Parameters.Add("@gioi_tinh", SqlDbType.Bit).Value = giaoVien.getGioi_tinh();
                cmd.Parameters.Add("@ngay_sinh", SqlDbType.DateTime).Value = giaoVien.getNgay_sinh();
                cmd.Parameters.Add("@dia_chi", SqlDbType.NVarChar).Value = giaoVien.getDia_chi();
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = giaoVien.getEmail();
                cmd.Parameters.Add("@ma_mh", SqlDbType.VarChar).Value = giaoVien.getMonHoc().getMaMH();
                cmd.Parameters.Add("@ma_gv", SqlDbType.VarChar).Value = giaoVien.getMaGV();
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

        public bool deleteTeacher(String id)
        {
            String query = "DELETE from giaovien where ma_gv = @id";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
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

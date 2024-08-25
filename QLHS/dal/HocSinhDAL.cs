using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLHS.Model;

namespace QLHS.dal
{
    public class HocSinhDAL:DBConnection
    {
        private SqlDataAdapter da;
        private SqlCommand cmd;

        public DataTable getStudentInClass(int id_lop) {
            //B1 Tạo câu lệnh truy vấn
            String query = "";
            if (id_lop > 0)
            {
                query = "SELECT id_hs, ho_ten, gioi_tinh, ngay_sinh, dia_chi, ten_lop " +
                    "FROM hocsinh inner join lop on hocsinh.id_lop = lop.id_lop" +
                    " where lop.id_lop=" + id_lop + "";
            }
            else
            {
                query = "SELECT id_hs, ho_ten, gioi_tinh, ngay_sinh, dia_chi, ten_lop " +
                    "FROM hocsinh inner join lop on hocsinh.id_lop = lop.id_lop";
            }
            //B2 Mở kết nối
            conn.Open();
            //B3 Tạo cầu kết nối giữa DataSet và SQL để truy xuất(Đơn giản là tạo cầu nối)
            da = new SqlDataAdapter(query, conn);
            //B4 Đổ dữ liệu vào DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("id_hs", typeof(int));
            dt.Columns.Add("ho_ten", typeof(String));
            dt.Columns.Add("gioi_tinh", typeof(bool));
            dt.Columns.Add("ngay_sinh", typeof(String));
            dt.Columns.Add("dia_chi", typeof(String));
            dt.Columns.Add("ten_lop", typeof(String));
            da.Fill(dt);
            //B5 Đóng kết nối
            conn.Close();
            return dt;
        }

        public bool AddStudent(HocSinh hocSinh)
        {
            String query = "INSERT INTO hocsinh (ho_ten, gioi_tinh, ngay_sinh, dia_chi, id_lop) " +
                "VALUES (@ho_ten, @gioi_tinh, @ngay_sinh, @dia_chi, @id_lop);";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@ho_ten", SqlDbType.NVarChar).Value = hocSinh.getHo_ten();
                cmd.Parameters.Add("@gioi_tinh", SqlDbType.Bit).Value = hocSinh.getGioi_tinh();
                cmd.Parameters.Add("@ngay_sinh", SqlDbType.DateTime).Value = hocSinh.getNgay_sinh();
                cmd.Parameters.Add("@dia_chi", SqlDbType.NVarChar).Value = hocSinh.getDia_chi();
                cmd.Parameters.Add("@id_lop", SqlDbType.Int).Value = hocSinh.getLop().getId_lop();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Lỗi!!");
                return false;
            }
            return true;
        }

        public bool updateStudent(HocSinh hocSinh)
        {
            String query = "UPDATE hocsinh SET ho_ten = @ho_ten, gioi_tinh = @gioi_tinh, ngay_sinh = @ngay_sinh," +
                " dia_chi = @dia_chi, id_lop = @id_lop where id_hs = @id_hs";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@ho_ten", SqlDbType.NVarChar).Value = hocSinh.getHo_ten();
                cmd.Parameters.Add("@gioi_tinh", SqlDbType.Bit).Value = hocSinh.getGioi_tinh();
                cmd.Parameters.Add("@ngay_sinh", SqlDbType.DateTime).Value = hocSinh.getNgay_sinh();
                cmd.Parameters.Add("@dia_chi", SqlDbType.NVarChar).Value = hocSinh.getDia_chi();
                cmd.Parameters.Add("@id_lop", SqlDbType.Int).Value = hocSinh.getLop().getId_lop();
                cmd.Parameters.Add("@id_hs", SqlDbType.Int).Value = hocSinh.getId_hs();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Lỗi!!");
                return false;
            }
            return true;
        }

        public bool deleteStudent(int id)
        {
            String query = "DELETE from hocsinh where id_hs = @id_hs";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@id_hs", SqlDbType.Int).Value = id;
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

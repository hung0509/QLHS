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
    public class LopDAL:DBConnection
    {
        private SqlDataAdapter da;
        private SqlCommand cmd;
        public DataTable getAllClass()
        {
            //B1 Tạo câu lệnh truy vấn
            String query = "SELECT id_lop, ten_lop FROM lop";
            //B2 Mở kết nối
            conn.Open();
            //B3 Tạo cầu kết nối giữa DataSet và SQL để truy xuất(Đơn giản là tạo cầu nối)
            da = new SqlDataAdapter(query, conn);
            //B4 Đổ dữ liệu vào DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow row = dt.NewRow();
            row["id_lop"] = 0;
            row["ten_lop"] = "Tất cả";
            dt.Rows.InsertAt(row, 0);
            //B5 Đóng kết nối
            conn.Close();
            return dt;
        }

        public bool addClass(Lop lop)
        {
            String query = "INSERT INTO lop(ten_lop, id_khoi) VALUES (@ten_lop, @id_khoi);";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@ten_lop", SqlDbType.NVarChar).Value = lop.getTen_lop();
                cmd.Parameters.Add("@id_khoi", SqlDbType.Int).Value = lop.getKhoi().getId_khoi();
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

        public bool updateClass(Lop lop)
        {
            String query = "UPDATE lop SET ten_lop=@ten_lop, id_khoi = @id_khoi where id_lop = @id";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@ten_lop", SqlDbType.NVarChar).Value = lop.getTen_lop();
                cmd.Parameters.Add("@id_khoi", SqlDbType.Int).Value = lop.getKhoi().getId_khoi();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = lop.getId_lop();
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

        public bool deleteClass(int id)
        {
            String query = "DELETE from lop where id_lop = @id";
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

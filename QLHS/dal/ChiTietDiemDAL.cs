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
    public class ChiTietDiemDAL: DBConnection
    {
        private SqlDataAdapter da;
        private SqlCommand cmd;
        public DataTable getAllPoints()
        {
            //B1 Tạo câu lệnh truy vấn
            String query = "SELECT* FROM chitietdie;";
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

        public bool AddPoint(ChiTietDiem chiTietDiem)
        {
            String query = "INSERT INTO chitietdiem (diem15, diem45, diemTB, id_hs, id_hk, ma_mh) " +
                "VALUES (@diem15, @diem45, @diemTB, @id_hs, @id_hk, @ma_mh);";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@diem15", SqlDbType.Float).Value = chiTietDiem.getDiem15();
                cmd.Parameters.Add("@diem45", SqlDbType.Float).Value = chiTietDiem.getDiem45();
                cmd.Parameters.Add("@diemTB", SqlDbType.Float).Value = chiTietDiem.getDiemTB();
                cmd.Parameters.Add("@id_hs", SqlDbType.Int).Value = chiTietDiem.GetHocSinh().getId_hs();
                cmd.Parameters.Add("@id_hk", SqlDbType.Int).Value = chiTietDiem.getHocKy();
                cmd.Parameters.Add("@ma_mh", SqlDbType.VarChar).Value = chiTietDiem.getMonHoc().getMaMH();
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

        public bool updatePoint(ChiTietDiem chiTietDiem)
        {
            String query = "UPDATE chitietdiem SET diem15=@diem15, diem45=@diem45, diemTB=@diemTB, " +
                "id_hs=@id_hs, id_hk=@id_hk, ma_mh=@ma_mh where id_ctd = @id_ctd";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@diem15", SqlDbType.Float).Value = chiTietDiem.getDiem15();
                cmd.Parameters.Add("@diem45", SqlDbType.Float).Value = chiTietDiem.getDiem45();
                cmd.Parameters.Add("@diemTB", SqlDbType.Float).Value = chiTietDiem.getDiemTB();
                cmd.Parameters.Add("@id_hs", SqlDbType.Int).Value = chiTietDiem.GetHocSinh().getId_hs();
                cmd.Parameters.Add("@id_hk", SqlDbType.Int).Value = chiTietDiem.getHocKy();
                cmd.Parameters.Add("@ma_mh", SqlDbType.VarChar).Value = chiTietDiem.getMonHoc().getMaMH();
                cmd.Parameters.Add("@id_ctd", SqlDbType.Int).Value = chiTietDiem.getId_ctd();
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

        public bool deletePoint(int id)
        {
            String query = "DELETE from chitietdiem where id_ctd = @id_ctd";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@id_ctd", SqlDbType.Int).Value = id;
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

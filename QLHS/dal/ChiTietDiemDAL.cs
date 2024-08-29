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
            String query = "SELECT* FROM chitietdiem";
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

        public DataTable searchPoint(String ma_mh, int id_lop, int id_hk)
        {
            String query = "SELECT id_ctd, ho_ten, ten_mon_hoc, hocky.id_hk, diem15, diem45, diemTB FROM chitietdiem inner join monhoc on monhoc.ma_mh = chitietdiem.ma_mh " +
                                                     "inner join hocky on hocky.id_hk = chitietdiem.id_hk " +
                                                     "inner join hocsinh on hocsinh.id_hs = chitietdiem.id_hs " +
                                                     "inner join lop on lop.id_lop = hocsinh.id_lop " +
                                                     "where 1 = 1";
            if(!ma_mh.Equals("all"))
            {
                query = query + " and monhoc.ma_mh like '" + ma_mh + "'";
            } 

            if(id_lop != 0)
            {
                query = query + " and lop.id_lop = " + id_lop + "";
            }

            if(id_hk != 0)
            {
                query = query + " and hocky.id_hk = " + id_hk + "";
            }
            conn.Open();
            da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            dt.Columns.Add("id_ctd", typeof(int));
            dt.Columns.Add("ho_ten", typeof(String));
            dt.Columns.Add("ten_mon_hoc", typeof(String));
            dt.Columns.Add("hocky.id_hk", typeof(byte));
            dt.Columns.Add("diem15", typeof(float));
            dt.Columns.Add("diem45", typeof(float));
            dt.Columns.Add("diemTB", typeof(float));
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public bool AddPoint(int id_hs, int id_hk, String ma_mh)
        {
            String query = "INSERT INTO chitietdiem (diem15, diem45, diemTB, id_hs, id_hk, ma_mh) " +
                "VALUES (0, 0, 0, @id_hs, @id_hk, @ma_mh);";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@id_hs", SqlDbType.Int).Value = id_hs;
                cmd.Parameters.Add("@id_hk", SqlDbType.Int).Value = id_hk;
                cmd.Parameters.Add("@ma_mh", SqlDbType.VarChar).Value = ma_mh;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool updatePoint(ChiTietDiem chiTietDiem)
        {
            String query = "UPDATE chitietdiem SET diem15=@diem15, diem45=@diem45, diemTB=@diemTB " +
                " where id_ctd = @id_ctd";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@diem15", SqlDbType.Float).Value = chiTietDiem.getDiem15();
                cmd.Parameters.Add("@diem45", SqlDbType.Float).Value = chiTietDiem.getDiem45();
                cmd.Parameters.Add("@diemTB", SqlDbType.Float).Value = chiTietDiem.getDiemTB();
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

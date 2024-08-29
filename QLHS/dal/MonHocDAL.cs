using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHS.dal
{
    public class MonHocDAL:DBConnection
    {
        private SqlDataAdapter da;
        private SqlCommand cmd;
        public DataTable getAllSubject()
        {
            //B1 Tạo câu lệnh truy vấn
            String query = "SELECT* FROM monhoc";
            //B2 Mở kết nối
            conn.Open();
            //B3 Tạo cầu kết nối giữa DataSet và SQL để truy xuất(Đơn giản là tạo cầu nối)
            da = new SqlDataAdapter(query, conn);
            //B4 Đổ dữ liệu vào DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow row = dt.NewRow();
            row["ma_mh"] = "all";
            row["ten_mon_hoc"] = "Tất cả";
            dt.Rows.InsertAt(row, 0);
            //B5 Đóng kết nối
            conn.Close();
            return dt;
        }

        public DataTable getSubject()
        {
            //B1 Tạo câu lệnh truy vấn
            String query = "SELECT* FROM monhoc";
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
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHS.dal
{
    public class HocKyDAL:DBConnection
    {
        private SqlDataAdapter da;
        private SqlCommand cmd;
        public DataTable getAllHocKy()
        {
            //B1 Tạo câu lệnh truy vấn
            String query = "SELECT* FROM hocky";
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

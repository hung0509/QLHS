using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHS.dal
{
    public class DBConnection
    {
        private const String CON_STR = "Data Source=XUAN-HUNG\\XUANHUNG;Initial Catalog=QLHS;User ID=sa;Password=1;Encrypt=False";

        protected SqlConnection conn;
        public DBConnection()
        {
            conn = new SqlConnection(CON_STR);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHS.Model
{
    public class MonHoc
    {
        private String Ma_MH;
        private String ten_mon_hoc;
        public MonHoc() { }

        public MonHoc(string ma_MH, string ten_mon_hoc)
        {
            Ma_MH = ma_MH;
            this.ten_mon_hoc = ten_mon_hoc;
        }

        public String getMaMH() {  return Ma_MH; }

        public String getTenMonHoc() { return ten_mon_hoc; }

        public void setTenMonHoc(String ten_mon_hoc) { 
            this.ten_mon_hoc = ten_mon_hoc;
        }
    }
}

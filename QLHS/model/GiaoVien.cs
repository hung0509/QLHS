using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHS.Model
{
    public class GiaoVien:Person
    {
        private String ma_gv;
        private String email;
        private MonHoc mon_hoc;

        public GiaoVien(String ma_gv, MonHoc mon_hoc, string ho_ten, bool gioi_tinh, string ngay_sinh, string dia_chi, string email)
        {
            this.ma_gv = ma_gv;
            this.mon_hoc = mon_hoc;
            this.ho_ten = ho_ten;
            this.gioi_tinh = gioi_tinh;
            this.ngay_sinh = ngay_sinh;
            this.dia_chi = dia_chi;
            this.email = email;
        }

        public String getMaGV()
        {
            return this.ma_gv;
        }
        public MonHoc getMonHoc()
        {
            return this.mon_hoc;
        }

        public String getEmail() { return this.email; }

        public void setEmail(String email) {  this.email = email; }
        public void setMonHoc(MonHoc monHoc)
        {
            this.mon_hoc = monHoc;
        }
    }
}

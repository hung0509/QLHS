using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHS.Model
{
    public class HocSinh : Person 
    {
        private int id_hs;
        private Lop lop;

        public HocSinh(int id_hs, Lop lop, string ho_ten, bool gioi_tinh, string ngay_sinh, string dia_chi)
        {
            this.id_hs = id_hs;
            this.lop = lop;
            this.ho_ten = ho_ten;
            this.gioi_tinh = gioi_tinh;
            this.ngay_sinh = ngay_sinh;
            this.dia_chi = dia_chi;
        }

        public int getId_hs()
        {
            return this.id_hs;
        }

        public Lop getLop() {
            return this.lop;
        }

        public void setLop(Lop lop)
        {
            this.lop = lop;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHS.Model
{
    public class Lop
    {
        public int id_lop;
        public String ten_lop;

        public Khoi khoi;
        public Lop() { }

        public Lop(int id_lop, string ten_lop, Khoi khoi)
        {
            this.id_lop = id_lop;
            this.ten_lop = ten_lop;
            this.khoi = khoi;
        }

        public int getId_lop() { return id_lop; }

        public String getTen_lop() {return ten_lop;}

        public Khoi getKhoi() {return khoi;}

        public void setTenLop(String tenLop) { 
            this.ten_lop = tenLop;
        }

        public void setKhoi(Khoi khoi) { 
            this.khoi  = khoi;
        }
    }
}

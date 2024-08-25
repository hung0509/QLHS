using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHS.Model
{
    public class Khoi
    {
        private int id_khoi;
        private String ten_khoi;
        public Khoi(int id_khoi, string ten_khoi)
        {
            this.id_khoi = id_khoi;
            this.ten_khoi = ten_khoi;
        }   
        public Khoi(){
        }

        public int getId_khoi() {
            return this.id_khoi;
        }

        public String getTen_khoi() {
            return this.ten_khoi;
        }

        public void setTenKhoi(String ten_Khoi)
        {
            this.ten_khoi  = ten_Khoi;
        }

    }
}

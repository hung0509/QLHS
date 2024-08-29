using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHS.Model
{
    public class HocKy
    {
        private int id_hk;
        private String name_hk;
        public HocKy(int id_hk, string name_hk)
        {
            this.id_hk = id_hk;
            this.name_hk = name_hk;
        }

        public HocKy() { }

        public int getHocKy() { 
            return this.id_hk; 
        }
        public String getNameKy() { 
            return this.name_hk;
        }

        public void setNameKy(String name_hk) { 
            this.name_hk = name_hk;
        }
    }
}

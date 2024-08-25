using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHS.Model
{
    public class Person
    {
        protected String ho_ten;
        protected bool gioi_tinh;
        protected String ngay_sinh;
        protected String dia_chi;

        public String getHo_ten() {  return ho_ten; }

        public bool getGioi_tinh() { return gioi_tinh; }

        public String getNgay_sinh() {  return ngay_sinh; }

        public String getDia_chi() { return dia_chi; }  

        public void setHo_ten(String ho_ten)
        {
            this.ho_ten = ho_ten;
        }

        public void setGioi_tinh(bool gioi_tinh)
        {
             this.gioi_tinh = gioi_tinh;
        }

        public void setNgay_sinh(String ngay_sinh)
        {
            this.ngay_sinh = ngay_sinh;
        }

        public void setDia_chi(String dia_chi)
        {
            this.dia_chi = dia_chi;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHS.Model
{
    public class ChiTietDiem
    {
        private int id_ctd;
        private float diem15;
        private float diem45;
        private float diemTB;
        private int id_hk;
        private HocSinh hoc_sinh;
        private MonHoc mon_hoc;

        public ChiTietDiem(int id_ctd, float diem15, float diem45, int id_hk, HocSinh hoc_sinh, MonHoc mon_hoc,float diemTB)
        {
            this.id_ctd = id_ctd;
            this.diem15 = diem15;
            this.diem45 = diem45;
            this.id_hk = id_hk;
            this.hoc_sinh = hoc_sinh;
            this.mon_hoc = mon_hoc;
            this.diemTB = diemTB;
        }

        public int getId_ctd() { 
            return this.id_ctd; 
        }

        public float getDiem15()
        {
            return this.diem15;
        }
        public float getDiem45()
        {
            return this.diem45;
        }

        public int getHocKy()
        {
            return this.id_hk;
        }

        public float getDiemTB()
        {
            return this.diemTB;
        }

        public MonHoc getMonHoc()
        {
            return this.mon_hoc;
        }

        public HocSinh GetHocSinh()
        {
            return this.hoc_sinh;
        }

        public void setDiem15(float diem15)
        {
             this.diem15 = diem15;
        }
        public void setDiem45(float diem45)
        {
            this.diem45 = diem45;
        }

        public void setHocKy(int hocky)
        {
             this.id_hk = hocky;
        }

        public void setDiemTB(float diemTB)
        {
            this.diemTB = diemTB;
        }

        public void setMonHoc(MonHoc monHoc)
        {
            this.mon_hoc = monHoc;
        }

        public void setHocSinh(HocSinh hs)
        {
            this.hoc_sinh = hs;
        }
    }
}

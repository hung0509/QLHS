using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHS.Model
{
    public class TaiKhoan
    {
        private int id_tk;
        private String ten_dang_nhap;
        private String mat_khau;
        private byte loai_tai_khoan;
        private GiaoVien giao_vien;

        public TaiKhoan() { 
        }
        public TaiKhoan(int id_tk, string ten_dang_nhap, string mat_khau, byte loai_tai_khoan, GiaoVien giao_vien)
        {
            this.id_tk = id_tk;
            this.ten_dang_nhap = ten_dang_nhap;
            this.mat_khau = mat_khau;
            this.loai_tai_khoan = loai_tai_khoan;
            this.giao_vien = giao_vien;
        }
        public TaiKhoan(string ten_dang_nhap, string mat_khau, byte loai_tai_khoan, GiaoVien giao_vien)
        {
            this.id_tk = id_tk;
            this.ten_dang_nhap = ten_dang_nhap;
            this.mat_khau = mat_khau;
            this.loai_tai_khoan = loai_tai_khoan;
            this.giao_vien = giao_vien;
        }

        public int getId_tk() {
            return this.id_tk;
        }

        public String getTenDangNhap()
        {
            return this.ten_dang_nhap;
        }

        public String getMatKhau()
        {
            return this.mat_khau;
        }

        public byte getLoaiTaiKhoan()
        {
            return this.loai_tai_khoan;
        }

        public GiaoVien getGiaoVien()
        {
            return this.giao_vien;
        }

        public void setTenDangNhap(String ten_dang_nhap)
        {
            this.ten_dang_nhap = ten_dang_nhap;
        }

        public void setMatKhau(String mat_khau)
        {
            this.mat_khau = mat_khau;
        }

        public void setLoaiTaiKhoan(byte loai_tk)
        {
            this.loai_tai_khoan = loai_tk;
        }

        public void setGiaoVien(GiaoVien giao_vien)
        {
            this.giao_vien = giao_vien;
        }
    }
}

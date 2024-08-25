using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLHS.dal;
using QLHS.Model;

namespace QLHS
{
    public partial class FrmDangNhap : Form
    { 
        public bool isConnect = false;
        public static String ho_ten = "";
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String tk = txtTaiKhoan.Text;
            String mk = txtMatKhau.Text;
            bool isCheck = true;
            if(tk == null || tk.Equals("")){
                label7.Text = "*Tài khoản đang bị trống*";
                label7.Visible = true;
                isCheck = false;
            }

            if(mk == null || mk.Equals(""))
            {
                label6.Text = "*Mật khẩu đang bị trống*";
                label6.Visible = true;
                isCheck = false;
            }

            if (isCheck)
            {
                TaiKhoanDAL dal = new TaiKhoanDAL();
                TaiKhoan taiKhoan = dal.Authentication(tk, mk);
                
                if(taiKhoan != null)
                {
                    isConnect = true;
                    ho_ten = taiKhoan.getGiaoVien().getHo_ten();
                    if(MessageBox.Show("Bạn đã đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        if(taiKhoan.getLoaiTaiKhoan() == 0)
                        {
                            Form1 f = new Form1();
                            this.Hide();    
                            f.ShowDialog();
                        }
                        else
                        {
                            FormGiaoVien f = new FormGiaoVien();
                            this.Hide();
                            f.ShowDialog();
                        }
                    }
                    else
                    {
                        label7.Visible = true;
                        label6.Visible = true;
                        label7.Text = "*Tài khoản hoặc tên đăng nhập sai!*";
                        label6.Text = "*Tài khoản hoặc tên đăng nhập sai!*";
                    }
                }
            }
          
        }

    }
}

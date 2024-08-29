using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLHS.dal;
using QLHS.Model;

namespace QLHS
{
    public partial class FrmAddTeacher : Form
    {
        public FrmAddTeacher()
        {
            InitializeComponent();
        }

        bool checkUsername()
        {
            TaiKhoanDAL tk = new TaiKhoanDAL();
            return tk.checkTk(txtuser.Text);
        }

        bool checkInfoTeacher()
        {
            bool isCheck = true;

            if (txtMaGV.Text == null || txtMaGV.Text.Equals(""))
            {
                isCheck = false;
                label16.Visible = true;
            }
            else
            {
                label16.Visible = false;
            }

            if (txtNameTeacher.Text == null || txtNameTeacher.Text.Equals(""))
            {
                isCheck = false;
                label13.Visible = true;
            }
            else
            {
                label13.Visible = false;
            }

            if (txtuser.Text == null || txtuser.Text.Equals(""))
            {
                isCheck |= false;
                label11.Text = "*Tên đăng nhập đang bị bỏ trống*";
                label11.Visible = true;
            }
            else
            {
                if (!checkUsername())
                {
                    label11.Text = "*Tên đăng nhập đã tồn tại*";
                    label11.Visible = true;
                }
                else
                {
                    label11.Visible = false;
                }
            }

            if (txtpass.Text == null || txtpass.Text.Equals(""))
            {
                isCheck = false;
                label12.Text = "*Mật khẩu đang bị bỏ trống*";
                label12.Visible = true;
            }
            else
            {
                label12.Visible = false;
            }

            if (txtrepass.Text == null || txtrepass.Text.Equals(""))
            {
                label14.Text = "*Xác nhận mật khẩu đang bị bỏ trống*";
                isCheck = false;
                label14.Visible = true;
            }
            else
            {
                label14.Visible = false;
            }

            if (txtpass.Text != txtrepass.Text && txtpass.Text != null && !txtpass.Text.Equals(""))
            {

                isCheck = false;
                label12.Text = "*Mật khẩu không khớp với mật khẩu xác nhận*";
                label14.Text = "*Mật khẩu không khớp với mật khẩu xác nhận*";
                label12.Visible = true;
                label14.Visible = true;
            }
            else if (txtpass.Text == txtrepass.Text && txtpass.Text != null && !txtpass.Text.Equals(""))
            {
                label13.Visible = false;
                label14.Visible = false;
            }

            if (txtDateOfBirthTeacher.Text == null || txtDateOfBirthTeacher.Text.Equals(""))
            {
                isCheck = false;
                label15.Visible = true;
            }
            else
            {
                String format = "dd/MM/yyyy";
                DateTime dateValue;
                bool isValid = DateTime.TryParseExact(txtDateOfBirthTeacher.Text, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);
                if (!isValid)
                {
                    isCheck = false;
                    label15.Text = "*Ngày sinh định dạnh sai hoặc thiếu*";
                    label15.Visible = true;
                }
                else
                {
                    label15.Visible = false;
                }
            }

            if (cbSubjectTeacher.SelectedValue.Equals("all"))
            {
                isCheck = false;
                label42.Visible = true;
            }
            else
            {
                label42.Visible = false;
            }

            if (cbGenderTeacher.SelectedItem == null)
            {
                isCheck = false;
                label43.Visible = true;
            }
            else
            {
                label43.Visible = false;
            }

            if (txtAndressTeacher.Text == null || txtAndressTeacher.Text.Equals(""))
            {
                label44.Visible = true;
                isCheck = false;
            }
            else
            {
                label44.Visible = false;
            }

            if (txtMail.Text == null || txtMail.Text.Equals(""))
            {
                isCheck = false;
                label45.Text = "*Email đang bị để trống*";
                label45.Visible = true;
            }
            else
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(txtMail.Text, pattern))
                {
                    isCheck = false;
                    label45.Text = "*Email nhập vào không hợp lệ*";
                    label45.Visible = true;
                }
                else
                {
                    label45.Visible = false;
                }
            }
            return isCheck;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInfoTeacher())
            {
                try
                {
                    GiaoVienDAL dal = new GiaoVienDAL();
                    bool gt = true;
                    if (cbGenderTeacher.SelectedText.Equals("Nữ"))
                    {
                        gt = false;
                    }
                    MonHoc m = new MonHoc(cbSubjectTeacher.SelectedValue.ToString(), cbSubjectTeacher.SelectedItem.ToString());
                    GiaoVien gv = new GiaoVien(txtMaGV.Text, m, txtNameTeacher.Text, gt,
                        txtDateOfBirthTeacher.Text, txtAndressTeacher.Text, txtMail.Text);
                    dal.AddGiaoVien(gv);
                    TaiKhoanDAL tkDAL = new TaiKhoanDAL();
                    //Mặc định tạo tk gv
                    TaiKhoan tk = new TaiKhoan(txtuser.Text, txtpass.Text, 1, gv);
                    if (tkDAL.AddAccount(tk))
                    {
                        MessageBox.Show("Đăng ký thành công 1 giáo viên");
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void FormThemGiaoVien_Load(object sender, EventArgs e)
        {
            MonHocDAL dal = new MonHocDAL();
            DataTable dt = dal.getAllSubject();

            cbSubjectTeacher.DisplayMember = "ten_mon_hoc";
            cbSubjectTeacher.ValueMember = "ma_mh";
            cbSubjectTeacher.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (FrmDangNhap.loai_tai_khoan == 0)
            {
                Form1 f = new Form1();
                f.ShowDialog();
            }
            else
            {
                FormGiaoVien f = new FormGiaoVien();
                f.ShowDialog();
            }
        }
    }

}

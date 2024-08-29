using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLHS.dal;
using QLHS.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLHS
{
    public partial class Form1 : Form
    {
        private bool addStudent = false;
        private int idSelectedStudent = -1;
        private int idSelectedPoint = -1;
        private String idSelectedTeacher = "";
        private bool addPoint = false;
        public Form1()
        {
            InitializeComponent();
        }

        void loadLopChiTietDiem()
        {
            LopDAL lopDAL = new LopDAL();
            DataTable dt = lopDAL.getAllClass();

            comboBox6.DisplayMember = "ten_lop";
            comboBox6.ValueMember = "id_lop";
            comboBox6.DataSource = dt;
        }

        void loadMonHocCTD()
        {
            MonHocDAL dal = new MonHocDAL();
            DataTable dt = dal.getAllSubject();

            comboBox3.DisplayMember = "ten_mon_hoc";
            comboBox3.ValueMember = "ma_mh";
            comboBox3.DataSource = dt;
        }
        void loadPoint()
        {
            int id_lop = 0, id_hk = 0;
            String ma_mh = "all";
            if (comboBox6.SelectedItem != null)
            {
                id_lop = Convert.ToInt32(comboBox6.SelectedValue);
            }
            if(comboBox2.SelectedItem != null)
            {
                id_hk = Convert.ToInt32(comboBox2.SelectedItem);
            }
            if(comboBox3.SelectedItem != null)
            {
                ma_mh = comboBox3.SelectedValue.ToString();
            }

            try
            {
                ChiTietDiemDAL dal = new ChiTietDiemDAL();
                DataTable dt = dal.searchPoint(ma_mh, id_lop, id_hk);

                dgvPoint.AutoGenerateColumns = false;
                dgvPoint.DataSource = dt;

                dgvPoint.Columns["id_ctd"].DataPropertyName = "id_ctd";
                dgvPoint.Columns["ho_ten_point"].DataPropertyName = "ho_ten";
                dgvPoint.Columns["mon_hoc_point"].DataPropertyName = "ten_mon_hoc";
                dgvPoint.Columns["hocky"].DataPropertyName = "id_hk";
                dgvPoint.Columns["diem15"].DataPropertyName = "diem15";
                dgvPoint.Columns["diem45"].DataPropertyName = "diem45";
                dgvPoint.Columns["diemtb"].DataPropertyName = "diemTB";
                if (dgvPoint.Rows.Count > 0)
                {
                    DataGridViewRow firstRow = dgvPoint.Rows[0];
                    textBox4.Text = firstRow.Cells["ho_ten_point"].Value.ToString();
                    textBox3.Text = firstRow.Cells["diem15"].Value.ToString();
                    textBox2.Text = firstRow.Cells["diem45"].Value.ToString();
                    textBox6.Text = firstRow.Cells["hocky"].Value.ToString();
                    textBox7.Text = firstRow.Cells["mon_hoc_point"].Value.ToString();
                    textBox5.Text = firstRow.Cells["diemtb"].Value.ToString();
                }
                else
                {
                    textBox4.Text = "";
                    textBox3.Text = "";
                    textBox2.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox5.Text = "";
                }
            }catch(Exception e)
            {

            }
           
        }
        public void loadAccount()
        {
                TaiKhoanDAL dal = new TaiKhoanDAL();
                DataTable dt = dal.getAllAccount();

                dgvAccount.AutoGenerateColumns = false;
                dgvAccount.DataSource = dt;
                dgvAccount.Columns["ma_gv_account"].DataPropertyName = "ma_gv";
                dgvAccount.Columns["ho_ten_account"].DataPropertyName = "ho_ten";
                dgvAccount.Columns["ten_dang_nhap"].DataPropertyName = "ten_dang_nhap";
                dgvAccount.Columns["mat_khau"].DataPropertyName = "mat_khau";
                dgvAccount.Columns["loai_tai_khoan"].DataPropertyName = "loai_tai_khoan";

            if (dgvAccount.Rows.Count > 0) {
                DataGridViewRow firstRow = dgvAccount.Rows[0];
                textBox8.Text = firstRow.Cells["ma_gv_account"].Value.ToString();
                textBox10.Text = firstRow.Cells["ho_ten_account"].Value.ToString();
                textBox12.Text = firstRow.Cells["ten_dang_nhap"].Value.ToString();
                textBox9.Text = firstRow.Cells["loai_tai_khoan"].Value.ToString();
                textBox11.Text = firstRow.Cells["mat_khau"].Value.ToString();
            }else
            { //Nếu không tồn tại data
                textBox8.Text = "";
                textBox10.Text = "";
                textBox12.Text = "";
                textBox9.Text = "";
                textBox11.Text = "";
            }
                
        }

        public void loadSubJect()
        {
            MonHocDAL dal = new MonHocDAL();
            DataTable dt = dal.getAllSubject();

            CbSearchSubJect.DisplayMember = "ten_mon_hoc";
            CbSearchSubJect.ValueMember = "ma_mh";
            CbSearchSubJect.DataSource = dt;
        }

        public void loadTeacher()
        {
            String ma_mh = CbSearchSubJect.SelectedValue.ToString();
            String search = txtSeacrhTeacher.Text;

            if (ma_mh != null && !ma_mh.Equals(""))
            {
                GiaoVienDAL dal = new GiaoVienDAL();
                DataTable dt = dal.searchTeacher(ma_mh, search);

                dgvGiaoVien.AutoGenerateColumns = false;
                dgvGiaoVien.DataSource = dt;

                dgvGiaoVien.Columns["ma_gv"].DataPropertyName = "ma_gv";
                dgvGiaoVien.Columns["ho_ten"].DataPropertyName = "ho_ten";
                dgvGiaoVien.Columns["ngay_sinh"].DataPropertyName = "ngay_sinh";
                dgvGiaoVien.Columns["gioi_tinh"].DataPropertyName = "gioi_tinh";
                dgvGiaoVien.Columns["email"].DataPropertyName = "email";
                dgvGiaoVien.Columns["dia_chi"].DataPropertyName = "dia_chi";
                dgvGiaoVien.Columns["mon_hoc"].DataPropertyName = "ten_mon_hoc";
                if(dgvGiaoVien.Rows.Count > 0)
                {
                    DataGridViewRow firstRow = dgvGiaoVien.Rows[0];
                    txtNameTeacher.Text = firstRow.Cells["ho_ten"].Value.ToString();
                    txtDateOfBirthTeacher.Text = firstRow.Cells["ngay_sinh"].Value.ToString();
                    textBox13.Text = firstRow.Cells["mon_hoc"].Value.ToString();
                    bool b = (bool)firstRow.Cells["gioi_tinh"].Value;
                    if (b == true)
                    {
                        textBox14.Text = "Nam";
                    }
                    else
                    {
                        textBox14.Text = "Nữ";
                    }
                    txtAndressTeacher.Text = firstRow.Cells["dia_chi"].Value.ToString();
                    txtMail.Text = firstRow.Cells["email"].Value.ToString();
                }
                else {
                    txtNameTeacher.Text = "";
                    txtDateOfBirthTeacher.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    txtAndressTeacher.Text = "";
                    txtMail.Text = "";
                }
            }
        }

        public void loadClass()
        {
            LopDAL lopDAL = new LopDAL();
            DataTable dt = lopDAL.getAllClass();

            CbSearchClassStudent.DisplayMember = "ten_lop";
            CbSearchClassStudent.ValueMember = "id_lop";
            CbSearchClassStudent.DataSource = dt;
        }

        public void loadStudent()
        {

            HocSinhDAL hocSinhDAL = new HocSinhDAL();
            DataTable dt = null;
            dt = hocSinhDAL.getStudentInClass((int)CbSearchClassStudent.SelectedValue);

            dgvSinhVien.AutoGenerateColumns = false;//Ko cho tự động tạo cột
            dgvSinhVien.DataSource = dt;

            dgvSinhVien.Columns["Column6"].DataPropertyName = "id_hs";
            dgvSinhVien.Columns["Column7"].DataPropertyName = "ho_ten";
            dgvSinhVien.Columns["Column8"].DataPropertyName = "gioi_tinh";
            dgvSinhVien.Columns["Column10"].DataPropertyName = "ngay_sinh";
            dgvSinhVien.Columns["Column9"].DataPropertyName = "dia_chi";
            dgvSinhVien.Columns["Column14"].DataPropertyName = "ten_lop";
            // Hiển thị qua panelthoong tin
            if(dgvSinhVien.Rows.Count > 0)
            {
                DataGridViewRow firstRow = dgvSinhVien.Rows[0];
                idSelectedStudent =Convert.ToInt32( firstRow.Cells["Column6"].Value);
                txtNameStudent.Text = firstRow.Cells["Column7"].Value.ToString();
                txtDateOfBirthStudent.Text = (String)firstRow.Cells["Column10"].Value.ToString();
                txtTenLop.Text = (String)firstRow.Cells["Column14"].Value.ToString();
                bool b = (bool)firstRow.Cells["Column8"].Value;
                if (b == true)
                {
                    txtGioiTinh.Text = "Nam";
                }
                else
                {
                    txtGioiTinh.Text = "Nữ";
                }
                txtAndressStudent.Text = (String)firstRow.Cells["Column9"].Value.ToString();
            }
            else
            {
                txtNameStudent.Text = "";
                txtDateOfBirthStudent.Text = "";
                txtTenLop.Text = "";
                txtGioiTinh.Text = "";
                txtAndressStudent.Text = "";
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //label2.Text = FrmDangNhap.ho_ten;
            loadClass();
            loadStudent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FrmDangNhap.ho_ten = "";
            FrmDangNhap.isConnect = false;
            FrmDangNhap f = new FrmDangNhap();
            f.ShowDialog();

        }


        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPoint();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không (Y/N)?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvSinhVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSinhVien.Columns[e.ColumnIndex].Name == "Column8")
            {
                if (e.Value != null)
                {
                    bool genderValue = (bool)e.Value;
                    e.Value = genderValue ? "Nam" : "Nữ";
                    e.FormattingApplied = true;
                }
            }
        }

        private void CbSearchClassStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int id_lop = Convert.ToInt32(CbSearchClassStudent.SelectedValue);
            loadStudent();
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenLop.Visible = true;
            txtGioiTinh.Visible = true;
            cbClassStudent.Visible = false;
            CbGioiTinh.Visible = false;

            txtNameStudent.ReadOnly = true;
            txtDateOfBirthStudent.ReadOnly = true;
            txtAndressStudent.ReadOnly = true;
            if (e.RowIndex >= 0)
            {
                // Lấy ra dòng được click
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

                idSelectedStudent = Convert.ToInt32(row.Cells["Column6"].Value);
                txtNameStudent.Text = row.Cells["Column7"].Value.ToString();
                txtDateOfBirthStudent.Text = (String)row.Cells["Column10"].Value.ToString();
                txtTenLop.Text = (String)row.Cells["Column14"].Value.ToString();
                bool b = (bool)row.Cells["Column8"].Value;
                if (b == true)
                {
                    txtGioiTinh.Text = "Nam";
                }
                else
                {
                    txtGioiTinh.Text = "Nữ";
                }
                txtAndressStudent.Text = (String)row.Cells["Column9"].Value.ToString();
            }

        }

        private void btnAllertStudent_Click(object sender, EventArgs e)
        {
            txtTenLop.Visible = false;
            txtGioiTinh.Visible = false;
            cbClassStudent.Visible = true;
            CbGioiTinh.Visible = true;

            txtNameStudent.ReadOnly = false;
            txtDateOfBirthStudent.ReadOnly = false;
            txtAndressStudent.ReadOnly = false;
            LopDAL lopDAL = new LopDAL();
            DataTable dt = lopDAL.getAllClass();

            cbClassStudent.DisplayMember = "ten_lop";
            cbClassStudent.ValueMember = "id_lop";
            cbClassStudent.DataSource = dt;
            txtNameStudent.Focus();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            txtNameStudent.Text = "";
            txtDateOfBirthStudent.Text = "";
            txtAndressStudent.Text = "";
            txtTenLop.Visible = false;
            txtGioiTinh.Visible = false;
            cbClassStudent.Visible = true;
            CbGioiTinh.Visible = true;

            txtNameStudent.ReadOnly = false;
            txtDateOfBirthStudent.ReadOnly = false;
            txtAndressStudent.ReadOnly = false;
            addStudent = true;
            LopDAL lopDAL = new LopDAL();
            DataTable dt = lopDAL.getAllClass();

            cbClassStudent.DisplayMember = "ten_lop";
            cbClassStudent.ValueMember = "id_lop";
            cbClassStudent.DataSource = dt;
            txtNameStudent.Focus();
        }

        bool checkInfoStudent()
        {
            bool isCheck = true;
            if (txtNameStudent.Text == null || txtNameStudent.Text.Equals(""))
            {
                isCheck = false;
                label30.Visible = true;
            }
            else
            {
                label30.Visible = false;
            }

            if (txtDateOfBirthStudent.Text == null || txtDateOfBirthStudent.Text.Equals(""))
            {
                isCheck = false;
                label36.Text = "*Ngày sinh đang bị bỏ trống*";
                label36.Visible = true;
            }
            else
            {
                String format = "dd/MM/yyyy";
                DateTime dateValue;
                bool isValid = DateTime.TryParseExact(txtDateOfBirthStudent.Text, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);
                if (!isValid)
                {
                    isCheck = false;
                    label36.Text = "*Ngày sinh định dạnh sai hoặc thiếu*";
                    label36.Visible = true;
                }
                else
                {
                    label36.Visible = false;
                }
            }

            if ((int)cbClassStudent.SelectedValue == 0)
            {
                isCheck = false;
                label38.Visible = true;
            }
            else
            {
                label38.Visible = false;
            }

            if (CbGioiTinh.SelectedItem == null)
            {
                isCheck = false;
                label39.Visible = true;
            }
            else
            {
                label39.Visible = false;
            }

            if (txtAndressStudent.Text == null || txtAndressStudent.Text.Equals(""))
            {
                isCheck = false;
                label40.Visible = true;
            }
            else
            {
                label40.Visible = false;
            }

            return true;
        }

        private void btnSaveStudent_Click(object sender, EventArgs e)
        {
            HocSinhDAL dal = new HocSinhDAL();
            if (addStudent)
            {
                if (checkInfoStudent())
                {
                    bool isMale = true;
                    if (CbGioiTinh.SelectedItem.ToString() == "Nữ")
                    {
                        isMale = false;
                    }
                    Lop l = new Lop((int)cbClassStudent.SelectedValue, cbClassStudent.SelectedItem.ToString(), null);
                    HocSinh hs = new HocSinh(0, l, txtNameStudent.Text, isMale, txtDateOfBirthStudent.Text, txtAndressStudent.Text);
                    if (dal.AddStudent(hs))
                    {
                        ChiTietDiemDAL cDal = new ChiTietDiemDAL();
                        MonHocDAL mdal = new MonHocDAL();
                        DataTable dt =  mdal.getSubject(); ;
                        int id = dal.getStudentNew();
                        for(int i = 1; i <= 2; i++)
                        {
                            foreach(DataRow row in dt.Rows)
                                {
                                cDal.AddPoint(id, i, row["ma_mh"].ToString());
                                }
                        }
                        MessageBox.Show("Bạn đã thêm thành công một học sinh!");
                    }
                }
            }
            else
            {
                bool isMale = true;
                if (txtGioiTinh.Text == "Nữ")
                {
                    isMale = false;
                }
                
                Lop l = new Lop((int)cbClassStudent.SelectedValue, cbClassStudent.SelectedItem.ToString(), null);
                HocSinh hs = new HocSinh(idSelectedStudent, l, txtNameStudent.Text, isMale, txtDateOfBirthStudent.Text, txtAndressStudent.Text);

                if (dal.updateStudent(hs))
                {
                    MessageBox.Show("Bạn đã cập nhật thành công một học sinh!");
                }
            }

            txtTenLop.Visible = true;
            txtGioiTinh.Visible = true;
            cbClassStudent.Visible = false;
            CbGioiTinh.Visible = false;

            txtNameStudent.ReadOnly = true;
            txtDateOfBirthStudent.ReadOnly = true;
            txtAndressStudent.ReadOnly = true;
            CbSearchClassStudent.SelectedValue = 0;
            addStudent = false;
            loadStudent();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            HocSinhDAL dal = new HocSinhDAL();
            if(idSelectedStudent != -1)
            { 
               if( MessageBox.Show("Bạn có chắc chắn muốn xóa học sinh này không(Y?N)", "Cánh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
               {
                    dal.deleteStudent(idSelectedStudent);
                    loadStudent();
               }
            }
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            if (txtSearchStudent.Text != null)
            {
                HocSinhDAL hocSinhDAL = new HocSinhDAL();
                DataTable dt = hocSinhDAL.searchStudent(txtSearchStudent.Text.ToString(), (int)CbSearchClassStudent.SelectedValue);
                dgvSinhVien.AutoGenerateColumns = false;//Ko cho tự động tạo cột
                dgvSinhVien.DataSource = dt;

                dgvSinhVien.Columns["Column6"].DataPropertyName = "id_hs";
                dgvSinhVien.Columns["Column7"].DataPropertyName = "ho_ten";
                dgvSinhVien.Columns["Column8"].DataPropertyName = "gioi_tinh";
                dgvSinhVien.Columns["Column10"].DataPropertyName = "ngay_sinh";
                dgvSinhVien.Columns["Column9"].DataPropertyName = "dia_chi";
                dgvSinhVien.Columns["Column14"].DataPropertyName = "ten_lop";
                // Hiển thị qua panelthoong tin
                DataGridViewRow firstRow = dgvSinhVien.Rows[0];
                txtNameStudent.Text = firstRow.Cells["Column7"].Value.ToString();
                txtDateOfBirthStudent.Text = (String)firstRow.Cells["Column10"].Value.ToString();
                txtTenLop.Text = (String)firstRow.Cells["Column14"].Value.ToString();
                bool b = (bool)firstRow.Cells["Column8"].Value;
                if (b == true)
                {
                    txtGioiTinh.Text = "Nam";
                }
                else
                {
                    txtGioiTinh.Text = "Nữ";
                }
                txtAndressStudent.Text = (String)firstRow.Cells["Column9"].Value.ToString();
            }
            }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(tabControl1.SelectedIndex);
            switch (index)
            {
                case 0:
                    {
                        loadClass();
                        loadStudent();
                        break;
                    }
                case 1:
                    {
                        loadSubJect();
                        loadTeacher();
                        break;
                    }
                case 2:
                    {
                        loadLopChiTietDiem();
                        loadMonHocCTD();
                        loadPoint();
                        break;
                    }
                case 3:
                    {
                        loadAccount();
                        break;
                    }
            }
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAddTeacher f = new FrmAddTeacher();
            f.ShowDialog();
        }

        private void btnEditTeacher_Click(object sender, EventArgs e)
        {
            textBox13.Visible = false;
            textBox14.Visible = false;

            cbSubjectTeacher.Visible = true;
            cbGenderTeacher.Visible = true;
            txtNameTeacher.ReadOnly = false;
            txtDateOfBirthTeacher.ReadOnly = false;
            txtAndressTeacher.ReadOnly = false;
            txtMail.ReadOnly = false;
            MonHocDAL dal = new MonHocDAL();
            DataTable dt = dal.getAllSubject();

            cbSubjectTeacher.DisplayMember = "ten_mon_hoc";
            cbSubjectTeacher.ValueMember = "ma_mh";
            cbSubjectTeacher.DataSource = dt;
        }

        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox13.Visible = true;
            textBox14.Visible = true;
            cbSubjectTeacher.Visible = false;
            cbGenderTeacher.Visible = false;

            txtNameTeacher.ReadOnly = true;
            txtDateOfBirthTeacher.ReadOnly = true;
            txtAndressTeacher.ReadOnly = true;
            txtMail.ReadOnly = true;
            if (e.RowIndex >= 0)
            {
                // Lấy ra dòng được click
                DataGridViewRow row = dgvGiaoVien.Rows[e.RowIndex];
                //Lấy ra id và lưu nó lại
                idSelectedTeacher = row.Cells["ma_gv"].Value.ToString();
                txtNameTeacher.Text = row.Cells["ho_ten"].Value.ToString();
                txtDateOfBirthTeacher.Text = row.Cells["ngay_sinh"].Value.ToString();
                textBox13.Text = row.Cells["mon_hoc"].Value.ToString();
               
                bool b = (bool)row.Cells["gioi_tinh"].Value;
                if (b == true)
                {
                    textBox14.Text = "Nam";
                }
                else
                {
                    textBox14.Text = "Nữ";
                }
                txtAndressTeacher.Text =row.Cells["dia_chi"].Value.ToString();
                txtMail.Text =row.Cells["email"].Value.ToString();
            }
        }

        //Xóa giáo viên , đầu tiên phải xóa tài khoản
        private void button2_Click(object sender, EventArgs e)
        {
            GiaoVienDAL dal = new GiaoVienDAL();
            if (!idSelectedTeacher.Equals(""))
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa giáo viên này không(Y?N)", "Cánh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TaiKhoanDAL tk = new TaiKhoanDAL();
                    tk.deleteAccountByMaGV(idSelectedTeacher);//Xóa tài khoản trước
                    dal.deleteTeacher(idSelectedTeacher);//Xóa giáo viên
                }
            }
        }

        private void btmSeacrhTeacher_Click(object sender, EventArgs e)
        {
            loadTeacher();
        }

        private void CbSearchSubJect_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTeacher();
        }

        private void btnSaveTeacher_Click(object sender, EventArgs e)
        {
             GiaoVienDAL dal = new GiaoVienDAL();
             bool isMale = true;
             if (cbGenderTeacher.SelectedItem.ToString() == "Nữ")
             {
                isMale = false;
             }
             MonHoc m = new MonHoc(cbSubjectTeacher.SelectedValue.ToString(), cbSubjectTeacher.SelectedItem.ToString());
             GiaoVien gv = new GiaoVien(idSelectedTeacher, m, txtNameTeacher.Text, isMale, txtDateOfBirthTeacher.Text, txtAndressTeacher.Text, txtMail.Text);
             if (dal.AddGiaoVien(gv))
             {
                 MessageBox.Show("Bạn đã cập nhật thành công một giáo viên!");
             }
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAccount.Rows[e.RowIndex];

                textBox8.Text = row.Cells["ma_gv_account"].Value.ToString();
                textBox10.Text = row.Cells["ho_ten_account"].Value.ToString();
                textBox12.Text = row.Cells["ten_dang_nhap"].Value.ToString();
                textBox9.Text = row.Cells["loai_tai_khoan"].Value.ToString();
                textBox11.Text = row.Cells["mat_khau"].Value.ToString();
            }
        }

        //Chỉ cho phép sửa đổi mật khẩu.
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            textBox11.ReadOnly = false;
            textBox11.Focus();
        }

        private void btnSaveAccount_Click(object sender, EventArgs e)
        {
            if(textBox11.Text != null && !textBox11.Text.Equals(""))
            {
                label46.Visible = false;
                TaiKhoanDAL dal = new TaiKhoanDAL();
                if(dal.updateAccount(textBox11.Text, textBox12.Text))
                {
                    textBox11.ReadOnly = true ;
                    MessageBox.Show("Cập nhật mật khẩu thành công!");
                }
            }
            else
            {
                label46.Visible = true;
            }
        }

        //Xóa tài khoản
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            TaiKhoanDAL dal = new TaiKhoanDAL();
            if(MessageBox.Show("Bạn có chắn chắn muốn xóa tài khoản này không(Y/N)?", "Cánh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                dal.deleteAccount(textBox12.Text);
            }
            loadAccount();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPoint();
        }


        private void button9_Click(object sender, EventArgs e)
        {
            textBox3.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChiTietDiemDAL dal = new ChiTietDiemDAL();
               if( MessageBox.Show("Bạn có chắn chắn muốn xóa không?", "Cánh báo",MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dal.deletePoint(idSelectedPoint);
                    loadPoint();
                }
            
        }

        private void dgvPoint_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox6.ReadOnly = true;
            if (e.RowIndex >= 0)
            {
                // Lấy ra dòng được click
                DataGridViewRow row = dgvPoint.Rows[e.RowIndex];

                idSelectedPoint = Convert.ToInt32(row.Cells["id_ctd"].Value);
                textBox4.Text = row.Cells["ho_ten_point"].Value.ToString();
                textBox3.Text = (String)row.Cells["diem15"].Value.ToString();
                textBox2.Text = (String)row.Cells["diem45"].Value.ToString();
                textBox6.Text = (String)row.Cells["hocky"].Value.ToString();
                textBox7.Text = (String)row.Cells["mon_hoc_point"].Value.ToString();
                textBox5.Text = (String)row.Cells["diemtb"].Value.ToString();
            }
        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPoint();
        }
        
        bool checkPoint()
        {
            if (textBox2.Text == null || textBox2.Text.Equals(""))
                return false;
            if (textBox3.Text == null || textBox3.Text.Equals(""))
                return false;
            return true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (checkPoint())
            {
                ChiTietDiemDAL dal = new ChiTietDiemDAL();
                float diem15 = (float)Convert.ToDouble(textBox2.Text);
                float diem45 = (float)Convert.ToDouble(textBox3.Text);
                float diemtb = (float)(diem15 + diem45) / 2;
                ChiTietDiem c = new ChiTietDiem(idSelectedPoint, diem15, diem45, 0,null,null, diemtb);
                if (dal.updatePoint(c))
                {
                    MessageBox.Show("Cập nhật điểm thành công!");
                    textBox3.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    loadPoint();
                }
                
            }
        }
    }
    }


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLHS.dal;

namespace QLHS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void loadClass()
        {
            LopDAL lopDAL = new LopDAL();
            DataTable dt = lopDAL.getAllClass();

            cbClassStudent.DisplayMember = "ten_lop";
            cbClassStudent.ValueMember = "id_lop";
            cbClassStudent.DataSource = dt;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            //label2.Text = FrmDangNhap.ho_ten;
            loadClass();
            loadStudent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn thoát không (Y/N)?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvSinhVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSinhVien.Columns[e.ColumnIndex].Name == "Column8")
            {
                if(e.Value != null)
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
            if (e.RowIndex >= 0)
            {
                // Lấy ra dòng được click
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

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
    }
}

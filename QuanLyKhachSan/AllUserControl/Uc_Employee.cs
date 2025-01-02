using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.AllUserControl
{
    public partial class Uc_Employee : UserControl
    {
        ConnectSql connectSql = new ConnectSql();
        String query;
        public Uc_Employee()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Uc_Employee_Load(object sender, EventArgs e)
        {
            getMaxID();
        }

        // ===========================================

        public void getMaxID()
        {
            query = "select max(MANV) from NHANVIEN";
            DataSet ds = connectSql.GetData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSet.Text = (num + 1).ToString();
            }
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtSDT.Text != "" && txtGioiTinh.Text != "" && txtEmail.Text != "" && txtUserName.Text != "" && txtPass.Text != "")
            {
                String name = txtName.Text;
                Int64 sdt = Int64.Parse(txtSDT.Text);
                String gioitinh = txtGioiTinh.Text;
                String email = txtEmail.Text;
                String userName = txtUserName.Text;
                String password = txtPass.Text;

                query = "insert into NHANVIEN (TENNV, SDT, GIOITINH, EMAIL, TAIKHOAN, MATKHAU) " + "values (N'" + name + "', " + sdt + ", N'" + gioitinh + "', N'" + email + "', N'" + userName + "', N'" + password + "')";
                connectSql.setData(query, "Đăng ký nhân viên thành công.");

                clearAll();
                getMaxID();
            }
        }

        public void clearAll()
        {
            txtName.Clear();
            txtSDT.Clear();
            txtGioiTinh.SelectedIndex = -1;
            txtEmail.Clear();
            txtUserName.Clear();
            txtPass.Clear();
        }

        private void tabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabEmployee.SelectedIndex == 1)
            {
                setEmployee(guna2DataGridView1);
            }
            else if(tabEmployee.SelectedIndex == 2)
            {
                setEmployee(guna2DataGridView2);
            }
        }

        public void setEmployee(DataGridView dgv)
        {
            query = "select * from NHANVIEN";
            DataSet ds = connectSql.GetData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from NHANVIEN where MANV = " + txtID.Text + "";
                    connectSql.setData(query, "Thông tin nhân viên đã được xóa.");
                    tabEmployee_SelectedIndexChanged(this, null);
                }
            }
        }

        private void Uc_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}

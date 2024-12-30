using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyKhachSan.AllUserControl
{
    public partial class Uc_Checkout : UserControl
    {
        ConnectSql connectSql = new ConnectSql();
        String query;
        public Uc_Checkout()
        {
            InitializeComponent();
        }

        private void Uc_Checkout_Load(object sender, EventArgs e)
        {
            query = "select KHACHHANG.MAKH, KHACHHANG.TENKH, KHACHHANG.SDT, KHACHHANG.QUOCTICH, KHACHHANG.GIOITINH, KHACHHANG.NGAYSINH, KHACHHANG.CHUNGMINH, KHACHHANG.DIACHI, KHACHHANG.CHECKIN, PHONG.SOPHONG, PHONG.LOAIPHONG, PHONG.GIUONG, PHONG.GIA from KHACHHANG inner join PHONG on KHACHHANG.MAPHONG = PHONG.MAPHONG where DACHECKOUT = 'KHONG'";
            DataSet ds = connectSql.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select KHACHHANG.MAKH, KHACHHANG.TENKH, KHACHHANG.SDT, KHACHHANG.QUOCTICH, KHACHHANG.GIOITINH, KHACHHANG.NGAYSINH, KHACHHANG.CHUNGMINH, KHACHHANG.DIACHI, KHACHHANG.CHECKIN, PHONG.SOPHONG, PHONG.LOAIPHONG, PHONG.GIUONG, PHONG.GIA from KHACHHANG inner join PHONG on KHACHHANG.MAPHONG = PHONG.MAPHONG where TENKH like N'" + txtName.Text + "%' and DACHECKOUT = 'KHONG'";
            DataSet ds = connectSql.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCname.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoom.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
             if(txtCname.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn không?", "Xác Nhận", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK) ;
                {
                    String cdate = txtCheckOutDay.Text;
                    query = "UPDATE KHACHHANG SET DACHECKOUT = 'CO', CHECKOUT = '" + cdate + "' WHERE MAKH = " + id + "; " +
                            "UPDATE PHONG SET DADAT = 'KHONG' WHERE SOPHONG = '" + txtRoom.Text + "';";
                    connectSql.setData(query, "Thanh toán thành công.");
                    Uc_Checkout_Load(this, null);
                    clearAll();
                } 
            } else
            {
                MessageBox.Show("Không có khách hàng để lựa chọn!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtCname.Clear();
            txtRoom.Clear();
            txtName.Clear();
            txtCheckOutDay.ResetText();
        }

        private void Uc_Checkout_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}

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
    public partial class Uc_CustomerDetails : UserControl
    {
        ConnectSql connectSql = new ConnectSql();
        String query;
        public Uc_CustomerDetails()
        {
            InitializeComponent();
        }

        private void txtTimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTimkiem.SelectedIndex == 0)
            {
                query = "select KHACHHANG.MAKH, KHACHHANG.TENKH, KHACHHANG.SDT, KHACHHANG.QUOCTICH, KHACHHANG.GIOITINH, KHACHHANG.NGAYSINH, KHACHHANG.CHUNGMINH, KHACHHANG.DIACHI, KHACHHANG.CHECKIN, PHONG.SOPHONG, PHONG.LOAIPHONG, PHONG.GIUONG, PHONG.GIA from KHACHHANG inner join PHONG on KHACHHANG.MAPHONG = PHONG.MAPHONG";
                 getRecord(query);
            } 
            else if (txtTimkiem.SelectedIndex == 1)
            {
                query = "select KHACHHANG.MAKH, KHACHHANG.TENKH, KHACHHANG.SDT, KHACHHANG.QUOCTICH, KHACHHANG.GIOITINH, KHACHHANG.NGAYSINH, KHACHHANG.CHUNGMINH, KHACHHANG.DIACHI, KHACHHANG.CHECKIN, PHONG.SOPHONG, PHONG.LOAIPHONG, PHONG.GIUONG, PHONG.GIA from KHACHHANG inner join PHONG on KHACHHANG.MAPHONG = PHONG.MAPHONG where CHECKOUT is null";
                getRecord(query);
            }
            else if ( txtTimkiem.SelectedIndex == 2)
            {
                query = "select KHACHHANG.MAKH, KHACHHANG.TENKH, KHACHHANG.SDT, KHACHHANG.QUOCTICH, KHACHHANG.GIOITINH, KHACHHANG.NGAYSINH, KHACHHANG.CHUNGMINH, KHACHHANG.DIACHI, KHACHHANG.CHECKIN, PHONG.SOPHONG, PHONG.LOAIPHONG, PHONG.GIUONG, PHONG.GIA from KHACHHANG inner join PHONG on KHACHHANG.MAPHONG = PHONG.MAPHONG where CHECKOUT is not null";
                getRecord(query);
            }
        }

        private void getRecord(String query)
        {
            DataSet ds = connectSql.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}

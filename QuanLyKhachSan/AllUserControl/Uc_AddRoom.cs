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
    public partial class Uc_AddRoom : UserControl
    {
        ConnectSql connectSql = new ConnectSql();
        String query;
        public Uc_AddRoom()
        {
            InitializeComponent();
        }

        private void Uc_AddRoom_Load(object sender, EventArgs e)
        {
            query = "select * from PHONG";
            DataSet ds = connectSql.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if(txtRoomNum.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                String roomNum = txtRoomNum.Text;
                String roomType = txtRoomType.Text;
                String  bed = txtBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text);

                query = "insert into PHONG (SOPHONG,LOAIPHONG,GIUONG,GIA) values (N'"+ roomNum +"', N'"+ roomType +"', N'"+ bed +"', N'"+ price +"')";
                connectSql.setData(query, "Đã thêm phòng!");

                Uc_AddRoom_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Xin vui lòng điền đầy đủ thông tin!","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        public void clearAll()
        {
            txtRoomNum.Clear();
            txtRoomType.SelectedIndex = -1; // giá trị mặc định để biểu thị trạng thái không hợp lệ hoặc không có mục nào được chọn.
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void Uc_AddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void Uc_AddRoom_Enter(object sender, EventArgs e)
        {
            Uc_AddRoom_Load(this,null);
        }
    }
}

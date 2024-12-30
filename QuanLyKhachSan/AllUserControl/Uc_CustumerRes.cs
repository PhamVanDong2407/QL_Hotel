using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyKhachSan.AllUserControl
{

    public partial class Uc_CustumerRes : UserControl
    {
        ConnectSql connectSql = new ConnectSql();
        String query;
        public Uc_CustumerRes()
        {
            InitializeComponent();
        }

        public void setComboBox(String query, ComboBox combo)
        {
            SqlDataReader sdr = connectSql.getForCombo(query);
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void Uc_CustumerRes_Load(object sender, EventArgs e)
        {

        }

        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomType.SelectedIndex = -1;
            txtRoomNum.Items.Clear();
            txtPrice.Clear();
        }

        private void txtRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomNum.Items.Clear();
            query = "select SOPHONG from PHONG where GIUONG = N'" + txtBed.Text + "' and LOAIPHONG = N'" + txtRoomType.Text + "' and DADAT = 'KHONG'";
            setComboBox(query, txtRoomNum);
        }

        int rid;
        private void txtRoomNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select GIA, MAPHONG from PHONG where SOPHONG = '" + txtRoomNum.Text + "'";
            DataSet ds = connectSql.GetData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtContact.Text != "" && txtNationality.Text != "" && txtGender.Text != "" && txtDob.Text != "" && txtCCCD.Text != "" && txtDiaChi.Text != "" && txtCheckin.Text != "" && txtPrice.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtContact.Text);
                String national = txtNationality.Text;
                String gender = txtGender.Text;
                String dob = txtDob.Text;
                String CCCD = txtCCCD.Text;
                String diachi = txtDiaChi.Text;
                String checkin = txtCheckin.Text;

                string query = "INSERT INTO KHACHHANG (TENKH, SDT, QUOCTICH, GIOITINH, NGAYSINH, CHUNGMINH, DIACHI, CHECKIN, MAPHONG) VALUES (N'"
                               + name + "', "
                               + mobile + ", N'"
                               + national + "', N'"
                               + gender + "', N'"
                               + dob + "', N'"
                               + CCCD + "', N'"
                               + diachi + "', N'"
                               + checkin + "', N'"
                               + rid + "); "
                               + "UPDATE PHONG SET DADAT = 'CO' WHERE SOPHONG = '"
                               + txtRoomNum.Text + "';";
                connectSql.setData(query, "Số phòng " + txtRoomNum.Text + " đăng ký khách hàng thành công!");
                clearAll();

            }
            else
            {
                MessageBox.Show("Xin vui lòng điền đầy đủ thông tin!", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtName.Clear();
            txtContact.Clear();
            txtNationality.Clear();
            txtGender.SelectedIndex = -1;
            txtDob.ResetText();
            txtCCCD.Clear();
            txtDiaChi.Clear();
            txtCheckin.ResetText();
            txtBed.SelectedIndex = -1;
            txtRoomType.SelectedIndex = -1;
            txtRoomNum.Items.Clear();
            txtPrice.Clear();
        }

        private void Uc_CustumerRes_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}

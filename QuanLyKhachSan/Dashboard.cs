using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uc_AddRoom1.Visible = false;
            uc_CustumerRes1.Visible = false;
            uc_Checkout1.Visible = false;
            uc_CustomerDetails1.Visible = false;
            btnAddRoom.PerformClick();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnAddRoom.Left + 50;
            uc_AddRoom1.Visible = true;
            uc_AddRoom1.BringToFront();
        }

        private void btnCustomerRes_Click(object sender, EventArgs e)
        {
            PanelMoving.Left=btnCustomerRes.Left + 70; 
            uc_CustumerRes1.Visible = true;
            uc_CustumerRes1.BringToFront();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCheckOut.Left + 70;
            uc_Checkout1.Visible = true;
            uc_Checkout1.BringToFront();
        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCustomerDetails.Left + 70;
            uc_CustomerDetails1.Visible = true;
            uc_CustomerDetails1.BringToFront();
        }
    }
}

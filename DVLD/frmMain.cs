using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DVLD.Helpers;
using DVLD.Login;
using DVLD.People;
using DVLD.People.Controls;
using DVLD.Users;

namespace DVLD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();
            frm.Show();
        }

        private void ApplyTheme()
        {
            // Form
            this.BackColor = AppColors.PanelBg;
            pictureBox1.BackColor = AppColors.PanelBg;


            // MenuStrip
            msMainMenue.BackColor = AppColors.NavyDark;
            msMainMenue.ForeColor = AppColors.TextLight;


            //ToolStripDropDownItem
            currentUserInfoToolStripMenuItem.BackColor = AppColors.NavyDark;
            currentUserInfoToolStripMenuItem.ForeColor = AppColors.TextLight;

            changePasswordToolStripMenuItem.BackColor = AppColors.NavyDark;
            changePasswordToolStripMenuItem.ForeColor = AppColors.TextLight;

            signOutToolStripMenuItem.BackColor = AppColors.NavyDark;
            signOutToolStripMenuItem.ForeColor = AppColors.TextLight;

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo(clsGlobal.CurrentUser.UserID, true);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            this.Hide();
            frmLoginScreen frm = new frmLoginScreen();
            frm.ShowDialog();
            this.Close();

        }

        private void smiPeople_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();
            frm.ShowDialog();
        }

        private void smiUsers_Click(object sender, EventArgs e)
        {
            frmUsersList frm = new frmUsersList();
            frm.ShowDialog();
        }
    }
}

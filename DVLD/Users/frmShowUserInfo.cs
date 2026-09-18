using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Helpers;

namespace DVLD.Users
{
    public partial class frmShowUserInfo : Form
    {
        public frmShowUserInfo(int ID,bool IsUserID)
        {
            InitializeComponent();
            _ApplyTheme();
            if(IsUserID)
            ctrlUserCard1.LoadUserInfo(ID);
            else
            ctrlUserCard1.LoadUserInfoByPersonID(ID);
        }

        private void _ApplyTheme()
        {
            this.BackColor = AppColors.PanelBg;
            btnClose.BackColor = AppColors.NavyPrimary;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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

namespace DVLD.Licenses.Local_Licenses
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        private void _ApplyTheme()
        {
            // Form
            this.BackColor = AppColors.PanelBg;
            // Buttons
            btnClose.BackColor = AppColors.NavyPrimary;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.ForeColor = Color.White;

            btnIssue.BackColor = AppColors.NavyPrimary;
            btnIssue.FlatStyle = FlatStyle.Flat;
            btnIssue.FlatAppearance.BorderSize = 0;
            btnIssue.ForeColor = Color.White;
        }
        private int _LocalDrivingLicenseApplicationID;
       
        public frmIssueDriverLicenseFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _ApplyTheme();
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(true)
            {

            }
        }
    }
}

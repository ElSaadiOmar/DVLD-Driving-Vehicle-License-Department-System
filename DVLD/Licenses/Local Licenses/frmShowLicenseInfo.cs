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
    public partial class frmShowLicenseInfo : Form
    {
        private int _LiecenseID;
        public frmShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LiecenseID = LicenseID;
        }
        private void _ApplyTheme()
        {
            this.BackColor = AppColors.PanelBg;
            lblTitle.ForeColor = AppColors.NavyDark;
            btnClose.ForeColor = Color.White;
            btnClose.BackColor = AppColors.NavyPrimary;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
        }

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            _ApplyTheme();
            ctrlDriverLicenseInfo1.LoadLicenseInfo(_LiecenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
using DVLD_Buisness;

namespace DVLD.Users
{
    public partial class frmAddAndUpdateUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _UserID = -1;
        clsUser _User;

        public frmAddAndUpdateUser()
        {
            InitializeComponent();
            _Mode= enMode.AddNew;
        }
        public frmAddAndUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;
        }

        private void frmAddAndUpdateUser_Load(object sender, EventArgs e)
        {
            _ApplyTheme();
        }
        private void _ApplyTheme()
        {
            // Form
            this.BackColor = AppColors.PanelBg;

            lblTitle.ForeColor = AppColors.NavyDark;
            tpPersonalInfo.BackColor = AppColors.PanelBg;
            tpLoginInfo.BackColor = AppColors.PanelBg;
            //Buttons
            btnPersonInfoNext.BackColor = AppColors.NavyPrimary;
            btnPersonInfoNext.ForeColor = Color.White;
            btnPersonInfoNext.FlatStyle = FlatStyle.Flat;
            btnPersonInfoNext.FlatAppearance.BorderSize = 0;

            btnClose.BackColor = AppColors.NavyPrimary;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            btnSave.BackColor = AppColors.NavyPrimary;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
        }

        private void txtRequiredFeild_Validating(object sender, CancelEventArgs e)
        {
            TextBox Field = (TextBox)sender;
            if (string.IsNullOrEmpty(Field.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(Field, "This field is required");
            }
            else
            {
                errorProvider1.SetError(Field, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {

        }
    }
}

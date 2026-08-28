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

namespace DVLD.Login
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
            
        }
        private void ApplyTheme()
        {
            // Form
            this.BackColor = AppColors.PanelBg;
            lblTitle.ForeColor = AppColors.NavyDark;

            btnClose.BackColor = AppColors.NavyPrimary;
            btnClose.ForeColor = Color.White;
            btnLogin.ForeColor = Color.White;
            btnLogin.BackColor = AppColors.NavyPrimary;



        }
        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            string storedUsername = string.Empty;
            string storedPassword = string.Empty;
            if (clsGlobal.GetStoredCredential(ref storedUsername, ref storedPassword))
            {
                txtUserName.Text = storedUsername;
                txtPassword.Text = storedPassword;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.Find(txtUserName.Text, txtPassword.Text);
            if (User != null)
            {
                if (User.IsActive)
                {
                    clsGlobal.CurrentUser = User;
                    if(chkRememberMe.Checked) {
                        clsGlobal.RememberUsernameAndPassword(txtUserName.Text, txtPassword.Text);
                    }
                    else
                    {
                        clsGlobal.RememberUsernameAndPassword("", "");
                    }
                    this.Hide();
                    frmMain mainForm = new frmMain();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your account is inactive. Please contact the administrator.", "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}

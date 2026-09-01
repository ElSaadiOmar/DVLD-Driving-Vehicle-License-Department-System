using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;

namespace DVLD.Users
{
    public partial class ctrlUserCard : UserControl
    {
        private clsUser _User;
        public ctrlUserCard()
        {
            InitializeComponent();
        }
        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.Find(UserID);
            if(_User ==null)
            {
                ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _FillUserInfo();
        }
        public void LoadUserInfoByPersonID(int PersonID)
        {
            _User = clsUser.FindByPersonID(PersonID);
            if (_User == null)
            {
                ResetUserInfo();
                MessageBox.Show("No User with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _FillUserInfo();
        }
        public void ResetUserInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();
            lblUserID.Text = "???";
            lblUserName.Text = "???";
            lblIsActive.Text = "???";
        }
        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName;
            lblIsActive.Text = _User.IsActive ? "Yes" : "No";
        }

     
    }
}

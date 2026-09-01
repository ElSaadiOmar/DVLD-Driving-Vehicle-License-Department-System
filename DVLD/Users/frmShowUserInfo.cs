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
            this.BackColor = AppColors.PanelBg;
            if(IsUserID)
            ctrlUserCard1.LoadUserInfo(ID);
            else
            ctrlUserCard1.LoadUserInfoByPersonID(ID);
        }
    }
}

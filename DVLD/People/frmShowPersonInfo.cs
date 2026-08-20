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
using DVLD.People.Controls;

namespace DVLD
{
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            ApplyTheme();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }
        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            ApplyTheme();
            ctrlPersonCard1.LoadPersonInfo(NationalNo);
        }
        private void ApplyTheme()
        {
            // Form
            this.BackColor = AppColors.PanelBg;
            label1.ForeColor = AppColors.NavyDark;

        }
     

    }
}

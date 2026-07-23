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
using DVLD.People;
using DVLD.People.Controls;

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
            menuStrip1.BackColor = AppColors.NavyDark;
            menuStrip1.ForeColor = AppColors.TextLight;
        }
     }
}

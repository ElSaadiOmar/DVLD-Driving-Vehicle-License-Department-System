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

namespace DVLD.Applications.Application_Types
{
    public partial class frmListApplicationTypes : Form
    {
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }
        private void _ApplyTheme()
        {
            // Form
            this.BackColor = AppColors.PanelBg;
            lblTitle.ForeColor = AppColors.NavyDark;

            btnClose.BackColor = AppColors.NavyPrimary;
            btnClose.ForeColor = Color.White;

            cmApplicationTypesMenu.BackColor = AppColors.NavyPrimary;
            cmApplicationTypesMenu.ForeColor = Color.White;
        }

        private void _RefreshApplicationTypesList()
        {
            dgvApplicationType.DataSource = clsApplicationType.GetAllApplicationType();

            dgvApplicationType.Columns[0].HeaderText = "ID";
            dgvApplicationType.Columns[0].Width = 107;
            dgvApplicationType.Columns[1].HeaderText = "Title";
            dgvApplicationType.Columns[1].Width = 350;
            dgvApplicationType.Columns[2].HeaderText = "Fees";
            dgvApplicationType.Columns[2].Width = 150;
        }
        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _ApplyTheme();
            _RefreshApplicationTypesList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dgvApplicationType.SelectedRows[0].Cells[0].Value);
            frm.OnApplicationTypeEdited += _RefreshApplicationTypesList;
            frm.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dgvApplicationType.SelectedRows[0].Cells[0].Value);
            frm.OnApplicationTypeEdited += _RefreshApplicationTypesList;
            frm.ShowDialog();
        }
    }
}

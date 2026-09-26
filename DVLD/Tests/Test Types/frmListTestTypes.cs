using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DVLD.Applications.Application_Types;
using DVLD.Helpers;
using DVLD_Buisness;

namespace DVLD.Tests.Test_Types
{
    public partial class frmListTestTypes : Form
    {
        public frmListTestTypes()
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

        private void _RefreshTestTypesList()
        {
            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();
            if(dgvTestTypes.Columns.Count >= 4)
            {
                dgvTestTypes.Columns[0].HeaderText = "ID";
                dgvTestTypes.Columns[0].Width = 50;
                dgvTestTypes.Columns[1].HeaderText = "Title";
                dgvTestTypes.Columns[1].Width = 155;
                dgvTestTypes.Columns[2].HeaderText = "Description";
                dgvTestTypes.Columns[2].Width = 377;
                dgvTestTypes.Columns[3].HeaderText = "Fees";
                dgvTestTypes.Columns[3].Width = 130;
            }
        }
    
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _ApplyTheme();
            _RefreshTestTypesList();
        }

        private void cmiEditTest_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((int)dgvTestTypes.SelectedRows[0].Cells[0].Value);
            frm.OnTestTypeEdited += _RefreshTestTypesList;
            frm.ShowDialog();
        }

        private void dgvTestTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((int)dgvTestTypes.SelectedRows[0].Cells[0].Value);
            frm.OnTestTypeEdited += _RefreshTestTypesList;
            frm.ShowDialog();
        }
    }
}

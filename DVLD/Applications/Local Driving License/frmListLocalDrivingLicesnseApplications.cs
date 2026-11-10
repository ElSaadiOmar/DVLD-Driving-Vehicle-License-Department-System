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
using DVLD.Licenses.Local_Licenses;
using DVLD.Tests;
using DVLD_Buisness;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmListLocalDrivingLicesnseApplications : Form
    {
        public frmListLocalDrivingLicesnseApplications()
        {
            InitializeComponent();
        }

        private DataTable _dtAllLocalDrivingLicenseApplications;
        private void _ApplyTheme()
        {
            // Form
            this.BackColor = AppColors.PanelBg;

            // Context Menu Strip
            cmsApplications.BackColor = AppColors.PanelBg;
            cmsApplications.ForeColor = Color.Black;

            scheduleStreetTestToolStripMenuItem.BackColor = AppColors.PanelBg;
            scheduleStreetTestToolStripMenuItem.ForeColor = Color.Black;
            scheduleVisionTestToolStripMenuItem.BackColor = AppColors.PanelBg;
            scheduleVisionTestToolStripMenuItem.ForeColor = Color.Black;
            scheduleWrittenTestToolStripMenuItem.BackColor = AppColors.PanelBg;
            scheduleWrittenTestToolStripMenuItem.ForeColor = Color.Black;

            lblTitle.ForeColor = AppColors.NavyDark;

            //GridView
            dgvLocalDrivingLicenseApplications.BackgroundColor = Color.White;
            dgvLocalDrivingLicenseApplications.GridColor = AppColors.GridRowAlt;

            //button
            btnAddNewLocalDrivingLicenseApplication.BackColor = AppColors.NavyPrimary;
            btnAddNewLocalDrivingLicenseApplication.FlatStyle = FlatStyle.Flat;
            btnAddNewLocalDrivingLicenseApplication.FlatAppearance.BorderSize = 0;

            btnClose.BackColor = AppColors.NavyPrimary;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

        }

        private void frmListLocalDrivingLicesnseApplications_Load(object sender, EventArgs e)
        {
            _ApplyTheme();
            _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLocalDrivingLicenseApplications.DataSource = _dtAllLocalDrivingLicenseApplications;
            lblRecords.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;
            if (dgvLocalDrivingLicenseApplications.Columns.Count > 0)
            {
                //_ConfigureGridColumns();
                dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplications.Columns[0].Width = 100;
                dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplications.Columns[1].Width = 230;
                dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No.";
                dgvLocalDrivingLicenseApplications.Columns[2].Width = 120;
                dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplications.Columns[3].Width = 310;
                dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplications.Columns[4].Width = 142;
                dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplications.Columns[5].Width = 85;
                dgvLocalDrivingLicenseApplications.Columns[6].HeaderText = "Status";
                dgvLocalDrivingLicenseApplications.Columns[6].Width = 85;
            }
        }

        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication();
            frm.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }
        private void dgvLocalDrivingLicenseApplications_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvLocalDrivingLicenseApplications.ClearSelection();
                dgvLocalDrivingLicenseApplications.CurrentCell =
                    dgvLocalDrivingLicenseApplications.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvLocalDrivingLicenseApplications.Rows[e.RowIndex].Selected = true;
                cmsApplications.Show(Cursor.Position);
            }
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            if (dgvLocalDrivingLicenseApplications.Rows.Count <= 0)
            {
                e.Cancel = true;
                return;
            }
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            int TotalPassedTests = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;
            bool LicenseExists = localDrivingLicenseApplication.IsLicenseIssued();

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;
            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            DeleteApplicationToolStripMenuItem.Enabled = !LicenseExists;
            editToolStripMenuItem.Enabled = (TotalPassedTests != 3) && !LicenseExists;
            CancelApplicaitonToolStripMenuItem.Enabled = !LicenseExists;
            ScheduleTestsMenue.Enabled = (TotalPassedTests != 3);
            switch (TotalPassedTests.ToString())
            {
                case "0":
                    scheduleVisionTestToolStripMenuItem.Enabled = true;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    break;
                case "1":
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = true;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    break;
                case "2":
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = true;
                    break;
                default:
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    break;
            }
          
            switch (localDrivingLicenseApplication.StatusText)
            {
                case "Cancelled":
                    showDetailsToolStripMenuItem.Enabled = true;
                    editToolStripMenuItem.Enabled = false;
                    DeleteApplicationToolStripMenuItem.Enabled = false;
                    CancelApplicaitonToolStripMenuItem.Enabled = false;
                    ScheduleTestsMenue.Enabled = false;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;//
                    showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
                    break;
                case "Completed":
                    showDetailsToolStripMenuItem.Enabled = true;
                    editToolStripMenuItem.Enabled = false;
                    DeleteApplicationToolStripMenuItem.Enabled = false;
                    CancelApplicaitonToolStripMenuItem.Enabled = false;
                    ScheduleTestsMenue.Enabled = false;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = true;
                    showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListLocalDrivingLicesnseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CancelApplicaitonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            clsLocalDrivingLicenseApplication  LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListLocalDrivingLicesnseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not cancel application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDriverLicenseFirstTime frm = new frmIssueDriverLicenseFirstTime((int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells[0].Value);
            frm.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //not implemented yet
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //not implemented yet
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestAppointments frm = new frmListTestAppointments((int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value,
                clsTestType.enTestType.VisionTest);
            frm.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestAppointments frm = new frmListTestAppointments((int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value,
                clsTestType.enTestType.WrittenTest);
            frm.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestAppointments frm = new frmListTestAppointments((int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value,
                clsTestType.enTestType.StreetTest);
            frm.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Always allow backspace and other control keys
            if (char.IsControl(e.KeyChar))
                return;

            switch (cbFilterBy.Text)
            {
                case "L.D.L.AppID":
                    e.Handled = !char.IsDigit(e.KeyChar);
                    break;

                case "Full Name":
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == ' ');
                    break;

                case "National No.":
                default:
                    // Allow everything
                    break;
            }
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text == "None")
            {
                txtFilterValue.Text = "";
                txtFilterValue.Visible = false;
                return;
            }
            if(cbFilterBy.Text== "Status")
            {
                txtFilterValue.Text = "";
                txtFilterValue.Visible = false;
                cbStatus.Visible = true;
                cbStatus.SelectedIndex = 0;
                return;
            }
            txtFilterValue.Visible = true;
            txtFilterValue.Text = "";
            txtFilterValue.Focus();

            
        }
        private void _Filter(string FilterBy, string FilterText)
        {
            if (FilterText == "" || FilterBy == "None")
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                lblRecords.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }
            if (int.TryParse(FilterText, out int Result))
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("CONVERT({0}, System.String) LIKE '{1}%'", FilterBy, Result);
            }
            else if (!string.IsNullOrEmpty(FilterText))
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterBy, FilterText.Trim());
            }
            else
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
            }
            lblRecords.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string filterValue = txtFilterValue.Text.Trim();
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {

                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }
            
            if(_dtAllLocalDrivingLicenseApplications.Rows.Count == 0)
            {
                return;
            }
            _Filter(FilterColumn, filterValue);
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbStatus.Text)
            {
                case "All":
                    _Filter("Status", "");
                    break;
                case "New":
                    _Filter("Status", "New");
                    break;
                case "Completed":
                    _Filter("Status", "Completed");
                    break;
                case "Cancelled":
                    _Filter("Status", "Cancelled");
                    break;
            }
        }
    }
}

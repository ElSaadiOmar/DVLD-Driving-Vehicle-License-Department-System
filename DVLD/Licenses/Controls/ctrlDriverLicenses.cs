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
using DVLD.Licenses.Local_Licenses;
using DVLD_Buisness;

namespace DVLD.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID { get; set; }
        private clsDriver _Driver {  get; set; }
        private DataTable _dtDriverLocalLicensesHistory {  get; set; }
        private DataTable _dtDriverInternationalLicensesHistory { get; set; }

        public Color tpInternationalLicenses_BackColor 
        {
            set
            {
                tpInternationalLicenses.BackColor = value;
            }
        }
        public Color tpLocalLicenses_BackColor
        {
            set
            {
                tpLocalLicenses.BackColor = value;
            }
        }
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }
        private void _LoadLocalLicensesInfo()
        {
            _dtDriverLocalLicensesHistory = clsDriver.GetDriverLocalLicenses(_DriverID);
            dgvLocalDriverLicenses.DataSource = _dtDriverLocalLicensesHistory;
            lblLocalDriverLicensesRecords.Text = dgvLocalDriverLicenses.Rows.Count.ToString();
            if (dgvLocalDriverLicenses.Columns.Count > 0 && dgvLocalDriverLicenses.Rows.Count > 0)
            {
                dgvLocalDriverLicenses.Columns[0].HeaderText = "Lic.ID";
                dgvLocalDriverLicenses.Columns[0].Width = 110;
                
                dgvLocalDriverLicenses.Columns[1].HeaderText = "App.ID";
                dgvLocalDriverLicenses.Columns[1].Width = 110;
                
                dgvLocalDriverLicenses.Columns[2].HeaderText = "Class Name";
                dgvLocalDriverLicenses.Columns[2].Width = 270;
                
                dgvLocalDriverLicenses.Columns[3].HeaderText = "Issue Date";
                dgvLocalDriverLicenses.Columns[3].Width = 170;
                
                dgvLocalDriverLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvLocalDriverLicenses.Columns[4].Width = 170;
                
                dgvLocalDriverLicenses.Columns[5].HeaderText = "Is Active";
                dgvLocalDriverLicenses.Columns[5].Width = 110;

            }
        }
        private void _LoadInternationalLicensesInfo()
        {
            _dtDriverInternationalLicensesHistory = clsDriver.GetDriverInternationalLicenses(_DriverID);
            dgvInternationalDriverLicenses.DataSource = _dtDriverInternationalLicensesHistory;
            lblInternationalDriverLicensesRecords.Text = _dtDriverInternationalLicensesHistory.Rows.Count.ToString();
            if (dgvInternationalDriverLicenses.Columns.Count > 0 && dgvInternationalDriverLicenses.Rows.Count > 0)
            {
                dgvInternationalDriverLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalDriverLicenses.Columns[0].Width = 160;
                
                dgvInternationalDriverLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalDriverLicenses.Columns[1].Width = 130;
                
                dgvInternationalDriverLicenses.Columns[2].HeaderText = "L.License ID";
                dgvInternationalDriverLicenses.Columns[2].Width = 130;
                
                dgvInternationalDriverLicenses.Columns[3].HeaderText = "Issue Date";
                dgvInternationalDriverLicenses.Columns[3].Width = 180;
                
                dgvInternationalDriverLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalDriverLicenses.Columns[4].Width = 180;
                
                dgvInternationalDriverLicenses.Columns[5].HeaderText = "Is Active";
                dgvInternationalDriverLicenses.Columns[5].Width = 120;

            }
        }
        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDriver.FindByDriverID(DriverID);
            _LoadLocalLicensesInfo();
            _LoadInternationalLicensesInfo();
        }
        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);
            if (_Driver != null)
            {
                _DriverID = _Driver.DriverID;
            }
            _LoadLocalLicensesInfo();
            _LoadInternationalLicensesInfo();
        }
        
        private void InternationalLicenseHistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //not emplement 
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dgvLocalDriverLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }

        private void cmsLicenseHistory_Opening(object sender, CancelEventArgs e)
        {
            var Menu = (ContextMenuStrip)sender;
            var GridView = (DataGridView)Menu.SourceControl;
            e.Cancel = GridView.Rows.Count == 0;
        }
    }
}

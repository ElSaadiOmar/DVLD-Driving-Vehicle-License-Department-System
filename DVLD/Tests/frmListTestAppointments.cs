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
using DVLD.Properties;
using DVLD_Buisness;

namespace DVLD.Tests
{
    public partial class frmListTestAppointments : Form
    {
        private DataTable _dtLicenseTestAppointments;
        private int _LocalDrivingLicenseApplicationID;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;
        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
        }
        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestType.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.vision_test_512;
                        cmsApplications.Items[1].Image = Resources.vision_test_32;
                        break;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.writing_test_512;
                        cmsApplications.Items[1].Image = Resources.writing_test_32;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Street_test_512;
                        cmsApplications.Items[1].Image = Resources.Street_test_32;
                        break;
                    }
            }
        }
        private void _ApplyTheme()
        {
            this.BackColor = AppColors.PanelBg;
            lblTitle.ForeColor = AppColors.NavyDark;
            btnClose.BackColor = AppColors.NavyPrimary;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
        }
        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _ApplyTheme();
            _LoadTestTypeImageAndTitle();
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            _dtLicenseTestAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID,_TestType);

            lblRecords.Text = _dtLicenseTestAppointments.Rows.Count.ToString();
            dgvTestAppointmentsList.DataSource = _dtLicenseTestAppointments;
            if (dgvTestAppointmentsList.Columns.Count > 0)
            {
                dgvTestAppointmentsList.Columns[0].HeaderText = "Appointment ID";
                dgvTestAppointmentsList.Columns[0].Width = 160;

                dgvTestAppointmentsList.Columns[1].HeaderText = "Appointment Date";
                dgvTestAppointmentsList.Columns[1].Width = 200;

                dgvTestAppointmentsList.Columns[2].HeaderText = "Paid Fees";
                dgvTestAppointmentsList.Columns[2].Width = 160;

                dgvTestAppointmentsList.Columns[3].HeaderText = "Is Locked";
                dgvTestAppointmentsList.Columns[3].Width = 90;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAppoinment_Click(object sender, EventArgs e)
        {
            if(clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID,_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(clsLocalDrivingLicenseApplication.DoesPassTestType(_LocalDrivingLicenseApplicationID,_TestType))
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, (int)dgvTestAppointmentsList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            if (dgvTestAppointmentsList.Rows.Count <= 0)
            {
                e.Cancel = true;
                return;
            }
           
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frm = new frmTakeTest((int)dgvTestAppointmentsList.CurrentRow.Cells[0].Value, _TestType);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);

        }
    }
}

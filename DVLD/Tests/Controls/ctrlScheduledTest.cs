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

namespace DVLD.Tests.Controls
{
    public partial class ctrlScheduledTest : UserControl
    {
        private int _TestAppointmentID = -1;
        private int _TestID = -1;
        public int TestAppointmentID { get {  return _TestAppointmentID; }  }
        public int TestID { get {  return _TestID; }  }
        private clsTestAppointment _TestAppointmentInfo { get; set; }
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        {
                            lblTitle.Text = "Vision Test";
                            this.Text = lblTitle.Text;
                            pbTestTypeImage.Image = Properties.Resources.vision_test_512;
                            break;
                        }
                    case clsTestType.enTestType.WrittenTest:
                        {
                            lblTitle.Text = "Written Test";
                            this.Text = lblTitle.Text;
                            pbTestTypeImage.Image = Properties.Resources.writing_test_512;
                            break;
                        }
                    case clsTestType.enTestType.StreetTest:
                        {
                            lblTitle.Text = "Street Test";
                            this.Text = lblTitle.Text;
                            pbTestTypeImage.Image = Properties.Resources.Street_test_512;
                            break;
                        }
                }
            }
        }
        
        public ctrlScheduledTest()
        {
            InitializeComponent();
        }
        public void LoadInfo(int AppointmentID)
        {
            _TestAppointmentID = AppointmentID;
            _TestAppointmentInfo = clsTestAppointment.FindByAppointmentID(_TestAppointmentID);
            if(_TestAppointmentInfo==null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }
            
            _TestID = _TestAppointmentInfo.TestID;
            if(_TestAppointmentInfo.LocalDrivingLicenseApplicationInfo ==null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _TestAppointmentInfo.LocalDrivingLicenseApplicationID.ToString(),
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblLocalDrivingLicenseApplicationID.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationID.ToString();
            lblClassName.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationInfo.LicenseClassInfo.ClassName;
            lblAplicantName.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationInfo.ApplicantFullName;
            lblFees.Text = _TestAppointmentInfo.PaidFees.ToString();
            lblTrail.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationInfo.TotalTrialsPerTest(TestTypeID).ToString();
            lblDate.Text = _TestAppointmentInfo.AppointmentDate.ToShortDateString().ToString();
            lblTestID.Text = _TestID != -1 ? _TestID.ToString() : "Not Taken Yet";
        }
    }
}

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

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {
        int _TestID { get; set; }
        private clsTest _Test;
        private clsTestType.enTestType _TestTypeID { get; set; }
        private int _AppointmentID { get; set; }
        public frmTakeTest(int AppointmentID, clsTestType.enTestType TestTypeID)
        { 
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _TestTypeID = TestTypeID;
        }
        private void _ApplyThem()
        {
            this.BackColor = AppColors.PanelBg;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _ApplyThem();
            ctrlScheduledTest1.TestTypeID = _TestTypeID;
            ctrlScheduledTest1.LoadInfo(_AppointmentID);
            btnSave.Enabled = ctrlScheduledTest1.TestAppointmentID != -1;
            _TestID = ctrlScheduledTest1.TestID;
            if (_TestID != -1) 
            {
                _Test =clsTest.FindByTestID(_TestID);
                if (_Test.TestResult) 
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;
                txtNotes.Text = _Test.Notes;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
                txtNotes.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                _Test=new clsTest();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _Test.TestAppointmentID = _AppointmentID;
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text;
            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }
    }
}

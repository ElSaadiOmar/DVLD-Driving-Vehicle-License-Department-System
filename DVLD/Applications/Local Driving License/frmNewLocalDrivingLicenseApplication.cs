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

namespace DVLD.Applications
{
    public partial class frmNewLocalDrivingLicenseApplication : Form
    {
        public frmNewLocalDrivingLicenseApplication()
        {
            InitializeComponent(); 
            _Mode = enMode.AddNew;
        }
        public frmNewLocalDrivingLicenseApplication(int ID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = ID;
        }
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }
        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillLicenseClassesInComoboBox();
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonCardWithFilter1.FilterFocus();
                tpLDLApplicationInfo.Enabled = false;

                lblLocalDrivingLicebseApplicationID.Text = "[???]";
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();
                lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tpLDLApplicationInfo.Enabled = true;
                btnSave.Enabled = true;

            }
           

        }

        private void _LoadData()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(_LocalDrivingLicenseApplication.LicenseClassInfo.ClassName);
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedByUser.Text = clsUser.Find(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);

        }
        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ApplyTheme();
            _ResetDefualtValues();
            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }
        

        private void _ApplyTheme()
        {
            // Form
            this.BackColor = AppColors.PanelBg;
            lblTitle.ForeColor = AppColors.NavyDark;
            tpPersonalInfo.BackColor = AppColors.PanelBg;
            tpLDLApplicationInfo.BackColor = AppColors.PanelBg;
            //Buttons
            btnPersonInfoNext.BackColor = AppColors.NavyPrimary;
            btnPersonInfoNext.ForeColor = Color.White;
            btnPersonInfoNext.FlatStyle = FlatStyle.Flat;
            btnPersonInfoNext.FlatAppearance.BorderSize = 0;

            btnClose.BackColor = AppColors.NavyPrimary;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            btnSave.BackColor = AppColors.NavyPrimary;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
        }
        
        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLDLApplicationInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLDLApplicationInfo"];
                return;
            }
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                
                    btnSave.Enabled = true;
                    tpLDLApplicationInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLDLApplicationInfo"];
                    return;
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();

            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int LicenseClassID = clsLicenseClass.FindByName(cbLicenseClass.Text).LicenseClassID;

            clsApplication application = clsApplication.FindByApplicantPersonIDAndLicenseClassID(ctrlPersonCardWithFilter1.PersonID, LicenseClassID);
            if (application != null)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + application.ApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }
            
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
            _LocalDrivingLicenseApplication.CreatedByUserID = clsUser.FindByUserName(lblCreatedByUser.Text).UserID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now; 
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewDrivingLicense;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);

            if (_LocalDrivingLicenseApplication.Save())
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                
                tpLDLApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
                lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
                _Mode = enMode.Update;
                ctrlPersonCardWithFilter1.FilterEnabled = false;
               
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

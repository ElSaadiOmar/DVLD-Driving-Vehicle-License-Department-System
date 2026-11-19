using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;

namespace DVLD.Licenses.Local_Licenses
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public int LicenseID { get; private set; }
        public clsLicense SelectedLicenseInfo { get; private set; }
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }
        public void ResetLicenseInfo()
        {
            lblClass.Text = "[???]";
            lblFullName.Text = "[????]";
            lblLicenseID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGender.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblIssueReason.Text = "[????]";
            lblNotes.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblExpirationDate.Text = "[????]";
            lblIsDetained.Text = "[????]";
            pbPersonImage.Image = Properties.Resources.Male_512;
        }
        private void _FillLicenseInfo()
        {
            LicenseID = SelectedLicenseInfo.LicenseID;
            lblClass.Text = SelectedLicenseInfo.LicenseClassInfo.ClassName;
            lblFullName.Text = SelectedLicenseInfo.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = SelectedLicenseInfo.LicenseID.ToString();
            lblNationalNo.Text = SelectedLicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lblIssueDate.Text = SelectedLicenseInfo.IssueDate.ToString("dd/MM/yyyy");
            lblIssueReason.Text = SelectedLicenseInfo.IssueReasonText;
            lblNotes.Text = SelectedLicenseInfo.Notes;
            lblIsActive.Text = SelectedLicenseInfo.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = SelectedLicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MM/yyyy");
            lblDriverID.Text = SelectedLicenseInfo.DriverID.ToString();
            lblExpirationDate.Text = SelectedLicenseInfo.ExpirationDate.ToString("dd/MM/yyyy");
            lblIsDetained.Text =  "No";//for now
            if(SelectedLicenseInfo.DriverInfo.PersonInfo.Gender.ToString() == "Male")
            {
                pbGendor.Image = Properties.Resources.Man_32;
                pbPersonImage.Image = Properties.Resources.Male_512;
                lblGender.Text = "Male";
            }
            else
            {
                pbGendor.Image = Properties.Resources.Woman_32;
                pbPersonImage.Image = Properties.Resources.Female_512;
                lblGender.Text = "Female";
            }
            _LoadImage(SelectedLicenseInfo.DriverInfo.PersonInfo.ImagePath);
            
        }
        public void LoadLicenseInfo(int LicenseID)
        {
            SelectedLicenseInfo = clsLicense.Find(LicenseID);
            if (SelectedLicenseInfo == null)
            {
                ResetLicenseInfo();
                MessageBox.Show($"License With this LicenseID [{LicenseID}] was not exist", "License not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLicenseInfo();
        }

        private void _LoadImage(string ImagePath)
        {
            if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
            {
                try { pbPersonImage.ImageLocation = ImagePath; }
                catch
                {
                    MessageBox.Show("your Image cant open", "Invalid Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

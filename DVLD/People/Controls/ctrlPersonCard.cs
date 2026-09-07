using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Properties;
using DVLD_Buisness;
using TheArtOfDevHtmlRenderer.Adapters;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;

        private int _PersonID = -1;
        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        { 
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No _Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No _Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }


        public void _FillPersonInfo()
        {
                _PersonID = _Person.PersonID;
                lblPersonID.Text = _Person.PersonID.ToString();
                lblFullName.Text = _Person.FullName;
                lblNationalNo.Text = _Person.NationalNo;
                lblEmail.Text = _Person.Email;
                lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
                lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
                lblAddress.Text = _Person.Address.ToString();
                lblPhone.Text = _Person.Phone;
                switch (_Person.Gender)
                {
                    case clsPerson.enGender.Male:
                        {
                            pbGender.Image = Resources.Man_32;
                            lblGender.Text = "Male";
                            pbPersonImage.Image = Properties.Resources.Male_512;
                            break;
                        }
                    case clsPerson.enGender.Female:
                    {
                        pbGender.Image = Resources.Woman_32;
                        lblGender.Text = "Female";
                            pbPersonImage.Image = Properties.Resources.Female_512;
                            break;
                        }
                }
                _LoadImage(_Person.ImagePath);

        }
        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            pbGender.Image = Resources.Man_32;
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;

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
        
        private void lnkEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(int.TryParse(lblPersonID.Text,out int ID))
            {
                frmAddAndUpdatePerson frm = new frmAddAndUpdatePerson(ID);
                frm.ShowDialog();
                LoadPersonInfo(ID);
            }
            else
            {
                MessageBox.Show("You must has Person to Edit", "Person not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

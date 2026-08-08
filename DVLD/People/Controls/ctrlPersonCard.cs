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
using DVLD_Buisness;
using TheArtOfDevHtmlRenderer.Adapters;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        public void FillTheCardWithPersonInfo(int PersonID)
        {

            clsPerson Person = clsPerson.Find(PersonID);
            if (Person != null)
            {
                lblPersonID.Text = Person.PersonID.ToString();
                lblName.Text = Person.GetFullName();
                lblNationalNo.Text = Person.NationalNo;
                lblEmail.Text = Person.Email;
                lblCountry.Text = clsCountry.Find(Person.NationalityCountryID).CountryName;
                lblDateOfBirth.Text = Person.DateOfBirth.ToString();
                lblAddress.Text = Person.Address.ToString();
                lblPhone.Text = Person.Phone;
                switch (Person.Gender)
                {
                    case clsPerson.enGender.Male:
                        {
                            lblGender.Text = "Male";
                            pbPersonImage.Image = Properties.Resources.Male_512;
                            break;
                        }
                    case clsPerson.enGender.Female:
                        {
                            lblGender.Text = "Female";
                            pbPersonImage.Image = Properties.Resources.Female_512;
                            break;
                        }
                }
                _ChangeImage(Person.ImagePath);
            }

        }
        public void FillTheCardWithPersonInfo(string NationalNo)
        {

            clsPerson Person = clsPerson.Find(NationalNo);
            if (Person != null)
            {
                lblPersonID.Text = Person.PersonID.ToString();
                lblName.Text = Person.GetFullName();
                lblNationalNo.Text = Person.NationalNo;
                lblEmail.Text = Person.Email;
                lblCountry.Text = clsCountry.Find(Person.NationalityCountryID).CountryName;
                lblDateOfBirth.Text = Person.DateOfBirth.ToString();
                lblAddress.Text = Person.Address.ToString();
                lblPhone.Text = Person.Phone;
                switch (Person.Gender)
                {
                    case clsPerson.enGender.Male:
                        {
                            lblGender.Text = "Male";
                            pbPersonImage.Image = Properties.Resources.Male_512;
                            break;
                        }
                    case clsPerson.enGender.Female:
                        {
                            lblGender.Text = "Female";
                            pbPersonImage.Image = Properties.Resources.Female_512;
                            break;
                        }
                }
                _ChangeImage(Person.ImagePath);
            }

        }
        private void _ChangeImage(string ImagePath)
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
                FillTheCardWithPersonInfo(ID);
            }
            else
            {
                MessageBox.Show("You must has Person to Edit", "Person not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

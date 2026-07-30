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
                            break;
                        }
                    case clsPerson.enGender.Female:
                        {
                            lblGender.Text = "Female";
                            break;
                        }
                }
                if (!string.IsNullOrEmpty(Person.ImagePath))
                {
                    // pictureBox1.ImageLocation = Person.ImagePath;
                }
                else
                {
                    //pictureBox1.Image = null;
                }
            }

        }

        private void lnkEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddAndUpdatePerson frm = new frmAddAndUpdatePerson(int.Parse(lblPersonID.Text));
            frm.ShowDialog();
            FillTheCardWithPersonInfo(int.Parse(lblPersonID.Text));
        }
    }
}

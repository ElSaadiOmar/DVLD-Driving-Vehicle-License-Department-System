using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using DVLD.Helpers;
using DVLD_Buisness;

namespace DVLD.People
{
    public partial class frmAddAndUpdatePerson : Form
    {
        private clsPerson _Person;

        private Dictionary<string, PropertyInfo> _MapPropertiesWithControl;


        List<Control> _lstControls;


        public frmAddAndUpdatePerson()
        {
            InitializeComponent();
            lblTitle.Text = "Add New Person";
            _Person = new clsPerson();
        }
        public frmAddAndUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Person = clsPerson.Find(PersonID);
            _FillAllField(_Person);
            lblTitle.Text = "Update Person";
        }

        private void frmAddAndUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            _ApplyTheme();
            _InitializeMapPropertiesWithControl();
            _InitializeValidationControls();
        }

        private void _ResetDefaultValues()
        {
            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
            cbCountry.DataSource = clsCountry.GetAllCountries();
            cbCountry.SelectedValueChanged += cbCountry_SelectedValueChanged;
            if (_Person.NationalityCountryID == -1)
            {
                cbCountry.SelectedIndex = cbCountry.FindString("Algeria");
            }
            else
            {
                cbCountry.SelectedValue = _Person.NationalityCountryID;
            }

            if (_Person.Gender == clsPerson.enGender.Female) rbFemale.Checked = true;
            else rbMale.Checked = true;
        }

        private void _ApplyTheme()
        {
            // Form
            this.BackColor = AppColors.PanelBg;
            lblTitle.ForeColor = AppColors.NavyDark;

            btnClose.BackColor = AppColors.NavyPrimary;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            btnSave.BackColor = AppColors.NavyPrimary;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
        }

        private void _InitializeValidationControls()
        {
            _lstControls = new List<Control>
            {
                txtNationalNo,
                txtFirstName,
                txtSecondName,
                txtThirdName,
                txtLastName,
                txtPhone,
                txtEmail,
                txtAddress,
             };
        }
        private void _InitializeMapPropertiesWithControl()
        {
            Type PersonType = typeof(clsPerson);
            _MapPropertiesWithControl = new Dictionary<string, PropertyInfo>
            {
                { "txtNationalNo", PersonType.GetProperty("NationalNo") },
                { "txtFirstName", PersonType.GetProperty("FirstName") } ,
                { "txtSecondName" , PersonType.GetProperty("SecondName") },
                { "txtThirdName", PersonType.GetProperty("ThirdName") },
                { "txtLastName", PersonType.GetProperty("LastName") },
                { "txtPhone" , PersonType.GetProperty("Phone") },
                { "txtEmail" , PersonType.GetProperty("Email") },
                { "txtAddress" , PersonType.GetProperty("Address") }
            };
        }

        private void _LettersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                errorProvider1.SetError((Control)sender, "You can enter only letter!!");
                e.Handled = true;
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void _DigitOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                errorProvider1.SetError((Control)sender, "You can enter only Number!!");
                e.Handled = true;
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void _RequiredField_Validating(object Field, CancelEventArgs e)
        {

            TextBox txt = (TextBox)Field;
            if (string.IsNullOrEmpty(txt.Text))
            {
                errorProvider1.SetError((Control)Field, "This field is required");
            }
            else
            {
                errorProvider1.SetError((Control)Field, "");
            }
        }

        private bool _TextIsOnlyLetters(string Text)
        {
            foreach (char c in Text)
            {
                if (!char.IsLetter(c) && !char.IsControl(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private void _LettersOnly_Validating(object sender, CancelEventArgs e)
        {
            _RequiredField_Validating(sender, e);
            TextBox txt = (TextBox)sender;
            if (!_TextIsOnlyLetters(txt.Text))
            {
                errorProvider1.SetError((Control)sender, "This Field Accept Only Letter");
                e.Cancel = true;
            }


        }

        private bool _TextIsOnlyDigit(string Text)
        {
            foreach (char c in Text)
            {
                if (!char.IsDigit(c) && !char.IsControl(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void _DigitesOnly_Validating(object sender, CancelEventArgs e)
        {
            _RequiredField_Validating(sender, e);
            TextBox txt = (TextBox)sender;
            if (!_TextIsOnlyDigit(txt.Text))
            {
                errorProvider1.SetError((Control)sender, "This Field Accept Only Number");
                e.Cancel = true;
            }


        }
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            _RequiredField_Validating(sender, e);
            if (clsPerson.IsPersonExist(txtNationalNo.Text) && txtNationalNo.Text != _Person.NationalNo)
            {
                errorProvider1.SetError(txtNationalNo, "Person with this NationalNo are exist");
                e.Cancel = true;
            }

        }


        private bool _AllFieldesAreRight()
        {
            if(ValidateChildren())
            {
                foreach (Control Ctrl in _lstControls)
                {   Ctrl.Focus();
                    if (!string.IsNullOrEmpty(errorProvider1.GetError(Ctrl)))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false ;
        }

        private void _FillAllField(clsPerson Person)
        {
            if (Person == null) return;
            lblPersonID.Text = Person.PersonID.ToString() ?? "N/A";
            txtFirstName.Text = Person.FirstName;
            txtSecondName.Text = Person.SecondName;
            txtThirdName.Text = Person.ThirdName;
            txtLastName.Text = Person.LastName;
            txtNationalNo.Text = Person.NationalNo;
            txtEmail.Text = Person.Email ?? string.Empty;
            txtPhone.Text = Person.Phone;
            dtDateOfBirth.Text = Person.DateOfBirth.ToString();
            cbCountry.SelectedValue = Person.NationalityCountryID;
            txtAddress.Text = Person.Address;
            switch (Person.Gender)
            {
                case clsPerson.enGender.Male:
                    {
                        rbMale.Checked = true;
                        break;
                    }
                case clsPerson.enGender.Female:
                    {
                        rbFemale.Checked = true;
                        break;
                    }
            }
            _ChangeImage();
        }
        private void _ChangeImage()
        {
            if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                try { pbPersonImage.ImageLocation = _Person.ImagePath;
                    llblRemoveImage.Visible = true;
                }
                catch
                {
                    _ChangeImageBasedGender();
                    MessageBox.Show("your Image cant open", "Invalid Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _ChangeImageBasedGender();
            }
        }
        private void _ChangeImageBasedGender()
        {
            if (rbFemale.Checked)
            {
                pbPersonImage.Image = Properties.Resources.Female_512;
            }
            else
            {
                pbPersonImage.Image = Properties.Resources.Male_512;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _HandelPersonImage()
        {
            if(_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if(!string.IsNullOrEmpty(_Person.ImagePath))
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch(IOException IO)
                    {

                    }
                }
                if(pbPersonImage.ImageLocation != null)
                {
                    string ImageSource = pbPersonImage.ImageLocation.ToString();
                    if(clsUtil.CopyImageToProjectImagesFolder(ref ImageSource))
                    {
                        pbPersonImage.ImageLocation = ImageSource;
                        _Person.ImagePath = ImageSource;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (_AllFieldesAreRight())//Validation is true
            {
                if(_HandelPersonImage())
                {
                    if (_Person.Save())
                    {
                        lblTitle.Text = "Update Person";

                        MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        lblPersonID.Text = _Person.PersonID.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Save is faild", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You are have invalid Image", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You are have invalid field", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox_Validated(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if (_MapPropertiesWithControl.TryGetValue(c.Name, out PropertyInfo propInfo))
            {
                object convertedValue = Convert.ChangeType(c.Text, propInfo.PropertyType);
                propInfo.SetValue(_Person, convertedValue);
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError((Control)sender, "");
                return;
            }
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                errorProvider1.SetError((Control)sender, "Invalid Email");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError((Control)sender, "");
            }
        }

        private void rbGender_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                _Person.Gender = clsPerson.enGender.Male;
                _ChangeImage();
            }
            else if (rbFemale.Checked)
            {

                _Person.Gender = clsPerson.enGender.Female;
                _ChangeImage();
            }

        }

        private void dtDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            _Person.DateOfBirth = dtDateOfBirth.Value;
        }

        private void cbCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbCountry.SelectedValue is int selectedCountryID)
            {
                _Person.NationalityCountryID = selectedCountryID;
                errorProvider1.SetError(cbCountry, "");
            }
            else
            {
                errorProvider1.SetError(cbCountry, "Selected country does not exist.");
            }
        }

        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\elssa\Pictures";
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.Title = "Chose Image";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ImagePath = openFileDialog1.FileName;
                pbPersonImage.Load(ImagePath);
                llblRemoveImage.Visible = true;
            }
        }

        private void llblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            _ChangeImageBasedGender();
            llblRemoveImage.Visible = false;
        }

        private void txtThirdName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtThirdName.Text))
            {
                errorProvider1.SetError((Control)sender, "");
                return;
            }
            TextBox txt = (TextBox)sender;
            if (!_TextIsOnlyLetters(txt.Text))
            {
                errorProvider1.SetError((Control)sender, "This Field Accept Only Letter");
                e.Cancel = true;
            }
        }
    }
}

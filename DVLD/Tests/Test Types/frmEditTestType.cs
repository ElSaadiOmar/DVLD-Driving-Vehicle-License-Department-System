using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Helpers;
using DVLD_Buisness;

namespace DVLD.Tests.Test_Types
{
    public partial class frmEditTestType : Form
    {
        public frmEditTestType(int TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }
        public Action OnTestTypeEdited;

        // Eventsprotected
        protected virtual void TestTypeEdited()
        {
            Action handler = OnTestTypeEdited;
            if (handler != null)
            {
                handler(); // Raise the event with the parameter
            }
        }
        private int _TestTypeID;
        private string _TestTypeTitle;
        private string _TestTypeDescription;
        private float _TestTypeFees;
        private clsTestType _TestType;
      
        private void _ApplyTheme()
        {
            // Form
            this.BackColor = AppColors.PanelBg;
            lblTitle.ForeColor = AppColors.NavyDark;

            btnClose.BackColor = AppColors.NavyPrimary;
            btnClose.ForeColor = Color.White;

            btnSave.BackColor = AppColors.NavyPrimary;
            btnSave.ForeColor = Color.White;
        }

        private void _ResetDefualtValues()
        {
            lblID.Text = "???";
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtFee.Text = "";
        }
        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _ApplyTheme();
            _ResetDefualtValues();
            _TestType = clsTestType.Find((clsTestType.enTestType)_TestTypeID);
            if (_TestType == null)
            {
                this.Close();
                MessageBox.Show("No Test Type with TestTypeID = " + _TestTypeID, "Test Type Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            lblID.Text = _TestType.TestTypeID.ToString();
            txtTitle.Text = _TestType.TestTypeTitle.ToString();
            txtDescription.Text = _TestType.TestTypeDescription.ToString();
            txtFee.Text = _TestType.TestTypeFees.ToString();
            _TestTypeTitle = _TestType.TestTypeTitle;
            _TestTypeDescription = _TestType.TestTypeDescription;
            _TestTypeFees = _TestType.TestTypeFees;
          
        }

        private void txtFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                errorProvider1.SetError(txtFee, "Please enter a valid number.");
                e.Handled = true;
            }
            else
            {
                errorProvider1.SetError(txtFee, "");
            }
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z\s,.{}()\[\]'""!?]+$"))
            {
                errorProvider1.SetError(txtTitle, "Please enter a valid character.");
                e.Handled = true;
            }
            else
            {
                errorProvider1.SetError(txtTitle, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorProvider1.SetError(txtTitle, "Title cannot be empty.");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtTitle.Text, @"^[a-zA-Z\s,.{}()\[\]'""!?]+$"))        
            {
                errorProvider1.SetError(txtTitle, "Please enter a valid title.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
        }

        private void txtFee_Validating(object sender, CancelEventArgs e)
        {
            if (!float.TryParse(txtFee.Text, out float fee))
            {
                errorProvider1.SetError(txtFee, "Please enter a valid number.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtFee, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                _TestType.TestTypeTitle = txtTitle.Text;
                _TestType.TestTypeDescription = txtDescription.Text;
                _TestType.TestTypeFees = float.Parse(txtFee.Text);
                if (_TestType.TestTypeTitle != _TestTypeTitle || _TestType.TestTypeFees != _TestTypeFees || _TestType.TestTypeDescription != _TestTypeDescription)
                {
                    if (_TestType.Save())
                    {
                        MessageBox.Show("Test Type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TestTypeEdited(); // Raise the event to notify subscribers)
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update Test Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errorProvider1.SetError(txtDescription, "Description cannot be empty.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
        }

        
    }
}

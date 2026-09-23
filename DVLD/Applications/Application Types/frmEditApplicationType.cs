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

namespace DVLD.Applications.Application_Types
{
    public partial class frmEditApplicationType : Form
    {
        private int _ApplicationTypeID;
        private clsApplicationType _ApplicationType;
        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }

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
            txtFee.Text = "";
        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _ApplyTheme();
            _ResetDefualtValues();
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);
            if (_ApplicationType == null)
            {
                this.Close();
                MessageBox.Show("No Application Type with ApplicationTypeID = " + _ApplicationTypeID, "Application Type Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  return;
            }
            lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
            txtTitle.Text = _ApplicationType.ApplicationTypeTitle.ToString();
            txtFee.Text = _ApplicationType.ApplicationFees.ToString();
        }

        private void txtFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
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
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
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
            if(!Regex.IsMatch(txtTitle.Text, @"^[a-zA-Z\s]+$"))
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
            if(!float.TryParse(txtFee.Text, out float fee))
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
            if(this.ValidateChildren())
            {
                _ApplicationType.ApplicationTypeTitle = txtTitle.Text;
                _ApplicationType.ApplicationFees = float.Parse(txtFee.Text);
                if (_ApplicationType.Save())
                {
                    MessageBox.Show("Application Type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update Application Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

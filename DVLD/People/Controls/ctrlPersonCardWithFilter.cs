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

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            _ApplyThem();
            cbSearchBy.SelectedIndex = 0;
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
            TextBox txt = (TextBox)sender;
            if (!_TextIsOnlyDigit(txt.Text))
            {
                errorProvider1.SetError((Control)sender, "This Field Accept Only Number");
                e.Cancel = true;
            }


        }


        private void _ApplyThem()
        {
            this.BackColor = AppColors.PanelBg;
            btnAddNewPerson.BackColor = AppColors.NavyPrimary;
            btnSearch.BackColor = AppColors.NavyPrimary;
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePerson frm = new frmAddAndUpdatePerson();
            frm.ShowDialog();
        }

        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchValue.Text = string.Empty;

        }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchBy.SelectedItem.ToString() == "Person ID")
            {
                _DigitOnly_KeyPress(sender, e);
            }
        }

        private void txtSearchValue_Validating(object sender, CancelEventArgs e)
        {
            if (cbSearchBy.SelectedItem.ToString() == "Person ID")
            {
                _DigitesOnly_Validating(sender, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cbSearchBy.SelectedItem.ToString())
            {
                case "Person ID":
                    {
                        if (int.TryParse(txtSearchValue.Text, out int ID))
                        {
                            if (clsPerson.IsPersonExist(ID))
                            {
                                ctrlPersonCard1.FillTheCardWithPersonInfo(ID);
                            }
                            else
                            {
                                MessageBox.Show($"Person With this PersonID [{ID}] was not exist","Person not found",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"this PersonID is Invalid", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                case "National No":
                    {
                        if (clsPerson.IsPersonExist(txtSearchValue.Text.ToString()))
                        {
                            ctrlPersonCard1.FillTheCardWithPersonInfo(txtSearchValue.Text.ToString());
                        }
                        else
                        {
                            MessageBox.Show($"Person With this National No [{txtSearchValue.Text.ToString()}] was not exist", "Person not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
            }
        }
    }
}

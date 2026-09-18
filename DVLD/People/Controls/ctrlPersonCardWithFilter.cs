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
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            _ApplyThem();
            cbSearchBy.SelectedIndex = 0;
        }


        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCard1.SelectedPersonInfo; }
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
            frm.DataBack += DataBack;
            frm.ShowDialog();
        }

        private void DataBack(object sender,int PersonID)
        {
            cbSearchBy.SelectedIndex = 0;
            txtSearchValue.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbSearchBy.SelectedIndex = 1;
            txtSearchValue.Text = PersonID.ToString();
            FindNow();

        }
        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchValue.Text = string.Empty;
            txtSearchValue.Focus();
            errorProvider1.SetError(txtSearchValue, null);

        }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchBy.Text == "Person ID")
            {
                _DigitOnly_KeyPress(sender, e);
            }
        }

        private void txtSearchValue_Validating(object sender, CancelEventArgs e)
        {
            if (cbSearchBy.Text == "Person ID")
            {
                _DigitesOnly_Validating(sender, e);
            }
        }
        public void FilterFocus()
        {
            txtSearchValue.Focus();
        }
        private void FindNow()
        {
            switch (cbSearchBy.Text)
            {
                case "Person ID":
                    {
                        if (int.TryParse(txtSearchValue.Text, out int ID))
                        {
                            ctrlPersonCard1.LoadPersonInfo(ID);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Person ID. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                case "National No":
                    {
                        ctrlPersonCard1.LoadPersonInfo(txtSearchValue.Text.ToString());

                        break;
                    }
            }
            if (OnPersonSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnPersonSelected(ctrlPersonCard1.PersonID);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            FindNow();
        }
    }
}

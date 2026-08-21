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
using DVLD.People.Controls;
using DVLD_Buisness;

namespace DVLD.People
{
    public partial class frmListPeople : Form
    {
        private DataTable _dtAllPeople;

        private DataTable _dtPeople;
        public frmListPeople()
        {
            InitializeComponent(); 
        }

        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false,  "PersonID","NationalNo",
                                                         "FirstName", "SecondName", "ThirdName", "LastName",
                                                         "Gender", "DateOfBirth", "CountryName",
                                                         "Phone", "Email");
            dgvPeopleList.DataSource = _dtPeople;
        }
        private void ApplyTheme()
        {
            // Form
            this.BackColor = AppColors.PanelBg;
            cmPersonMenu.BackColor = AppColors.NavyPrimary;
            cmPersonMenu.ForeColor = Color.White;
           
            //GridView

            dgvPeopleList.BackgroundColor = Color.White;
            dgvPeopleList.GridColor = AppColors.GridRowAlt;
            //button

            btnAddNewPerson.BackColor = AppColors.NavyPrimary;
            btnAddNewPerson.FlatStyle = FlatStyle.Flat;
            btnAddNewPerson.FlatAppearance.BorderSize = 0;

            btnClose.BackColor = AppColors.NavyPrimary;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

        }
       

        private void frmMangePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            ApplyTheme();
            cbFilterBy.SelectedIndex = 0;

            if (dgvPeopleList.Rows.Count > 0)
            {

                dgvPeopleList.Columns[0].HeaderText = "Person ID";
                dgvPeopleList.Columns[0].Width = 110;

                dgvPeopleList.Columns[1].HeaderText = "National No.";
                dgvPeopleList.Columns[1].Width = 120;


                dgvPeopleList.Columns[2].HeaderText = "First Name";
                dgvPeopleList.Columns[2].Width = 120;

                dgvPeopleList.Columns[3].HeaderText = "Second Name";
                dgvPeopleList.Columns[3].Width = 140;


                dgvPeopleList.Columns[4].HeaderText = "Third Name";
                dgvPeopleList.Columns[4].Width = 120;

                dgvPeopleList.Columns[5].HeaderText = "Last Name";
                dgvPeopleList.Columns[5].Width = 120;

                dgvPeopleList.Columns[6].HeaderText = "Date Of Birth";
                dgvPeopleList.Columns[6].Width = 120;

                dgvPeopleList.Columns[7].HeaderText = "Gender";
                dgvPeopleList.Columns[7].Width = 140;

                dgvPeopleList.Columns[8].HeaderText = "Nationality";
                dgvPeopleList.Columns[8].Width = 120;


                dgvPeopleList.Columns[9].HeaderText = "Phone";
                dgvPeopleList.Columns[9].Width = 120;


                dgvPeopleList.Columns[10].HeaderText = "Email";
                dgvPeopleList.Columns[10].Width = 170;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePerson frm = new frmAddAndUpdatePerson();
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void dgvPeopleList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvPeopleList.ClearSelection();
                dgvPeopleList.Rows[e.RowIndex].Selected = true;
                cmPersonMenu.Show(Cursor.Position);
            }
        }

        private void tsmshowDetails_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvPeopleList.SelectedRows[0].Cells["PersonID"].Value;
            frmShowPersonInfo frm = new frmShowPersonInfo(ID);
            frm.ShowDialog();
        }

        private void tsmaddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePerson frm = new frmAddAndUpdatePerson();
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void tsmedit_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvPeopleList.SelectedRows[0].Cells["PersonID"].Value;
            frmAddAndUpdatePerson frm = new frmAddAndUpdatePerson(ID);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void tsmdelete_Click(object sender, EventArgs e)
        {
            
                int ID = (int)dgvPeopleList.SelectedRows[0].Cells["PersonID"].Value;
                DialogResult result = MessageBox.Show($"Are you sure you want delete person [{ID.ToString()}]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(result ==DialogResult.OK)
                {
                    if(clsPerson.Delete(ID))
                    {
                        MessageBox.Show("Person Deleted Successfully","Successful",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _RefreshPeopleList();
                }
                    else
                    {
                        MessageBox.Show("Person was not Deleted because it has data linked to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
          
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
            TextBox txt = (TextBox)sender;
            if (!_TextIsOnlyDigit(txt.Text))
            {
                errorProvider1.SetError((Control)sender, "This Field Accept Only Number");
                e.Cancel = true;
            }


        }
    
        private void _CleanField(TextBox Field)
        {
            Field.Text = string.Empty;
            Field.KeyPress -= _DigitOnly_KeyPress;
            Field.KeyPress -= _LettersOnly_KeyPress;
            errorProvider1.SetError(Field, "");

        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CleanField(txtFilter);
            switch (cbFilterBy.Text)
            {
                case "None":
                    txtFilter.Visible = false;
                    _dtPeople.DefaultView.RowFilter = "";
                    break;
                case "Person ID":
                    txtFilter.Visible = true;
                    txtFilter.KeyPress += _DigitOnly_KeyPress;
                    break;
                case "National No":
                    txtFilter.Visible = true;
                    break;
                case "First Name":
                    txtFilter.Visible = true;
                    txtFilter.KeyPress += _LettersOnly_KeyPress;
                    break;
                case "Second Name":
                    txtFilter.Visible = true;
                    txtFilter.KeyPress += _LettersOnly_KeyPress;
                    break;
                case "Third Name":
                    txtFilter.Visible = true;
                    txtFilter.KeyPress += _LettersOnly_KeyPress;
                    break;
                case "Last Name":
                    txtFilter.Visible = true;
                    txtFilter.KeyPress += _LettersOnly_KeyPress;
                    break;
                case "Nationalty":
                    txtFilter.Visible = true;
                    txtFilter.KeyPress += _LettersOnly_KeyPress;
                    break;
                case "Phone":
                    txtFilter.Visible = true;
                    txtFilter.KeyPress += _DigitOnly_KeyPress;
                    break;
                case "Address":
                    txtFilter.Visible = true;
                    break;
            }
        }
        private void _Filter(string FilterBy,string FilterText)
        {

            if (_dtPeople.Rows.Count == 0)
                return;
            Type DataType = _dtPeople.Columns[FilterBy].DataType;
            if (DataType == typeof(int))
            {
                if(int.TryParse(FilterText,out int Result))
                {
                    _dtPeople.DefaultView.RowFilter =  $"CONVERT({FilterBy}, System.String) LIKE '{Result}%'";
                }
                else
                {
                    _dtPeople.DefaultView.RowFilter = "";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(FilterText))
                {
                    _dtPeople.DefaultView.RowFilter = $"{FilterBy} LIKE '{FilterText.Trim()}%'";
                }
                else
                {
                    _dtPeople.DefaultView.RowFilter = "";
                }
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string filterColumn = cbFilterBy.Text.Replace(" ", "");
            string filterValue = txtFilter.Text.Trim();

            if (_dtPeople.Rows.Count == 0)
                return;
            _Filter(filterColumn, filterValue);
        }
    }
}

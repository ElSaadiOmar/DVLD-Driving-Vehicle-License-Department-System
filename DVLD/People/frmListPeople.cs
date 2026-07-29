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
        public frmListPeople()
        {
            InitializeComponent(); 
            ApplyTheme();
        }

        private void _RefreshPeopleList()
        {
            dgvPeopleList.DataSource = clsPerson.GetAllPeople();
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
    }
}

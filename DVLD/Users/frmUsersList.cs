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

namespace DVLD.Users
{
    public partial class frmUsersList : Form
    {
        private DataTable _dtUsersList;
        public frmUsersList()
        {
            InitializeComponent();
            ApplyTheme();
        }
        private void ApplyTheme()
        {
            // Form
            this.BackColor = AppColors.PanelBg;
            cmUserMenu.BackColor = AppColors.NavyPrimary;
            cmUserMenu.ForeColor = Color.White;

            //GridView

            dgvUsersList.BackgroundColor = Color.White;
            dgvUsersList.GridColor = AppColors.GridRowAlt;
            //button

            btnAddNewPerson.BackColor = AppColors.NavyPrimary;
            btnAddNewPerson.FlatStyle = FlatStyle.Flat;
            btnAddNewPerson.FlatAppearance.BorderSize = 0;

            btnClose.BackColor = AppColors.NavyPrimary;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

        }

        private void frmUsersList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0; 
            _dtUsersList = clsUser.GetAllUsers();
            dgvUsersList.DataSource = _dtUsersList;
            lblRecords.Text = dgvUsersList.Rows.Count.ToString();
        }


        private void tsmShowUser_Click(object sender, EventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo((int)dgvUsersList.SelectedRows[0].Cells["UserID"].Value,true);
            frm.ShowDialog();
            frmUsersList_Load(null, null);
        }

        private void tsmDeleteUser_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsersList.SelectedRows[0].Cells[0].Value;
            if(UserID != clsGlobal.CurrentUser.UserID)
            {
                if (MessageBox.Show($"Are you sure you want delete User [{UserID.ToString()}]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (clsUser.Delete(UserID))
                    {
                        MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmUsersList_Load(null, null);
                    }

                    else
                        MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You can not delete your own user.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdateUser frm = new frmAddAndUpdateUser();
            frm.ShowDialog();
            frmUsersList_Load(null, null);
        }

        private void tsmEditUser_Click(object sender, EventArgs e)
        {
            frmAddAndUpdateUser frm = new frmAddAndUpdateUser((int)dgvUsersList.SelectedRows[0].Cells[0].Value);
            frm.ShowDialog();
            frmUsersList_Load(null, null);
        }

        private void dgvUsersList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo((int)dgvUsersList.SelectedRows[0].Cells[0].Value, true);
            frm.ShowDialog();
            frmUsersList_Load(null, null);
        }

        private void dgvUsersList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right  && e.RowIndex >= 0)
            {
                dgvUsersList.ClearSelection();
                dgvUsersList.Rows[e.RowIndex].Selected = true;
                cmUserMenu.Show(Cursor.Position);
            }
        }

        private void cmUserMenu_Opening(object sender, CancelEventArgs e)
        {
            if(dgvUsersList.Rows.Count <= 0)
            {
                e.Cancel = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            
            frmChangePassword frm = new frmChangePassword((int)dgvUsersList.SelectedRows[0].Cells[0].Value);
            frm.ShowDialog();
            frmUsersList_Load(null, null);
        }
    }
}

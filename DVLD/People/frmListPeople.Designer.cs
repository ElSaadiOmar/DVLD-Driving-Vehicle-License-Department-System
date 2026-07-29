namespace DVLD.People
{
    partial class frmListPeople
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListPeople));
            this.dgvPeopleList = new System.Windows.Forms.DataGridView();
            this.cmPersonMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmshowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmaddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmedit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmdelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmsendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmphoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeopleList)).BeginInit();
            this.cmPersonMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPeopleList
            // 
            this.dgvPeopleList.AllowUserToAddRows = false;
            this.dgvPeopleList.AllowUserToDeleteRows = false;
            this.dgvPeopleList.AllowUserToOrderColumns = true;
            this.dgvPeopleList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPeopleList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeopleList.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeopleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeopleList.ContextMenuStrip = this.cmPersonMenu;
            this.dgvPeopleList.Location = new System.Drawing.Point(12, 234);
            this.dgvPeopleList.Name = "dgvPeopleList";
            this.dgvPeopleList.ReadOnly = true;
            this.dgvPeopleList.RowHeadersWidth = 51;
            this.dgvPeopleList.RowTemplate.Height = 24;
            this.dgvPeopleList.Size = new System.Drawing.Size(1388, 381);
            this.dgvPeopleList.TabIndex = 0;
            this.dgvPeopleList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPeopleList_CellMouseDown);
            // 
            // cmPersonMenu
            // 
            this.cmPersonMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmPersonMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmshowDetails,
            this.toolStripMenuItem1,
            this.tsmaddNewPerson,
            this.tsmedit,
            this.tsmdelete,
            this.toolStripMenuItem2,
            this.tsmsendEmail,
            this.tsmphoneCall});
            this.cmPersonMenu.Name = "cmsPersonMenu";
            this.cmPersonMenu.Size = new System.Drawing.Size(215, 200);
            // 
            // tsmshowDetails
            // 
            this.tsmshowDetails.Image = ((System.Drawing.Image)(resources.GetObject("tsmshowDetails.Image")));
            this.tsmshowDetails.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsmshowDetails.Name = "tsmshowDetails";
            this.tsmshowDetails.Size = new System.Drawing.Size(214, 26);
            this.tsmshowDetails.Text = "Show Details";
            this.tsmshowDetails.Click += new System.EventHandler(this.tsmshowDetails_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 6);
            // 
            // tsmaddNewPerson
            // 
            this.tsmaddNewPerson.Image = ((System.Drawing.Image)(resources.GetObject("tsmaddNewPerson.Image")));
            this.tsmaddNewPerson.Name = "tsmaddNewPerson";
            this.tsmaddNewPerson.Size = new System.Drawing.Size(214, 26);
            this.tsmaddNewPerson.Text = "Add New Person";
            this.tsmaddNewPerson.Click += new System.EventHandler(this.tsmaddNewPerson_Click);
            // 
            // tsmedit
            // 
            this.tsmedit.Name = "tsmedit";
            this.tsmedit.Size = new System.Drawing.Size(214, 26);
            this.tsmedit.Text = "Edit";
            this.tsmedit.Click += new System.EventHandler(this.tsmedit_Click);
            // 
            // tsmdelete
            // 
            this.tsmdelete.Name = "tsmdelete";
            this.tsmdelete.Size = new System.Drawing.Size(214, 26);
            this.tsmdelete.Text = "Delete";
            this.tsmdelete.Click += new System.EventHandler(this.tsmdelete_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(211, 6);
            // 
            // tsmsendEmail
            // 
            this.tsmsendEmail.Name = "tsmsendEmail";
            this.tsmsendEmail.Size = new System.Drawing.Size(214, 26);
            this.tsmsendEmail.Text = "Send Email";
            // 
            // tsmphoneCall
            // 
            this.tsmphoneCall.Name = "tsmphoneCall";
            this.tsmphoneCall.Size = new System.Drawing.Size(214, 26);
            this.tsmphoneCall.Text = "Phone Call";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter By";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(138, 195);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnAddNewPerson.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddNewPerson.BackgroundImage")));
            this.btnAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddNewPerson.Location = new System.Drawing.Point(1332, 164);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(64, 56);
            this.btnAddNewPerson.TabIndex = 3;
            this.btnAddNewPerson.UseVisualStyleBackColor = false;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1283, 627);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 45);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "    Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmListPeople
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1412, 676);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPeopleList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListPeople";
            this.Text = "Mange People";
            this.Load += new System.EventHandler(this.frmMangePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeopleList)).EndInit();
            this.cmPersonMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPeopleList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmPersonMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmshowDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmaddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmedit;
        private System.Windows.Forms.ToolStripMenuItem tsmdelete;
        private System.Windows.Forms.ToolStripMenuItem tsmsendEmail;
        private System.Windows.Forms.ToolStripMenuItem tsmphoneCall;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}
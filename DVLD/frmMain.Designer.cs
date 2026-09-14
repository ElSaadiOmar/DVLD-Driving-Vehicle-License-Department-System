namespace DVLD
{
    partial class frmMain
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
            this.msMainMenue = new System.Windows.Forms.MenuStrip();
            this.smiApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.smiDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.smiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.smiAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.msMainMenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // msMainMenue
            // 
            this.msMainMenue.AutoSize = false;
            this.msMainMenue.BackColor = System.Drawing.Color.Navy;
            this.msMainMenue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.msMainMenue.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMainMenue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiApplications,
            this.smiPeople,
            this.smiDrivers,
            this.smiUsers,
            this.smiAccountSettings});
            this.msMainMenue.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.msMainMenue.Location = new System.Drawing.Point(0, 0);
            this.msMainMenue.Name = "msMainMenue";
            this.msMainMenue.Size = new System.Drawing.Size(1399, 120);
            this.msMainMenue.TabIndex = 4;
            this.msMainMenue.Text = "menuStrip1";
            // 
            // smiApplications
            // 
            this.smiApplications.AutoSize = false;
            this.smiApplications.Image = global::DVLD.Properties.Resources.Application_64;
            this.smiApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiApplications.Name = "smiApplications";
            this.smiApplications.Size = new System.Drawing.Size(275, 100);
            this.smiApplications.Text = "&Applications";
            // 
            // smiPeople
            // 
            this.smiPeople.AutoSize = false;
            this.smiPeople.Image = global::DVLD.Properties.Resources.People_64_png;
            this.smiPeople.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiPeople.Name = "smiPeople";
            this.smiPeople.Size = new System.Drawing.Size(220, 100);
            this.smiPeople.Text = " People";
            this.smiPeople.Click += new System.EventHandler(this.smiPeople_Click);
            // 
            // smiDrivers
            // 
            this.smiDrivers.AutoSize = false;
            this.smiDrivers.Image = global::DVLD.Properties.Resources.Drivers_64;
            this.smiDrivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiDrivers.Name = "smiDrivers";
            this.smiDrivers.Size = new System.Drawing.Size(220, 100);
            this.smiDrivers.Text = "Drivers";
            // 
            // smiUsers
            // 
            this.smiUsers.AutoSize = false;
            this.smiUsers.Image = global::DVLD.Properties.Resources.Users_64;
            this.smiUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiUsers.Name = "smiUsers";
            this.smiUsers.Size = new System.Drawing.Size(200, 100);
            this.smiUsers.Text = "Users";
            this.smiUsers.Click += new System.EventHandler(this.smiUsers_Click);
            // 
            // smiAccountSettings
            // 
            this.smiAccountSettings.AutoSize = false;
            this.smiAccountSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.toolStripSeparator4,
            this.signOutToolStripMenuItem});
            this.smiAccountSettings.Image = global::DVLD.Properties.Resources.Account_Setting_64;
            this.smiAccountSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiAccountSettings.Name = "smiAccountSettings";
            this.smiAccountSettings.Size = new System.Drawing.Size(330, 100);
            this.smiAccountSettings.Text = "Account Settings";
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentUserInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(339, 42);
            this.currentUserInfoToolStripMenuItem.Text = "&Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePasswordToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(339, 42);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(336, 6);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(339, 42);
            this.signOutToolStripMenuItem.Text = "Sign &Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1399, 576);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1399, 576);
            this.Controls.Add(this.msMainMenue);
            this.Controls.Add(this.pictureBox1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msMainMenue.ResumeLayout(false);
            this.msMainMenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip msMainMenue;
        private System.Windows.Forms.ToolStripMenuItem smiApplications;
        private System.Windows.Forms.ToolStripMenuItem smiPeople;
        private System.Windows.Forms.ToolStripMenuItem smiDrivers;
        private System.Windows.Forms.ToolStripMenuItem smiUsers;
        private System.Windows.Forms.ToolStripMenuItem smiAccountSettings;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
    }
}


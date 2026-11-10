namespace DVLD.Applications.Local_Driving_License
{
    partial class ctrlDrivingLicenseApplicationInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbDrivingLicenseApplicationInfo = new System.Windows.Forms.GroupBox();
            this.llShowLicenceInfo = new System.Windows.Forms.LinkLabel();
            this.lblPassedTests = new System.Windows.Forms.Label();
            this.lblLicenseClass = new System.Windows.Forms.Label();
            this.lblLocalDrivingLicenseApplicationID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlApplicationBasicInfo1 = new DVLD.Applications.Controls.ctrlApplicationBasicInfo();
            this.gbDrivingLicenseApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDrivingLicenseApplicationInfo
            // 
            this.gbDrivingLicenseApplicationInfo.Controls.Add(this.llShowLicenceInfo);
            this.gbDrivingLicenseApplicationInfo.Controls.Add(this.lblPassedTests);
            this.gbDrivingLicenseApplicationInfo.Controls.Add(this.lblLicenseClass);
            this.gbDrivingLicenseApplicationInfo.Controls.Add(this.lblLocalDrivingLicenseApplicationID);
            this.gbDrivingLicenseApplicationInfo.Controls.Add(this.label4);
            this.gbDrivingLicenseApplicationInfo.Controls.Add(this.label2);
            this.gbDrivingLicenseApplicationInfo.Controls.Add(this.label1);
            this.gbDrivingLicenseApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbDrivingLicenseApplicationInfo.Location = new System.Drawing.Point(3, 3);
            this.gbDrivingLicenseApplicationInfo.Name = "gbDrivingLicenseApplicationInfo";
            this.gbDrivingLicenseApplicationInfo.Size = new System.Drawing.Size(784, 100);
            this.gbDrivingLicenseApplicationInfo.TabIndex = 0;
            this.gbDrivingLicenseApplicationInfo.TabStop = false;
            this.gbDrivingLicenseApplicationInfo.Text = "Driving License Application Info";
            // 
            // llShowLicenceInfo
            // 
            this.llShowLicenceInfo.AutoSize = true;
            this.llShowLicenceInfo.Location = new System.Drawing.Point(112, 64);
            this.llShowLicenceInfo.Name = "llShowLicenceInfo";
            this.llShowLicenceInfo.Size = new System.Drawing.Size(146, 20);
            this.llShowLicenceInfo.TabIndex = 192;
            this.llShowLicenceInfo.TabStop = true;
            this.llShowLicenceInfo.Text = "Show License Info";
            this.llShowLicenceInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenceInfo_LinkClicked);
            // 
            // lblPassedTests
            // 
            this.lblPassedTests.AutoSize = true;
            this.lblPassedTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassedTests.Location = new System.Drawing.Point(487, 64);
            this.lblPassedTests.Name = "lblPassedTests";
            this.lblPassedTests.Size = new System.Drawing.Size(19, 20);
            this.lblPassedTests.TabIndex = 0;
            this.lblPassedTests.Text = "0";
            // 
            // lblLicenseClass
            // 
            this.lblLicenseClass.AutoSize = true;
            this.lblLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblLicenseClass.Location = new System.Drawing.Point(445, 34);
            this.lblLicenseClass.Name = "lblLicenseClass";
            this.lblLicenseClass.Size = new System.Drawing.Size(61, 20);
            this.lblLicenseClass.TabIndex = 0;
            this.lblLicenseClass.Text = "[????]";
            // 
            // lblLocalDrivingLicenseApplicationID
            // 
            this.lblLocalDrivingLicenseApplicationID.AutoSize = true;
            this.lblLocalDrivingLicenseApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblLocalDrivingLicenseApplicationID.Location = new System.Drawing.Point(131, 34);
            this.lblLocalDrivingLicenseApplicationID.Name = "lblLocalDrivingLicenseApplicationID";
            this.lblLocalDrivingLicenseApplicationID.Size = new System.Drawing.Size(61, 20);
            this.lblLocalDrivingLicenseApplicationID.TabIndex = 0;
            this.lblLocalDrivingLicenseApplicationID.Text = "[????]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(17, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 146;
            this.label4.Text = "D.L.App ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(326, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 146;
            this.label2.Text = "Passed Tests:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(255, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 20);
            this.label1.TabIndex = 146;
            this.label1.Text = "Applied For License:";
            // 
            // ctrlApplicationBasicInfo1
            // 
            this.ctrlApplicationBasicInfo1.Location = new System.Drawing.Point(3, 109);
            this.ctrlApplicationBasicInfo1.Name = "ctrlApplicationBasicInfo1";
            this.ctrlApplicationBasicInfo1.Size = new System.Drawing.Size(793, 218);
            this.ctrlApplicationBasicInfo1.TabIndex = 1;
            // 
            // ctrlDrivingLicenseApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlApplicationBasicInfo1);
            this.Controls.Add(this.gbDrivingLicenseApplicationInfo);
            this.Name = "ctrlDrivingLicenseApplicationInfo";
            this.Size = new System.Drawing.Size(793, 328);
            this.gbDrivingLicenseApplicationInfo.ResumeLayout(false);
            this.gbDrivingLicenseApplicationInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbDrivingLicenseApplicationInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel llShowLicenceInfo;
        private System.Windows.Forms.Label lblPassedTests;
        private System.Windows.Forms.Label lblLicenseClass;
        private System.Windows.Forms.Label lblLocalDrivingLicenseApplicationID;
        private Controls.ctrlApplicationBasicInfo ctrlApplicationBasicInfo1;
    }
}

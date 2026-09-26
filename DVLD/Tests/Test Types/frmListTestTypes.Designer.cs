namespace DVLD.Tests.Test_Types
{
    partial class frmListTestTypes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvTestTypes = new System.Windows.Forms.DataGridView();
            this.cmApplicationTypesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiEditTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbApplicationTypesmage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypes)).BeginInit();
            this.cmApplicationTypesMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbApplicationTypesmage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(318, 214);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(427, 54);
            this.lblTitle.TabIndex = 88;
            this.lblTitle.Text = "Mange Test Types";
            // 
            // dgvTestTypes
            // 
            this.dgvTestTypes.AllowUserToAddRows = false;
            this.dgvTestTypes.AllowUserToDeleteRows = false;
            this.dgvTestTypes.AllowUserToResizeColumns = false;
            this.dgvTestTypes.AllowUserToResizeRows = false;
            this.dgvTestTypes.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTestTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestTypes.ContextMenuStrip = this.cmApplicationTypesMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTestTypes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTestTypes.Location = new System.Drawing.Point(12, 292);
            this.dgvTestTypes.MultiSelect = false;
            this.dgvTestTypes.Name = "dgvTestTypes";
            this.dgvTestTypes.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestTypes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTestTypes.RowHeadersWidth = 51;
            this.dgvTestTypes.RowTemplate.Height = 24;
            this.dgvTestTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestTypes.Size = new System.Drawing.Size(1020, 362);
            this.dgvTestTypes.TabIndex = 86;
            this.dgvTestTypes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTestTypes_CellDoubleClick);
            // 
            // cmApplicationTypesMenu
            // 
            this.cmApplicationTypesMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmApplicationTypesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.cmiEditTest,
            this.toolStripSeparator2});
            this.cmApplicationTypesMenu.Name = "cmApplicationTypesMenu";
            this.cmApplicationTypesMenu.Size = new System.Drawing.Size(195, 44);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // cmiEditTest
            // 
            this.cmiEditTest.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmiEditTest.Image = global::DVLD.Properties.Resources.Edit_32;
            this.cmiEditTest.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.cmiEditTest.Name = "cmiEditTest";
            this.cmiEditTest.Size = new System.Drawing.Size(194, 28);
            this.cmiEditTest.Text = "Edit Test Type";
            this.cmiEditTest.Click += new System.EventHandler(this.cmiEditTest_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(918, 679);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 51);
            this.btnClose.TabIndex = 87;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbApplicationTypesmage
            // 
            this.pbApplicationTypesmage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbApplicationTypesmage.Image = global::DVLD.Properties.Resources.Test_Type_512;
            this.pbApplicationTypesmage.InitialImage = null;
            this.pbApplicationTypesmage.Location = new System.Drawing.Point(455, 14);
            this.pbApplicationTypesmage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbApplicationTypesmage.Name = "pbApplicationTypesmage";
            this.pbApplicationTypesmage.Size = new System.Drawing.Size(187, 189);
            this.pbApplicationTypesmage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbApplicationTypesmage.TabIndex = 117;
            this.pbApplicationTypesmage.TabStop = false;
            // 
            // frmListTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 742);
            this.Controls.Add(this.pbApplicationTypesmage);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvTestTypes);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListTestTypes";
            this.Text = "List Test Types";
            this.Load += new System.EventHandler(this.frmListTestTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypes)).EndInit();
            this.cmApplicationTypesMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbApplicationTypesmage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvTestTypes;
        private System.Windows.Forms.ContextMenuStrip cmApplicationTypesMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmiEditTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbApplicationTypesmage;
    }
}
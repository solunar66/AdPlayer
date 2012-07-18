namespace FTP
{
    partial class frmUserAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserAccount));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lstUserList = new System.Windows.Forms.ListView();
            this.UserName = new System.Windows.Forms.ColumnHeader();
            this.Password = new System.Windows.Forms.ColumnHeader();
            this.StartUpPath = new System.Windows.Forms.ColumnHeader();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.SystemColors.Info;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(493, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "User List";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstUserList
            // 
            this.lstUserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserName,
            this.Password,
            this.StartUpPath});
            this.lstUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUserList.FullRowSelect = true;
            this.lstUserList.GridLines = true;
            this.lstUserList.Location = new System.Drawing.Point(0, 20);
            this.lstUserList.Name = "lstUserList";
            this.lstUserList.Size = new System.Drawing.Size(493, 278);
            this.lstUserList.TabIndex = 1;
            this.lstUserList.UseCompatibleStateImageBehavior = false;
            this.lstUserList.View = System.Windows.Forms.View.Details;
            this.lstUserList.DoubleClick += new System.EventHandler(this.EditUser_Click);
            // 
            // UserName
            // 
            this.UserName.Text = "User Name";
            this.UserName.Width = 120;
            // 
            // Password
            // 
            this.Password.Text = "Password";
            this.Password.Width = 120;
            // 
            // StartUpPath
            // 
            this.StartUpPath.Text = "StartUp Path";
            this.StartUpPath.Width = 300;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnDeleteUser);
            this.panelBottom.Controls.Add(this.btnEditUser);
            this.panelBottom.Controls.Add(this.btnNewUser);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 298);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(493, 70);
            this.panelBottom.TabIndex = 0;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Image = global::FTP.Properties.Resources.DeleteUser;
            this.btnDeleteUser.Location = new System.Drawing.Point(130, 9);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(55, 55);
            this.btnDeleteUser.TabIndex = 2;
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.DeleteUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Image = global::FTP.Properties.Resources.EditUser;
            this.btnEditUser.Location = new System.Drawing.Point(69, 9);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(55, 55);
            this.btnEditUser.TabIndex = 1;
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.EditUser_Click);
            // 
            // btnNewUser
            // 
            this.btnNewUser.Image = global::FTP.Properties.Resources.NewUser;
            this.btnNewUser.Location = new System.Drawing.Point(8, 9);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(55, 55);
            this.btnNewUser.TabIndex = 0;
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.CreateNewUser_Click);
            // 
            // frmUserAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 368);
            this.Controls.Add(this.lstUserList);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.panelBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUserAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced FTP Server :: User Account";
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ListView lstUserList;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader Password;
        private System.Windows.Forms.ColumnHeader StartUpPath;
    }
}
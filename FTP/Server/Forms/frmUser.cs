using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FTP
{
    public partial class frmUser : Form
    {
        string OldUserName;

        public frmUser()
        {
            InitializeComponent();
        }

        public frmUser(string UserName)
        {
            InitializeComponent();
            OldUserName = UserName;
            Text = "Advanced FTP Server :: Edit User";
            lblHeader.Text = "Edit User";

            string Password = null, StartUpPath = null, PermissionSet = null;
            bool EnableUser = false;
            if (ApplicationSettings.GetUser(UserName, out Password, out StartUpPath, out PermissionSet, out EnableUser))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                txtStartUpPath.Text = StartUpPath;
                chkEnableUser.Checked = EnableUser;

                char[] Permissions = PermissionSet.ToCharArray();
                chkAllowStoreFiles.Checked = Permissions[0] == '1';
                chkAllowStoreFolders.Checked = Permissions[1] == '1';
                chkAllowRenameFiles.Checked = Permissions[2] == '1';
                chkAllowRenameFolders.Checked = Permissions[3] == '1';
                chkAllowDeleteFiles.Checked = Permissions[4] == '1';
                chkAllowDeleteFolders.Checked = Permissions[5] == '1';
                chkAllowCopyFiles.Checked = Permissions[6] == '1';
                chkAllowViewHiddenFiles.Checked = Permissions[7] == '1';
                chkAllowViewHiddenFolders.Checked = Permissions[8] == '1';
            }
            else
            {
                MessageBox.Show("The user with the name " + OldUserName + " dose not exist.", "Advanced FTP Server");
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        void BrowseRootFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.Description = "Select the Root Folder for the user";
            FBD.ShowNewFolderButton = true;
            FBD.SelectedPath = txtStartUpPath.Text;
            if (FBD.ShowDialog() == DialogResult.Cancel) return;
            txtStartUpPath.Text = FBD.SelectedPath;
        }

        void SaveUser_Click(object sender, EventArgs e)
        {
            txtUserName.Text = txtUserName.Text.Trim();
            txtStartUpPath.Text = txtStartUpPath.Text.Trim();

            string Message = string.Empty;

            if (txtUserName.Text.Length < 2) Message = "User Name cannot be lesser than 2 chars\n ";
            if (txtPassword.Text.Length < 2) Message += "Password cannot be lesser than 2 chars\n";
            if (!System.IO.Directory.Exists(txtStartUpPath.Text)) Message += "The selected root path dose not exists\n";

            string PermissionSet = string.Empty;

            PermissionSet += (chkAllowStoreFiles.Checked) ? "1" : "0";
            PermissionSet += (chkAllowStoreFolders.Checked) ? "1" : "0";
            PermissionSet += (chkAllowRenameFiles.Checked) ? "1" : "0";
            PermissionSet += (chkAllowRenameFolders.Checked) ? "1" : "0";
            PermissionSet += (chkAllowDeleteFiles.Checked) ? "1" : "0";
            PermissionSet += (chkAllowDeleteFolders.Checked) ? "1" : "0";
            PermissionSet += (chkAllowCopyFiles.Checked) ? "1" : "0";

            if (PermissionSet.IndexOf('1') == -1) Message += "The user requires atleast a single permission.\n";

            PermissionSet += (chkAllowViewHiddenFiles.Checked) ? "1" : "0";
            PermissionSet += (chkAllowViewHiddenFolders.Checked) ? "1" : "0";

            if (Message.Length != 0)
            {
                MessageBox.Show(Message, "Advanced FTP Server");
                return;
            }

            if (OldUserName == null) // Add new user
            {
                if (!ApplicationSettings.CreateFTPUser(txtUserName.Text, txtPassword.Text, txtStartUpPath.Text, PermissionSet, chkEnableUser.Checked))
                {
                    MessageBox.Show("User with the specified name already exists. Please specify different User Name", "Advanced FTP Server");
                    return;
                }
            }
            else // Edit existing user
            {
                if (!ApplicationSettings.EditUser(OldUserName, txtUserName.Text, txtPassword.Text, txtStartUpPath.Text, PermissionSet, chkEnableUser.Checked))
                {
                    MessageBox.Show("Specified new User Name already exists. Please specify new name.", "Advanced FTP Server");
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        void CancelChanges_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
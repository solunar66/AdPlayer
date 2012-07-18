using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FTP
{
    public partial class frmUserAccount : Form
    {
        public frmUserAccount()
        {
            InitializeComponent();
            UpdateUserList();
        }

        void UpdateUserList()
        {
            lstUserList.Items.Clear();
            System.Xml.XmlNodeList UserList = ApplicationSettings.GetUserList();
            foreach (System.Xml.XmlNode User in UserList)
            {
                ListViewItem UserItem = new ListViewItem(new string[] { User.Attributes[0].Value, User.Attributes[1].Value, User.Attributes[2].Value });
                lstUserList.Items.Add(UserItem);
            }
        }

        void CreateNewUser_Click(object sender, EventArgs e)
        {
            frmUser NewUser = new frmUser();
            if (NewUser.ShowDialog() == DialogResult.Cancel) return;
            UpdateUserList();
        }

        void EditUser_Click(object sender, EventArgs e)
        {
            if (lstUserList.SelectedItems.Count == 0) return;

            frmUser EditUser = new frmUser(lstUserList.SelectedItems[0].SubItems[0].Text);
            if (EditUser.ShowDialog() == DialogResult.Cancel) return;
            UpdateUserList();
        }

        void DeleteUser_Click(object sender, EventArgs e)
        {
            if (lstUserList.SelectedItems.Count == 0) return;
            string UserName = lstUserList.SelectedItems[0].SubItems[0].Text;
            if (MessageBox.Show("Are you sure to delete the user named " + UserName + " permenantly.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            ApplicationSettings.DeleteFTPUser(UserName);
            UpdateUserList();
        }
    }
}
using System;
using System.Windows.Forms;

namespace FTP
{
    public partial class frmOnlineUsers : Form
    {
        public frmOnlineUsers()
        {
            InitializeComponent();
            RefreshUsersList(null, null);
        }

        void DisconnectUser(object sender, EventArgs e)
        {
            if (lstOnlineUsers.SelectedItems.Count == 0) return;

            string SelectedConnection_SessionID = lstOnlineUsers.SelectedItems[0].SubItems[0].Text;
            
            foreach (FTPClient ConnectedUser in ApplicationSettings.FtpServer.FTPClients)
            {
                if (ConnectedUser.SessionID == SelectedConnection_SessionID)
                {
                    ConnectedUser.Disconnect();
                    break;
                }
            }
            RefreshUsersList(null, null);
        }

        void ViewConnectionHistory(object sender, EventArgs e)
        {
            MessageBox.Show("This menu is reserved for future implementation. Option is currently unavailable.", "Advanced FTP Server");
        }

        void RefreshUsersList(object sender, EventArgs e)
        {
            lstOnlineUsers.Items.Clear();
            foreach (FTPClient ConnectedUser in ApplicationSettings.FtpServer.FTPClients)
            {
                string[] ItemArray = new string[5];
                ItemArray[0] = ConnectedUser.SessionID;
                ItemArray[1] = ConnectedUser.ConnectedUser.UserName;
                ItemArray[2] = ConnectedUser.EndPoint;
                ItemArray[3] = ConnectedUser.ConnectedTime.ToString(ApplicationSettings.DateTimeFormat);
                ItemArray[4] = ConnectedUser.LastInteraction.ToString(ApplicationSettings.DateTimeFormat);
                lstOnlineUsers.Items.Add(new ListViewItem(ItemArray));                
            }
        }
    }
}
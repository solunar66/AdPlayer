using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FTP
{
    public partial class frmViewService : Form
    {
        public frmViewService()
        {
            InitializeComponent();

            txtFTPPort.Value = ApplicationSettings.FTPPort;
            chkEnableFTP.Checked = ApplicationSettings.AutoStartFTP;
            chkEnableFTPLogging.Checked = ApplicationSettings.EnableFTPLogging;
            txtPasvRangeFrom.Value = ApplicationSettings.MinPassvPort;
            txtPasvRangeTo.Value = ApplicationSettings.MaxPassvPort;

            txtHTTPPort.Value = ApplicationSettings.HTTPPort;
            chkStartHTTP.Checked = ApplicationSettings.AutoStartHTTP;
            txtLoginID.Text = ApplicationSettings.UserName;
            txtPassword.Text = ApplicationSettings.Password;
        }

        void SaveSettings_Click(object sender, EventArgs e)
        {
            if (!ApplicationSettings.EnableNotifyIcon && !chkStartHTTP.Checked)
            {
                MessageBox.Show("Displaying Notify Icon in system tray is already disabled and you cannot disable http service. Either of one is required to manage the service.", "Advanced FTP Server");
                chkStartHTTP.Checked = true;
                return;
            }
            if (txtPasvRangeFrom.Value >= (txtPasvRangeTo.Value - 10))
            {
                MessageBox.Show("Invalid PASV Port range. Atleast 10 ports must be allowed for PASSIV mode.", "Advanced FTP Server");
                return;
            }

            ApplicationSettings.FTPPort = Convert.ToInt32(txtFTPPort.Value);
            ApplicationSettings.AutoStartFTP = chkEnableFTP.Checked;
            ApplicationSettings.EnableFTPLogging = chkEnableFTPLogging.Checked;
            ApplicationSettings.MinPassvPort = (int)txtPasvRangeFrom.Value;
            ApplicationSettings.MaxPassvPort = (int)txtPasvRangeTo.Value;

            ApplicationSettings.HTTPPort = Convert.ToInt32(txtHTTPPort.Value);
            ApplicationSettings.AutoStartHTTP = chkStartHTTP.Checked;
            ApplicationSettings.UserName = txtLoginID.Text.Trim();
            ApplicationSettings.Password = txtPassword.Text;
            ApplicationSettings.SaveSettings();
            Close();
        }

        void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
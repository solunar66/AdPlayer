using System;
using System.Windows.Forms;

namespace FTP
{
    public partial class frmCommonSettings : Form
    {
        public frmCommonSettings()
        {
            InitializeComponent();
            LoadSettings();
        }

        void LoadSettings()
        {
            txtDateTimeFormat.Text = ApplicationSettings.DateTimeFormat;

            chkDisplayNotifyIcon.Checked = ApplicationSettings.EnableNotifyIcon;
            chkChangeFTPFoldrsIcon.Checked = ApplicationSettings.ChangeFTPFoldersIcon;
            //chkEnableAPD.Checked = ApplicationSettings.DefineFileAccessPermission;
            //chkDisplayQuickConfigure.Checked = ApplicationSettings.EnableQuickConfigMenu;
            chkAutoSendErrorReport.Checked = ApplicationSettings.AutoSendErrorReport;
            chkMoveFilesToRecycleBin.Checked = ApplicationSettings.MoveDeletedFilesToRecycleBin;
        }

        void Save_Click(object sender, EventArgs e)
        {
            if (!chkDisplayNotifyIcon.Checked && !ApplicationSettings.AutoStartHTTP)
            {
                MessageBox.Show("HTTP service is already disabled. Notify icon option is required for Management.", "Advanced FTP Server");
                chkDisplayNotifyIcon.Checked = true;
                return;
            }

            ApplicationSettings.DateTimeFormat = txtDateTimeFormat.Text;

            ApplicationSettings.EnableNotifyIcon = chkDisplayNotifyIcon.Checked;
            ApplicationSettings.ChangeFTPFoldersIcon = chkChangeFTPFoldrsIcon.Checked;
            //ApplicationSettings.DefineFileAccessPermission = chkEnableAPD.Checked;
            //ApplicationSettings.EnableQuickConfigMenu = chkDisplayQuickConfigure.Checked;
            ApplicationSettings.AutoSendErrorReport = chkAutoSendErrorReport.Checked;
            ApplicationSettings.MoveDeletedFilesToRecycleBin = chkMoveFilesToRecycleBin.Checked;

            ApplicationSettings.SaveSettings();
            Close();
        }

        void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        void DateFormat_Changed(object sender, EventArgs e)
        {
            try
            {
                lblEgDateTimeFormat.Text = string.Format("(eg. {0})", DateTime.Now.ToString(txtDateTimeFormat.Text));
            }
            catch
            {
                lblEgDateTimeFormat.Text = "(eg. Invalid Format)";
            }
        }

        void txtDateTimeFormat_Leave(object sender, EventArgs e)
        {
            if (txtDateTimeFormat.Text.Trim().Length == 0)
                txtDateTimeFormat.Text = ApplicationSettings.DateTimeFormat;
        }
    }
}
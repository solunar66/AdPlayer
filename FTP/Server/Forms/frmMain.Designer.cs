namespace FTP
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.TrayContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuViewShow = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuConfigSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUserAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewService = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCommonSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShortcuts = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenHTTP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenFTP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShortcutSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEnableHTTPService = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEnableFTPService = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMessage = new System.Windows.Forms.Label();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayContext
            // 
            this.TrayContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewShow,
            this.mnuSeperator1,
            this.mnuConfigSettings,
            this.mnuShortcuts,
            this.mnuSeparator2,
            this.mnuHelpAbout,
            this.mnuSeparator3,
            this.mnuExit});
            this.TrayContext.Name = "TrayContext";
            this.TrayContext.Size = new System.Drawing.Size(155, 132);
            this.TrayContext.Text = "Advanced FTP Server";
            this.TrayContext.Opened += new System.EventHandler(this.TrayContext_Opened);
            // 
            // mnuViewShow
            // 
            this.mnuViewShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlineUsersToolStripMenuItem,
            this.errorLogsToolStripMenuItem});
            this.mnuViewShow.Name = "mnuViewShow";
            this.mnuViewShow.Size = new System.Drawing.Size(154, 22);
            this.mnuViewShow.Text = "View / Show";
            // 
            // onlineUsersToolStripMenuItem
            // 
            this.onlineUsersToolStripMenuItem.Name = "onlineUsersToolStripMenuItem";
            this.onlineUsersToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.onlineUsersToolStripMenuItem.Text = "Online Users";
            this.onlineUsersToolStripMenuItem.Click += new System.EventHandler(this.ViewOnlineUsers_Click);
            // 
            // errorLogsToolStripMenuItem
            // 
            this.errorLogsToolStripMenuItem.Name = "errorLogsToolStripMenuItem";
            this.errorLogsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.errorLogsToolStripMenuItem.Text = "Error Logs";
            this.errorLogsToolStripMenuItem.Click += new System.EventHandler(this.ViewErrorLogs_Click);
            // 
            // mnuSeperator1
            // 
            this.mnuSeperator1.Name = "mnuSeperator1";
            this.mnuSeperator1.Size = new System.Drawing.Size(151, 6);
            // 
            // mnuConfigSettings
            // 
            this.mnuConfigSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUserAccount,
            this.mnuViewService,
            this.mnuCommonSettings});
            this.mnuConfigSettings.Name = "mnuConfigSettings";
            this.mnuConfigSettings.Size = new System.Drawing.Size(154, 22);
            this.mnuConfigSettings.Text = "Config / Settings";
            // 
            // mnuUserAccount
            // 
            this.mnuUserAccount.Name = "mnuUserAccount";
            this.mnuUserAccount.Size = new System.Drawing.Size(157, 22);
            this.mnuUserAccount.Text = "User Account";
            this.mnuUserAccount.Click += new System.EventHandler(this.ViewUserAccount_Click);
            // 
            // mnuViewService
            // 
            this.mnuViewService.Name = "mnuViewService";
            this.mnuViewService.Size = new System.Drawing.Size(157, 22);
            this.mnuViewService.Text = "Service";
            this.mnuViewService.Click += new System.EventHandler(this.ViewService_Click);
            // 
            // mnuCommonSettings
            // 
            this.mnuCommonSettings.Name = "mnuCommonSettings";
            this.mnuCommonSettings.Size = new System.Drawing.Size(157, 22);
            this.mnuCommonSettings.Text = "Common Settings";
            this.mnuCommonSettings.Click += new System.EventHandler(this.CommonSettings_Click);
            // 
            // mnuShortcuts
            // 
            this.mnuShortcuts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenHTTP,
            this.mnuOpenFTP,
            this.mnuShortcutSeparator1,
            this.mnuEnableHTTPService,
            this.mnuEnableFTPService});
            this.mnuShortcuts.Name = "mnuShortcuts";
            this.mnuShortcuts.Size = new System.Drawing.Size(154, 22);
            this.mnuShortcuts.Text = "Shortcuts";
            // 
            // mnuOpenHTTP
            // 
            this.mnuOpenHTTP.Name = "mnuOpenHTTP";
            this.mnuOpenHTTP.Size = new System.Drawing.Size(172, 22);
            this.mnuOpenHTTP.Text = "Open HTTP";
            this.mnuOpenHTTP.Click += new System.EventHandler(this.OpenHTTP_Click);
            // 
            // mnuOpenFTP
            // 
            this.mnuOpenFTP.Name = "mnuOpenFTP";
            this.mnuOpenFTP.Size = new System.Drawing.Size(172, 22);
            this.mnuOpenFTP.Text = "Open FTP";
            this.mnuOpenFTP.Click += new System.EventHandler(this.OpenFTP_Click);
            // 
            // mnuShortcutSeparator1
            // 
            this.mnuShortcutSeparator1.Name = "mnuShortcutSeparator1";
            this.mnuShortcutSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // mnuEnableHTTPService
            // 
            this.mnuEnableHTTPService.Name = "mnuEnableHTTPService";
            this.mnuEnableHTTPService.Size = new System.Drawing.Size(172, 22);
            this.mnuEnableHTTPService.Text = "Enable HTTP Service";
            this.mnuEnableHTTPService.Click += new System.EventHandler(this.EnableHTTPService_Click);
            // 
            // mnuEnableFTPService
            // 
            this.mnuEnableFTPService.Name = "mnuEnableFTPService";
            this.mnuEnableFTPService.Size = new System.Drawing.Size(172, 22);
            this.mnuEnableFTPService.Text = "Enable FTP Service";
            this.mnuEnableFTPService.Click += new System.EventHandler(this.EnableFTPService_Click);
            // 
            // mnuSeparator2
            // 
            this.mnuSeparator2.Name = "mnuSeparator2";
            this.mnuSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(154, 22);
            this.mnuHelpAbout.Text = "About";
            this.mnuHelpAbout.Click += new System.EventHandler(this.ShowAbout_Click);
            // 
            // mnuSeparator3
            // 
            this.mnuSeparator3.Name = "mnuSeparator3";
            this.mnuSeparator3.Size = new System.Drawing.Size(151, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(154, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.ExitApplication_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(226, 43);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "This is a hidden form and wont be visible at any time.";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrayIcon
            // 
            this.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayIcon.BalloonTipText = "Advancde FTP Server is running in background";
            this.TrayIcon.BalloonTipTitle = "Advancde FTP Server";
            this.TrayIcon.ContextMenuStrip = this.TrayContext;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Advanced FTP Server";
            this.TrayIcon.Visible = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 43);
            this.ControlBox = false;
            this.Controls.Add(this.lblMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Opacity = 0;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Advanced FTP Server :: Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.StartApplication);
            this.Shown += new System.EventHandler(this.HideForm);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EndApplication);
            this.TrayContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip TrayContext;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuShortcuts;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenHTTP;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenFTP;
        private System.Windows.Forms.ToolStripSeparator mnuShortcutSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuEnableFTPService;
        private System.Windows.Forms.ToolStripMenuItem mnuEnableHTTPService;
        private System.Windows.Forms.ToolStripMenuItem mnuViewShow;
        private System.Windows.Forms.ToolStripMenuItem onlineUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator mnuSeperator1;
        private System.Windows.Forms.ToolStripMenuItem mnuConfigSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuUserAccount;
        private System.Windows.Forms.ToolStripMenuItem mnuViewService;
        private System.Windows.Forms.ToolStripMenuItem mnuCommonSettings;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
    }
}
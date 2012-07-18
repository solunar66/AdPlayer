namespace FTP
{
    partial class frmOnlineUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOnlineUsers));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lstOnlineUsers = new System.Windows.Forms.ListView();
            this.colCurrentSession = new System.Windows.Forms.ColumnHeader();
            this.colUserName = new System.Windows.Forms.ColumnHeader();
            this.colEndPoint = new System.Windows.Forms.ColumnHeader();
            this.colConnectedTime = new System.Windows.Forms.ColumnHeader();
            this.colLastInteraction = new System.Windows.Forms.ColumnHeader();
            this.OnlileUserContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.disconnectUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewConnectionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OnlileUserContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.SystemColors.Info;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(597, 23);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Online Users";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstOnlineUsers
            // 
            this.lstOnlineUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCurrentSession,
            this.colUserName,
            this.colEndPoint,
            this.colConnectedTime,
            this.colLastInteraction});
            this.lstOnlineUsers.ContextMenuStrip = this.OnlileUserContext;
            this.lstOnlineUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOnlineUsers.FullRowSelect = true;
            this.lstOnlineUsers.Location = new System.Drawing.Point(0, 23);
            this.lstOnlineUsers.Name = "lstOnlineUsers";
            this.lstOnlineUsers.Size = new System.Drawing.Size(597, 374);
            this.lstOnlineUsers.TabIndex = 1;
            this.lstOnlineUsers.UseCompatibleStateImageBehavior = false;
            this.lstOnlineUsers.View = System.Windows.Forms.View.Details;
            // 
            // colCurrentSession
            // 
            this.colCurrentSession.Text = "Session ID";
            this.colCurrentSession.Width = 130;
            // 
            // colUserName
            // 
            this.colUserName.Text = "User Name";
            this.colUserName.Width = 122;
            // 
            // colEndPoint
            // 
            this.colEndPoint.Text = "End Point";
            this.colEndPoint.Width = 102;
            // 
            // colConnectedTime
            // 
            this.colConnectedTime.Text = "Connected Time";
            this.colConnectedTime.Width = 122;
            // 
            // colLastInteraction
            // 
            this.colLastInteraction.Text = "Last Interaction";
            this.colLastInteraction.Width = 117;
            // 
            // OnlileUserContext
            // 
            this.OnlileUserContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectUserToolStripMenuItem,
            this.viewConnectionHistoryToolStripMenuItem,
            this.toolStripSeparator1,
            this.refreshListToolStripMenuItem});
            this.OnlileUserContext.Name = "OnlileUserContext";
            this.OnlileUserContext.Size = new System.Drawing.Size(202, 76);
            // 
            // disconnectUserToolStripMenuItem
            // 
            this.disconnectUserToolStripMenuItem.Name = "disconnectUserToolStripMenuItem";
            this.disconnectUserToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.disconnectUserToolStripMenuItem.Text = "Disconnect User";
            this.disconnectUserToolStripMenuItem.Click += new System.EventHandler(this.DisconnectUser);
            // 
            // viewConnectionHistoryToolStripMenuItem
            // 
            this.viewConnectionHistoryToolStripMenuItem.Name = "viewConnectionHistoryToolStripMenuItem";
            this.viewConnectionHistoryToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.viewConnectionHistoryToolStripMenuItem.Text = "View Connection History";
            this.viewConnectionHistoryToolStripMenuItem.Click += new System.EventHandler(this.ViewConnectionHistory);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // refreshListToolStripMenuItem
            // 
            this.refreshListToolStripMenuItem.Name = "refreshListToolStripMenuItem";
            this.refreshListToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.refreshListToolStripMenuItem.Text = "Refresh List";
            this.refreshListToolStripMenuItem.Click += new System.EventHandler(this.RefreshUsersList);
            // 
            // frmOnlineUsers
            // 
            this.ClientSize = new System.Drawing.Size(597, 397);
            this.Controls.Add(this.lstOnlineUsers);
            this.Controls.Add(this.lblHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOnlineUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced FTP Server :: Online Users List";
            this.OnlileUserContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ListView lstOnlineUsers;
        private System.Windows.Forms.ColumnHeader colCurrentSession;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.ColumnHeader colEndPoint;
        private System.Windows.Forms.ColumnHeader colConnectedTime;
        private System.Windows.Forms.ColumnHeader colLastInteraction;
        private System.Windows.Forms.ContextMenuStrip OnlileUserContext;
        private System.Windows.Forms.ToolStripMenuItem disconnectUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewConnectionHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem refreshListToolStripMenuItem;

    }
}


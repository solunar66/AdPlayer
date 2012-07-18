namespace FTP
{
    partial class frmUser
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtStartUpPath = new System.Windows.Forms.TextBox();
            this.lblStartUpPath = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.gbUserPermissions = new System.Windows.Forms.GroupBox();
            this.tablePermissions = new System.Windows.Forms.TableLayoutPanel();
            this.chkAllowViewHiddenFolders = new System.Windows.Forms.CheckBox();
            this.chkAllowViewHiddenFiles = new System.Windows.Forms.CheckBox();
            this.lblViewHidden = new System.Windows.Forms.Label();
            this.lblCopy = new System.Windows.Forms.Label();
            this.chkAllowCopyFiles = new System.Windows.Forms.CheckBox();
            this.chkAllowDeleteFolders = new System.Windows.Forms.CheckBox();
            this.chkAllowDeleteFiles = new System.Windows.Forms.CheckBox();
            this.chkAllowRenameFolders = new System.Windows.Forms.CheckBox();
            this.chkAllowRenameFiles = new System.Windows.Forms.CheckBox();
            this.chkAllowStoreFolders = new System.Windows.Forms.CheckBox();
            this.lblStore = new System.Windows.Forms.Label();
            this.lblHeaderFolders = new System.Windows.Forms.Label();
            this.lblHeaderFiles = new System.Windows.Forms.Label();
            this.lblHeaderPermissions = new System.Windows.Forms.Label();
            this.lblRename = new System.Windows.Forms.Label();
            this.lblDelete = new System.Windows.Forms.Label();
            this.chkAllowStoreFiles = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkEnableUser = new System.Windows.Forms.CheckBox();
            this.gbUserPermissions.SuspendLayout();
            this.tablePermissions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.SystemColors.Info;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(405, 23);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Add New User";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(11, 34);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(105, 31);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(288, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(105, 57);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(288, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(11, 60);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // txtStartUpPath
            // 
            this.txtStartUpPath.Location = new System.Drawing.Point(105, 83);
            this.txtStartUpPath.MaxLength = 300;
            this.txtStartUpPath.Name = "txtStartUpPath";
            this.txtStartUpPath.Size = new System.Drawing.Size(227, 20);
            this.txtStartUpPath.TabIndex = 5;
            // 
            // lblStartUpPath
            // 
            this.lblStartUpPath.AutoSize = true;
            this.lblStartUpPath.Location = new System.Drawing.Point(11, 86);
            this.lblStartUpPath.Name = "lblStartUpPath";
            this.lblStartUpPath.Size = new System.Drawing.Size(68, 13);
            this.lblStartUpPath.TabIndex = 4;
            this.lblStartUpPath.Text = "StartUp Path";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(337, 81);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(56, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BrowseRootFolder_Click);
            // 
            // gbUserPermissions
            // 
            this.gbUserPermissions.Controls.Add(this.tablePermissions);
            this.gbUserPermissions.Location = new System.Drawing.Point(13, 116);
            this.gbUserPermissions.Name = "gbUserPermissions";
            this.gbUserPermissions.Size = new System.Drawing.Size(336, 170);
            this.gbUserPermissions.TabIndex = 7;
            this.gbUserPermissions.TabStop = false;
            this.gbUserPermissions.Text = "User Permissions";
            // 
            // tablePermissions
            // 
            this.tablePermissions.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tablePermissions.ColumnCount = 3;
            this.tablePermissions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tablePermissions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tablePermissions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tablePermissions.Controls.Add(this.chkAllowViewHiddenFolders, 2, 5);
            this.tablePermissions.Controls.Add(this.chkAllowViewHiddenFiles, 1, 5);
            this.tablePermissions.Controls.Add(this.lblViewHidden, 0, 5);
            this.tablePermissions.Controls.Add(this.lblCopy, 0, 4);
            this.tablePermissions.Controls.Add(this.chkAllowCopyFiles, 1, 4);
            this.tablePermissions.Controls.Add(this.chkAllowDeleteFolders, 2, 3);
            this.tablePermissions.Controls.Add(this.chkAllowDeleteFiles, 1, 3);
            this.tablePermissions.Controls.Add(this.chkAllowRenameFolders, 2, 2);
            this.tablePermissions.Controls.Add(this.chkAllowRenameFiles, 1, 2);
            this.tablePermissions.Controls.Add(this.chkAllowStoreFolders, 2, 1);
            this.tablePermissions.Controls.Add(this.lblStore, 0, 1);
            this.tablePermissions.Controls.Add(this.lblHeaderFolders, 2, 0);
            this.tablePermissions.Controls.Add(this.lblHeaderFiles, 1, 0);
            this.tablePermissions.Controls.Add(this.lblHeaderPermissions, 0, 0);
            this.tablePermissions.Controls.Add(this.lblRename, 0, 2);
            this.tablePermissions.Controls.Add(this.lblDelete, 0, 3);
            this.tablePermissions.Controls.Add(this.chkAllowStoreFiles, 1, 1);
            this.tablePermissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePermissions.Location = new System.Drawing.Point(3, 16);
            this.tablePermissions.Name = "tablePermissions";
            this.tablePermissions.RowCount = 6;
            this.tablePermissions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePermissions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tablePermissions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tablePermissions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tablePermissions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tablePermissions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tablePermissions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePermissions.Size = new System.Drawing.Size(330, 151);
            this.tablePermissions.TabIndex = 0;
            // 
            // chkAllowViewHiddenFolders
            // 
            this.chkAllowViewHiddenFolders.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAllowViewHiddenFolders.AutoSize = true;
            this.chkAllowViewHiddenFolders.Location = new System.Drawing.Point(265, 129);
            this.chkAllowViewHiddenFolders.Name = "chkAllowViewHiddenFolders";
            this.chkAllowViewHiddenFolders.Size = new System.Drawing.Size(51, 16);
            this.chkAllowViewHiddenFolders.TabIndex = 18;
            this.chkAllowViewHiddenFolders.Text = "Allow";
            this.chkAllowViewHiddenFolders.UseVisualStyleBackColor = true;
            // 
            // chkAllowViewHiddenFiles
            // 
            this.chkAllowViewHiddenFiles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAllowViewHiddenFiles.AutoSize = true;
            this.chkAllowViewHiddenFiles.Location = new System.Drawing.Point(168, 129);
            this.chkAllowViewHiddenFiles.Name = "chkAllowViewHiddenFiles";
            this.chkAllowViewHiddenFiles.Size = new System.Drawing.Size(51, 16);
            this.chkAllowViewHiddenFiles.TabIndex = 17;
            this.chkAllowViewHiddenFiles.Text = "Allow";
            this.chkAllowViewHiddenFiles.UseVisualStyleBackColor = true;
            // 
            // lblViewHidden
            // 
            this.lblViewHidden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblViewHidden.AutoSize = true;
            this.lblViewHidden.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblViewHidden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewHidden.ForeColor = System.Drawing.Color.DarkRed;
            this.lblViewHidden.Location = new System.Drawing.Point(6, 126);
            this.lblViewHidden.Name = "lblViewHidden";
            this.lblViewHidden.Size = new System.Drawing.Size(139, 22);
            this.lblViewHidden.TabIndex = 16;
            this.lblViewHidden.Text = "View Hidden";
            this.lblViewHidden.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCopy
            // 
            this.lblCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopy.AutoSize = true;
            this.lblCopy.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopy.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCopy.Location = new System.Drawing.Point(6, 101);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(139, 22);
            this.lblCopy.TabIndex = 15;
            this.lblCopy.Text = "Copy";
            this.lblCopy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkAllowCopyFiles
            // 
            this.chkAllowCopyFiles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAllowCopyFiles.AutoSize = true;
            this.chkAllowCopyFiles.Checked = true;
            this.chkAllowCopyFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowCopyFiles.Location = new System.Drawing.Point(168, 104);
            this.chkAllowCopyFiles.Name = "chkAllowCopyFiles";
            this.chkAllowCopyFiles.Size = new System.Drawing.Size(51, 16);
            this.chkAllowCopyFiles.TabIndex = 13;
            this.chkAllowCopyFiles.Text = "Allow";
            this.chkAllowCopyFiles.UseVisualStyleBackColor = true;
            // 
            // chkAllowDeleteFolders
            // 
            this.chkAllowDeleteFolders.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAllowDeleteFolders.AutoSize = true;
            this.chkAllowDeleteFolders.Checked = true;
            this.chkAllowDeleteFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowDeleteFolders.Location = new System.Drawing.Point(265, 79);
            this.chkAllowDeleteFolders.Name = "chkAllowDeleteFolders";
            this.chkAllowDeleteFolders.Size = new System.Drawing.Size(51, 16);
            this.chkAllowDeleteFolders.TabIndex = 11;
            this.chkAllowDeleteFolders.Text = "Allow";
            this.chkAllowDeleteFolders.UseVisualStyleBackColor = true;
            // 
            // chkAllowDeleteFiles
            // 
            this.chkAllowDeleteFiles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAllowDeleteFiles.AutoSize = true;
            this.chkAllowDeleteFiles.Checked = true;
            this.chkAllowDeleteFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowDeleteFiles.Location = new System.Drawing.Point(168, 79);
            this.chkAllowDeleteFiles.Name = "chkAllowDeleteFiles";
            this.chkAllowDeleteFiles.Size = new System.Drawing.Size(51, 16);
            this.chkAllowDeleteFiles.TabIndex = 10;
            this.chkAllowDeleteFiles.Text = "Allow";
            this.chkAllowDeleteFiles.UseVisualStyleBackColor = true;
            // 
            // chkAllowRenameFolders
            // 
            this.chkAllowRenameFolders.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAllowRenameFolders.AutoSize = true;
            this.chkAllowRenameFolders.Checked = true;
            this.chkAllowRenameFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowRenameFolders.Location = new System.Drawing.Point(265, 54);
            this.chkAllowRenameFolders.Name = "chkAllowRenameFolders";
            this.chkAllowRenameFolders.Size = new System.Drawing.Size(51, 16);
            this.chkAllowRenameFolders.TabIndex = 9;
            this.chkAllowRenameFolders.Text = "Allow";
            this.chkAllowRenameFolders.UseVisualStyleBackColor = true;
            // 
            // chkAllowRenameFiles
            // 
            this.chkAllowRenameFiles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAllowRenameFiles.AutoSize = true;
            this.chkAllowRenameFiles.Checked = true;
            this.chkAllowRenameFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowRenameFiles.Location = new System.Drawing.Point(168, 54);
            this.chkAllowRenameFiles.Name = "chkAllowRenameFiles";
            this.chkAllowRenameFiles.Size = new System.Drawing.Size(51, 16);
            this.chkAllowRenameFiles.TabIndex = 8;
            this.chkAllowRenameFiles.Text = "Allow";
            this.chkAllowRenameFiles.UseVisualStyleBackColor = true;
            // 
            // chkAllowStoreFolders
            // 
            this.chkAllowStoreFolders.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAllowStoreFolders.AutoSize = true;
            this.chkAllowStoreFolders.Checked = true;
            this.chkAllowStoreFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowStoreFolders.Location = new System.Drawing.Point(265, 29);
            this.chkAllowStoreFolders.Name = "chkAllowStoreFolders";
            this.chkAllowStoreFolders.Size = new System.Drawing.Size(51, 16);
            this.chkAllowStoreFolders.TabIndex = 7;
            this.chkAllowStoreFolders.Text = "Allow";
            this.chkAllowStoreFolders.UseVisualStyleBackColor = true;
            // 
            // lblStore
            // 
            this.lblStore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStore.AutoSize = true;
            this.lblStore.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStore.Location = new System.Drawing.Point(6, 26);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(139, 22);
            this.lblStore.TabIndex = 3;
            this.lblStore.Text = "Store";
            this.lblStore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderFolders
            // 
            this.lblHeaderFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderFolders.AutoSize = true;
            this.lblHeaderFolders.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblHeaderFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderFolders.ForeColor = System.Drawing.Color.Maroon;
            this.lblHeaderFolders.Location = new System.Drawing.Point(242, 3);
            this.lblHeaderFolders.Name = "lblHeaderFolders";
            this.lblHeaderFolders.Size = new System.Drawing.Size(97, 20);
            this.lblHeaderFolders.TabIndex = 2;
            this.lblHeaderFolders.Text = "Folders";
            this.lblHeaderFolders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderFiles
            // 
            this.lblHeaderFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderFiles.AutoSize = true;
            this.lblHeaderFiles.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblHeaderFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderFiles.ForeColor = System.Drawing.Color.Maroon;
            this.lblHeaderFiles.Location = new System.Drawing.Point(154, 3);
            this.lblHeaderFiles.Name = "lblHeaderFiles";
            this.lblHeaderFiles.Size = new System.Drawing.Size(79, 20);
            this.lblHeaderFiles.TabIndex = 1;
            this.lblHeaderFiles.Text = "Files";
            this.lblHeaderFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderPermissions
            // 
            this.lblHeaderPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderPermissions.AutoSize = true;
            this.lblHeaderPermissions.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblHeaderPermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderPermissions.ForeColor = System.Drawing.Color.Maroon;
            this.lblHeaderPermissions.Location = new System.Drawing.Point(6, 3);
            this.lblHeaderPermissions.Name = "lblHeaderPermissions";
            this.lblHeaderPermissions.Size = new System.Drawing.Size(139, 20);
            this.lblHeaderPermissions.TabIndex = 0;
            this.lblHeaderPermissions.Text = "Permissions";
            this.lblHeaderPermissions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRename
            // 
            this.lblRename.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRename.AutoSize = true;
            this.lblRename.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRename.ForeColor = System.Drawing.Color.DarkRed;
            this.lblRename.Location = new System.Drawing.Point(6, 51);
            this.lblRename.Name = "lblRename";
            this.lblRename.Size = new System.Drawing.Size(139, 22);
            this.lblRename.TabIndex = 4;
            this.lblRename.Text = "Rename";
            this.lblRename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDelete
            // 
            this.lblDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDelete.AutoSize = true;
            this.lblDelete.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelete.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDelete.Location = new System.Drawing.Point(6, 76);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(139, 22);
            this.lblDelete.TabIndex = 5;
            this.lblDelete.Text = "Delete";
            this.lblDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkAllowStoreFiles
            // 
            this.chkAllowStoreFiles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAllowStoreFiles.AutoSize = true;
            this.chkAllowStoreFiles.Checked = true;
            this.chkAllowStoreFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowStoreFiles.Location = new System.Drawing.Point(168, 29);
            this.chkAllowStoreFiles.Name = "chkAllowStoreFiles";
            this.chkAllowStoreFiles.Size = new System.Drawing.Size(51, 16);
            this.chkAllowStoreFiles.TabIndex = 6;
            this.chkAllowStoreFiles.Text = "Allow";
            this.chkAllowStoreFiles.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(235, 297);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveUser_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(316, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelChanges_Click);
            // 
            // chkEnableUser
            // 
            this.chkEnableUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkEnableUser.AutoSize = true;
            this.chkEnableUser.Checked = true;
            this.chkEnableUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableUser.Location = new System.Drawing.Point(14, 301);
            this.chkEnableUser.Name = "chkEnableUser";
            this.chkEnableUser.Size = new System.Drawing.Size(84, 17);
            this.chkEnableUser.TabIndex = 14;
            this.chkEnableUser.Text = "Enable User";
            this.chkEnableUser.UseVisualStyleBackColor = true;
            // 
            // frmUser
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(405, 324);
            this.Controls.Add(this.chkEnableUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbUserPermissions);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtStartUpPath);
            this.Controls.Add(this.lblStartUpPath);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmUser";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced FTP Server :: New User";
            this.gbUserPermissions.ResumeLayout(false);
            this.tablePermissions.ResumeLayout(false);
            this.tablePermissions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtStartUpPath;
        private System.Windows.Forms.Label lblStartUpPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.GroupBox gbUserPermissions;
        private System.Windows.Forms.TableLayoutPanel tablePermissions;
        private System.Windows.Forms.CheckBox chkAllowDeleteFolders;
        private System.Windows.Forms.CheckBox chkAllowDeleteFiles;
        private System.Windows.Forms.CheckBox chkAllowRenameFolders;
        private System.Windows.Forms.CheckBox chkAllowRenameFiles;
        private System.Windows.Forms.CheckBox chkAllowStoreFolders;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.Label lblHeaderFolders;
        private System.Windows.Forms.Label lblHeaderFiles;
        private System.Windows.Forms.Label lblHeaderPermissions;
        private System.Windows.Forms.Label lblRename;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.CheckBox chkAllowStoreFiles;
        private System.Windows.Forms.Label lblCopy;
        private System.Windows.Forms.CheckBox chkAllowCopyFiles;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkEnableUser;
        private System.Windows.Forms.CheckBox chkAllowViewHiddenFolders;
        private System.Windows.Forms.CheckBox chkAllowViewHiddenFiles;
        private System.Windows.Forms.Label lblViewHidden;
    }
}
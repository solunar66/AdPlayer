namespace FTP
{
    partial class frmViewService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewService));
            this.gbFTPSettings = new System.Windows.Forms.GroupBox();
            this.txtPasvRangeTo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPasvRangeFrom = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnableFTPLogging = new System.Windows.Forms.CheckBox();
            this.txtFTPPort = new System.Windows.Forms.NumericUpDown();
            this.chkEnableFTP = new System.Windows.Forms.CheckBox();
            this.lblFtpPort = new System.Windows.Forms.Label();
            this.gbHTTPSettings = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtLoginID = new System.Windows.Forms.TextBox();
            this.lblLoginID = new System.Windows.Forms.Label();
            this.txtHTTPPort = new System.Windows.Forms.NumericUpDown();
            this.chkStartHTTP = new System.Windows.Forms.CheckBox();
            this.lblHTTPPort = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbFTPSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasvRangeTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasvRangeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTPPort)).BeginInit();
            this.gbHTTPSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHTTPPort)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFTPSettings
            // 
            this.gbFTPSettings.Controls.Add(this.txtPasvRangeTo);
            this.gbFTPSettings.Controls.Add(this.label2);
            this.gbFTPSettings.Controls.Add(this.txtPasvRangeFrom);
            this.gbFTPSettings.Controls.Add(this.label1);
            this.gbFTPSettings.Controls.Add(this.chkEnableFTPLogging);
            this.gbFTPSettings.Controls.Add(this.txtFTPPort);
            this.gbFTPSettings.Controls.Add(this.chkEnableFTP);
            this.gbFTPSettings.Controls.Add(this.lblFtpPort);
            this.gbFTPSettings.Location = new System.Drawing.Point(12, 12);
            this.gbFTPSettings.Name = "gbFTPSettings";
            this.gbFTPSettings.Size = new System.Drawing.Size(293, 136);
            this.gbFTPSettings.TabIndex = 0;
            this.gbFTPSettings.TabStop = false;
            this.gbFTPSettings.Text = "FTP Settings";
            // 
            // txtPasvRangeTo
            // 
            this.txtPasvRangeTo.Location = new System.Drawing.Point(198, 54);
            this.txtPasvRangeTo.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.txtPasvRangeTo.Name = "txtPasvRangeTo";
            this.txtPasvRangeTo.Size = new System.Drawing.Size(84, 20);
            this.txtPasvRangeTo.TabIndex = 7;
            this.txtPasvRangeTo.Value = new decimal(new int[] {
            7100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "to";
            // 
            // txtPasvRangeFrom
            // 
            this.txtPasvRangeFrom.Location = new System.Drawing.Point(86, 54);
            this.txtPasvRangeFrom.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.txtPasvRangeFrom.Name = "txtPasvRangeFrom";
            this.txtPasvRangeFrom.Size = new System.Drawing.Size(84, 20);
            this.txtPasvRangeFrom.TabIndex = 5;
            this.txtPasvRangeFrom.Value = new decimal(new int[] {
            7000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "PASV Ports";
            // 
            // chkEnableFTPLogging
            // 
            this.chkEnableFTPLogging.AutoSize = true;
            this.chkEnableFTPLogging.Enabled = false;
            this.chkEnableFTPLogging.Location = new System.Drawing.Point(11, 104);
            this.chkEnableFTPLogging.Name = "chkEnableFTPLogging";
            this.chkEnableFTPLogging.Size = new System.Drawing.Size(160, 17);
            this.chkEnableFTPLogging.TabIndex = 3;
            this.chkEnableFTPLogging.Text = "Enable Logging user actions";
            this.chkEnableFTPLogging.UseVisualStyleBackColor = true;
            // 
            // txtFTPPort
            // 
            this.txtFTPPort.Location = new System.Drawing.Point(86, 22);
            this.txtFTPPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.txtFTPPort.Name = "txtFTPPort";
            this.txtFTPPort.Size = new System.Drawing.Size(84, 20);
            this.txtFTPPort.TabIndex = 2;
            this.txtFTPPort.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // chkEnableFTP
            // 
            this.chkEnableFTP.AutoSize = true;
            this.chkEnableFTP.Location = new System.Drawing.Point(11, 79);
            this.chkEnableFTP.Name = "chkEnableFTP";
            this.chkEnableFTP.Size = new System.Drawing.Size(230, 17);
            this.chkEnableFTP.TabIndex = 1;
            this.chkEnableFTP.Text = "Start FTP Listener when windows starts up.";
            this.chkEnableFTP.UseVisualStyleBackColor = true;
            // 
            // lblFtpPort
            // 
            this.lblFtpPort.AutoSize = true;
            this.lblFtpPort.Location = new System.Drawing.Point(8, 24);
            this.lblFtpPort.Name = "lblFtpPort";
            this.lblFtpPort.Size = new System.Drawing.Size(49, 13);
            this.lblFtpPort.TabIndex = 0;
            this.lblFtpPort.Text = "FTP Port";
            // 
            // gbHTTPSettings
            // 
            this.gbHTTPSettings.Controls.Add(this.txtPassword);
            this.gbHTTPSettings.Controls.Add(this.lblPassword);
            this.gbHTTPSettings.Controls.Add(this.txtLoginID);
            this.gbHTTPSettings.Controls.Add(this.lblLoginID);
            this.gbHTTPSettings.Controls.Add(this.txtHTTPPort);
            this.gbHTTPSettings.Controls.Add(this.chkStartHTTP);
            this.gbHTTPSettings.Controls.Add(this.lblHTTPPort);
            this.gbHTTPSettings.Location = new System.Drawing.Point(12, 154);
            this.gbHTTPSettings.Name = "gbHTTPSettings";
            this.gbHTTPSettings.Size = new System.Drawing.Size(293, 143);
            this.gbHTTPSettings.TabIndex = 0;
            this.gbHTTPSettings.TabStop = false;
            this.gbHTTPSettings.Text = "HTTP Settings";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(86, 105);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(189, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(8, 108);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            // 
            // txtLoginID
            // 
            this.txtLoginID.Location = new System.Drawing.Point(86, 75);
            this.txtLoginID.Name = "txtLoginID";
            this.txtLoginID.Size = new System.Drawing.Size(189, 20);
            this.txtLoginID.TabIndex = 4;
            // 
            // lblLoginID
            // 
            this.lblLoginID.AutoSize = true;
            this.lblLoginID.Location = new System.Drawing.Point(8, 78);
            this.lblLoginID.Name = "lblLoginID";
            this.lblLoginID.Size = new System.Drawing.Size(47, 13);
            this.lblLoginID.TabIndex = 3;
            this.lblLoginID.Text = "Login ID";
            // 
            // txtHTTPPort
            // 
            this.txtHTTPPort.Location = new System.Drawing.Point(86, 22);
            this.txtHTTPPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.txtHTTPPort.Name = "txtHTTPPort";
            this.txtHTTPPort.Size = new System.Drawing.Size(84, 20);
            this.txtHTTPPort.TabIndex = 2;
            this.txtHTTPPort.Value = new decimal(new int[] {
            9090,
            0,
            0,
            0});
            // 
            // chkStartHTTP
            // 
            this.chkStartHTTP.AutoSize = true;
            this.chkStartHTTP.Location = new System.Drawing.Point(11, 48);
            this.chkStartHTTP.Name = "chkStartHTTP";
            this.chkStartHTTP.Size = new System.Drawing.Size(239, 17);
            this.chkStartHTTP.TabIndex = 1;
            this.chkStartHTTP.Text = "Start HTTP Listener when windows starts up.";
            this.chkStartHTTP.UseVisualStyleBackColor = true;
            // 
            // lblHTTPPort
            // 
            this.lblHTTPPort.AutoSize = true;
            this.lblHTTPPort.Location = new System.Drawing.Point(8, 24);
            this.lblHTTPPort.Name = "lblHTTPPort";
            this.lblHTTPPort.Size = new System.Drawing.Size(58, 13);
            this.lblHTTPPort.TabIndex = 0;
            this.lblHTTPPort.Text = "HTTP Port";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(148, 303);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveSettings_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(230, 303);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // frmViewService
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(318, 335);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbHTTPSettings);
            this.Controls.Add(this.gbFTPSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmViewService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced FTP Server :: Service Settings";
            this.gbFTPSettings.ResumeLayout(false);
            this.gbFTPSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasvRangeTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasvRangeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTPPort)).EndInit();
            this.gbHTTPSettings.ResumeLayout(false);
            this.gbHTTPSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHTTPPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFTPSettings;
        private System.Windows.Forms.CheckBox chkEnableFTPLogging;
        private System.Windows.Forms.NumericUpDown txtFTPPort;
        private System.Windows.Forms.CheckBox chkEnableFTP;
        private System.Windows.Forms.Label lblFtpPort;
        private System.Windows.Forms.GroupBox gbHTTPSettings;
        private System.Windows.Forms.NumericUpDown txtHTTPPort;
        private System.Windows.Forms.CheckBox chkStartHTTP;
        private System.Windows.Forms.Label lblHTTPPort;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtLoginID;
        private System.Windows.Forms.Label lblLoginID;
        private System.Windows.Forms.NumericUpDown txtPasvRangeTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtPasvRangeFrom;
        private System.Windows.Forms.Label label1;
    }
}
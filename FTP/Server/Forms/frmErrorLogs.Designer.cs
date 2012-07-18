namespace FTP
{
    partial class frmErrorLogs
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
            this.panelList = new System.Windows.Forms.Panel();
            this.gbSearchCondition = new System.Windows.Forms.GroupBox();
            this.txtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnClearList = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTimeTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDateTo = new System.Windows.Forms.DateTimePicker();
            this.chkShowFTPErrorList = new System.Windows.Forms.CheckBox();
            this.chkShowHTTPErrorList = new System.Windows.Forms.CheckBox();
            this.gbSearchInProgress = new System.Windows.Forms.GroupBox();
            this.btnCancelSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lstExceptionList = new System.Windows.Forms.ListView();
            this.colErrorSource = new System.Windows.Forms.ColumnHeader();
            this.colDateTime = new System.Windows.Forms.ColumnHeader();
            this.colException = new System.Windows.Forms.ColumnHeader();
            this.colMessage = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelDescription = new System.Windows.Forms.Panel();
            this.txtErrorDetails = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.Searcher = new System.ComponentModel.BackgroundWorker();
            this.panelList.SuspendLayout();
            this.gbSearchCondition.SuspendLayout();
            this.gbSearchInProgress.SuspendLayout();
            this.panelDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.gbSearchCondition);
            this.panelList.Controls.Add(this.gbSearchInProgress);
            this.panelList.Controls.Add(this.lstExceptionList);
            this.panelList.Controls.Add(this.label1);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(0, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(681, 310);
            this.panelList.TabIndex = 1;
            // 
            // gbSearchCondition
            // 
            this.gbSearchCondition.Controls.Add(this.txtDateFrom);
            this.gbSearchCondition.Controls.Add(this.btnClearList);
            this.gbSearchCondition.Controls.Add(this.label3);
            this.gbSearchCondition.Controls.Add(this.btnSearch);
            this.gbSearchCondition.Controls.Add(this.label4);
            this.gbSearchCondition.Controls.Add(this.txtTimeTo);
            this.gbSearchCondition.Controls.Add(this.label5);
            this.gbSearchCondition.Controls.Add(this.txtTimeFrom);
            this.gbSearchCondition.Controls.Add(this.label6);
            this.gbSearchCondition.Controls.Add(this.txtDateTo);
            this.gbSearchCondition.Controls.Add(this.chkShowFTPErrorList);
            this.gbSearchCondition.Controls.Add(this.chkShowHTTPErrorList);
            this.gbSearchCondition.Location = new System.Drawing.Point(3, 23);
            this.gbSearchCondition.Name = "gbSearchCondition";
            this.gbSearchCondition.Size = new System.Drawing.Size(465, 114);
            this.gbSearchCondition.TabIndex = 0;
            this.gbSearchCondition.TabStop = false;
            this.gbSearchCondition.Text = "Logs Filter";
            this.gbSearchCondition.Visible = false;
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.Location = new System.Drawing.Point(71, 18);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(200, 20);
            this.txtDateFrom.TabIndex = 0;
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(377, 81);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(75, 23);
            this.btnClearList.TabIndex = 7;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.ClearList_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date From";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(296, 81);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.SearchList_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Date To";
            // 
            // txtTimeTo
            // 
            this.txtTimeTo.CustomFormat = "HH : mm";
            this.txtTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTimeTo.Location = new System.Drawing.Point(386, 49);
            this.txtTimeTo.Name = "txtTimeTo";
            this.txtTimeTo.Size = new System.Drawing.Size(66, 20);
            this.txtTimeTo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Time From";
            // 
            // txtTimeFrom
            // 
            this.txtTimeFrom.CustomFormat = "HH : mm";
            this.txtTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTimeFrom.Location = new System.Drawing.Point(386, 18);
            this.txtTimeFrom.Name = "txtTimeFrom";
            this.txtTimeFrom.Size = new System.Drawing.Size(66, 20);
            this.txtTimeFrom.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Time To";
            // 
            // txtDateTo
            // 
            this.txtDateTo.Location = new System.Drawing.Point(71, 49);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(200, 20);
            this.txtDateTo.TabIndex = 1;
            // 
            // chkShowFTPErrorList
            // 
            this.chkShowFTPErrorList.AutoSize = true;
            this.chkShowFTPErrorList.Location = new System.Drawing.Point(12, 85);
            this.chkShowFTPErrorList.Name = "chkShowFTPErrorList";
            this.chkShowFTPErrorList.Size = new System.Drawing.Size(106, 17);
            this.chkShowFTPErrorList.TabIndex = 4;
            this.chkShowFTPErrorList.Text = "Show FTP Errors";
            this.chkShowFTPErrorList.UseVisualStyleBackColor = true;
            // 
            // chkShowHTTPErrorList
            // 
            this.chkShowHTTPErrorList.AutoSize = true;
            this.chkShowHTTPErrorList.Location = new System.Drawing.Point(150, 85);
            this.chkShowHTTPErrorList.Name = "chkShowHTTPErrorList";
            this.chkShowHTTPErrorList.Size = new System.Drawing.Size(115, 17);
            this.chkShowHTTPErrorList.TabIndex = 5;
            this.chkShowHTTPErrorList.Text = "Show HTTP Errors";
            this.chkShowHTTPErrorList.UseVisualStyleBackColor = true;
            // 
            // gbSearchInProgress
            // 
            this.gbSearchInProgress.Controls.Add(this.btnCancelSearch);
            this.gbSearchInProgress.Controls.Add(this.label7);
            this.gbSearchInProgress.Location = new System.Drawing.Point(3, 27);
            this.gbSearchInProgress.Name = "gbSearchInProgress";
            this.gbSearchInProgress.Size = new System.Drawing.Size(465, 112);
            this.gbSearchInProgress.TabIndex = 0;
            this.gbSearchInProgress.TabStop = false;
            this.gbSearchInProgress.Text = "Searching";
            this.gbSearchInProgress.Visible = false;
            // 
            // btnCancelSearch
            // 
            this.btnCancelSearch.Location = new System.Drawing.Point(335, 73);
            this.btnCancelSearch.Name = "btnCancelSearch";
            this.btnCancelSearch.Size = new System.Drawing.Size(101, 23);
            this.btnCancelSearch.TabIndex = 1;
            this.btnCancelSearch.Text = "Cancel Search";
            this.btnCancelSearch.UseVisualStyleBackColor = true;
            this.btnCancelSearch.Click += new System.EventHandler(this.CancelSearch_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(427, 33);
            this.label7.TabIndex = 0;
            this.label7.Text = "Searching is in progress. This may take some time. You may cancel the search at a" +
                "ny time. Click cancel to cancel the searching operation.";
            // 
            // lstExceptionList
            // 
            this.lstExceptionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colErrorSource,
            this.colDateTime,
            this.colException,
            this.colMessage});
            this.lstExceptionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstExceptionList.FullRowSelect = true;
            this.lstExceptionList.GridLines = true;
            this.lstExceptionList.Location = new System.Drawing.Point(0, 23);
            this.lstExceptionList.Name = "lstExceptionList";
            this.lstExceptionList.Size = new System.Drawing.Size(681, 287);
            this.lstExceptionList.TabIndex = 0;
            this.lstExceptionList.UseCompatibleStateImageBehavior = false;
            this.lstExceptionList.View = System.Windows.Forms.View.Details;
            this.lstExceptionList.SelectedIndexChanged += new System.EventHandler(this.LogChoosen);
            // 
            // colErrorSource
            // 
            this.colErrorSource.Text = "Error Source";
            this.colErrorSource.Width = 76;
            // 
            // colDateTime
            // 
            this.colDateTime.Text = "DateTime";
            this.colDateTime.Width = 123;
            // 
            // colException
            // 
            this.colException.Text = "Exception";
            this.colException.Width = 198;
            // 
            // colMessage
            // 
            this.colMessage.Text = "Message";
            this.colMessage.Width = 277;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(681, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logs Filter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 307);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(681, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panelDescription
            // 
            this.panelDescription.Controls.Add(this.txtErrorDetails);
            this.panelDescription.Controls.Add(this.lblDescription);
            this.panelDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDescription.Location = new System.Drawing.Point(0, 310);
            this.panelDescription.Name = "panelDescription";
            this.panelDescription.Size = new System.Drawing.Size(681, 158);
            this.panelDescription.TabIndex = 3;
            // 
            // txtErrorDetails
            // 
            this.txtErrorDetails.BackColor = System.Drawing.SystemColors.Window;
            this.txtErrorDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtErrorDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrorDetails.ForeColor = System.Drawing.Color.Red;
            this.txtErrorDetails.Location = new System.Drawing.Point(0, 23);
            this.txtErrorDetails.Name = "txtErrorDetails";
            this.txtErrorDetails.ReadOnly = true;
            this.txtErrorDetails.Size = new System.Drawing.Size(681, 135);
            this.txtErrorDetails.TabIndex = 0;
            this.txtErrorDetails.Text = "";
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.SystemColors.Info;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(0, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(681, 23);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Error Description";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(0, 0);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(45, 23);
            this.btnFilter.TabIndex = 0;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // Searcher
            // 
            this.Searcher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Searcher_DoWork);
            // 
            // frmErrorLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 468);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.panelDescription);
            this.Name = "frmErrorLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced FTP Server :: Exception Logs";
            this.panelList.ResumeLayout(false);
            this.gbSearchCondition.ResumeLayout(false);
            this.gbSearchCondition.PerformLayout();
            this.gbSearchInProgress.ResumeLayout(false);
            this.panelDescription.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panelDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker txtTimeTo;
        private System.Windows.Forms.DateTimePicker txtTimeFrom;
        private System.Windows.Forms.DateTimePicker txtDateTo;
        private System.Windows.Forms.DateTimePicker txtDateFrom;
        private System.Windows.Forms.CheckBox chkShowHTTPErrorList;
        private System.Windows.Forms.CheckBox chkShowFTPErrorList;
        private System.Windows.Forms.ListView lstExceptionList;
        private System.Windows.Forms.ColumnHeader colErrorSource;
        private System.Windows.Forms.ColumnHeader colDateTime;
        private System.Windows.Forms.ColumnHeader colException;
        private System.Windows.Forms.ColumnHeader colMessage;
        private System.Windows.Forms.RichTextBox txtErrorDetails;
        private System.Windows.Forms.GroupBox gbSearchCondition;
        private System.Windows.Forms.Button btnFilter;
        private System.ComponentModel.BackgroundWorker Searcher;
        private System.Windows.Forms.GroupBox gbSearchInProgress;
        private System.Windows.Forms.Button btnCancelSearch;
        private System.Windows.Forms.Label label7;
    }
}
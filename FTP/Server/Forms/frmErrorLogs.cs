using System;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System.Text;

namespace FTP
{
    public partial class frmErrorLogs : Form
    {
        DataTable LogList;
        bool CancelSearch;

        public frmErrorLogs()
        {
            InitializeComponent();
        }

        void Filter_Click(object sender, EventArgs e)
        {
            gbSearchInProgress.Visible = false;
            gbSearchCondition.Visible = !gbSearchCondition.Visible;
        }

        void SearchList_Click(object sender, EventArgs e)
        {
            string Message = string.Empty;
            if (txtDateFrom.Value > txtDateTo.Value)
                Message = "Selected Date range is not correct.";

            if (txtTimeFrom.Value.Hour > txtTimeTo.Value.Hour ||
                (txtTimeFrom.Value.Hour == txtTimeTo.Value.Hour &&
                txtTimeFrom.Value.Minute > txtTimeTo.Value.Minute))
                Message += "Selected Time range is not correct";

            if (!chkShowFTPErrorList.Checked && !chkShowHTTPErrorList.Checked)
                Message += "Either FTP or HTTP Error list must be selected.";

            if (Message != string.Empty)
            {
                MessageBox.Show(Message, "Advanced FTP Server");
                return;
            }

            lstExceptionList.Items.Clear();
            if (LogList != null) LogList.Rows.Clear();
            txtErrorDetails.Text = string.Empty;
            btnFilter.Enabled = false;
            gbSearchCondition.Visible = false;
            gbSearchInProgress.Visible = true;
            Searcher.RunWorkerAsync();
        }

        void ClearList_Click(object sender, EventArgs e)
        {
            lstExceptionList.Items.Clear();
            txtErrorDetails.Text = string.Empty;
        }

        void Searcher_DoWork(object sender, DoWorkEventArgs e)
        {
            CancelSearch = false;
            LogList = ApplicationSettings.GetExceptionLog(txtDateFrom.Value,
                txtDateTo.Value, txtTimeFrom.Value, txtTimeTo.Value,
                chkShowFTPErrorList.Checked, chkShowHTTPErrorList.Checked, ref CancelSearch);
            gbSearchInProgress.Visible = false;
            btnFilter.Enabled = true;

            if (LogList == null || LogList.Rows.Count == 0)
            {
                gbSearchCondition.Visible = true;                
                MessageBox.Show("No results to display.", "Advanced FTP Server");
                return;
            }

            foreach (DataRow Log in LogList.Rows)
            {
                string[] Item = new string[4];
                Item[0] = Log["ErrorSource"].ToString();
                Item[1] = ((DateTime)Log["DateTime"]).ToString(ApplicationSettings.DateTimeFormat);
                Item[2] = Log["Exception"].ToString();
                Item[3] = Log["Message"].ToString();
                lstExceptionList.Items.Add(new ListViewItem(Item));
            }
        }

        void CancelSearch_Click(object sender, EventArgs e)
        {
            CancelSearch =
                MessageBox.Show("Are you sure to cancel the searching operation?", "Advanced FTP Server",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        void LogChoosen(object sender, EventArgs e)
        {
            if (lstExceptionList.SelectedItems.Count == 0) return;
            DataRow Log = LogList.Rows[lstExceptionList.SelectedIndices[0]];
            StringBuilder Description = new StringBuilder();
            Description.AppendLine("Error Source : " + Log["ErrorSource"].ToString());
            Description.AppendLine("Date & Time  : " + ((DateTime)Log["DateTime"]).ToString(ApplicationSettings.DateTimeFormat));

            Description.AppendLine("Message :");
            Description.AppendLine(Log["Message"].ToString());
            Description.AppendLine("");

            Description.AppendLine("Exception :");
            Description.AppendLine(Log["Exception"].ToString());
            Description.AppendLine("");

            Description.AppendLine("Source :");
            Description.AppendLine(Log["Source"].ToString());
            Description.AppendLine("");

            Description.AppendLine("TargetSite :");
            Description.AppendLine(Log["TargetSite"].ToString());
            Description.AppendLine("");

            Description.AppendLine("Stack :");
            Description.AppendLine(Log["Stack"].ToString());
            Description.AppendLine("");

            txtErrorDetails.Text = Description.ToString();
        }
    }
}
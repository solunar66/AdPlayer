using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XML;

namespace PLAY
{
    public partial class Form_Config : Form
    {
        private Config config;
        private DateTimePicker dp;
        private ComboBox cb_mode;
        private ComboBox cb_type;
        private NumericUpDown nu;

        public Form_Config(Config cfg)
        {
            InitializeComponent();

            config = cfg;

            dp = new DateTimePicker();
            dp.Format = DateTimePickerFormat.Custom;
            dp.CustomFormat = "HH 时 mm 分 ss 秒";
            dp.ShowUpDown = true;
            dp.Visible = false;
            dataGridView1.Controls.Add(dp);

            cb_mode = new ComboBox();
            cb_mode.Items.Add(PlayMode.sequencial);
            cb_mode.Items.Add(PlayMode.random);
            cb_mode.Visible = false;
            dataGridView1.Controls.Add(cb_mode);

            cb_type = new ComboBox();
            cb_type.Items.Add(ContentType.dir);
            cb_type.Items.Add(ContentType.video);
            cb_type.Items.Add(ContentType.powerpoint);
            cb_type.Visible = false;
            dataGridView1.Controls.Add(cb_type);

            nu = new NumericUpDown();
            nu.Minimum = 0;
            nu.Maximum = 600;
            nu.Visible = false;
            dataGridView1.Controls.Add(nu);

            XML2Tree();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {

        }

        private void button_update_Click(object sender, EventArgs e)
        {

        }

        private void button_delete_Click(object sender, EventArgs e)
        {

        }

        private void XML2Tree()
        {
            for (int i = 0; i < config.datesheets.Count; i++)
            {
                DateSheet datesheet = config.datesheets[i];

                TreeNode rootnode = new TreeNode();
                rootnode.Name = i.ToString();
                rootnode.Text = "日期: " + datesheet.startDate.ToShortDateString() + " 至 " + datesheet.endDate.ToShortDateString();
                treeView1.Nodes.Add(rootnode);
                for (int j = 0; j < datesheet.timesheets.Count; j++)
                {
                    TimeSheet timesheet = datesheet.timesheets[j];

                    TreeNode subnode = new TreeNode();
                    subnode.Name = j.ToString();
                    subnode.Text = "时间: " + timesheet.startTime.ToShortTimeString() + " 至 " + timesheet.endTime.ToShortTimeString();
                    rootnode.Nodes.Add(subnode);
                    for (int k = 0; k < timesheet.contents.Count; k++)
                    {
                        Content content = timesheet.contents[k];

                        TreeNode itemnode = new TreeNode();
                        itemnode.Name = k.ToString();
                        itemnode.Text = "文件: 类型:" + content.type.ToString() + ", 停留: " + content.duration.ToString() + ", 名称: " + content.file;
                        subnode.Nodes.Add(itemnode);
                    }
                }
            }
        }

        private void display(TreeNode node)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            switch (node.Level)
            {
                case 0:
                    dataGridView1.Columns.Add("startdate", "起始日期");
                    dataGridView1.Columns.Add("enddate", "终止日期");
                    DataGridViewCheckBoxColumn colMon = new DataGridViewCheckBoxColumn();
                    colMon.Name = "mon";
                    colMon.Width = 50;
                    colMon.HeaderText = "周一";
                    dataGridView1.Columns.Add(colMon);
                    DataGridViewCheckBoxColumn colTue = new DataGridViewCheckBoxColumn();
                    colTue.Name = "tue";
                    colTue.Width = 50;
                    colTue.HeaderText = "周二";
                    dataGridView1.Columns.Add(colTue);
                    DataGridViewCheckBoxColumn colWed = new DataGridViewCheckBoxColumn();
                    colWed.Name = "wed";
                    colWed.Width = 50;
                    colWed.HeaderText = "周三";
                    dataGridView1.Columns.Add(colWed);
                    DataGridViewCheckBoxColumn colThus = new DataGridViewCheckBoxColumn();
                    colThus.Name = "thu";
                    colThus.Width = 50;
                    colThus.HeaderText = "周四";
                    dataGridView1.Columns.Add(colThus);
                    DataGridViewCheckBoxColumn colFri = new DataGridViewCheckBoxColumn();
                    colFri.Name = "fri";
                    colFri.Width = 50;
                    colFri.HeaderText = "周五";
                    dataGridView1.Columns.Add(colFri);
                    DataGridViewCheckBoxColumn colSat = new DataGridViewCheckBoxColumn();
                    colSat.Name = "sat";
                    colSat.Width = 50;
                    colSat.HeaderText = "周六";
                    dataGridView1.Columns.Add(colSat);
                    DataGridViewCheckBoxColumn colSun = new DataGridViewCheckBoxColumn();
                    colSun.Name = "sun";
                    colSun.Width = 50;
                    colSun.HeaderText = "周日";
                    dataGridView1.Columns.Add(colSun);

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[0].Cells[0].Value = config.datesheets[node.Index].startDate.ToShortDateString();
                    dataGridView1.Rows[0].Cells[0].ToolTipText = "cc";
                    dataGridView1.Rows[0].Cells[1].Value = config.datesheets[node.Index].endDate.ToShortDateString();
                    dataGridView1.Rows[0].Cells[1].ToolTipText = "cc";
                    dataGridView1.Rows[0].Cells[2].Value = config.datesheets[node.Index].Mon;
                    dataGridView1.Rows[0].Cells[3].Value = config.datesheets[node.Index].Tus;
                    dataGridView1.Rows[0].Cells[4].Value = config.datesheets[node.Index].Wed;
                    dataGridView1.Rows[0].Cells[5].Value = config.datesheets[node.Index].Thu;
                    dataGridView1.Rows[0].Cells[6].Value = config.datesheets[node.Index].Fri;
                    dataGridView1.Rows[0].Cells[7].Value = config.datesheets[node.Index].Sat;
                    dataGridView1.Rows[0].Cells[8].Value = config.datesheets[node.Index].Sun;
                    break;

                case 1:
                    dataGridView1.Columns.Add("starttime", "起始时间");
                    dataGridView1.Columns[0].Width = 150;
                    dataGridView1.Columns.Add("endtime", "终止时间");
                    dataGridView1.Columns[1].Width = 150;
                    dataGridView1.Columns.Add("mode", "播放模式");

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[0].Cells[0].Value = config.datesheets[node.Parent.Index].timesheets[node.Index].startTime.ToShortTimeString();
                    dataGridView1.Rows[0].Cells[1].Value = config.datesheets[node.Parent.Index].timesheets[node.Index].endTime.ToShortTimeString();
                    dataGridView1.Rows[0].Cells[2].Value = config.datesheets[node.Parent.Index].timesheets[node.Index].mode.ToString();
                    break;

                case 2:
                    dataGridView1.Columns.Add("type", "媒体类型");
                    dataGridView1.Columns[0].Width = 80;
                    dataGridView1.Columns.Add("intv", "幻灯页间隔(秒)");
                    dataGridView1.Columns[1].Width = 80;
                    dataGridView1.Columns.Add("file", "媒体文件");
                    dataGridView1.Columns[2].Width = 300;

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[0].Cells[0].Value = config.datesheets[node.Parent.Parent.Index].timesheets[node.Parent.Index].contents[node.Index].type.ToString();
                    dataGridView1.Rows[0].Cells[1].Value = config.datesheets[node.Parent.Parent.Index].timesheets[node.Parent.Index].contents[node.Index].duration.ToString();
                    dataGridView1.Rows[0].Cells[2].Value = config.datesheets[node.Parent.Parent.Index].timesheets[node.Parent.Index].contents[node.Index].file;
                    break;
                
                default:
                    break;
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            display(e.Node);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1[e.ColumnIndex,e.RowIndex];
            if (cell.Value == null) return;
            if (cell.OwningColumn.Name == "starttime" || cell.OwningColumn.Name == "endtime")
            {
                Rectangle _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                dp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                dp.Visible = true;
                dp.Value = Convert.ToDateTime(cell.Value);
            }
            else if (cell.OwningColumn.Name == "mode")
            {
                Rectangle _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                cb_mode.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                cb_mode.Location = new Point(_Rectangle.X, _Rectangle.Y);
                cb_mode.Visible = true;
                if (cell.Value.ToString() == PlayMode.random.ToString()) cb_mode.SelectedIndex = (int)PlayMode.random;
                if (cell.Value.ToString() == PlayMode.sequencial.ToString()) cb_mode.SelectedIndex = (int)PlayMode.sequencial;
            }
            else if (cell.OwningColumn.Name == "type")
            {
                Rectangle _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                cb_type.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                cb_type.Location = new Point(_Rectangle.X, _Rectangle.Y);
                cb_type.Visible = true;
                if (cell.Value.ToString() == ContentType.dir.ToString()) cb_type.SelectedIndex = (int)ContentType.dir;
                if (cell.Value.ToString() == ContentType.video.ToString()) cb_type.SelectedIndex = (int)ContentType.video;
                if (cell.Value.ToString() == ContentType.powerpoint.ToString()) cb_type.SelectedIndex = (int)ContentType.powerpoint;
            }
            else if (cell.OwningColumn.Name == "intv")
            {
                Rectangle _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                nu.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                nu.Location = new Point(_Rectangle.X, _Rectangle.Y);
                nu.Visible = true;
                nu.Value = decimal.Parse(cell.Value.ToString());
            }
            else 
            { }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            if (cell.Value == null) return;
            if (cell.OwningColumn.Name == "starttime" || cell.OwningColumn.Name == "endtime")
            {
                cell.Value = dp.Value.ToShortTimeString();
                dp.Visible = false;
            }
            else if (cell.OwningColumn.Name == "mode")
            {
                if (cb_mode.SelectedItem != null) cell.Value = cb_mode.SelectedItem.ToString();
                cb_mode.Visible = false;
            }
            else if (cell.OwningColumn.Name == "type")
            {
                if (cb_type.SelectedItem != null) cell.Value = cb_type.SelectedItem.ToString();
                cb_type.Visible = false;
            }
            else if (cell.OwningColumn.Name == "intv")
            {
                cell.Value = nu.Value.ToString();
                nu.Visible = false;
            }
            else
            { }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];

            if (cell.OwningColumn.Name == "startdate" || 
                cell.OwningColumn.Name == "enddate")
            {

                CalenderCell cc = new CalenderCell(cell);
                cc.Show();
                cc.DateSelected += new DateRangeEventHandler(monthCalendar_DateSelected);
                dataGridView1.Controls.Add(cc);
            }
            else if (cell.OwningColumn.Name == "file")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    cell.Value = ofd.FileName;
                }
            }
            else
            { }
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            CalenderCell m = (CalenderCell)sender;
            DateTime d1, d2;
            d1 = m.SelectionStart;
            d2 = m.SelectionEnd;
            if (d1.Equals(d2))
                m.cell.Value = d1.ToShortDateString();
            else
                //m.cell.Value = d1.ToLongDateString() + "-" + d2.ToLongDateString();
            dataGridView1.Controls.Remove(m);
            dataGridView1.Refresh();
            m.Dispose();
            m = null;
        }
    }
}

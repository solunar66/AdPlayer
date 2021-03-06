﻿using System;
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

#region fields

        private XMLInfo xml;
        private Config config;
        private DateTimePicker dp;
        private ComboBox cb_mode;
        private ComboBox cb_type;
        private NumericUpDown nu;

        private TreeNode cur_node;

        private string error;

#endregion

#region constructor

        public Form_Config(XMLInfo x)
        {
            InitializeComponent();

            xml = x;
            xml.ReadPlayConfig(ref config, false, ref error);

            dp = new DateTimePicker();
            dp.Format = DateTimePickerFormat.Custom;
            dp.CustomFormat = "HH 时 mm 分 ss 秒";
            dp.ShowUpDown = true;
            dp.Visible = false;
            dataGridView1.Controls.Add(dp);

            cb_mode = new ComboBox();
            //cb_mode.Items.Add(PlayMode.sequencial);
            //cb_mode.Items.Add(PlayMode.random);
            cb_mode.Items.Add("顺序播放");
            cb_mode.Items.Add("随机播放");
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

#endregion

#region form events handler

        private void button_ok_Click(object sender, EventArgs e)
        {
            string err = xml.SavePlayConfig(config);
            if (err.Equals(string.Empty))
            {
                MessageBox.Show("保存配置成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("保存配置失败！\r\n" + err, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出？\n\n(所有未写入配置文件的修改都将失效)", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                this.Close();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;
            
            TreeNode node = treeView1.SelectedNode;

            try
            {
                switch (node.Level)
                {
                    case 0:
                        DateTime startDate = DateTime.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
                        DateTime endDate = DateTime.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
                        if (startDate.Date >= endDate.Date)
                        {
                            MessageBox.Show("起始日期须早于终止日期！请检查输入！", "日期校验异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        DateSheet dt = new DateSheet();
                        dt.startDate = startDate;
                        dt.endDate = endDate;
                        dt.Mon = (bool)dataGridView1.Rows[0].Cells[2].Value;
                        dt.Tue = (bool)dataGridView1.Rows[0].Cells[3].Value;
                        dt.Wed = (bool)dataGridView1.Rows[0].Cells[4].Value;
                        dt.Thu = (bool)dataGridView1.Rows[0].Cells[5].Value;
                        dt.Fri = (bool)dataGridView1.Rows[0].Cells[6].Value;
                        dt.Sat = (bool)dataGridView1.Rows[0].Cells[7].Value;
                        dt.Sun = (bool)dataGridView1.Rows[0].Cells[8].Value;
                        dt.timesheets = config.datesheets[node.Index].timesheets;
                        config.datesheets[node.Index] = dt;
                        cur_node.Text = "日期: " + dt.startDate.ToShortDateString() + " 至 " + dt.endDate.ToShortDateString();
                        break;

                    case 1:
                        DateTime startTime = DateTime.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
                        DateTime endTime = DateTime.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
                        if (startTime.TimeOfDay >= endTime.TimeOfDay)
                        {
                            MessageBox.Show("起始时间须早于终止时间！请检查输入！", "时间校验异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        TimeSheet ts = new TimeSheet();
                        ts.startTime = startTime;
                        ts.endTime = endTime;
                        ts.mode = dataGridView1.Rows[0].Cells[2].Value.ToString() == "随机播放" ? PlayMode.random : PlayMode.sequencial;
                        ts.contents = config.datesheets[node.Parent.Index].timesheets[node.Index].contents;
                        config.datesheets[node.Parent.Index].timesheets[node.Index] = ts;
                        cur_node.Text = "时间: " + ts.startTime.ToLongTimeString() + " 至 " + ts.endTime.ToLongTimeString() + ", 播放模式: " + ts.mode;
                        break;

                    case 2:
                        Content ct = new Content();
                        if (dataGridView1.Rows[0].Cells[0].Value.ToString().Equals("dir")) ct.type = ContentType.dir;
                        if (dataGridView1.Rows[0].Cells[0].Value.ToString().Equals("powerpoint")) ct.type = ContentType.powerpoint;
                        if (dataGridView1.Rows[0].Cells[0].Value.ToString().Equals("video")) ct.type = ContentType.video;
                        ct.duration = int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());
                        ct.file = dataGridView1.Rows[0].Cells[2].Value.ToString();
                        config.datesheets[node.Parent.Parent.Index].timesheets[node.Parent.Index].contents[node.Index] = ct;
                        cur_node.Text = "文件: 类型:" + ct.type.ToString() + ", 停留: " + ct.duration.ToString() + ", 名称: " + ct.file;
                        break;

                    default:
                        break;
                }
                label_update_ok.Text = "保存成功！";
                label_update_ok.ForeColor = Color.Black;
            }
            catch
            {
                label_update_ok.Text = "修改失败！请检查输入！";
                label_update_ok.ForeColor = Color.Red;
            }

            label_update_ok.Visible = true;
        }

#endregion

#region treeview events handler

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == cur_node)
            { }
            else
            {
                label_update_ok.Visible = false;
                button_update.Visible = false;
                clear();
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            display(e.Node);
        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = treeView1.GetNodeAt(e.X, e.Y);
                if (node != null)
                {
                    treeView1.SelectedNode = node;
                    contextMenuStrip1.Show(treeView1, e.X, e.Y);
                }
            }
        }

        private void toolStripMenuItem_MoveUp_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node.Index == 0) return;

            TreeNode cloneNode = (TreeNode)node.Clone();

            switch (node.Level)
            {
                case 0:
                    config.datesheets.Reverse(node.Index - 1, 2);
                    treeView1.Nodes.Remove(node);
                    treeView1.Nodes.Insert(cloneNode.Index - 1, cloneNode);
                    break;
                case 1:
                    config.datesheets[node.Parent.Index].timesheets.Reverse(node.Index - 1, 2);
                    node.Parent.Nodes.Insert(node.Index - 1, cloneNode);
                    node.Parent.Nodes.Remove(node);
                    break;
                case 2:
                    config.datesheets[node.Parent.Parent.Index].timesheets[node.Parent.Index].contents.Reverse(node.Index - 1, 2);
                    node.Parent.Nodes.Insert(node.Index - 1, cloneNode);
                    node.Parent.Nodes.Remove(node);
                    break;
            }
        }

        private void toolStripMenuItem_MoveDown_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node.NextNode == null) return;

            TreeNode cloneNode = (TreeNode)node.Clone();

            switch (node.Level)
            {
                case 0:
                    config.datesheets.Reverse(node.Index, 2);
                    treeView1.Nodes.Insert(node.Index + 2, cloneNode);
                    treeView1.Nodes.Remove(node);
                    break;
                case 1:
                    config.datesheets[node.Parent.Index].timesheets.Reverse(node.Index, 2);
                    node.Parent.Nodes.Insert(node.Index + 2, cloneNode);
                    node.Parent.Nodes.Remove(node);
                    break;
                case 2:
                    config.datesheets[node.Parent.Parent.Index].timesheets[node.Parent.Index].contents.Reverse(node.Index, 2);
                    node.Parent.Nodes.Insert(node.Index + 2, cloneNode);
                    node.Parent.Nodes.Remove(node);
                    break;
                default:
                    throw new Exception();
            }
        }

        private void toolStripMenuItem_Delete_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
                        
            if (node.PrevNode == null && node.NextNode == null)
            {
                MessageBox.Show("本级最后一项配置不可删除！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("确认删除该项？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (node.Level)
                {
                    case 0:
                        config.datesheets.RemoveAt(node.Index);
                        break;
                    case 1:
                        config.datesheets[node.Parent.Index].timesheets.RemoveAt(node.Index);
                        break;
                    case 2:
                        config.datesheets[node.Parent.Parent.Index].timesheets[node.Parent.Index].contents.RemoveAt(node.Index);
                        break;
                    default:
                        throw new Exception();
                }
                treeView1.SelectedNode.Remove();
            }
        }

        private void ToolStripMenuItem_Add_Date_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Add(0);
        }

        private void ToolStripMenuItem_Add_Time_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Add(1);
        }

        private void ToolStripMenuItem_Add_Content_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Add(2);
        }

        private void ToolStripMenuItem_Add(int level)
        {
            TreeNode node = treeView1.SelectedNode;
            TreeNode newNode;

            try
            {
                switch (level)
                {
                    case 0:
                        config.datesheets.Insert(node.Index, new DateSheet());
                        newNode = treeView1.Nodes.Insert(node.Index, "New Node");
                        break;
                    case 1:
                        config.datesheets[node.Parent.Index].timesheets.Insert(node.Index, new TimeSheet());
                        newNode = node.Parent.Nodes.Insert(node.Index, "New Node");
                        break;
                    case 2:
                        config.datesheets[node.Parent.Parent.Index].timesheets[node.Parent.Index].contents.Insert(node.Index, new Content());
                        newNode = node.Parent.Nodes.Insert(node.Index, "New Node");
                        break;
                    default:
                        throw new Exception();
                }
                treeView1.SelectedNode = newNode;

                display(newNode);
            }
            catch
            {
                MessageBox.Show("请先完成新添加配置项目内容，再添加新项目。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

#endregion

#region datagridview events handler

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
                if (cell.Value.ToString() == "随机播放") cb_mode.SelectedIndex = (int)PlayMode.random;
                if (cell.Value.ToString() == "顺序播放") cb_mode.SelectedIndex = (int)PlayMode.sequencial;
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
            { cell.ReadOnly = false; }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            if (cell.Value == null) return;
            if (cell.OwningColumn.Name == "starttime" || cell.OwningColumn.Name == "endtime")
            {
                cell.Value = dp.Value.ToLongTimeString();
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
                if (dataGridView1[e.ColumnIndex - 2, e.RowIndex].Value.ToString().Equals("dir"))
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        cell.Value = fbd.SelectedPath;
                    }
                    
                }
                else
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        cell.Value = ofd.FileName;
                    }
                }
            }
            else
            { }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name.Length == 3) { }
            else { e.Cancel = true; }
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            CalenderCell m = (CalenderCell)sender;
            DateTime d1/*, d2*/;
            d1 = m.SelectionStart;
            //d2 = m.SelectionEnd;
            //if (d1.Equals(d2))
                m.cell.Value = d1.ToShortDateString();
            //else
                //m.cell.Value = d1.ToLongDateString() + "-" + d2.ToLongDateString();
            dataGridView1.Controls.Remove(m);
            dataGridView1.Refresh();
            m.Dispose();
            m = null;
        }

#endregion

#region functions
        
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
                    string mode = timesheet.mode == PlayMode.random ? "随机播放" : "顺序播放";
                    subnode.Text = "时间: " + timesheet.startTime.ToLongTimeString() + " 至 " + timesheet.endTime.ToLongTimeString() + ", 播放模式: " + mode;
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
            CreateDataGridView(node.Level);

            switch (node.Level)
            {
                case 0:
                    dataGridView1.Rows[0].Cells[0].Value = config.datesheets[node.Index].startDate.ToShortDateString();
                    dataGridView1.Rows[0].Cells[1].Value = config.datesheets[node.Index].endDate.ToShortDateString();
                    dataGridView1.Rows[0].Cells[2].Value = config.datesheets[node.Index].Mon;
                    dataGridView1.Rows[0].Cells[3].Value = config.datesheets[node.Index].Tue;
                    dataGridView1.Rows[0].Cells[4].Value = config.datesheets[node.Index].Wed;
                    dataGridView1.Rows[0].Cells[5].Value = config.datesheets[node.Index].Thu;
                    dataGridView1.Rows[0].Cells[6].Value = config.datesheets[node.Index].Fri;
                    dataGridView1.Rows[0].Cells[7].Value = config.datesheets[node.Index].Sat;
                    dataGridView1.Rows[0].Cells[8].Value = config.datesheets[node.Index].Sun;
                    break;

                case 1:
                    dataGridView1.Rows[0].Cells[0].Value = config.datesheets[node.Parent.Index].timesheets[node.Index].startTime.ToLongTimeString();
                    dataGridView1.Rows[0].Cells[1].Value = config.datesheets[node.Parent.Index].timesheets[node.Index].endTime.ToLongTimeString();
                    dataGridView1.Rows[0].Cells[2].Value = config.datesheets[node.Parent.Index].timesheets[node.Index].mode == PlayMode.random ? "随机播放" : "顺序播放";
                    break;

                case 2:
                    dataGridView1.Rows[0].Cells[0].Value = config.datesheets[node.Parent.Parent.Index].timesheets[node.Parent.Index].contents[node.Index].type.ToString();
                    dataGridView1.Rows[0].Cells[1].Value = config.datesheets[node.Parent.Parent.Index].timesheets[node.Parent.Index].contents[node.Index].duration.ToString();
                    dataGridView1.Rows[0].Cells[2].Value = config.datesheets[node.Parent.Parent.Index].timesheets[node.Parent.Index].contents[node.Index].file;
                    break;

                default:
                    break;
            }

            button_update.Visible = true;

            cur_node = node;
        }

        private void clear()
        { 
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }

        private void CreateDataGridView(int index)
        {
            clear();

            switch (index)
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
                    break;

                case 1:
                    dataGridView1.Columns.Add("starttime", "起始时间");
                    dataGridView1.Columns[0].Width = 150;
                    dataGridView1.Columns.Add("endtime", "终止时间");
                    dataGridView1.Columns[1].Width = 150;
                    dataGridView1.Columns.Add("mode", "播放模式");
                    break;

                case 2:
                    dataGridView1.Columns.Add("type", "媒体类型");
                    dataGridView1.Columns[0].Width = 80;
                    dataGridView1.Columns.Add("intv", "幻灯页间隔(秒)");
                    dataGridView1.Columns[1].Width = 80;
                    dataGridView1.Columns.Add("file", "媒体文件");
                    dataGridView1.Columns[2].Width = 300;
                    break;

                default:
                    break;
            }
            dataGridView1.Rows.Add();
        }

#endregion
    }

#region customize datagridviewcell
    class CalenderCell : MonthCalendar
    {
        public DataGridViewCell cell = null;
        public CalenderCell(DataGridViewCell c)
        {
            cell = c;
        }
    }
#endregion
}

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

        public Form_Config(Config cfg)
        {
            InitializeComponent();

            config = cfg;

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
                    colMon.Width = 50;
                    colMon.HeaderText = "周一";
                    dataGridView1.Columns.Add(colMon);
                    DataGridViewCheckBoxColumn colTue = new DataGridViewCheckBoxColumn();
                    colTue.Width = 50;
                    colTue.HeaderText = "周二";
                    dataGridView1.Columns.Add(colTue);
                    DataGridViewCheckBoxColumn colWed = new DataGridViewCheckBoxColumn();
                    colWed.Width = 50;
                    colWed.HeaderText = "周三";
                    dataGridView1.Columns.Add(colWed);
                    DataGridViewCheckBoxColumn colThus = new DataGridViewCheckBoxColumn();
                    colThus.Width = 50;
                    colThus.HeaderText = "周四";
                    dataGridView1.Columns.Add(colThus);
                    DataGridViewCheckBoxColumn colFri = new DataGridViewCheckBoxColumn();
                    colFri.Width = 50;
                    colFri.HeaderText = "周五";
                    dataGridView1.Columns.Add(colFri);
                    DataGridViewCheckBoxColumn colSat = new DataGridViewCheckBoxColumn();
                    colSat.Width = 50;
                    colSat.HeaderText = "周六";
                    dataGridView1.Columns.Add(colSat);
                    DataGridViewCheckBoxColumn colSun = new DataGridViewCheckBoxColumn();
                    colSun.Width = 50;
                    colSun.HeaderText = "周日";
                    dataGridView1.Columns.Add(colSun);

                    dataGridView1.Rows.Add();
                    break;

                case 1:
                    break;

                case 2:
                    break;
                
                default:
                    break;
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            display(e.Node);
        }
    }
}

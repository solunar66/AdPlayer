﻿namespace PLAY
{
    partial class Form_Config
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
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_MoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_MoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Add_Date = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Add_Time = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Add_Content = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_update_ok = new System.Windows.Forms.Label();
            this.button_update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(378, 432);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(124, 25);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "保存并退出";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(508, 432);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(124, 25);
            this.button_cancel.TabIndex = 0;
            this.button_cancel.Text = "放弃修改";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 268);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(644, 158);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(644, 261);
            this.treeView1.TabIndex = 2;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_MoveUp,
            this.toolStripMenuItem_MoveDown,
            this.toolStripSeparator1,
            this.toolStripMenuItem_Add,
            this.toolStripMenuItem_Delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 98);
            // 
            // toolStripMenuItem_MoveUp
            // 
            this.toolStripMenuItem_MoveUp.Name = "toolStripMenuItem_MoveUp";
            this.toolStripMenuItem_MoveUp.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem_MoveUp.Text = "上移";
            this.toolStripMenuItem_MoveUp.Click += new System.EventHandler(this.toolStripMenuItem_MoveUp_Click);
            // 
            // toolStripMenuItem_MoveDown
            // 
            this.toolStripMenuItem_MoveDown.Name = "toolStripMenuItem_MoveDown";
            this.toolStripMenuItem_MoveDown.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem_MoveDown.Text = "下移";
            this.toolStripMenuItem_MoveDown.Click += new System.EventHandler(this.toolStripMenuItem_MoveDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(95, 6);
            // 
            // toolStripMenuItem_Add
            // 
            this.toolStripMenuItem_Add.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Add_Date,
            this.ToolStripMenuItem_Add_Time,
            this.ToolStripMenuItem_Add_Content});
            this.toolStripMenuItem_Add.Name = "toolStripMenuItem_Add";
            this.toolStripMenuItem_Add.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem_Add.Text = "添加";
            // 
            // ToolStripMenuItem_Add_Date
            // 
            this.ToolStripMenuItem_Add_Date.Name = "ToolStripMenuItem_Add_Date";
            this.ToolStripMenuItem_Add_Date.Size = new System.Drawing.Size(134, 22);
            this.ToolStripMenuItem_Add_Date.Text = "日期时间段";
            this.ToolStripMenuItem_Add_Date.Click += new System.EventHandler(this.ToolStripMenuItem_Add_Date_Click);
            // 
            // ToolStripMenuItem_Add_Time
            // 
            this.ToolStripMenuItem_Add_Time.Name = "ToolStripMenuItem_Add_Time";
            this.ToolStripMenuItem_Add_Time.Size = new System.Drawing.Size(134, 22);
            this.ToolStripMenuItem_Add_Time.Text = "每天时间段";
            this.ToolStripMenuItem_Add_Time.Click += new System.EventHandler(this.ToolStripMenuItem_Add_Time_Click);
            // 
            // ToolStripMenuItem_Add_Content
            // 
            this.ToolStripMenuItem_Add_Content.Name = "ToolStripMenuItem_Add_Content";
            this.ToolStripMenuItem_Add_Content.Size = new System.Drawing.Size(134, 22);
            this.ToolStripMenuItem_Add_Content.Text = "播放内容项";
            this.ToolStripMenuItem_Add_Content.Click += new System.EventHandler(this.ToolStripMenuItem_Add_Content_Click);
            // 
            // toolStripMenuItem_Delete
            // 
            this.toolStripMenuItem_Delete.Name = "toolStripMenuItem_Delete";
            this.toolStripMenuItem_Delete.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem_Delete.Text = "删除";
            this.toolStripMenuItem_Delete.Click += new System.EventHandler(this.toolStripMenuItem_Delete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_update_ok);
            this.panel1.Controls.Add(this.button_update);
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.button_ok);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 498);
            this.panel1.TabIndex = 6;
            // 
            // label_update_ok
            // 
            this.label_update_ok.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label_update_ok.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_update_ok.ForeColor = System.Drawing.Color.Red;
            this.label_update_ok.Location = new System.Drawing.Point(408, 395);
            this.label_update_ok.Name = "label_update_ok";
            this.label_update_ok.Size = new System.Drawing.Size(143, 20);
            this.label_update_ok.TabIndex = 7;
            this.label_update_ok.Text = "修改成功！";
            this.label_update_ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_update_ok.Visible = false;
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(557, 392);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(75, 25);
            this.button_update.TabIndex = 5;
            this.button_update.Text = "确认修改";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Visible = false;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // Form_Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 498);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_Config";
            this.ShowInTaskbar = false;
            this.Text = "播放配置";
            this.Click += new System.EventHandler(this.button_update_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveUp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MoveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Delete;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Label label_update_ok;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Add;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Add_Date;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Add_Time;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Add_Content;
    }
}
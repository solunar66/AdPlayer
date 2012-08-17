namespace FtpClient
{
    partial class Form_FTP
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
            this.tvFiles = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.上移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_login = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.button_upload = new System.Windows.Forms.Button();
            this.label_file = new System.Windows.Forms.Label();
            this.button_file = new System.Windows.Forms.Button();
            this.button_quit = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvFiles
            // 
            this.tvFiles.ContextMenuStrip = this.contextMenuStrip1;
            this.tvFiles.Location = new System.Drawing.Point(12, 38);
            this.tvFiles.Name = "tvFiles";
            this.tvFiles.Size = new System.Drawing.Size(468, 162);
            this.tvFiles.TabIndex = 0;
            this.tvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvFiles_DragDrop);
            this.tvFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvFiles_MouseDown);
            this.tvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvFiles_DragEnter);
            this.tvFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvFiles_ItemDrag);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上移ToolStripMenuItem,
            this.下移ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            // 
            // 上移ToolStripMenuItem
            // 
            this.上移ToolStripMenuItem.Name = "上移ToolStripMenuItem";
            this.上移ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.上移ToolStripMenuItem.Text = "上移";
            this.上移ToolStripMenuItem.Click += new System.EventHandler(this.上移ToolStripMenuItem_Click);
            // 
            // 下移ToolStripMenuItem
            // 
            this.下移ToolStripMenuItem.Name = "下移ToolStripMenuItem";
            this.下移ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.下移ToolStripMenuItem.Text = "下移";
            this.下移ToolStripMenuItem.Click += new System.EventHandler(this.下移ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(12, 11);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 21);
            this.button_login.TabIndex = 1;
            this.button_login.Text = "连接服务器";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // label_status
            // 
            this.label_status.AutoEllipsis = true;
            this.label_status.Location = new System.Drawing.Point(93, 16);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(387, 17);
            this.label_status.TabIndex = 2;
            // 
            // button_upload
            // 
            this.button_upload.Location = new System.Drawing.Point(12, 205);
            this.button_upload.Name = "button_upload";
            this.button_upload.Size = new System.Drawing.Size(75, 21);
            this.button_upload.TabIndex = 3;
            this.button_upload.Text = "上传";
            this.button_upload.UseVisualStyleBackColor = true;
            this.button_upload.Click += new System.EventHandler(this.button_upload_Click);
            // 
            // label_file
            // 
            this.label_file.AutoEllipsis = true;
            this.label_file.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_file.Location = new System.Drawing.Point(93, 205);
            this.label_file.Name = "label_file";
            this.label_file.Size = new System.Drawing.Size(358, 21);
            this.label_file.TabIndex = 4;
            this.label_file.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_file
            // 
            this.button_file.Location = new System.Drawing.Point(455, 205);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(25, 21);
            this.button_file.TabIndex = 5;
            this.button_file.Text = "...";
            this.button_file.UseVisualStyleBackColor = true;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // button_quit
            // 
            this.button_quit.Location = new System.Drawing.Point(405, 233);
            this.button_quit.Name = "button_quit";
            this.button_quit.Size = new System.Drawing.Size(75, 21);
            this.button_quit.TabIndex = 6;
            this.button_quit.Text = "退出";
            this.button_quit.UseVisualStyleBackColor = true;
            this.button_quit.Click += new System.EventHandler(this.button_quit_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 232);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(387, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 7;
            // 
            // Form_FTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 265);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_quit);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.button_file);
            this.Controls.Add(this.button_upload);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.tvFiles);
            this.Controls.Add(this.label_status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_FTP";
            this.Text = "AdPlayer FTP Client";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvFiles;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button button_upload;
        private System.Windows.Forms.Label label_file;
        private System.Windows.Forms.Button button_file;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button_quit;
        private System.Windows.Forms.ToolStripMenuItem 上移ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下移ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}


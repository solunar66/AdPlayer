using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices; 

namespace FtpClient
{
    public partial class Form_FTP : Form
    {
        private string Config = @"config.ini";
        private string IP, User, Passwd;

        private Point Position = new Point(0, 0);

        private FtpClient ftpClient = new FtpClient();

        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);

        public Form_FTP()
        {
            InitializeComponent();

            Config = System.IO.Directory.GetCurrentDirectory() + "\\" + Config;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            IP = "";
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString("FTP server", "IP", "", temp, 255, Config);
            IP = temp.ToString();
            GetPrivateProfileString("FTP server", "User", "", temp, 255, Config);
            User = temp.ToString();
            GetPrivateProfileString("FTP server", "Passwd", "", temp, 255, Config);
            Passwd = temp.ToString();
            if (IP.Equals(string.Empty) || User.Equals(string.Empty) || Passwd.Equals(string.Empty))
            {
                MessageBox.Show("配置文件读取错误！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ftpClient.Server = IP;
            ftpClient.Username = User;
            ftpClient.Password = Passwd;

            try
            {
                ftpClient.Login();
                label_status.Text = "FTP服务器已连接.";
            }
            catch (Exception ex)
            {
                label_status.Text = "FTP服务器连接错误！Error: " + ex.Message;
            }

            tvFiles.Nodes.Clear();

            string[] filelist = ftpClient.GetFileList();
            string[] filename;
            foreach (string file in filelist)
            {
                if (file != "" && file.IndexOf("<DIR>") == -1)
                {
                    filename = file.Split(' ');
                    for (int i=4; i<filename.Length; i++)
                    {
                        filename[3] += " "+filename[i];
                    }
                    tvFiles.Nodes.Add(filename[3]);
                }
            }
            ReNameFilesInSeq();
        }

        private void tvFiles_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode myNode = null;  
            if (e.Data.GetDataPresent(typeof(TreeNode)))  
            {  
                myNode = (TreeNode)(e.Data.GetData(typeof(TreeNode)));
            }  
            else  
            {  
                MessageBox.Show("error!");  
            }  

            Position.X = e.X;  
            Position.Y = e.Y;  
            Position = tvFiles.PointToClient(Position);

            TreeNode dropNode = this.tvFiles.GetNodeAt(Position); 

            if (dropNode != null 
                && dropNode != myNode)  
            {  
                TreeNode dragNode = myNode; 
                myNode.Remove();  
                tvFiles.Nodes.Insert(dropNode.Index, myNode);
            }
 
            if (dropNode == null)  
            {  
                TreeNode DragNode = myNode;  
                myNode.Remove();  
                tvFiles.Nodes.Add(DragNode);  
            }
        }

        private void tvFiles_DragEnter(object sender, DragEventArgs e)
        {                
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tvFiles_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);  
        }

        private void tvFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tvFiles.SelectedNode = null;
            }
            else if (e.Button == MouseButtons.Right)
            {
                Position.X = e.X;
                Position.Y = e.Y;
                tvFiles.SelectedNode = tvFiles.GetNodeAt(Position);
            }
        }

        private void button_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 上移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = tvFiles.GetNodeAt(Position);
            if (node.Index == 0) return;

            //tvFiles.Nodes.Remove(node);
            //tvFiles.Nodes.Insert(node.Index - 1, node);
            //tvFiles.SelectedNode = node;

            try
            {
                string sIndex = node.Text.Substring(0, 2);
                string orgName = tvFiles.Nodes[node.Index - 1].Text.Substring(0, 2) + node.Text.Substring(2);
                ftpClient.RenameFile(tvFiles.Nodes[node.Index].Text, orgName, true);
                string tarName = sIndex + tvFiles.Nodes[node.Index - 1].Text.Substring(2);
                ftpClient.RenameFile(tvFiles.Nodes[node.Index - 1].Text, tarName, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("\"" + node.Text + "\"下移失败！\r\r" + ex.Message, "文件排序", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            button_login_Click(this, null);
        }

        private void 下移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = tvFiles.GetNodeAt(Position);
            if (node.NextNode == null) return;

            //tvFiles.Nodes.Remove(node);
            //tvFiles.Nodes.Insert(node.Index + 1, node);
            //tvFiles.SelectedNode = node;

            try 
            {
                string sIndex = node.Text.Substring(0, 2);
                string orgName = tvFiles.Nodes[node.Index+1].Text.Substring(0,2) + node.Text.Substring(2);
                ftpClient.RenameFile(tvFiles.Nodes[node.Index].Text, orgName, true);
                string tarName = sIndex + tvFiles.Nodes[node.Index + 1].Text.Substring(2);
                ftpClient.RenameFile(tvFiles.Nodes[node.Index + 1].Text, tarName, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("\"" + node.Text + "\"下移失败！\r\r" + ex.Message, "文件排序", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            button_login_Click(this, null);
        }
        
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = tvFiles.GetNodeAt(Position);
            if (DialogResult.Yes ==
                MessageBox.Show("确认删除\"" + node.Text + "\"?", "删除文件", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                try
                {
                    ftpClient.DeleteFile(node.Text);

                    int iIndex;
                    string sIndex;
                    for (int i = node.Index + 1; i < tvFiles.Nodes.Count; i++)
                    {
                        iIndex = int.Parse(tvFiles.Nodes[i].Text.Substring(0, 2)) - 1;
                        sIndex = iIndex.ToString();
                        if (iIndex < 10) sIndex = "0" + sIndex;
                        ftpClient.RenameFile(tvFiles.Nodes[i].Text, sIndex, true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("\"" + node.Text + "\"删除失败！\r\r" + ex.Message, "删除文件", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                button_login_Click(this, null);
            }
        }

        private void button_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                label_file.Text = @ofd.FileName;
            }
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            if (label_file.Text == "")
            {
                MessageBox.Show("请先选择要上传的文件！", "上传文件", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ftpClient.loggedin)
            {
                MessageBox.Show("请先连接服务器！", "上传文件", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FileInfo file = new FileInfo(label_file.Text);
            if (!file.Exists)
            {
                MessageBox.Show("上传失败！\r\r文件不存在:" + label_file.Text, "上传文件", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                ftpClient.Upload(file.FullName);

                int iIndex = 1;
                if (tvFiles.Nodes.Count > 0)
                {
                    iIndex = int.Parse(tvFiles.Nodes[tvFiles.Nodes.Count - 1].Text.Substring(0, 2)) + 1;
                }
                string sIndex = iIndex.ToString();
                if (iIndex < 10) sIndex = "0" + sIndex;
                ftpClient.RenameFile(file.Name, sIndex + "_" + file.Name, true);

                label_file.Text = "";
                button_login_Click(this, null);
                MessageBox.Show("文件:" + file.Name + "\r\r上传成功！", "上传文件", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("上传失败！\r\rError:" + ex.Message, "上传文件", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReNameFilesInSeq()
        {
            string file, index;
            int numb;
            for (int i = 0; i < tvFiles.Nodes.Count; i++)
            {
                file = tvFiles.Nodes[i].Text;
                if (file.Substring(2, 1) == "_" && int.TryParse(file.Substring(0, 2), out numb))
                    continue;
                else
                {
                    index = i < 10 ? "0" + (i + 1).ToString() : (i + 1).ToString();
                    ftpClient.RenameFile(file, index + "_" + file, true);
                    tvFiles.Nodes.RemoveAt(i);
                    tvFiles.Nodes.Insert(i, index + "_" + file);
                }
            }
        }
    }
}

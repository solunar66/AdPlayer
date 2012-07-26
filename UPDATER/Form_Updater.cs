using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using LOG;
using MSG;

namespace UPD
{
    public partial class Form_Updater : Form
    {
        public const int WM_DEVICECHANGE = 0x219;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_CONFIGCHANGECANCELED = 0x0019;
        public const int DBT_CONFIGCHANGED = 0x0018;
        public const int DBT_CUSTOMEVENT = 0x8006;
        public const int DBT_DEVICEQUERYREMOVE = 0x8001;
        public const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        public const int DBT_DEVICEREMOVEPENDING = 0x8003;
        public const int DBT_DEVICETYPESPECIFIC = 0x8005;
        public const int DBT_DEVNODES_CHANGED = 0x0007;
        public const int DBT_QUERYCHANGECONFIG = 0x0017;
        public const int DBT_USERDEFINED = 0xFFFF;
        
        private const int WM_DESTROY = 0x0002;

        private string rar = @"rar\WinRAR.exe";

        private string updatefile = @"update.zip";

        private string passwd = "TaoXue";

        private LogInfo log = LogInfo.GetInstance;

        private Msg.myParam tmp;

        public Form_Updater()
        {
            InitializeComponent();

            this.Text = "系统升级守护进程";
            this.Visible = false;
        }

        public void DoUpdate()
        {
            DriveInfo[] s = DriveInfo.GetDrives();
            foreach (DriveInfo drive in s)
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    LogUpdate("检测到U盘插入...");
                    FileInfo file = new FileInfo(drive.Name + @"\update.zip");
                    if (file.Exists)
                    {
                        LogUpdate("检测到升级文件: " + drive.Name + updatefile);

                        IntPtr ptr = Msg.FindWindow(null, "广告播放系统");
                        if (IntPtr.Zero != ptr)
                        {
                            Msg.PostMessage(ptr, WM_DESTROY, 0, ref tmp);
                            LogUpdate("开始升级主程序...");

                            Process UnRAR = new Process();
                            UnRAR.StartInfo.FileName = rar;
                            UnRAR.StartInfo.CreateNoWindow = true;
                            // e : 解压到当前目录
                            // o+: 覆盖原文件
                            // y : 对话框默认确认
                            // p : 解压密码
                            UnRAR.StartInfo.Arguments = " e -o+ -y -cl -p" + passwd + " " + drive.Name + updatefile;
                            UnRAR.Start();

                            while(true)
                            {
                                if (UnRAR.HasExited) { break; }
                                else { Thread.Sleep(500); }
                            }

                            if (UnRAR.ExitCode == 0)
                            {
                                LogUpdate("主程序升级成功！");
                            }
                            else
                            {
                                LogUpdate("升级失败！ExitCode:" + UnRAR.ExitCode.ToString());
                            }

                            LogUpdate("重新启动主程序...");
                            System.Diagnostics.Process.Start(@"Router.exe");

                            this.Dispose();
                            
                        }
                        else { }
                    }
                    else
                    {
                        LogUpdate("没有检测到升级文件: " + updatefile);
                    }
                }
            }
        }

        private void LogUpdate(string s)
        {
            log.WriteConsoleAndLog("[Updater]=====>>>>> " + s);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == MSG.Msg.INT_MSG_Update)
            {
                DoUpdate();
            }

            base.WndProc(ref m);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
    }
}

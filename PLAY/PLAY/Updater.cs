using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PLAY
{
    class Updater
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

        private string rar = @"rar\WinRAR.exe";

        private string targetpath = @"C:\System\";

        private string updatefile = @"\update.zip";

        private string passwd = "TaoXue";

        private LOG.LogInfo log = LOG.LogInfo.GetInstance;

        public void DoUpdate(ref Message m)
        {
            if (m.Msg == WM_DEVICECHANGE)
            {
                switch (m.WParam.ToInt32())
                {
                    // 插入
                    case DBT_DEVICEARRIVAL:
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
                                    Process UnRAR = new Process();
                                    UnRAR.StartInfo.FileName = rar;
                                    UnRAR.StartInfo.CreateNoWindow = true;
                                    UnRAR.StartInfo.Arguments = " x -o+ t -y -cl -p" + passwd + " " + updatefile + " " + targetpath;
                                    UnRAR.Start();
                                    LogUpdate("开始升级主程序: " + targetpath);
                                    if (UnRAR.HasExited)
                                    {
                                        if (UnRAR.ExitCode == 0)
                                            LogUpdate("主程序升级成功！重新启动...");
                                        else
                                            LogUpdate("升级失败！ExitCode:" + UnRAR.ExitCode.ToString());
                                    }
                                }
                                LogUpdate("没有检测到升级文件: " + updatefile);
                            }
                        }
                        break;

                    // 卸载
                    case DBT_DEVICEREMOVECOMPLETE:
                        LogUpdate("U盘卸载...");
                        break;

                    default:
                        break;
                }
            }
        }

        private void LogUpdate(string s)
        {
            log.WriteConsoleAndLog("[Updater]=====>>>>> " + s);
        }
    }
}

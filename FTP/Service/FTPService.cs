using System;
using System.ServiceProcess;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace AdvancedFTPServer
{
    class WindowsService : ServiceBase
    {
        public WindowsService()
        {
            this.ServiceName = "AdvFTPSvr";
            this.EventLog.Source = "Advanced FTP Server";
            this.EventLog.Log = "Application";
        }

        static void Main()
        {
            ServiceBase.Run(new WindowsService());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnStart(string[] args)
        {
            using (RegistryKey Service = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + this.ServiceName))
                if (Service != null)
                {
                    string Path = Service.GetValue("ImagePath").ToString();
                    Path = Path.Substring(0, Path.LastIndexOf('\\')).Replace("\"", "");
                    Process.Start(Path + "\\FTPServer.exe");
                }
            base.Stop();
        }
    }
}
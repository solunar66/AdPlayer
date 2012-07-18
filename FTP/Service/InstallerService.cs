using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
using Microsoft.Win32;
using System.Collections;
using System.IO;

namespace WindowsService
{
    [RunInstaller(true)]
    public class InstallerService : Installer
    {
        ServiceInstaller serviceInstaller;

        public InstallerService()
        {
            ServiceProcessInstaller ServiceInstaller = new ServiceProcessInstaller();
            ServiceInstaller.Account = ServiceAccount.LocalSystem;
            ServiceInstaller.Username = null;
            ServiceInstaller.Password = null;

            this.Installers.Add(ServiceInstaller);

            serviceInstaller = new ServiceInstaller();
            serviceInstaller.DisplayName = "Advanced FTP Server";
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.Description = "Enables access to files and folders over network with user specific credentials. If this service is disabled, any services explicitly depend on it will fail to start.";
            serviceInstaller.ServiceName = "AdvFTPSvr";
            this.Installers.Add(serviceInstaller);
        }

        protected override void OnCommitted(IDictionary savedState)
        {
            string ApplicationPath = null;

            using (RegistryKey Service = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + serviceInstaller.ServiceName, true))
            {
                if (Service != null)
                {
                    Service.SetValue("Type", (((int)Service.GetValue("Type")) | 256));

                    ApplicationPath = Service.GetValue("ImagePath").ToString();
                    ApplicationPath = ApplicationPath.Substring(0, ApplicationPath.LastIndexOf('\\')).Replace("\"", string.Empty);
                    Service.Close();
                }
            }
            EncryptSettingsFile(ApplicationPath + "\\Settings.DAT");
            AddToFirewallException(serviceInstaller.DisplayName, ApplicationPath + "\\FTPServer.exe");
            //AddMenuOptionToFolders("FTP Sharing and Security", ApplicationPath);
            base.OnCommitted(savedState);
        }

        void AddToFirewallException(string ApplicationName, string FilePath)
        {
            // Add exception to windows firewall after installation
            string RegPath =
               @"SYSTEM\ControlSet001\Services\SharedAccess\Parameters\FirewallPolicy\StandardProfile\AuthorizedApplications\List";
            string KeyValue = FilePath + ":*:Enabled:" + ApplicationName;

            RegistryKey Key = Registry.LocalMachine.OpenSubKey(RegPath, true);
            Key.SetValue(FilePath, KeyValue);
            Key.Close();
            Key = null;
        }

        void EncryptSettingsFile(string Path)
        {
            FileStream FS = new FileStream(Path, FileMode.Open, FileAccess.ReadWrite);
            byte[] Buffer = new byte[(int)FS.Length];
            FS.Read(Buffer, 0, Buffer.Length);
            FS.Position = 0;
            FS.Write(Crypt(Buffer), 0, Buffer.Length);
            FS.Close();
            FS = null;
        }

        byte[] Crypt(byte[] Buffer)
        {
            for (int i = 0; i < Buffer.Length; i++)
            {
                Buffer[i] ^= 36;
            }
            return Buffer;
        }

        //protected override void OnAfterUninstall(IDictionary savedState)
        //{
        //    //Remove the context menu keys option
        //    Registry.ClassesRoot.DeleteSubKey(@"Folder\shell\AdvancedFTPServer\command", false);
        //    Registry.ClassesRoot.DeleteSubKey(@"Folder\shell\AdvancedFTPServer", false);
        //    base.OnAfterUninstall(savedState);
        //}

        //void AddMenuOptionToFolders(string MenuText, string ExecutablePath)
        //{
        //    try
        //    {
        //        RegistryKey RegKey = Registry.ClassesRoot.CreateSubKey(@"Folder\shell\AdvancedFTPServer");
        //        if (RegKey != null)
        //        {
        //            RegKey.SetValue("", MenuText);
        //            RegKey.Close();

        //            RegKey = Registry.ClassesRoot.CreateSubKey(@"Folder\shell\AdvancedFTPServer\command");
        //            if (RegKey != null)
        //            {
        //                RegKey.SetValue("", ExecutablePath);
        //                RegKey.Close();
        //            }
        //        }
        //    }
        //    catch { }
        //}
    }
}
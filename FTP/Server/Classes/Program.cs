using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace FTP
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                new SIApplication().Run(new string[0]);
            }
            catch (UnauthorizedAccessException Ex)
            {
                MessageBox.Show("Advanced FTP Server is already running in background by some other user. New instance cannot be started.", "Advanced FTP Server");
            }
        }
    }

    class SIApplication : WindowsFormsApplicationBase
    {
        public SIApplication()
        {
            this.IsSingleInstance = true;
            this.EnableVisualStyles = true;

            this.ShutdownStyle = Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses;
            this.StartupNextInstance += new StartupNextInstanceEventHandler(this.Application_NewInstance);
        }

        protected override void OnCreateMainForm()
        {
            this.MainForm = new frmMain();
        }

        protected void Application_NewInstance(object sender, StartupNextInstanceEventArgs eventArgs)
        {
            this.MainForm.Invoke(new frmMain.ProcessNewInstanceDelegate(
                ((frmMain)this.MainForm).ProcessNewInstance));
        }
    }
}
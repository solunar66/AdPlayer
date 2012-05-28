using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace UPD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] argv)
        {
            if (argv.Length != 0 && argv[0] == "-f")
            { }
            else
            {
                MessageBox.Show("请从主程序\"Router.exe\"启动！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //Loop through the running processes in with the same name      
            foreach (Process process in processes)
            {
                //Ignore the current process
                if (process.Id != current.Id)
                {
                    //Make sure that the process is running from the exe file.      
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //Return the other process instance.      
                        process.Kill();
                    }
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Updater());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PLAY
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Play());
        }
    }
}

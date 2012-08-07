using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices; 

namespace MSG
{
    public class Msg
    {
#region messages
        // 系统消息
        private const int WM_SYSCOMMAND = 0x112;
        // 启动屏幕保护消息
        private const int SC_SCREENSAVE = 0xf140;
        // 关闭显示器的系统命令
        private const int SC_MONITORPOWER = 0xF170;
        // 2为关闭, 1为省电状态, -1为开机
        private const int POWER_OFF = 2;
        private const int POWER_SAVING = 1;
        private const int POWER_ON = -1;
        //广播消息，所有顶级窗体都会接收
        private static readonly IntPtr HWND_BROADCAST = new IntPtr(0xffff);

        // WM_USER = 0x0400;
        public const int USER = 0x500;

        public const int INT_MSG_GoOnPlayingAfterPPT = USER + 1;

        public const int EXT_MSG_PlayNotice = USER + 2;

        public const int EXT_MSG_StopNotice = USER + 3;

        public const int INT_MSG_Update = USER + 4;

        public const int INT_MSG_Window = USER + 5;

        public const int INT_MSG_Ftp = USER + 6;

        public struct myParam
        {
            public string param;
        }
#endregion

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(
            IntPtr hWnd,        // 信息发往的窗口的句柄 
            int Msg,            // 消息ID 
            int wParam,         // 参数1 
            ref myParam lParam// 自定义消息参数
            );

        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(
            IntPtr hWnd,        // 信息发往的窗口的句柄 
            int Msg,            // 消息ID 
            int wParam,         // 参数1 
            ref myParam lParam// 自定义消息参数
            );

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        /// <summary>
        /// 控制显示器电源
        /// </summary>
        /// <param name="power">
        /// 2: 关闭
        /// 1: 省电状态
        /// -1:开机
        /// </param>
        public static void ShutMonitor(int power)
        {
            switch (power)
            {
                case 2:
                    SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, POWER_OFF);
                    break;
                case 1:
                    SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, POWER_SAVING);
                    break;
                case -1:
                    SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, POWER_ON);
                    break;
                default:
                    break;
            }
        }
    }
}

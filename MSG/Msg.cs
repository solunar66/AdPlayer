using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices; 

namespace MSG
{
    public class Msg
    {
        // WM_USER = 0x0400;
        public const int USER = 0x500;

        public const int INT_MSG_GoOnPlayingAfterPPT = USER + 1;

        public const int EXT_MSG_PlayNotice = USER + 2;

        public const int EXT_MSG_StopNotice = USER + 3;

        public const int INT_MSG_Update = USER + 4;

        public const int INT_MSG_Window = USER + 5;

        public struct My_lParam_Notice
        {
            public string text;
            public string color;
            public string bgcolor;
            public int interval;
            public string font;
            public bool bold;
        }
        
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(
            IntPtr hWnd,        // 信息发往的窗口的句柄 
            int Msg,            // 消息ID 
            int wParam,         // 参数1 
            ref My_lParam_Notice lParam// 自定义消息参数
            );

        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(
            IntPtr hWnd,        // 信息发往的窗口的句柄 
            int Msg,            // 消息ID 
            int wParam,         // 参数1 
            ref My_lParam_Notice lParam// 自定义消息参数
            );

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
    }
}

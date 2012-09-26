using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using MSG;

namespace ROUTER
{
    public partial class Form_Router : Form
    {
        private bool forceQuit = false;

        private Socket sock;
        private IPEndPoint ipEndPoint;
        private byte[] ipAddr;

        private const int WM_DESTROY = 0x0002;
        private Msg.myParam tmp;

        public Form_Router()
        {
            InitializeComponent();

            this.Text = "系统服务";

            ClearProcesses();

            //System.Diagnostics.Process.Start("MediaPlayer.exe");
            System.Diagnostics.Process.Start("Updater.exe", "-f");

            System.Diagnostics.Process.Start("FTPserver.exe", "-f");
            
            PLAY.Form_Play play = new PLAY.Form_Play();
            if (!play.IsDisposed)
            {
                play.Show();
            }
            else 
            {
                forceQuit = true;
            }
            //UPD.Form_Updater updater = new UPD.Form_Updater();
            //updater.Show();

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            ipEndPoint = new IPEndPoint(IPAddress.Broadcast, 9050);
            foreach (IPAddress addr in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork) ipAddr = Encoding.ASCII.GetBytes(addr.ToString());
            }
        }

        private void ClearProcesses()
        {
            IntPtr ptr1 = Msg.FindWindow(null, "系统服务");

            if (IntPtr.Zero != ptr1)
            {
                Msg.PostMessage(ptr1, WM_DESTROY, 0, ref tmp);
            }

            IntPtr ptr2 = Msg.FindWindow(null, "系统升级守护进程");

            if (IntPtr.Zero != ptr2)
            {
                Msg.PostMessage(ptr2, WM_DESTROY, 0, ref tmp);
            }

            IntPtr ptr3 = Msg.FindWindow(null, "Advanced FTP Server :: Main Form");

            if (IntPtr.Zero != ptr3)
            {
                Msg.PostMessage(ptr3, WM_DESTROY, 0, ref tmp);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr ptr = Msg.FindWindow(null, "宣传播放系统");

            if (IntPtr.Zero == ptr) return;

            Msg.myParam tmp = new Msg.myParam();
            //Msg.SendMessage(ptr, Msg.INT_MSG_GoOnPlayingAfterPPT, 1, ref tmp);//发送消息
            Msg.PostMessage(ptr, Msg.EXT_MSG_PlayNotice, 1, ref tmp);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
        }

        private void 配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form_Router_Load(object sender, EventArgs e)
        {
            if (forceQuit) this.Close();
        }

        private void checkBox_ftp_CheckedChanged(object sender, EventArgs e)
        {
            IntPtr ptr = Msg.FindWindow(null, "Advanced FTP Server :: Main Form");

            if (IntPtr.Zero == ptr) return;

            Msg.myParam tmp = new Msg.myParam();
            Msg.PostMessage(ptr, Msg.INT_MSG_Ftp, 1, ref tmp);
        }

        private void button_hide_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void timer1_broadcast_Tick(object sender, EventArgs e)
        {
            if (sock != null)
            {
                sock.SendTo(ipAddr, ipEndPoint);
            }
        }
    }
}

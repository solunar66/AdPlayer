using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSG;

namespace ROUTER
{
    public partial class Form_Router : Form
    {
        public Form_Router()
        {
            InitializeComponent();

            this.Text = "系统服务";

            //System.Diagnostics.Process.Start("MediaPlayer.exe");
            System.Diagnostics.Process.Start("Updater.exe");
            
            PLAY.Form_Play play = new PLAY.Form_Play();
            play.Show();

            //UPD.Form_Updater updater = new UPD.Form_Updater();
            //updater.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr ptr = Msg.FindWindow(null, "广告播放系统");

            if (IntPtr.Zero == ptr) return;

            Msg.My_lParam_Notice m = new Msg.My_lParam_Notice();

            //Msg.SendMessage(ptr, Msg.INT_MSG_GoOnPlayingAfterPPT, 1, ref m);//发送消息
            Msg.PostMessage(ptr, Msg.EXT_MSG_PlayNotice, 1, ref m);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void 配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button_quit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {

        }
    }
}

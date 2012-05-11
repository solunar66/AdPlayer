using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PPT;
using MSG;
using XML;
using LOG;
using UPD;

namespace PLAY
{
    public partial class Form_Play : Form
    {
        private const int WM_DESTROY = 0x0002;

        private const int KeyESC = 27;

        private string curDir = System.IO.Directory.GetCurrentDirectory().ToString();

        private XMLInfo xml = new XMLInfo(@"config\play.xml");

        private LogInfo log = LogInfo.GetInstance;

        private Config config;

        private List<Content> playlist;
        private Content content;
        private PlayMode mode;

        private Hook hook;

        private WMPLib.WMPPlayState prev_state;

        private bool wait;

        public Form_Play()
        {
            InitializeComponent();

            this.Text = "广告播放系统";

            // 读取配置
            xml.ReadPlayConfig(out config);
            numericUpDown2.Value = config.notice.interval;

            // 播放器设置
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.Ctlenabled = true;
            axWindowsMediaPlayer1.settings.setMode("loop", true);// 循环

            Screen[] scr = Screen.AllScreens;
            if (scr.Length > 1)
            {
                label8.ForeColor = Color.FromKnownColor(System.Drawing.KnownColor.ControlText);
                comboBox_scr.Enabled = true;
                for (int i = 0; i < scr.Length; i++)
                {
                    comboBox_scr.Items.Add(scr[i].DeviceName);
                }
                if (config.scr <= scr.Length) comboBox_scr.SelectedIndex = config.scr - 1;
            }
            
            hook = new Hook();
        }

        // 字幕滚动
        private void timer_title_Tick(object sender, EventArgs e)
        {
            //label1.Text = axWindowsMediaPlayer1.currentMedia.name;
            //axWindowsMediaPlayer1.Ctlcontrols.stop();
            label_title.Location = new Point(label_title.Location.X - 5, this.Height - label_title.Height);
            if (label_title.Width + label_title.Location.X < 0)
            {
                label_title.Location = new Point(this.Width, label_title.Location.Y);
            }
        }

        // 消息响应
        protected override void WndProc(ref Message m)
        {
            try
            {
                switch (m.Msg)
                {
                    case Form_Updater.WM_DEVICECHANGE:
                        if (m.WParam.ToInt32() == Form_Updater.DBT_DEVICEARRIVAL)
                        {
                            IntPtr ptr = Msg.FindWindow(null, "系统升级守护进程");
                            if (IntPtr.Zero == ptr) return;
                            Msg.My_lParam_Notice myM = new Msg.My_lParam_Notice();
                            Msg.PostMessage(ptr, Msg.INT_MSG_Update, 1, ref myM);
                        }
                        break;

                    case Msg.INT_MSG_GoOnPlayingAfterPPT:
                        //Msg.My_lParam param = new Msg.My_lParam();
                        //Type t = param.GetType();
                        //param = (Msg.My_lParam)m.GetLParam(t);
                        //MessageBox.Show("收到命令: " + param.s);
                        if (axWindowsMediaPlayer1.Dock == DockStyle.Fill) DoPlay();
                        break;

                    case Msg.EXT_MSG_PlayNotice:
                        // 字幕字体
                        label_title.BackColor = config.notice.bgcolor;
                        label_title.Font = new Font(config.notice.font, config.notice.size);
                        label_title.Location = new Point(0, label_title.Location.Y);
                        label_title.Text = "notice";
                        label_title.Visible = false;

                        this.timer_title.Interval = config.notice.interval;
                        this.timer_title.Start();
                        this.label_title.Visible = true;
                        break;

                    case Msg.EXT_MSG_StopNotice:
                        this.timer_title.Stop();
                        this.label_title.Visible = false;
                        break;

                    case Msg.INT_MSG_Window:
                        EscKeyPressEvent();
                        break;

                    case WM_DESTROY:
                        IntPtr ptr1 = Msg.FindWindow(null, "系统服务");
                        if (IntPtr.Zero != ptr1)
                        {
                            Msg.My_lParam_Notice mm = new Msg.My_lParam_Notice();
                            Msg.PostMessage(ptr1, WM_DESTROY, 0, ref mm);
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogPlay("WndProc Exception: " + ex.Message);
                //MessageBox.Show(ex.Message);
            }

            base.WndProc(ref m);
        }

        // ESC 返回管理界面
        private void EscKeyPressEvent()
        {
            if (axWindowsMediaPlayer1.Dock == DockStyle.Fill)
            {
                hook.Hook_Clear();
                Cursor.Show();
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.WindowState = FormWindowState.Normal;
                axWindowsMediaPlayer1.Dock = DockStyle.None;
                axWindowsMediaPlayer1.Size = new Size(496, 431);
                axWindowsMediaPlayer1.Location = new Point(12, 3);
                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                { axWindowsMediaPlayer1.Ctlcontrols.pause(); }
                panel1.Visible = true;
            }
        }

        // 伪全屏
        // 防止意外退出全屏模式
        public void Play_Click(object sender, EventArgs e)
        {
            // 读取配置
            xml.ReadPlayConfig(out config);

            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            panel1.Visible = false;

            hook.Hook_Clear();
            hook.Hook_Start();

            // 多屏显示
            Screen[] scr = Screen.AllScreens;
            if (scr.Length > 1)
            {
                this.Location = scr[config.scr].WorkingArea.Location;
            }

            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else
            {
                CheckPlayList();
                DoPlay();
            }
        }

        private void CheckPlayList()
        {
            DateTime now = DateTime.Now;
            playlist = null;

            for (int i = 0; i < config.datesheets.Count; i++)
            {
                DateSheet datesheet = config.datesheets[i];
                if (now.Date >= datesheet.startDate.Date && now.Date <= datesheet.endDate.Date)
                {
                    bool weekday = false;
                    switch (now.DayOfWeek)
                    {
                        case DayOfWeek.Monday: weekday = datesheet.Mon; break;
                        case DayOfWeek.Tuesday: weekday = datesheet.Tue; break;
                        case DayOfWeek.Wednesday: weekday = datesheet.Wed; break;
                        case DayOfWeek.Thursday: weekday = datesheet.Thu; break;
                        case DayOfWeek.Friday: weekday = datesheet.Fri; break;
                        case DayOfWeek.Saturday: weekday = datesheet.Sat; break;
                        case DayOfWeek.Sunday: weekday = datesheet.Sun; break;
                        default: break;
                    }
                    if (weekday)
                    {
                        for (int j = 0; j < datesheet.timesheets.Count; j++)
                        {
                            TimeSheet timesheet = datesheet.timesheets[j];
                            if (now.TimeOfDay >= timesheet.startTime.TimeOfDay && now.TimeOfDay <= timesheet.endTime.TimeOfDay)
                            {
                                playlist = timesheet.contents;
                                mode = timesheet.mode;
                                wait = false;
                            }
                        }
                    }
                }
            }
        }

        public void DoPlay()
        {
            CheckPlayList();
            if (playlist == null)
            {
                wait = true;
                return;
            }

            switch (mode)
            {
                case PlayMode.random:
                    Random rdm = new Random();
                    content = playlist[rdm.Next(playlist.Count - 1)];
                    break;
                case PlayMode.sequencial:
                    int index = playlist.IndexOf(content);
                    if (index == playlist.Count - 1) content = playlist[0];
                    else content = playlist[index + 1];
                    break;
                default:
                    break;
            }
            switch (content.type)
            {
                case ContentType.powerpoint:
                    PlayPPT();
                    break;
                case ContentType.video:
                    PlayVideo();
                    break;
                default:
                    break;
            }
        }

        // 播放视频
        private void PlayVideo()
        {
            axWindowsMediaPlayer1.URL = content.file.IndexOf(":") == -1 ? curDir + "\\" + content.file : content.file;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        // 播放PPT
        private void PlayPPT()
        {
            OperatePPT ppt = new OperatePPT();
            string pathfile = content.file.IndexOf(":") == -1 ? curDir + "\\" + content.file : content.file;
            if (numericUpDown1.Enabled)
            {
                ppt.PPTAuto(pathfile, int.Parse(numericUpDown1.Value.ToString()));
            }
            else
            {
                ppt.PPTAuto(pathfile, content.duration);
            }
            LogPlay("当前文件:\"" + pathfile + "\"" + ", 播放状态:PowerPoint放映中");
        }

        // 退出
        private void Exit_Click(object sender, EventArgs e)
        {
            IntPtr ptr1 = Msg.FindWindow(null, "系统服务");

            if (IntPtr.Zero != ptr1)
            {
                Msg.My_lParam_Notice m = new Msg.My_lParam_Notice();
                Msg.PostMessage(ptr1, WM_DESTROY, 0, ref m);
            }

            IntPtr ptr2 = Msg.FindWindow(null, "系统升级守护进程");

            if (IntPtr.Zero != ptr2)
            {
                Msg.My_lParam_Notice m = new Msg.My_lParam_Notice();
                Msg.PostMessage(ptr2, WM_DESTROY, 0, ref m);
            }

            this.Dispose();
        }

        private void LogPlay(string s)
        {
            log.WriteConsoleAndLog("[MediaPlayer]=====>>>>> " + s);
        }

        private void button_Configfile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", @"config\play.xml");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = checkBox1.CheckState == CheckState.Checked ? false : true;
            label2.Enabled = numericUpDown1.Enabled;
            label3.Enabled = numericUpDown1.Enabled;

            checkBox1.ForeColor = 
                (checkBox1.CheckState == CheckState.Checked) ? 
                Color.FromKnownColor(System.Drawing.KnownColor.ControlText) :
                Color.FromKnownColor(System.Drawing.KnownColor.InactiveCaption);
        }

        private void button_Font_Click(object sender, EventArgs e)
        {
            xml.ReadPlayConfig(out config);

            Font font = new Font(config.notice.font, 
                                config.notice.size, 
                                config.notice.bold ? FontStyle.Bold : FontStyle.Regular);            
            fontDialog1.Color = config.notice.color;
            fontDialog1.Font = font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                xml.Update("notice", "font", fontDialog1.Font.FontFamily.Name);
                xml.Update("notice", "bold", fontDialog1.Font.Bold ? "1" : "0");
                xml.Update("notice", "size", fontDialog1.Font.Size.ToString());
                xml.Update("notice", "color", fontDialog1.Color.Name.ToString());
            }
        }

        private void button_fontbg_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = config.notice.bgcolor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                xml.Update("notice", "bgcolor", colorDialog1.Color.Name.ToString());
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            xml.Update("notice", "speed", numericUpDown2.Value.ToString());
        }

        private void button_Config_Click(object sender, EventArgs e)
        {
            xml.ReadPlayConfig(out config);

            Form_Config cfg = new Form_Config(xml);
            cfg.ShowDialog();
        }

        private void timer_monitor_Tick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1_PlayStateChange();

            if (wait)
            {
                //LogPlay("当前时间段无播放配置信息，等待中...");
                DoPlay();
            }
        }

        private void axWindowsMediaPlayer1_PlayStateChange()
        {
            WMPLib.WMPPlayState cur_state = axWindowsMediaPlayer1.playState;
            if (cur_state == prev_state) return;
            else prev_state = cur_state;

            bool goon = false;
            string state;
            switch (cur_state)
            {
                case WMPLib.WMPPlayState.wmppsStopped:
                    state = "Stopped";
                    goon = true;
                    break;
                case WMPLib.WMPPlayState.wmppsPaused:
                    state = "Paused";
                    break;
                case WMPLib.WMPPlayState.wmppsPlaying:
                    state = "Playing";
                    break;
                case WMPLib.WMPPlayState.wmppsBuffering:
                    state = "Buffering";
                    break;
                case WMPLib.WMPPlayState.wmppsTransitioning:
                    state = "Transitioning";
                    break;
                case WMPLib.WMPPlayState.wmppsReady:
                    state = "Ready";
                    goon = true;
                    break;
                default:
                    state = axWindowsMediaPlayer1.playState.ToString();
                    break;
            }

            string cur_media = axWindowsMediaPlayer1.currentMedia == null ? "null" : axWindowsMediaPlayer1.currentMedia.name;

            LogPlay("当前文件:\"" + cur_media + "\", 播放状态:" + state);

            if (goon && axWindowsMediaPlayer1.Dock == DockStyle.Fill)
            {
                DoPlay();
            }
        }

        private void comboBox_scr_SelectedIndexChanged(object sender, EventArgs e)
        {
            xml.Update("screen", "index", (comboBox_scr.SelectedIndex + 1).ToString());
        }
    }
}

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
        private Content lastPlay, lastInter;

        private bool monitorON = true;
        private bool interPlay = false;

        private Hook hook;

        private WMPLib.WMPPlayState prev_state;

        private string interMediaPath;

        private Msg.myParam tmp;

        public Form_Play()
        {
            InitializeComponent();

            this.Text = "广告播放系统";

            // 读取配置
            if (!xml.ReadPlayConfig(out config))
            {
                MessageBox.Show("没有检测到配置文件！\n\n请将正确的配置文件\"play.xml\"放入程序目录的\"config\"文件夹下", "启动异常", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
            else
            {
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

                comboBox_idle.Items.Add(ContentType.video);
                comboBox_idle.Items.Add(ContentType.powerpoint);
                comboBox_idle.SelectedIndex = (int)(config.idle.type) - 1;
                numericUpDown_idle.Value = (decimal)config.idle.duration;
                label_idle.Text = config.idle.file;

                dateTimePicker_sleepStart.Value = config.sleep.timespan.startTime;
                dateTimePicker_sleepEnd.Value = config.sleep.timespan.endTime;
                checkBox_sleep.Checked = config.sleep.enable;
                checkBox_sleep_CheckedChanged(this, null);

                checkBox_interval.Checked = config.intermedia.enable;
                checkBox_interval_CheckedChanged(this, null);
                numericUpDown_interval.Value = config.intermedia.limit;
                numericUpDown_duration.Value = config.intermedia.duration;

                hook = new Hook();
            }
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
                            Msg.PostMessage(ptr, Msg.INT_MSG_Update, 1, ref tmp);
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
                            Msg.PostMessage(ptr1, WM_DESTROY, 0, ref tmp);
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
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                panel1.Visible = true;
                button_about.Visible = true;
                button_help.Visible = true;
            }
        }

        // 伪全屏
        // 防止意外退出全屏模式
        public void Play_Click(object sender, EventArgs e)
        {
            // 读取配置
            xml.ReadPlayConfig(out config);
            string pwd, pmt; bool ebl;
            FTP.ApplicationSettings._DataPath = Directory.GetCurrentDirectory();
            FTP.ApplicationSettings.ReadSettings();
            FTP.ApplicationSettings.GetUser("ADPLAYER", out pwd, out interMediaPath, out pmt, out ebl);

            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            panel1.Visible = false;
            button_about.Visible = false;
            button_help.Visible = false;

            hook.Hook_Clear();
            hook.Hook_Start();

            // 多屏显示
            Screen[] scr = Screen.AllScreens;
            if (scr.Length > 1)
            {
                this.Location = scr[config.scr].WorkingArea.Location;
            }

            axWindowsMediaPlayer1.Ctlcontrols.play();

            if (config.intermedia.contents.Count == 0) config.intermedia.enable = false;
            CheckPlayList();
            DoPlay();
        }

        private void CheckPlayList()
        {
            DateTime now = DateTime.Now;
            playlist = null;

            if (config.datesheets == null) return;
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
                                return;
                            }
                        }
                    }
                }
            }
        }

        public void DoPlay()
        {
            CheckPlayList();
            if (playlist == null || playlist.Count == 0)
            {
                PlayIdle();
                return;
            }

            int index;
            Msg.ShutMonitor(-1);

            if (config.intermedia.enable && interPlay)
            {
                index = config.intermedia.contents.IndexOf(lastInter);
                if (index == config.intermedia.contents.Count - 1) content = config.intermedia.contents[0];
                else content = config.intermedia.contents[index + 1];
                lastInter = content;
            }
            else
            {
                switch (mode)
                {
                    case PlayMode.random:
                        if (playlist.Count == 1)
                        {
                            content = playlist[0];
                        }
                        else
                        {
                            Random rdm = new Random();
                            content = playlist[rdm.Next(playlist.Count)];
                        }
                        break;
                    case PlayMode.sequencial:
                        index = playlist.IndexOf(lastPlay);
                        if (index == playlist.Count - 1) content = playlist[0];
                        else content = playlist[index + 1];
                        break;
                    default:
                        break;
                }
                lastPlay = content;
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
            interPlay ^= true;
        }

        // 空闲播放
        private void PlayIdle()
        {
            FileInfo idle = new FileInfo(config.idle.file.IndexOf(":") == -1 ? curDir + "\\" + config.idle.file : config.idle.file);
            if (idle.Exists)
            {
                axWindowsMediaPlayer1.URL = idle.FullName;
                axWindowsMediaPlayer1.Ctlcontrols.play();
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
            numericUpDown1.Enabled = checkBox1.CheckState == CheckState.Checked ? true : false;

            label2.ForeColor = 
                (checkBox1.CheckState == CheckState.Checked) ? 
                Color.FromKnownColor(System.Drawing.KnownColor.ControlText) :
                Color.FromKnownColor(System.Drawing.KnownColor.InactiveCaption);
            label3.ForeColor = label2.ForeColor;
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

            if (axWindowsMediaPlayer1.Dock == DockStyle.Fill)
            {
                if (CheckSleep())
                {
                    if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    {
                        axWindowsMediaPlayer1.Ctlcontrols.pause();
                    }
                    if (monitorON)
                    {
                        monitorON = false;
                        Msg.ShutMonitor(2);
                        LogPlay("关闭显示器");
                    }
                }
                else
                {
                    if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
                    {
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    }
                    if (!monitorON)
                    {
                        monitorON = true;
                        Msg.ShutMonitor(-1);
                        LogPlay("打开显示器");
                    }
                }
            }
        }

        private bool CheckSleep()
        {
            if (!config.sleep.enable) return false;

            // in one day
            if (config.sleep.timespan.startTime.TimeOfDay < config.sleep.timespan.endTime.TimeOfDay)
            {
                if (DateTime.Now.TimeOfDay >= config.sleep.timespan.startTime.TimeOfDay && DateTime.Now.TimeOfDay <= config.sleep.timespan.endTime.TimeOfDay)
                { return true; }
            }
            // cross night
            else if (config.sleep.timespan.startTime.TimeOfDay > config.sleep.timespan.endTime.TimeOfDay)
            {
                if (DateTime.Now.TimeOfDay >= config.sleep.timespan.startTime.TimeOfDay && DateTime.Now.TimeOfDay <= config.sleep.timespan.endTime.TimeOfDay)
                { return false; }
            }

            return false;
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

        private void button_idle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                label_idle.Text = ofd.FileName;
                xml.Update("idle", "src", ofd.FileName);
            }
        }

        private void numericUpDown_idle_ValueChanged(object sender, EventArgs e)
        {
            xml.Update("idle", "duration", numericUpDown_idle.Value.ToString());
        }

        private void comboBox_idle_SelectedIndexChanged(object sender, EventArgs e)
        {
            xml.Update("idle", "type", ((ContentType)(comboBox_idle.SelectedIndex + 1)).ToString());
        }

        private void dateTimePicker_sleepStart_Leave(object sender, EventArgs e)
        {
            xml.Update("sleep", "starttime", dateTimePicker_sleepStart.Value.ToLongTimeString());
        }

        private void dateTimePicker_sleepEnd_Leave(object sender, EventArgs e)
        {
            xml.Update("sleep", "endtime", dateTimePicker_sleepEnd.Value.ToLongTimeString());
        }

        private void 退出全屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EscKeyPressEvent();
        }

        private void axWindowsMediaPlayer1_MouseDownEvent(object sender, AxWMPLib._WMPOCXEvents_MouseDownEvent e)
        {
            if(axWindowsMediaPlayer1.Dock != DockStyle.Fill) return;
            if (e.nButton == 2)
            {
                Cursor.Show();
                if (DialogResult.Yes == MessageBox.Show("退出全屏？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    EscKeyPressEvent();
                }
                Cursor.Hide();
            }
            else if (e.nButton == 4)
            {
                Cursor.Show();
                if (DialogResult.Yes == MessageBox.Show("跳过当前视频？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                }
                Cursor.Hide();
            }
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("manual.docx");
            }
            catch { }
        }

        private void button_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("版权所有: 程漱铭\r\nCopyright © 2012 Samuel.CHENG\nAll rights reserved\r\n\n技术支持: +86 1381***5709", "版权所有", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void checkBox_interval_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown_interval.Enabled = checkBox_interval.CheckState == CheckState.Checked ? true : false;
            numericUpDown_duration.Enabled = numericUpDown_interval.Enabled;

            numericUpDown_interval.ForeColor =
                (checkBox_interval.CheckState == CheckState.Checked) ?
                Color.FromKnownColor(System.Drawing.KnownColor.ControlText) :
                Color.FromKnownColor(System.Drawing.KnownColor.InactiveCaption);
            numericUpDown_duration.ForeColor = numericUpDown_interval.ForeColor;
            label12.ForeColor = numericUpDown_interval.ForeColor;
            label14.ForeColor = numericUpDown_interval.ForeColor;
            label15.ForeColor = numericUpDown_interval.ForeColor;
            label17.ForeColor = numericUpDown_interval.ForeColor;

            xml.Update("intermedia", "enable", checkBox_interval.Checked ? "1" : "0");
        }

        private void numericUpDown_interval_ValueChanged(object sender, EventArgs e)
        {
            xml.Update("intermedia", "limit", numericUpDown_interval.Value.ToString());
        }

        private void numericUpDown_duration_ValueChanged(object sender, EventArgs e)
        {
            xml.Update("intermedia", "duration", numericUpDown_duration.Value.ToString());
        }

        private void checkBox_sleep_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_sleepStart.Enabled = checkBox_sleep.CheckState == CheckState.Checked ? true : false;
            dateTimePicker_sleepEnd.Enabled = dateTimePicker_sleepStart.Enabled;

            label11.ForeColor =
                (checkBox_sleep.CheckState == CheckState.Checked) ?
                Color.FromKnownColor(System.Drawing.KnownColor.ControlText) :
                Color.FromKnownColor(System.Drawing.KnownColor.InactiveCaption);

            xml.Update("sleep", "enable", checkBox_sleep.Checked ? "1" : "0");
        }
    }
}

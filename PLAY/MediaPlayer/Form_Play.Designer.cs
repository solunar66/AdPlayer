namespace PLAY
{
    partial class Form_Play
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Play));
            this.timer_title = new System.Windows.Forms.Timer(this.components);
            this.label_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.checkBox_interval = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDown_duration = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_interval = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button_idle = new System.Windows.Forms.Button();
            this.comboBox_idle = new System.Windows.Forms.ComboBox();
            this.label_idle = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown_idle = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button_Config = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_fontbg = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Font = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBox_scr = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox_sleep = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_sleepEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_sleepStart = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Play = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer_monitor = new System.Windows.Forms.Timer(this.components);
            this.button_help = new System.Windows.Forms.Button();
            this.button_about = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.axFramerControl1 = new AxDSOFramer.AxFramerControl();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_duration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_idle)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(10, 558);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(41, 12);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "label1";
            this.label_title.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button_Exit);
            this.panel1.Controls.Add(this.button_Play);
            this.panel1.Location = new System.Drawing.Point(514, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 557);
            this.panel1.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label17);
            this.panel8.Controls.Add(this.checkBox_interval);
            this.panel8.Controls.Add(this.label15);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Controls.Add(this.label16);
            this.panel8.Controls.Add(this.numericUpDown_duration);
            this.panel8.Controls.Add(this.numericUpDown_interval);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Location = new System.Drawing.Point(3, 338);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(260, 80);
            this.panel8.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(81, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 12);
            this.label17.TabIndex = 5;
            this.label17.Text = "幻灯页停留时间";
            // 
            // checkBox_interval
            // 
            this.checkBox_interval.AutoSize = true;
            this.checkBox_interval.Location = new System.Drawing.Point(13, 29);
            this.checkBox_interval.Name = "checkBox_interval";
            this.checkBox_interval.Size = new System.Drawing.Size(96, 16);
            this.checkBox_interval.TabIndex = 8;
            this.checkBox_interval.Text = "启用间隔播放";
            this.checkBox_interval.UseVisualStyleBackColor = true;
            this.checkBox_interval.CheckedChanged += new System.EventHandler(this.checkBox_interval_CheckedChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(232, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 17);
            this.label15.TabIndex = 3;
            this.label15.Text = "秒";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(118, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 17);
            this.label14.TabIndex = 5;
            this.label14.Text = "间隔时限";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(3, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(252, 14);
            this.label16.TabIndex = 3;
            this.label16.Text = "媒体间隔播放内容";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_duration
            // 
            this.numericUpDown_duration.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numericUpDown_duration.Enabled = false;
            this.numericUpDown_duration.Location = new System.Drawing.Point(173, 53);
            this.numericUpDown_duration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_duration.Name = "numericUpDown_duration";
            this.numericUpDown_duration.ReadOnly = true;
            this.numericUpDown_duration.Size = new System.Drawing.Size(54, 21);
            this.numericUpDown_duration.TabIndex = 2;
            this.numericUpDown_duration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_duration.ValueChanged += new System.EventHandler(this.numericUpDown_duration_ValueChanged);
            // 
            // numericUpDown_interval
            // 
            this.numericUpDown_interval.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numericUpDown_interval.Location = new System.Drawing.Point(173, 26);
            this.numericUpDown_interval.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.numericUpDown_interval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_interval.Name = "numericUpDown_interval";
            this.numericUpDown_interval.ReadOnly = true;
            this.numericUpDown_interval.Size = new System.Drawing.Size(53, 21);
            this.numericUpDown_interval.TabIndex = 2;
            this.numericUpDown_interval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_interval.ValueChanged += new System.EventHandler(this.numericUpDown_interval_ValueChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(232, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 17);
            this.label12.TabIndex = 3;
            this.label12.Text = "秒";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.button_idle);
            this.panel6.Controls.Add(this.comboBox_idle);
            this.panel6.Controls.Add(this.label_idle);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.numericUpDown_idle);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(3, 251);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(260, 81);
            this.panel6.TabIndex = 6;
            // 
            // button_idle
            // 
            this.button_idle.Location = new System.Drawing.Point(6, 47);
            this.button_idle.Name = "button_idle";
            this.button_idle.Size = new System.Drawing.Size(92, 21);
            this.button_idle.TabIndex = 7;
            this.button_idle.Text = "媒体文件选择";
            this.button_idle.UseVisualStyleBackColor = true;
            this.button_idle.Click += new System.EventHandler(this.button_idle_Click);
            // 
            // comboBox_idle
            // 
            this.comboBox_idle.FormattingEnabled = true;
            this.comboBox_idle.Location = new System.Drawing.Point(67, 23);
            this.comboBox_idle.Name = "comboBox_idle";
            this.comboBox_idle.Size = new System.Drawing.Size(67, 20);
            this.comboBox_idle.TabIndex = 6;
            this.comboBox_idle.SelectedIndexChanged += new System.EventHandler(this.comboBox_idle_SelectedIndexChanged);
            // 
            // label_idle
            // 
            this.label_idle.AutoEllipsis = true;
            this.label_idle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_idle.Location = new System.Drawing.Point(111, 51);
            this.label_idle.Name = "label_idle";
            this.label_idle.Size = new System.Drawing.Size(136, 17);
            this.label_idle.TabIndex = 5;
            this.label_idle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(11, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "媒体类型";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(156, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "停留";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(252, 14);
            this.label9.TabIndex = 3;
            this.label9.Text = "空闲时段播放内容";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_idle
            // 
            this.numericUpDown_idle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numericUpDown_idle.Location = new System.Drawing.Point(190, 23);
            this.numericUpDown_idle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_idle.Name = "numericUpDown_idle";
            this.numericUpDown_idle.ReadOnly = true;
            this.numericUpDown_idle.Size = new System.Drawing.Size(42, 21);
            this.numericUpDown_idle.TabIndex = 2;
            this.numericUpDown_idle.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_idle.ValueChanged += new System.EventHandler(this.numericUpDown_idle_ValueChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(232, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "秒";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button_Config);
            this.panel4.Location = new System.Drawing.Point(3, 55);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 31);
            this.panel4.TabIndex = 5;
            // 
            // button_Config
            // 
            this.button_Config.Location = new System.Drawing.Point(3, 3);
            this.button_Config.Name = "button_Config";
            this.button_Config.Size = new System.Drawing.Size(249, 23);
            this.button_Config.TabIndex = 1;
            this.button_Config.Text = "修改播放配置";
            this.button_Config.UseVisualStyleBackColor = true;
            this.button_Config.Click += new System.EventHandler(this.button_Config_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button_fontbg);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.button_Font);
            this.panel3.Controls.Add(this.numericUpDown2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(3, 92);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 59);
            this.panel3.TabIndex = 4;
            // 
            // button_fontbg
            // 
            this.button_fontbg.Location = new System.Drawing.Point(6, 31);
            this.button_fontbg.Name = "button_fontbg";
            this.button_fontbg.Size = new System.Drawing.Size(102, 21);
            this.button_fontbg.TabIndex = 6;
            this.button_fontbg.Text = "修改通知背景";
            this.button_fontbg.UseVisualStyleBackColor = true;
            this.button_fontbg.Click += new System.EventHandler(this.button_fontbg_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(114, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "滚动间隔";
            // 
            // button_Font
            // 
            this.button_Font.Location = new System.Drawing.Point(6, 5);
            this.button_Font.Name = "button_Font";
            this.button_Font.Size = new System.Drawing.Size(102, 21);
            this.button_Font.TabIndex = 0;
            this.button_Font.Text = "修改通知字体";
            this.button_Font.UseVisualStyleBackColor = true;
            this.button_Font.Click += new System.EventHandler(this.button_Font_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numericUpDown2.Location = new System.Drawing.Point(171, 6);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.ReadOnly = true;
            this.numericUpDown2.Size = new System.Drawing.Size(55, 21);
            this.numericUpDown2.TabIndex = 2;
            this.numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(227, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "毫秒";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.comboBox_scr);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(3, 212);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(260, 33);
            this.panel5.TabIndex = 3;
            // 
            // comboBox_scr
            // 
            this.comboBox_scr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scr.Enabled = false;
            this.comboBox_scr.FormattingEnabled = true;
            this.comboBox_scr.Location = new System.Drawing.Point(83, 7);
            this.comboBox_scr.Name = "comboBox_scr";
            this.comboBox_scr.Size = new System.Drawing.Size(164, 20);
            this.comboBox_scr.TabIndex = 4;
            this.comboBox_scr.SelectedIndexChanged += new System.EventHandler(this.comboBox_scr_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label8.Location = new System.Drawing.Point(10, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "显示屏选择";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label11);
            this.panel7.Controls.Add(this.checkBox_sleep);
            this.panel7.Controls.Add(this.dateTimePicker_sleepEnd);
            this.panel7.Controls.Add(this.dateTimePicker_sleepStart);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Location = new System.Drawing.Point(3, 424);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(260, 70);
            this.panel7.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(119, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "到";
            // 
            // checkBox_sleep
            // 
            this.checkBox_sleep.AutoSize = true;
            this.checkBox_sleep.Location = new System.Drawing.Point(13, 24);
            this.checkBox_sleep.Name = "checkBox_sleep";
            this.checkBox_sleep.Size = new System.Drawing.Size(96, 16);
            this.checkBox_sleep.TabIndex = 8;
            this.checkBox_sleep.Text = "启用屏幕休眠";
            this.checkBox_sleep.UseVisualStyleBackColor = true;
            this.checkBox_sleep.CheckedChanged += new System.EventHandler(this.checkBox_sleep_CheckedChanged);
            // 
            // dateTimePicker_sleepEnd
            // 
            this.dateTimePicker_sleepEnd.CustomFormat = "HH 时 mm 分 ss 秒";
            this.dateTimePicker_sleepEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_sleepEnd.Location = new System.Drawing.Point(142, 44);
            this.dateTimePicker_sleepEnd.Name = "dateTimePicker_sleepEnd";
            this.dateTimePicker_sleepEnd.ShowUpDown = true;
            this.dateTimePicker_sleepEnd.Size = new System.Drawing.Size(110, 21);
            this.dateTimePicker_sleepEnd.TabIndex = 4;
            this.dateTimePicker_sleepEnd.Leave += new System.EventHandler(this.dateTimePicker_sleepEnd_Leave);
            // 
            // dateTimePicker_sleepStart
            // 
            this.dateTimePicker_sleepStart.CustomFormat = "HH 时 mm 分 ss 秒";
            this.dateTimePicker_sleepStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_sleepStart.Location = new System.Drawing.Point(6, 44);
            this.dateTimePicker_sleepStart.Name = "dateTimePicker_sleepStart";
            this.dateTimePicker_sleepStart.ShowUpDown = true;
            this.dateTimePicker_sleepStart.Size = new System.Drawing.Size(110, 21);
            this.dateTimePicker_sleepStart.TabIndex = 4;
            this.dateTimePicker_sleepStart.Leave += new System.EventHandler(this.dateTimePicker_sleepStart_Leave);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(3, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(252, 14);
            this.label13.TabIndex = 3;
            this.label13.Text = "屏幕休眠时间段";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Location = new System.Drawing.Point(3, 157);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 50);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(114, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "手动设置";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(13, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "采用系统配置";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(234, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "秒";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "幻灯片每页停留时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numericUpDown1.Location = new System.Drawing.Point(171, 23);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(61, 21);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Exit.Location = new System.Drawing.Point(146, 529);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(117, 23);
            this.button_Exit.TabIndex = 2;
            this.button_Exit.Text = "退出系统";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // button_Play
            // 
            this.button_Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Play.Location = new System.Drawing.Point(3, 3);
            this.button_Play.Name = "button_Play";
            this.button_Play.Size = new System.Drawing.Size(260, 46);
            this.button_Play.TabIndex = 0;
            this.button_Play.Text = "开 始 播 放";
            this.button_Play.UseVisualStyleBackColor = true;
            this.button_Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.ShowColor = true;
            // 
            // timer_monitor
            // 
            this.timer_monitor.Enabled = true;
            this.timer_monitor.Interval = 1000;
            this.timer_monitor.Tick += new System.EventHandler(this.timer_monitor_Tick);
            // 
            // button_help
            // 
            this.button_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_help.Location = new System.Drawing.Point(263, 538);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(120, 22);
            this.button_help.TabIndex = 7;
            this.button_help.Text = "帮 助";
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // button_about
            // 
            this.button_about.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_about.Location = new System.Drawing.Point(389, 538);
            this.button_about.Name = "button_about";
            this.button_about.Size = new System.Drawing.Size(120, 22);
            this.button_about.TabIndex = 7;
            this.button_about.Text = "关 于";
            this.button_about.UseVisualStyleBackColor = true;
            this.button_about.Click += new System.EventHandler(this.button_about_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 3);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(496, 529);
            this.axWindowsMediaPlayer1.TabIndex = 8;
            this.axWindowsMediaPlayer1.MouseDownEvent += new AxWMPLib._WMPOCXEvents_MouseDownEventHandler(this.axWindowsMediaPlayer1_MouseDownEvent);
            // 
            // axFramerControl1
            // 
            this.axFramerControl1.Enabled = true;
            this.axFramerControl1.Location = new System.Drawing.Point(0, 0);
            this.axFramerControl1.Name = "axFramerControl1";
            this.axFramerControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFramerControl1.OcxState")));
            this.axFramerControl1.Size = new System.Drawing.Size(75, 23);
            this.axFramerControl1.TabIndex = 9;
            // 
            // Form_Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.axFramerControl1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.button_about);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Play";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "宣传播放系统";
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_duration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_idle)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer_title;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Config;
        private System.Windows.Forms.Button button_Play;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_Font;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_fontbg;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer timer_monitor;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboBox_scr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button_idle;
        private System.Windows.Forms.ComboBox comboBox_idle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown_idle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_idle;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePicker_sleepEnd;
        private System.Windows.Forms.DateTimePicker dateTimePicker_sleepStart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Button button_about;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkBox_interval;
        private System.Windows.Forms.NumericUpDown numericUpDown_interval;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDown_duration;
        private System.Windows.Forms.CheckBox checkBox_sleep;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private AxDSOFramer.AxFramerControl axFramerControl1;
    }
}


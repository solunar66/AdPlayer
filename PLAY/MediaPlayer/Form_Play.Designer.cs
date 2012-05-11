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
            this.panel4 = new System.Windows.Forms.Panel();
            this.button_Config = new System.Windows.Forms.Button();
            this.button_configfile = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_fontbg = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Font = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBox_scr = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Play = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer_monitor = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(10, 460);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(35, 13);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "label1";
            this.label_title.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button_Exit);
            this.panel1.Controls.Add(this.button_Play);
            this.panel1.Location = new System.Drawing.Point(514, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 467);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button_Config);
            this.panel4.Controls.Add(this.button_configfile);
            this.panel4.Location = new System.Drawing.Point(3, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 33);
            this.panel4.TabIndex = 5;
            // 
            // button_Config
            // 
            this.button_Config.Location = new System.Drawing.Point(3, 3);
            this.button_Config.Name = "button_Config";
            this.button_Config.Size = new System.Drawing.Size(154, 25);
            this.button_Config.TabIndex = 1;
            this.button_Config.Text = "修改播放配置";
            this.button_Config.UseVisualStyleBackColor = true;
            this.button_Config.Click += new System.EventHandler(this.button_Config_Click);
            // 
            // button_configfile
            // 
            this.button_configfile.Location = new System.Drawing.Point(163, 3);
            this.button_configfile.Name = "button_configfile";
            this.button_configfile.Size = new System.Drawing.Size(94, 25);
            this.button_configfile.TabIndex = 1;
            this.button_configfile.Text = "打开配置文件";
            this.button_configfile.UseVisualStyleBackColor = true;
            this.button_configfile.Click += new System.EventHandler(this.button_Configfile_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button_fontbg);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.button_Font);
            this.panel3.Controls.Add(this.numericUpDown2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(3, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 64);
            this.panel3.TabIndex = 4;
            // 
            // button_fontbg
            // 
            this.button_fontbg.Location = new System.Drawing.Point(6, 34);
            this.button_fontbg.Name = "button_fontbg";
            this.button_fontbg.Size = new System.Drawing.Size(102, 23);
            this.button_fontbg.TabIndex = 6;
            this.button_fontbg.Text = "修改通知背景";
            this.button_fontbg.UseVisualStyleBackColor = true;
            this.button_fontbg.Click += new System.EventHandler(this.button_fontbg_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(114, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "滚动速度";
            // 
            // button_Font
            // 
            this.button_Font.Location = new System.Drawing.Point(6, 5);
            this.button_Font.Name = "button_Font";
            this.button_Font.Size = new System.Drawing.Size(102, 23);
            this.button_Font.TabIndex = 0;
            this.button_Font.Text = "修改通知字体";
            this.button_Font.UseVisualStyleBackColor = true;
            this.button_Font.Click += new System.EventHandler(this.button_Font_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numericUpDown2.Location = new System.Drawing.Point(171, 7);
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
            this.numericUpDown2.Size = new System.Drawing.Size(55, 20);
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
            this.label4.Location = new System.Drawing.Point(227, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "豪秒";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.comboBox_scr);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(3, 230);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(260, 36);
            this.panel5.TabIndex = 3;
            // 
            // comboBox_scr
            // 
            this.comboBox_scr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scr.Enabled = false;
            this.comboBox_scr.FormattingEnabled = true;
            this.comboBox_scr.Location = new System.Drawing.Point(83, 8);
            this.comboBox_scr.Name = "comboBox_scr";
            this.comboBox_scr.Size = new System.Drawing.Size(164, 21);
            this.comboBox_scr.TabIndex = 4;
            this.comboBox_scr.SelectedIndexChanged += new System.EventHandler(this.comboBox_scr_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label8.Location = new System.Drawing.Point(10, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "显示屏选择";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Location = new System.Drawing.Point(3, 170);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 54);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(114, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "手动设置";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(13, 27);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "采用系统配置";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(232, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "秒";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "幻灯片每页停留时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(171, 25);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Exit.Location = new System.Drawing.Point(3, 434);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(260, 25);
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
            this.button_Play.Size = new System.Drawing.Size(260, 50);
            this.button_Play.TabIndex = 0;
            this.button_Play.Text = "播放广告";
            this.button_Play.UseVisualStyleBackColor = true;
            this.button_Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 3);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(496, 431);
            this.axWindowsMediaPlayer1.TabIndex = 0;
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
            // Form_Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 475);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_Play";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "广告播放系统";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
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
        private System.Windows.Forms.Button button_configfile;
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
    }
}


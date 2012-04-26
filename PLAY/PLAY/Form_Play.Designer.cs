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
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.label_title = new System.Windows.Forms.Label();
            this.timer_title = new System.Windows.Forms.Timer(this.components);
            this.button_Play = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Config = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(30, 30);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(320, 240);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            this.axWindowsMediaPlayer1.KeyPressEvent += new AxWMPLib._WMPOCXEvents_KeyPressEventHandler(this.axWindowsMediaPlayer1_KeyPressEvent);
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(0, 560);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(35, 13);
            this.label_title.TabIndex = 1;
            this.label_title.Text = "label1";
            // 
            // timer_title
            // 
            this.timer_title.Tick += new System.EventHandler(this.timer_title_Tick);
            // 
            // button_Play
            // 
            this.button_Play.Location = new System.Drawing.Point(3, 3);
            this.button_Play.Name = "button_Play";
            this.button_Play.Size = new System.Drawing.Size(75, 23);
            this.button_Play.TabIndex = 2;
            this.button_Play.Text = "播放广告";
            this.button_Play.UseVisualStyleBackColor = true;
            this.button_Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_Config);
            this.panel1.Controls.Add(this.button_Exit);
            this.panel1.Controls.Add(this.button_Play);
            this.panel1.Location = new System.Drawing.Point(388, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(85, 240);
            this.panel1.TabIndex = 3;
            // 
            // button_Config
            // 
            this.button_Config.Location = new System.Drawing.Point(3, 47);
            this.button_Config.Name = "button_Config";
            this.button_Config.Size = new System.Drawing.Size(75, 23);
            this.button_Config.TabIndex = 4;
            this.button_Config.Text = "配置系统";
            this.button_Config.UseVisualStyleBackColor = true;
            this.button_Config.Click += new System.EventHandler(this.button_Config_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(3, 212);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 3;
            this.button_Exit.Text = "退出系统";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Form_Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 295);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_Play";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "广告播放系统";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Timer timer_title;
        private System.Windows.Forms.Button button_Play;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Config;

    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PLAY
{
    public partial class Form_Start : Form
    {
        private string _booting = "媒体文件扫描中";

        private int _dot = 0;

        private bool _close = false;

        private int timeout = 2000;

        public Form_Start()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_close)
            {
                if (_dot * timer1.Interval > timeout)
                {
                    this.Close();
                }
            }

            this.label1.Text = _booting;
            for (int i = 0; i < _dot % 6; i++)
            {
                this.label1.Text = "." + this.label1.Text + ".";
            }
            _dot++;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x10 && !_close)
            {
                _close = true;
                return;
            }

            base.WndProc(ref m);
        }
    }
}

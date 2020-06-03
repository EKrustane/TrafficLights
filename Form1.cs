﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLights
{
    public partial class TrafficLights : Form
    {
        private Timer timerSwitch;

        public TrafficLights()
        {
            InitializeComponent();
            InitializeTrafficLights();
            InitializeTimerSwitch();
        }
        private void InitializeTimerSwitch()
        {
            timerSwitch = new Timer();
            timerSwitch.Interval = 1000;
            timerSwitch.Tick += new EventHandler(TimerSwitch_Tick);
            timerSwitch.Start();
        }

        private void TimerSwitch_Tick(object sender, EventArgs e)
        {
            if(RedLight.BackColor==Color.Gray)
            {
                RedLight.BackColor = Color.Red;
            }
            else
            {
                RedLight.BackColor = Color.Gray;
            }
        }

        private void InitializeTrafficLights()
        {
            this.BackColor = Color.Black;
            RedLight.BackColor = Color.Gray;
            YellowLight.BackColor = Color.Gray;
            GreenLight.BackColor = Color.Gray;
            LightsCircle();
        }

        private void LightsCircle()
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, RedLight.Width, RedLight.Height);
            RedLight.Region = new Region(path);

            System.Drawing.Drawing2D.GraphicsPath path2 = new System.Drawing.Drawing2D.GraphicsPath();
            path2.AddEllipse(0, 0, YellowLight.Width, YellowLight.Height);
            YellowLight.Region = new Region(path2);

            System.Drawing.Drawing2D.GraphicsPath path3 = new System.Drawing.Drawing2D.GraphicsPath();
            path3.AddEllipse(0, 0, GreenLight.Width, GreenLight.Height);
            GreenLight.Region = new Region(path3);
        }
    }
}

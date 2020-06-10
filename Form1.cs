using System;
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
        private Timer timerBlink;
        private int tickCount = 0;
        private Label labelTime = null;
        private int hou = 0, min = 0, sec = 0;

        public TrafficLights()
        {
            InitializeComponent();
            InitializeTrafficLights();
            InitializeTimerSwitch();
            InitializeLabelTime();
        }
        private void InitializeLabelTime()
        {
            labelTime = new Label();
            labelTime.Font = new Font("Consolas", 18, FontStyle.Bold);
            labelTime.Width = 150;
            labelTime.Height = 50;
            labelTime.Top = 10;
            labelTime.Left = 30;
            labelTime.ForeColor = Color.White;
            labelTime.Text = "00:00:00";
            this.Controls.Add(labelTime);
        }
        private void InitializeTimerSwitch()
        {
            timerSwitch = new Timer();
            timerSwitch.Interval = 1000;
            timerSwitch.Tick += new EventHandler(TimerSwitch_Tick);
            timerSwitch.Start();

        }
        private void InitializeTimerBlink()
        {
            timerBlink = new Timer();
            timerBlink.Interval = 500;
            timerBlink.Tick += new EventHandler(TimerBlink_Tick);
            timerBlink.Start();
        }

        private void TimerSwitch_Tick(object sender, EventArgs e)
        {
            UpdateClock();
            SwitchLights();
        }

        private void UpdateClock()
        {

        }
        private void SwitchLights()
        {
            switch (tickCount)
            {
                case 0:
                    RedLight.BackColor = Color.Red;
                    break;
                case 3:
                    YellowLight.BackColor = Color.Yellow;
                    //RedLight.BackColor = Color.Gray;
                    break;
                case 5:
                    RedLight.BackColor = Color.Gray;
                    YellowLight.BackColor = Color.Gray;
                    GreenLight.BackColor = Color.Green;
                    break;
                case 6:
                    InitializeTimerBlink();
                    break;
                case 8:
                    timerBlink.Stop();
                    YellowLight.BackColor = Color.Yellow;
                    GreenLight.BackColor = Color.Gray;
                    break;
                case 10:
                    YellowLight.BackColor = Color.Gray;
                    RedLight.BackColor = Color.Red;
                    tickCount = -1;
                    break;
            }
            tickCount++;
        }
        private void TimerBlink_Tick(object sender, EventArgs e)
        {
            if(GreenLight.BackColor == Color.Gray)
            {
                GreenLight.BackColor = Color.Green;
            }
            else
            {
                GreenLight.BackColor = Color.Gray;
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

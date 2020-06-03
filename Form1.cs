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
        int tickCount = 0;

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
        private void InitializeTimerBlink()
        {
            timerBlink = new Timer();
            timerBlink.Interval = 500;
            timerBlink.Tick += new EventHandler(TimerBlink_Tick);
            timerBlink.Start();
        }

        private void TimerSwitch_Tick(object sender, EventArgs e)
        {
            if (tickCount <= 3)
            {

                RedLight.BackColor = Color.Red;
                GreenLight.BackColor = Color.Gray;
                YellowLight.BackColor = Color.Gray;
                tickCount++;

            }
            else if (tickCount > 3 && tickCount <= 6)
            {

                RedLight.BackColor = Color.Gray;
                GreenLight.BackColor = Color.Gray;
                YellowLight.BackColor = Color.Yellow;
                tickCount++;

            }
            else if (tickCount > 6 && tickCount <= 9)
            {

                RedLight.BackColor = Color.Gray;
                GreenLight.BackColor = Color.Green;
                YellowLight.BackColor = Color.Gray;
                if (tickCount > 7 && tickCount<10)
                {
                    InitializeTimerBlink();
                }
                tickCount++;
            }
            else if (tickCount > 9 && tickCount <= 12)
            {

                RedLight.BackColor = Color.Gray;
                GreenLight.BackColor = Color.Gray;
                YellowLight.BackColor = Color.Yellow;
                tickCount++;

            }
            else if (tickCount > 12)
            {

                RedLight.BackColor = Color.Red;
                GreenLight.BackColor = Color.Gray;
                YellowLight.BackColor = Color.Gray;
                tickCount = 0;

            }

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
            timerBlink.Stop();
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

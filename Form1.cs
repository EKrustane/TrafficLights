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
            int d = 100;
            Rectangle red = new Rectangle(0, 0, RedLight.Width, RedLight.Height);
            System.Drawing.Drawing2D.GraphicsPath gp1 = new System.Drawing.Drawing2D.GraphicsPath();
            gp1.AddArc(red.X, red.Y, d, d, 180, 90);
            gp1.AddArc(red.X + red.Width - d, red.Y, d, d, 270, 90);
            gp1.AddArc(red.X + red.Width - d, red.Y + red.Height - d, d, d, 0, 90);
            gp1.AddArc(red.X, red.Y + red.Height - d, d, d, 90, 90);
            RedLight.Region = new Region(gp1);

            Rectangle yellow = new Rectangle(0, 0, YellowLight.Width, RedLight.Height);
            System.Drawing.Drawing2D.GraphicsPath gp2 = new System.Drawing.Drawing2D.GraphicsPath();
            gp2.AddArc(yellow.X, yellow.Y, d, d, 180, 90);
            gp2.AddArc(yellow.X + yellow.Width - d, yellow.Y, d, d, 270, 90);
            gp2.AddArc(yellow.X + yellow.Width - d, yellow.Y + yellow.Height - d, d, d, 0, 90);
            gp2.AddArc(yellow.X, yellow.Y + yellow.Height - d, d, d, 90, 90);
            YellowLight.Region = new Region(gp2);

            Rectangle green = new Rectangle(0, 0, GreenLight.Width, GreenLight.Height);
            System.Drawing.Drawing2D.GraphicsPath gp3 = new System.Drawing.Drawing2D.GraphicsPath();
            gp3.AddArc(green.X, green.Y, d, d, 180, 90);
            gp3.AddArc(green.X + green.Width - d, green.Y, d, d, 270, 90);
            gp3.AddArc(green.X + green.Width - d, green.Y + green.Height - d, d, d, 0, 90);
            gp3.AddArc(green.X, green.Y + green.Height - d, d, d, 90, 90);
            GreenLight.Region = new Region(gp3);
        }
    }
}

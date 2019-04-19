using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W5.T1.DyerSamuel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clockTimer.Start();
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(SystemColors.Control);
            ClockControl clock = new ClockControl(pictureBox1.Width);

            g.DrawLine(clock.returnPen("hour"), clock.Origin, clock.updateHours());
            g.DrawLine(clock.returnPen("minute"), clock.Origin, clock.updateMinutes());
            g.DrawLine(clock.returnPen("second"), clock.Origin, clock.updateSeconds());
            //label1.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();     //for testing
        }
    }
}

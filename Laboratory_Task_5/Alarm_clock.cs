using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_Task_5
{
    public partial class Alarm_clock : Form
    {
        public int hours, minutes;
        DateTime time = new DateTime();
        TimeSpan interval = new TimeSpan();
        Alarm_clock_2 alarm_Clock_2 = new Alarm_clock_2();
        public Alarm_clock()
        {
            InitializeComponent();
        }

        private void Alarm_clock_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            timer1.Interval = 1000;
            timer1.Start();
            this.ShowInTaskbar = false;
            notifyIcon1.Click += notifyIcon1_Click;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();           
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            minutes = (int)numericUpDown2.Value;
            hours = (int)numericUpDown1.Value;
            interval = new TimeSpan(hours,minutes,0);
            time = DateTime.Now + interval;
            timer2.Interval = 1000;
            timer2.Start();
            //label1.Text = String.Format("{0}:{1}", time.Hour, time.Minute);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now.Hour == time.Hour)&&(DateTime.Now.Minute == time.Minute))
            //if (DateTime.Compare(DateTime.Now,time)==0)
            {
                alarm_Clock_2.time = time;
                alarm_Clock_2.Show();                
                timer2.Stop();
            }
        }

      

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) button1.Enabled = true;
            else button1.Enabled = false;
        }
    }
}

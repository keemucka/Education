using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Laboratory_Task_5
{
    public partial class Form1 : Form
    {       
        decimal minutes, seconds;
        int time;   
        
       
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {           
            time--;
            label3.Text = string.Format($"{time / 60:d2}:{time % 60:d2}");        
            if (time == 0)
            {
                timer1.Enabled = false;               
                MessageBox.Show("Время истекло");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //date = DateTime.Now;
            //timer1.Interval = 10;
            //timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;              
            minutes = numericUpDown1.Value;
            seconds = numericUpDown2.Value;
            time = (int)(minutes * 60 + seconds);              
          

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}

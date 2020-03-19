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
    public partial class Alarm_clock_2 : Form
    {
        public DateTime time = new DateTime();        
       
        public Alarm_clock_2()
        {
            InitializeComponent();
        }

        private void Alarm_clock_2_Load(object sender, EventArgs e)
        {
            label1.Text = time.Hour.ToString() + ":" + time.Minute.ToString();
            label2.Text = "Время прошло";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

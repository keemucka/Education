using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Task_2
{
    public partial class Form1 : Form
    {
        int i = 5;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            if (info.CheckRecipientInfo(textBox1, textBox2)&&(i!=5))
            {
                Form2 form2 = new Form2(new List<string>{ textBox1.Text, textBox2.Text, textBox5.Text, textBox6.Text }, i, this, richTextBox1);
                form2.Show();
                this.Hide();
            }
    }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[0];
            i = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[1];
            i = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[2];
            i = 2;
        }
    }
}

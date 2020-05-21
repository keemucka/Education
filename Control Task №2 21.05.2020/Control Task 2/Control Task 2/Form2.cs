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
    public partial class Form2 : Form
    {
        public List<string> info;
        public int numOfpicture;
        Form1 form1;
        public Form2(List<string> info, int numOfpicture, Form1 form1, RichTextBox richTextBox)
        {           
            InitializeComponent();
            this.info = info;
            this.numOfpicture = numOfpicture;
            this.form1 = form1;
            switch(numOfpicture)
            {
                case 0:
                    {
                        this.BackgroundImage = imageList1.Images[0];
                    }break;
                case 1:
                    {
                        this.BackgroundImage = imageList1.Images[1];
                    }
                    break;
                case 2:
                    {
                        this.BackgroundImage = imageList1.Images[2];
                    }
                    break;
            }
            label5.Text = info[0];
            label6.Text = info[1];
            label7.Text = info[2];
            label8.Text = info[3];
            richTextBox1.Text = richTextBox.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.AddPostCard(new List<string>{ label5.Text,label6.Text,label7.Text,label8.Text});
            MessageBox.Show("Открытка отправлена");
            this.Close();
            form1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }
    }
}

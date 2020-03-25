using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Password
{   

    public partial class Form2 : Form
    {
        public User currentUser;
        public int currentLine;
        public int currentLineMetod
        {
            get { return currentLine;}
            set { currentLine = value;}
        }

        public User currentUserMetod
        {
            get { return currentUser; }
            set { currentUser = value; }
        }
        public void ChangePassword(string newPassword)
        {
            string[] s; 
            string[] data = File.ReadAllLines(@"C:\Азат\КНИТУ\Визуальное программирование\Laboratory Task 6\Password\user.txt");
            for (int i = 0;i<data.Length;i++)
            {               
                if (i == currentLine)
                {
                    s = data[i].Split(' ');
                    s[1] = newPassword;
                    data[i] = s[0] + " " + s[1] + " " + s[2];
                }
            }            
            File.WriteAllLines(@"C:\Азат\КНИТУ\Визуальное программирование\Laboratory Task 6\Password\user.txt", data);  
        }

        public Form2()
        {
            InitializeComponent(); 
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePassword(textBox1.Text);
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = currentUser.role;
        }
    }
}

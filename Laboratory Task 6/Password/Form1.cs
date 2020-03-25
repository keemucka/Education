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

    public partial class Form1 : Form
    {      
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            User UserForCheck = new User(textBox1.Text, textBox2.Text, null);
            UserForCheck.checkUser(UserForCheck);  
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }

    public class User
    {

        public string login;
        public string password;
        public string role;
        public bool IsUserExist = false;

        public User(string login, string password, string role)
        {
            this.login = login;
            this.password = password;
            this.role = role;
        }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public void checkUser(User UserForCheck)
        {
            string[] info;
            string s;
            StreamReader sr = new StreamReader(@"C:\Азат\КНИТУ\Визуальное программирование\Laboratory Task 6\Password\user.txt");
            int numOfLine = 0;
            while ((s = sr.ReadLine()) != null)
            {
                info = s.Split(' ');
                User user = new User(info[0], info[1], info[2]);
                if ((user.login == UserForCheck.login) && (user.password == UserForCheck.password))
                {

                    UserForCheck.role = info[2];
                    IsUserExist = true;
                    Form2 form2 = new Form2();
                    form2.currentLineMetod = numOfLine;
                    form2.currentUserMetod = UserForCheck;
                    form2.Show();
                    break;
                }
                numOfLine++;
            }
            sr.Close();
            if (IsUserExist == false)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}

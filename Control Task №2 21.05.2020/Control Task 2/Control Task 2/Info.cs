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
    class Info
    {
        public Model12 db = new Model12();
        public Info()
        {

        }

        public bool CheckRecipientInfo(TextBox textBox1, TextBox textBox2)
        {
            int ok = 0;
            List<string> RecipientInfo = new List<string>();
            if (textBox1.Text != "")
            {
                string[] se;
                try
                {
                   se = textBox1.Text.Split(' ');
                }
                catch
                {
                    MessageBox.Show("Введите ФИО в именительном падеже через пробел");
                }
                string s = textBox2.Text;
                for (int i = 0; i < s.Length; i++)
                {
                    if ((s[i] == '@') && (s[i] != '.') && (ok == 0)) ok++;
                    if ((ok == 1) && (s[i] == '.')) ok++;
                }
            }
            else MessageBox.Show("Введите данные");
            if (ok != 2)
            {
                MessageBox.Show("Некорректно введенные данные");
                return false;
            }
            else return true;  

        }

        public void AddPostCard(List<string> info)
        {
            try
            {
                string[] s = info[0].Split(' ');
                int number_of_s = db.sender.Max(n => n.id_sender) + 1;
                sender sender = new sender
                {
                    id_sender = number_of_s,
                    surname = s[0],
                    name = s[1],
                    lastlename = s[2],
                    email = info[1]
                };
                s = info[2].Split(' ');
                int number_of_r = db.recipient.Max(n => n.id_recipient) + 1;
                recipient recipient = new recipient
                {
                    id_recipient = number_of_s,
                    surname = s[0],
                    name = s[1],
                    lastlename = s[2],
                    email = info[3]
                };
                postcard postcard;
                int number_of_pc = db.postcard.Max(n => n.id_postcard) + 1;
                postcard = new postcard
                {
                    id_postcard = number_of_pc,
                    id_recipient = number_of_r,
                    id_sender = number_of_s,
                    date = DateTime.Now
                };
                db.postcard.Add(postcard);
                db.recipient.Add(recipient);
                db.sender.Add(sender);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lb8
{
    public partial class FormAddStudent : Form
    {
        public bool Correct()
        {
            bool res = true;
            string s = textBox1.Text.Trim();
            s[0].ToString().ToUpper();
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                {
                    MessageBox.Show("Допустимы только буквенные символы");
                    res = false;
                }
            }
            textBox1.Text = s;
            s = textBox2.Text.Trim();
            s[0].ToString().ToUpper();
            textBox2.Text = s;
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                {
                    MessageBox.Show("Допустимы только буквенные символы");
                    res = false;
                }
            }
            return res;
        }

        Form1 form1 = new Form1();
        public demoEntities db = new demoEntities();       
        public FormAddStudent()
        {
            InitializeComponent();

            var group_for_list = (from g in db.groups
                                  select g.name_group).Distinct();

            foreach (string it in group_for_list)
            {
                comboBox1.Items.Add(it);
            }
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("Введите данные");
            }
            else if (Correct())
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Выберите критерий");
                }
                else
                {
                    var query = (from g in db.groups
                                 where g.name_group == comboBox1.SelectedItem.ToString()
                                 select g.code_group).ToList();
                    int number_of_student = db.students.Max(n => n.code_stud) + 1;

                    students new_student = new students
                    {
                        code_stud = number_of_student,
                        surname = textBox1.Text,
                        name = textBox2.Text,
                        code_group = query[0]
                    };
                    db.students.Add(new_student);

                    db.SaveChanges();
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.Activate();
            this.Close();
        }        
    }
}

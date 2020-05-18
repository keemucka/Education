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
    public partial class FormEditStudent : Form
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
        students item;
        public FormEditStudent(students stud)
        {
            item = stud;
            InitializeComponent();
            var group_of_list = (from g in db.groups
                                 select g.name_group).Distinct();

            foreach (string it in group_of_list) comboBox1.Items.Add(it);

            textBox1.Text = item.surname.ToString();
            textBox2.Text = item.name.ToString();

            var query = (from g in db.groups
                         where g.code_group == item.code_group
                         select g.name_group).ToList();

            comboBox1.SelectedItem = query[0];
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
                    var result = ((Form1)Owner).db.students.SingleOrDefault(w => w.code_stud == item.code_stud);
                    result.surname = textBox1.Text.ToString();
                    result.name = textBox2.Text.ToString();
                    var query = (from g in db.groups
                                 where g.name_group == comboBox1.SelectedItem.ToString()
                                 select g.code_group).ToList();
                    result.code_group = query[0];
                    ((Form1)Owner).db.SaveChanges();

                    ((Form1)Owner).studentsheet = ((Form1)Owner).db.students.OrderBy(o => o.code_stud).ToList();
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

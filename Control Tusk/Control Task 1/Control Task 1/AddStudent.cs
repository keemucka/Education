using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Task_1
{
    public partial class AddStudent : Form
    {
        public void Correct()
        {
            string s = textBox1.Text.Trim();
            s[0].ToString().ToUpper();
            textBox1.Text = s;
            s = textBox2.Text.Trim();
            s[0].ToString().ToUpper();
            textBox2.Text = s;
        }

        public contEntities db = new contEntities();

        public AddStudent()
        {
            InitializeComponent();

            var group_for_list = (from g in db.s_in_group
                                  select g.group_num).Distinct();

            foreach (int it in group_for_list)
            {
                comboBox1.Items.Add(it);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Correct();
            var query = (from g in db.s_in_group
                         where g.group_num.ToString() == comboBox1.SelectedItem.ToString()
                         select g.id_group).ToList();
            int number_of_student = db.s_students.Max(n => n.id) + 1;

            s_students new_student = new s_students
            {
                id = number_of_student,
                surname = textBox1.Text,
                name = textBox2.Text,
                middlename = textBox3.Text,
                id_group = query[0]
            };
            db.s_students.Add(new_student);

            db.SaveChanges();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

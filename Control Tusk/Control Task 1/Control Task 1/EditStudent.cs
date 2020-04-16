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
    public partial class EditStudent : Form
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
        s_students item;
        public EditStudent(s_students stud)
        {
            item = stud;
            InitializeComponent();
            var group_of_list = (from g in db.s_in_group
                                 select g.group_num).Distinct();
                 

            foreach (int it in group_of_list) comboBox1.Items.Add(it);

            textBox1.Text = item.surname.ToString();
            textBox2.Text = item.name.ToString();
            textBox3.Text = item.middlename.ToString();

            var query = (from g in db.s_in_group
                         where g.id_group == item.id_group
                         select g.group_num).ToList();

            comboBox1.SelectedItem = query[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Correct();
            

            var result = ((Students)Owner).db.s_students.SingleOrDefault(w => w.id == item.id);
            result.surname = textBox1.Text.ToString();
            result.name = textBox2.Text.ToString();
            var query = (from g in db.s_in_group
                         where g.group_num.ToString() == comboBox1.SelectedItem.ToString()
                         select g.id_group).ToList();
            result.id_group = query[0];
            ((Students)Owner).db.SaveChanges();

            ((Students)Owner).studentsheet = ((Students)Owner).db.s_students.OrderBy(o => o.id).ToList();
            this.Close();

            db.SaveChanges();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Students s = new Students();
            s.Activate();
            this.Close();
        }
    }
}

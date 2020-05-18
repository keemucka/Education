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
    public partial class Marks : Form
    {
        public demoEntities db = new demoEntities();

        public List<progress> progresssheet;

        public Marks()
        {
            InitializeComponent();
        }

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
            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = (from prog in db.progress
                         join g in db.students on prog.code_stud equals g.code_stud
                         join k in db.subjects on prog.code_subject equals k.code_subject
                         join l in db.lectors on prog.code_lector equals l.code_lector
                         join h in db.groups on g.code_group equals h.code_group
                         orderby h.code_group
                         select new {h.name_group,g.name,g.surname,k.name_subject,l.name_lector, prog.estimate,prog.date_exam}).ToList();
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Выберите критерий");
            }
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    dataGridView1.DataSource = query.Where(p => p.name_subject.ToString() == textBox1.Text.ToString()).ToList(); break;
                case 1:
                    dataGridView1.DataSource = query.Where(p => p.name_lector.ToString() == textBox1.Text.ToString()).ToList(); break;
                case 2:
                    dataGridView1.DataSource = query.Where(p => p.surname.ToString() == textBox1.Text.ToString()).ToList(); break;
               
            }
            dataGridView1.Update();
            
        }
    }
}

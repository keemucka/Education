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
    public partial class Students : Form
    {
        public contEntities db = new contEntities();
        public List<s_students> studentsheet;

        public Students()
        {
            InitializeComponent();
            studentsheet = (from stud in db.s_students
                            select stud).ToList();

            var query = (from stud in studentsheet
                         join g in db.s_in_group on stud.id_group equals g.id_group
                         orderby stud.id
                         select new { stud.id, stud.surname, stud.name, stud.middlename, g.kurs_num, g.group_num }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;
            //if (dataGridView1.RowCount == 0) label1.Visible = true;
            //else label1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Students_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = (from stud in studentsheet
                         join g in db.s_in_group on stud.id_group equals g.id_group
                         orderby stud.id
                         select new { stud.id, stud.surname, stud.name, stud.middlename, g.kurs_num, g.group_num }).ToList();
            dataGridView1.DataSource = query;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var query = (from stud in studentsheet
                         join g in db.s_in_group on stud.id_group equals g.id_group
                         orderby stud.id
                         select new { stud.id, stud.surname, stud.name, stud.middlename, g.kurs_num, g.group_num }).ToList();
            if (textBox1.Text != "")
                dataGridView1.DataSource = query.Where(p => p.surname.ToString() == textBox1.Text.ToString()).ToList();
            if (textBox2.Text != "")
                dataGridView1.DataSource = query.Where(p => p.kurs_num.ToString() == textBox1.Text.ToString()).ToList();
            if (textBox3.Text != "")
                dataGridView1.DataSource = query.Where(p => p.group_num.ToString() == textBox1.Text.ToString()).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddStudent add = new AddStudent();
            add.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<s_students> query = (from stud in db.s_students
                                    select stud).ToList();
            s_students item = query.First(w => w.id.ToString() ==
                dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());

            EditStudent editSt = new EditStudent(item);
            editSt.Owner = this;
            editSt.Show();
        }
    }
}

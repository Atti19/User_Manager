using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Manager
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void labelNume_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load_1(object sender, EventArgs e)
        {
            label1.Text = Form2.textPassedForm1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            DBconnect dBconnect = new DBconnect(); 
            Stack all_members = new Stack();
            all_members = dBconnect.Select_all();
            while(all_members.Count > 0)
            {
                string nivel = all_members.Pop().ToString();
                string tel = all_members.Pop().ToString();
                string cnp = all_members.Pop().ToString();
                string name = all_members.Pop().ToString(); 
                string id = all_members.Pop().ToString();
                textBox1.Text += "ID: " + id + ", ";
                textBox1.Text += "Name: " + name + ", ";
                textBox1.Text += "CNP: " + cnp + ", ";
                textBox1.Text += "TEL: " + tel + ", ";
                textBox1.Text += "Nivel: " + nivel + ", ";
                textBox1.AppendText("\r\n");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            DBconnect dbconnect = new DBconnect();
            Stack all_activity = new Stack();
            all_activity = dbconnect.Select_all_Activities();
            while(all_activity.Count > 0)
            {
                string activity = all_activity.Pop().ToString();
                string name = all_activity.Pop().ToString();
                textBox1.Text += "Name: " + name + ", ";
                textBox1.Text += "Activity: " + activity + ", ";
                textBox1.AppendText("\r\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string textboxText = textBox1.Text;
            DBconnect dbconnect = new DBconnect();
            dbconnect.Update(textboxText);
            MessageBox.Show("Updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string textboxText = textBox1.Text;
            DBconnect dBconnect = new DBconnect();
            dBconnect.Delete(textboxText);
            MessageBox.Show("Deleted");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

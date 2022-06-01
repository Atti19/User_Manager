using System;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnect dBconnect = new DBconnect();
            string Nameu = textBox1.Text.ToString();
            string passw = textBox2.Text.ToString();
            string CNP = textBox3.Text.ToString();
            long tel = Convert.ToInt64(textBox4.Text);
            dBconnect.Insert(Nameu, passw, CNP, tel);
            MessageBox.Show("Registration succesful");
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }
    }
}

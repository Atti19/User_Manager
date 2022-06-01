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
using System.Net;
using MySql.Data.MySqlClient;

namespace User_Manager
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        public static string textPassedForm1;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassw.Clear();
            txtUsername.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] list = new string[6];
            string name = txtUsername.Text;
            DBconnect test = new DBconnect();
            list = test.Select(name);
            //list5 = nivel
            if(txtUsername.Text == list[1] && txtPassw.Text == list[2])
            {
                if (list[5].Equals("1"))
                {
                    //User form
                    Form3 f2 = new Form3();
                    textPassedForm1 = txtUsername.Text;
                    f2.Show();
                    this.Hide();
                }
                else
                {
                    //admin form
                }
            }
            else
            {
                MessageBox.Show("Wrong password or user");
                txtPassw.Clear();
            }
        }

    }
}

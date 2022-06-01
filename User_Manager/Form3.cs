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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            labelNume.Text = Form2.textPassedForm1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnect dBconnect = new DBconnect();
            dBconnect.Insert_activity(Form2.textPassedForm1);
            MessageBox.Show("Entry registered");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            Stack infoStack = new Stack();
            DBconnect data = new DBconnect();
            infoStack = data.Select_activity(Form2.textPassedForm1);
            while(infoStack.Count > 0)
            {
                label2.Text += (infoStack.Pop().ToString()) + "\n";
                
            }
        }
    }
}

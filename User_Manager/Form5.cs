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
    }
}

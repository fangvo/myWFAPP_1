using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class SQlLogin : Form
    {
        public SQlLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = textBox1.Text;
            string t2 = textBox2.Text;
            string t3 = textBox3.Text;
            string s = @"Data Source=" + t1 + ";Initial Catalog=MyDB;User Id=" + t2 + ";Password=" + t3;
            Form1.connectionString = s;
            this.Close();

        }

    }
}

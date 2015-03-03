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
            string _t1 = Properties.Settings.Default.ConURL;
            string _t2 = Properties.Settings.Default.ConID;
            string _t3 = Properties.Settings.Default.ConPas;

            textBox1.Text = _t1;
            textBox2.Text = _t2;
            textBox3.Text = _t3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string t1 = textBox1.Text;
            string t2 = textBox2.Text;
            string t3 = textBox3.Text;

            Properties.Settings.Default.ConURL = t1;
            Properties.Settings.Default.ConID = t2;
            Properties.Settings.Default.ConPas = t3;
            Properties.Settings.Default.Save();
            string s = @"Data Source=" + t1 + ";Initial Catalog=MyDB;User Id=" + t2 + ";Password=" + t3;
            Form1.connectionString = s;
            this.Close();

        }

    }
}

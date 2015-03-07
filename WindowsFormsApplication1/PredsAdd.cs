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
    public partial class PredsAdd : Form
    {
        int company_id = 0;

        public PredsAdd(int _company_id)
        {
            InitializeComponent();
            company_id = _company_id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.SQLExecuteNonQuery(String.Format("INSERT INTO Predst VALUES ( @name,@phone,@id );"),
                new Dictionary<string, object> {
                { "@name", textBox1.Text },
                { "@phone", textBox2.Text },
                { "@id", company_id }
                });
                this.Close();
        }
    }
}

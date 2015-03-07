using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ImpAddForm : Form
    {


        public ImpAddForm()
        {
            InitializeComponent();
            this.Load += ClientAddForm_Load;
        }

        void ClientAddForm_Load(object sender, EventArgs e)
        {
        }



        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBoxName.Text;
            String adres = textBoxAdres.Text;
            int staz = Int32.Parse(textBoxStaz.Text);
            long zp = Int64.Parse(textBoxZP.Text);
            String dolz = textBoxDolz.Text;
            Form1.SQLQuery("INSERT INTO Imp VALUES ( @name,@adres,@staz,@zp,@dolz,@otdel,@login,@date,@date )",
                new Dictionary<string, object> 
                {   { "@name", name },
                    { "@login", textBox1.Text } ,
                    {"@adres", adres},
                    {"@staz", staz},
                    {"@zp", zp},
                    {"@dolz", dolz},
                    {"@otdel",textBox2.Text},
                    {"@date", "1/1/1753 12:00:00"}
                });

            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

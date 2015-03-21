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
    public partial class ClientAddForm : Form
    {


        public ClientAddForm()
        {
            InitializeComponent();
            this.Load += ClientAddForm_Load;
        }

        void ClientAddForm_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
        }



        private void button1_Click(object sender, EventArgs e)
        {

            /// Отправка даныйх в дб

            long inn = Int64.Parse(textBoxINN.Text);
            long kpp = Int64.Parse(textBoxKPP.Text);
            long rs = Int64.Parse(textBoxRS.Text);
            long ks = Int64.Parse(textBoxKS.Text);
            long bik = Int64.Parse(textBoxBIK.Text);
            Form1.SQLExecuteNonQuery(String.Format("INSERT INTO Clients VALUES ( @client,@adres,@inn,@kpp,@bank,@rs,@ks,@bik,@type,@dir );"),
                new Dictionary<string, object> {
                { "@client", textBoxClientName.Text },
                { "@adres", textBoxAdres.Text },
                //{ "@phone", textBoxTel.Text }, 
                { "@inn", inn },
                { "@kpp", kpp }, 
                { "@bank", textBoxBank.Text }, 
                { "@rs", rs }, 
                { "@ks", ks },
                { "@bik", bik },
                { "@type", comboBox2.SelectedItem.ToString() },
                { "@dir", textBox1.Text }

                });

            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String client = textBoxClientName.Text;
            String adres = textBoxAdres.Text;
            String phone = textBoxTel.Text;
            long inn = Int64.Parse(textBoxINN.Text);
            long kpp = Int64.Parse(textBoxKPP.Text);
            String bank = textBoxBank.Text;
            long rs = Int64.Parse(textBoxRS.Text);
            long ks = Int64.Parse(textBoxKS.Text);
            long bik = Int64.Parse(textBoxBIK.Text);
            SqlConnection conn = new SqlConnection(@"Data Source=FANGVO-PC\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True");
            SqlCommand cmd = conn.CreateCommand();
           // cmd.CommandText = String.Format("INSERT INTO Clients VALUES ( '{0}', '{1}', '{2}', {3], {4}, '{5}', {6}, {7}, {8});", client, adres, phone, inn, kpp, bank, rs, ks, bik);
            cmd.CommandText = String.Format("INSERT INTO Clients VALUES ( '" + client + "', '" + adres + "', '" + phone + "', " + inn + ", " + kpp + ", '" + bank + "', " + rs + ", " + ks + ", " + bik + ");");

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            //dgview.Update();
            //dgview.Refresh();
            this.Close();
            
        }
    }
}

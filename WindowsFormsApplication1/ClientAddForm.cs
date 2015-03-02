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
            String client = textBoxClientName.Text;
            String adres = textBoxAdres.Text;
            String phone = textBoxTel.Text;
            long inn = Int64.Parse(textBoxINN.Text);
            long kpp = Int64.Parse(textBoxKPP.Text);
            String bank = textBoxBank.Text;
            long rs = Int64.Parse(textBoxRS.Text);
            long ks = Int64.Parse(textBoxKS.Text);
            long bik = Int64.Parse(textBoxBIK.Text);
            String type = comboBox2.SelectedItem.ToString();
            object[] obj = { client, adres, phone, inn, kpp, bank, rs, ks, bik };
            SqlConnection conn = new SqlConnection(@"Data Source=FANGVO-PC\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True");
            SqlCommand cmd = conn.CreateCommand();
            //cmd.CommandText = String.Format("INSERT INTO Clients VALUES ( '{0}', '{1}', '{2}', {3], {4}, '{5}', {6}, {7}, {8});", obj);
            cmd.CommandText = String.Format("INSERT INTO Clients VALUES ( @client,@adres,@phone,@inn,@kpp,@bank,@rs,@ks,@bik,@type );");
            cmd.Parameters.AddWithValue("@client", client);
            cmd.Parameters.AddWithValue("@adres", adres);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@inn", inn);
            cmd.Parameters.AddWithValue("@kpp", kpp);
            cmd.Parameters.AddWithValue("@bank", bank);
            cmd.Parameters.AddWithValue("@rs", rs);
            cmd.Parameters.AddWithValue("@ks", ks);
            cmd.Parameters.AddWithValue("@bik", bik);
            cmd.Parameters.AddWithValue("@type", type);


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            //dgview.Update();
            //dgview.Refresh();
            this.Close();
            
        }
    }
}

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
    public partial class GoodsAddForm : Form
    {
        public GoodsAddForm()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBoxTName.Text;
            decimal cena = decimal.Parse(textBoxCena.Text);
            Int64 kolvo = Int64.Parse(textBoxKolvo.Text);
            Int64 articyl = Int64.Parse(textBoxTArticyl.Text);
            Int64 cod = Int64.Parse(textBoxStrihCod.Text);
            String ed = textBoxED.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=FANGVO-PC\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO Goods VALUES ( '" + name + "', " + cena + ", " + kolvo + ", " + articyl + ", " + cod + ", '" + ed + "', '2000-01-01' );";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }
    }
}

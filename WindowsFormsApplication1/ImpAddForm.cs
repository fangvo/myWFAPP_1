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
            using (SqlConnection conn = new SqlConnection(Form1.connectionString))
            {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = String.Format("INSERT INTO Imp VALUES ( @name,@adres,@staz,@zp,@dolz );");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@adres", adres);
            cmd.Parameters.AddWithValue("@staz", staz);
            cmd.Parameters.AddWithValue("@zp", zp);
            cmd.Parameters.AddWithValue("@dolz", dolz);


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            }
            //dgview.Update();
            //dgview.Refresh();
            this.Close();
            
        }
    }
}

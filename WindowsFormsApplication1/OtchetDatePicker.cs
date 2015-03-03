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
    public partial class OtchetDatePicker : Form
    {
        public OtchetDatePicker()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void OnLoad(object sender, EventArgs e)
        {

        }

        private void buttonMakeDataGrid_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Form1.connectionString))
            {
                connection.Open();
                string day_1 = dateTimePicker1.Value.ToShortDateString();
                string day_2 = dateTimePicker2.Value.ToShortDateString();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = String.Format("SELECT * FROM {0} WHERE day >= @day1 AND day <= @day2;", "Sells");
                cmd.Parameters.AddWithValue("@day1", day_1);
                cmd.Parameters.AddWithValue("@day2", day_2);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                connection.Close();
                dataGridView1.DataSource = dt;
            }
        }
    }
}

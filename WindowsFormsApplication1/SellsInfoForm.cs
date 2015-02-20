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
    public partial class SellsInfoForm : Form
    {
        int id;
        MyDataGrid dataGrid = new MyDataGrid();

        public SellsInfoForm(int _id)
        {
            InitializeComponent();
            id = _id;
            dataGrid.dataGrid = dataGridView1;
            dataGrid.table_name = "SellInfo";

        }

        private void SellsInfoForm_Load(object sender, EventArgs e)
        {
            Form1.BindDataCB(comboBox1, "Goods", "name");
        }

        private void refereshDG(MyDataGrid dg)
        {
            SqlConnection connection = new SqlConnection(Form1.connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM @table WHERE idofsell = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@table", dg.table_name);
            dg.adapter = new SqlDataAdapter(cmd);
            SqlCommandBuilder sBuilder = new SqlCommandBuilder(dg.adapter);
            dg.ds = new DataSet();
            dg.adapter.Fill(dg.ds, dg.table_name);
            dg.table = dg.ds.Tables[dg.table_name];
            connection.Close();
            dg.dataGrid.DataSource = dg.ds.Tables[dg.table_name];
            dg.dataGrid.ReadOnly = true;
            dg.dataGrid.AllowUserToAddRows = false;
            dg.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}

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
    public partial class Form1 : Form
    {
        SqlCommand sCommand;
        SqlCommandBuilder sBuilder;
        MyDataGrid clientDataGrid,goodsDataGrid,sellsDataGrid;
        static public string connectionString = @"Data Source=FANGVO-PC\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            clientDataGrid = new MyDataGrid();
            goodsDataGrid = new MyDataGrid();
            sellsDataGrid = new MyDataGrid();

            clientDataGrid.dataGrid = dataGridViewClients;
            clientDataGrid.table_name = "Clients";
            clientDataGrid.b_save = buttonClient_Save;
            clientDataGrid.b_new_edit = buttonClient_new;
            clientDataGrid.b_delete = buttonClient_Del;

            goodsDataGrid.dataGrid = dataGridViewGoods;
            goodsDataGrid.table_name = "Goods";
            goodsDataGrid.b_save = buttonSave_Goods;
            goodsDataGrid.b_new_edit = buttonNew_Goods;
            goodsDataGrid.b_delete = buttonDel_Goods;

            sellsDataGrid.dataGrid = dataGridSells;
            sellsDataGrid.table_name = "Sells";


            RefreshDG(clientDataGrid,true);
            RefreshDG(goodsDataGrid,true);
            RefreshDG(sellsDataGrid,false);

            comboBox3.SelectedIndex = 1;


            BindDataCB(comboBox1, "Clients", "Клиент");
            //BindDataCB(comboBox2, "Goods", "name");
            //BindDataCB(comboBox1, "Clients", "Клиент");
            //comboBox1.TextChanged += comboBox1_TextChanged;
            
            
        }

        void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String table_name = "",colum_name = "";

                ComboBox comboBox = (ComboBox) sender;
                if (comboBox == comboBox1) { table_name = "Clients"; colum_name = "Клиент"; }
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = String.Format("select * from {0}", table_name);
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader sdr = null;
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    col.Add(sdr[colum_name].ToString());
                }
                sdr.Close();

                comboBox.AutoCompleteCustomSource = col;
                connection.Close();
            }
            catch
            {
            }
        }

        public static void BindDataCB(ComboBox cb, String table_name,String colom_name)
        {
            DataTable dt = null;

            cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb.AutoCompleteSource = AutoCompleteSource.ListItems;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string strCmd = String.Format("select {0} from {1}", colom_name, table_name);
                using (SqlCommand cmd = new SqlCommand(strCmd, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                    dt = new DataTable(colom_name);
                    da.Fill(dt);
                }
            }

            cb.DataSource = dt;
            cb.DisplayMember = colom_name;
            //cb.ValueMember = "field2";
            //cb.AutoCompleteCustomSource = dt[colom_name];

            }



        public void RefreshDG(MyDataGrid dg,Boolean but)
        {
            string sql = "SELECT * FROM " + dg.table_name;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            sCommand = new SqlCommand(sql, connection);
            dg.adapter = new SqlDataAdapter(sCommand);
            sBuilder = new SqlCommandBuilder(dg.adapter);
            dg.ds = new DataSet();
            dg.adapter.Fill(dg.ds, dg.table_name);
            dg.table = dg.ds.Tables[dg.table_name];
            connection.Close();
            dg.dataGrid.DataSource = dg.ds.Tables[dg.table_name];
            if (but)
            {
                dg.b_save.Enabled = false;
            }
            dg.dataGrid.ReadOnly = true;
            dg.dataGrid.AllowUserToAddRows = false;
            dg.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Сохранить измененые даные из датагрид в бд
        /// </summary>
        /// <param name="dg"></param>

        private void SaveDG(MyDataGrid dg)
        {
            dg.adapter.Update(dg.table);
            dg.dataGrid.ReadOnly = true;
            dg.dataGrid.AllowUserToAddRows = false;
            dg.b_save.Enabled = false;
            dg.b_new_edit.Enabled = true;
            dg.b_delete.Enabled = true;
        }

        /// <summary>
        /// Включить режим редактирования датагрида
        /// </summary>
        /// <param name="dg"></param>

        private void New_EditDG(MyDataGrid dg)
        {
            dg.dataGrid.ReadOnly = false;
            dg.dataGrid.AllowUserToAddRows = true;
            dg.b_save.Enabled = true;
            dg.b_new_edit.Enabled = false;
            dg.b_delete.Enabled = false;
        }

        /// <summary>
        /// Удалить выбраную строку
        /// </summary>
        /// <param name="dg"></param>

        private void DeleteDG(MyDataGrid dg)
        {
            if (MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dg.dataGrid.Rows.RemoveAt(dg.dataGrid.SelectedRows[0].Index);
                dg.adapter.Update(dg.table);
            }
        }

        /// <summary>
        /// save clirnt button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void button5_Click(object sender, EventArgs e)
        {
            SaveDG(clientDataGrid);
        }

        /// <summary>
        /// new/edit client button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button6_Click(object sender, EventArgs e)
        {
            New_EditDG(clientDataGrid);
        }

        /// <summary>
        /// dellete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button7_Click(object sender, EventArgs e)
        {
            DeleteDG(clientDataGrid);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RefreshDG(clientDataGrid,true);
        }

        /// <summary>
        /// Кнопка добовления зариси в таблтцу Clients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void button2_Click_1(object sender, EventArgs e)
        {
            Form clientAddForm = new ClientAddForm();
            clientAddForm.ShowDialog();
        }

        /// <summary>
        /// Кнопка добовления зариси в таблтцу Goods
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button4_Click(object sender, EventArgs e)
        {
            Form goodsAddForm = new GoodsAddForm();
            goodsAddForm.ShowDialog();
        }

        private void buttonSave_Goods_Click(object sender, EventArgs e)
        {
            SaveDG(goodsDataGrid); 
        }

        private void buttonDel_Goods_Click(object sender, EventArgs e)
        {
            DeleteDG(goodsDataGrid); 
        }

        private void buttonNew_Goods_Click(object sender, EventArgs e)
        {
            New_EditDG(goodsDataGrid);            
        }



        /////////////////////////////////////////////Tab5///////////////////////////////////////////////////////////

        private void buttonAdd_Sells_Click(object sender, EventArgs e)
        {
            String name = comboBox1.Text;
            String type = comboBox3.Text;
            int id = 0;
            DateTime date = DateTime.Now;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Sells VALUES ( @name,@type,@date )";
            SqlParameter sinceDateTimeParam = new SqlParameter("@date", SqlDbType.DateTime);
            sinceDateTimeParam.Value = date;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.Add(sinceDateTimeParam);
            conn.Open();
            cmd.ExecuteNonQuery();
            RefreshDG(sellsDataGrid,false);
            cmd.CommandText = "SELECT id FROM Sells WHERE ClientName like @name AND Type like @type AND  day like @date ";
            SqlDataReader sdr = null;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                id = (int)sdr["id"];
            }
            conn.Close();
            SellsInfoForm sif = new SellsInfoForm(id);
            sif.ShowDialog();
        }

    }
}

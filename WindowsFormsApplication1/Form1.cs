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
        MyDataGrid ClientDataGrid;
        MyDataGrid GoodsDataGrid;
        string connectionString = @"Data Source=FANGVO-PC\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            ClientDataGrid = new MyDataGrid();
            GoodsDataGrid = new MyDataGrid();
            ClientDataGrid.dataGrid = dataGridViewClients;
            ClientDataGrid.table_name = "Clients";
            ClientDataGrid.b_save = button5;
            ClientDataGrid.b_new_edit = b
            GoodsDataGrid.dataGrid = dataGridViewGoods;
            GoodsDataGrid.table_name = "Goods";
            RefreshDG(ClientDataGrid, button5);
            RefreshDG(GoodsDataGrid, buttonSave_Goods);
            
        }


        public void RefreshDG(MyDataGrid dg,Button b_save)
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
            dg.dataGrid.ReadOnly = true;
            dg.dataGrid.AllowUserToAddRows = false;
            b_save.Enabled = false;
            dg.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// save clirnt button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void save_DG(MyDataGrid dg)
        {
            ClientDataGrid.adapter.Update(ClientDataGrid.table);
            dataGridViewClients.ReadOnly = true;
            dataGridViewClients.AllowUserToAddRows = false;
            button5.Enabled = false;
            button_Client_new.Enabled = true;
            button7.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClientDataGrid.adapter.Update(ClientDataGrid.table);
            dataGridViewClients.ReadOnly = true;
            dataGridViewClients.AllowUserToAddRows = false;
            button5.Enabled = false;
            button_Client_new.Enabled = true;
            button7.Enabled = true;
        }

        /// <summary>
        /// new client button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridViewClients.ReadOnly = false;
            dataGridViewClients.AllowUserToAddRows = true;
            button5.Enabled = true;
            button_Client_new.Enabled = false;
            button7.Enabled = false;
        }

        /// <summary>
        /// dellete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataGridViewClients.Rows.RemoveAt(dataGridViewClients.SelectedRows[0].Index);
                ClientDataGrid.adapter.Update(ClientDataGrid.table);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RefreshDG(ClientDataGrid,button5);
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
            GoodsDataGrid.adapter.Update(GoodsDataGrid.table);
            dataGridViewGoods.ReadOnly = true;
            dataGridViewGoods.AllowUserToAddRows = false;
            buttonSave_Goods.Enabled = false;
            buttonNew_Goods.Enabled = true;
            buttonDel_Goods.Enabled = true;
        }

        private void buttonDel_Goods_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataGridViewGoods.Rows.RemoveAt(dataGridViewGoods.SelectedRows[0].Index);
                GoodsDataGrid.adapter.Update(GoodsDataGrid.table);
            }
        }

        private void buttonNew_Goods_Click(object sender, EventArgs e)
        {
            dataGridViewGoods.AllowUserToAddRows = true;
            dataGridViewGoods.ReadOnly = false;
            buttonSave_Goods.Enabled = true;
            buttonNew_Goods.Enabled = false;
            buttonDel_Goods.Enabled = false;
            
        }



    }
}

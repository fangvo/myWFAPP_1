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
            ClientDataGrid.b_save = buttonClient_Save;
            ClientDataGrid.b_new_edit = buttonClient_new;
            ClientDataGrid.b_delete = buttonClient_Del;
            GoodsDataGrid.dataGrid = dataGridViewGoods;
            GoodsDataGrid.table_name = "Goods";
            GoodsDataGrid.b_save = buttonSave_Goods;
            GoodsDataGrid.b_new_edit = buttonNew_Goods;
            GoodsDataGrid.b_delete = buttonDel_Goods;
            RefreshDG(ClientDataGrid);
            RefreshDG(GoodsDataGrid);
            
        }


        public void RefreshDG(MyDataGrid dg)
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
            dg.b_save.Enabled = false;
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
            SaveDG(ClientDataGrid);
        }

        /// <summary>
        /// new/edit client button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button6_Click(object sender, EventArgs e)
        {
            New_EditDG(ClientDataGrid);
        }

        /// <summary>
        /// dellete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button7_Click(object sender, EventArgs e)
        {
            DeleteDG(ClientDataGrid);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RefreshDG(ClientDataGrid);
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
            SaveDG(GoodsDataGrid); 
        }

        private void buttonDel_Goods_Click(object sender, EventArgs e)
        {
            DeleteDG(GoodsDataGrid); 
        }

        private void buttonNew_Goods_Click(object sender, EventArgs e)
        {
            New_EditDG(GoodsDataGrid);            
        }



    }
}

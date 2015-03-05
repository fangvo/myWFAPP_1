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


// LIKE '%es%';

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SqlCommand sCommand;
        MyDataGrid clientDataGrid,goodsDataGrid,sellsDataGrid,impDataGrid;
        //static public string connectionString = @"Data Source=FANGVO-PC\SQLEXPRESS;Initial Catalog=MyDB;User Id=fangvo;Password=84695237"";
        static public string connectionString = "";
        public String compName = "Some Name";


        Filters filterFClients,filtersFGoods,filterFSells;

        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(800, 600);
            clientDataGrid = new MyDataGrid();
            goodsDataGrid = new MyDataGrid();
            sellsDataGrid = new MyDataGrid();
            impDataGrid = new MyDataGrid();
            SQlLogin fsqll = new SQlLogin();
            fsqll.ShowDialog();
            this.Load +=Form1_Load;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;

            clientDataGrid.dataGrid = dataGridViewClients;
            clientDataGrid.dataGrid.AllowUserToAddRows = false;
            clientDataGrid.dataGrid.ReadOnly = true;
            clientDataGrid.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientDataGrid.table_name = "Clients";

            goodsDataGrid.dataGrid = dataGridViewGoods;
            goodsDataGrid.dataGrid.AllowUserToAddRows = false;
            goodsDataGrid.dataGrid.ReadOnly = true;
            goodsDataGrid.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            goodsDataGrid.table_name = "Goods";

            sellsDataGrid.dataGrid = dataGridSells;
            sellsDataGrid.dataGrid.AllowUserToAddRows = false;
            sellsDataGrid.dataGrid.ReadOnly = true;
            sellsDataGrid.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            sellsDataGrid.table_name = "Sells";

            impDataGrid.dataGrid = dataGridImp;
            impDataGrid.dataGrid.AllowUserToAddRows = false;
            impDataGrid.dataGrid.ReadOnly = true;
            impDataGrid.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            impDataGrid.table_name = "Imp";


            RefreshDGV(null, clientDataGrid, comboBox2.SelectedItem.ToString());
            RefreshDGV(null, goodsDataGrid, null);
            RefreshDGV(null, sellsDataGrid, null);
            RefreshDGV(null, impDataGrid, null);

            comboBox3.SelectedIndex = 1;


            BindDataCB(comboBox1, "Clients", "Клиент");
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;


            buttonCientFilter.Click += buttonCientFilter_Click;
            buttonGoodsFilters.Click += buttonGoodsFilters_Click;
            buttonSellsFilter.Click += buttonSellsFilter_Click;
            filterFClients = new Filters(GetHeaders(dataGridViewClients), clientDataGrid, comboBox2.SelectedItem.ToString());
            filtersFGoods = new Filters(GetHeaders(dataGridViewGoods), goodsDataGrid, null);
            filterFSells = new Filters(GetHeaders(dataGridSells), sellsDataGrid, null);
        }

        public static void SQLExecuteNonQuery(string command, Dictionary<string, object> sqlparam)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = command;
                        if (sqlparam != null)
                        {
                            foreach (KeyValuePair<string, object> item in sqlparam)
                            {
                                cmd.Parameters.AddWithValue(item.Key, item.Value);
                            }
                        }
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }catch (SqlException)
                    {
                        MessageBox.Show("Error to Connect to SQL Serever", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        public static DataTable SQLQuery(string command, Dictionary<string, object> sqlparam)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = command;
                        if (sqlparam != null)
                        {
                            foreach (KeyValuePair<string, object> item in sqlparam)
                            {
                                cmd.Parameters.AddWithValue(item.Key, item.Value);
                            }
                        }
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        connection.Close();
                        return dt;
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Error to Connect to SQL Serever", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new DataTable();
                }
            }
        }

        void buttonSellsFilter_Click(object sender, EventArgs e)
        {
            filterFSells.Visible = true;
        }

        void buttonGoodsFilters_Click(object sender, EventArgs e)
        {
            filtersFGoods.Visible = true;
        }

        void buttonCientFilter_Click(object sender, EventArgs e)
        {
            filterFClients.Visible = true;
        }

        private void TabIndexChanced(object sender, EventArgs e)
        {
            TabControl tc = (TabControl)sender;
            string s = tc.SelectedTab.Text;
            switch (s)
            {
                case "Клиенты":
                    RefreshDGV(null, clientDataGrid, comboBox2.SelectedItem.ToString());
                    break;
                case "Товары":
                    RefreshDGV(null, goodsDataGrid, null);
                    break;
                case "Сделки":
                    RefreshDGV(null, sellsDataGrid, null);
                    break;
                default:
                    break;
            }
        }



        private List<String> GetHeaders(DataGridView dgv)
        {
            List<string> headers = new List<string>();

            foreach (DataGridViewTextBoxColumn coll in dgv.Columns)
            {
                headers.Add(coll.HeaderText);
            }

            return headers;
        }

        void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDGV(filterFClients.filterList, clientDataGrid, comboBox2.SelectedItem.ToString());
        }

        /*
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
        */

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

            }


        /*
        public void RefreshDG(MyDataGrid dg,Boolean but)
        {
            string sql = "SELECT * FROM " + dg.table_name;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            sCommand = new SqlCommand(sql, connection);
            dg.adapter = new SqlDataAdapter(sCommand);
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
        }*/

        private static string getOper(Filters.FiltersValls filter_item)
        {
            string oper = "";
            switch (filter_item.type)
                    {
                        case "Равно":
                            if (filter_item.vall is string) { oper = "like"; }
                            if (filter_item.vall is long || filter_item.vall is int || filter_item.vall is decimal || filter_item.vall is DateTime) { oper = "="; }
                            break;
                        case "Не Равно":
                            if (filter_item.vall is string) { oper = "not like"; }
                            if (filter_item.vall is long || filter_item.vall is int || filter_item.vall is decimal || filter_item.vall is DateTime) { oper = "!="; }
                            break;
                        case ">=":
                            oper = ">=";
                            break;
                        case "<=":
                            oper = "<=";
                            break;
                        default:
                            break;

                    }
            return oper;
        }

        private static string CreateString(Filters.FiltersValls filter_item, string filter_string,string oper)
        {
            filter_string += " [" + filter_item.coll + "] ";
            if (filter_item.vall is string || filter_item.vall is DateTime) { filter_string += oper + " '" + filter_item.vall + "' "; }
            if (filter_item.vall is long || filter_item.vall is int) { filter_string += oper + filter_item.vall.ToString() + " "; }
            if (filter_item.vall is decimal)
            {
                char[] delimiterChars = { ' ', ',', '.', ':' };
                string[] temp = filter_item.vall.ToString().Split(delimiterChars);
                filter_string += oper + temp[0] + "." + temp[1] + " ";
            }
            if (!filter_item.param.Equals("")) { if (filter_item.param.Equals("И")) { filter_string += "AND"; } else { filter_string += "OR"; } }

            return filter_string;
        }

        public static void RefreshDGV(List<Filters.FiltersValls> filter, MyDataGrid dg,String type)
        {
            string filter_string = "";

            if (type != null && filter == null ){filter_string= String.Format("WHERE TYPE LIKE '{0}'", type);}

            if (filter != null && type != null)
            {
                filter_string = String.Format("WHERE (TYPE LIKE '{0}'", type);
                Boolean first = true;
                foreach (Filters.FiltersValls filter_item in filter)
                {
                    if (filter_item.coll.Equals("")) { break; }


                    string oper = getOper(filter_item);
                    

                    if (first) { filter_string += " and ("; first = false; }


                    filter_string = CreateString(filter_item, filter_string, oper);


                }
                if (first) { filter_string += ")"; } else { filter_string += "))"; }
            }
            else if (filter != null && type == null)
            {
                Boolean b = true;
                filter_string = "WHERE ";
                foreach (Filters.FiltersValls filter_item in filter)
                {
                    if (filter_item.coll.Equals("")) { break; }

                    if (b) { b = false; }
                    string oper = getOper(filter_item);

                    filter_string = CreateString(filter_item, filter_string,oper);


                    
                }
                if (b) { filter_string = ""; }
            }

            //dg.dataGrid.DataSource = dg.ds.Tables[dg.table_name];
            //dg.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataTable dt = SQLQuery(String.Format("SELECT * FROM {0} {1}", dg.table_name, filter_string), null);

            dg.dataGrid.DataSource = dt;
            /*
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = String.Format("SELECT * FROM {0} {1}", dg.table_name, filter_string);
                //cmd.Parameters.AddWithValue("@type", type);
                dg.adapter = new SqlDataAdapter(cmd);
                dg.ds = new DataSet();
                dg.adapter.Fill(dg.ds, dg.table_name);
                dg.table = dg.ds.Tables[dg.table_name];
                connection.Close();
                dg.dataGrid.DataSource = dg.ds.Tables[dg.table_name];
                dg.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            */
        }


        /*
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
        
        public void updateRow(MyDataGrid dg)
        {
            Dictionary<String, Object> dict = new Dictionary<string,object>();
            int rowIndex = dg.dataGrid.SelectedRows[0].Index;
            for (int i = 0; i < dg.dataGrid.Rows[rowIndex].Cells.Count; i++)
            {
                String dkey = dg.dataGrid.Rows[rowIndex].Cells[i].OwningColumn.HeaderText;
                object dval = dg.dataGrid.Rows[rowIndex].Cells[i].Value;
                dict.Add(dkey, dval);
            }
            
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
        */


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

        private void button8_Click(object sender, EventArgs e)
        {
            RefreshDGV(filterFClients.filterList, clientDataGrid, comboBox2.SelectedItem.ToString());
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



        /////////////////////////////////////////////Tab5///////////////////////////////////////////////////////////

        private void buttonAdd_Sells_Click(object sender, EventArgs e)
        {
            String name = comboBox1.Text;
            string type = comboBox3.SelectedItem.ToString();
            int id = 0;
            DateTime date = DateTime.Now;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = String.Format("SELECT IDENT_CURRENT({0}) , IDENT_INCR({0})", "'Sells'");
                SqlDataReader sdr = null;
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    object temp_id = sdr.GetValue(0);
                    object temp_2 = sdr.GetValue(1);
                    id = Convert.ToInt32(temp_id) + Convert.ToInt32(temp_2);
                }
                sdr.Close();
                if (id == 2)
                {
                    cmd.CommandText = "SELECT COUNT(*) AS RowCnt FROM Sells";
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        object temp_id = sdr.GetValue(0);
                        int temp = Convert.ToInt32(temp_id);
                        if (temp == 0)
                        {
                            id = 1;
                        }
                    }
                }
                sdr.Close();
            }
            SellsInfoForm sif = new SellsInfoForm(name, date, id, type, true);
            sif.ShowDialog();
            RefreshDGV(null, sellsDataGrid, null);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            int id = (int)sellsDataGrid.dataGrid.SelectedRows[0].Cells["Id"].Value;
            string name = (string)sellsDataGrid.dataGrid.SelectedRows[0].Cells["ClientName"].Value;
            string type = (string)sellsDataGrid.dataGrid.SelectedRows[0].Cells["Type"].Value;
            DateTime date = (DateTime)sellsDataGrid.dataGrid.SelectedRows[0].Cells["day"].Value;
            
            SellsInfoForm sif = new SellsInfoForm(name,date, id,type,false);
            sif.ShowDialog();
            RefreshDGV(null, sellsDataGrid, null);
        }

        private void buttonOtchet_Click(object sender, EventArgs e)
        {
            Form otchet = new OtchetDatePicker();
            otchet.ShowDialog();

        }

        
        //////////////////////////////////////////////////Tab Imp///////////////////////////////////////////////////


        private void buttonImpAdd_Click(object sender, EventArgs e)
        {
            Form impAddForm = new ImpAddForm();
            impAddForm.ShowDialog();
            RefreshDGV(null, impDataGrid, null);
        }



        
    }
}

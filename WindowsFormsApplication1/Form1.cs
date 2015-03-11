using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


// LIKE '%es%';

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        MyDataGrid clientDataGrid,goodsDataGrid,sellsDataGrid,impDataGrid,predDataGrid;
        //static public string connectionString = @"Data Source=FANGVO-PC\SQLEXPRESS;Initial Catalog=MyDB;User Id=fangvo;Password=84695237"";
        static public string connectionString = "";
        public String compName = "Some Name";
        int company_id = 0;
        DataGridView oldGoodGrid;


        Filters filterFClients,filtersFGoods,filterFSells;

        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(800, 600);
            clientDataGrid = new MyDataGrid();
            goodsDataGrid = new MyDataGrid();
            sellsDataGrid = new MyDataGrid();
            impDataGrid = new MyDataGrid();
            predDataGrid = new MyDataGrid();
            SQlLogin fsqll = new SQlLogin();
            fsqll.ShowDialog();
            this.Load +=Form1_Load;
            this.dataGridViewClients.SelectionChanged += new System.EventHandler(this.dataGridViewClients_SelectionChanged);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            updateLastVxod(DateTime.Now);
            comboBox2.SelectedIndex = 0;

            

            clientDataGrid.dataGrid = dataGridViewClients;
            clientDataGrid.dataGrid.AllowUserToAddRows = false;
            clientDataGrid.dataGrid.ReadOnly = true;
            clientDataGrid.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientDataGrid.dataGrid.RowHeadersVisible = false;
            clientDataGrid.table_name = "Clients";

            goodsDataGrid.dataGrid = dataGridViewGoods;
            goodsDataGrid.dataGrid.AllowUserToAddRows = false;
            goodsDataGrid.dataGrid.ReadOnly = true;
            goodsDataGrid.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            goodsDataGrid.dataGrid.RowHeadersVisible = false;
            goodsDataGrid.table_name = "Goods";

            sellsDataGrid.dataGrid = dataGridSells;
            sellsDataGrid.dataGrid.AllowUserToAddRows = false;
            sellsDataGrid.dataGrid.ReadOnly = true;
            sellsDataGrid.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            sellsDataGrid.dataGrid.RowHeadersVisible = false;
            sellsDataGrid.table_name = "Sells";

            impDataGrid.dataGrid = dataGridImp;
            impDataGrid.dataGrid.AllowUserToAddRows = false;
            impDataGrid.dataGrid.ReadOnly = true;
            impDataGrid.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            impDataGrid.dataGrid.RowHeadersVisible = false;
            impDataGrid.table_name = "Imp";

            predDataGrid.dataGrid = dataGridViewPreds;
            predDataGrid.dataGrid.AllowUserToAddRows = false;
            predDataGrid.dataGrid.ReadOnly = true;
            predDataGrid.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            predDataGrid.dataGrid.RowHeadersVisible = false;
            predDataGrid.table_name = "Predst";


            dataGridViewOthetByTimeAndName.AllowUserToAddRows = false;
            dataGridViewOthetByTimeAndName.ReadOnly = true;
            dataGridViewOthetByTimeAndName.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOthetByTimeAndName.RowHeadersVisible = false;


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

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            SQLExecuteNonQuery("update Imp set last_vixod = @date where login = @login", new Dictionary<string, object> { { "@date", DateTime.Now }, { "@login", Properties.Settings.Default.ConID } });
        }

        private void updateLastVxod(DateTime date)
        {
            SQLExecuteNonQuery("update Imp set last_vxod = @date where login = @login", new Dictionary<string, object> { { "@date", date }, { "@login", Properties.Settings.Default.ConID } });
            

            using (DataTable dt = SQLQuery("select name from imp where login = @login", new Dictionary<string, object> { { "@login", Properties.Settings.Default.ConID } }))
            {

                string s = (string)dt.Rows[0].ItemArray[0];
                Properties.Settings.Default.CurName = s;
                Properties.Settings.Default.Save();
                
            }
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
                    myMhetod();
                    break;
                case "Сделки":
                    RefreshDGV(null, sellsDataGrid, null);
                    break;
                case "Отчеты":
                    BindDataCB(comboBoxOtchetByName, "Imp", "name");
                    break;
                default:
                    break;
            }
        }

        private List<String> GetHeaders(DataGridView dgv)
        {
            List<string> headers = new List<string>();

            foreach (DataGridViewColumn coll in dgv.Columns)
            {
                headers.Add(coll.HeaderText);
            }

            return headers;
        }

        void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDGV(filterFClients.filterList, clientDataGrid, comboBox2.SelectedItem.ToString());
        }

        public static void BindDataCB(ComboBox cb, String table_name, String colom_name)
        {
            DataTable dt = null;

            cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb.AutoCompleteSource = AutoCompleteSource.ListItems;

            dt = SQLQuery(String.Format("select {0} from {1}", colom_name, table_name), null);
            cb.DataSource = dt;
            cb.DisplayMember = colom_name;

        }

        public static List<object> GenerateListFromColum(String table_name, String colom_name)
        {
            List<object> list = new List<object>();

            using (DataTable dt = SQLQuery(String.Format("select {0} from {1}", colom_name, table_name), null))
                {

                    foreach (DataRow item in dt.Rows)
                    {
                        list.Add(item.ItemArray[0]);
                    }
                }
            ;
            return list;

        }

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

            DataTable dt = SQLQuery(String.Format("SELECT * FROM {0} {1}", dg.table_name, filter_string), null);

            dg.table = dt;

            dg.dataGrid.DataSource = dt;
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
            RefreshDGV(filterFClients.filterList, clientDataGrid, comboBox2.SelectedItem.ToString());
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
            RefreshDGV(filtersFGoods.filterList, goodsDataGrid, null);
            myMhetod();
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
            SellsInfoForm sif = new SellsInfoForm(name, date, id, type, true, false);
            sif.ShowDialog();
            RefreshDGV(null, sellsDataGrid, null);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            int id = (int)sellsDataGrid.dataGrid.SelectedRows[0].Cells["Id"].Value;
            string name = (string)sellsDataGrid.dataGrid.SelectedRows[0].Cells["ClientName"].Value;
            string type = (string)sellsDataGrid.dataGrid.SelectedRows[0].Cells["Type"].Value;
            DateTime date = (DateTime)sellsDataGrid.dataGrid.SelectedRows[0].Cells["day"].Value;
            Boolean active = (Boolean)sellsDataGrid.dataGrid.SelectedRows[0].Cells["Active"].Value;

            SellsInfoForm sif = new SellsInfoForm(name, date, id, type, false, active);
            sif.ShowDialog();
            RefreshDGV(null, sellsDataGrid, null);
        }


        
        //////////////////////////////////////////////////Tab Imp///////////////////////////////////////////////////


        private void buttonImpAdd_Click(object sender, EventArgs e)
        {
            Form impAddForm = new ImpAddForm();
            impAddForm.ShowDialog();
            RefreshDGV(null, impDataGrid, null);
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void dataGridViewClients_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            int index_row = 1;
            DataTable dt;

            try
            {
                index_row = dg.SelectedRows[0].Index;
            }

            catch (IndexOutOfRangeException) { return; }
            catch (ArgumentOutOfRangeException) { return; }

            company_id = (int)dg.Rows[index_row].Cells["UID"].Value;

            dt = SQLQuery("Select name,Phone From Predst where [Company _ID] = @id", new Dictionary<string, object> { { "@id", company_id } });
            dataGridViewPreds.DataSource = dt;
        }

        private void buttonPredAdd_Click(object sender, EventArgs e)
        {
            Form predAdd = new PredsAdd(company_id);
            predAdd.ShowDialog();
            dataGridViewPreds.DataSource = SQLQuery("Select name,Phone From Predst where [Company _ID] = @id", new Dictionary<string, object> { { "@id", company_id } });
            
        }


        private void myMhetod()
        {
            
            DataTable dt = goodsDataGrid.table;
            IEnumerable<DataRow> query =
                from tbl in dt.AsEnumerable()
                where tbl.Field<DateTime>("Last") <= DateTime.Now.AddDays(-14)
                select tbl;
            if (query.Count() > 0)
            {
                if (oldGoodGrid == null)
                {
                    oldGoodGrid = new DataGridView();
                    oldGoodGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));

                    oldGoodGrid.AllowUserToAddRows = false;
                    oldGoodGrid.RowHeadersVisible = false;
                    oldGoodGrid.ReadOnly = true;
                    oldGoodGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewGoods.Location = new System.Drawing.Point(3, 150);
                    dataGridViewGoods.Size = new System.Drawing.Size(760, 360);
                    oldGoodGrid.Location = new System.Drawing.Point(3, 35);
                    oldGoodGrid.Size = new System.Drawing.Size(760, 100);
                    this.tabPageGoods.Controls.Add(oldGoodGrid);
                }
                oldGoodGrid.DataSource = query.CopyToDataTable<DataRow>();
            }
            else
            {
                this.Controls.Remove(oldGoodGrid);
                oldGoodGrid = null;
                dataGridViewGoods.Location = new System.Drawing.Point(3, 35);
                dataGridViewGoods.Size = new System.Drawing.Size(760, 475);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form otchet = new Otchet();
            otchet.ShowDialog();
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region OtchetTab

        private void buttonMakeDataGrid_Click(object sender, EventArgs e)
        {
            dataGridViewOthetByTimeAndName.DataSource = GetDataTableOtchet();
        }

        private DataTable GetDataTableOtchet()
        {
            string day_1 = dateTimePicker1.Value.ToShortDateString();
            string day_2 = dateTimePicker2.Value.ToShortDateString();
            string s1 = "";

            string cbtext = comboBoxOtchetByName.Text;
            if (!cbtext.Equals(""))
            {
                s1 = String.Format("and [Кем] = '{0}'", cbtext);
            }
            return Form1.SQLQuery(
                String.Format("SELECT ClientName,Type,day,SUM FROM {0} WHERE (day >= @day1 AND day <= @day2 and Active = 'true'){1};", "Sells", s1),
                new Dictionary<string, object> { { "@day1", day_1 }, { "@day2", day_2 } }
                );
        }

        private decimal GetSumOtchet()
        {
            string day_1 = dateTimePicker1.Value.ToShortDateString();
            string day_2 = dateTimePicker2.Value.ToShortDateString();
            string s1 = "";

            string cbtext = comboBoxOtchetByName.Text;
            if (!cbtext.Equals(""))
            {
                s1 = String.Format("and [Кем] = '{0}'", cbtext);
            }
            DataTable dt = Form1.SQLQuery(
                String.Format("SELECT SUM(SUM) FROM {0} WHERE (day >= @day1 AND day <= @day2 and Active = 'true'){1};", "Sells", s1),
                new Dictionary<string, object> { { "@day1", day_1 }, { "@day2", day_2 } }
                );
            return (decimal)dt.Rows[0].ItemArray[0];
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string s = "";
            if (!comboBoxOtchetByName.Text.Equals(""))
            {
                s = String.Format("Отфильтровано по '{0}'", comboBoxOtchetByName.Text);
            }
            Dictionary<string, object> d = new Dictionary<string, object> { { "DATA1",  String.Format("c {0}",dateTimePicker1.Value.ToShortDateString()) },
            { "DATA2", String.Format("по {0}",dateTimePicker2.Value.ToShortDateString()) },
            {"WHO", String.Format(" {0}",s)},
            {"SUM",String.Format("Сумма: {0}",GetSumOtchet())}
            };
            new NewWord().MakeWordDoc("\\temp_otchet.dotx", GetDataTableOtchet(), d);

        }




        #endregion

        /*
        private DataTable GetDataTableOtchetMonth( DateTime date)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

            return Form1.SQLQuery(
                String.Format("SELECT ClientName,Type,day,SUM FROM {0} WHERE (day >= @day1 AND day <= @day2 and Active = 'true');", "Sells"),
                new Dictionary<string, object> { { "@day1", firstDayOfMonth }, { "@day2", lastDayOfMonth } }
                );
        }

        */

        private decimal GetSumOtchetMonth(DateTime date)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

            decimal arenda = 0;

            if (!decimal.TryParse(textBoxArenda.Text, out arenda))
            {
                MessageBox.Show("Введие цифры", "Error", MessageBoxButtons.OK);
                return 0;
            }

            DataTable dt = Form1.SQLQuery(
                String.Format("SELECT SUM(SUM) as Sum FROM {0} WHERE (day >= @day1 AND day <= @day2 and Active = 'true' and Type = 'Продажа');", "Sells"),
                new Dictionary<string, object> { { "@day1", firstDayOfMonth }, { "@day2", lastDayOfMonth } }
                );

            decimal sum;
            object d = dt.Rows[0].ItemArray[0];
            if (!(d is System.DBNull))
            {
                sum = (decimal)d;

            }
            else
            {
                sum = 0;
            }
            

            DataTable dt2 = Form1.SQLQuery(String.Format("SELECT SUM(zp) as Sum FROM {0};", "Imp"), null);

            decimal sum2 = (decimal)dt2.Rows[0].ItemArray[0];

            DataTable dt3 = Form1.SQLQuery(
                String.Format("SELECT SUM(SUM) as Sum FROM {0} WHERE (day >= @day1 AND day <= @day2 and Active = 'true' and Type = 'Покупка');", "Sells"),
                new Dictionary<string, object> { { "@day1", firstDayOfMonth }, { "@day2", lastDayOfMonth } }
                );


            decimal sum3;
            object d3 = dt3.Rows[0].ItemArray[0];
            if (!(d3 is System.DBNull))
            {
                sum3 = (decimal)d3;

            }
            else
            {
                sum3 = 0;
            }

            return sum - Decimal.Multiply(sum2, (decimal)1.13) - sum3 - arenda;
        }

        /// <summary>
        /// Отчет по Месецам обновить таблицу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePickerMontOnly.Value;
            label4.Text = String.Format(" {1} : {0:C}",GetSumOtchetMonth(date),date.ToString("MMMM"));

        }

        /*

        /// <summary>
        /// Отчет по Месецам в Ворд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePickerMontOnly.Value;

            Dictionary<string, object> d = new Dictionary<string, object> { { "DATA1", String.Format("за {0}",dateTimePicker1.Value.ToString("MMMM")) },
            { "DATA2", "" },
            {"WHO", ""},
            {"SUM",String.Format("Сумма: {0}",GetSumOtchetMonth(date))}
            };
            new NewWord().MakeWordDoc("\\temp_otchet.dotx", GetDataTableOtchetMonth(date), d);
            
        }
          
        */


        private void OtchetTab_Changed(object sender, EventArgs e)
        {
            TabControl tc = (TabControl)sender;
            string s = (string)tc.SelectedTab.Tag;
            switch (s)
            {
                case "Tab1":
                    BindDataCB(comboBoxOtchetByName,"Imp","name");
                    break;
                case "Tab2":
                    break;
                case "Tab3":
                    //GenerateChart();
                    break;
                default:
                    break;
            }
        }

       

        private List<string> GetListOfProiz()
        {
            DataTable dt = null;

            dt = SQLQuery(String.Format("select name from Goods"), null);

            List<string> s = dt.AsEnumerable().Select(x => x[0].ToString().Split(new Char[] { ' ' }).Last()).Distinct().ToList();

            return s;
            //cb.DisplayMember = colom_name;
        }

        private DataTable GetTableForProizOtchet(DateTime date)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            DataTable dt = new DataTable();
            dt.Columns.Add("Производитель", typeof(string));
	        dt.Columns.Add("Сумма", typeof(object));
            List<string> proiz = GetListOfProiz();
            foreach (string proiz_name in proiz)
            {
                DataTable temp = Form1.SQLQuery(
                    String.Format("SELECT SUM(chena) as SUM FROM SellInfo as si left join Sells as s on si.idofsell = s.ID where si.name like '%{0}%' and s.Type = 'Продажа' and s.day >= @day1 AND s.day <= @day2 and s.Active = 'true'", proiz_name),
                new Dictionary<string, object> { { "@day1", firstDayOfMonth }, { "@day2", lastDayOfMonth }/*, { "@name", proiz_name }*/ }
                );
                object d = temp.Rows[0].ItemArray[0];
                if (!(d is System.DBNull))
                {
                    dt.Rows.Add(proiz_name, d);
                }
                else
                {
                    dt.Rows.Add(proiz_name, 0);
                }
                
            }
            return dt;
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker3.Value;
            dataGridViewOtchetProiz.DataSource = GetTableForProizOtchet(date);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            GenerateChart();
        }

        private void GenerateChart()
        {

            List<String> proiz = GetListOfProiz();
            chart1.Series.Clear();
            foreach (String item in proiz)
            {
                chart1.Series.Add(item);
                chart1.Series[item].ChartType = SeriesChartType.Line;
                chart1.Series[item].BorderWidth = 3;
                chart1.Series[item].MarkerStyle = MarkerStyle.Circle;
                chart1.Series[item].ToolTip = "#SERIESNAME : #VALY{F2}";
            }

            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;

            /*
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            */

            List<String> names = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList();
            names.RemoveAt(12);
            DateTime date = DateTime.Now.AddYears(-1).AddMonths(1);
            for (int i = 1; i < 13; i++)
            {
                DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                DateTime lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(DateTime.Now.Year, date.Month));
                
                foreach (String item in proiz)
                {
                    DataTable temp = Form1.SQLQuery(
                    String.Format("SELECT SUM(chena) as SUM FROM SellInfo as si left join Sells as s on si.idofsell = s.ID where si.name like '%{0}%' and s.Type = 'Продажа' and s.day >= @day1 AND s.day <= @day2 and s.Active = 'true'", item),
                new Dictionary<string, object> { { "@day1", firstDayOfMonth }, { "@day2", lastDayOfMonth }/*, { "@name", proiz_name }*/ }
                );
                    object d = temp.Rows[0].ItemArray[0];
                    if (!(d is System.DBNull))
                    {
                        chart1.Series[item].Points.AddXY(date.ToString("MMMM - yy") ,d);
                        
                    }
                    else
                    {
                        chart1.Series[item].Points.AddXY(date.ToString("MMMM - yy"), 0);
                    }
                    //chart1.Series[item].Points.AddXY(month, random.Next(5, 95));
                }
                date = date.AddMonths(1);
            }
        }

        private void GenerateChart2()
        {

            chart1.Series.Clear();
            chart1.Series.Add("Доход");
            chart1.Series["Доход"].ChartType = SeriesChartType.Line;
            chart1.Series["Доход"].BorderWidth = 3;
            chart1.Series["Доход"].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["Доход"].ToolTip = "#SERIESNAME : #VALY{F2}";

            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;


            List<String> names = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList();
            names.RemoveAt(12);
            DateTime date = DateTime.Now.AddYears(-1).AddMonths(1);
            for (int i = 1; i < 13; i++)
            {

                object d = GetSumOtchetMonth(date);
                if (!(d is System.DBNull))
                {
                    chart1.Series["Доход"].Points.AddXY(date.ToString("MMMM - yy"), d);

                }
                else
                {
                    chart1.Series["Доход"].Points.AddXY(date.ToString("MMMM - yy"), 0);
                }
                //chart1.Series[item].Points.AddXY(month, random.Next(5, 95));
                date = date.AddMonths(1);
            }



        }

        private void button11_Click(object sender, EventArgs e)
        {
            GenerateChart2();
        }




    }
}

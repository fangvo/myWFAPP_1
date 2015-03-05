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
        String name,type;
        MyDataGrid dataGrid = new MyDataGrid();
        int number;
        DateTime date;
        Boolean isFirst;

        public SellsInfoForm(String _name,DateTime _date,int _id,string _type,Boolean _bool)
        {
            InitializeComponent();
            dataGrid.dataGrid = dataGridView1;
            dataGrid.table_name = "SellInfo";
            number = 0;
            name = _name;
            type = _type;
            date = _date;
            id = _id;
            isFirst = _bool;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void SellsInfoForm_Load(object sender, EventArgs e)
        {
            refereshDG(dataGrid);
            Form1.BindDataCB(comboBox1, "Goods", "name");
            if (!isFirst)
            {
                Dictionary<string, object> d = new Dictionary<string, object>();
                string cmdtext = "select max(num) as max from SellInfo where idofsell = @id";
                d.Add("@id", id);
                using (DataTable dt = Form1.SQLQuery(cmdtext, d))
                {

                    object temp_id = dt.Rows[0].ItemArray[0];
                    number = Convert.ToInt32(temp_id);
                }
                SumMethod(dataGrid, false);

            }
        }

        private void refereshDG(MyDataGrid dg)
        {
            Dictionary<string,object> d = new Dictionary<string,object>();
            string cmd = string.Format("SELECT sellinfo.num AS [№],sellinfo.name,sellinfo.ed as [колво],Goods.ed,sellinfo.chena as [Цена] ,Goods.articyl,Goods.cod FROM {0} sellinfo inner join Goods on sellinfo.name = Goods.name  WHERE idofsell = @id ORDER BY sellinfo.num", dg.table_name);
            d.Add("@id", id);
            DataTable dt = Form1.SQLQuery(cmd, d);
            dg.dataGrid.DataSource = dt;          
        }

        private void SumMethod(MyDataGrid dg,bool update)
        {

                Dictionary<string, object> d = new Dictionary<string, object>();
                Dictionary<string, object> d2 = new Dictionary<string, object>();

                string cmdtext = String.Format("SELECT SUM(chena) as summ from {0} WHERE idofsell = @id", dg.table_name);
                d.Add("@id", id);
                DataTable dt = Form1.SQLQuery(cmdtext, d);
                object o = dt.Rows[0].ItemArray[0];

                label3.Text = o.ToString();
                if (update)
                {
                    String text = "update SELLS set SUM = @sum where ID = @id";
                    d2.Add("@id", id);
                    d2.Add("@SUM", o);
                    Form1.SQLExecuteNonQuery(text, d2);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name_goods = comboBox1.Text;
            Dictionary<string, object> d = new Dictionary<string, object>();
            string cmdtext;
            int ed;
            int kolvo = 0;
            decimal chena = 0;


            if (!int.TryParse(textBox1.Text, out ed))
            {
                MessageBox.Show("Введие цифры", "Error", MessageBoxButtons.OK);
                return;
            }
            cmdtext = "Select kolvo,chena from Goods where name = @name";
            d.Add("@name", name_goods);
            using (DataTable dt = Form1.SQLQuery(cmdtext, d))
            {
                kolvo = (int)dt.Rows[0].ItemArray[0];
                chena = (decimal)dt.Rows[0].ItemArray[1];
            }

            if (kolvo == 0 && type.Equals("Продажа"))
            {
                MessageBox.Show("Товара нет", "Error", MessageBoxButtons.OK);
                return;
                
            }
            else if (ed <= kolvo && type.Equals("Продажа"))
            {
                kolvo -= ed;
            }
            else if (ed > kolvo && kolvo > 0 && type.Equals("Продажа"))
            {
                ed = kolvo;
                kolvo = 0;
            }
            else if (type.Equals("Покупка"))
            {
                kolvo += ed;
            }
            cmdtext = "update Goods set kolvo = @kolvo where name = @name";
            d.Clear();
            d.Add("@kolvo", kolvo);
            d.Add("@name", name_goods);
            Form1.SQLExecuteNonQuery(cmdtext, d);


            if (isFirst)
            {
                decimal sum = ed*chena;
                cmdtext = "INSERT INTO Sells VALUES ( @name,@type,@date,@sum )";
                d.Clear();
                d.Add("@name", name);
                d.Add("@type", type);
                d.Add("@sum", sum);
                d.Add("@date", date.Date.ToShortDateString());
                Form1.SQLExecuteNonQuery(cmdtext, d);
                isFirst = false;
                ;
            }

            bool Update = true;
            cmdtext = "SELECT COUNT(*) AS RowCnt FROM SellInfo WHERE name = @name and idofsell = @id";
            d.Clear();
            d.Add("@name", name_goods);
            d.Add("@id", id);
            using (DataTable dt = Form1.SQLQuery(cmdtext, d))
            {

                object temp_id = dt.Rows[0].ItemArray[0];
                int temp = Convert.ToInt32(temp_id);
                if (temp == 0)
                {
                    Update = false;
                }
            }

            if (Update)
            {
                int newed = ed;
                cmdtext = "SELECT ed FROM SellInfo WHERE name = @name and idofsell = @id";
                d.Clear();
                d.Add("@name", name_goods);
                d.Add("@id", id);
                using (DataTable dt = Form1.SQLQuery(cmdtext, d))
            {

                object temp_id = dt.Rows[0].ItemArray[0];
                newed += Convert.ToInt32(temp_id);
            }
                cmdtext = "update SellInfo set ed = @kolvo, chena = @chena where name = @name and idofsell = @id";
                d.Clear();
                d.Add("@kolvo", newed);
                d.Add("@name", name_goods);
                d.Add("@id", id);
                d.Add("@chena", chena * newed);
                Form1.SQLExecuteNonQuery(cmdtext, d);

            }
            else
            {
                number++;
                cmdtext = "INSERT INTO SellInfo VALUES ( @num, @name, @ed, @id,@chena )";
                d.Clear();
                d.Add("@num", number);
                d.Add("@name", name_goods);
                d.Add("@ed", ed);
                d.Add("@id", id);
                d.Add("@chena", chena*ed);
                Form1.SQLExecuteNonQuery(cmdtext, d);
                
            }

            refereshDG(dataGrid);
            SumMethod(dataGrid,true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new NewWord("many many text", dataGrid).MakeWordDoc("\\temp.dotx");
        }

        



    }
}

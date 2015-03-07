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
        Boolean isFirst,active;

        public SellsInfoForm(String _name,DateTime _date,int _id,string _type,Boolean _bool,Boolean _active)
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
            active = _active;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void SellsInfoForm_Load(object sender, EventArgs e)
        {
            refereshDG(dataGrid);
            checkBox1.Checked = active;
            Form1.BindDataCB(comboBox1, "Goods", "name");
            if (!isFirst)
            {
                GetMaxNum();
            }
        }

        private void GetMaxNum()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            string cmdtext = "select max(num) as max from SellInfo where idofsell = @id";
            d.Add("@id", id);
            using (DataTable dt = Form1.SQLQuery(cmdtext, d))
            {

                object temp_id = dt.Rows[0].ItemArray[0];
                number = Convert.ToInt32(temp_id);
            }
            //SumMethod(dataGrid, false);
        }

        private void refereshDG(MyDataGrid dg)
        {
            Dictionary<string,object> d = new Dictionary<string,object>();
            string cmd = string.Format("SELECT sellinfo.num AS [№],sellinfo.name,sellinfo.ed as [колво],Goods.ed,sellinfo.chena as [Цена] ,Goods.articyl,Goods.cod FROM {0} sellinfo inner join Goods on sellinfo.name = Goods.name  WHERE idofsell = @id ORDER BY sellinfo.num", dg.table_name);
            d.Add("@id", id);
            DataTable dt = Form1.SQLQuery(cmd, d);
            dg.dataGrid.DataSource = dt;
            dg.table = dt;
        }

        private decimal SUMNumber()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            string cmdtext = String.Format("SELECT SUM(chena) as summ from {0} WHERE idofsell = @id", dataGrid.table_name);
            d.Add("@id", id);
            DataTable dt = Form1.SQLQuery(cmdtext, d);
            return (decimal)dt.Rows[0].ItemArray[0];
        }

        private void SumMethod(MyDataGrid dg,bool update)
        {

                
                Dictionary<string, object> d2 = new Dictionary<string, object>();

                decimal d = SUMNumber();

                label3.Text = d.ToString();
                if (update)
                {
                    String text = "update SELLS set SUM = @sum where ID = @id";
                    d2.Add("@id", id);
                    d2.Add("@SUM", d);
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


            d.Add("@name", name_goods);
            using (DataTable dt = Form1.SQLQuery("Select kolvo,chena from Goods where name = @name", d))
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


            if (type.Equals("Продажа"))
            {
                cmdtext = "update Goods set kolvo = @kolvo, Last = @date where name = @name";
                d.Clear();
                d.Add("@kolvo", kolvo);
                d.Add("@name", name_goods);
                d.Add("@date", date);
                Form1.SQLExecuteNonQuery(cmdtext, d);
            }
            else
            {
                cmdtext = "update Goods set kolvo = @kolvo where name = @name";
                d.Clear();
                d.Add("@kolvo", kolvo);
                d.Add("@name", name_goods);
                Form1.SQLExecuteNonQuery(cmdtext, d);
            }
            


            if (isFirst)
            {
                decimal sum = ed*chena;
                cmdtext = "INSERT INTO Sells VALUES ( @name,@type,@date,@sum,@who,@active,null )";
                d.Clear();
                d.Add("@name", name);
                d.Add("@type", type);
                d.Add("@sum", sum);
                d.Add("@date", date.Date.ToShortDateString());
                d.Add("@active", active);
                d.Add("@who", Properties.Settings.Default.CurName);
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
            new NewWord().MakeWordDoc("\\temp.dotx", dataGrid.table, new Dictionary<string, object> { { "NUMBER", id }, { "DATE", date }, { "SUM", String.Format("Сумма: {0}", SUMNumber()) } });
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            active = checkBox1.Checked;
            if (!isFirst)
            {
                Form1.SQLExecuteNonQuery("update SELLS set Active = @active where ID = @id", new Dictionary<string, object> { { "@active", active }, { "@id", id } });
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> d =  new Dictionary<string, object>();
            DataTable dt = Form1.SQLQuery(String.Format("Select * from Clients where [Клиент] = '{0}'", name), null);
            d.Add("NUM", id);
            if (type.Equals("Покупка"))
            {
                d.Add("NAME1", dt.Rows[0].ItemArray[1]);
                d.Add("INN1", dt.Rows[0].ItemArray[3]);
                d.Add("KPP1", dt.Rows[0].ItemArray[4]);
                d.Add("ADRES1", dt.Rows[0].ItemArray[2]);
                d.Add("RS1", dt.Rows[0].ItemArray[6]);
                d.Add("BANK1", dt.Rows[0].ItemArray[5]);
                d.Add("KS1", dt.Rows[0].ItemArray[7]);
                d.Add("BIK1", dt.Rows[0].ItemArray[8]);
                d.Add("DIRECTOR1", dt.Rows[0].ItemArray[10]);

                d.Add("NAME2", Properties.Settings.Default.MyComName);
                d.Add("INN2", Properties.Settings.Default.MyComINN);
                d.Add("KPP2", Properties.Settings.Default.MyComKPP);
                d.Add("ADRES2", Properties.Settings.Default.MyComAdres);
                d.Add("RS2", Properties.Settings.Default.MyComRS);
                d.Add("BANK2", Properties.Settings.Default.MyComBank);
                d.Add("KS2", Properties.Settings.Default.MyComKS);
                d.Add("BIK2", Properties.Settings.Default.MyComBIK);
                d.Add("DIRECTOR2", Properties.Settings.Default.MyComDirector);
            }
            else
            {
                d.Add("NAME2", dt.Rows[0].ItemArray[1]);
                d.Add("INN2", dt.Rows[0].ItemArray[3]);
                d.Add("KPP2", dt.Rows[0].ItemArray[4]);
                d.Add("ADRES2", dt.Rows[0].ItemArray[2]);
                d.Add("RS2", dt.Rows[0].ItemArray[6]);
                d.Add("BANK2", dt.Rows[0].ItemArray[5]);
                d.Add("KS2", dt.Rows[0].ItemArray[7]);
                d.Add("BIK2", dt.Rows[0].ItemArray[8]);
                d.Add("DIRECTOR2", dt.Rows[0].ItemArray[10]);

                d.Add("NAME1", Properties.Settings.Default.MyComName);
                d.Add("INN1", Properties.Settings.Default.MyComINN);
                d.Add("KPP1", Properties.Settings.Default.MyComKPP);
                d.Add("ADRES1", Properties.Settings.Default.MyComAdres);
                d.Add("RS1", Properties.Settings.Default.MyComRS);
                d.Add("BANK1", Properties.Settings.Default.MyComBank);
                d.Add("KS1", Properties.Settings.Default.MyComKS);
                d.Add("BIK1", Properties.Settings.Default.MyComBIK);
                d.Add("DIRECTOR1", Properties.Settings.Default.MyComDirector);
            }
            
            new NewWord().MakeWordDoc("\\dogovor.dotx", d, id,checkBox2.Checked);
        }

        



    }
}

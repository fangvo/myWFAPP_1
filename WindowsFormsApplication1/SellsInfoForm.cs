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

        }

        private void SellsInfoForm_Load(object sender, EventArgs e)
        {
            refereshDG(dataGrid);
            Form1.BindDataCB(comboBox1, "Goods", "name");
            if (!isFirst)
            {
            DateTime date = DateTime.Now;
            using (SqlConnection con = new SqlConnection(Form1.connectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select max(num) as max from SellInfo where idofsell = @id";
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = null;
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    object temp_id = sdr.GetValue(0);
                    number = Convert.ToInt32(temp_id);
                }
            }
            }
        }

        private void refereshDG(MyDataGrid dg)
        {
            using (SqlConnection connection = new SqlConnection(Form1.connectionString))
            {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = string.Format("SELECT sellinfo.num AS [№],sellinfo.name,sellinfo.ed as [колво],Goods.ed,sellinfo.chena as [Цена] ,Goods.articyl,Goods.cod FROM {0} sellinfo inner join Goods on sellinfo.name = Goods.name  WHERE idofsell = @id ORDER BY sellinfo.num", dg.table_name);
            cmd.Parameters.AddWithValue("@id", id);
            connection.Open();
            dg.adapter = new SqlDataAdapter(cmd);
            dg.ds = new DataSet();
            dg.adapter.Fill(dg.ds, dg.table_name);
            dg.table = dg.ds.Tables[dg.table_name];
            connection.Close();
            dg.dataGrid.DataSource = dg.ds.Tables[dg.table_name];

            connection.Close();
            dg.dataGrid.ReadOnly = true;
            dg.dataGrid.AllowUserToAddRows = false;
            dg.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg.dataGrid.Refresh();


            connection.Open();
            cmd.CommandText = String.Format("SELECT SUM(chena) as summ from {0} WHERE idofsell = @id", dg.table_name);
            SqlDataReader sdr = null;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string sumtext =  sdr.GetValue(0).ToString();
                label3.Text = sumtext;
            }
            sdr.Close();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name_goods = comboBox1.Text;
            int ed;
            int kolvo = 0;
            decimal chena = 0;
            if (!int.TryParse(textBox1.Text, out ed))
            {
                MessageBox.Show("Введие цифры", "Error", MessageBoxButtons.OK);
                return;
            }
            SqlConnection conn = new SqlConnection(Form1.connectionString);
            SqlCommand cmd = conn.CreateCommand();
            if (isFirst)
            {
                cmd.CommandText = "INSERT INTO Sells VALUES ( @name,@type,@date )";
                cmd.Parameters.Clear();
                SqlParameter sinceDateTimeParam = new SqlParameter("@date", SqlDbType.DateTime);
                sinceDateTimeParam.Value = date;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.Add(sinceDateTimeParam);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                isFirst = false;
                ;
            }
            cmd.CommandText = "Select kolvo,chena from Goods where name = @name";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", name_goods);
            SqlDataReader sdr = null;
            conn.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                kolvo = (int)sdr["kolvo"];
                chena = (decimal)sdr["chena"];

            }

            conn.Close();

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
            cmd.CommandText = "update Goods set kolvo = @kolvo where name = @name";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@kolvo", kolvo);
            cmd.Parameters.AddWithValue("@name", name_goods);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            bool Update = true;
            cmd.CommandText = "SELECT COUNT(*) AS RowCnt FROM SellInfo WHERE name = @name and idofsell = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", name_goods);
            cmd.Parameters.AddWithValue("@id", id);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                object temp_id = sdr.GetValue(0);
                int temp = Convert.ToInt32(temp_id);
                if (temp == 0)
                {
                    Update = false;
                }
            }
            sdr.Close();
            conn.Close();

            if (Update)
            {
                int newed = ed;
                cmd.CommandText = "SELECT ed FROM SellInfo WHERE name = @name and idofsell = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", name_goods);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    object temp_id = sdr.GetValue(0);
                    newed += Convert.ToInt32(temp_id);
                }
                sdr.Close();
                conn.Close();

                cmd.CommandText = "update SellInfo set ed = @kolvo, chena = @chena where name = @name and idofsell = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kolvo", newed);
                cmd.Parameters.AddWithValue("@name", name_goods);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@chena", chena * newed);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                number++;
                cmd.CommandText = "INSERT INTO SellInfo VALUES ( @num, @name, @ed, @id,@chena )";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@num", number);
                cmd.Parameters.AddWithValue("@name", name_goods);
                cmd.Parameters.AddWithValue("@ed", ed);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@chena", chena*ed);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                
            }

            refereshDG(dataGrid);

            
            
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //new OpenXml("temp.dotx", "new.docx").GenerateDocument();
            //new ToWord().MakeWordDoc(name,date,id,dataGrid);
            new NewWord("many many text", dataGrid).MakeWordDoc("\\temp.dotx");
            //dataGrid.table.Rows[0];
        }

        



    }
}

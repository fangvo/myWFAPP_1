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

        int id,index;
        String name;
        MyDataGrid dataGrid = new MyDataGrid();
        int number;
        DateTime date;
        Boolean isFirst;

        public SellsInfoForm(String _name,DateTime _date,int _id,Boolean _bool)
        {
            InitializeComponent();
            dataGrid.dataGrid = dataGridView1;
            dataGrid.table_name = "SellInfo";
            number = 0;
            name = _name;
            date = _date;
            id = _id;
            isFirst = _bool;

        }

        private void SellsInfoForm_Load(object sender, EventArgs e)
        {
            refereshDG(dataGrid);
            Form1.BindDataCB(comboBox1, "Goods", "name");
        }

        private void refereshDG(MyDataGrid dg)
        {
            SqlConnection connection = new SqlConnection(Form1.connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = string.Format("SELECT sellinfo.num AS [№],sellinfo.name,sellinfo.ed as [колво],Goods.ed,Goods.articyl,Goods.cod FROM {0} sellinfo inner join Goods on sellinfo.name = Goods.name  WHERE idofsell = @id ORDER BY sellinfo.num", dg.table_name);
            cmd.Parameters.AddWithValue("@id", id);
            connection.Open();

            dg.adapter = new SqlDataAdapter(cmd);
            SqlCommandBuilder sBuilder = new SqlCommandBuilder(dg.adapter);
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


        }

        private void button1_Click(object sender, EventArgs e)
        {
            number++;
            String name = comboBox1.Text;
            int ed;
            int kolvo = 0;
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
                SqlParameter sinceDateTimeParam = new SqlParameter("@date", SqlDbType.DateTime);
                sinceDateTimeParam.Value = date;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@type", "Продажа");
                cmd.Parameters.Add(sinceDateTimeParam);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                isFirst = false;
            }
            cmd.CommandText = "Select kolvo from Goods where name = @name";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", name);
            SqlDataReader sdr = null;
            conn.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                kolvo = (int)sdr["kolvo"];
            }

            conn.Close();

            if (kolvo == 0 && index == 1)
            {
                MessageBox.Show("Товара нет", "Error", MessageBoxButtons.OK);
                number--;
                return;
                
            }
            else if (ed <= kolvo && index == 1)
            {
                kolvo -= ed;
            }
            else if (ed > kolvo && kolvo>0 && index == 1)
            {
                ed = kolvo;
                kolvo = 0;
            }
            else if (index == 0)
            {
                kolvo += ed;
            }
            cmd.CommandText = "update Goods set kolvo = @kolvo where name = @name";
            cmd.Parameters.AddWithValue("@kolvo", kolvo);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.CommandText = "INSERT INTO SellInfo VALUES ( @num, @name, @ed, @id )";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num", number);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@ed", ed);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
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

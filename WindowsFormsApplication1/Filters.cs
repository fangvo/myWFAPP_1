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
    public partial class Filters : Form
    {
        private List<ControlSet> contrSet;
        public List<FiltersValls> filterList;
        MyDataGrid f;
        string type;

        static List<String> headers;
        List<string> cb_4_list = new List<string> { "И", "ИЛИ" };

        public class ControlSet
        {
            public System.Windows.Forms.ComboBox comboBox1 { get; set; }
            public System.Windows.Forms.ComboBox comboBox2 { get; set; }
            public System.Windows.Forms.ComboBox comboBox3 { get; set; }
            public System.Windows.Forms.ComboBox comboBox4 { get; set; }
        }

        public class FiltersValls
        {
            public string coll { get; set; }
            public object vall { get; set; }
            public string param { get; set; }
            public string type { get; set; }

        }

        public Filters(List<String> _headers,object _f,string _type)
        {
            InitializeComponent();
            headers = _headers;
            f = (MyDataGrid)_f;
            type = _type;
            headers[0] = "";
            contrSet = new List<ControlSet>();
            filterList = new List<FiltersValls>();
            contrSet.Add(new ControlSet());
            filterList.Add(new FiltersValls { coll = "", vall = "", param = "",type = "" });
            CreateMyControl(contrSet.Count - 1);
            this.Load += Filters_Load;
            this.buttonAdd.Click += button_Click;
            this.buttonBack.Click += button_Click;
            this.buttonRem.Click += button_Click;
            this.buttonAplay.Click += button_Click;
            this.buttonSbros.Click += button_Click;

        }

        #region events
        void Filters_Load(object sender, EventArgs e)
        {
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            int cb_id = (int)cb.Tag;
            ComboBox cb_3 = contrSet[cb_id].comboBox3;
            String text_cb = cb.SelectedItem.ToString();
            filterList[cb_id].coll = text_cb;
            List<object> s = BindDataCB(cb_3, f.table_name, text_cb);
            if (s[0] is string)
            {
                contrSet[cb_id].comboBox2.DataSource = new List<string> {"Равно","Не Равно" };
            }
            if (s[0] is long || s[0] is int || s[0] is decimal || s[0] is DateTime)
            {
                contrSet[cb_id].comboBox2.DataSource = new List<string> { "Равно", "Не Равно",">=","<=" };
            }
            filterList[cb_id].vall = s[0];

        }

        void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            int cb_id = (int)cb.Tag;
            string index = cb.SelectedItem.ToString();
            filterList[cb_id].type = index;
        }

        void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            int cb_id = (int)cb.Tag;
            int index = cb.SelectedIndex;
            object text_cb = cb.SelectedItem;
            
            filterList[cb_id].vall = text_cb;
        }

        void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            int cb_id = (int)cb.Tag;
            String text_cb = cb.SelectedItem.ToString();
            filterList[cb_id].param = text_cb;
        }

        void button_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            String s = but.Tag.ToString();
            switch (s)
            {
                case "add" :
                    contrSet.Add(new ControlSet());
                    filterList.Add(new FiltersValls { coll = "", vall = "", param = "", type = "" });
                    CreateMyControl(contrSet.Count-1);
                    AddOneMoreCB();
                    filterList[contrSet.Count - 2].param = "И";
                    break;
                case "rem":
                    RemoveLastItemFromControls();
                    break;
                case "back":
                    this.Visible = false;
                    break;
                case "aplay":
                    Form1.RefreshDGV(filterList,f,type);
                    break;
                case "sbros":
                    RemoveAllControl();
                    break;
                default:
                    break;
            }
        }

        private void RemoveAllControl()
        {
            foreach (ControlSet cstoRemove in contrSet)
	        {
		        this.Controls.Remove(cstoRemove.comboBox1);
                this.Controls.Remove(cstoRemove.comboBox2);
                this.Controls.Remove(cstoRemove.comboBox3);
                this.Controls.Remove(cstoRemove.comboBox4);
	        }
                this.Refresh();
                contrSet.Clear();
                filterList.Clear();
                contrSet.Add(new ControlSet());
                filterList.Add(new FiltersValls { coll = "", vall = "", param = "", type = "" });
                CreateMyControl(contrSet.Count - 1);
        }

        #endregion

        #region add/del

        private void AddOneMoreCB()
        {
            ControlSet set = contrSet[contrSet.Count-2];
            set.comboBox4 = new System.Windows.Forms.ComboBox();

            set.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            set.comboBox4.FormattingEnabled = true;
            set.comboBox4.Location = new System.Drawing.Point(410, 10 + ((contrSet.Count-2) * 30));
            set.comboBox4.Size = new System.Drawing.Size(45, 20);
            set.comboBox4.DataSource = new List<String>(cb_4_list);
            set.comboBox4.Tag = contrSet.Count-2;
            set.comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;

            this.Controls.Add(set.comboBox4);

        }



        private void RemoveLastItemFromControls()
        {
            int id = contrSet.Count - 1;
            if (id != 0)
            {
                filterList.RemoveAt(id);
                ControlSet cstoRemove = contrSet[id];
                this.Controls.Remove(cstoRemove.comboBox1);
                this.Controls.Remove(cstoRemove.comboBox2);
                this.Controls.Remove(cstoRemove.comboBox3);
                this.Controls.Remove(contrSet[id - 1].comboBox4);
                filterList[id - 1].param = "";
                contrSet.Remove(cstoRemove);
                this.Refresh();
            }
            
        }

        private void CreateMyControl(int id)
        {
            ControlSet set = contrSet[id];
            set.comboBox1 = new System.Windows.Forms.ComboBox();
            set.comboBox2 = new System.Windows.Forms.ComboBox();
            set.comboBox3 = new System.Windows.Forms.ComboBox();
            // 
            // comboBox1
            // 
            set.comboBox1.FormattingEnabled = true;
            set.comboBox1.Location = new System.Drawing.Point(10, 10 + (id * 30));//10//40/70/100
            //set.comboBox1.Name = String.Format("comboBox1_{0}", id);
            set.comboBox1.Size = new System.Drawing.Size(120, 20);
            set.comboBox1.Tag = id;

            set.comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            set.comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            set.comboBox1.DataSource = new List<string>(headers);
            set.comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            set.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            set.comboBox2.FormattingEnabled = true;
            set.comboBox2.Location = new System.Drawing.Point(135, 10 + (id * 30));
            //set.comboBox2.Name = String.Format("comboBox2_{0}", id);
            set.comboBox2.Size = new System.Drawing.Size(70, 20);
            //set.comboBox2.DataSource = new List<String>(cb_2_list);
            set.comboBox2.Tag = id;
            set.comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox3
            // 
            set.comboBox3.FormattingEnabled = true;
            set.comboBox3.Location = new System.Drawing.Point(210, 10 + (id * 30));
           // set.comboBox3.Name = String.Format("comboBox3_{0}", id);
            set.comboBox3.Size = new System.Drawing.Size(195, 20);
            set.comboBox3.Tag = id;
            set.comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;

            this.Controls.Add(set.comboBox3);
            this.Controls.Add(set.comboBox2);
            this.Controls.Add(set.comboBox1);

        }



        public List<object> BindDataCB(ComboBox cb, String table_name, String colom_name)
        {
            if (colom_name.Equals(""))
            {
                cb.DataSource = null;
                cb.Items.Clear();
                return  new List<object>{""};
            }
            cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            List<object> slist = new List<object>();


            
            using (SqlConnection con = new SqlConnection(Form1.connectionString))
            {
                con.Open();
                string strCmd = String.Format("select {0} from {1} group by {0}", colom_name, table_name);
                using (SqlCommand cmd = new SqlCommand(strCmd, con))
                {

                    SqlDataReader sdr = null;
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        slist.Add(sdr.GetValue(0));
                    }
                    cb.DataSource = slist;
                    sdr.Close();
                }
                return slist;
            }
            //cb.ValueMember = "field2";
            //cb.AutoCompleteCustomSource = dt[colom_name];

        }

        #endregion

        public static void BindDataCB(ComboBox cb)
        {
            cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb.AutoCompleteSource = AutoCompleteSource.ListItems;

            cb.DataSource = headers;
            //cb.DisplayMember = "column_name";

        }
    }
}
